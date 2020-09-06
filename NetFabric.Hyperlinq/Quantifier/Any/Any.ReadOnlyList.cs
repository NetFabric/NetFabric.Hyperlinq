using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        
        public static bool Any<TList, TSource>(this TList source)
            where TList : notnull, IReadOnlyList<TSource>
            => source.Count != 0;


        static bool Any<TList, TSource>(this TList source, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
        {
            (_, var take) = Utils.SkipTake(source.Count, offset, count);
            return take != 0;
        }

        static bool Any<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            var end = offset + count - 1;
            for (var index = offset; index <= end; index++)
            {
                if (predicate.Invoke(source[index]))
                    return true;
            }
            return false;
        }

        static bool AnyAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicateAt<TSource>
        {
            var end = count - 1;
            if (offset == 0)
            {
                for (var index = 0; index <= end; index++)
                {
                    if (predicate.Invoke(source[index], index))
                        return true;
                }
            }
            else
            {
                for (var index = 0; index <= end; index++)
                {
                    if (predicate.Invoke(source[index + offset], index))
                        return true;
                }
            }
            return false;
        }
    }
}

