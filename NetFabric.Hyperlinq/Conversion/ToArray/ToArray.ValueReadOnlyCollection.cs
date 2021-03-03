using System;
using System.Buffers;
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
                var result = Utils.AllocateUninitializedArray<TSource>(source.Count);
                Copy<TEnumerable, TEnumerator, TSource>(source, result);
                return result;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TSource> ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source, MemoryPool<TSource> pool)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            return source switch
            {
                { Count: 0 } => pool.Rent(0),
                _ => BuildArray(source, pool)
            };

            static IMemoryOwner<TSource> BuildArray(TEnumerable source, MemoryPool<TSource> pool)
            {
                var result = pool.RentSliced(source.Count);
                Copy<TEnumerable, TEnumerator, TSource>(source, result.Memory.Span);
                return result;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, MemoryPool<TSource> pool)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            => source switch
            {
                { Count: 0 } => pool.Rent(0),
                _ => ValueEnumerableExtensions.ToArray<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate, pool)
            };

        //////////////////////////////////////////////////////////////////////////////////////////////////

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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArrayAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, MemoryPool<TSource> pool)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source switch
            {
                { Count: 0 } => pool.Rent(0),
                _ => ValueEnumerableExtensions.ToArrayAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate, pool)
            };

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector)
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector, MemoryPool<TResult> pool)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            return source switch
            {
                { Count: 0 } => pool.Rent(0),
                _ => BuildArray(source, selector, pool)
            };

            static IMemoryOwner<TResult> BuildArray(TEnumerable source, TSelector selector, MemoryPool<TResult> pool)
            {
                var result = pool.RentSliced(source.Count);
                Copy<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, result.Memory.Span, selector);
                return result;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArrayAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector)
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArrayAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector, MemoryPool<TResult> pool)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            return source switch
            {
                { Count: 0 } => pool.Rent(0),
                _ => BuildArray(source, selector, pool)
            };

            static IMemoryOwner<TResult> BuildArray(TEnumerable source, TSelector selector, MemoryPool<TResult> pool)
            {
                var result = pool.RentSliced(source.Count);
                CopyAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, result.Memory.Span, selector);
                return result;
            }
        }
        
        //////////////////////////////////////////////////////////////////////////////////////////////////

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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(this TEnumerable source, TPredicate predicate, TSelector selector, MemoryPool<TResult> pool)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            => source switch
            {
                { Count: 0 } => pool.Rent(0),
                _ => ValueEnumerableExtensions.ToArray<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(source, predicate, selector, pool)
            };
    }
}
