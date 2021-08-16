using System;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Delphinus.Generator
{
    public static class Utils
    {
        public static string GetName(FieldDeclarationSyntax fieldDeclaration)
            => fieldDeclaration.Declaration.Variables.First().Identifier.Text;

        public static AttributeSyntax FindAttribute(this MemberDeclarationSyntax memberDecl, string name)
        {
            AttributeSyntax result = null;
            if (memberDecl?.AttributeLists == null)
                return result;

            foreach (var al in memberDecl.AttributeLists)
            {
                if ((result = al.Attributes.FirstOrDefault(a => a.Name.ToString() == name)) != null)
                {
                    return result;
                }
            }

            return result;
        }
    }
}