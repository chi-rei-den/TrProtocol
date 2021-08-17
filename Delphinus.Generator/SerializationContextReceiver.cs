using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Delphinus.Generator
{
    public class SerializationContextReceiver : ISyntaxContextReceiver
    {
        public List<TypeDeclarationSyntax> PacketTypes = new List<TypeDeclarationSyntax>();

        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            CollectPacketTypes(context);
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