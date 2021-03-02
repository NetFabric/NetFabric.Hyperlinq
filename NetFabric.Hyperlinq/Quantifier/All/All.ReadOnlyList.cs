using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool All<TList, TSource>(this TList source, Func<TSource, bool> predicate, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            => source.All<TList, TSource, FunctionWrapper<TSource, bool>>(new FunctionWrapper<TSource, bool>(predicate), offset, count);
        
        static bool All<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
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
        static bool All<TList, TSource>(this TList source, Func<TSource, int, bool> predicate, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            => source.AllAt<TList, TSource, FunctionWrapper<TSource, int, bool>>(new FunctionWrapper<TSource, int, bool>(predicate), offset, count);
        
        static bool AllAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            if (offset is 0)
            {
                for (var index = 0; index < count; index++)
                {
                    var item = source[index];
                    if (!predicate.Invoke(item, index))
                        return false;
                }
            }
            else
            {
                for (var index = 0; index < count; index++)
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

