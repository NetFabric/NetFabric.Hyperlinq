using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        [Pure]
        public static TSource ElementAt<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (index >= 0)
            {
                using var enumerator = source.GetEnumerator();
                for (; enumerator.MoveNext(); index--)
                {
                    if (index == 0)
                        return enumerator.Current;
                }
            }

            return ThrowHelper.ThrowArgumentOutOfRangeException<TSource>(nameof(index));
        }

        [Pure]
        [return: MaybeNull]
        public static TSource ElementAtOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (index >= 0)
            {
                using var enumerator = source.GetEnumerator();
                for (; enumerator.MoveNext(); index--)
                {
                    if (index == 0)
                        return enumerator.Current;
                }
            }

            return default!;
        }

        [Pure]
        public static Maybe<TSource> TryElementAt<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (index >= 0)
            {
                using var enumerator = source.GetEnumerator();
                for (; enumerator.MoveNext(); index--)
                {
                    if (index == 0)
                        return new Maybe<TSource>(enumerator.Current);
                }
            }

            return default;
        }
    }
}
