using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        public static bool Contains<TList, TSource>(this in ArraySegment<TSource> source, TSource value)
            where TSource : struct
        {
            if (source.Any())
            {
                if (source.IsWhole())
                {
                    foreach (var item in source.Array!)
                    {
                        if (EqualityComparer<TSource>.Default.Equals(item, value))
                            return true;
                    }
                }
                else
                {
                    var array = source.Array!;
                    var end = source.Count + source.Offset - 1;
                    for (var index = source.Offset; index <= end; index++)
                    {
                        if (EqualityComparer<TSource>.Default.Equals(array[index], value))
                            return true;
                    }
                }
            }
            return false;
        }

        public static bool Contains<TSource>(this in ArraySegment<TSource> source, TSource value, IEqualityComparer<TSource>? comparer = default)
        {
            if (source.Count == 0)
                return false;

            if (Utils.UseDefault(comparer))
                return DefaultContains(source, value);

            comparer ??= EqualityComparer<TSource>.Default;
            return ComparerContains(source, value, comparer);

            static bool DefaultContains(in ArraySegment<TSource> source, TSource value)
            {
                if (source.Any())
                {
                    if (source.IsWhole())
                    {
                        foreach (var item in source.Array!)
                        {
                            if (EqualityComparer<TSource>.Default.Equals(item, value))
                                return true;
                        }
                    }
                    else
                    {
                        var array = source.Array!;
                        var end = source.Count + source.Offset - 1;
                        for (var index = source.Offset; index <= end; index++)
                        {
                            if (EqualityComparer<TSource>.Default.Equals(array[index], value))
                                return true;
                        }
                    }
                }
                return false;
            }

            static bool ComparerContains(in ArraySegment<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            {
                if (source.Any())
                {
                    if (source.IsWhole())
                    {
                        foreach (var item in source.Array!)
                        {
                            if (comparer.Equals(item, value))
                                return true;
                        }
                    }
                    else
                    {
                        var array = source.Array!;
                        var end = source.Count + source.Offset - 1;
                        for (var index = source.Offset; index <= end; index++)
                        {
                            if (comparer.Equals(array[index], value))
                                return true;
                        }
                    }
                }
                return false;
            }
        }


        static bool Contains<TSource, TResult, TSelector>(this in ArraySegment<TSource> source, TResult value, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
        {
            return source.Count switch
            {
                0 => false,
                _ => Utils.IsValueType<TResult>()
                    ? ValueContains(source, value, selector)
                    : ReferenceContains(source, value, selector)
            };

            static bool ValueContains(in ArraySegment<TSource> source, TResult value, TSelector selector)
            {
                if (source.Any())
                {
                    if (source.IsWhole())
                    {
                        foreach (var item in source.Array!)
                        {
                            if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(item), value))
                                return true;
                        }
                    }
                    else
                    {
                        var array = source.Array!;
                        var end = source.Count + source.Offset - 1;
                        for (var index = source.Offset; index <= end; index++)
                        {
                            if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(array[index]), value))
                                return true;
                        }
                    }
                }
                return false;
            }

            static bool ReferenceContains(in ArraySegment<TSource> source, TResult value, TSelector selector)
            {
                var defaultComparer = EqualityComparer<TResult>.Default;

                if (source.Any())
                {
                    if (source.IsWhole())
                    {
                        foreach (var item in source.Array!)
                        {
                            if (defaultComparer.Equals(selector.Invoke(item), value))
                                return true;
                        }
                    }
                    else
                    {
                        var array = source.Array!;
                        var end = source.Count + source.Offset - 1;
                        for (var index = source.Offset; index <= end; index++)
                        {
                            if (defaultComparer.Equals(selector.Invoke(array[index]), value))
                                return true;
                        }
                    }
                }
                return false;
            }
        }


        static bool ContainsAt<TSource, TResult, TSelector>(this in ArraySegment<TSource> source, TResult value, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            return source.Count switch
            {
                0 => false,
                _ => Utils.IsValueType<TResult>()
                    ? ValueContains(source, value, selector)
                    : ReferenceContains(source, value, selector),
            };

            static bool ValueContains(in ArraySegment<TSource> source, TResult value, TSelector selector)
            {
                if (source.Any())
                {
                    if (source.IsWhole())
                    {
                        var index = 0;
                        foreach (var item in source.Array!)
                        {
                            if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(item, index), value))
                                return true;

                            index++;
                        }
                    }
                    else
                    {
                        var end = source.Count - 1;
                        if (source.Offset == 0)
                        {
                            var array = source.Array!;
                            for (var index = 0; index <= end; index++)
                            {
                                if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(array[index], index), value))
                                    return true;
                            }
                        }
                        else
                        {
                            var array = source.Array!;
                            var offset = source.Offset;
                            for (var index = 0; index <= end; index++)
                            {
                                if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(array[index + offset], index), value))
                                    return true;
                            }
                        }
                    }
                }
                return false;
            }

            static bool ReferenceContains(in ArraySegment<TSource> source, TResult value, TSelector selector)
            {
                var defaultComparer = EqualityComparer<TResult>.Default;

                if (source.Any())
                {
                    if (source.IsWhole())
                    {
                        var index = 0;
                        foreach (var item in source.Array!)
                        {
                            if (defaultComparer.Equals(selector.Invoke(item, index)!, value))
                                return true;

                            index++;
                        }
                    }
                    else
                    {
                        var end = source.Count - 1;
                        if (source.Offset == 0)
                        {
                            var array = source.Array!;
                            for (var index = 0; index <= end; index++)
                            {
                                if (defaultComparer.Equals(selector.Invoke(array[index], index), value))
                                    return true;
                            }
                        }
                        else
                        {
                            var array = source.Array!;
                            var offset = source.Offset;
                            for (var index = 0; index <= end; index++)
                            {
                                if (defaultComparer.Equals(selector.Invoke(array[index + offset], index), value))
                                    return true;
                            }
                        }
                    }
                }
                return false;
            }
        }
    }
}

