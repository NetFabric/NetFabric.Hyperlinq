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
                _ => Option.Some(source.Array![source.Offset])
            };

        static Option<TSource> First<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, bool>
        {
            if (source.Any())
            {
                var array = source.Array!;
                var start = source.Offset;
                var end = start + source.Count;
                for (var index = start; index < end; index++)
                {
                    var item = array[index];
                    if (predicate.Invoke(item))
                        return Option.Some(item);
                }
            }
            return Option.None;
        }


        static Option<TSource> FirstAt<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            if (source.Any())
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
                            return Option.Some(item);
                    }
                }
                else
                {
                    for (var index = 0; index < end; index++)
                    {
                        var item = array[index + start];
                        if (predicate.Invoke(item, index))
                            return Option.Some(item);
                    }
                }
            }
            return Option.None;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> First<TSource, TResult, TSelector>(this in ArraySegment<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Count switch
            {
                0 => Option.None,
                _ => Option.Some(selector.Invoke(source.Array![source.Offset]))
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> FirstAt<TSource, TResult, TSelector>(this in ArraySegment<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
            => source.Count switch
            {
                0 => Option.None,
                _ => Option.Some(selector.Invoke(source.Array![source.Offset], 0))
            };
        
        static Option<TResult> First<TSource, TResult, TPredicate, TSelector>(this in ArraySegment<TSource> source, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            if (source.Any())
            {
                var array = source.Array!;
                var start = source.Offset;
                var end = start + source.Count;
                for (var index = start; index < end; index++)
                {
                    var item = array[index];
                    if (predicate.Invoke(item))
                        return Option.Some(selector.Invoke(item));
                }
            }
            return Option.None;
        }
    }
}
