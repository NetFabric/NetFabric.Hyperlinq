using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {

        public static Option<TSource> Single<TList, TSource>(this TList source)
            where TList : struct, IReadOnlyList<TSource>
            => source.Single<TList, TSource>(0, source.Count);

        static Option<TSource> Single<TList, TSource>(this TList source, int offset, int count) 
            where TList : struct, IReadOnlyList<TSource>
            => count switch
            {
                1 => Option.Some(source[offset]),
                _ => Option.None,
            };


        static Option<TSource> Single<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count) 
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            => source.GetSingle<TList, TSource, TPredicate>(predicate, offset, count);


        static Option<TSource> SingleAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count) 
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.GetSingleAt<TList, TSource, TPredicate>(predicate, offset, count);


        static Option<TResult> Single<TList, TSource, TResult, TSelector>(this TList source, TSelector selector, int offset, int count) 
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            => count switch
            {
                1 => Option.Some(selector.Invoke(source[offset])),
                _ => Option.None,
            };


        static Option<TResult> SingleAt<TList, TSource, TResult, TSelector>(this TList source, TSelector selector, int offset, int count) 
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
            => count switch
            {
                1 => Option.Some(selector.Invoke(source[offset], 0)),
                _ => Option.None,
            };


        static Option<TResult> Single<TList, TSource, TResult, TPredicate, TSelector>(this TList source, TPredicate predicate, TSelector selector, int offset, int count) 
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            => source.GetSingle<TList, TSource, TPredicate>(predicate, offset, count).Select<TResult, TSelector>(selector);

        ////////////////////////////////
        // GetSingle 

        
        static Option<TSource> GetSingle<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            var end = offset + count;
            for (var index = offset; index < end; index++)
            {
                var item = source[index];
                if (predicate.Invoke(item))
                {
                    var value = item;

                    for (index++; index < end; index++)
                    {
                        item = source[index];
                        if (predicate.Invoke(item))
                            return Option.None;
                    }

                    return Option.Some(value);
                }
            }

            return Option.None;
        }
        
        
        static Option<TSource> GetSingleAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            var end = count;
            if (offset is 0)
            {
                for (var index = 0; index < end; index++)
                {
                    var item = source[index];
                    if (predicate.Invoke(item, index))
                    {
                        var value = item;

                        for (index++; index < end; index++)
                        {
                            item = source[index];
                            if (predicate.Invoke(item, index))
                                return Option.None;
                        }

                        return Option.Some(value);
                    }
                }
            }
            else
            {
                for (var index = 0; index < end; index++)
                {
                    var item = source[index + offset];
                    if (predicate.Invoke(item, index))
                    {
                        var value = item;

                        for (index++; index < end; index++)
                        {
                            item = source[index + offset];
                            if (predicate.Invoke(item, index))
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
