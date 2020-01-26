using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        [Pure]
        internal static List<TSource> ToList<TList, TSource>(this TList source)
            where TList : notnull, IReadOnlyList<TSource>
            => source switch
            {
                ICollection<TSource> collection => new List<TSource>(collection), // no need to allocate helper class

                _ => new List<TSource>(new ToListCollection<TList, TSource>(source)),
            };

        [Pure]
        internal static List<TSource> ToList<TList, TSource>(this TList source, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
            => new List<TSource>(new IntervalToListCollection<TList, TSource>(source, skipCount, takeCount));

        [Pure]
        internal static List<TSource> ToList<TList, TSource>(this TList source, Predicate<TSource> predicate, int skipCount, int takeCount)
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
        internal static List<TSource> ToList<TList, TSource>(this TList source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
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

        // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
        [GeneratorIgnore]
        internal sealed class ToListCollection<TList, TSource>
            : ToListCollectionBase<TSource>
            where TList : notnull, IReadOnlyList<TSource>
        {
            readonly TList source;

            public ToListCollection(in TList source)
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
        internal sealed class IntervalToListCollection<TList, TSource>
            : ToListCollectionBase<TSource>
            where TList : notnull, IReadOnlyList<TSource>
        {
            readonly TList source;
            readonly int skipCount;
            readonly int takeCount;

            public IntervalToListCollection(in TList source, int skipCount, int takeCount)
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
