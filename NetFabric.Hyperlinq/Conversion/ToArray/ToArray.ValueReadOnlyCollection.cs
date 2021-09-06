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

        public static IMemoryOwner<TSource> ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source, ArrayPool<TSource> pool, bool clearOnDispose = default)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count is 0)
                return EmptyMemoryOwner<TSource>.Instance;

            var result = pool.RentDisposable(source.Count, clearOnDispose);
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            if (source is ICollection<TSource> collection)
                collection.CopyTo(result.Rented, 0);
            else
                Copy<TEnumerable, TEnumerator, TSource>(source, result.Rented);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [GeneratorIgnore]
        static TSource[] ToArray<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source,
            TPredicate predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool> 
            => source.Count is 0 
                ? Array.Empty<TSource>() 
                : ValueEnumerableExtensions.ToArray<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

        [GeneratorIgnore]
        static IMemoryOwner<TSource> ToArray<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, ArrayPool<TSource> pool, bool clearOnDispose, TPredicate predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            => source.Count is 0 
                ? EmptyMemoryOwner<TSource>.Instance
                : ValueEnumerableExtensions.ToArray<TEnumerable, TEnumerator, TSource, TPredicate>(source, pool, clearOnDispose, predicate);

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [GeneratorIgnore]
        static TSource[] ToArrayAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.Count is 0 
                ? Array.Empty<TSource>() 
                : ValueEnumerableExtensions.ToArrayAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArrayAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, ArrayPool<TSource> pool, bool clearOnDispose, TPredicate predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.Count is 0 
                ? EmptyMemoryOwner<TSource>.Instance
                : ValueEnumerableExtensions.ToArrayAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, pool, clearOnDispose, predicate);

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [GeneratorIgnore]
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

        [GeneratorIgnore]
        internal static IMemoryOwner<TResult> ToArray<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, ArrayPool<TResult> pool, bool clearOnDispose, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            if (source.Count is 0)
                return EmptyMemoryOwner<TResult>.Instance;

            var result = pool.RentDisposable(source.Count, clearOnDispose);
            Copy<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, result.Rented, selector);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [GeneratorIgnore]
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

        [GeneratorIgnore]
        internal static IMemoryOwner<TResult> ToArrayAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, ArrayPool<TResult> pool, bool clearOnDispose, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            if (source.Count is 0)
                return EmptyMemoryOwner<TResult>.Instance;

            var result = pool.RentDisposable(source.Count, clearOnDispose);
            CopyAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, result.Rented, selector);
            return result;
        }
        
        //////////////////////////////////////////////////////////////////////////////////////////////////

        [GeneratorIgnore]
        static TResult[] ToArray<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(this TEnumerable source, TPredicate predicate, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Count is 0 
                ? Array.Empty<TResult>()
                : ValueEnumerableExtensions.ToArray<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(source, predicate, selector);

        [GeneratorIgnore]
        static IMemoryOwner<TResult> ToArray<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(this TEnumerable source, ArrayPool<TResult> pool, bool clearOnDispose, TPredicate predicate, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Count is 0 
                ? EmptyMemoryOwner<TResult>.Instance
                : ValueEnumerableExtensions.ToArray<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(source, pool, clearOnDispose, predicate, selector);
    }
}
