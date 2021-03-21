using System;

namespace NetFabric.Hyperlinq.UnitTests
{
    public abstract partial class ValueEnumerableTestsBase<TEnumerable>
        : ValueEnumerableTestsBase<TEnumerable, TEnumerable, TEnumerable>
        where TEnumerable : struct
    {
        protected ValueEnumerableTestsBase(Func<int[], TEnumerable> createInstance)
            : base(createInstance)
        {
        }
    }
}