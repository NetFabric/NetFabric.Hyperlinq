using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TSource>(this in ArraySegment<TSource> source)
            => new List<TSource>(source);

        static List<TSource> ToList<TSource>(this in ArraySegment<TSource> source, Predicate<TSource> predicate)
        {
            var array = source.Array;
            var list = new List<TSource>();
            if (source.Offset == 0 && source.Count == array.Length)
            {
                for (var index = 0; index < array.Length; index++)
                {
                    var item = array[index];
                    if (predicate(item))
                        list.Add(item);
                }
                return list;
            }
            else
            {
                var end = source.Offset + source.Count;
                for (var index = source.Offset; index < end; index++)
                {
                    var item = array[index];
                    if (predicate(item))
                        list.Add(item);
                }
                return list;
            }
        }

        static List<TSource> ToList<TSource>(this in ArraySegment<TSource> source, PredicateAt<TSource> predicate)
        {
            var array = source.Array;
            var list = new List<TSource>();
            if (source.Offset == 0)
            {
                if (source.Count == array.Length)
                {
                    for (var index = 0; index < array.Length; index++)
                    {
                        var item = array[index];
                        if (predicate(item, index))
                            list.Add(item);
                    }
                }
                else
                {
                    for (var index = 0; index < source.Count; index++)
                    {
                        var item = array[index];
                        if (predicate(item, index))
                            list.Add(item);
                    }
                }
            }
            else
            {
                for (var index = 0; index < source.Count; index++)
                {
                    var item = array[index + source.Offset];
                    if (predicate(item, index))
                        list.Add(item);
                }
            }
            return list;
        }


        static List<TResult> ToList<TSource, TResult>(this in ArraySegment<TSource> source, NullableSelector<TSource, TResult> selector)
            => source.Count == 0
                ? new List<TResult>()
                : new List<TResult>(new ArraySegmentSelectorToListCollection<TSource, TResult>(source, selector));

        static List<TResult> ToList<TSource, TResult>(this in ArraySegment<TSource> source, NullableSelectorAt<TSource, TResult> selector)
            => source.Count == 0
                ? new List<TResult>()
                : new List<TResult>(new ArraySegmentSelectorAtToListCollection<TSource, TResult>(source, selector));


        static List<TResult> ToList<TSource, TResult>(this in ArraySegment<TSource> source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector)
        {
            var array = source.Array;
            var list = new List<TResult>();
            if (source.Offset == 0 && source.Count == array.Length)
            {
                for (var index = 0; index < array.Length; index++)
                {
                    var item = array[index];
                    if (predicate(item))
                        list.Add(selector(item)!);
                }
            }
            else
            {
                var end = source.Offset + source.Count;
                for (var index = source.Offset; index < end; index++)
                {
                    var item = array[index];
                    if (predicate(item))
                        list.Add(selector(item)!);
                }
            }
            return list;
        }

        // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
        sealed class ArraySegmentSelectorToListCollection<TSource, TResult>
            : ToListCollectionBase<TResult>
        {
            readonly ArraySegment<TSource> source;
            readonly NullableSelector<TSource, TResult> selector;

            public ArraySegmentSelectorToListCollection(in ArraySegment<TSource> source, NullableSelector<TSource, TResult> selector)
                : base(source.Count)
                => (this.source, this.selector) = (source, selector);

            public override void CopyTo(TResult[] array, int arrayIndex)
                => ArrayExtensions.Copy(source, new ArraySegment<TResult>(array, arrayIndex, array.Length), selector);
        }

        // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
        sealed class ArraySegmentSelectorAtToListCollection<TSource, TResult>
            : ToListCollectionBase<TResult>
        {
            readonly ArraySegment<TSource> source;
            readonly NullableSelectorAt<TSource, TResult> selector;

            public ArraySegmentSelectorAtToListCollection(in ArraySegment<TSource> source, NullableSelectorAt<TSource, TResult> selector)
                : base(source.Count)
                => (this.source, this.selector) = (source, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override void CopyTo(TResult[] array, int arrayIndex)
                => ArrayExtensions.Copy(source, new ArraySegment<TResult>(array, arrayIndex, array.Length), selector);
        }
    }
}