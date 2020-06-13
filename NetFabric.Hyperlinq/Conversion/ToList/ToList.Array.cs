using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TSource>(this TSource[] source)
            => new List<TSource>(source);

#if SPAN_SUPPORTED

#else

        static List<TSource> ToList<TSource>(this TSource[] source, int skipCount, int takeCount)
            => new List<TSource>(new ToListCollection<TSource>(source, skipCount, takeCount));

        static List<TSource> ToList<TSource>(this TSource[] source, Predicate<TSource> predicate, int skipCount, int takeCount)
        {
            var list = new List<TSource>();
            if (takeCount == 0 && skipCount == source.Length)
            {
                for (var index = 0; index < source.Length; index++)
                {
                    var item = source[index];
                    if (predicate(item))
                        list.Add(item);
                }
                return list;
            }
            else
            {
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    var item = source[index];
                    if (predicate(item))
                        list.Add(item);
                }
                return list;
            }
        }


        static List<TSource> ToList<TSource>(this TSource[] source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
        {
            var list = new List<TSource>();
            if (skipCount == 0)
            {
                if (takeCount == source.Length)
                {
                    for (var index = 0; index < source.Length; index++)
                    {
                        var item = source[index];
                        if (predicate(item, index))
                            list.Add(item);
                    }
                }
                else
                {
                    for (var index = 0; index < takeCount; index++)
                    {
                        var item = source[index];
                        if (predicate(item, index))
                            list.Add(item);
                    }
                }
            }
            else
            {
                for (var index = 0; index < takeCount; index++)
                {
                    var item = source[index + skipCount];
                    if (predicate(item, index))
                        list.Add(item);
                }
            }
            return list;
        }


        static List<TResult> ToList<TSource, TResult>(this TSource[] source, NullableSelector<TSource, TResult> selector, int skipCount, int takeCount)
            => new List<TResult>(new ToListCollection<TSource, TResult>(source, selector, skipCount, takeCount));

        static List<TResult> ToList<TSource, TResult>(this TSource[] source, NullableSelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
            => new List<TResult>(new IndexedToListCollection<TSource, TResult>(source, selector, skipCount, takeCount));


        static List<TResult> ToList<TSource, TResult>(this TSource[] source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector, int skipCount, int takeCount)
        {
            var list = new List<TResult>();
            if (skipCount == 0 && takeCount == source.Length)
            {
                for (var index = 0; index < source.Length; index++)
                {
                    var item = source[index];
                    if (predicate(item))
                        list.Add(selector(item));
                }
            }
            else
            {
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    var item = source[index];
                    if (predicate(item))
                        list.Add(selector(item));
                }
            }
            return list;
        }

        // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
        [GeneratorIgnore]
        sealed class ToListCollection<TSource>
            : ToListCollectionBase<TSource>
        {
            readonly TSource[] source;
            readonly int skipCount;
            readonly int takeCount;

            public ToListCollection(in TSource[] source, int skipCount, int takeCount)
                : base(takeCount)
            {
                this.source = source;
                this.skipCount = skipCount;
                this.takeCount = takeCount;
            }

            public override void CopyTo(TSource[] array, int _)
            {
                if (skipCount == 0)
                {
                    if (takeCount == array.Length)
                    {
                        for (var index = 0; index < array.Length; index++)
                            array[index] = source[index];
                    }
                    else
                    {
                        for (var index = 0; index < takeCount; index++)
                            array[index] = source[index];
                    }
                }
                else
                {
                    for (var index = 0; index < takeCount; index++)
                        array[index] = source[index + skipCount];
                }
            }
        }

        // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
        [GeneratorIgnore]
        sealed class ToListCollection<TSource, TResult>
            : ToListCollectionBase<TResult>
        {
            readonly TSource[] source;
            readonly NullableSelector<TSource, TResult> selector;
            readonly int skipCount;
            readonly int takeCount;

            public ToListCollection(in TSource[] source, NullableSelector<TSource, TResult> selector, int skipCount, int takeCount)
                : base(takeCount)
            {
                this.source = source;
                this.selector = selector;
                this.skipCount = skipCount;
                this.takeCount = takeCount;
            }

            public override void CopyTo(TResult[] array, int _)
            {
                if (skipCount == 0)
                {
                    if (takeCount == source.Length)
                    {
                        for (var index = 0; index < source.Length; index++)
                            array[index] = selector(source[index]);
                    }
                    else
                    {
                        for (var index = 0; index < takeCount; index++)
                            array[index] = selector(source[index]);
                    }
                }
                else
                {
                    for (var index = 0; index < takeCount; index++)
                        array[index] = selector(source[index + skipCount]);
                }
            }
        }

        // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
        [GeneratorIgnore]
        sealed class IndexedToListCollection<TSource, TResult>
            : ToListCollectionBase<TResult>
        {
            readonly TSource[] source;
            readonly NullableSelectorAt<TSource, TResult> selector;
            readonly int skipCount;
            readonly int takeCount;

            public IndexedToListCollection(in TSource[] source, NullableSelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
                : base(takeCount)
            {
                this.source = source;
                this.selector = selector;
                this.skipCount = skipCount;
                this.takeCount = takeCount;
            }

            public override void CopyTo(TResult[] array, int _)
            {
                if (skipCount == 0)
                {
                    if (takeCount == source.Length)
                    {
                        for (var index = 0; index < source.Length; index++)
                            array[index] = selector(source[index], index);
                    }
                    else
                    {
                        for (var index = 0; index < takeCount; index++)
                            array[index] = selector(source[index], index);
                    }
                }
                else
                {
                    for (var index = 0; index < takeCount; index++)
                        array[index] = selector(source[index + skipCount], index);
                }
            }
        }

#endif
    }
}