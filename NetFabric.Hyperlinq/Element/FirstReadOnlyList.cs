using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static TSource First<TSource>(this IReadOnlyList<TSource> source) =>
            First<IReadOnlyList<TSource>, TSource>(source);

        public static TSource First<TSource>(this List<TSource> source) =>
            First<List<TSource>, TSource>(source);

        public static TSource First<TEnumerable, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (source == null) ThrowSourceNull();
            if (source.Count == 0) ThrowEmptySequence();

            return source[0];

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowEmptySequence() => throw new InvalidOperationException(Resource.EmptySequence);
        }

        public static TSource First<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate) =>
            First<IReadOnlyList<TSource>, TSource>(source, predicate);

        public static TSource First<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
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
