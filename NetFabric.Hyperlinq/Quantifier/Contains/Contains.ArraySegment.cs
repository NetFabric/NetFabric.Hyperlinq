using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        public static bool Contains<TSource>(this in ArraySegment<TSource> source, [AllowNull] TSource value, IEqualityComparer<TSource>? comparer = default)
        {
            if (source.Count == 0)
                return false;

            if (comparer is null || ReferenceEquals(comparer, EqualityComparer<TSource>.Default))
            {
                if (source.Offset == 0 && source.Count == source.Array.Length)
                    return ((ICollection<TSource>)source.Array).Contains(value);

                if (Utils.IsValueType<TSource>())
                    return DefaultContains(source, value);
            }

            comparer ??= EqualityComparer<TSource>.Default;
            return ComparerContains(source, value, comparer);

            static bool DefaultContains(in ArraySegment<TSource> source, [AllowNull] TSource value)
            {
                var array = source.Array;
                if (source.Offset == 0 && source.Count == array.Length)
                {
                    for (var index = 0; index < array.Length; index++)
                    {
                        if (EqualityComparer<TSource>.Default.Equals(array[index], value))
                            return true;
                    }
                }
                else
                {
                    var end = source.Offset + source.Count;
                    for (var index = source.Offset; index < end; index++)
                    {
                        if (EqualityComparer<TSource>.Default.Equals(array[index], value))
                            return true;
                    }
                }
                return false;
            }

            static bool ComparerContains(in ArraySegment<TSource> source, [AllowNull] TSource value, IEqualityComparer<TSource> comparer)
            {
                var array = source.Array;
                if (source.Offset == 0 && source.Count == array.Length)
                {
                    for (var index = 0; index < array.Length; index++)
                    {
                        if (comparer.Equals(array[index], value))
                            return true;
                    }
                }
                else
                {
                    var end = source.Offset + source.Count;
                    for (var index = source.Offset; index < end; index++)
                    {
                        if (comparer.Equals(array[index], value))
                            return true;
                    }
                }
                return false;
            }
        }

        static bool Contains<TSource, TResult>(this in ArraySegment<TSource> source, [AllowNull] TResult value, NullableSelector<TSource, TResult> selector)
        {
            if (source.Count == 0)
                return false;

            return Utils.IsValueType<TResult>()
                ? ValueContains(source, value, selector)
                : ReferenceContains(source, value, selector);

            static bool ValueContains(in ArraySegment<TSource> source, [AllowNull] TResult value, NullableSelector<TSource, TResult> selector)
            {
                var array = source.Array;
                if (source.Offset == 0 && source.Count == array.Length)
                {
                    for (var index = 0; index < array.Length; index++)
                    {
                        if (EqualityComparer<TResult>.Default.Equals(selector(array[index])!, value!))
                            return true;
                    }
                }
                else
                {
                    var end = source.Offset + source.Count;
                    for (var index = source.Offset; index < end; index++)
                    {
                        if (EqualityComparer<TResult>.Default.Equals(selector(array[index])!, value!))
                            return true;
                    }
                }
                return false;
            }

            static bool ReferenceContains(in ArraySegment<TSource> source, [AllowNull] TResult value, NullableSelector<TSource, TResult> selector)
            {
                var array = source.Array;
                var defaultComparer = EqualityComparer<TResult>.Default;

                if (source.Offset == 0 && source.Count == array.Length)
                {
                    for (var index = 0; index < array.Length; index++)
                    {
                        if (defaultComparer.Equals(selector(array[index])!, value!))
                            return true;
                    }
                }
                else
                {
                    var end = source.Offset + source.Count;
                    for (var index = source.Offset; index < end; index++)
                    {
                        if (defaultComparer.Equals(selector(array[index])!, value!))
                            return true;
                    }
                }
                return false;
            }
        }


        static bool Contains<TSource, TResult>(this in ArraySegment<TSource> source, [AllowNull] TResult value, NullableSelectorAt<TSource, TResult> selector)
        {
            if (source.Count == 0)
                return false;

            return Utils.IsValueType<TResult>()
                ? ValueContains(source, value, selector)
                : ReferenceContains(source, value, selector);

            static bool ValueContains(in ArraySegment<TSource> source, [AllowNull] TResult value, NullableSelectorAt<TSource, TResult> selector)
            {
                var array = source.Array;
                if (source.Offset == 0)
                {
                    if (source.Count == array.Length)
                    {
                        for (var index = 0; index < array.Length; index++)
                        {
                            if (EqualityComparer<TResult>.Default.Equals(selector(array[index], index)!, value!))
                                return true;
                        }
                    }
                    else
                    {
                        for (var index = 0; index < source.Count; index++)
                        {
                            if (EqualityComparer<TResult>.Default.Equals(selector(array[index], index)!, value!))
                                return true;
                        }
                    }
                }
                else
                {
                    var offset = source.Offset;
                    for (var index = 0; index < source.Count; index++)
                    {
                        if (EqualityComparer<TResult>.Default.Equals(selector(array[index + offset], index)!, value!))
                            return true;
                    }
                }
                return false;
            }

            static bool ReferenceContains(in ArraySegment<TSource> source, [AllowNull] TResult value, NullableSelectorAt<TSource, TResult> selector)
            {
                var array = source.Array;
                var defaultComparer = EqualityComparer<TResult>.Default;

                if (source.Offset == 0)
                {
                    if (source.Count == array.Length)
                    {
                        for (var index = 0; index < array.Length; index++)
                        {
                            if (defaultComparer.Equals(selector(array[index], index)!, value!))
                                return true;
                        }
                    }
                    else
                    {
                        for (var index = 0; index < source.Count; index++)
                        {
                            if (defaultComparer.Equals(selector(array[index], index)!, value!))
                                return true;
                        }
                    }
                }
                else
                {
                    var offset = source.Offset;
                    for (var index = 0; index < source.Count; index++)
                    {
                        if (defaultComparer.Equals(selector(array[index + offset], index)!, value!))
                            return true;
                    }
                }
                return false;
            }
        }
    }
}

