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
            var end = source.Offset + source.Count - 1;
            for (var index = source.Offset; index <= end; index++)
            {
                if (predicate.Invoke(array[index]))
                {
                    ref readonly var first = ref array[index];

                    for (index++; index <= end; index++)
                    {
                        if (predicate.Invoke(array[index]))
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
            if (source.Offset is 0)
            {
                var end = source.Count - 1;
                for (var index = 0; index <= end; index++)
                {
                    if (predicate.Invoke(array[index], index))
                    {
                        ref readonly var first = ref array[index];

                        for (index++; index <= end; index++)
                        {
                            if (predicate.Invoke(array[index], index))
                                return Option.None;
                        }

                        return Option.Some(first);
                    }
                }
            }
            else
            {
                var offset = source.Offset;
                var end = source.Count - 1;
                for (var index = 0; index <= end; index++)
                {
                    if (predicate.Invoke(array[index + offset], index))
                    {
                        ref readonly var first = ref array[index + offset];

                        for (index++; index <= end; index++)
                        {
                            if (predicate.Invoke(array[index + offset], index))
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
            var end = source.Offset + source.Count - 1;
            for (var index = source.Offset; index <= end; index++)
            {
                if (predicate.Invoke(array[index]))
                {
                    ref readonly var first = ref array[index];

                    for (index++; index <= end; index++)
                    {
                        if (predicate.Invoke(array[index]))
                            return Option.None;
                    }

                    return Option.Some(selector.Invoke(first));
                }
            }
            return Option.None;
        }
    }
}
