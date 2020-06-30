using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> First<TSource>(this in ArraySegment<TSource> source)
            => source.Count switch
            {
                0 => Option.None,
                _ => Option.Some(source.Array[source.Offset]),
            };


        static Option<TSource> First<TSource>(this in ArraySegment<TSource> source, Predicate<TSource> predicate)
        {
            var array = source.Array;
            if (source.Offset == 0 && source.Count == array.Length)
            {
                for (var index = 0; index < array.Length; index++)
                {
                    var item = array[index];
                    if (predicate(item))
                        return Option.Some(item);
                }
            }
            else
            {
                var end = source.Offset + source.Count;
                for (var index = source.Offset; index < end; index++)
                {
                    var item = array[index];
                    if (predicate(item))
                        return Option.Some(item);
                }
            }
            return Option.None;
        }


        static Option<TSource> First<TSource>(this in ArraySegment<TSource> source, PredicateAt<TSource> predicate)
        {
            var array = source.Array;
            if (source.Offset == 0)
            {
                if (source.Count == array.Length)
                {
                    for (var index = 0; index < array.Length; index++)
                    {
                        var item = array[index];
                        if (predicate(item, index))
                            return Option.Some(item);
                    }
                }
                else
                {
                    for (var index = 0; index < source.Count; index++)
                    {
                        var item = array[index];
                        if (predicate(item, index))
                            return Option.Some(item);
                    }
                }
            }
            else
            {
                var offset = source.Offset;
                for (var index = 0; index < source.Count; index++)
                {
                    var item = array[index + offset];
                    if (predicate(item, index))
                        return Option.Some(item);
                }
            }
            return Option.None;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> First<TSource, TResult>(this in ArraySegment<TSource> source, NullableSelector<TSource, TResult> selector)
            => source.Count switch
            {
                0 => Option.None,
                _ => Option.Some(selector(source.Array[source.Offset])),
            };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> First<TSource, TResult>(this in ArraySegment<TSource> source, NullableSelectorAt<TSource, TResult> selector)
            => source.Count switch
            {
                0 => Option.None,
                _ => Option.Some(selector(source.Array[source.Offset], 0)),
            };


        static Option<TResult> First<TSource, TResult>(this in ArraySegment<TSource> source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector)
        {
            var array = source.Array;
            if (source.Offset == 0 && source.Count == array.Length)
            {
                for (var index = 0; index < array.Length; index++)
                {
                    if (predicate(array[index]))
                        return Option.Some(selector(array[index]));
                }
            }
            else
            {
                var end = source.Offset + source.Count;
                for (var index = source.Offset; index < end; index++)
                {
                    if (predicate(array[index]))
                        return Option.Some(selector(array[index]));
                }
            }
            return Option.None;
        }
    }
}
