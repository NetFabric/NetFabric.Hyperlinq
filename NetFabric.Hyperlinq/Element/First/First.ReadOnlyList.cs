using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> First<TList, TSource>(this TList source) 
            where TList : IReadOnlyList<TSource>
            => First<TList, TSource>(source, 0, source.Count);


        static Option<TSource> First<TList, TSource>(this TList source, int offset, int count) 
            where TList : IReadOnlyList<TSource>
            => count switch
            {
                0 => Option.None,
                _ => Option.Some(source[offset]),
            };


        static Option<TSource> First<TList, TSource>(this TList source, Predicate<TSource> predicate, int offset, int count)
            where TList : IReadOnlyList<TSource>
        {
            var end = offset + count;
            for (var index = offset; index < end; index++)
            {
                var item = source[index];
                if (predicate(item))
                    return Option.Some(item);
            }
            return Option.None;
        }


        static Option<TSource> First<TList, TSource>(this TList source, PredicateAt<TSource> predicate, int offset, int count)
            where TList : IReadOnlyList<TSource>
        {
            if (offset == 0)
            {
                for (var index = 0; index < count; index++)
                {
                    var item = source[index];
                    if (predicate(item, index))
                        return Option.Some(item);
                }
            }
            else
            {
                for (var index = 0; index < count; index++)
                {
                    var item = source[index + offset];
                    if (predicate(item, index))
                        return Option.Some(item);
                }
            }
            return Option.None;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> First<TList, TSource, TResult>(this TList source, NullableSelector<TSource, TResult> selector, int offset, int count)
            where TList : IReadOnlyList<TSource>
            => count switch
            {
                0 => Option.None,
                _ => Option.Some(selector(source[offset])),
            };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> First<TList, TSource, TResult>(this TList source, NullableSelectorAt<TSource, TResult> selector, int offset, int count)
            where TList : IReadOnlyList<TSource>
            => count switch
            {
                0 => Option.None,
                _ => Option.Some(selector(source[offset], 0)),
            };


        static Option<TResult> First<TList, TSource, TResult>(this TList source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector, int offset, int count)
            where TList : IReadOnlyList<TSource>
        {
            var end = offset + count;
            for (var index = offset; index < end; index++)
            {
                if (predicate(source[index]))
                    return Option.Some(selector(source[index]));
            }
            return Option.None;
        }
    }
}
