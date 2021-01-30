using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> Single<TSource>(this in ArraySegment<TSource> source)
            => source.Count switch
            {
                1 => Option.Some(source.Array![source.Offset]),
                _ => Option.None
            };

        static Option<TSource> Single<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, bool>
        {
            var array = source.Array!;
            var start = source.Offset;
            var end = start + source.Count;
            for (var index = start; index < end; index++)
            {
                var item = array[index];
                if (predicate.Invoke(item))
                {
                    var first = item;

                    for (index++; index < end; index++)
                    {
                        item = array[index];
                        if (predicate.Invoke(item))
                            return Option.None;
                    }

                    return Option.Some(first);
                }
            }
            return Option.None;
        }


        static Option<TSource> SingleAt<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            var array = source.Array!;
            var start = source.Offset;
            var end = source.Count;
            if (start is 0)
            {
                for (var index = 0; index < end; index++)
                {
                    var item = array[index];
                    if (predicate.Invoke(item, index))
                    {
                        var first = item;

                        for (index++; index < end; index++)
                        {
                            item = array[index];
                            if (predicate.Invoke(item, index))
                                return Option.None;
                        }

                        return Option.Some(first);
                    }
                }
            }
            else
            {
                for (var index = 0; index < end; index++)
                {
                    var item = array[index + start];
                    if (predicate.Invoke(item, index))
                    {
                        var first = item;

                        for (index++; index < end; index++)
                        {
                            item = array[index + start];
                            if (predicate.Invoke(item, index))
                                return Option.None;
                        }

                        return Option.Some(first);
                    }
                }
            }
            return Option.None;
        }


        static Option<TResult> Single<TSource, TResult, TSelector>(this in ArraySegment<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Count switch
            {
                1 => Option.Some(selector.Invoke(source.Array![source.Offset])),
                _ => Option.None
            };


        static Option<TResult> SingleAt<TSource, TResult, TSelector>(this in ArraySegment<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
            => source.Count switch
            {
                1 => Option.Some(selector.Invoke(source.Array![source.Offset], 0)),
                _ => Option.None
            };


        static Option<TResult> Single<TSource, TResult, TPredicate, TSelector>(this in ArraySegment<TSource> source, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            var array = source.Array!;
            var start = source.Offset;
            var end = start + source.Count;
            for (var index = source.Offset; index < end; index++)
            {
                var item = array[index];
                if (predicate.Invoke(item))
                {
                    var first = item;

                    for (index++; index < end; index++)
                    {
                        item = array[index];
                        if (predicate.Invoke(item))
                            return Option.None;
                    }

                    return Option.Some(selector.Invoke(first));
                }
            }
            return Option.None;
        }
    }
}
