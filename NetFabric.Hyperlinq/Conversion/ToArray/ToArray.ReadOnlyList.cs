using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
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
                var result = Utils.AllocateUninitializedArray<TSource>(count);
                Copy(source, offset, result.AsSpan(), count);
                return result;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TSource> ToArray<TList, TSource>(this TList source, MemoryPool<TSource> pool)
            where TList : struct, IReadOnlyList<TSource>
            => source.ToArray(pool, 0, source.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TList, TSource>(this TList source, MemoryPool<TSource> pool, int offset, int count)
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
                using var arrayBuilder = ToArrayBuilder(source, ArrayPool<TSource>.Shared, predicate, offset, count);
                return arrayBuilder.ToArray();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TList, TSource, TPredicate>(this TList source, MemoryPool<TSource> pool, TPredicate predicate, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            return count switch
            {
                0 => pool.Rent(0),
                _ => BuildArray(source, pool, predicate, offset, count)
            };

            static IMemoryOwner<TSource> BuildArray(TList source, MemoryPool<TSource> pool, TPredicate predicate, int offset, int count)
            {
                using var arrayBuilder = ToArrayBuilder(source, ArrayPool<TSource>.Shared, predicate, offset, count);
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
                using var arrayBuilder = ToArrayBuilderAt(source, ArrayPool<TSource>.Shared, predicate, offset, count);
                return arrayBuilder.ToArray();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArrayAt<TList, TSource, TPredicate>(this TList source, MemoryPool<TSource> pool, TPredicate predicate, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            return count switch
            {
                0 => pool.Rent(0),
                _ => BuildArray(source, pool, predicate, offset, count)
            };

            static IMemoryOwner<TSource> BuildArray(TList source, MemoryPool<TSource> pool, TPredicate predicate, int offset, int count)
            {
                using var arrayBuilder = ToArrayBuilderAt(source, ArrayPool<TSource>.Shared, predicate, offset, count);
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
                var result = Utils.AllocateUninitializedArray<TResult>(count);
                Copy<TList, TSource, TResult, TSelector>(source, offset, result.AsSpan(), count, selector);
                return result;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TList, TSource, TResult, TSelector>(this TList source, MemoryPool<TResult> pool, TSelector selector, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            return count switch
            {
                0 => pool.Rent(0),
                _ => BuildArray(source, pool, selector, offset, count)
            };

            static IMemoryOwner<TResult> BuildArray(TList source, MemoryPool<TResult> pool, TSelector selector, int offset, int count)
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
                var result = Utils.AllocateUninitializedArray<TResult>(count);
                CopyAt<TList, TSource, TResult, TSelector>(source, offset, result.AsSpan(), count, selector);
                return result;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArrayAt<TList, TSource, TResult, TSelector>(this TList source, MemoryPool<TResult> pool, TSelector selector, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            return count switch
            {
                0 => pool.Rent(0),
                _ => BuildArray(source, pool, selector, offset, count)
            };

            static IMemoryOwner<TResult> BuildArray(TList source, MemoryPool<TResult> pool, TSelector selector, int offset, int count)
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
                using var arrayBuilder = ToArrayBuilder<TList, TSource, TResult, TPredicate, TSelector>(source, ArrayPool<TResult>.Shared, predicate, selector, offset, count);
                return arrayBuilder.ToArray();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TList, TSource, TResult, TPredicate, TSelector>(this TList source, MemoryPool<TResult> pool, TPredicate predicate, TSelector selector, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            return count switch
            {
                0 => pool.Rent(0),
                _ => BuildArray(source, pool, predicate, selector, offset, count)
            };

            static IMemoryOwner<TResult> BuildArray(TList source, MemoryPool<TResult> pool, TPredicate predicate, TSelector selector, int offset, int count)
            {
                using var arrayBuilder = ToArrayBuilder<TList, TSource, TResult, TPredicate, TSelector>(source, ArrayPool<TResult>.Shared, predicate, selector, offset, count);
                return arrayBuilder.ToArray(pool);
            }
        }
    }
}

