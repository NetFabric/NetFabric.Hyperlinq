using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> Single<TList, TSource>(this TList source) 
            where TList : notnull, IReadOnlyList<TSource>
            => Single<TList, TSource>(source, 0, source.Count);


        static Option<TSource> Single<TList, TSource>(this TList source, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
            => takeCount switch
            {
                0 => Option.None,
                1 => Option.Some(source[skipCount]),
                _ => Option.None,
            };


        static Option<TSource> Single<TList, TSource>(this TList source, Predicate<TSource> predicate, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
            => GetSingle<TList, TSource>(source, predicate, skipCount, takeCount);


        static Option<TSource> Single<TList, TSource>(this TList source, PredicateAt<TSource> predicate, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
            => GetSingle<TList, TSource>(source, predicate, skipCount, takeCount);


        static Option<TResult> Single<TList, TSource, TResult>(this TList source, NullableSelector<TSource, TResult> selector, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
            => takeCount switch
            {
                0 => Option.None,
                1 => Option.Some(selector(source[skipCount])),
                _ => Option.None,
            };


        static Option<TResult> Single<TList, TSource, TResult>(this TList source, NullableSelectorAt<TSource, TResult> selector, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
            => takeCount switch
            {
                0 => Option.None,
                1 => Option.Some(selector(source[skipCount], 0)),
                _ => Option.None,
            };


        static Option<TResult> Single<TList, TSource, TResult>(this TList source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
            => GetSingle<TList, TSource>(source, predicate, skipCount, takeCount).Select(selector);

        ////////////////////////////////
        // GetSingle 

        
        static Option<TSource> GetSingle<TList, TSource>(this TList source, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
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
        
        
        static Option<TSource> GetSingle<TList, TSource>(this TList source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (skipCount == 0)
            {
                for (var index = 0; index < takeCount; index++)
                {
                    if (predicate(source[index], index))
                    {
                        var value = source[index];

                        for (index++; index < takeCount; index++)
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
                for (var index = 0; index < takeCount; index++)
                {
                    if (predicate(source[index + skipCount], index))
                    {
                        var value = source[index + skipCount];

                        for (index++; index < takeCount; index++)
                        {
                            if (predicate(source[index + skipCount], index))
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
