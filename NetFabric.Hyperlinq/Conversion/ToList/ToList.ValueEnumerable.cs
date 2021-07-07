using System.Collections.Generic;
using System.Runtime.CompilerServices;
// ReSharper disable HeapView.ObjectAllocation.Evident

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source.ToArray<TEnumerable, TEnumerator, TSource>().AsList();



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToList<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            => source.ToArray<TEnumerable, TEnumerator, TSource, TPredicate>(predicate).AsList();



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToListAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.ToArrayAt<TEnumerable, TEnumerator, TSource, TPredicate>(predicate).AsList();



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            => source.ToArray<TEnumerable, TEnumerator, TSource, TResult, TSelector>(selector).AsList();



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToListAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
            => source.ToArrayAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(selector).AsList();


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(this TEnumerable source, TPredicate predicate, TSelector selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            => source.ToArray<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(predicate, selector).AsList();

    }
}
