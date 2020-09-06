using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {
        
        public static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
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
                        using var arrayBuilder = ToArrayBuilder<TEnumerable, TEnumerator, TSource>(source, ArrayPool<TSource>.Shared);
                        return arrayBuilder.ToArray();
                    }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TSource> ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source, MemoryPool<TSource> pool)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var arrayBuilder = ToArrayBuilder<TEnumerable, TEnumerator, TSource>(source, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            using var arrayBuilder = ToArrayBuilder<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, MemoryPool<TSource> pool)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            using var arrayBuilder = ToArrayBuilder<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArrayAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicateAt<TSource>
        {
            using var arrayBuilder = ToArrayBuilderAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArrayAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, MemoryPool<TSource> pool)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicateAt<TSource>
        {
            using var arrayBuilder = ToArrayBuilderAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, NullableSelector<TSource, TResult> selector)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var arrayBuilder = ToArrayBuilder<TEnumerable, TEnumerator, TSource, TResult>(source, selector, ArrayPool<TResult>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, NullableSelector<TSource, TResult> selector, MemoryPool<TResult> pool)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var arrayBuilder = ToArrayBuilder<TEnumerable, TEnumerator, TSource, TResult>(source, selector, ArrayPool<TResult>.Shared);
            return arrayBuilder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, NullableSelectorAt<TSource, TResult> selector)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var arrayBuilder = ToArrayBuilder<TEnumerable, TEnumerator, TSource, TResult>(source, selector, ArrayPool<TResult>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, NullableSelectorAt<TSource, TResult> selector, MemoryPool<TResult> pool)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var arrayBuilder = ToArrayBuilder<TEnumerable, TEnumerator, TSource, TResult>(source, selector, ArrayPool<TResult>.Shared);
            return arrayBuilder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(this TEnumerable source, TPredicate predicate, NullableSelector<TSource, TResult> selector)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            using var arrayBuilder = ToArrayBuilder<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(source, predicate, selector, ArrayPool<TResult>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(this TEnumerable source, TPredicate predicate, NullableSelector<TSource, TResult> selector, MemoryPool<TResult> pool)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            using var arrayBuilder = ToArrayBuilder<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(source, predicate, selector, ArrayPool<TResult>.Shared);
            return arrayBuilder.ToArray(pool);
        }
    }
}