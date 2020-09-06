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
            where TList : notnull, IReadOnlyList<TSource>
            => source.Count == 0
                ? new List<TSource>()
                : source switch
                    {
                        ICollection<TSource> collection => new List<TSource>(collection), // no need to allocate helper class

                        _ => new List<TSource>(new ToListCollection<TList, TSource>(source, 0, source.Count)),
                    };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToList<TList, TSource>(this TList source, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            => source.Count == 0
                ? new List<TSource>()
                : new List<TSource>(new ToListCollection<TList, TSource>(source, offset, count));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToList<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, offset, count, ArrayPool<TSource>.Shared);
            return new List<TSource>(arrayBuilder);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToListAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicateAt<TSource>
        {
            using var arrayBuilder = ToArrayBuilderAt(source, predicate, offset, count, ArrayPool<TSource>.Shared);
            return new List<TSource>(arrayBuilder);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TList, TSource, TResult>(this TList source, NullableSelector<TSource, TResult> selector, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            => source.Count == 0
                ? new List<TResult>()
                : new List<TResult>(new ToListCollection<TList, TSource, TResult>(source, selector, offset, count));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TList, TSource, TResult>(this TList source, NullableSelectorAt<TSource, TResult> selector, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            => source.Count == 0
                ? new List<TResult>()
                : new List<TResult>(new IndexedToListCollection<TList, TSource, TResult>(source, selector, offset, count));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TList, TSource, TResult, TPredicate>(this TList source, TPredicate predicate, NullableSelector<TSource, TResult> selector, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, selector, offset, count, ArrayPool<TResult>.Shared);
            return new List<TResult>(arrayBuilder);
        }

        // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
        [GeneratorIgnore]
        sealed class ToListCollection<TList, TSource>
            : ToListCollectionBase<TSource>
            where TList : notnull, IReadOnlyList<TSource>
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
        sealed class ToListCollection<TList, TSource, TResult>
            : ToListCollectionBase<TResult>
            where TList : notnull, IReadOnlyList<TSource>
        {
            readonly TList source;
            readonly NullableSelector<TSource, TResult> selector;
            readonly int offset;
            readonly int count;

            public ToListCollection(in TList source, NullableSelector<TSource, TResult> selector, int offset, int count)
                : base(count)
            {
                this.source = source;
                this.selector = selector;
                this.offset = offset;
                this.count = count;
            }

            public override void CopyTo(TResult[] array, int arrayIndex)
                => ReadOnlyListExtensions.Copy(source, offset, array, arrayIndex, count, selector);
        }

        // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
        [GeneratorIgnore]
        sealed class IndexedToListCollection<TList, TSource, TResult>
            : ToListCollectionBase<TResult>
            where TList : notnull, IReadOnlyList<TSource>
        {
            readonly TList source;
            readonly NullableSelectorAt<TSource, TResult> selector;
            readonly int offset;
            readonly int count;

            public IndexedToListCollection(in TList source, NullableSelectorAt<TSource, TResult> selector, int offset, int count)
                : base(count)
            {
                this.source = source;
                this.selector = selector;
                this.offset = offset;
                this.count = count;
            }

            public override void CopyTo(TResult[] array, int arrayIndex)
                => ReadOnlyListExtensions.Copy(source, offset, array, arrayIndex, count, selector);
        }
    }
}
