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
        public static ValueMemoryOwner<TSource> ToArray<TSource>(this ReadOnlySpan<TSource> source, ArrayPool<TSource> pool, bool clearOnDispose = default)
        {
            var result = pool.RentSliced(source.Length, clearOnDispose);
            Copy(source, result.Memory.Span);
            return result;
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
                using var arrayBuilder = ToArrayBuilder(source, ArrayPool<TSource>.Shared, false, predicate);
                return arrayBuilder.ToArray();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ValueMemoryOwner<TSource> ToArray<TSource, TPredicate>(this ReadOnlySpan<TSource> source, ArrayPool<TSource> pool, bool clearOnDispose, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, bool>
        {
            using var arrayBuilder = ToArrayBuilder(source, pool, clearOnDispose, predicate);
            return arrayBuilder.ToArray(pool, clearOnDispose);
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
                using var arrayBuilder = ToArrayBuilderAt(source, ArrayPool<TSource>.Shared, false, predicate);
                return arrayBuilder.ToArray();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ValueMemoryOwner<TSource> ToArrayAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, ArrayPool<TSource> pool, bool clearOnDispose, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            using var arrayBuilder = ToArrayBuilderAt(source, pool, clearOnDispose, predicate);
            return arrayBuilder.ToArray(pool, clearOnDispose);
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
        static ValueMemoryOwner<TResult> ToArrayVector<TSource, TResult, TVectorSelector, TSelector>(this ReadOnlySpan<TSource> source, ArrayPool<TResult> pool, bool clearOnDispose, TVectorSelector vectorSelector, TSelector selector)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
        {
            var result = pool.RentSliced(source.Length, clearOnDispose);
            CopyVector(source, result.Memory.Span, vectorSelector, selector);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ValueMemoryOwner<TResult> ToArray<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, ArrayPool<TResult> pool, bool clearOnDispose, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
        {
            var result = pool.RentSliced(source.Length, clearOnDispose);
            Copy(source, result.Memory.Span, selector);
            return result;
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
        static ValueMemoryOwner<TResult> ToArrayAt<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, ArrayPool<TResult> pool, bool clearOnDispose, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            var result = pool.RentSliced(source.Length, clearOnDispose);
            CopyAt(source, result.Memory.Span, selector);
            return result;
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
                using var arrayBuilder = ToArrayBuilder(source, ArrayPool<TResult>.Shared, false, predicate, selector);
                return arrayBuilder.ToArray();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ValueMemoryOwner<TResult> ToArray<TSource, TResult, TPredicate, TSelector>(this ReadOnlySpan<TSource> source, ArrayPool<TResult> pool, bool clearOnDispose, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            using var arrayBuilder = ToArrayBuilder(source, pool, clearOnDispose, predicate, selector);
            return arrayBuilder.ToArray(pool, clearOnDispose);
        }
    }
}

