using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TList, TSource>(this TList source, [AllowNull] TSource value, IEqualityComparer<TSource>? comparer = default)
            where TList : notnull, IReadOnlyList<TSource>
            => ReadOnlyListExtensions.Contains<TList, TSource>(source, value, comparer, 0, source.Count);


        static bool Contains<TList, TSource>(this TList source, [AllowNull] TSource value, IEqualityComparer<TSource>? comparer, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (takeCount == 0)
                return false;

            if (comparer is null && source is ICollection<TSource> collection)
                return collection.Contains(value!);

            if (Utils.UseDefault(comparer))
                return DefaultContains(source, value, skipCount, takeCount);

            comparer ??= EqualityComparer<TSource>.Default;
            return ComparerContains(source, value, comparer, skipCount, takeCount);

            static bool DefaultContains(TList source, [AllowNull] TSource value, int skipCount, int takeCount)
            {
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    if (EqualityComparer<TSource>.Default.Equals(source[index], value!))
                        return true;
                }
                return false;
            }

            static bool ComparerContains(TList source, [AllowNull] TSource value, IEqualityComparer<TSource> comparer, int skipCount, int takeCount)
            {
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    if (comparer.Equals(source[index], value!))
                        return true;
                }
                return false;
            }
        }

        static bool Contains<TList, TSource, TResult>(this TList source, [AllowNull] TResult value, NullableSelector<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (takeCount == 0)
                return false;

            return default(TResult) is object
                ? ValueContains(source, value, selector, skipCount, takeCount)
                : ReferenceContains(source, value, selector, skipCount, takeCount);

            static bool ValueContains(TList source, [AllowNull] TResult value, NullableSelector<TSource, TResult> selector, int skipCount, int takeCount)
            {
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    if (EqualityComparer<TResult>.Default.Equals(selector(source[index])!, value!))
                        return true;
                }
                return false;
            }

            static bool ReferenceContains(TList source, [AllowNull] TResult value, NullableSelector<TSource, TResult> selector, int skipCount, int takeCount)
            {
                var defaultComparer = EqualityComparer<TResult>.Default;

                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    if (defaultComparer.Equals(selector(source[index])!, value!))
                        return true;
                }
                return false;
            }
        }


        static bool Contains<TList, TSource, TResult>(this TList source, [AllowNull] TResult value, NullableSelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (takeCount == 0)
                return false;

            return default(TResult) is object
                ? ValueContains(source, value, selector, skipCount, takeCount)
                : ReferenceContains(source, value, selector, skipCount, takeCount);

            static bool ValueContains(TList source, [AllowNull] TResult value, NullableSelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
            {
                if (skipCount == 0)
                {
                    for (var index = 0; index < takeCount; index++)
                    {
                        if (EqualityComparer<TResult>.Default.Equals(selector(source[index], index)!, value!))
                            return true;
                    }
                }
                else
                {
                    for (var index = 0; index < takeCount; index++)
                    {
                        if (EqualityComparer<TResult>.Default.Equals(selector(source[index + skipCount], index)!, value!))
                            return true;
                    }
                }
                return false;
            }

            static bool ReferenceContains(TList source, [AllowNull] TResult value, NullableSelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
            {
                var defaultComparer = EqualityComparer<TResult>.Default;

                if (skipCount == 0)
                {
                    for (var index = 0; index < takeCount; index++)
                    {
                        if (defaultComparer.Equals(selector(source[index], index)!, value!))
                            return true;
                    }
                }
                else
                {
                    for (var index = 0; index < takeCount; index++)
                    {
                        if (defaultComparer.Equals(selector(source[index + skipCount], index)!, value!))
                            return true;
                    }
                }
                return false;
            }
        }
    }
}

