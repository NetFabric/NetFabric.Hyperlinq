using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyListExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueReadOnlyCollectionExtensions.WhereAtEnumerable<TEnumerable, TEnumerator, TSource, TPredicate> WhereAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate = default)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
            => ValueReadOnlyCollectionExtensions.WhereAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);
    }
}

