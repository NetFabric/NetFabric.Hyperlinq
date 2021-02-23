using System;
using System.Buffers;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TSource> ToArray<TSource>(this ReadOnlySpan<TSource> source, MemoryPool<TSource> pool)
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
                using var arrayBuilder = ToArrayBuilder(source, predicate, ArrayPool<TSource>.Shared);
                return arrayBuilder.ToArray();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArrayRef<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunctionIn<TSource, bool>
        {
            return source switch
            {
                { Length: 0 } => Array.Empty<TSource>(),
                _ => BuildArray(source, predicate)
            };

            static TSource[] BuildArray(ReadOnlySpan<TSource> source, TPredicate predicate)
            {
                using var arrayBuilder = ToArrayBuilderRef(source, predicate, ArrayPool<TSource>.Shared);
                return arrayBuilder.ToArray();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate, MemoryPool<TSource> pool)
            where TPredicate : struct, IFunction<TSource, bool>
        {
            return source switch
            {
                { Length: 0 } => pool.Rent(0),
                _ => BuildArray(source, predicate, pool)
            };

            static IMemoryOwner<TSource> BuildArray(ReadOnlySpan<TSource> source, TPredicate predicate, MemoryPool<TSource> pool)
            {
                using var arrayBuilder = ToArrayBuilder(source, predicate, ArrayPool<TSource>.Shared);
                return arrayBuilder.ToArray(pool);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArrayRef<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate, MemoryPool<TSource> pool)
            where TPredicate : struct, IFunctionIn<TSource, bool>
        {
            return source switch
            {
                { Length: 0 } => pool.Rent(0),
                _ => BuildArray(source, predicate, pool)
            };

            static IMemoryOwner<TSource> BuildArray(ReadOnlySpan<TSource> source, TPredicate predicate, MemoryPool<TSource> pool)
            {
                using var arrayBuilder = ToArrayBuilderRef(source, predicate, ArrayPool<TSource>.Shared);
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
                using var arrayBuilder = ToArrayBuilderAt(source, predicate, ArrayPool<TSource>.Shared);
                return arrayBuilder.ToArray();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArrayAtRef<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
        {
            return source switch
            {
                { Length: 0 } => Array.Empty<TSource>(),
                _ => BuildArray(source, predicate)
            };

            static TSource[] BuildArray(ReadOnlySpan<TSource> source, TPredicate predicate)
            {
                using var arrayBuilder = ToArrayBuilderAtRef(source, predicate, ArrayPool<TSource>.Shared);
                return arrayBuilder.ToArray();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArrayAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate, MemoryPool<TSource> pool)
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            return source switch
            {
                { Length: 0 } => pool.Rent(0),
                _ => BuildArray(source, predicate, pool)
            };

            static IMemoryOwner<TSource> BuildArray(ReadOnlySpan<TSource> source, TPredicate predicate, MemoryPool<TSource> pool)
            {
                using var arrayBuilder = ToArrayBuilderAt(source, predicate, ArrayPool<TSource>.Shared);
                return arrayBuilder.ToArray(pool);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArrayAtRef<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate, MemoryPool<TSource> pool)
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
        {
            return source switch
            {
                { Length: 0 } => pool.Rent(0),
                _ => BuildArray(source, predicate, pool)
            };

            static IMemoryOwner<TSource> BuildArray(ReadOnlySpan<TSource> source, TPredicate predicate, MemoryPool<TSource> pool)
            {
                using var arrayBuilder = ToArrayBuilderAtRef(source, predicate, ArrayPool<TSource>.Shared);
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
        static IMemoryOwner<TResult> ToArrayVector<TSource, TResult, TVectorSelector, TSelector>(this ReadOnlySpan<TSource> source, TVectorSelector vectorSelector, TSelector selector, MemoryPool<TResult> pool)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
        {
            return source switch
            {
                { Length: 0 } => pool.Rent(0),
                _ => BuildArray(source, vectorSelector, selector, pool)
            };

            static IMemoryOwner<TResult> BuildArray(ReadOnlySpan<TSource> source, TVectorSelector vectorSelector, TSelector selector, MemoryPool<TResult> pool)
            {
                var result = pool.RentSliced(source.Length);
                CopyVector<TSource, TResult, TVectorSelector, TSelector>(source, result.Memory.Span, vectorSelector, selector);
                return result;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArrayRef<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunctionIn<TSource, TResult>
        {
            return source switch
            {
                { Length: 0 } => Array.Empty<TResult>(),
                _ => BuildArray(source, selector)
            };

            static TResult[] BuildArray(ReadOnlySpan<TSource> source, TSelector selector)
            {
                var result = Utils.AllocateUninitializedArray<TResult>(source.Length);
                CopyRef(source, result.AsSpan(), selector);
                return result;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector, MemoryPool<TResult> pool)
            where TSelector : struct, IFunction<TSource, TResult>
        {
            return source switch
            {
                { Length: 0 } => pool.Rent(0),
                _ => BuildArray(source, selector, pool)
            };

            static IMemoryOwner<TResult> BuildArray(ReadOnlySpan<TSource> source, TSelector selector, MemoryPool<TResult> pool)
            {
                var result = pool.RentSliced(source.Length);
                Copy(source, result.Memory.Span, selector);
                return result;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArrayRef<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector, MemoryPool<TResult> pool)
            where TSelector : struct, IFunctionIn<TSource, TResult>
        {
            return source switch
            {
                { Length: 0 } => pool.Rent(0),
                _ => BuildArray(source, selector, pool)
            };

            static IMemoryOwner<TResult> BuildArray(ReadOnlySpan<TSource> source, TSelector selector, MemoryPool<TResult> pool)
            {
                var result = pool.RentSliced(source.Length);
                CopyRef(source, result.Memory.Span, selector);
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
        static TResult[] ToArrayAtRef<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunctionIn<TSource, int, TResult>
        {
            return source switch
            {
                { Length: 0 } => Array.Empty<TResult>(),
                _ => BuildArray(source, selector)
            };

            static TResult[] BuildArray(ReadOnlySpan<TSource> source, TSelector selector)
            {
                var result = Utils.AllocateUninitializedArray<TResult>(source.Length);
                CopyAtRef(source, result.AsSpan(), selector);
                return result;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArrayAt<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector, MemoryPool<TResult> pool)
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            return source switch
            {
                { Length: 0 } => pool.Rent(0),
                _ => BuildArray(source, selector, pool)
            };

            static IMemoryOwner<TResult> BuildArray(ReadOnlySpan<TSource> source, TSelector selector, MemoryPool<TResult> pool)
            {
                var result = pool.RentSliced(source.Length);
                CopyAt(source, result.Memory.Span, selector);
                return result;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArrayAtRef<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector, MemoryPool<TResult> pool)
            where TSelector : struct, IFunctionIn<TSource, int, TResult>
        {
            return source switch
            {
                { Length: 0 } => pool.Rent(0),
                _ => BuildArray(source, selector, pool)
            };

            static IMemoryOwner<TResult> BuildArray(ReadOnlySpan<TSource> source, TSelector selector, MemoryPool<TResult> pool)
            {
                var result = pool.RentSliced(source.Length);
                CopyAtRef(source, result.Memory.Span, selector);
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
                using var arrayBuilder = ToArrayBuilder(source, predicate, selector, ArrayPool<TResult>.Shared);
                return arrayBuilder.ToArray();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArrayRef<TSource, TResult, TPredicate, TSelector>(this ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSelector : struct, IFunctionIn<TSource, TResult>
        {
            return source switch
            {
                { Length: 0 } => Array.Empty<TResult>(),
                _ => BuildArray(source, predicate, selector)
            };

            static TResult[] BuildArray(ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector)
            {
                using var arrayBuilder = ToArrayBuilderRef(source, predicate, selector, ArrayPool<TResult>.Shared);
                return arrayBuilder.ToArray();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult, TPredicate, TSelector>(this ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector, MemoryPool<TResult> pool)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            return source switch
            {
                { Length: 0 } => pool.Rent(0),
                _ => BuildArray(source, predicate, selector, pool)
            };

            static IMemoryOwner<TResult> BuildArray(ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector, MemoryPool<TResult> pool)
            {
                using var arrayBuilder = ToArrayBuilder(source, predicate, selector, ArrayPool<TResult>.Shared);
                return arrayBuilder.ToArray(pool);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArrayRef<TSource, TResult, TPredicate, TSelector>(this ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector, MemoryPool<TResult> pool)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSelector : struct, IFunctionIn<TSource, TResult>
        {
            return source switch
            {
                { Length: 0 } => pool.Rent(0),
                _ => BuildArray(source, predicate, selector, pool)
            };

            static IMemoryOwner<TResult> BuildArray(ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector, MemoryPool<TResult> pool)
            {
                using var arrayBuilder = ToArrayBuilderRef(source, predicate, selector, ArrayPool<TResult>.Shared);
                return arrayBuilder.ToArray(pool);
            }
        }
    }
}

