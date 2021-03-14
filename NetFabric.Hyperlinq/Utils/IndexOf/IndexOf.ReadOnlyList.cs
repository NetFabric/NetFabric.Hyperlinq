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
    }
}
