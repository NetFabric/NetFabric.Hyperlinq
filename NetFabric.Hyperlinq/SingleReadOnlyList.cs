using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static TSource Single<TSource>(this IReadOnlyList<TSource> source) =>
            Single<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TResult Single<TEnumerable, TEnumerator, TSource, TResult>(
            this SelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult> source)
                where TEnumerable : IReadOnlyList<TSource>
                where TEnumerator : IEnumerator<TSource> =>
                    Single<SelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, SelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>.Enumerator, TResult>(source);

        public static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyList<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();
            if (source.Count == 0) ThrowEmptySequence();
            if (source.Count > 1) ThrowNotSingleSequence();

            return source[0];

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowEmptySequence() => throw new InvalidOperationException(Resource.EmptySequence);
            void ThrowNotSingleSequence() => throw new InvalidOperationException(Resource.NotSingleSequence);
        }

        public static TSource Single<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate) =>
            Single<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TResult Single<TEnumerable, TEnumerator, TSource, TResult>(
            this SelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult> source,
            Func<TResult, bool> predicate)
                where TEnumerable : IReadOnlyList<TSource>
                where TEnumerator : IEnumerator<TSource> =>
                    Single<SelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, SelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>.Enumerator, TResult>(source, predicate);

        public static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
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
            void ThrowNotSingleSequence() => throw new InvalidOperationException(Resource.NotSingleSequence);
        }
    }
}
