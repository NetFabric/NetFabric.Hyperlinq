using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

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
                foreach (var item in source)
                {
                    if (index == 0)
                        return item;

                    index--;
                }
            }

            return ThrowHelper.ThrowArgumentOutOfRangeException<TSource>(nameof(index));
        }

        [Pure]
        public static TSource ElementAtOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (index >= 0)
            {
                foreach (var item in source)
                {
                    if (index == 0)
                        return item;

                    index--;
                }
            }

            return default;
        }

        [Pure]
        public static Maybe<TSource> TryElementAt<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (index >= 0)
            {
                foreach (var item in source)
                {
                    if (index == 0)
                        return new Maybe<TSource>(item);

                    index--;
                }
            }

            return default;
        }
    }
}
