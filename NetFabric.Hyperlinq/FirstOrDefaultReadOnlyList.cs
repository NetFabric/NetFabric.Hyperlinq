using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static TSource FirstOrDefault<TSource>(this IReadOnlyList<TSource> source) =>
            FirstOrDefault<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TResult FirstOrDefault<TEnumerable, TEnumerator, TSource, TResult>(
            this SelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult> source)
                where TEnumerable : IReadOnlyList<TSource>
                where TEnumerator : IEnumerator<TSource> =>
                    FirstOrDefault<SelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, SelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>.Enumerator, TResult>(source);

        public static TSource FirstOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyList<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();
            if (source.Count == 0) return default;

            return source[0];

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
        }

        public static TSource FirstOrDefault<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate) =>
            FirstOrDefault<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TResult FirstOrDefault<TEnumerable, TEnumerator, TSource, TResult>(
            this SelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult> source,
            Func<TResult, bool> predicate)
                where TEnumerable : IReadOnlyList<TSource>
                where TEnumerator : IEnumerator<TSource> =>
                    FirstOrDefault<SelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, SelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>.Enumerator, TResult>(source, predicate);

        public static TSource FirstOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();

            for (var index = 0; index < source.Count; index++)
            {
                if (predicate(source[index]))
                    return source[index];
            }
            return default;

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
        }
    }
}
