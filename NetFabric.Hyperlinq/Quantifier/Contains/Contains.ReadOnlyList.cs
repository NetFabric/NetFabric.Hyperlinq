using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        public static bool Contains<TList, TSource>(this TList source, [AllowNull] TSource value)
            where TList : IReadOnlyList<TSource>
            where TSource : struct
        {
            if (source is ICollection<TSource> collection)
                return collection.Contains(value);

            for (var index = 0; index < source.Count; index++)
            {
                if (EqualityComparer<TSource>.Default.Equals(source[index], value!))
                    return true;
            }
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TList, TSource>(this TList source, [AllowNull] TSource value, IEqualityComparer<TSource>? comparer = default)
            where TList : IReadOnlyList<TSource>
            => Contains(source, value, comparer, 0, source.Count);


        static bool Contains<TList, TSource>(this TList source, [AllowNull] TSource value, IEqualityComparer<TSource>? comparer, int offset, int count)
            where TList : IReadOnlyList<TSource>
        {
            if (count == 0)
                return false;

            if (comparer is null || ReferenceEquals(comparer, EqualityComparer<TSource>.Default))
            {
                if (offset == 0 && count == source.Count && source is ICollection<TSource> collection)
                    return collection.Contains(value);

                if (Utils.IsValueType<TSource>())
                    return DefaultContains(source, value, offset, count);
            }

            comparer ??= EqualityComparer<TSource>.Default;
            return ComparerContains(source, value, comparer, offset, count);

            static bool DefaultContains(TList source, [AllowNull] TSource value, int offset, int count)
            {
                var end = offset + count;
                for (var index = offset; index < end; index++)
                {
                    if (EqualityComparer<TSource>.Default.Equals(source[index], value!))
                        return true;
                }
                return false;
            }

            static bool ComparerContains(TList source, [AllowNull] TSource value, IEqualityComparer<TSource> comparer, int offset, int count)
            {
                var end = offset + count;
                for (var index = offset; index < end; index++)
                {
                    if (comparer.Equals(source[index], value!))
                        return true;
                }
                return false;
            }
        }

        static bool Contains<TList, TSource, TResult>(this TList source, [AllowNull] TResult value, NullableSelector<TSource, TResult> selector, int offset, int count)
            where TList : IReadOnlyList<TSource>
        {
            if (count == 0)
                return false;

            return Utils.IsValueType<TResult>()
                ? ValueContains(source, value, selector, offset, count)
                : ReferenceContains(source, value, selector, offset, count);

            static bool ValueContains(TList source, [AllowNull] TResult value, NullableSelector<TSource, TResult> selector, int offset, int count)
            {
                var end = offset + count;
                for (var index = offset; index < end; index++)
                {
                    if (EqualityComparer<TResult>.Default.Equals(selector(source[index])!, value!))
                        return true;
                }
                return false;
            }

            static bool ReferenceContains(TList source, [AllowNull] TResult value, NullableSelector<TSource, TResult> selector, int offset, int count)
            {
                var defaultComparer = EqualityComparer<TResult>.Default;

                var end = offset + count;
                for (var index = offset; index < end; index++)
                {
                    if (defaultComparer.Equals(selector(source[index])!, value!))
                        return true;
                }
                return false;
            }
        }


        static bool Contains<TList, TSource, TResult>(this TList source, [AllowNull] TResult value, NullableSelectorAt<TSource, TResult> selector, int offset, int count)
            where TList : IReadOnlyList<TSource>
        {
            if (count == 0)
                return false;

            return Utils.IsValueType<TResult>()
                ? ValueContains(source, value, selector, offset, count)
                : ReferenceContains(source, value, selector, offset, count);

            static bool ValueContains(TList source, [AllowNull] TResult value, NullableSelectorAt<TSource, TResult> selector, int offset, int count)
            {
                if (offset == 0)
                {
                    for (var index = 0; index < count; index++)
                    {
                        if (EqualityComparer<TResult>.Default.Equals(selector(source[index], index)!, value!))
                            return true;
                    }
                }
                else
                {
                    for (var index = 0; index < count; index++)
                    {
                        if (EqualityComparer<TResult>.Default.Equals(selector(source[index + offset], index)!, value!))
                            return true;
                    }
                }
                return false;
            }

            static bool ReferenceContains(TList source, [AllowNull] TResult value, NullableSelectorAt<TSource, TResult> selector, int offset, int count)
            {
                var defaultComparer = EqualityComparer<TResult>.Default;

                if (offset == 0)
                {
                    for (var index = 0; index < count; index++)
                    {
                        if (defaultComparer.Equals(selector(source[index], index)!, value!))
                            return true;
                    }
                }
                else
                {
                    for (var index = 0; index < count; index++)
                    {
                        if (defaultComparer.Equals(selector(source[index + offset], index)!, value!))
                            return true;
                    }
                }
                return false;
            }
        }
    }
}

