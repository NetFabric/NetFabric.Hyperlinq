using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {
        
        public static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            switch (source)
            {
                case ICollection<TSource> collection:
#if NET5_0
                    var result = GC.AllocateUninitializedArray<TSource>(collection.Count);
#else
                    var result = new TSource[collection.Count];
#endif
                    collection.CopyTo(result, 0);
                    return result;

                default:
                    {
                        using var builder = new LargeArrayBuilder<TSource>(ArrayPool<TSource>.Shared);
                        using var enumerator = source.GetEnumerator();
                        while (enumerator.MoveNext())
                            builder.Add(enumerator.Current);
                        return builder.ToArray();
                    }
            }
        }

        public static IMemoryOwner<TSource> ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source, MemoryPool<TSource> pool)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            Debug.Assert(pool is object);

            using var builder = new LargeArrayBuilder<TSource>(ArrayPool<TSource>.Shared);
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
                builder.Add(enumerator.Current);
            return builder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Predicate<TSource> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var builder = new LargeArrayBuilder<TSource>(ArrayPool<TSource>.Shared);
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate(item))
                    builder.Add(item);
            }
            return builder.ToArray();
        }

        static IMemoryOwner<TSource> ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Predicate<TSource> predicate, MemoryPool<TSource> pool)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            Debug.Assert(pool is object);

            using var builder = new LargeArrayBuilder<TSource>(ArrayPool<TSource>.Shared);
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate(item))
                    builder.Add(item);
            }
            return builder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source, PredicateAt<TSource> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var builder = new LargeArrayBuilder<TSource>(ArrayPool<TSource>.Shared);
            using var enumerator = source.GetEnumerator();
            for (var index = 0; enumerator.MoveNext(); index++)
            {
                var item = enumerator.Current;
                if (predicate(item, index))
                    builder.Add(item);
            }
            return builder.ToArray();
        }

        static IMemoryOwner<TSource> ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source, PredicateAt<TSource> predicate, MemoryPool<TSource> pool)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            Debug.Assert(pool is object);

            using var builder = new LargeArrayBuilder<TSource>(ArrayPool<TSource>.Shared);
            using var enumerator = source.GetEnumerator();
            for (var index = 0; enumerator.MoveNext(); index++)
            {
                var item = enumerator.Current;
                if (predicate(item, index))
                    builder.Add(item);
            }
            return builder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        static TResult[] ToArray<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, NullableSelector<TSource, TResult> selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var builder = new LargeArrayBuilder<TResult>(ArrayPool<TResult>.Shared);
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
                builder.Add(selector(enumerator.Current));
            return builder.ToArray();
        }

        static IMemoryOwner<TResult> ToArray<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, NullableSelector<TSource, TResult> selector, MemoryPool<TResult> pool)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            Debug.Assert(pool is object);

            using var builder = new LargeArrayBuilder<TResult>(ArrayPool<TResult>.Shared);
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
                builder.Add(selector(enumerator.Current));
            return builder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        static TResult[] ToArray<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, NullableSelectorAt<TSource, TResult> selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var builder = new LargeArrayBuilder<TResult>(ArrayPool<TResult>.Shared);
            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                    builder.Add(selector(enumerator.Current, index));
            }
            return builder.ToArray();
        }

        static IMemoryOwner<TResult> ToArray<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, NullableSelectorAt<TSource, TResult> selector, MemoryPool<TResult> pool)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            Debug.Assert(pool is object);

            using var builder = new LargeArrayBuilder<TResult>(ArrayPool<TResult>.Shared);
            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                    builder.Add(selector(enumerator.Current, index));
            }
            return builder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        static TResult[] ToArray<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var builder = new LargeArrayBuilder<TResult>(ArrayPool<TResult>.Shared);
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate(item))
                    builder.Add(selector(item));
            }
            return builder.ToArray();
        }

        static IMemoryOwner<TResult> ToArray<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector, MemoryPool<TResult> pool)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            Debug.Assert(pool is object);

            using var builder = new LargeArrayBuilder<TResult>(ArrayPool<TResult>.Shared);
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate(item))
                    builder.Add(selector(item));
            }
            return builder.ToArray(pool);
        }
    }
}