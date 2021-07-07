using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source.Count;
        
        public static int Count<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate = default)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate: struct, IFunction<TSource, bool>
            => source switch
            {
                {Count: 0} => 0,
                _ => ValueEnumerableExtensions.Count<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate)
            };
        
        public static int CountAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate = default)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate: struct, IFunction<TSource, int, bool>
            => source switch
            {
                {Count: 0} => 0,
                _ => ValueEnumerableExtensions.CountAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate)
            };

    }
}

