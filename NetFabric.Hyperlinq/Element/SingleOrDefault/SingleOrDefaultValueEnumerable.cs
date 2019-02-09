using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public static TSource SingleOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();

            using (var enumerator = source.GetValueEnumerator())
            {
                if (!enumerator.TryMoveNext(out var first))
                    return default;

                if (enumerator.TryMoveNext())
                    ThrowNotSingleSequence();

                return first;
            }

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowNotSingleSequence() => throw new InvalidOperationException(Resource.NotSingleSequence);
        }

        public static TSource SingleOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();

            using (var enumerator = source.GetValueEnumerator())
            {
                while (enumerator.TryMoveNext(out var first))
                {
                    if (predicate(first))
                    {
                        // found first, keep going until end or find second
                        while (enumerator.TryMoveNext(out var current))
                        {
                            if (predicate(current))
                                ThrowNotSingleSequence();
                        }
                        return first;
                    }
                }

                return default;
            }

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowNotSingleSequence() => throw new InvalidOperationException(Resource.NotSingleSequence);
        }
    }
}
