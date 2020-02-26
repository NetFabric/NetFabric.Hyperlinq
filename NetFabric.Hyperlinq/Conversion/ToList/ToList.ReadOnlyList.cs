using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        [Pure]
        public static List<TSource> ToList<TList, TSource>(this TList source)
            where TList : notnull, IReadOnlyList<TSource>
            => source switch
            {
                ICollection<TSource> collection => new List<TSource>(collection), // no need to allocate helper class

                _ => new List<TSource>(new ToListCollection<TList, TSource>(source, 0, source.Count)),
            };

        [Pure]
        static List<TSource> ToList<TList, TSource>(this TList source, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
            => new List<TSource>(new ToListCollection<TList, TSource>(source, skipCount, takeCount));

        [Pure]
        static List<TSource> ToList<TList, TSource>(this TList source, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var list = new List<TSource>();
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                var item = source[index];
                if (predicate(item))
                    list.Add(item);
            }
            return list;
        }

        [Pure]
        static List<TSource> ToList<TList, TSource>(this TList source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var list = new List<TSource>();
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                var item = source[index];
                if (predicate(item, index))
                    list.Add(item);
            }
            return list;
        }

        [Pure]
        static List<TResult> ToList<TList, TSource, TResult>(this TList source, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
            => new List<TResult>(new ToListCollection<TList, TSource, TResult>(source, selector, skipCount, takeCount));

        [Pure]
        static List<TResult> ToList<TList, TSource, TResult>(this TList source, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
            => new List<TResult>(new IndexedToListCollection<TList, TSource, TResult>(source, selector, skipCount, takeCount));

        [Pure]
        static List<TResult> ToList<TList, TSource, TResult>(this TList source, Predicate<TSource> predicate, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var list = new List<TResult>();
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                var item = source[index];
                if (predicate(item))
                    list.Add(selector(item));
            }
            return list;
        }

        // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
        [GeneratorIgnore]
        sealed class ToListCollection<TList, TSource>
            : ToListCollectionBase<TSource>
            where TList : notnull, IReadOnlyList<TSource>
        {
            readonly TList source;
            readonly int skipCount;
            readonly int takeCount;

            public ToListCollection(in TList source, int skipCount, int takeCount)
                : base(takeCount)
            {
                this.source = source;
                this.skipCount = skipCount;
                this.takeCount = takeCount;
            }

            public override void CopyTo(TSource[] array, int _)
            {
                if (skipCount == 0)
                {
                    for (var index = 0; index < takeCount; index++)
                        array[index] = source[index];
                }
                else
                {
                    for (var index = 0; index < takeCount; index++)
                        array[index] = source[index + skipCount];
                }
            }
        }

        // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
        [GeneratorIgnore]
        sealed class ToListCollection<TList, TSource, TResult>
            : ToListCollectionBase<TResult>
            where TList : notnull, IReadOnlyList<TSource>
        {
            readonly TList source;
            readonly Selector<TSource, TResult> selector;
            readonly int skipCount;
            readonly int takeCount;

            public ToListCollection(in TList source, Selector<TSource, TResult> selector, int skipCount, int takeCount)
                : base(takeCount)
            {
                this.source = source;
                this.selector = selector;
                this.skipCount = skipCount;
                this.takeCount = takeCount;
            }

            public override void CopyTo(TResult[] array, int _)
            {
                if (skipCount == 0)
                {
                    for (var index = 0; index < takeCount; index++)
                        array[index] = selector(source[index]);
                }
                else
                {
                    for (var index = 0; index < takeCount; index++)
                        array[index] = selector(source[index + skipCount]);
                }
            }
        }

        // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
        [GeneratorIgnore]
        sealed class IndexedToListCollection<TList, TSource, TResult>
            : ToListCollectionBase<TResult>
            where TList : notnull, IReadOnlyList<TSource>
        {
            readonly TList source;
            readonly SelectorAt<TSource, TResult> selector;
            readonly int skipCount;
            readonly int takeCount;

            public IndexedToListCollection(in TList source, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
                : base(takeCount)
            {
                this.source = source;
                this.selector = selector;
                this.skipCount = skipCount;
                this.takeCount = takeCount;
            }

            public override void CopyTo(TResult[] array, int _)
            {
                if (skipCount == 0)
                {
                    for (var index = 0; index < takeCount; index++)
                        array[index] = selector(source[index], index);
                }
                else
                {
                    for (var index = 0; index < takeCount; index++)
                        array[index] = selector(source[index + skipCount], index);
                }
            }
        }
    }
}
