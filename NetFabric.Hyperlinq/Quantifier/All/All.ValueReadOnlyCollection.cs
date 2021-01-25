using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => All<TEnumerable, TEnumerator, TSource, FunctionWrapper<TSource, bool>>(source, new FunctionWrapper<TSource, bool>(predicate));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate = default)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            => source.Count is 0 || ValueEnumerableExtensions.All<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => AllAt<TEnumerable, TEnumerator, TSource, FunctionWrapper<TSource, int, bool>>(source, new FunctionWrapper<TSource, int, bool>(predicate));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AllAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate = default)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.Count is 0 || ValueEnumerableExtensions.AllAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);
    }
}

