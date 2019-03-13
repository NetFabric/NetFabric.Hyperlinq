using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            using (var enumerator = source.GetValueEnumerator())
            {
                if (!enumerator.TryMoveNext(out var first))
                    ThrowHelper.ThrowEmptySequence<TSource>();

                if (enumerator.TryMoveNext())
                    ThrowHelper.ThrowNotSingleSequence<TSource>();

                return first;
            }
        }

        public static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

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
                                ThrowHelper.ThrowNotSingleSequence<TSource>();
                        }
                        return first;
                    }
                }
                return ThrowHelper.ThrowEmptySequence<TSource>();
            }
        }
    }
}
