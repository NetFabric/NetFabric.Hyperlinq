using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> First<TList, TSource>(this TList source) 
            where TList : notnull, IReadOnlyList<TSource>
            => First<TList, TSource>(source, 0, source.Count);


        static Option<TSource> First<TList, TSource>(this TList source, int offset, int count) 
            where TList : notnull, IReadOnlyList<TSource>
            => count switch
            {
                0 => Option.None,
                _ => Option.Some(source[offset]),
            };


        static Option<TSource> First<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            var end = offset + count - 1;
            for (var index = offset; index <= end; index++)
            {
                var item = source[index];
                if (predicate.Invoke(item))
                    return Option.Some(item);
            }
            return Option.None;
        }


        static Option<TSource> FirstAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicateAt<TSource>
        {
            var end = count - 1;
            if (offset == 0)
            {
                for (var index = 0; index <= end; index++)
                {
                    var item = source[index];
                    if (predicate.Invoke(item, index))
                        return Option.Some(item);
                }
            }
            else
            {
                for (var index = 0; index <= end; index++)
                {
                    var item = source[index + offset];
                    if (predicate.Invoke(item, index))
                        return Option.Some(item);
                }
            }
            return Option.None;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult?> First<TList, TSource, TResult>(this TList source, NullableSelector<TSource, TResult> selector, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            => count switch
            {
                0 => Option.None,
                _ => Option.Some(selector(source[offset])),
            };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult?> First<TList, TSource, TResult>(this TList source, NullableSelectorAt<TSource, TResult> selector, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            => count switch
            {
                0 => Option.None,
                _ => Option.Some(selector(source[offset], 0)),
            };


        static Option<TResult?> First<TList, TSource, TResult, TPredicate>(this TList source, TPredicate predicate, NullableSelector<TSource, TResult> selector, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            var end = offset + count - 1;
            for (var index = offset; index <= end; index++)
            {
                if (predicate.Invoke(source[index]))
                    return Option.Some(selector(source[index]));
            }
            return Option.None;
        }
    }
}
