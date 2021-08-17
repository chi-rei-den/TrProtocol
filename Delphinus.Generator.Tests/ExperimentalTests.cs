using System;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Scriban;
using Scriban.Runtime;
using Scriban.Syntax;
using Xunit;

namespace Delphinus.Generator.Tests
{
    public class ExperimentalTests
    {
        [Fact]
        public void TestScriban()
        {
            var context = new TemplateContext();


            var templateOuter = Template.Parse(@"
outer {{name}} {
    {{ inner }}
}
");
            var templateInner =  Template.Parse(@"inner = {{name}}");


            TemplateContext ctx = new TemplateContext();
            ctx.SetValue(ScriptVariable.Create("name", ScriptVariableScope.Global), "Hello");

            var inner = templateInner.Render(ctx);

            ctx.SetValue(ScriptVariable.Create("inner", ScriptVariableScope.Global), inner);

            var result = templateOuter.Render(ctx);

            Assert.False(false);
        }

        private static Compilation CreateCompilation(string source)
            => CSharpCompilation.Create("compilation",
                new[] { CSharpSyntaxTree.ParseText(source) },
                new[] { MetadataReference.CreateFromFile(typeof(Binder).GetTypeInfo().Assembly.Location) },
                new CSharpCompilationOptions(OutputKind.ConsoleApplication));
    }
}