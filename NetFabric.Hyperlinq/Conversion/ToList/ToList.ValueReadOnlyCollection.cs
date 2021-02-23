using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
// ReSharper disable HeapView.ObjectAllocation.Evident

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {

        public static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source switch
            {
                { Count: 0 } => new List<TSource>(),
                _ => source switch
                {
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    ICollection<TSource> collection => new List<TSource>(collection),

                    _ => ToArray<TEnumerable, TEnumerator, TSource>(source).AsList(),
                }
            };

        static List<TResult> ToList<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            => ToArray<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, selector).AsList();

        static List<TResult> ToListAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
            => ToArrayAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, selector).AsList();
    }
}
