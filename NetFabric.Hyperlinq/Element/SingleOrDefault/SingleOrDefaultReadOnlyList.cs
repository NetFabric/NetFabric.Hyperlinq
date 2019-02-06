using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static TSource SingleOrDefault<TSource>(this IReadOnlyList<TSource> source) =>
            SingleOrDefault<IReadOnlyList<TSource>, TSource>(source);

        public static TSource SingleOrDefault<TEnumerable, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (source == null) ThrowSourceNull();
            if (source.Count == 0) return default;
            if (source.Count > 1) ThrowNotSingleSequence();

            return source[0];

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowNotSingleSequence() => throw new InvalidOperationException(Resource.NotSingleSequence);
        }

        public static TSource SingleOrDefault<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate) =>
            SingleOrDefault<IReadOnlyList<TSource>, TSource>(source, predicate);

        public static TSource SingleOrDefault<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (source == null) ThrowSourceNull();

            var index = 0;
            var count = source.Count;
            while (index < count)
            {
                var current = source[index];
                if (predicate(current))
                {
                    // found first, keep going until end or find second
                    index++;
                    while (index < count)
                    {
                        if (predicate(source[index]))
                            ThrowNotSingleSequence();

                        index++;
                    }
                    return current;
                }
                index++;
            }
            return default;

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowNotSingleSequence() => throw new InvalidOperationException(Resource.NotSingleSequence);
        }
    }
}
