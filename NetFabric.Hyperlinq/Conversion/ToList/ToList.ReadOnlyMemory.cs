using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TSource>(this ReadOnlyMemory<TSource> source)
            => new List<TSource>(new ReadOnlyMemoryToListCollection<TSource>(source));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToList<TSource, TPredicate>(this ReadOnlyMemory<TSource> source, TPredicate predicate)
            where TPredicate : struct, IPredicate<TSource>
        {
            using var arrayBuilder = ToArrayBuilder(source.Span, predicate, ArrayPool<TSource>.Shared);
            return new List<TSource>(arrayBuilder);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToListAt<TSource, TPredicate>(this ReadOnlyMemory<TSource> source, TPredicate predicate)
            where TPredicate : struct, IPredicateAt<TSource>
        {
            using var arrayBuilder = ToArrayBuilderAt(source.Span, predicate, ArrayPool<TSource>.Shared);
            return new List<TSource>(arrayBuilder);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TSource, TResult>(this ReadOnlyMemory<TSource> source, NullableSelector<TSource, TResult> selector)
            => new List<TResult>(new ReadOnlyMemorySelectorToListCollection<TSource, TResult>(source, selector));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TSource, TResult>(this ReadOnlyMemory<TSource> source, NullableSelectorAt<TSource, TResult> selector)
            => new List<TResult>(new ReadOnlyMemorySelectorAtToListCollection<TSource, TResult>(source, selector));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TSource, TResult, TPredicate>(this ReadOnlyMemory<TSource> source, TPredicate predicate, NullableSelector<TSource, TResult> selector)
            where TPredicate : struct, IPredicate<TSource>
        {
            using var arrayBuilder = ToArrayBuilder(source.Span, predicate, selector, ArrayPool<TResult>.Shared);
            return new List<TResult>(arrayBuilder);
        }

        sealed class ReadOnlyMemoryToListCollection<TSource>
            : ToListCollectionBase<TSource>
        {
            readonly ReadOnlyMemory<TSource> source;

            public ReadOnlyMemoryToListCollection(ReadOnlyMemory<TSource> source)
                : base(source.Length)
                => this.source = source;

            public override void CopyTo(TSource[] array, int _)
                => ArrayExtensions.Copy(source.Span, array);
        }

        sealed class ReadOnlyMemorySelectorToListCollection<TSource, TResult>
            : ToListCollectionBase<TResult>
        {
            readonly ReadOnlyMemory<TSource> source;
            readonly NullableSelector<TSource, TResult> selector;

            public ReadOnlyMemorySelectorToListCollection(ReadOnlyMemory<TSource> source, NullableSelector<TSource, TResult> selector)
                : base(source.Length)
                => (this.source, this.selector) = (source, selector);

            public override void CopyTo(TResult[] array, int _)
                => ArrayExtensions.Copy(source.Span, array, selector);
        }

        sealed class ReadOnlyMemorySelectorAtToListCollection<TSource, TResult>
            : ToListCollectionBase<TResult>
        {
            readonly ReadOnlyMemory<TSource> source;
            readonly NullableSelectorAt<TSource, TResult> selector;

            public ReadOnlyMemorySelectorAtToListCollection(ReadOnlyMemory<TSource> source, NullableSelectorAt<TSource, TResult> selector)
                : base(source.Length)
                => (this.source, this.selector) = (source, selector);

            public override void CopyTo(TResult[] array, int _)
                => ArrayExtensions.Copy(source.Span, array, selector);
        }
    }
}