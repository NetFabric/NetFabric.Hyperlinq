using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource[] ToArray<TList, TSource>(this TList source)
            where TList : notnull, IReadOnlyList<TSource>
            => ToArray<TList, TSource>(source, 0, source.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TSource> ToArray<TList, TSource>(this TList source, MemoryPool<TSource> pool)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (pool is null) Throw.ArgumentNullException(nameof(pool));

            return ToArray(source, 0, source.Count, pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TList, TSource>(this TList source, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
        {
#if NET5_0
            var result = GC.AllocateUninitializedArray<TSource>(count);
#else
            var result = new TSource[count];
#endif
            ReadOnlyListExtensions.Copy(source, offset, result, 0, count);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TList, TSource>(this TList source, int offset, int count, MemoryPool<TSource> pool)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var result = pool.RentSliced(count);
            ReadOnlyListExtensions.Copy<TList, TSource>(source, offset, result.Memory.Span, count);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, offset, count, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count, MemoryPool<TSource> pool)
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, offset, count, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArrayAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicateAt<TSource>
        {
            using var arrayBuilder = ToArrayBuilderAt(source, predicate, offset, count, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArrayAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count, MemoryPool<TSource> pool)
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicateAt<TSource>
        {
            using var arrayBuilder = ToArrayBuilderAt(source, predicate, offset, count, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TList, TSource, TResult>(this TList source, NullableSelector<TSource, TResult> selector, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
        {
#if NET5_0
            var result = GC.AllocateUninitializedArray<TResult>(count);
#else
            var result = new TResult[count];
#endif
            ReadOnlyListExtensions.Copy(source, offset, result, 0, count, selector);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TList, TSource, TResult>(this TList source, NullableSelector<TSource, TResult> selector, int offset, int count, MemoryPool<TResult> pool)
            where TList : notnull, IReadOnlyList<TSource>
        {
            Debug.Assert(pool is object);

            var result = pool.RentSliced(count);
            ReadOnlyListExtensions.Copy(source, offset, result.Memory.Span, count, selector);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TList, TSource, TResult>(this TList source, NullableSelectorAt<TSource, TResult> selector, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
        {
#if NET5_0
            var result = GC.AllocateUninitializedArray<TResult>(count);
#else
            var result = new TResult[count];
#endif
            ReadOnlyListExtensions.Copy(source, offset, result, 0, count, selector);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TList, TSource, TResult>(this TList source, NullableSelectorAt<TSource, TResult> selector, int offset, int count, MemoryPool<TResult> pool)
            where TList : notnull, IReadOnlyList<TSource>
        {
            Debug.Assert(pool is object);

            var result = pool.RentSliced(count);
            ReadOnlyListExtensions.Copy(source, offset, result.Memory.Span, count, selector);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TList, TSource, TResult, TPredicate>(this TList source, TPredicate predicate, NullableSelector<TSource, TResult> selector, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, selector, offset, count, ArrayPool<TResult>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TList, TSource, TResult, TPredicate>(this TList source, TPredicate predicate, NullableSelector<TSource, TResult> selector, int offset, int count, MemoryPool<TResult> pool)
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, selector, offset, count, ArrayPool<TResult>.Shared);
            return arrayBuilder.ToArray(pool);
        }
    }
}

