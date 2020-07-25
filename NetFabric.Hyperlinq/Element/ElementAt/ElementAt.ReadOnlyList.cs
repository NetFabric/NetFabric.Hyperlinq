using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> ElementAt<TList, TSource>(this TList source, int index) 
            where TList : IReadOnlyList<TSource>
            => ElementAt<TList, TSource>(source, index, 0, source.Count);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TSource> ElementAt<TList, TSource>(this TList source, int index, int offset, int count) 
            where TList : IReadOnlyList<TSource>
            => index < 0 || index >= count 
                ? Option.None 
                : Option.Some(source[index + offset]);


        static Option<TSource> ElementAt<TList, TSource>(this TList source, int index, Predicate<TSource> predicate, int offset, int count) 
            where TList : IReadOnlyList<TSource>
        {
            if (index >= 0)
            {
                var end = offset + count;
                for (var sourceIndex = offset; sourceIndex < end; sourceIndex++)
                {
                    var item = source[sourceIndex];
                    if (predicate(item) && index-- == 0)
                        return Option.Some(item);
                }
            }
            return Option.None;
        }


        static Option<TSource> ElementAt<TList, TSource>(this TList source, int index, PredicateAt<TSource> predicate, int offset, int count) 
            where TList : IReadOnlyList<TSource>
        {
            if (index >= 0)
            {
                if (offset == 0)
                {
                    for (var sourceIndex = 0; sourceIndex < count; sourceIndex++)
                    {
                        var item = source[sourceIndex];
                        if (predicate(item, sourceIndex) && index-- == 0)
                            return Option.Some(item);
                    }
                }
                else
                {
                    for (var sourceIndex = 0; sourceIndex < count; sourceIndex++)
                    {
                        var item = source[sourceIndex + offset];
                        if (predicate(item, sourceIndex) && index-- == 0)
                            return Option.Some(item);
                    }
                }
            }
            return Option.None;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> ElementAt<TList, TSource, TResult>(this TList source, int index, NullableSelector<TSource, TResult> selector, int offset, int count) 
            where TList : IReadOnlyList<TSource>
            => index < 0 || index >= count 
                ? Option.None
                : Option.Some(selector(source[index + offset]));

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TResult> ElementAt<TList, TSource, TResult>(this TList source, int index, NullableSelectorAt<TSource, TResult> selector, int offset, int count) 
            where TList : IReadOnlyList<TSource>
            => index < 0 || index >= count 
                ? Option.None 
                : Option.Some(selector(source[index + offset], index));


        static Option<TResult> ElementAt<TList, TSource, TResult>(this TList source, int index, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector, int offset, int count) 
            where TList : IReadOnlyList<TSource>
        {
            if (index >= 0)
            {
                var end = offset + count;
                for (var sourceIndex = offset; sourceIndex < end; sourceIndex++)
                {
                    var item = source[sourceIndex];
                    if (predicate(item) && index-- == 0)
                        return Option.Some(selector(item));
                }
            }
            return Option.None;
        }
    }
}
