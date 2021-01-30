using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
// ReSharper disable HeapView.ObjectAllocation.Evident

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TSource>(this in ArraySegment<TSource> source)
            // ReSharper disable once HeapView.BoxingAllocation
            => new(collection: source);

        static List<TSource> ToList<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, bool>
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, ArrayPool<TSource>.Shared);
            // ReSharper disable once HeapView.BoxingAllocation
            return new List<TSource>(collection: arrayBuilder);
        }

        static List<TSource> ToListRef<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunctionIn<TSource, bool>
        {
            using var arrayBuilder = ToArrayBuilderRef(source, predicate, ArrayPool<TSource>.Shared);
            // ReSharper disable once HeapView.BoxingAllocation
            return new List<TSource>(collection: arrayBuilder);
        }

        static List<TSource> ToListAt<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            using var arrayBuilder = ToArrayBuilderAt(source, predicate, ArrayPool<TSource>.Shared);
            // ReSharper disable once HeapView.BoxingAllocation
            return new List<TSource>(collection: arrayBuilder);
        }

        static List<TSource> ToListAtRef<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
        {
            using var arrayBuilder = ToArrayBuilderAtRef(source, predicate, ArrayPool<TSource>.Shared);
            // ReSharper disable once HeapView.BoxingAllocation
            return new List<TSource>(collection: arrayBuilder);
        }

        static List<TResult> ToList<TSource, TResult, TSelector>(this in ArraySegment<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Count switch
            {
                0 => new List<TResult>(),
                _ => new List<TResult>(collection: new ArraySegmentSelectorToListCollection<TSource, TResult, TSelector>(source, selector))
            };

        static List<TResult> ToListAt<TSource, TResult, TSelector>(this in ArraySegment<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
            => source.Count switch
            {
                0 => new List<TResult>(),
                _ => new List<TResult>(collection: new ArraySegmentSelectorAtToListCollection<TSource, TResult, TSelector>(source, selector))
            };

        static List<TResult> ToList<TSource, TResult, TPredicate, TSelector>(this in ArraySegment<TSource> source, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, selector, ArrayPool<TResult>.Shared);
            // ReSharper disable once HeapView.BoxingAllocation
            return new List<TResult>(collection: arrayBuilder);
        }

        static List<TResult> ToListRef<TSource, TResult, TPredicate, TSelector>(this in ArraySegment<TSource> source, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSelector : struct, IFunctionIn<TSource, TResult>
        {
            using var arrayBuilder = ToArrayBuilderRef(source, predicate, selector, ArrayPool<TResult>.Shared);
            // ReSharper disable once HeapView.BoxingAllocation
            return new List<TResult>(collection: arrayBuilder);
        }

        // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
        [GeneratorIgnore]
        sealed class ArraySegmentSelectorToListCollection<TSource, TResult, TSelector>
            : ToListCollectionBase<TResult>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            readonly ArraySegment<TSource> source;
            readonly TSelector selector;

            public ArraySegmentSelectorToListCollection(in ArraySegment<TSource> source, TSelector selector)
                : base(source.Count)
                => (this.source, this.selector) = (source, selector);

            public override void CopyTo(TResult[] array, int _)
                => Copy<TSource, TResult, TSelector>(source, array, selector);
        }

        [GeneratorIgnore]
        sealed class ArraySegmentSelectorAtToListCollection<TSource, TResult, TSelector>
            : ToListCollectionBase<TResult>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            readonly ArraySegment<TSource> source;
            readonly TSelector selector;

            public ArraySegmentSelectorAtToListCollection(in ArraySegment<TSource> source, TSelector selector)
                : base(source.Count)
                => (this.source, this.selector) = (source, selector);

            public override void CopyTo(TResult[] array, int _)
                => CopyAt<TSource, TResult, TSelector>(source, array, selector);
        }
    }
}