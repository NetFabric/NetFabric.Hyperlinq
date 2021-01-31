using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TList, TSource>(this TList source, Func<TSource, bool> predicate)
            where TList : IReadOnlyList<TSource>
            => source.All<TList, TSource, FunctionWrapper<TSource, bool>>(new FunctionWrapper<TSource, bool>(predicate));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TList, TSource, TPredicate>(this TList source, TPredicate predicate = default)
            where TList : IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            => source.All<TList, TSource, TPredicate>(predicate, 0, source.Count);
        
        internal static bool All<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            var end = offset + count;
            for (var index = offset; index < end; index++)
            {
                var item = source[index];
                if (!predicate.Invoke(item))
                    return false;
            }
            return true;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TList, TSource>(this TList source, Func<TSource, int, bool> predicate)
            where TList : IReadOnlyList<TSource>
            => source.AllAt<TList, TSource, FunctionWrapper<TSource, int, bool>>(new FunctionWrapper<TSource, int, bool>(predicate));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AllAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate = default)
            where TList : IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.AllAt<TList, TSource, TPredicate>(predicate, 0, source.Count);
        
        internal static bool AllAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            var end = count;
            if (offset is 0)
            {
                for (var index = 0; index < end; index++)
                {
                    var item = source[index];
                    if (!predicate.Invoke(item, index))
                        return false;
                }
            }
            else
            {
                for (var index = 0; index < end; index++)
                {
                    var item = source[index + offset];
                    if (!predicate.Invoke(item, index))
                        return false;
                }
            }
            return true;
        }
    }
}

