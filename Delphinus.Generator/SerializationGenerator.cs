using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Scriban;

namespace Delphinus.Generator
{
    [Generator]
    public class SerializationGenerator : ISourceGenerator
    {
        private Template _packetTypeTemplate;
        private Template _serializationClassTemplate;
        private Template _serializationMethodTemplate;
        private Template _serializeStatementTemplate;
        private Template _deserializeStatementTemplate;

        private List<GenerationConfig> _configs;

        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new SerializationContextReceiver());
        }

        public void Execute(GeneratorExecutionContext context)
        {
            var receiver = (SerializationContextReceiver) context.SyntaxContextReceiver;
            if (receiver == null) throw new ArgumentNullException(nameof(receiver));

            _packetTypeTemplate = Utils.LoadTemplate(context, "packet-type");
            _serializationClassTemplate = Utils.LoadTemplate(context, "serialization-class");
            _serializationMethodTemplate = Utils.LoadTemplate(context, "serialization-method");
            _serializeStatementTemplate = Utils.LoadTemplate(context, "serialize-statement");
            _deserializeStatementTemplate = Utils.LoadTemplate(context, "deserialize-statement");

            LoadConfigs(context);
            foreach (var config in _configs)
            {
                GenerateNewPacketTypes(context, receiver, config);
                GenerateSerializationClass(context, receiver, config);
            }
        }

        private void LoadConfigs(GeneratorExecutionContext context)
        {
            var yamlDeserializer = new YamlDotNet.Serialization.Deserializer();
            _configs = context.AdditionalFiles
                .Where(f => f.Path.EndsWith("delphinus.yml", StringComparison.InvariantCultureIgnoreCase))
                .Distinct()
                .Select(f => yamlDeserializer.Deserialize<GenerationConfig>(
                    f.GetText(context.CancellationToken)?.ToString()))
                .ToList();
        }

        private void GenerateNewPacketTypes(
            GeneratorExecutionContext context,
            SerializationContextReceiver receiver,
            GenerationConfig config)
        {
            foreach (var packetType in receiver.PacketTypes)
            {
                var templateCtx = new TemplateContext();

                templateCtx.SetVar("using_statements", config.UsingStatements);
                templateCtx.SetVar("namespace", config.Namespace);
                templateCtx.SetVar("type_kind", config.TypeKind);
                templateCtx.SetVar("base_type", config.BaseType);
                templateCtx.SetVar("reader_type", config.Reader);
                templateCtx.SetVar("writer_type", config.Writer);
                templateCtx.SetVar("packet", "this");
                templateCtx.SetVar("packet_type_name", packetType.Identifier.Text);
                templateCtx.SetVar("members", packetType.Members);

                var serializeStatements = new List<string>();
                var deserializeStatements = new List<string>();
                foreach (var member in packetType.Members)
                {
                    serializeStatements.Add(RenderSerializeStatement(member, templateCtx, context, config));
                    deserializeStatements.Add(RenderDeserializeStatement(member, templateCtx, context, config));
                }

                templateCtx.SetVar("serialize_statements", serializeStatements);
                templateCtx.SetVar("deserialize_statements", deserializeStatements);

                var result = _packetTypeTemplate.Render(templateCtx);

                context.AddSource($"{packetType.Identifier.Text}", result);
            }
        }

        private void GenerateSerializationClass(
            GeneratorExecutionContext context,
            SerializationContextReceiver receiver,
            GenerationConfig config)
        {
            var templateCtx = new TemplateContext();

            templateCtx.SetVar("using_statements", config.UsingStatements);
            templateCtx.SetVar("namespace", config.Namespace);
            templateCtx.SetVar("type_kind", config.TypeKind);
            templateCtx.SetVar("base_type", config.BaseType);
            templateCtx.SetVar("reader_type", config.Reader);
            templateCtx.SetVar("writer_type", config.Writer);
            templateCtx.SetVar("packet", "packet");

            var methodTuples = new List<string>();
            foreach (var packetType in receiver.PacketTypes)
            {
                var subCtx = new TemplateContext(templateCtx.BuiltinObject);
                subCtx.SetVar("packet_type_name", packetType.Identifier.Text);
                subCtx.SetVar("members", packetType.Members);

                var serializeStatements = new List<string>();
                var deserializeStatements = new List<string>();

                foreach (var member in packetType.Members)
                {
                    serializeStatements.Add(RenderSerializeStatement(member, subCtx, context, config));
                    deserializeStatements.Add(RenderDeserializeStatement(member, subCtx, context, config));
                }

                subCtx.SetVar("serialize_statements", serializeStatements);
                subCtx.SetVar("deserialize_statements", deserializeStatements);

                methodTuples.Add(_serializationMethodTemplate.Render(templateCtx));
            }

            templateCtx.SetVar("method_tuples", methodTuples);

            var result = _serializationClassTemplate.Render(templateCtx);

            context.AddSource($"Serialization", result);
        }

        private string RenderSerializeStatement(
            MemberDeclarationSyntax memberDecl,
            TemplateContext context,
            GeneratorExecutionContext genContext,
            GenerationConfig config)
        {
            if (!IsPublicOrInternal(memberDecl.Modifiers) || IsStaticOrConstant(memberDecl.Modifiers))
                return "";

            if (memberDecl.FindAttribute("NoSerialization") != null)
                return "";

            AddProcessorsIntoContext(memberDecl, context, genContext, true);

            if (memberDecl is PropertyDeclarationSyntax propDecl)
            {
                context.SetVar("member_name", propDecl.Identifier.Text);
                context.SetVar("serializer", getSerializer(propDecl.Type.ToString()));
            }
            else if (memberDecl is FieldDeclarationSyntax fieldDecl)
            {
                context.SetVar("member_name", Utils.GetName(fieldDecl));
                context.SetVar("serializer", getSerializer(fieldDecl.Declaration.Type.ToString()));
            }

            string getSerializer(string typeName)
            {
                string serializer = null;
                if (config.CustomSerializers?.TryGetValue(typeName, out serializer) == true)
                    return Template.Parse(serializer).Render(context);
                else if (_defaultSerializer.TryGetValue(typeName, out serializer))
                    return Template.Parse(serializer).Render(context);
                else
                    throw new Exception($"No serializer for type: {typeName}"); //TODO: Custom exception type
            }

            return _serializeStatementTemplate.Render(context);
        }

        private string RenderDeserializeStatement(
            MemberDeclarationSyntax memberDecl,
            TemplateContext context,
            GeneratorExecutionContext genContext,
            GenerationConfig config)
        {
            if (!IsPublicOrInternal(memberDecl.Modifiers) || IsStaticOrConstant(memberDecl.Modifiers))
                return "";

            if (memberDecl.Modifiers.Any(m => m.Text == "readonly"))
                return "";

            if (memberDecl.FindAttribute("NoSerialization") != null)
                return "";

            AddProcessorsIntoContext(memberDecl, context, genContext, false);

            if (memberDecl is PropertyDeclarationSyntax propDecl)
            {
                if (propDecl.AccessorList?.Accessors.Any(a => a.Keyword.Text == "set") == true)
                {
                    context.SetVar("member_name", propDecl.Identifier.Text);
                    context.SetVar("deserializer", getDeserializer(propDecl.Type.ToString()));
                }
                else
                {
                    return "";
                }
            }
            else if (memberDecl is FieldDeclarationSyntax fieldDecl)
            {
                context.SetVar("member_name", Utils.GetName(fieldDecl));
                context.SetVar("deserializer", getDeserializer(fieldDecl.Declaration.Type.ToString()));
            }

            string getDeserializer(string typeName)
            {
                string deserializer = null;
                if (config.CustomDeserializers?.TryGetValue(typeName, out deserializer) == true)
                    return Template.Parse(deserializer).Render(context);
                else if (_defaultDserializer.TryGetValue(typeName, out deserializer))
                    return Template.Parse(deserializer).Render(context);
                else
                    throw new Exception($"No deserializer for type: {typeName}");//TODO: Custom exception type
            }

            return _deserializeStatementTemplate.Render(context);
        }

        private static void AddProcessorsIntoContext(
            MemberDeclarationSyntax memberDecl,
            TemplateContext context,
            GeneratorExecutionContext genContext,
            bool isSerialize)
        {
            context.SetVar("condition", null);
            context.SetVar("expression", null);
            for (int i = 0; i < 10; i++)
            {
                context.SetVar($"args[i]", null);
            }
            context.SetVar("code", null);

            var anotherSide = isSerialize ? "Deserialize" : "Serialize";
            var manualAttr = memberDecl.FindAttribute("Manual");
            var condAttr = memberDecl.FindAttribute("Condition");
            var exprAttr = memberDecl.FindAttribute("Expression");
            var argsAttr = memberDecl.FindAttribute("Arguments");

            if (manualAttr != null)
            {
                var code = GetCodeFromAttribute(manualAttr, isSerialize, genContext);
                if (code != null)
                {
                    context.SetVar("code", Template.Parse(code).Render(context));
                    return;
                }
            }

            var condition = GetCodeFromAttribute(condAttr, isSerialize, genContext);
            if (condition != null) condition = Template.Parse(condition).Render(context);

            var expression = GetCodeFromAttribute(exprAttr, isSerialize, genContext);
            if (expression != null) expression = Template.Parse(expression).Render(context);

            if (argsAttr?.ArgumentList != null && argsAttr.ArgumentList.Arguments.Count > 0)
            {
                for (int i = 0; i < argsAttr.ArgumentList.Arguments.Count; i++)
                {
                    var arg = argsAttr.ArgumentList.Arguments[i];
                    context.SetVar($"args{i}", Template.Parse(GetAttributeArgValueString(arg, genContext)).Render(context));
                }
            }

            context.SetVar("condition", condition);
            context.SetVar("expression", expression);
        }

        private bool IsPublicOrInternal(SyntaxTokenList modifiers)
            => modifiers.Any(m => m.Text == "public" || m.Text == "internal");

        private bool IsStaticOrConstant(SyntaxTokenList modifiers)
            => modifiers.Any(m => m.Text == "static" || m.Text == "const");

        private static string GetCodeFromAttribute(AttributeSyntax attr, bool isSerialize, GeneratorExecutionContext context)
        {
            if (attr != null)
            {
                var args = attr?.ArgumentList;
                if (args != null && args.Arguments.Count > 1)
                {
                    if (args.Arguments[1].ToString() == (isSerialize ? "Usage.Deserialize" : "Usage.Serialize"))
                    {
                        return null;
                    }
                    return isSerialize
                        ? GetAttributeArgValueString(args.Arguments[0], context)
                        : GetAttributeArgValueString(args.Arguments[1], context);
                }
                else if (args != null && args.Arguments.Count > 0)
                {
                    return GetAttributeArgValueString(args.Arguments.First(), context);
                }
            }

            return null;
        }

        private static string GetAttributeArgValueString(AttributeArgumentSyntax arg, GeneratorExecutionContext context)
            => context.Compilation.GetSemanticModel(arg.SyntaxTree).GetConstantValue(arg.Expression).ToString();

        private static Dictionary<string, string> InitDefaultSerializers()
        {
            var defaultSerializers = new Dictionary<string, string>();
            string[] primitiveTypes = new[]
            {
                "int", "uint", "long", "ulong", "short", "ushort", "byte", "sbyte",
                "float", "double", "decimal", "string", "bool", "char",
                "Int32", "Int64", "UInt32", "UInt64", "Int16", "UInt16", "Byte", "SByte",
                "Single", "Double", "Decimal", "String", "Boolean", "Char",
                "byte[]", "Byte[]", "char[]", "Char[]",
            };
            foreach (var type in primitiveTypes)
            {
                defaultSerializers.Add(type, "writer.Write(value)");
            }
            return defaultSerializers;
        }

        private static readonly Dictionary<string, string> _defaultSerializer = InitDefaultSerializers();

        private static readonly Dictionary<string, string> _defaultDserializer = new Dictionary<string, string>()
        {
            {"int", $"reader.{nameof(BinaryReader.ReadInt32)}()"},
            {"Int32", $"reader.{nameof(BinaryReader.ReadInt32)}()"},
            {"uint", $"reader.{nameof(BinaryReader.ReadUInt32)}()"},
            {"UInt32", $"reader.{nameof(BinaryReader.ReadUInt32)}()"},
            {"long", $"reader.{nameof(BinaryReader.ReadInt64)}()"},
            {"Int64", $"reader.{nameof(BinaryReader.ReadInt64)}()"},
            {"ulong", $"reader.{nameof(BinaryReader.ReadUInt64)}()"},
            {"UInt64", $"reader.{nameof(BinaryReader.ReadUInt64)}()"},
            {"short", $"reader.{nameof(BinaryReader.ReadInt16)}()"},
            {"Int16", $"reader.{nameof(BinaryReader.ReadInt16)}()"},
            {"ushort", $"reader.{nameof(BinaryReader.ReadUInt16)}()"},
            {"UInt16", $"reader.{nameof(BinaryReader.ReadUInt16)}()"},
            {"byte", $"reader.{nameof(BinaryReader.ReadByte)}()"},
            {"Byte", $"reader.{nameof(BinaryReader.ReadByte)}()"},
            {"sbyte", $"reader.{nameof(BinaryReader.ReadSByte)}()"},
            {"SByte", $"reader.{nameof(BinaryReader.ReadSByte)}()"},
            {"float", $"reader.{nameof(BinaryReader.ReadSingle)}()"},
            {"Single", $"reader.{nameof(BinaryReader.ReadSingle)}()"},
            {"double", $"reader.{nameof(BinaryReader.ReadDouble)}()"},
            {"Double", $"reader.{nameof(BinaryReader.ReadDouble)}()"},
            {"decimal", $"reader.{nameof(BinaryReader.ReadDecimal)}()"},
            {"Decimal", $"reader.{nameof(BinaryReader.ReadDecimal)}()"},
            {"string", $"reader.{nameof(BinaryReader.ReadString)}()"},
            {"String", $"reader.{nameof(BinaryReader.ReadString)}()"},
            {"bool", $"reader.{nameof(BinaryReader.ReadBoolean)}()"},
            {"Boolean", $"reader.{nameof(BinaryReader.ReadBoolean)}()"},
            {"char", $"reader.{nameof(BinaryReader.ReadChar)}()"},
            {"Char", $"reader.{nameof(BinaryReader.ReadChar)}()"},
        };
    }
}