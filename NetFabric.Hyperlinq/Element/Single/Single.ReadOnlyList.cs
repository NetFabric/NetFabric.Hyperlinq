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


        static Option<TSource> Single<TList, TSource>(this TList source, int offset, int count) 
            where TList : notnull, IReadOnlyList<TSource>
            => count switch
            {
                0 => Option.None,
                1 => Option.Some(source[offset]),
                _ => Option.None,
            };


        static Option<TSource> Single<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count) 
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicate<TSource>
            => GetSingle<TList, TSource, TPredicate>(source, predicate, offset, count);


        static Option<TSource> SingleAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count) 
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicateAt<TSource>
            => GetSingleAt<TList, TSource, TPredicate>(source, predicate, offset, count);


        static Option<TResult?> Single<TList, TSource, TResult>(this TList source, NullableSelector<TSource, TResult> selector, int offset, int count) 
            where TList : notnull, IReadOnlyList<TSource>
            => count switch
            {
                0 => Option.None,
                1 => Option.Some(selector(source[offset])),
                _ => Option.None,
            };


        static Option<TResult?> Single<TList, TSource, TResult>(this TList source, NullableSelectorAt<TSource, TResult> selector, int offset, int count) 
            where TList : notnull, IReadOnlyList<TSource>
            => count switch
            {
                0 => Option.None,
                1 => Option.Some(selector(source[offset], 0)),
                _ => Option.None,
            };


        static Option<TResult> Single<TList, TSource, TResult, TPredicate>(this TList source, TPredicate predicate, NullableSelector<TSource, TResult> selector, int offset, int count) 
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicate<TSource>
            => GetSingle<TList, TSource, TPredicate>(source, predicate, offset, count).Select(selector);

        ////////////////////////////////
        // GetSingle 

        
        static Option<TSource> GetSingle<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            var end = offset + count - 1;
            for (var index = offset; index <= end; index++)
            {
                if (predicate.Invoke(source[index]))
                {
                    var value = source[index];

                    for (index++; index <= end; index++)
                    {
                        if (predicate.Invoke(source[index]))
                            return Option.None;
                    }

                    return Option.Some(value);
                }
            }

            return Option.None;
        }
        
        
        static Option<TSource> GetSingleAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicateAt<TSource>
        {
            var end = count - 1;
            if (offset == 0)
            {
                for (var index = 0; index <= end; index++)
                {
                    if (predicate.Invoke(source[index], index))
                    {
                        var value = source[index];

                        for (index++; index <= end; index++)
                        {
                            if (predicate.Invoke(source[index], index))
                                return Option.None;
                        }

                        return Option.Some(value);
                    }
                }
            }
            else
            {
                for (var index = 0; index <= end; index++)
                {
                    if (predicate.Invoke(source[index + offset], index))
                    {
                        var value = source[index + offset];

                        for (index++; index <= end; index++)
                        {
                            if (predicate.Invoke(source[index + offset], index))
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
