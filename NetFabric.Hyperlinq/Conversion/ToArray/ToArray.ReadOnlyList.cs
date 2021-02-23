using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource[] ToArray<TList, TSource>(this TList source)
            where TList : struct, IReadOnlyList<TSource>
            => source.ToArray<TList, TSource>(0, source.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TList, TSource>(this TList source, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
        {
            return count switch
            {
                0 => Array.Empty<TSource>(),
                _ => BuildArray(source, offset, count)
            };

            static TSource[] BuildArray(TList source, int offset, int count)
            {
#if NET5_0
                var result = GC.AllocateUninitializedArray<TSource>(count);
#else
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                var result = new TSource[count];
#endif
                Copy(source, offset, result.AsSpan(), count);
                return result;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TSource> ToArray<TList, TSource>(this TList source, MemoryPool<TSource> pool)
            where TList : struct, IReadOnlyList<TSource>
            => source.ToArray(0, source.Count, pool);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TList, TSource>(this TList source, int offset, int count, MemoryPool<TSource> pool)
            where TList : struct, IReadOnlyList<TSource>
        {
            return count switch
            {
                0 => pool.Rent(0),
                _ => BuildArray(source, offset, count, pool)
            };

            static IMemoryOwner<TSource> BuildArray(TList source, int offset, int count,
                MemoryPool<TSource> pool)
            {
                var result = pool.RentSliced(count);
                Copy(source, offset, result.Memory.Span, count);
                return result;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            return count switch
            {
                0 => Array.Empty<TSource>(),
                _ => BuildArray(source, predicate, offset, count)
            };

            static TSource[] BuildArray(TList source, TPredicate predicate, int offset, int count)
            {
                using var arrayBuilder = ToArrayBuilder(source, predicate, offset, count, ArrayPool<TSource>.Shared);
                return arrayBuilder.ToArray();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count, MemoryPool<TSource> pool)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            return count switch
            {
                0 => pool.Rent(0),
                _ => BuildArray(source, predicate, offset, count, pool)
            };

            static IMemoryOwner<TSource> BuildArray(TList source, TPredicate predicate, int offset, int count, MemoryPool<TSource> pool)
            {
                using var arrayBuilder = ToArrayBuilder(source, predicate, offset, count, ArrayPool<TSource>.Shared);
                return arrayBuilder.ToArray(pool);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArrayAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            return count switch
            {
                0 => Array.Empty<TSource>(),
                _ => BuildArray(source, predicate, offset, count)
            };

            static TSource[] BuildArray(TList source, TPredicate predicate, int offset, int count)
            {
                using var arrayBuilder = ToArrayBuilderAt(source, predicate, offset, count, ArrayPool<TSource>.Shared);
                return arrayBuilder.ToArray();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArrayAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count, MemoryPool<TSource> pool)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            return count switch
            {
                0 => pool.Rent(0),
                _ => BuildArray(source, predicate, offset, count, pool)
            };

            static IMemoryOwner<TSource> BuildArray(TList source, TPredicate predicate, int offset, int count, MemoryPool<TSource> pool)
            {
                using var arrayBuilder = ToArrayBuilderAt(source, predicate, offset, count, ArrayPool<TSource>.Shared);
                return arrayBuilder.ToArray(pool);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TList, TSource, TResult, TSelector>(this TList source, TSelector selector, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            return count switch
            {
                0 => Array.Empty<TResult>(),
                _ => BuildArray(source, selector, offset, count)
            };

            static TResult[] BuildArray(TList source, TSelector selector, int offset, int count)
            {
#if NET5_0
                var result = GC.AllocateUninitializedArray<TResult>(count);
#else
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                var result = new TResult[count];
#endif
                Copy<TList, TSource, TResult, TSelector>(source, offset, result.AsSpan(), count, selector);
                return result;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TList, TSource, TResult, TSelector>(this TList source, TSelector selector, int offset, int count, MemoryPool<TResult> pool)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            return count switch
            {
                0 => pool.Rent(0),
                _ => BuildArray(source, selector, offset, count, pool)
            };

            static IMemoryOwner<TResult> BuildArray(TList source, TSelector selector, int offset, int count, MemoryPool<TResult> pool)
            {
                var result = pool.RentSliced(count);
                Copy<TList, TSource, TResult, TSelector>(source, offset, result.Memory.Span, count, selector);
                return result;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArrayAt<TList, TSource, TResult, TSelector>(this TList source, TSelector selector, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            return count switch
            {
                0 => Array.Empty<TResult>(),
                _ => BuildArray(source, selector, offset, count)
            };

            static TResult[] BuildArray(TList source, TSelector selector, int offset, int count)
            {
#if NET5_0
                var result = GC.AllocateUninitializedArray<TResult>(count);
#else
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                var result = new TResult[count];
#endif
                CopyAt<TList, TSource, TResult, TSelector>(source, offset, result.AsSpan(), count, selector);
                return result;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArrayAt<TList, TSource, TResult, TSelector>(this TList source, TSelector selector, int offset, int count, MemoryPool<TResult> pool)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            return count switch
            {
                0 => pool.Rent(0),
                _ => BuildArray(source, selector, offset, count, pool)
            };

            static IMemoryOwner<TResult> BuildArray(TList source, TSelector selector, int offset, int count, MemoryPool<TResult> pool)
            {
                var result = pool.RentSliced(count);
                CopyAt<TList, TSource, TResult, TSelector>(source, offset, result.Memory.Span, count, selector);
                return result;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TList, TSource, TResult, TPredicate, TSelector>(this TList source, TPredicate predicate, TSelector selector, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            return count switch
            {
                0 => Array.Empty<TResult>(),
                _ => BuildArray(source, predicate, selector, offset, count)
            };

            static TResult[] BuildArray(TList source, TPredicate predicate, TSelector selector, int offset, int count)
            {
                using var arrayBuilder = ToArrayBuilder<TList, TSource, TResult, TPredicate, TSelector>(source, predicate, selector, offset, count, ArrayPool<TResult>.Shared);
                return arrayBuilder.ToArray();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TList, TSource, TResult, TPredicate, TSelector>(this TList source, TPredicate predicate, TSelector selector, int offset, int count, MemoryPool<TResult> pool)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            return count switch
            {
                0 => pool.Rent(0),
                _ => BuildArray(source, predicate, selector, offset, count, pool)
            };

            static IMemoryOwner<TResult> BuildArray(TList source, TPredicate predicate, TSelector selector, int offset, int count, MemoryPool<TResult> pool)
            {
                using var arrayBuilder = ToArrayBuilder<TList, TSource, TResult, TPredicate, TSelector>(source, predicate, selector, offset, count, ArrayPool<TResult>.Shared);
                return arrayBuilder.ToArray(pool);
            }
        }
    }
}

