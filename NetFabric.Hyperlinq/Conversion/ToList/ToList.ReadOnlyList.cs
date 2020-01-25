using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        [Pure]
        internal static List<TSource> ToList<TSource>(IReadOnlyList<TSource> source)
            => source switch
            {
                ICollection<TSource> collection => new List<TSource>(collection), // no need to allocate helper class

                _ => new List<TSource>(new ToListCollection<TSource>(source)),
            };

        [Pure]
        internal static List<TSource> ToList<TSource>(IReadOnlyList<TSource> source, int skipCount, int takeCount)
            => new List<TSource>(new IntervalToListCollection<TSource>(source, skipCount, takeCount));

        [Pure]
        internal static List<TSource> ToList<TSource>(IReadOnlyList<TSource> source, Predicate<TSource> predicate, int skipCount, int takeCount)
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
        internal static List<TSource> ToList<TSource>(IReadOnlyList<TSource> source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
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

        // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
        [GeneratorIgnore]
        internal sealed class ToListCollection<TSource>
            : ToListCollectionBase<TSource>
        {
            readonly IReadOnlyList<TSource> source;

            public ToListCollection(IReadOnlyList<TSource> source)
                : base(source.Count)
                => this.source = source;

            public override void CopyTo(TSource[] array, int _)
            {
                for (var index = 0; index < source.Count; index++)
                    array[index] = source[index];
            }
        }

        // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
        [GeneratorIgnore]
        internal sealed class IntervalToListCollection<TSource>
            : ToListCollectionBase<TSource>
        {
            readonly IReadOnlyList<TSource> source;
            readonly int skipCount;
            readonly int takeCount;

            public IntervalToListCollection(IReadOnlyList<TSource> source, int skipCount, int takeCount)
                : base(takeCount)
            {
                this.source = source;
                this.skipCount = skipCount;
                this.takeCount = takeCount;
            }

            public override void CopyTo(TSource[] array, int _)
            {
                for (var index = 0; index < takeCount; index++)
                    array[index] = source[index + skipCount];
            }
        }
    }
}
