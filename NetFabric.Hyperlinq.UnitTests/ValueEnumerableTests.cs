using System;

namespace NetFabric.Hyperlinq.UnitTests
{
    public abstract partial class ValueEnumerableTests<
            TEnumerable,
            TWhereEnumerable,
            TWhereAtEnumerable>
        : ValueEnumerableTests<
            TEnumerable,
            TEnumerable,
            TEnumerable,
            TWhereEnumerable,
            TWhereAtEnumerable>
        where TEnumerable : struct
        where TWhereEnumerable : struct
        where TWhereAtEnumerable : struct
    {
        protected ValueEnumerableTests(Func<int[], TEnumerable> createInstance)
            : base(createInstance)
        {
        }
    }

    public abstract partial class ValueEnumerableTests<
            TEnumerable,
            TSkipEnumerable,
            TTakeEnumerable,
            TWhereEnumerable,
            TWhereAtEnumerable>
        : TestsBase<TEnumerable>
        where TEnumerable : struct
        where TSkipEnumerable : struct
        where TTakeEnumerable : struct
        where TWhereEnumerable : struct
        where TWhereAtEnumerable : struct
    {
        protected ValueEnumerableTests(Func<int[], TEnumerable> createInstance)
            : base(createInstance)
        {
        }
    }
}