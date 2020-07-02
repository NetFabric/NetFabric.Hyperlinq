using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> ElementAt<TSource>(this in ArraySegment<TSource> source, int index)
            => index < 0 || index >= source.Count
                ? Option.None
                : Option.Some(source.Array[index + source.Offset]);


        static Option<TSource> ElementAt<TSource>(this in ArraySegment<TSource> source, int index, Predicate<TSource> predicate)
        {
            if (index >= 0)
            {
                var array = source.Array;
                if (source.Offset == 0 && source.Count == array.Length)
                {
                    for (var sourceIndex = 0; sourceIndex < array.Length; sourceIndex++)
                    {
                        var item = array[sourceIndex];
                        if (predicate(item) && index-- == 0)
                            return Option.Some(item);
                    }
                }
                else
                {
                    var end = source.Offset + source.Count;
                    for (var sourceIndex = source.Offset; sourceIndex < end; sourceIndex++)
                    {
                        var item = array[sourceIndex];
                        if (predicate(item) && index-- == 0)
                            return Option.Some(item);
                    }
                }
            }
            return Option.None;
        }


        static Option<TSource> ElementAt<TSource>(this in ArraySegment<TSource> source, int index, PredicateAt<TSource> predicate)
        {
            if (index >= 0)
            {
                var array = source.Array;
                if (source.Offset == 0)
                {
                    if (source.Count == array.Length)
                    {
                        for (var sourceIndex = 0; sourceIndex < array.Length; sourceIndex++)
                        {
                            var item = array[sourceIndex];
                            if (predicate(item, sourceIndex) && index-- == 0)
                                return Option.Some(item);
                        }
                    }
                    else
                    {
                        for (var sourceIndex = 0; sourceIndex < source.Count; sourceIndex++)
                        {
                            var item = array[sourceIndex];
                            if (predicate(item, sourceIndex) && index-- == 0)
                                return Option.Some(item);
                        }
                    }
                }
                else
                {
                    for (var sourceIndex = 0; sourceIndex < source.Count; sourceIndex++)
                    {
                        var item = array[sourceIndex + source.Offset];
                        if (predicate(item, sourceIndex) && index-- == 0)
                            return Option.Some(item);
                    }
                }
            }
            return Option.None;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> ElementAt<TSource, TResult>(this in ArraySegment<TSource> source, int index, NullableSelector<TSource, TResult> selector)
            => index >= 0 && index < source.Count
                ? Option.Some(selector(source.Array[index + source.Offset]))
                : Option.None;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TResult> ElementAt<TSource, TResult>(this in ArraySegment<TSource> source, int index, NullableSelectorAt<TSource, TResult> selector)
            => index >= 0 && index < source.Count
                ? Option.Some(selector(source.Array[index + source.Offset], index))
                : Option.None;


        static Option<TResult> ElementAt<TSource, TResult>(this in ArraySegment<TSource> source, int index, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector)
        {
            if (index >= 0)
            {
                var array = source.Array;
                if (source.Offset == 0 && source.Count == array.Length)
                {
                    for (var sourceIndex = 0; sourceIndex < array.Length; sourceIndex++)
                    {
                        var item = array[sourceIndex];
                        if (predicate(item) && index-- == 0)
                            return Option.Some(selector(item));
                    }
                }
                else
                {
                    var end = source.Offset + source.Count;
                    for (var sourceIndex = source.Offset; sourceIndex < end; sourceIndex++)
                    {
                        var item = array[sourceIndex];
                        if (predicate(item) && index-- == 0)
                            return Option.Some(selector(item));
                    }
                }
            }
            return Option.None;
        }
    }
}
