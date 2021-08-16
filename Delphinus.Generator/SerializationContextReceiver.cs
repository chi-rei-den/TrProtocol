using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Delphinus.Generator
{
    public class SerializationContextReceiver : ISyntaxContextReceiver
    {
        public List<TypeDeclarationSyntax> PacketTypes = new List<TypeDeclarationSyntax>();

        public GenerationConfig Config;

        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            ReadConfig(context);
            CollectPacketTypes(context);
        }

        private void ReadConfig(GeneratorSyntaxContext context)
        {
            if (!(context.Node is FieldDeclarationSyntax fieldDeclaration)) return;

            if (fieldDeclaration.Modifiers.Any(m => m.Text == "const")
                && Utils.GetName(fieldDeclaration) == "_DelphinusGenerationConfig_")
            {
                if (fieldDeclaration.Declaration.Variables.Count == 1
                    && fieldDeclaration.Declaration?.Variables[0].Initializer?.Value is LiteralExpressionSyntax expr)
                {
                    Config = JsonSerializer.Deserialize<GenerationConfig>(expr.Token.ValueText);
                }
            }
        }

        private void CollectPacketTypes(GeneratorSyntaxContext context)
        {
            if (!(context.Node is TypeDeclarationSyntax typeDeclaration)) return;
            if (typeDeclaration.BaseList == null) return;
            if (typeDeclaration.Modifiers.Any(m => m.Text == "abstract")) return;
            if (typeDeclaration is InterfaceDeclarationSyntax) return;
            foreach (var baseTypeSyntax in typeDeclaration.BaseList.Types)
            {
                if (baseTypeSyntax.Type is SimpleNameSyntax simpleName
                    && simpleName.Identifier.Text == "IPacket")
                {
                    PacketTypes.Add(typeDeclaration);
                }
            }
        }
    }
}