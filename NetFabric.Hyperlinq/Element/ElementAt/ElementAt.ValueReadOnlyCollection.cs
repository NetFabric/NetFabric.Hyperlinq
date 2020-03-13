using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        /////////////////
        // ElementAt

        [Pure]
        public static TSource ElementAt<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (index >= 0 && index < source.Count)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (index-- == 0)
                        return enumerator.Current;
                }
            }

            return Throw.ArgumentOutOfRangeException<TSource>(nameof(index));
        }

        [Pure]
        static TResult ElementAt<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, int index, Selector<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (index >= 0 && index < source.Count)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (index-- == 0)
                        return selector(enumerator.Current);
                }
            }

            return Throw.ArgumentOutOfRangeException<TResult>(nameof(index));
        }

        [Pure]
        public static TResult ElementAt<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, int index, SelectorAt<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (index >= 0 && index < source.Count)
            {
                using var enumerator = source.GetEnumerator();
                checked
                {
                    for (var itemIndex = 0; enumerator.MoveNext(); itemIndex++)
                    {
                        if (itemIndex == index)
                            return selector(enumerator.Current, index);
                    }
                }
            }
            return Throw.ArgumentOutOfRangeException<TResult>(nameof(index));
        }

        /////////////////
        // ElementAtOrDefault

        [Pure]
        [return: MaybeNull]
        public static TSource ElementAtOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (index >= 0 && index < source.Count)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (index-- == 0)
                        return enumerator.Current;
                }
            }

            return default!;
        }

        [Pure]
        [return: MaybeNull]
        static TResult ElementAtOrDefault<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, int index, Selector<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (index >= 0 && index < source.Count)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (index-- == 0)
                        return selector(enumerator.Current);
                }
            }

            return default;
        }

        [Pure]
        [return: MaybeNull]
        public static TResult ElementAtOrDefault<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, int index, SelectorAt<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (index >= 0 && index < source.Count)
            {
                using var enumerator = source.GetEnumerator();
                checked
                {
                    for (var itemIndex = 0; enumerator.MoveNext(); itemIndex++)
                    {
                        if (itemIndex == index)
                            return selector(enumerator.Current, index);
                    }
                }
            }
            return default;
        }
    }
}
