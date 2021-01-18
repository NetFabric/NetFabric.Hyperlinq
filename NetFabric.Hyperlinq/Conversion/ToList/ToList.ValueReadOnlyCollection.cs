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
            => source.Count switch
            {
                0 => new List<TSource>(),
                _ => source switch
                {
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    ICollection<TSource> collection => new List<TSource>(collection),

                    _ => new List<TSource>(collection: new ValueReadOnlyCollectionToListCollection<TEnumerable, TEnumerator, TSource>(source)),
                }
            };

        static List<TResult> ToList<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Count switch
            {
                0 => new List<TResult>(),
                _ => new List<TResult>(collection: new ValueReadOnlyCollectionSelectorToListCollection<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, selector))
            };

        static List<TResult> ToListAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
            => source.Count switch
            {
                0 => new List<TResult>(),
                _ => new List<TResult>(collection: new ValueReadOnlyCollectionSelectorAtToListCollection<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, selector))
            };

        // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
        [GeneratorIgnore]
        internal sealed class ValueReadOnlyCollectionToListCollection<TEnumerable, TEnumerator, TSource>
            : ToListCollectionBase<TSource>
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;

            public ValueReadOnlyCollectionToListCollection(TEnumerable source)
                : base(source.Count) 
                => this.source = source;

            public override void CopyTo(TSource[] array, int _)
            {
                using var enumerator = source.GetEnumerator();
                checked
                {
                    for (var index = 0; enumerator.MoveNext(); index++)
                        array[index] = enumerator.Current;
                }
            }
        }

        [GeneratorIgnore]
        internal sealed class ValueReadOnlyCollectionSelectorToListCollection<TEnumerable, TEnumerator, TSource, TResult, TSelector>
            : ToListCollectionBase<TResult>
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            readonly TEnumerable source;
            readonly TSelector selector;

            public ValueReadOnlyCollectionSelectorToListCollection(TEnumerable source, TSelector selector)
                : base(source.Count)
                => (this.source, this.selector) = (source, selector);

            public override void CopyTo(TResult[] array, int _)
                => Copy<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, array, selector);
        }

        [GeneratorIgnore]
        internal sealed class ValueReadOnlyCollectionSelectorAtToListCollection<TEnumerable, TEnumerator, TSource, TResult, TSelector>
            : ToListCollectionBase<TResult>
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            readonly TEnumerable source;
            readonly TSelector selector;

            public ValueReadOnlyCollectionSelectorAtToListCollection(TEnumerable source, TSelector selector)
                : base(source.Count)
                => (this.source, this.selector) = (source, selector);

            public override void CopyTo(TResult[] array, int _)
                => CopyAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, array, selector);
        }
    }
}
