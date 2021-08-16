using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Delphinus.Generator
{
    public class Utils
    {
        public static string GetName(FieldDeclarationSyntax fieldDeclaration)
            => fieldDeclaration.Declaration.Variables.First().Identifier.Text;
    }
}