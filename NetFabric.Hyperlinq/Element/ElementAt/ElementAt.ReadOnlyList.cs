using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> ElementAt<TList, TSource>(this TList source, int index) 
            where TList : notnull, IReadOnlyList<TSource>
            => ElementAt<TList, TSource>(source, index, 0, source.Count);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TSource> ElementAt<TList, TSource>(this TList source, int index, int offset, int count) 
            where TList : notnull, IReadOnlyList<TSource>
            => index < 0 || index >= count 
                ? Option.None 
                : Option.Some(source[index + offset]);


        static Option<TSource> ElementAt<TList, TSource, TPredicate>(this TList source, int index, TPredicate predicate, int offset, int count) 
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            if (index >= 0)
            {
                var end = offset + count - 1;
                for (var sourceIndex = offset; sourceIndex <= end; sourceIndex++)
                {
                    var item = source[sourceIndex];
                    if (predicate.Invoke(item) && index-- == 0)
                        return Option.Some(item);
                }
            }
            return Option.None;
        }


        static Option<TSource> ElementAtAt<TList, TSource, TPredicate>(this TList source, int index, TPredicate predicate, int offset, int count) 
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicateAt<TSource>
        {
            if (index >= 0)
            {
                var end = count - 1;
                if (offset == 0)
                {
                    for (var sourceIndex = 0; sourceIndex <= end; sourceIndex++)
                    {
                        var item = source[sourceIndex];
                        if (predicate.Invoke(item, sourceIndex) && index-- == 0)
                            return Option.Some(item);
                    }
                }
                else
                {
                    for (var sourceIndex = 0; sourceIndex <= end; sourceIndex++)
                    {
                        var item = source[sourceIndex + offset];
                        if (predicate.Invoke(item, sourceIndex) && index-- == 0)
                            return Option.Some(item);
                    }
                }
            }
            return Option.None;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult?> ElementAt<TList, TSource, TResult>(this TList source, int index, NullableSelector<TSource, TResult> selector, int offset, int count) 
            where TList : notnull, IReadOnlyList<TSource>
            => index < 0 || index >= count 
                ? Option.None
                : Option.Some(selector(source[index + offset]));

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TResult?> ElementAt<TList, TSource, TResult>(this TList source, int index, NullableSelectorAt<TSource, TResult> selector, int offset, int count) 
            where TList : notnull, IReadOnlyList<TSource>
            => index < 0 || index >= count 
                ? Option.None 
                : Option.Some(selector(source[index + offset], index));


        static Option<TResult?> ElementAt<TList, TSource, TResult, TPredicate>(this TList source, int index, TPredicate predicate, NullableSelector<TSource, TResult> selector, int offset, int count) 
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            if (index >= 0)
            {
                var end = offset + count - 1;
                for (var sourceIndex = offset; sourceIndex <= end; sourceIndex++)
                {
                    var item = source[sourceIndex];
                    if (predicate.Invoke(item) && index-- == 0)
                        return Option.Some(selector(item));
                }
            }
            return Option.None;
        }
    }
}
