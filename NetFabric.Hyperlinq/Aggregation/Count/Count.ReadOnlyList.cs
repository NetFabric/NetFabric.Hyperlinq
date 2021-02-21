using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TList, TSource>(this TList source)
            where TList : struct, IReadOnlyList<TSource>
            => source.Count<TList, TSource>(0, source.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static int Count<TList, TSource>(this TList source, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            => count;

        static int Count<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            var counter = 0;
            var end = offset + count;
            for (var index = offset; index < end; index++)
            {
                var item = source[index];
                counter += predicate.Invoke(item).AsByte();
            }
            return counter;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static int CountAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.CountAt<TList, TSource, TPredicate>(predicate, 0, source.Count);

        static int CountAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate: struct, IFunction<TSource, int, bool>
        {
            var counter = 0;
            var end = count;
            if (offset is 0)
            {
                for (var index = 0; index < end; index++)
                {
                    var item = source[index];
                    counter += predicate.Invoke(source[index], index).AsByte();
                }
            }
            else
            {
                for (var index = 0; index < end; index++)
                {
                    var item = source[index + offset];
                    counter += predicate.Invoke(item, index).AsByte();
                }
            }
            return counter;
        }
    }
}

