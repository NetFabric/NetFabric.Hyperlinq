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
                if (source.IsWhole())
                {
                    foreach (var item in source.Array!)
                    {
                        if (predicate.Invoke(item))
                            return Option.Some(item);
                    }
                }
                else
                {
                    var array = source.Array!;
                    var end = source.Offset + source.Count - 1;
                    for (var index = source.Offset; index <= end; index++)
                    {
                        if (predicate.Invoke(array[index]))
                            return Option.Some(array[index]);
                    }
                }
            }
            return Option.None;
        }


        static Option<TSource> FirstAt<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            if (source.Any())
            {
                if (source.IsWhole())
                {
                    var index = 0;
                    foreach (var item in source.Array!)
                    {
                        if (predicate.Invoke(item, index))
                            return Option.Some(item);

                        index++;
                    }
                }
                else
                {
                    var array = source.Array!;
                    if (source.Offset == 0)
                    {
                        var end = source.Count - 1;
                        for (var index = 0; index <= end; index++)
                        {
                            var item = array[index];
                            if (predicate.Invoke(item, index))
                                return Option.Some(item);
                        }
                    }
                    else
                    {
                        var offset = source.Offset;
                        var end = source.Count - 1;
                        for (var index = 0; index <= end; index++)
                        {
                            var item = array[index + offset];
                            if (predicate.Invoke(item, index))
                                return Option.Some(item);
                        }
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
                if (source.IsWhole())
                {
                    foreach (var item in source.Array!)
                    {
                        if (predicate.Invoke(item))
                            return Option.Some(selector.Invoke(item));
                    }
                }
                else
                {
                    var array = source.Array!;
                    var end = source.Offset + source.Count - 1;
                    for (var index = source.Offset; index <= end; index++)
                    {
                        if (predicate.Invoke(array[index]))
                            return Option.Some(selector.Invoke(array[index]));
                    }
                }
            }
            return Option.None;
        }
    }
}
