using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static int Count<TSource>(this IEnumerable<TSource> source) =>
            Count<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);

        public static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();

            var count = 0;
            using(var enumerator = (TEnumerator)source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                    count++;
            }
            return count;

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
        }
    }
}
