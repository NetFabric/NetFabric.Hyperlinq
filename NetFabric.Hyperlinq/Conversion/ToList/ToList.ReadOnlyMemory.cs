using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TSource>(this ReadOnlyMemory<TSource> source)
            => new List<TSource>(new ReadOnlyMemoryToListCollection<TSource>(source));

        
        static List<TSource> ToList<TSource>(this ReadOnlyMemory<TSource> source, Predicate<TSource> predicate)
        {
            var list = new List<TSource>();
            var span = source.Span;
            for (var index = 0; index < source.Length; index++)
            {
                var item = span[index];
                if (predicate(item))
                    list.Add(item);
            }
            return list;
        }

        
        static List<TSource> ToList<TSource>(this ReadOnlyMemory<TSource> source, PredicateAt<TSource> predicate)
        {
            var list = new List<TSource>();
            var span = source.Span;
            for (var index = 0; index < source.Length; index++)
            {
                var item = span[index];
                if (predicate(item, index))
                    list.Add(item);
            }
            return list;
        }

        
        static List<TResult> ToList<TSource, TResult>(this ReadOnlyMemory<TSource> source, NullableSelector<TSource, TResult> selector)
            => new List<TResult>(new ReadOnlyMemorySelectorToListCollection<TSource, TResult>(source, selector));

        
        static List<TResult> ToList<TSource, TResult>(this ReadOnlyMemory<TSource> source, NullableSelectorAt<TSource, TResult> selector)
            => new List<TResult>(new ReadOnlyMemorySelectorAtToListCollection<TSource, TResult>(source, selector));

        
        static List<TResult> ToList<TSource, TResult>(this ReadOnlyMemory<TSource> source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector)
        {
            var list = new List<TResult>();
            var span = source.Span;
            for (var index = 0; index < source.Length; index++)
            {
                var item = span[index];
                if (predicate(item))
                    list.Add(selector(item)!);
            }
            return list;
        }

        sealed class ReadOnlyMemoryToListCollection<TSource>
            : ToListCollectionBase<TSource>
        {
            readonly ReadOnlyMemory<TSource> source;

            public ReadOnlyMemoryToListCollection(ReadOnlyMemory<TSource> source)
                : base(source.Length)
                => this.source = source;

            public override void CopyTo(TSource[] array, int _)
                => source.Span.CopyTo(array.AsSpan());
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