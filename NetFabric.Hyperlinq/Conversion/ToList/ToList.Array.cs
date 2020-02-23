using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        public static List<TSource> ToList<TSource>(this TSource[] source)
            => new List<TSource>(new ToListCollection<TSource>(source, 0, source.Length));

        [Pure]
        static List<TSource> ToList<TSource>(this TSource[] source, int skipCount, int takeCount)
            => new List<TSource>(new ToListCollection<TSource>(source, skipCount, takeCount));

        [Pure]
        static List<TSource> ToList<TSource>(this TSource[] source, Predicate<TSource> predicate, int skipCount, int takeCount)
        {
            var list = new List<TSource>();
            if (skipCount == 0 && takeCount == source.Length)
            {
                for (var index = 0; index < source.Length; index++)
                {
                    var item = source[index];
                    if (predicate(item))
                        list.Add(item);
                }
            }
            else
            {
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    var item = source[index];
                    if (predicate(item))
                        list.Add(item);
                }
            }
            return list;
        }

        [Pure]
        static List<TSource> ToList<TSource>(this TSource[] source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
        {
            var list = new List<TSource>();
            if (skipCount == 0 && takeCount == source.Length)
            {
                for (var index = 0; index < source.Length; index++)
                {
                    var item = source[index];
                    if (predicate(item, index))
                        list.Add(item);
                }
            }
            else
            {
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    var item = source[index];
                    if (predicate(item, index))
                        list.Add(item);
                }
            }
            return list;
        }

        [Pure]
        static List<TResult> ToList<TSource, TResult>(this TSource[] source, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            => new List<TResult>(new ToListCollection<TSource, TResult>(source, selector, skipCount, takeCount));

        [Pure]
        static List<TResult> ToList<TSource, TResult>(this TSource[] source, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
            => new List<TResult>(new IndexedToListCollection<TSource, TResult>(source, selector, skipCount, takeCount));

        [Pure]
        static List<TResult> ToList<TSource, TResult>(this TSource[] source, Predicate<TSource> predicate, Selector<TSource, TResult> selector, int skipCount, int takeCount)
        {
            var list = new List<TResult>();
            if (skipCount == 0 && takeCount == source.Length)
            {
                for (var index = 0; index < source.Length; index++)
                {
                    var item = source[index];
                    if (predicate(item))
                        list.Add(selector(item));
                }
            }
            else
            {
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    var item = source[index];
                    if (predicate(item))
                        list.Add(selector(item));
                }
            }
            return list;
        }

        [GeneratorIgnore]
        sealed class ToListCollection<TSource>
            : ToListCollectionBase<TSource>
        {
            readonly TSource[] source;
            readonly int skipCount;
            readonly int takeCount;

            public ToListCollection(TSource[] source, int skipCount, int takeCount)
                : base(takeCount)
            {
                this.source = source;
                this.skipCount = skipCount;
                this.takeCount = takeCount;
            }

            public override void CopyTo(TSource[] array, int _)
            {
                System.Array.Copy(source, skipCount, array, 0, takeCount);
            }
        }

        [GeneratorIgnore]
        sealed class ToListCollection<TSource, TResult>
            : ToListCollectionBase<TResult>
        {
            readonly TSource[] source;
            readonly Selector<TSource, TResult> selector;
            readonly int skipCount;
            readonly int takeCount;

            public ToListCollection(TSource[] source, Selector<TSource, TResult> selector, int skipCount, int takeCount)
                : base(takeCount)
            {
                this.source = source;
                this.selector = selector;
                this.skipCount = skipCount;
                this.takeCount = takeCount;
            }

            public override void CopyTo(TResult[] array, int _)
            {
                if (skipCount == 0 && takeCount == source.Length)
                {
                    for (var index = 0; index < source.Length; index++)
                        array[index] = selector(source[index]);
                }
                else
                {
                    for (var index = 0; index < takeCount; index++)
                        array[index] = selector(source[index + skipCount]);
                }
            }
        }

        [GeneratorIgnore]
        sealed class IndexedToListCollection<TSource, TResult>
            : ToListCollectionBase<TResult>
        {
            readonly TSource[] source;
            readonly SelectorAt<TSource, TResult> selector;
            readonly int skipCount;
            readonly int takeCount;

            public IndexedToListCollection(TSource[] source, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
                : base(takeCount)
            {
                this.source = source;
                this.selector = selector;
                this.skipCount = skipCount;
                this.takeCount = takeCount;
            }

            public override void CopyTo(TResult[] array, int _)
            {
                if (skipCount == 0 && takeCount == source.Length)
                {
                    for (var index = 0; index < source.Length; index++)
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
