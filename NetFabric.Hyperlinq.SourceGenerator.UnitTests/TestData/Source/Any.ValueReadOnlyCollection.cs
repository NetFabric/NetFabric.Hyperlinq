using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source.Count is not 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => Any<TEnumerable, TEnumerator, TSource, FunctionWrapper<TSource, bool>>(source, new FunctionWrapper<TSource, bool>(predicate));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate = default)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            => source.Count is not 0 && ValueEnumerableExtensions.Any<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);
    }
}

