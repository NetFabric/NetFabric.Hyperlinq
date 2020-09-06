using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TSource>(this in ArraySegment<TSource> source)
            => new List<TSource>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToList<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate : struct, IPredicate<TSource>
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, ArrayPool<TSource>.Shared);
            return new List<TSource>(arrayBuilder);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToListAt<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate : struct, IPredicateAt<TSource>
        {
            using var arrayBuilder = ToArrayBuilderAt(source, predicate, ArrayPool<TSource>.Shared);
            return new List<TSource>(arrayBuilder);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TSource, TResult>(this in ArraySegment<TSource> source, NullableSelector<TSource, TResult> selector)
            => source.Count == 0
                ? new List<TResult>()
                : new List<TResult>(new ArraySegmentSelectorToListCollection<TSource, TResult>(source, selector));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TSource, TResult>(this in ArraySegment<TSource> source, NullableSelectorAt<TSource, TResult> selector)
            => source.Count == 0
                ? new List<TResult>()
                : new List<TResult>(new ArraySegmentSelectorAtToListCollection<TSource, TResult>(source, selector));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TSource, TResult, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate, NullableSelector<TSource, TResult> selector)
            where TPredicate : struct, IPredicate<TSource>
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, selector, ArrayPool<TResult>.Shared);
            return new List<TResult>(arrayBuilder);
        }

        // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
        [GeneratorIgnore]
        sealed class ArraySegmentSelectorToListCollection<TSource, TResult>
            : ToListCollectionBase<TResult>
        {
            readonly ArraySegment<TSource> source;
            readonly NullableSelector<TSource, TResult> selector;

            public ArraySegmentSelectorToListCollection(in ArraySegment<TSource> source, NullableSelector<TSource, TResult> selector)
                : base(source.Count)
                => (this.source, this.selector) = (source, selector);

            public override void CopyTo(TResult[] array, int _)
                => ArrayExtensions.Copy<TSource, TResult>(source, array, selector);
        }

        [GeneratorIgnore]
        sealed class ArraySegmentSelectorAtToListCollection<TSource, TResult>
            : ToListCollectionBase<TResult>
        {
            readonly ArraySegment<TSource> source;
            readonly NullableSelectorAt<TSource, TResult> selector;

            public ArraySegmentSelectorAtToListCollection(in ArraySegment<TSource> source, NullableSelectorAt<TSource, TResult> selector)
                : base(source.Count)
                => (this.source, this.selector) = (source, selector);

            public override void CopyTo(TResult[] array, int _)
                => ArrayExtensions.Copy<TSource, TResult>(source, array, selector);
        }
    }
}