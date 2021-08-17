using System;

namespace Delphinus
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public sealed class S2COnlyAttribute : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public sealed class C2SOnlyAttribute : Attribute
    {

    }

    public enum Usage
    {
        Serialize,
        Deserialize,
        Both,
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class ConditionAttribute : Attribute
    {
        public ConditionAttribute(string condition, Usage usage = Usage.Both) { }
        public ConditionAttribute(string serialize, string deserialize) { }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class ExpressionAttribute : Attribute
    {
        public ExpressionAttribute(string expression, Usage usage = Usage.Both) { }
        public ExpressionAttribute(string serialize, string deserialize) { }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class ManualAttribute : Attribute
    {
        public ManualAttribute(string code, Usage usage = Usage.Both) { }
        public ManualAttribute(string serialize, string deserialize) { }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class Arguments : Attribute
    {
        public string[] Args { get; set; }

        public Arguments(params string[] args)
        {
            Args = args;
        }
    }
}
