using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        public static List<TSource> ToList<TSource>(this ReadOnlyMemory<TSource> source)
            => new List<TSource>(new ToListCollection<TSource>(source));

        
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

        
        static List<TResult> ToList<TSource, TResult>(this ReadOnlyMemory<TSource> source, Selector<TSource, TResult> selector)
            => new List<TResult>(new ToListCollection<TSource, TResult>(source, selector));

        
        static List<TResult> ToList<TSource, TResult>(this ReadOnlyMemory<TSource> source, SelectorAt<TSource, TResult> selector)
            => new List<TResult>(new IndexedToListCollection<TSource, TResult>(source, selector));

        
        static List<TResult> ToList<TSource, TResult>(this ReadOnlyMemory<TSource> source, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
        {
            var list = new List<TResult>();
            var span = source.Span;
            for (var index = 0; index < source.Length; index++)
            {
                var item = span[index];
                if (predicate(item))
                    list.Add(selector(item));
            }
            return list;
        }

        [GeneratorIgnore]
        sealed class ToListCollection<TSource>
            : ToListCollectionBase<TSource>
        {
            readonly ReadOnlyMemory<TSource> source;

            public ToListCollection(ReadOnlyMemory<TSource> source)
                : base(source.Length)
                => this.source = source;

            public override void CopyTo(TSource[] array, int _)
                => source.Span.CopyTo(array.AsSpan());
        }

        [GeneratorIgnore]
        sealed class ToListCollection<TSource, TResult>
            : ToListCollectionBase<TResult>
        {
            readonly ReadOnlyMemory<TSource> source;
            readonly Selector<TSource, TResult> selector;

            public ToListCollection(ReadOnlyMemory<TSource> source, Selector<TSource, TResult> selector)
                : base(source.Length)
            {
                this.source = source;
                this.selector = selector;
            }

            public override void CopyTo(TResult[] array, int _)
            {
                var span = source.Span;
                for (var index = 0; index < span.Length; index++)
                    array[index] = selector(span[index]);
            }
        }

        [GeneratorIgnore]
        sealed class IndexedToListCollection<TSource, TResult>
            : ToListCollectionBase<TResult>
        {
            readonly ReadOnlyMemory<TSource> source;
            readonly SelectorAt<TSource, TResult> selector;

            public IndexedToListCollection(ReadOnlyMemory<TSource> source, SelectorAt<TSource, TResult> selector)
                : base(source.Length)
            {
                this.source = source;
                this.selector = selector;
            }

            public override void CopyTo(TResult[] array, int _)
            {
                var span = source.Span;
                for (var index = 0; index < span.Length; index++)
                    array[index] = selector(span[index], index);
            }
        }
    }
}