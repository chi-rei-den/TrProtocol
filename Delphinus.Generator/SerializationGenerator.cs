using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Delphinus.Generator
{
    [Generator]
    public class SerializationGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new SerializationContextReceiver());
        }

        public void Execute(GeneratorExecutionContext context)
        {
            var receiver = (SerializationContextReceiver) context.SyntaxContextReceiver;
            if (receiver == null) throw new ArgumentNullException(nameof(receiver));
            if (receiver.Config == null)
            {
                throw new Exception("Config not found");
            }

            GenerateNewPacketTypes(context, receiver);
            GenerateStaticSerializeMethods(context, receiver);
            GenerateStaticDeserializeMethods(context, receiver);
        }

        private void GenerateNewPacketTypes(GeneratorExecutionContext context, SerializationContextReceiver receiver)
        {
            foreach (var packetType in receiver.PacketTypes)
            {
                var sb = new StringBuilder();

                foreach (var stmt in receiver.Config.UsingStatements)
                {
                    sb.AppendLine(stmt);
                }
                var packetName = packetType.Identifier.Text;
                sb.AppendLine($"namespace Delphinus.Packets {{");
                sb.AppendLine($"public {receiver.Config.TypeKind} {packetName} {{");

                foreach (var memberDecl in packetType.Members)
                {
                    sb.AppendLine(memberDecl.ToString());
                }

                sb.Append(GenerateSerializeMethod(packetType, receiver.Config, true));
                sb.Append(GenerateDeserializeMethod(packetType, receiver.Config, true));

                sb.AppendLine("}}");

                context.AddSource($"{packetName}", sb.ToString());
            }
        }


        #region Serialize

        private void GenerateStaticSerializeMethods(GeneratorExecutionContext context, SerializationContextReceiver receiver)
        {
            var sb = new StringBuilder();

            foreach (var stmt in receiver.Config.UsingStatements)
            {
                sb.AppendLine(stmt);
            }
            sb.AppendLine($"namespace Delphinus {{");
            sb.AppendLine("public static partial class Serialization {");

            foreach (var packetType in receiver.PacketTypes)
            {
                sb.Append(GenerateSerializeMethod(packetType, receiver.Config, false));
            }

            sb.AppendLine("}}");

            context.AddSource("Serialize.cs", sb.ToString());
        }

        private string GenerateSerializeMethod(TypeDeclarationSyntax typeDecl, GenerationConfig config, bool instanced)
        {
            var sb = new StringBuilder();
            if (instanced)
            {
                sb.AppendLine($"public void Serialize({config.Writer} writer) {{");
            }
            else
            {
                sb.AppendLine($"public static void Serialize(this {("Delphinus.Packets")}.{typeDecl.Identifier.Text} packet, {config.Writer} writer) {{");
            }
            foreach (var memberDeclaration in typeDecl.Members)
            {
                sb.AppendLine(GenerateSerializeStatement(memberDeclaration, config, instanced));
            }
            sb.Append("}");
            return sb.ToString();
        }

        private string GenerateSerializeStatement(MemberDeclarationSyntax memberDeclaration, GenerationConfig config, bool instanced)
        {
            if (!IsPublicOrInternal(memberDeclaration.Modifiers) || IsStaticOrConstant(memberDeclaration.Modifiers))
            {
                return "";
            }

            if (memberDeclaration.AttributeLists.Any(al
                => al.Attributes.Any(a
                    => (a.Name as SimpleNameSyntax)?.Identifier.Text == "NoSerialization")))
            {
                return "";
            }

            if (memberDeclaration is PropertyDeclarationSyntax propDecl)
            {
                return gen(propDecl.Type.ToString(), propDecl.Identifier.Text);
            }
            else if (memberDeclaration is FieldDeclarationSyntax fieldDecl)
            {
                return gen(fieldDecl.Declaration.Type.ToString(), Utils.GetName(fieldDecl));
            }

            string gen(string type, string data)
            {
                string serializer = null;
                if (config.CustomSerializers?.TryGetValue(type, out serializer) == true)
                {
                    return string.Format(serializer, $"{(instanced ? "this" : "packet")}.{data}");
                }
                if (_defaultSerializer.TryGetValue(type, out serializer))
                {
                    return string.Format(serializer, $"{(instanced ? "this" : "packet")}.{data}");
                }
                //TODO: Custom exception type
                throw new Exception($"No serializer for type: {type}");
            }
            return "";
        }

        #endregion


        #region Deserialize

        private void GenerateStaticDeserializeMethods(GeneratorExecutionContext context, SerializationContextReceiver receiver)
        {
            var sb = new StringBuilder();

            foreach (var stmt in receiver.Config.UsingStatements)
            {
                sb.AppendLine(stmt);
            }
            sb.AppendLine($"namespace Delphinus {{");
            sb.AppendLine("public static partial class Serialization {");

            foreach (var packetType in receiver.PacketTypes)
            {
                sb.Append(GenerateDeserializeMethod(packetType, receiver.Config, false));
            }

            sb.AppendLine("}}");

            context.AddSource("Deserialize.cs", sb.ToString());
        }

        private string GenerateDeserializeMethod(TypeDeclarationSyntax typeDecl, GenerationConfig config, bool instanced)
        {
            var sb = new StringBuilder();
            var fullname = "Delphinus.Packets." + typeDecl.Identifier.Text;
            if (instanced)
            {
                sb.AppendLine($"public void Deserialize({config.Reader} reader) {{");
            }
            else
            {
                //FIXME: This works on reference type only
                sb.AppendLine($"public static {fullname} Deserialize<T>(this {config.Reader} reader, {fullname} packet = null) where T : {fullname} {{");
                sb.AppendLine($"packet = new {fullname}();");
            }
            foreach (var memberDeclaration in typeDecl.Members)
            {
                sb.AppendLine(GenerateDeserializeStatement(memberDeclaration, config, instanced));
            }

            if (!instanced)
            {
                sb.AppendLine($"return packet;");
            }

            sb.AppendLine("}");

            return sb.ToString();
        }

        private string GenerateDeserializeStatement(MemberDeclarationSyntax memberDeclaration, GenerationConfig config, bool instanced)
        {
            if (!IsPublicOrInternal(memberDeclaration.Modifiers) || IsStaticOrConstant(memberDeclaration.Modifiers))
            {
                return "";
            }

            if (memberDeclaration.Modifiers.Any(m => m.Text == "readonly"))
            {
                return "";
            }

            if (memberDeclaration.AttributeLists.Any(al
                => al.Attributes.Any(a
                    => (a.Name as SimpleNameSyntax)?.Identifier.Text == "NoSerialization")))
            {
                return "";
            }

            if (memberDeclaration is PropertyDeclarationSyntax propDecl)
            {
                if (propDecl.AccessorList?.Accessors.Any(a => a.Keyword.Text == "set") == true)
                {
                    return gen(propDecl.Type.ToString(), propDecl.Identifier.Text);
                }
            }
            else if (memberDeclaration is FieldDeclarationSyntax fieldDecl)
            {
                return gen(fieldDecl.Declaration.Type.ToString(), Utils.GetName(fieldDecl));
            }

            string gen(string type, string data)
            {
                string deserializer = null;
                if (config.CustomDeserializers?.TryGetValue(type, out deserializer) == true)
                {
                    return string.Format(deserializer, $"{(instanced ? "this" : "packet")}.{data}");
                }
                if (_defaultDserializer.TryGetValue(type, out deserializer))
                {
                    return string.Format(deserializer, $"{(instanced ? "this" : "packet")}.{data}");
                }
                //TODO: Custom exception type
                throw new Exception($"No deserializer for type: {type}");
            }
            return "";
        }


        #endregion


        private bool IsPublicOrInternal(SyntaxTokenList modifiers)
            => modifiers.Any(m => m.Text == "public" || m.Text == "internal");

        private bool IsStaticOrConstant(SyntaxTokenList modifiers)
            => modifiers.Any(m => m.Text == "static" || m.Text == "const");

        private static Dictionary<string, string> InitDefaultSerializers()
        {
            var defaultSerializers = new Dictionary<string, string>();
            string[] primitiveTypes = new[]
            {
                "int", "uint", "long", "ulong", "short", "ushort", "byte", "sbyte",
                "float", "double", "decimal", "string", "bool", "char",
                "Int32", "Int64", "UInt32", "UInt64", "Int16", "UInt16", "Byte", "SByte",
                "Single", "Double", "Decimal", "String", "Boolean", "Char",
            };
            foreach (var type in primitiveTypes)
            {
                defaultSerializers.Add(type, "writer.Write({0});");
            }
            return defaultSerializers;
        }

        private static readonly Dictionary<string, string> _defaultSerializer = InitDefaultSerializers();

        private static readonly Dictionary<string, string> _defaultDserializer = new Dictionary<string, string>()
        {
            {"int", $"{{0}} = reader.{nameof(BinaryReader.ReadInt32)}();"},
            {"Int32", $"{{0}} = reader.{nameof(BinaryReader.ReadInt32)}();"},
            {"uint", $"{{0}} = reader.{nameof(BinaryReader.ReadUInt32)}();"},
            {"UInt32", $"{{0}} = reader.{nameof(BinaryReader.ReadUInt32)}();"},
            {"long", $"{{0}} = reader.{nameof(BinaryReader.ReadInt64)}();"},
            {"Int64", $"{{0}} = reader.{nameof(BinaryReader.ReadInt64)}();"},
            {"ulong", $"{{0}} = reader.{nameof(BinaryReader.ReadUInt64)}();"},
            {"UInt64", $"{{0}} = reader.{nameof(BinaryReader.ReadUInt64)}();"},
            {"short", $"{{0}} = reader.{nameof(BinaryReader.ReadInt16)}();"},
            {"Int16", $"{{0}} = reader.{nameof(BinaryReader.ReadInt16)}();"},
            {"ushort", $"{{0}} = reader.{nameof(BinaryReader.ReadUInt16)}();"},
            {"UInt16", $"{{0}} = reader.{nameof(BinaryReader.ReadUInt16)}();"},
            {"byte", $"{{0}} = reader.{nameof(BinaryReader.ReadByte)}();"},
            {"Byte", $"{{0}} = reader.{nameof(BinaryReader.ReadByte)}();"},
            {"sbyte", $"{{0}} = reader.{nameof(BinaryReader.ReadSByte)}();"},
            {"SByte", $"{{0}} = reader.{nameof(BinaryReader.ReadSByte)}();"},
            {"float", $"{{0}} = reader.{nameof(BinaryReader.ReadSingle)}();"},
            {"Single", $"{{0}} = reader.{nameof(BinaryReader.ReadSingle)}();"},
            {"double", $"{{0}} = reader.{nameof(BinaryReader.ReadDouble)}();"},
            {"Double", $"{{0}} = reader.{nameof(BinaryReader.ReadDouble)}();"},
            {"decimal", $"{{0}} = reader.{nameof(BinaryReader.ReadDecimal)}();"},
            {"Decimal", $"{{0}} = reader.{nameof(BinaryReader.ReadDecimal)}();"},
            {"string", $"{{0}} = reader.{nameof(BinaryReader.ReadString)}();"},
            {"String", $"{{0}} = reader.{nameof(BinaryReader.ReadString)}();"},
            {"bool", $"{{0}} = reader.{nameof(BinaryReader.ReadBoolean)}();"},
            {"Boolean", $"{{0}} = reader.{nameof(BinaryReader.ReadBoolean)}();"},
            {"char", $"{{0}} = reader.{nameof(BinaryReader.ReadChar)}();"},
            {"Char", $"{{0}} = reader.{nameof(BinaryReader.ReadChar)}();"},
        };
    }
}