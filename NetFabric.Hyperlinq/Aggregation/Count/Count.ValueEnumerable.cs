﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        [Pure]
        public static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var count = 0;
            checked
            {
                foreach (var _ in source)
                    count++; 
                return count;
            }
        }

        [Pure]
        public static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var count = 0;
            checked
            {
                foreach (var item in source)
                {
                    if (predicate(item))
                        count++;
                }
                return count;
            }
        }

        [Pure]
        public static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var count = 0;
            var index = 0;
            checked
            {
                foreach (var item in source)
                {
                    if (predicate(item, index))
                        count++;

                    index++;
                }
                return count;
            }
        }
    }
}
