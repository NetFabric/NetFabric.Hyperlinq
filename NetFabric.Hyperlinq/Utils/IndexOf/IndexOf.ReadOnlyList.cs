using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static partial class ReadOnlyListExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int IndexOf<TList, TSource>(TList source, TSource item, int offset, int count)
            where TList : IReadOnlyList<TSource>
        {
            if (count is 0)
                return -1;

            // ReSharper disable once HeapView.PossibleBoxingAllocation
            if (offset is 0 && count == source.Count && source is IList<TSource> list)
                return list.IndexOf(item);

            var end = offset + count;
            if (Utils.IsValueType<TSource>())
            {
                for (var index = offset; index < end; index++)
                {
                    var arrayItem = source[index];
                    if (EqualityComparer<TSource>.Default.Equals(arrayItem, item))
                        return index - offset;
                }
            }
            else
            {
                var defaultComparer = EqualityComparer<TSource>.Default;
                for (var index = offset; index < end; index++)
                {
                    var arrayItem = source[index];
                    if (defaultComparer.Equals(arrayItem, item))
                        return index - offset;
                }
            }

            return -1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int IndexOf<TList, TSource, TResult, TSelector>(TList source, TResult item, TSelector selector, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            if (count is 0)
                return -1;

            var end = offset + count;
            if (Utils.IsValueType<TSource>())
            {
                for (var index = offset; index < end; index++)
                {
                    var arrayItem = source[index];
                    if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(arrayItem), item))
                        return index - offset;
                }
            }
            else
            {
                var defaultComparer = EqualityComparer<TResult>.Default;
                for (var index = offset; index < end; index++)
                {
                    var arrayItem = source[index];
                    if (defaultComparer.Equals(selector.Invoke(arrayItem), item))
                        return index - offset;
                }
            }

            return -1;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int IndexOfAt<TList, TSource, TResult, TSelector>(TList source, TResult item, TSelector selector, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            if (count is 0)
                return -1;

            if (Utils.IsValueType<TResult>())
            {
                if (offset is 0)
                {
                    for (var index = 0; index < count; index++)
                    {
                        var listItem = source[index];
                        if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(listItem, index), item))
                            return index;
                    }
                }
                else
                {
                    for (var index = 0; index < count; index++)
                    {
                        var listItem = source[index + offset];
                        if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(listItem, index), item))
                            return index;
                    }
                }
            }
            else
            {
                var defaultComparer = EqualityComparer<TResult>.Default;

                if (offset is 0)
                {
                    for (var index = 0; index < count; index++)
                    {
                        var listItem = source[index];
                        if (defaultComparer.Equals(selector.Invoke(listItem, index), item))
                            return index;
                    }
                }
                else
                {
                    for (var index = 0; index < count; index++)
                    {
                        var listItem = source[index + offset];
                        if (defaultComparer.Equals(selector.Invoke(listItem, index), item))
                            return index;
                    }
                }
            }
            return -1;
        }
    }
}
