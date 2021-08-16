using System;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace Delphinus.Generator.Tests
{
    public class ExperimentalTests
    {
        [Fact]
        public void Test()
        {
            const string config = @"
{
    ""UsingStatements"" : [
        ""using System.IO;"",
        ""using Microsoft.Xna.Framework;""
    ]
}
";
            // Create the 'input' compilation that the generator will act on
            Compilation inputCompilation = CreateCompilation(@"
namespace Delphinus.Packets
{
    internal class AnglerQuestPacket : IPacket
    {
        public const string _DelphinusGenerationConfig_ = @""{config}"";
        public byte QuestType { get; set; }
        public bool Finished;
    }
}
".Replace("{config}", config.Replace("\"", "\"\"")));

            var generator = new SerializationGenerator();
            GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);
            driver = driver.RunGeneratorsAndUpdateCompilation(inputCompilation, out var outputCompilation, out var diagnostics);
            var runResult = driver.GetRunResult();
            Assert.Empty(runResult.Diagnostics);
        }

        private static Compilation CreateCompilation(string source)
            => CSharpCompilation.Create("compilation",
                new[] { CSharpSyntaxTree.ParseText(source) },
                new[] { MetadataReference.CreateFromFile(typeof(Binder).GetTypeInfo().Assembly.Location) },
                new CSharpCompilationOptions(OutputKind.ConsoleApplication));
    }
}