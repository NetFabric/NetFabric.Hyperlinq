using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        public static bool Contains<TSource>(this in ArraySegment<TSource> source, TSource value)
        {
            if (source.Any())
            {
                var array = source.Array!;
                var start = source.Offset;
                var end = start + source.Count;
                for (var index = start; index < end; index++)
                {
                    var item = array[index];
                    if (EqualityComparer<TSource>.Default.Equals(item, value))
                        return true;
                }
            }
            return false;
        }

        public static bool Contains<TSource>(this in ArraySegment<TSource> source, TSource value, IEqualityComparer<TSource>? comparer)
        {
            if (source.Count is 0)
                return false;

            if (Utils.UseDefault(comparer))
                return DefaultContains(source, value);

            comparer ??= EqualityComparer<TSource>.Default;
            return ComparerContains(source, value, comparer);

            static bool DefaultContains(in ArraySegment<TSource> source, TSource value)
            {
                if (source.Any())
                {
                    var array = source.Array!;
                    var start = source.Offset;
                    var end = start + source.Count;
                    for (var index = start; index < end; index++)
                    {
                        var item = array[index];
                        if (EqualityComparer<TSource>.Default.Equals(item, value))
                            return true;
                    }
                }
                return false;
            }

            static bool ComparerContains(in ArraySegment<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            {
                if (source.Any())
                {
                    var array = source.Array!;
                    var start = source.Offset;
                    var end = start + source.Count;
                    for (var index = start; index < end; index++)
                    {
                        var item = array[index];
                        if (comparer.Equals(item, value))
                            return true;
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
                    var array = source.Array!;
                    var start = source.Offset;
                    var end = start + source.Count;
                    for (var index = start; index < end; index++)
                    {
                        var item = array[index];
                        if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(item), value))
                            return true;
                    }
                }
                return false;
            }

            static bool ReferenceContains(in ArraySegment<TSource> source, TResult value, TSelector selector)
            {
                var defaultComparer = EqualityComparer<TResult>.Default;

                if (source.Any())
                {
                    var array = source.Array!;
                    var start = source.Offset;
                    var end = start + source.Count;
                    for (var index = start; index < end; index++)
                    {
                        var item = array[index];
                        if (defaultComparer.Equals(selector.Invoke(item), value))
                            return true;
                    }
                }
                return false;
            }
        }


        static bool ContainsRef<TSource, TResult, TSelector>(this in ArraySegment<TSource> source, TResult value, TSelector selector)
            where TSelector : struct, IFunctionIn<TSource, TResult>
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
                    var array = source.Array!;
                    var start = source.Offset;
                    var end = start + source.Count;
                    for (var index = start; index < end; index++)
                    {
                        var item = array[index];
                        if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(in item), value))
                            return true;
                    }
                }
                return false;
            }

            static bool ReferenceContains(in ArraySegment<TSource> source, TResult value, TSelector selector)
            {
                var defaultComparer = EqualityComparer<TResult>.Default;

                if (source.Any())
                {
                    var array = source.Array!;
                    var start = source.Offset;
                    var end = start + source.Count;
                    for (var index = start; index < end; index++)
                    {
                        var item = array[index];
                        if (defaultComparer.Equals(selector.Invoke(in item), value))
                            return true;
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
                    var array = source.Array!;
                    var start = source.Offset;
                    var end = source.Count;
                    if (start is 0)
                    {
                        for (var index = 0; index < end; index++)
                        {
                            var item = array[index];
                            if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(item, index), value))
                                return true;
                        }
                    }
                    else
                    {
                        for (var index = 0; index < end; index++)
                        {
                            var item = array[index + start];
                            if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(item, index), value))
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
                    var array = source.Array!;
                    var start = source.Offset;
                    var end = source.Count;
                    if (start is 0)
                    {
                        for (var index = 0; index < end; index++)
                        {
                            var item = array[index];
                            if (defaultComparer.Equals(selector.Invoke(item, index), value))
                                return true;
                        }
                    }
                    else
                    {
                        for (var index = 0; index < end; index++)
                        {
                            var item = array[index + start];
                            if (defaultComparer.Equals(selector.Invoke(item, index), value))
                                return true;
                        }
                    }
                }
                return false;
            }
        }


        static bool ContainsAtRef<TSource, TResult, TSelector>(this in ArraySegment<TSource> source, TResult value, TSelector selector)
            where TSelector : struct, IFunctionIn<TSource, int, TResult>
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
                    var array = source.Array!;
                    var start = source.Offset;
                    var end = source.Count;
                    if (start is 0)
                    {
                        for (var index = 0; index < end; index++)
                        {
                            var item = array[index];
                            if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(in item, index), value))
                                return true;
                        }
                    }
                    else
                    {
                        for (var index = 0; index < end; index++)
                        {
                            var item = array[index + start];
                            if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(in item, index), value))
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
                    var array = source.Array!;
                    var start = source.Offset;
                    var end = source.Count;
                    if (start is 0)
                    {
                        for (var index = 0; index < end; index++)
                        {
                            var item = array[index];
                            if (defaultComparer.Equals(selector.Invoke(in item, index), value))
                                return true;
                        }
                    }
                    else
                    {
                        for (var index = 0; index < end; index++)
                        {
                            var item = array[index + start];
                            if (defaultComparer.Equals(selector.Invoke(in item, index), value))
                                return true;
                        }
                    }
                }
                return false;
            }
        }
    }
}

