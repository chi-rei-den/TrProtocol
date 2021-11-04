using System;
using System.Reflection;

namespace TrProtocol
{
    public class BadBoundException : Exception
    {
        public BadBoundException(string message) : base(message)
        {

        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class BoundWithAttribute : Attribute
    {
        public PropertyInfo property;

        public BoundWithAttribute(string property)
        {
            this.property = typeof(Constants).GetProperty(property);
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public sealed class BoundAttribute : Attribute
    {
        public int upper, lower;
        public string version;
        public bool interrupt;

        public BoundAttribute(string version, int upper, int lower = int.MinValue, bool interrupt = true)
        {
            this.upper = upper;
            this.lower = lower;
            this.version = version;
            this.interrupt = interrupt;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ForceSerializeAttribute : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public sealed class ProtocolVersionAttribute : Attribute
    {
        public string version;

        public ProtocolVersionAttribute(string version)
        {
            this.version = version;
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public sealed class S2COnlyAttribute : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public sealed class C2SOnlyAttribute : Attribute
    {

    }
    
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ArraySizeAttribute : Attribute
    {
        public object[] size;

        public ArraySizeAttribute(params object[] size)
        {
            this.size = size;
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ConditionAttribute : Attribute
    {
        public string field;
        public sbyte bit;
        public bool pred;

        public ConditionAttribute(string field, sbyte bit = -1, bool pred = true)
        {
            this.bit = bit;
            this.field = field;
            this.pred = pred;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class IgnoreAttribute : Attribute
    {
    }
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class LegacySerializerAttribute : Attribute
    {
    }
    
}
