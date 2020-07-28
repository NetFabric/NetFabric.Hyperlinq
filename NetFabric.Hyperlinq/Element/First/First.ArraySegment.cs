using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> First<TSource>(this in ArraySegment<TSource> source)
            => source.Count == 0
                ? Option.None
                : Option.Some(source.Array[source.Offset]);


        static Option<TSource> First<TSource>(this in ArraySegment<TSource> source, Predicate<TSource> predicate)
        {
            var array = source.Array;
            if (source.IsWhole())
            {
                foreach (var item in array)
                {
                    if (predicate(item))
                        return Option.Some(item);
                }
            }
            else
            {
                var end = source.Offset + source.Count - 1;
                for (var index = source.Offset; index <= end; index++)
                {
                    if (predicate(array[index]))
                        return Option.Some(array[index]);
                }
            }
            return Option.None;
        }


        static Option<TSource> First<TSource>(this in ArraySegment<TSource> source, PredicateAt<TSource> predicate)
        {
            var array = source.Array;
            if (source.IsWhole())
            {
                var index = 0;
                foreach (var item in array)
                {
                    if (predicate(item, index))
                        return Option.Some(item);
                    index++;
                }
            }
            else
            {
                var end = source.Offset + source.Count - 1;
                for (var index = source.Offset; index <= end; index++)
                {
                    if (predicate(array[index], index))
                        return Option.Some(array[index]);
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
            if (source.IsWhole())
            {
                foreach (var item in array)
                {
                    if (predicate(item))
                        return Option.Some(selector(item));
                }
            }
            else
            {
                var end = source.Offset + source.Count - 1;
                for (var index = source.Offset; index <= end; index++)
                {
                    if (predicate(array[index]))
                        return Option.Some(selector(array[index]));
                }
            }
            return Option.None;
        }
    }
}
