using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {

        public static bool Contains<TList, TSource>(this TList source, TSource value, IEqualityComparer<TSource>? comparer = default)
            where TList : struct, IReadOnlyList<TSource>
            => source.Contains(value, comparer, 0, source.Count);

        static bool Contains<TList, TSource>(this TList source, TSource value, IEqualityComparer<TSource>? comparer, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
        {
            if (count is 0)
                return false;

            if (comparer is null || ReferenceEquals(comparer, EqualityComparer<TSource>.Default))
            {
                if (offset is 0 && count == source.Count && source is ICollection<TSource> collection)
                    return collection.Contains(value);

                if (Utils.IsValueType<TSource>())
                    return DefaultContains(source, value, offset, count);
            }

            return ComparerContains(source, value, comparer, offset, count);

            static bool DefaultContains(TList source, TSource value, int offset, int count)
            {
                var end = offset + count;
                for (var index = offset; index < end; index++)
                {
                    var item = source[index];
                    if (EqualityComparer<TSource>.Default.Equals(item, value))
                        return true;
                }
                return false;
            }

            static bool ComparerContains(TList source, TSource value, IEqualityComparer<TSource>? comparer, int offset, int count)
            {
                comparer ??= EqualityComparer<TSource>.Default;
                var end = offset + count;
                for (var index = offset; index < end; index++)
                {
                    var item = source[index];
                    if (comparer.Equals(item, value))
                        return true;
                }
                return false;
            }
        }

        static bool Contains<TList, TSource, TResult, TSelector>(this TList source, TResult value, IEqualityComparer<TResult>? comparer, TSelector selector, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            return count switch
            {
                0 => false,
                _ => Utils.UseDefault(comparer)
                    ? ValueContains(source, value, selector, offset, count)
                    : ReferenceContains(source, value, comparer, selector, offset, count)
            };

            static bool ValueContains(TList source, TResult value, TSelector selector, int offset, int count)
            {
                var end = offset + count;
                for (var index = offset; index < end; index++)
                {
                    var item = source[index];
                    if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(item), value))
                        return true;
                }
                return false;
            }

            static bool ReferenceContains(TList source, TResult value, IEqualityComparer<TResult>? comparer, TSelector selector, int offset, int count)
            {
                comparer ??= EqualityComparer<TResult>.Default;
                var end = offset + count;
                for (var index = offset; index < end; index++)
                {
                    var item = source[index];
                    if (comparer.Equals(selector.Invoke(item), value))
                        return true;
                }
                return false;
            }
        }


        static bool ContainsAt<TList, TSource, TResult, TSelector>(this TList source, TResult value, IEqualityComparer<TResult>? comparer, TSelector selector, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            return count switch
            {
                0 => false,
                _ => Utils.UseDefault(comparer)
                    ? ValueContains(source, value, selector, offset, count)
                    : ReferenceContains(source, value, comparer, selector, offset, count)
            };

            static bool ValueContains(TList source, TResult value, TSelector selector, int offset, int count)
            {
                var end = count;
                if (offset is 0)
                {
                    for (var index = 0; index < end; index++)
                    {
                        var item = source[index];
                        if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(item, index), value))
                            return true;
                    }
                }
                else
                {
                    for (var index = 0; index < end; index++)
                    {
                        var item = source[index + offset];
                        if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(item, index), value))
                            return true;
                    }
                }
                return false;
            }

            static bool ReferenceContains(TList source, TResult value, IEqualityComparer<TResult>? comparer, TSelector selector, int offset, int count)
            {
                comparer ??= EqualityComparer<TResult>.Default;
                var end = count;
                if (offset is 0)
                {
                    for (var index = 0; index < end; index++)
                    {
                        var item = source[index];
                        if (comparer.Equals(selector.Invoke(item, index), value))
                            return true;
                    }
                }
                else
                {
                    for (var index = 0; index < end; index++)
                    {
                        var item = source[index + offset];
                        if (comparer.Equals(selector.Invoke(item, index), value))
                            return true;
                    }
                }
                return false;
            }
        }
    }
}

