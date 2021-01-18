using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        public static bool Contains<TList, TSource>(this TList source, TSource value)
            where TList : IReadOnlyList<TSource>
        {
            if (source is ICollection<TSource> collection)
                return collection.Contains(value);

            var end = source.Count - 1;
            for (var index = 0; index <= end; index++)
            {
                if (EqualityComparer<TSource>.Default.Equals(source[index], value))
                    return true;
            }
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TList, TSource>(this TList source, TSource value, IEqualityComparer<TSource>? comparer = default)
            where TList : IReadOnlyList<TSource>
            => source.Contains(value, comparer, 0, source.Count);


        static bool Contains<TList, TSource>(this TList source, TSource value, IEqualityComparer<TSource>? comparer, int offset, int count)
            where TList : IReadOnlyList<TSource>
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

            comparer ??= EqualityComparer<TSource>.Default;
            return ComparerContains(source, value, comparer, offset, count);

            static bool DefaultContains(TList source, TSource value, int offset, int count)
            {
                var end = offset + count - 1;
                for (var index = offset; index <= end; index++)
                {
                    if (EqualityComparer<TSource>.Default.Equals(source[index], value))
                        return true;
                }
                return false;
            }

            static bool ComparerContains(TList source, TSource value, IEqualityComparer<TSource> comparer, int offset, int count)
            {
                var end = offset + count - 1;
                for (var index = offset; index <= end; index++)
                {
                    if (comparer.Equals(source[index], value))
                        return true;
                }
                return false;
            }
        }

        static bool Contains<TList, TSource, TResult, TSelector>(this TList source, TResult value, TSelector selector, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            if (count is 0)
                return false;

            return Utils.IsValueType<TResult>()
                ? ValueContains(source, value, selector, offset, count)
                : ReferenceContains(source, value, selector, offset, count);

            static bool ValueContains(TList source, TResult value, TSelector selector, int offset, int count)
            {
                var end = offset + count - 1;
                for (var index = offset; index <= end; index++)
                {
                    if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(source[index]), value))
                        return true;
                }
                return false;
            }

            static bool ReferenceContains(TList source, TResult value, TSelector selector, int offset, int count)
            {
                var defaultComparer = EqualityComparer<TResult>.Default;

                var end = offset + count - 1;
                for (var index = offset; index <= end; index++)
                {
                    if (defaultComparer.Equals(selector.Invoke(source[index]), value))
                        return true;
                }
                return false;
            }
        }


        static bool ContainsAt<TList, TSource, TResult, TSelector>(this TList source, TResult value, TSelector selector, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            if (count is 0)
                return false;

            return Utils.IsValueType<TResult>()
                ? ValueContains(source, value, selector, offset, count)
                : ReferenceContains(source, value, selector, offset, count);

            static bool ValueContains(TList source, TResult value, TSelector selector, int offset, int count)
            {
                var end = count - 1;
                if (offset is 0)
                {
                    for (var index = 0; index <= end; index++)
                    {
                        if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(source[index], index), value))
                            return true;
                    }
                }
                else
                {
                    for (var index = 0; index <= end; index++)
                    {
                        if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(source[index + offset], index), value))
                            return true;
                    }
                }
                return false;
            }

            static bool ReferenceContains(TList source, TResult value, TSelector selector, int offset, int count)
            {
                var defaultComparer = EqualityComparer<TResult>.Default;

                var end = count - 1;
                if (offset is 0)
                {
                    for (var index = 0; index <= end; index++)
                    {
                        if (defaultComparer.Equals(selector.Invoke(source[index], index), value))
                            return true;
                    }
                }
                else
                {
                    for (var index = 0; index <= end; index++)
                    {
                        if (defaultComparer.Equals(selector.Invoke(source[index + offset], index), value))
                            return true;
                    }
                }
                return false;
            }
        }
    }
}

