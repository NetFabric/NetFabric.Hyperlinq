using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        public static int Count<TList, TSource>(this TList source)
            where TList : notnull, IReadOnlyList<TSource>
            => source.Count;

        static int Count<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            var counter = 0;
            var end = offset + count - 1;
            for (var index = offset; index <= end; index++)
                counter += predicate.Invoke(source[index]).AsByte();
            return counter;
        }

        static int CountAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicateAt<TSource>
        {
            var counter = 0;
            var end = count - 1;
            if (offset == 0)
            {
                for (var index = 0; index <= end; index++)
                    counter += predicate.Invoke(source[index], index).AsByte();
            }
            else
            {
                for (var index = 0; index <= end; index++)
                    counter += predicate.Invoke(source[index + offset], index).AsByte();
            }
            return counter;
        }
    }
}

