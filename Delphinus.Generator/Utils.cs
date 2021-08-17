using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Scriban;
using Scriban.Syntax;

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

        public static Template LoadTemplate(GeneratorExecutionContext context, string name)
        {
            var templateText = context
                .AdditionalFiles
                .Where(f =>
                {
                    string compilationPath = Path.GetFullPath(".");
                    string fullPath = Path.GetFullPath(f.Path);
                    string fullTemplatePath = Path.GetFullPath($"{name}.sbntxt");

                    if (!fullPath.StartsWith(compilationPath)
                        || !fullTemplatePath.StartsWith(compilationPath))
                    {
                        return false;
                    }

                    return fullPath.Equals(fullTemplatePath, StringComparison.InvariantCultureIgnoreCase);
                })
                .FirstOrDefault()
                ?.GetText(context.CancellationToken)
                ?.ToString();

            if (string.IsNullOrWhiteSpace(templateText))
            {
                templateText = LoadFromEmbeddedResources($"templates.{name}.sbntxt")
                    ?? throw new Exception($"Unable to find the template: {name}");
            }

            return Template.Parse(templateText);
        }

        private static string LoadFromEmbeddedResources(string relativePath)
        {
            var baseName = typeof(Utils).Assembly.GetName().Name;

            using var stream = typeof(Utils).Assembly.GetManifestResourceStream($"{baseName}.{relativePath}");

            if (stream == null)
            {
                throw new NotSupportedException("Unable to get embedded resource content, because the stream was null");
            }

            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        public static void SetVar(this TemplateContext context, string name, object val)
        {
            context.SetValue(ScriptVariable.Create(name, ScriptVariableScope.Global), val);
        }
    }
}