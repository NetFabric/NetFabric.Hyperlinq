using System;
using System.Buffers;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource[] ToArray<TSource>(this in ArraySegment<TSource> source)
        {
#if NET5_0
            var result = GC.AllocateUninitializedArray<TSource>(source.Count);
#else
            var result = new TSource[source.Count];
#endif
            ArrayExtensions.Copy(source, new ArraySegment<TSource>(result));
            return result;
        }

        public static IMemoryOwner<TSource> ToArray<TSource>(this in ArraySegment<TSource> source, MemoryPool<TSource> pool)
        {
            if (pool is null) Throw.ArgumentNullException(nameof(pool));

            var result = pool.RentSliced(source.Count);
            ArrayExtensions.Copy(source.AsSpan(), result.Memory.Span);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TSource>(this in ArraySegment<TSource> source, Predicate<TSource> predicate)
            => ToArrayBuilder(source, predicate, ArrayPool<TSource>.Shared).ToArray();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TSource>(this in ArraySegment<TSource> source, Predicate<TSource> predicate, MemoryPool<TSource> pool)
        {
            Debug.Assert(pool is object);
            return ToArrayBuilder(source, predicate, ArrayPool<TSource>.Shared).ToArray(pool);
        }

        static LargeArrayBuilder<TSource> ToArrayBuilder<TSource>(in ArraySegment<TSource> source, Predicate<TSource> predicate, ArrayPool<TSource> pool)
        {
            Debug.Assert(pool is object);

            using var builder = new LargeArrayBuilder<TSource>(pool);
            var array = source.Array;
            if (source.Offset == 0 && source.Count == array.Length)
            {
                for (var index = 0; index < array.Length; index++)
                {
                    if (predicate(array[index]))
                        builder.Add(array[index]);
                }
            }
            else
            {
                var end = source.Offset + source.Count;
                for (var index = source.Offset; index < end; index++)
                {
                    if (predicate(array[index]))
                        builder.Add(array[index]);
                }
            }
            return builder;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TSource>(this in ArraySegment<TSource> source, PredicateAt<TSource> predicate)
            => ToArrayBuilder(source, predicate, ArrayPool<TSource>.Shared).ToArray();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TSource>(this in ArraySegment<TSource> source, PredicateAt<TSource> predicate, MemoryPool<TSource> pool)
        {
            Debug.Assert(pool is object);
            return ToArrayBuilder(source, predicate, ArrayPool<TSource>.Shared).ToArray(pool);
        }

        static LargeArrayBuilder<TSource> ToArrayBuilder<TSource>(in ArraySegment<TSource> source, PredicateAt<TSource> predicate, ArrayPool<TSource> pool)
        {
            Debug.Assert(pool is object);

            using var builder = new LargeArrayBuilder<TSource>(pool);
            var array = source.Array;
            if (source.Offset == 0)
            {
                if (source.Count == array.Length)
                {
                    for (var index = 0; index < array.Length; index++)
                    {
                        if (predicate(array[index], index))
                            builder.Add(array[index]);
                    }
                }
                else
                {
                    for (var index = 0; index < source.Count; index++)
                    {
                        if (predicate(array[index], index))
                            builder.Add(array[index]);
                    }
                }
            }
            else
            {
                var offset = source.Offset;
                var count = source.Count;
                for (var index = 0; index < count; index++)
                {
                    var item = array[index + offset];
                    if (predicate(item, index))
                        builder.Add(item);
                }
            }
            return builder;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult>(this in ArraySegment<TSource> source, NullableSelector<TSource, TResult> selector)
        {
#if NET5_0
            var result = GC.AllocateUninitializedArray<TResult>(source.Count);
#else
            var result = new TResult[source.Count];
#endif
            ArrayExtensions.Copy(source, new ArraySegment<TResult>(result), selector);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult>(this in ArraySegment<TSource> source, NullableSelector<TSource, TResult> selector, MemoryPool<TResult> pool)
        {
            Debug.Assert(pool is object);

            var result = pool.RentSliced(source.Count);
            ArrayExtensions.Copy(source.AsSpan(), result.Memory.Span, selector);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult>(this in ArraySegment<TSource> source, NullableSelectorAt<TSource, TResult> selector)
        {
#if NET5_0
            var result = GC.AllocateUninitializedArray<TResult>(source.Count);
#else
            var result = new TResult[source.Count];
#endif
            ArrayExtensions.Copy(source, new ArraySegment<TResult>(result), selector);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult>(this in ArraySegment<TSource> source, NullableSelectorAt<TSource, TResult> selector, MemoryPool<TResult> pool)
        {
            Debug.Assert(pool is object);

            var result = pool.RentSliced(source.Count);
            ArrayExtensions.Copy(source.AsSpan(), result.Memory.Span, selector);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult>(this in ArraySegment<TSource> source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector)
            => ToArrayBuilder(source, predicate, selector, ArrayPool<TResult>.Shared).ToArray();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult>(this in ArraySegment<TSource> source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector, MemoryPool<TResult> pool)
        {
            Debug.Assert(pool is object);
            return ToArrayBuilder(source, predicate, selector, ArrayPool<TResult>.Shared).ToArray(pool);
        }

        static LargeArrayBuilder<TResult> ToArrayBuilder<TSource, TResult>(in ArraySegment<TSource> source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector, ArrayPool<TResult> pool)
        {
            Debug.Assert(pool is object);

            using var builder = new LargeArrayBuilder<TResult>(pool);
            var array = source.Array;
            if (source.Offset == 0 && source.Count == array.Length)
            {
                for (var sourceIndex = 0; sourceIndex < array.Length; sourceIndex++)
                {
                    if (predicate(array[sourceIndex]))
                        builder.Add(selector(array[sourceIndex]));
                }
            }
            else
            {
                var end = source.Offset + source.Count;
                for (var index = source.Offset; index < end; index++)
                {
                    if (predicate(array[index]))
                        builder.Add(selector(array[index]));
                }
            }
            return builder;
        }
    }
}

