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
        static Option<TSource> ElementAt<TList, TSource>(this TList source, int index, int skipCount, int takeCount) 
            where TList : IReadOnlyList<TSource>
            => index < 0 || index >= takeCount 
                ? Option.None 
                : Option.Some(source[index + skipCount]);


        static Option<TSource> ElementAt<TList, TSource>(this TList source, int index, Predicate<TSource> predicate, int skipCount, int takeCount) 
            where TList : IReadOnlyList<TSource>
        {
            if (index >= 0)
            {
                var end = skipCount + takeCount;
                for (var sourceIndex = skipCount; sourceIndex < end; sourceIndex++)
                {
                    var item = source[sourceIndex];
                    if (predicate(item) && index-- == 0)
                        return Option.Some(item);
                }
            }
            return Option.None;
        }


        static Option<TSource> ElementAt<TList, TSource>(this TList source, int index, PredicateAt<TSource> predicate, int skipCount, int takeCount) 
            where TList : IReadOnlyList<TSource>
        {
            if (index >= 0)
            {
                if (skipCount == 0)
                {
                    for (var sourceIndex = 0; sourceIndex < takeCount; sourceIndex++)
                    {
                        var item = source[sourceIndex];
                        if (predicate(item, sourceIndex) && index-- == 0)
                            return Option.Some(item);
                    }
                }
                else
                {
                    for (var sourceIndex = 0; sourceIndex < takeCount; sourceIndex++)
                    {
                        var item = source[sourceIndex + skipCount];
                        if (predicate(item, sourceIndex) && index-- == 0)
                            return Option.Some(item);
                    }
                }
            }
            return Option.None;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> ElementAt<TList, TSource, TResult>(this TList source, int index, NullableSelector<TSource, TResult> selector, int skipCount, int takeCount) 
            where TList : IReadOnlyList<TSource>
            => index < 0 || index >= takeCount 
                ? Option.None
                : Option.Some(selector(source[index + skipCount]));

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TResult> ElementAt<TList, TSource, TResult>(this TList source, int index, NullableSelectorAt<TSource, TResult> selector, int skipCount, int takeCount) 
            where TList : IReadOnlyList<TSource>
            => index < 0 || index >= takeCount 
                ? Option.None 
                : Option.Some(selector(source[index + skipCount], index));


        static Option<TResult> ElementAt<TList, TSource, TResult>(this TList source, int index, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector, int skipCount, int takeCount) 
            where TList : IReadOnlyList<TSource>
        {
            if (index >= 0)
            {
                var end = skipCount + takeCount;
                for (var sourceIndex = skipCount; sourceIndex < end; sourceIndex++)
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
