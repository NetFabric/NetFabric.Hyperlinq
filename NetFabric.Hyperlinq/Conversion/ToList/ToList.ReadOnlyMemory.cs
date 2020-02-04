using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TSource>(this ReadOnlyMemory<TSource> source)
            => new List<TSource>(new MemoryToListCollection<TSource>(source));

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToList<TSource>(this ReadOnlyMemory<TSource> source, Predicate<TSource> predicate)
            => ToList(source.Span, predicate);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToList<TSource>(this ReadOnlyMemory<TSource> source, PredicateAt<TSource> predicate)
            => ToList(source.Span, predicate);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TSource, TResult>(this ReadOnlyMemory<TSource> source, Selector<TSource, TResult> selector)
            => new List<TResult>(new MemoryToListCollection<TSource, TResult>(source, selector));

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TSource, TResult>(this ReadOnlyMemory<TSource> source, SelectorAt<TSource, TResult> selector)
            => new List<TResult>(new IndexedMemoryToListCollection<TSource, TResult>(source, selector));

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TSource, TResult>(this ReadOnlyMemory<TSource> source, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
            => ToList(source.Span, predicate, selector);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TSource, TResult>(this ReadOnlyMemory<TSource> source, PredicateAt<TSource> predicate, SelectorAt<TSource, TResult> selector)
            => ToList(source.Span, predicate, selector);

        [GeneratorIgnore]
        sealed class MemoryToListCollection<TSource>
            : ToListCollectionBase<TSource>
        {
            readonly ReadOnlyMemory<TSource> source;

            public MemoryToListCollection(ReadOnlyMemory<TSource> source)
                : base(source.Length)
                => this.source = source;

            public override void CopyTo(TSource[] array, int _)
                => source.CopyTo(array);
        }

        [GeneratorIgnore]
        sealed class MemoryToListCollection<TSource, TResult>
            : ToListCollectionBase<TResult>
        {
            readonly ReadOnlyMemory<TSource> source;
            readonly Selector<TSource, TResult> selector;

            public MemoryToListCollection(ReadOnlyMemory<TSource> source, Selector<TSource, TResult> selector)
                : base(source.Length)
            {
                this.source = source;
                this.selector = selector;
            }

            public override void CopyTo(TResult[] array, int _)
            {
                var span = source.Span;
                for (var index = 0; index < source.Length; index++)
                    array[index] = selector(span[index]);
            }
        }

        [GeneratorIgnore]
        sealed class IndexedMemoryToListCollection<TSource, TResult>
            : ToListCollectionBase<TResult>
        {
            readonly ReadOnlyMemory<TSource> source;
            readonly SelectorAt<TSource, TResult> selector;

            public IndexedMemoryToListCollection(ReadOnlyMemory<TSource> source, SelectorAt<TSource, TResult> selector)
                : base(source.Length)
            {
                this.source = source;
                this.selector = selector;
            }

            public override void CopyTo(TResult[] array, int _)
            {
                var span = source.Span;
                for (var index = 0; index < source.Length; index++)
                    array[index] = selector(span[index], index);
            }
        }
    }
}
