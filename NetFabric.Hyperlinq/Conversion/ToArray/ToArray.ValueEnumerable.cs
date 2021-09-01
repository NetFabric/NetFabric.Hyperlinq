using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {
        
        public static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            return source switch
            {
                // ReSharper disable once HeapView.PossibleBoxingAllocation
                // ReSharper disable once SuspiciousTypeConversion.Global
                ICollection<TSource> collection => BuildArrayFromCollection(collection),
                
                _ => BuildArray(source)
            };

            static TSource[] BuildArrayFromCollection(ICollection<TSource> collection)
            {
                var result = Utils.AllocateUninitializedArray<TSource>(collection.Count);
                collection.CopyTo(result, 0);
                return result;                
            }

            static TSource[] BuildArray(TEnumerable source)
            {
                using var arrayBuilder = ToArrayBuilder<TEnumerable, TEnumerator, TSource>(source, ArrayPool<TSource>.Shared, false);
                return arrayBuilder.ToArray();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueMemoryOwner<TSource> ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source, ArrayPool<TSource> pool, bool clearOnDispose = default)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            return source switch
            {
                // ReSharper disable once HeapView.PossibleBoxingAllocation
                // ReSharper disable once SuspiciousTypeConversion.Global
                ICollection<TSource> collection => BuildArrayFromCollection(collection, pool, clearOnDispose),
                
                _ => BuildArray(source, pool, clearOnDispose)
            };

            static ValueMemoryOwner<TSource> BuildArrayFromCollection(ICollection<TSource> collection, ArrayPool<TSource> pool, bool clearOnDispose)
            {
                var result = pool.RentDisposable(collection.Count, clearOnDispose);
                collection.CopyTo(result.Rented, 0);
                return result;
            }

            static ValueMemoryOwner<TSource> BuildArray(TEnumerable source, ArrayPool<TSource> pool, bool clearOnDispose)
            {
                using var arrayBuilder = ToArrayBuilder<TEnumerable, TEnumerator, TSource>(source, pool, clearOnDispose);
                return arrayBuilder.ToArray(pool, clearOnDispose);
            }            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TSource[] ToArray<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            using var arrayBuilder = ToArrayBuilder<TEnumerable, TEnumerator, TSource, TPredicate>(source, ArrayPool<TSource>.Shared, false, predicate);
            return arrayBuilder.ToArray();
        }

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ValueMemoryOwner<TSource> ToArray<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, ArrayPool<TSource> pool, bool clearOnDispose, TPredicate predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            using var arrayBuilder = ToArrayBuilder<TEnumerable, TEnumerator, TSource, TPredicate>(source, pool, clearOnDispose, predicate);
            return arrayBuilder.ToArray(pool, clearOnDispose);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TSource[] ToArrayAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            using var arrayBuilder = ToArrayBuilderAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, ArrayPool<TSource>.Shared, false, predicate);
            return arrayBuilder.ToArray();
        }

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ValueMemoryOwner<TSource> ToArrayAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, ArrayPool<TSource> pool, bool clearOnDispose, TPredicate predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            using var arrayBuilder = ToArrayBuilderAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, pool, clearOnDispose, predicate);
            return arrayBuilder.ToArray(pool, clearOnDispose);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            using var arrayBuilder = ToArrayBuilder<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, ArrayPool<TResult>.Shared, false, selector);
            return arrayBuilder.ToArray();
        }

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ValueMemoryOwner<TResult> ToArray<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, ArrayPool<TResult> pool, bool clearOnDispose, TSelector selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            using var arrayBuilder = ToArrayBuilder<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, pool, clearOnDispose, selector);
            return arrayBuilder.ToArray(pool, clearOnDispose);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArrayAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            using var arrayBuilder = ToArrayBuilderAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, ArrayPool<TResult>.Shared, false, selector);
            return arrayBuilder.ToArray();
        }

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ValueMemoryOwner<TResult> ToArrayAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, ArrayPool<TResult> pool, bool clearOnDispose, TSelector selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            using var arrayBuilder = ToArrayBuilderAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, pool, clearOnDispose, selector);
            return arrayBuilder.ToArray(pool, clearOnDispose);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TResult[] ToArray<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(this TEnumerable source, TPredicate predicate, TSelector selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            using var arrayBuilder = ToArrayBuilder<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(source, ArrayPool<TResult>.Shared, false, predicate, selector);
            return arrayBuilder.ToArray();
        }

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ValueMemoryOwner<TResult> ToArray<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(this TEnumerable source, ArrayPool<TResult> pool, bool clearOnDispose, TPredicate predicate, TSelector selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            using var arrayBuilder = ToArrayBuilder<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(source, pool, clearOnDispose, predicate, selector);
            return arrayBuilder.ToArray(pool, clearOnDispose);
        }
    }
}