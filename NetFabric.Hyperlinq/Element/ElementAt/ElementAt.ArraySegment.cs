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
                if (source.IsWhole())
                {
                    foreach (var item in array)
                    {
                        if (predicate(item) && index-- == 0)
                            return Option.Some(item);
                    }
                }
                else
                {
                    var end = source.Offset + source.Count - 1;
                    for (var sourceIndex = source.Offset; sourceIndex <= end; sourceIndex++)
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
                if (source.IsWhole())
                {
                    var sourceIndex = 0;
                    foreach (var item in array)
                    {
                        if (predicate(item, sourceIndex) && index-- == 0)
                            return Option.Some(item);

                        sourceIndex++;
                    }
                }
                else
                {
                    if (source.Offset == 0)
                    {
                        var end = source.Count - 1;
                        for (var sourceIndex = 0; sourceIndex <= end; sourceIndex++)
                        {
                            var item = array[sourceIndex];
                            if (predicate(item, sourceIndex) && index-- == 0)
                                return Option.Some(item);
                        }
                    }
                    else
                    {
                        var offset = source.Offset;
                        var end = source.Count - 1;
                        for (var sourceIndex = 0; sourceIndex <= end; sourceIndex++)
                        {
                            var item = array[sourceIndex + offset];
                            if (predicate(item, sourceIndex) && index-- == 0)
                                return Option.Some(item);
                        }
                    }
                }
            }
            return Option.None;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> ElementAt<TSource, TResult>(this in ArraySegment<TSource> source, int index, NullableSelector<TSource, TResult> selector)
            => index < 0 || index >= source.Count
                ? Option.None
                : Option.Some(selector(source.Array[index + source.Offset]));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TResult> ElementAt<TSource, TResult>(this in ArraySegment<TSource> source, int index, NullableSelectorAt<TSource, TResult> selector)
            => index < 0 || index >= source.Count
                ? Option.None
                : Option.Some(selector(source.Array[index + source.Offset], index));


        static Option<TResult> ElementAt<TSource, TResult>(this in ArraySegment<TSource> source, int index, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector)
        {
            if (index >= 0)
            {
                var array = source.Array;
                if (source.IsWhole())
                {
                    foreach (var item in array)
                    {
                        if (predicate(item) && index-- == 0)
                            return Option.Some(selector(item));
                    }
                }
                else
                {
                    var end = source.Offset + source.Count - 1;
                    for (var sourceIndex = source.Offset; sourceIndex <= end; sourceIndex++)
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
