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
                0 => Option.None,
                1 => Option.Some(source.Array[source.Offset]),
                _ => Option.None,
            };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TSource> Single<TSource>(this in ArraySegment<TSource> source, Predicate<TSource> predicate)
            => GetSingle(source, predicate);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TSource> Single<TSource>(this in ArraySegment<TSource> source, PredicateAt<TSource> predicate)
            => GetSingle(source, predicate);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> Single<TSource, TResult>(this in ArraySegment<TSource> source, NullableSelector<TSource, TResult> selector)
            => source.Count switch
            {
                0 => Option.None,
                1 => Option.Some(selector(source.Array[source.Offset])),
                _ => Option.None,
            };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> Single<TSource, TResult>(this in ArraySegment<TSource> source, NullableSelectorAt<TSource, TResult> selector)
            => source.Count switch
            {
                0 => Option.None,
                1 => Option.Some(selector(source.Array[source.Offset], 0)),
                _ => Option.None,
            };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> Single<TSource, TResult>(this in ArraySegment<TSource> source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector)
            => GetSingle(source, predicate).Select(selector);

        ////////////////////////////////
        // GetSingle 


        static Option<TSource> GetSingle<TSource>(this in ArraySegment<TSource> source, Predicate<TSource> predicate)
        {
            var array = source.Array;
            if (source.Offset == 0 && source.Count == array.Length)
            {
                for (var index = 0; index < array.Length; index++)
                {
                    if (predicate(array[index]))
                    {
                        var value = array[index];

                        for (index++; index < array.Length; index++)
                        {
                            if (predicate(array[index]))
                                return Option.None;
                        }

                        return Option.Some(value);
                    }
                }
            }
            else
            {
                var end = source.Offset + source.Count;
                for (var index = source.Offset; index < end; index++)
                {
                    if (predicate(array[index]))
                    {
                        var value = array[index];

                        for (index++; index < end; index++)
                        {
                            if (predicate(array[index]))
                                return Option.None;
                        }

                        return Option.Some(value);
                    }
                }
            }
            return Option.None;
        }


        static Option<TSource> GetSingle<TSource>(this in ArraySegment<TSource> source, PredicateAt<TSource> predicate)
        {
            var array = source.Array;
            if (source.Offset == 0)
            {
                if (source.Count == array.Length)
                {
                    for (var index = 0; index < array.Length; index++)
                    {
                        if (predicate(array[index], index))
                        {
                            var value = array[index];

                            for (index++; index < array.Length; index++)
                            {
                                if (predicate(array[index], index))
                                    return Option.None;
                            }

                            return Option.Some(value);
                        }
                    }
                }
                else
                {
                    for (var index = 0; index < source.Count; index++)
                    {
                        if (predicate(array[index], index))
                        {
                            var value = array[index];

                            for (index++; index < source.Count; index++)
                            {
                                if (predicate(array[index], index))
                                    return Option.None;
                            }

                            return Option.Some(value);
                        }
                    }
                }
            }
            else
            {
                var offset = source.Offset;
                for (var index = 0; index < source.Count; index++)
                {
                    if (predicate(array[index + offset], index))
                    {
                        var value = array[index + offset];

                        for (index++; index < source.Count; index++)
                        {
                            if (predicate(array[index + offset], index))
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
