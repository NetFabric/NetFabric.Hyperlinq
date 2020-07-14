using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TList, TSource>(this TList source)
            where TList : IReadOnlyList<TSource>
            => source.Count == 0
                ? new List<TSource>()
                : source switch
                    {
                        ICollection<TSource> collection => new List<TSource>(collection), // no need to allocate helper class

                        _ => new List<TSource>(new ToListCollection<TList, TSource>(source, 0, source.Count)),
                    };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToList<TList, TSource>(this TList source, int skipCount, int takeCount)
            where TList : IReadOnlyList<TSource>
            => source.Count == 0
                ? new List<TSource>()
                : new List<TSource>(new ToListCollection<TList, TSource>(source, skipCount, takeCount));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToList<TList, TSource>(this TList source, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TList : IReadOnlyList<TSource>
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, skipCount, takeCount, ArrayPool<TSource>.Shared);
            return new List<TSource>(arrayBuilder);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToList<TList, TSource>(this TList source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TList : IReadOnlyList<TSource>
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, skipCount, takeCount, ArrayPool<TSource>.Shared);
            return new List<TSource>(arrayBuilder);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TList, TSource, TResult>(this TList source, NullableSelector<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : IReadOnlyList<TSource>
            => source.Count == 0
                ? new List<TResult>()
                : new List<TResult>(new ToListCollection<TList, TSource, TResult>(source, selector, skipCount, takeCount));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TList, TSource, TResult>(this TList source, NullableSelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : IReadOnlyList<TSource>
            => source.Count == 0
                ? new List<TResult>()
                : new List<TResult>(new IndexedToListCollection<TList, TSource, TResult>(source, selector, skipCount, takeCount));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TList, TSource, TResult>(this TList source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : IReadOnlyList<TSource>
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, selector, skipCount, takeCount, ArrayPool<TResult>.Shared);
            return new List<TResult>(arrayBuilder);
        }

        // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
        [GeneratorIgnore]
        sealed class ToListCollection<TList, TSource>
            : ToListCollectionBase<TSource>
            where TList : IReadOnlyList<TSource>
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
                for (var index = 0; index < takeCount; index++)
                    array[index] = source[index + skipCount];
            }
        }

        // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
        [GeneratorIgnore]
        sealed class ToListCollection<TList, TSource, TResult>
            : ToListCollectionBase<TResult>
            where TList : IReadOnlyList<TSource>
        {
            readonly TList source;
            readonly NullableSelector<TSource, TResult> selector;
            readonly int skipCount;
            readonly int takeCount;

            public ToListCollection(in TList source, NullableSelector<TSource, TResult> selector, int skipCount, int takeCount)
                : base(takeCount)
            {
                this.source = source;
                this.selector = selector;
                this.skipCount = skipCount;
                this.takeCount = takeCount;
            }

            public override void CopyTo(TResult[] array, int arrayIndex)
                => ReadOnlyListExtensions.Copy(source, skipCount, array, arrayIndex, takeCount, selector);
        }

        // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
        [GeneratorIgnore]
        sealed class IndexedToListCollection<TList, TSource, TResult>
            : ToListCollectionBase<TResult>
            where TList : IReadOnlyList<TSource>
        {
            readonly TList source;
            readonly NullableSelectorAt<TSource, TResult> selector;
            readonly int skipCount;
            readonly int takeCount;

            public IndexedToListCollection(in TList source, NullableSelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
                : base(takeCount)
            {
                this.source = source;
                this.selector = selector;
                this.skipCount = skipCount;
                this.takeCount = takeCount;
            }

            public override void CopyTo(TResult[] array, int arrayIndex)
                => ReadOnlyListExtensions.Copy(source, skipCount, array, arrayIndex, takeCount, selector);
        }
    }
}
