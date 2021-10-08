using System.Collections.Generic;
using System.Runtime.CompilerServices;

// ReSharper disable HeapView.ObjectAllocation.Evident

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {

        public static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source switch
            {
                { Count: 0 } => new List<TSource>(),
                _ => ToArray<TEnumerable, TEnumerator, TSource>(source).AsList(),
            };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToList<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            => ToArray<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate).AsList(); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToListAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
            => ToArrayAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate).AsList(); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static List<TResult> ToList<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            => ToArray<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, selector).AsList(); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static List<TResult> ToListAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
            => ToArrayAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, selector).AsList(); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(this TEnumerable source, TPredicate predicate, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            => ToArray<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(source, predicate, selector).AsList(); 
    }
}
