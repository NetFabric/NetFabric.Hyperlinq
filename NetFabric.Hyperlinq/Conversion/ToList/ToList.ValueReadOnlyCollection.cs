using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {
        
        public static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source switch
            {
                ICollection<TSource> collection => new List<TSource>(collection), // no need to allocate helper class

                _ => source.Count == 0
                    ? new List<TSource>()
                    : new List<TSource>(new ValueReadOnlyCollectionToListCollection<TEnumerable, TEnumerator, TSource>(source)),
            };

        
        public static List<TResult> ToList<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, NullableSelector<TSource, TResult> selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source.Count == 0
                ? new List<TResult>()
                : new List<TResult>(new ValueReadOnlyCollectionSelectorToListCollection<TEnumerable, TEnumerator, TSource, TResult>(source, selector));

        
        public static List<TResult> ToList<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, NullableSelectorAt<TSource, TResult> selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source.Count == 0
                ? new List<TResult>()
                : new List<TResult>(new ValueReadOnlyCollectionSelectorAtToListCollection<TEnumerable, TEnumerator, TSource, TResult>(source, selector));

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
        internal sealed class ValueReadOnlyCollectionSelectorToListCollection<TEnumerable, TEnumerator, TSource, TResult>
            : ToListCollectionBase<TResult>
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly NullableSelector<TSource, TResult> selector;

            public ValueReadOnlyCollectionSelectorToListCollection(TEnumerable source, NullableSelector<TSource, TResult> selector)
                : base(source.Count)
                => (this.source, this.selector) = (source, selector);

            public override void CopyTo(TResult[] array, int _)
                => ValueReadOnlyCollectionExtensions.Copy<TEnumerable, TEnumerator, TSource, TResult>(source, array, selector);
        }

        [GeneratorIgnore]
        internal sealed class ValueReadOnlyCollectionSelectorAtToListCollection<TEnumerable, TEnumerator, TSource, TResult>
            : ToListCollectionBase<TResult>
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly NullableSelectorAt<TSource, TResult> selector;

            public ValueReadOnlyCollectionSelectorAtToListCollection(TEnumerable source, NullableSelectorAt<TSource, TResult> selector)
                : base(source.Count)
                => (this.source, this.selector) = (source, selector);

            public override void CopyTo(TResult[] array, int _)
                => ValueReadOnlyCollectionExtensions.Copy<TEnumerable, TEnumerator, TSource, TResult>(source, array, selector);
        }
    }
}
