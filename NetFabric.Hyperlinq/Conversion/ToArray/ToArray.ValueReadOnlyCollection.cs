using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            return source switch
            {
                { Count: 0 } => Array.Empty<TSource>(),
                
                // ReSharper disable once HeapView.PossibleBoxingAllocation
                // ReSharper disable once SuspiciousTypeConversion.Global
                ICollection collection => BuildArrayFromCollection(collection),
                
                _ => BuildArray(source)
            };

            static TSource[] BuildArrayFromCollection(ICollection collection)
            {
                var result = Utils.AllocateUninitializedArray<TSource>(collection.Count);
                collection.CopyTo(result, 0);
                return result;                
            }

            static TSource[] BuildArray(TEnumerable source)
            {
                var result = Utils.AllocateUninitializedArray<TSource>(source.Count);
                Copy<TEnumerable, TEnumerator, TSource>(source, result);
                return result;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueMemoryOwner<TSource> ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source, ArrayPool<TSource> pool, bool clearOnDispose = default)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var result = pool.RentSliced(source.Count, clearOnDispose);
            Copy<TEnumerable, TEnumerator, TSource>(source, result.Memory.Span);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            => source switch
            {
                { Count: 0 } => Array.Empty<TSource>(),
                _ => ValueEnumerableExtensions.ToArray<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate)
            };

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ValueMemoryOwner<TSource> ToArray<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, ArrayPool<TSource> pool, bool clearOnDispose, TPredicate predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            => ValueEnumerableExtensions.ToArray<TEnumerable, TEnumerator, TSource, TPredicate>(source, pool, clearOnDispose, predicate);

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArrayAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source switch
            {
                { Count: 0 } => Array.Empty<TSource>(),
                _ => ValueEnumerableExtensions.ToArrayAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate)
            };

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ValueMemoryOwner<TSource> ToArrayAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, ArrayPool<TSource> pool, bool clearOnDispose, TPredicate predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
            => ValueEnumerableExtensions.ToArrayAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, pool, clearOnDispose, predicate);

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TResult[] ToArray<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            return source switch
            {
                { Count: 0 } => Array.Empty<TResult>(),
                _ => BuildArray(source, selector)
            };

            static TResult[] BuildArray(TEnumerable source, TSelector selector)
            {
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                var array = new TResult[source.Count];
                Copy<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, array, selector);
                return array;
            }
        }

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ValueMemoryOwner<TResult> ToArray<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, ArrayPool<TResult> pool, bool clearOnDispose, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            var result = pool.RentSliced(source.Count, clearOnDispose);
            Copy<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, result.Memory.Span, selector);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TResult[] ToArrayAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            return source switch
            {
                { Count: 0 } => Array.Empty<TResult>(),
                _ => BuildArray(source, selector)
            };

            static TResult[] BuildArray(TEnumerable source, TSelector selector)
            {
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                var array = new TResult[source.Count];
                CopyAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, array, selector);
                return array;
            }
        }

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ValueMemoryOwner<TResult> ToArrayAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, ArrayPool<TResult> pool, bool clearOnDispose, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            var result = pool.RentSliced(source.Count, clearOnDispose);
            CopyAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, result.Memory.Span, selector);
            return result;
        }
        
        //////////////////////////////////////////////////////////////////////////////////////////////////

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(this TEnumerable source, TPredicate predicate, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            => source switch
            {
                { Count: 0 } => Array.Empty<TResult>(),
                _ => ValueEnumerableExtensions.ToArray<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(source, predicate, selector)
            };

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ValueMemoryOwner<TResult> ToArray<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(this TEnumerable source, ArrayPool<TResult> pool, bool clearOnDispose, TPredicate predicate, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            => ValueEnumerableExtensions.ToArray<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(source, pool, clearOnDispose, predicate, selector);
    }
}
