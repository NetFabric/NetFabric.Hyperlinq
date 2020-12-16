using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// ReSharper disable HeapView.ObjectAllocation.Evident

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TSource>(this ReadOnlyMemory<TSource> source)
            => new(collection: new ReadOnlyMemoryToListCollection<TSource>(source));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToList<TSource, TPredicate>(this ReadOnlyMemory<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, bool>
        {
            using var arrayBuilder = ToArrayBuilder(source.Span, predicate, ArrayPool<TSource>.Shared);
            // ReSharper disable once HeapView.BoxingAllocation
            return new List<TSource>(collection: arrayBuilder);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToListAt<TSource, TPredicate>(this ReadOnlyMemory<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            using var arrayBuilder = ToArrayBuilderAt(source.Span, predicate, ArrayPool<TSource>.Shared);
            // ReSharper disable once HeapView.BoxingAllocation
            return new List<TSource>(collection: arrayBuilder);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TSource, TResult, TSelector>(this ReadOnlyMemory<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
            => new(collection: new ReadOnlyMemorySelectorToListCollection<TSource, TResult, TSelector>(source, selector));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToListAt<TSource, TResult, TSelector>(this ReadOnlyMemory<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
            => new(collection: new ReadOnlyMemorySelectorAtToListCollection<TSource, TResult, TSelector>(source, selector));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TSource, TResult, TPredicate, TSelector>(this ReadOnlyMemory<TSource> source, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            using var arrayBuilder = ToArrayBuilder(source.Span, predicate, selector, ArrayPool<TResult>.Shared);
            // ReSharper disable once HeapView.BoxingAllocation
            return new List<TResult>(collection: arrayBuilder);
        }

        sealed class ReadOnlyMemoryToListCollection<TSource>
            : ToListCollectionBase<TSource>
        {
            readonly ReadOnlyMemory<TSource> source;

            public ReadOnlyMemoryToListCollection(ReadOnlyMemory<TSource> source)
                : base(source.Length)
                => this.source = source;

            public override void CopyTo(TSource[] array, int _)
                => Copy(source.Span, array);
        }

        sealed class ReadOnlyMemorySelectorToListCollection<TSource, TResult, TSelector>
            : ToListCollectionBase<TResult>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            readonly ReadOnlyMemory<TSource> source;
            readonly TSelector selector;

            public ReadOnlyMemorySelectorToListCollection(ReadOnlyMemory<TSource> source, TSelector selector)
                : base(source.Length)
                => (this.source, this.selector) = (source, selector);

            public override void CopyTo(TResult[] array, int _)
                => Copy<TSource, TResult, TSelector>(source.Span, array, selector);
        }

        sealed class ReadOnlyMemorySelectorAtToListCollection<TSource, TResult, TSelector>
            : ToListCollectionBase<TResult>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            readonly ReadOnlyMemory<TSource> source;
            readonly TSelector selector;

            public ReadOnlyMemorySelectorAtToListCollection(ReadOnlyMemory<TSource> source, TSelector selector)
                : base(source.Length)
                => (this.source, this.selector) = (source, selector);

            public override void CopyTo(TResult[] array, int _)
                => CopyAt<TSource, TResult, TSelector>(source.Span, array, selector);
        }
    }
}