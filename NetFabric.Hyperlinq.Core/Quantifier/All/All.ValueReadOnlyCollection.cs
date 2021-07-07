using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate = default)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            => source.Count is 0 || ValueEnumerableExtensions.All<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AllAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate = default)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.Count is 0 || ValueEnumerableExtensions.AllAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);
    }
}

