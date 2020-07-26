using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> Single<TList, TSource>(this TList source) 
            where TList : IReadOnlyList<TSource>
            => Single<TList, TSource>(source, 0, source.Count);


        static Option<TSource> Single<TList, TSource>(this TList source, int offset, int count) 
            where TList : IReadOnlyList<TSource>
            => count switch
            {
                0 => Option.None,
                1 => Option.Some(source[offset]),
                _ => Option.None,
            };


        static Option<TSource> Single<TList, TSource>(this TList source, Predicate<TSource> predicate, int offset, int count) 
            where TList : IReadOnlyList<TSource>
            => GetSingle<TList, TSource>(source, predicate, offset, count);


        static Option<TSource> Single<TList, TSource>(this TList source, PredicateAt<TSource> predicate, int offset, int count) 
            where TList : IReadOnlyList<TSource>
            => GetSingle<TList, TSource>(source, predicate, offset, count);


        static Option<TResult> Single<TList, TSource, TResult>(this TList source, NullableSelector<TSource, TResult> selector, int offset, int count) 
            where TList : IReadOnlyList<TSource>
            => count switch
            {
                0 => Option.None,
                1 => Option.Some(selector(source[offset])),
                _ => Option.None,
            };


        static Option<TResult> Single<TList, TSource, TResult>(this TList source, NullableSelectorAt<TSource, TResult> selector, int offset, int count) 
            where TList : IReadOnlyList<TSource>
            => count switch
            {
                0 => Option.None,
                1 => Option.Some(selector(source[offset], 0)),
                _ => Option.None,
            };


        static Option<TResult> Single<TList, TSource, TResult>(this TList source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector, int offset, int count) 
            where TList : IReadOnlyList<TSource>
            => GetSingle<TList, TSource>(source, predicate, offset, count).Select(selector);

        ////////////////////////////////
        // GetSingle 

        
        static Option<TSource> GetSingle<TList, TSource>(this TList source, Predicate<TSource> predicate, int offset, int count)
            where TList : IReadOnlyList<TSource>
        {
            var end = offset + count;
            for (var index = offset; index < end; index++)
            {
                if (predicate(source[index]))
                {
                    var value = source[index];

                    for (index++; index < end; index++)
                    {
                        if (predicate(source[index]))
                            return Option.None;
                    }

                    return Option.Some(value);
                }
            }

            return Option.None;
        }
        
        
        static Option<TSource> GetSingle<TList, TSource>(this TList source, PredicateAt<TSource> predicate, int offset, int count)
            where TList : IReadOnlyList<TSource>
        {
            if (offset == 0)
            {
                for (var index = 0; index < count; index++)
                {
                    if (predicate(source[index], index))
                    {
                        var value = source[index];

                        for (index++; index < count; index++)
                        {
                            if (predicate(source[index], index))
                                return Option.None;
                        }

                        return Option.Some(value);
                    }
                }
            }
            else
            {
                for (var index = 0; index < count; index++)
                {
                    if (predicate(source[index + offset], index))
                    {
                        var value = source[index + offset];

                        for (index++; index < count; index++)
                        {
                            if (predicate(source[index + offset], index))
                                return Option.None;
                        }

                        return Option.Some(value);
                    }
                }
            }

            return Option.None;
        }
    }
}
