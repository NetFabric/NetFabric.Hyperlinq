using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {

        public static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count is 0)
                return Array.Empty<TSource>();

            var result = Utils.AllocateUninitializedArray<TSource>(source.Count);
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            if (source is ICollection<TSource> collection)
                collection.CopyTo(result, 0);
            else
                Copy<TEnumerable, TEnumerator, TSource>(source, result);
            return result;
        }

        public static Lease<TSource> ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source, ArrayPool<TSource> pool, bool clearOnDispose = default)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count is 0)
                return Lease.Empty<TSource>();

            var result = pool.Lease(source.Count, clearOnDispose);
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            if (source is ICollection<TSource> collection)
                collection.CopyTo(result.Rented, 0);
            else
                Copy<TEnumerable, TEnumerator, TSource>(source, result.Rented);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        static TSource[] ToArray<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source,
            TPredicate predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool> 
            => source.Count is 0 
                ? Array.Empty<TSource>() 
                : ValueEnumerableExtensions.ToArray<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

        static Lease<TSource> ToArray<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, ArrayPool<TSource> pool, bool clearOnDispose, TPredicate predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            => source.Count is 0 
                ? Lease.Empty<TSource>()
                : ValueEnumerableExtensions.ToArray<TEnumerable, TEnumerator, TSource, TPredicate>(source, pool, clearOnDispose, predicate);

        //////////////////////////////////////////////////////////////////////////////////////////////////

        static TSource[] ToArrayAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.Count is 0 
                ? Array.Empty<TSource>() 
                : ValueEnumerableExtensions.ToArrayAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Lease<TSource> ToArrayAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, ArrayPool<TSource> pool, bool clearOnDispose, TPredicate predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.Count is 0 
                ? Lease.Empty<TSource>()
                : ValueEnumerableExtensions.ToArrayAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, pool, clearOnDispose, predicate);

        //////////////////////////////////////////////////////////////////////////////////////////////////

        internal static TResult[] ToArray<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            if (source.Count is 0)
                return Array.Empty<TResult>();

            var result = Utils.AllocateUninitializedArray<TResult>(source.Count);
            Copy<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, result, selector);
            return result;
        }

        internal static Lease<TResult> ToArray<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, ArrayPool<TResult> pool, bool clearOnDispose, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            if (source.Count is 0)
                return Lease.Empty<TResult>();

            var result = pool.Lease(source.Count, clearOnDispose);
            Copy<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, result.Rented, selector);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        internal static TResult[] ToArrayAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            if (source.Count is 0)
                return Array.Empty<TResult>();

            var result = Utils.AllocateUninitializedArray<TResult>(source.Count);
            CopyAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, result, selector);
            return result;
        }

        internal static Lease<TResult> ToArrayAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, ArrayPool<TResult> pool, bool clearOnDispose, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            if (source.Count is 0)
                return Lease.Empty<TResult>();

            var result = pool.Lease(source.Count, clearOnDispose);
            CopyAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, result.Rented, selector);
            return result;
        }
        
        //////////////////////////////////////////////////////////////////////////////////////////////////

        static TResult[] ToArray<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(this TEnumerable source, TPredicate predicate, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Count is 0 
                ? Array.Empty<TResult>()
                : ValueEnumerableExtensions.ToArray<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(source, predicate, selector);

        static Lease<TResult> ToArray<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(this TEnumerable source, ArrayPool<TResult> pool, bool clearOnDispose, TPredicate predicate, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Count is 0 
                ? Lease.Empty<TResult>()
                : ValueEnumerableExtensions.ToArray<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(source, pool, clearOnDispose, predicate, selector);
    }
}
