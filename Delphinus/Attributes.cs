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


    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class ArraySizeAttribute : Attribute
    {
        public int size;

        public ArraySizeAttribute(int size)
        {
            this.size = size;
        }
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
        public string Condition { get; }

        public Usage Usage { get; }

        public ConditionAttribute(string condition, Usage usage = Usage.Both)
        {
            Condition = condition;
            Usage = usage;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class ExpressionAttribute : Attribute
    {
        public string Expression { get; }

        public Usage Usage { get; }

        public ExpressionAttribute(string expression, Usage usage = Usage.Both)
        {
            Expression = expression;
            Usage = usage;
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public sealed class ManualAttribute : Attribute
    {

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
