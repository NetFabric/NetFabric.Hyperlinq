using System;
using System.Buffers;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static partial class ArrayExtensions
    {
        [GeneratorIgnore(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TSource>(this ReadOnlySpan<TSource> source)
            => source.ToArray();

        [GeneratorIgnore(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TSource>(this ReadOnlySpan<TSource> source, MemoryPool<TSource> pool)
        {
            return source switch
            {
                { Length: 0 } => pool.Rent(0),
                _ => BuildArray(source, pool)
            };

            static IMemoryOwner<TSource> BuildArray(ReadOnlySpan<TSource> source, MemoryPool<TSource> pool)
            {
                var result = pool.RentSliced(source.Length);
                Copy(source, result.Memory.Span);
                return result;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, bool>
        {
            return source switch
            {
                { Length: 0 } => Array.Empty<TSource>(),
                _ => BuildArray(source, predicate)
            };

            static TSource[] BuildArray(ReadOnlySpan<TSource> source, TPredicate predicate)
            {
                using var arrayBuilder = ToArrayBuilder(source, ArrayPool<TSource>.Shared, predicate);
                return arrayBuilder.ToArray();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TSource, TPredicate>(this ReadOnlySpan<TSource> source, MemoryPool<TSource> pool, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, bool>
        {
            return source switch
            {
                { Length: 0 } => pool.Rent(0),
                _ => BuildArray(source, pool, predicate)
            };

            static IMemoryOwner<TSource> BuildArray(ReadOnlySpan<TSource> source, MemoryPool<TSource> pool, TPredicate predicate)
            {
                using var arrayBuilder = ToArrayBuilder(source, ArrayPool<TSource>.Shared, predicate);
                return arrayBuilder.ToArray(pool);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArrayAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            return source switch
            {
                { Length: 0 } => Array.Empty<TSource>(),
                _ => BuildArray(source, predicate)
            };

            static TSource[] BuildArray(ReadOnlySpan<TSource> source, TPredicate predicate)
            {
                using var arrayBuilder = ToArrayBuilderAt(source, ArrayPool<TSource>.Shared, predicate);
                return arrayBuilder.ToArray();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArrayAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, MemoryPool<TSource> pool, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            return source switch
            {
                { Length: 0 } => pool.Rent(0),
                _ => BuildArray(source, pool, predicate)
            };

            static IMemoryOwner<TSource> BuildArray(ReadOnlySpan<TSource> source, MemoryPool<TSource> pool, TPredicate predicate)
            {
                using var arrayBuilder = ToArrayBuilderAt(source, ArrayPool<TSource>.Shared, predicate);
                return arrayBuilder.ToArray(pool);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
        {
            return source switch
            {
                { Length: 0 } => Array.Empty<TResult>(),
                _ => BuildArray(source, selector)
            };

            static TResult[] BuildArray(ReadOnlySpan<TSource> source, TSelector selector)
            {
                var result = Utils.AllocateUninitializedArray<TResult>(source.Length);
                Copy(source, result.AsSpan(), selector);
                return result;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArrayVector<TSource, TResult, TVectorSelector, TSelector>(this ReadOnlySpan<TSource> source, TVectorSelector vectorSelector, TSelector selector)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
        {
            return source switch
            {
                { Length: 0 } => Array.Empty<TResult>(),
                _ => BuildArray(source, vectorSelector, selector)
            };

            static TResult[] BuildArray(ReadOnlySpan<TSource> source, TVectorSelector vectorSelector, TSelector selector)
            {
                var result = Utils.AllocateUninitializedArray<TResult>(source.Length);
                CopyVector(source, result.AsSpan(), vectorSelector, selector);
                return result;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArrayVector<TSource, TResult, TVectorSelector, TSelector>(this ReadOnlySpan<TSource> source, MemoryPool<TResult> pool, TVectorSelector vectorSelector, TSelector selector)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
        {
            return source switch
            {
                { Length: 0 } => pool.Rent(0),
                _ => BuildArray(source, pool, vectorSelector, selector)
            };

            static IMemoryOwner<TResult> BuildArray(ReadOnlySpan<TSource> source, MemoryPool<TResult> pool, TVectorSelector vectorSelector, TSelector selector)
            {
                var result = pool.RentSliced(source.Length);
                CopyVector(source, result.Memory.Span, vectorSelector, selector);
                return result;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, MemoryPool<TResult> pool, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
        {
            return source switch
            {
                { Length: 0 } => pool.Rent(0),
                _ => BuildArray(source, pool, selector)
            };

            static IMemoryOwner<TResult> BuildArray(ReadOnlySpan<TSource> source, MemoryPool<TResult> pool, TSelector selector)
            {
                var result = pool.RentSliced(source.Length);
                Copy(source, result.Memory.Span, selector);
                return result;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArrayAt<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            return source switch
            {
                { Length: 0 } => Array.Empty<TResult>(),
                _ => BuildArray(source, selector)
            };

            static TResult[] BuildArray(ReadOnlySpan<TSource> source, TSelector selector)
            {
                var result = Utils.AllocateUninitializedArray<TResult>(source.Length);
                CopyAt(source, result.AsSpan(), selector);
                return result;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArrayAt<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, MemoryPool<TResult> pool, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            return source switch
            {
                { Length: 0 } => pool.Rent(0),
                _ => BuildArray(source, pool, selector)
            };

            static IMemoryOwner<TResult> BuildArray(ReadOnlySpan<TSource> source, MemoryPool<TResult> pool, TSelector selector)
            {
                var result = pool.RentSliced(source.Length);
                CopyAt(source, result.Memory.Span, selector);
                return result;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult, TPredicate, TSelector>(this ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            return source switch
            {
                { Length: 0 } => Array.Empty<TResult>(),
                _ => BuildArray(source, predicate, selector)
            };

            static TResult[] BuildArray(ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector)
            {
                using var arrayBuilder = ToArrayBuilder(source, ArrayPool<TResult>.Shared, predicate, selector);
                return arrayBuilder.ToArray();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult, TPredicate, TSelector>(this ReadOnlySpan<TSource> source, MemoryPool<TResult> pool, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            return source switch
            {
                { Length: 0 } => pool.Rent(0),
                _ => BuildArray(source, pool, predicate, selector)
            };

            static IMemoryOwner<TResult> BuildArray(ReadOnlySpan<TSource> source, MemoryPool<TResult> pool, TPredicate predicate, TSelector selector)
            {
                using var arrayBuilder = ToArrayBuilder(source, ArrayPool<TResult>.Shared, predicate, selector);
                return arrayBuilder.ToArray(pool);
            }
        }
    }
}

