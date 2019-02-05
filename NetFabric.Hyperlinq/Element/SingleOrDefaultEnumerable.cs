using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source) =>
            SingleOrDefault<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TSource SingleOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();

            using (var enumerator = (TEnumerator)source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                    return default;

                var first = enumerator.Current;

                if (enumerator.MoveNext())
                    ThrowNotSingleSequence();

                return first;
            }

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowNotSingleSequence() => throw new InvalidOperationException(Resource.NotSingleSequence);
        }

        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate) =>
            SingleOrDefault<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TSource SingleOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();

            using (var enumerator = (TEnumerator)source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    if (predicate(current))
                    {
                        // found first, keep going until end or find second
                        while (enumerator.MoveNext())
                        {
                            if (predicate(enumerator.Current))
                                ThrowNotSingleSequence();
                        }
                        return current;
                    }
                }
                return default;
            }

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowNotSingleSequence() => throw new InvalidOperationException(Resource.NotSingleSequence);
        }
    }
}
