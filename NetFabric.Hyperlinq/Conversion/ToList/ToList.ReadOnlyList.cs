using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
// ReSharper disable HeapView.ObjectAllocation.Evident

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TList, TSource>(this TList source)
            where TList : IReadOnlyList<TSource>
            => source.Count switch
            {
                0 => new List<TSource>(),
                _ => source switch
                    {
                        // ReSharper disable once HeapView.PossibleBoxingAllocation
                        ICollection<TSource> collection => new List<TSource>(collection),
                        
                        _ => new List<TSource>(new ToListCollection<TList, TSource>(source, 0, source.Count)),
                    }
            };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToList<TList, TSource>(this TList source, int offset, int count)
            where TList : IReadOnlyList<TSource>
            => source.Count switch
            {
                0 => new List<TSource>(),
                _ => new List<TSource>(new ToListCollection<TList, TSource>(source, offset, count))
            };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToList<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, offset, count, ArrayPool<TSource>.Shared);
            // ReSharper disable once HeapView.BoxingAllocation
            return new List<TSource>(collection: arrayBuilder);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToListAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            using var arrayBuilder = ToArrayBuilderAt(source, predicate, offset, count, ArrayPool<TSource>.Shared);
            // ReSharper disable once HeapView.BoxingAllocation
            return new List<TSource>(collection: arrayBuilder);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TList, TSource, TResult, TSelector>(this TList source, TSelector selector, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Count switch
            {
                0 => new List<TResult>(),
                _ => new List<TResult>(new ToListCollection<TList, TSource, TResult, TSelector>(source, selector, offset, count))
            };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToListAt<TList, TSource, TResult, TSelector>(this TList source, TSelector selector, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
            => source.Count == 0
                ? new List<TResult>()
                : new List<TResult>(new IndexedToListCollection<TList, TSource, TResult, TSelector>(source, selector, offset, count));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TList, TSource, TResult, TPredicate, TSelector>(this TList source, TPredicate predicate, TSelector selector, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            using var arrayBuilder = ToArrayBuilder<TList, TSource, TResult, TPredicate, TSelector>(source, predicate, selector, offset, count, ArrayPool<TResult>.Shared);
            // ReSharper disable once HeapView.BoxingAllocation
            return new List<TResult>(collection: arrayBuilder);
        }

        // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
        [GeneratorIgnore]
        sealed class ToListCollection<TList, TSource>
            : ToListCollectionBase<TSource>
            where TList : IReadOnlyList<TSource>
        {
            readonly TList source;
            readonly int offset;
            readonly int count;

            public ToListCollection(in TList source, int offset, int count)
                : base(count)
            {
                this.source = source;
                this.offset = offset;
                this.count = count;
            }

            public override void CopyTo(TSource[] array, int _)
            {
                for (var index = 0; index < count; index++)
                    array[index] = source[index + offset];
            }
        }

        // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
        [GeneratorIgnore]
        sealed class ToListCollection<TList, TSource, TResult, TSelector>
            : ToListCollectionBase<TResult>
            where TList : IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            readonly TList source;
            readonly TSelector selector;
            readonly int offset;
            readonly int count;

            public ToListCollection(in TList source, TSelector selector, int offset, int count)
                : base(count)
            {
                this.source = source;
                this.selector = selector;
                this.offset = offset;
                this.count = count;
            }

            public override void CopyTo(TResult[] array, int arrayIndex)
                => Copy<TList, TSource, TResult, TSelector>(source, offset, array, arrayIndex, count, selector);
        }

        // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
        [GeneratorIgnore]
        sealed class IndexedToListCollection<TList, TSource, TResult, TSelector>
            : ToListCollectionBase<TResult>
            where TList : IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            readonly TList source;
            readonly TSelector selector;
            readonly int offset;
            readonly int count;

            public IndexedToListCollection(in TList source, TSelector selector, int offset, int count)
                : base(count)
            {
                this.source = source;
                this.selector = selector;
                this.offset = offset;
                this.count = count;
            }

            public override void CopyTo(TResult[] array, int arrayIndex)
                => CopyAt<TList, TSource, TResult, TSelector>(source, offset, array, arrayIndex, count, selector);
        }
    }
}
