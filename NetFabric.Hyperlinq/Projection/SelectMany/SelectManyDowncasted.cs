using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class SelectManyEnumerableExtensions
    {
        public static Enumerable.SelectManyEnumerable<IEnumerable<TSource>, IEnumerator<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TSubEnumerable> selector) 
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
            => Enumerable.SelectMany<IEnumerable<TSource>, IEnumerator<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult>(source, selector);

        public static ReadOnlyList.SelectManyEnumerable<IReadOnlyList<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this IReadOnlyList<TSource> source,
            Func<TSource, TSubEnumerable> selector) 
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
            => ReadOnlyList.SelectMany<IReadOnlyList<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult>(source, selector);
    }
}