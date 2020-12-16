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
                : Option.Some(source.Array![index + source.Offset]);

        static Option<TSource> ElementAt<TSource, TPredicate>(this in ArraySegment<TSource> source, int index, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, bool>
        {
            if (source.Any() && index >= 0)
            {
                if (source.IsWhole())
                {
                    foreach (var item in source.Array!)
                    {
                        if (predicate.Invoke(item) && index-- == 0)
                            return Option.Some(item);
                    }
                }
                else
                {
                    var array = source.Array!;
                    var end = source.Offset + source.Count - 1;
                    for (var sourceIndex = source.Offset; sourceIndex <= end; sourceIndex++)
                    {
                        var item = array[sourceIndex];
                        if (predicate.Invoke(item) && index-- == 0)
                            return Option.Some(item);
                    }
                }
            }
            return Option.None;
        }


        static Option<TSource> ElementAtAt<TSource, TPredicate>(this in ArraySegment<TSource> source, int index, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            if (source.Any() && index >= 0)
            {
                if (source.IsWhole())
                {
                    var sourceIndex = 0;
                    foreach (var item in source.Array!)
                    {
                        if (predicate.Invoke(item, sourceIndex) && index-- == 0)
                            return Option.Some(item);

                        sourceIndex++;
                    }
                }
                else
                {
                    var array = source.Array!;
                    if (source.Offset == 0)
                    {
                        var end = source.Count - 1;
                        for (var sourceIndex = 0; sourceIndex <= end; sourceIndex++)
                        {
                            var item = array[sourceIndex];
                            if (predicate.Invoke(item, sourceIndex) && index-- == 0)
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
                            if (predicate.Invoke(item, sourceIndex) && index-- == 0)
                                return Option.Some(item);
                        }
                    }
                }
            }
            return Option.None;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> ElementAt<TSource, TResult, TSelector>(this in ArraySegment<TSource> source, int index, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
            => index < 0 || index >= source.Count
                ? Option.None
                : Option.Some(selector.Invoke(source.Array![index + source.Offset]));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> ElementAtAt<TSource, TResult, TSelector>(this in ArraySegment<TSource> source, int index, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
            => index < 0 || index >= source.Count
                ? Option.None
                : Option.Some(selector.Invoke(source.Array![index + source.Offset], index));


        static Option<TResult> ElementAt<TSource, TResult, TPredicate, TSelector>(this in ArraySegment<TSource> source, int index, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            if (source.Any() && index >= 0)
            {
                if (source.IsWhole())
                {
                    foreach (var item in source.Array!)
                    {
                        if (predicate.Invoke(item) && index-- == 0)
                            return Option.Some(selector.Invoke(item));
                    }
                }
                else
                {
                    var array = source.Array!;
                    var end = source.Offset + source.Count - 1;
                    for (var sourceIndex = source.Offset; sourceIndex <= end; sourceIndex++)
                    {
                        var item = array[sourceIndex];
                        if (predicate.Invoke(item) && index-- == 0)
                            return Option.Some(selector.Invoke(item));
                    }
                }
            }
            return Option.None;
        }
    }
}
