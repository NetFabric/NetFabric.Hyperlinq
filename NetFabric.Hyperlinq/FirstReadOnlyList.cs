using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static TSource First<TSource>(this IReadOnlyList<TSource> source) =>
            First<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TResult First<TEnumerable, TEnumerator, TSource, TResult>(
            this SelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult> source)
                where TEnumerable : IReadOnlyList<TSource>
                where TEnumerator : IEnumerator<TSource> =>
                    First<SelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, SelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>.Enumerator, TResult>(source);

        public static TSource First<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyList<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();
            if (source.Count == 0) ThrowEmptySequence();

            return source[0];

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowEmptySequence() => throw new InvalidOperationException(Resource.EmptySequence);
        }

        public static TSource First<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate) =>
            First<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TResult First<TEnumerable, TEnumerator, TSource, TResult>(
            this SelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult> source,
            Func<TResult, bool> predicate)
                where TEnumerable : IReadOnlyList<TSource>
                where TEnumerator : IEnumerator<TSource> =>
                    First<SelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, SelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>.Enumerator, TResult>(source, predicate);

        public static TSource First<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();

            for (var index = 0; index < source.Count; index++)
            {
                if (predicate(source[index]))
                    return source[index];
            }
            ThrowEmptySequence();
            return default;

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowEmptySequence() => throw new InvalidOperationException(Resource.EmptySequence);
        }
    }
}
