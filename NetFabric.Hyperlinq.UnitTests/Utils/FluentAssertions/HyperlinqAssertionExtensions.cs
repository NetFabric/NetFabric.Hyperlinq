using FluentAssertions.Primitives;
using System.Diagnostics;

namespace FluentAssertions
{
    [DebuggerNonUserCode]
    public static class HyperlinqAssertionExtensions
    {
        public static ObjectAssertions2 Must(this object actualValue)
            => new ObjectAssertions2(actualValue);
    }
}
