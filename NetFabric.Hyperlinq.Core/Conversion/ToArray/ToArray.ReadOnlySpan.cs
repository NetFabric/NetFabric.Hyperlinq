using System;
using System.Buffers;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TSource>(this ReadOnlySpan<TSource> source)
            => source.ToArray();

        public static Lease<TSource> ToArray<TSource>(this ReadOnlySpan<TSource> source, ArrayPool<TSource> pool, bool clearOnDispose = default)
        {
            if (source.Length is 0)
                return Lease.Empty<TSource>();

            var result = pool.Lease(source.Length, clearOnDispose);
            Copy(source, result.Memory.Span);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        static TSource[] ToArray<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, bool>
        {
            if (source.Length is 0)
                return Array.Empty<TSource>();

            using var arrayBuilder = ToArrayBuilder(source, ArrayPool<TSource>.Shared, clearOnDispose: false, predicate);
            return arrayBuilder.ToArray();
        }

        static Lease<TSource> ToArray<TSource, TPredicate>(this ReadOnlySpan<TSource> source, ArrayPool<TSource> pool, bool clearOnDispose, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, bool>
        {
            if (source.Length is 0)
                return Lease.Empty<TSource>();

            using var arrayBuilder = ToArrayBuilder(source, pool, clearOnDispose, predicate);
            return arrayBuilder.ToArray(pool, clearOnDispose);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        static TSource[] ToArrayAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            if (source.Length is 0)
                return Array.Empty<TSource>();
            
            using var arrayBuilder = ToArrayBuilderAt(source, ArrayPool<TSource>.Shared, clearOnDispose: false, predicate);
            return arrayBuilder.ToArray();
        }

        static Lease<TSource> ToArrayAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, ArrayPool<TSource> pool, bool clearOnDispose, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            if (source.Length is 0)
                return Lease.Empty<TSource>();

            using var arrayBuilder = ToArrayBuilderAt(source, pool, clearOnDispose, predicate);
            return arrayBuilder.ToArray(pool, clearOnDispose);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        static TResult[] ToArray<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
        {
            if (source.Length is 0)
                return Array.Empty<TResult>();

            var result = Utils.AllocateUninitializedArray<TResult>(source.Length);
            Copy(source, result.AsSpan(), selector);
            return result;
        }

        static TResult[] ToArrayVector<TSource, TResult, TVectorSelector, TSelector>(this ReadOnlySpan<TSource> source, TVectorSelector vectorSelector, TSelector selector)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
        {
            if (source.Length is 0)
                return Array.Empty<TResult>();
            
            var result = Utils.AllocateUninitializedArray<TResult>(source.Length);
            CopyVector(source, result.AsSpan(), vectorSelector, selector);
            return result;
        }

        static Lease<TResult> ToArrayVector<TSource, TResult, TVectorSelector, TSelector>(this ReadOnlySpan<TSource> source, ArrayPool<TResult> pool, bool clearOnDispose, TVectorSelector vectorSelector, TSelector selector)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
        {
            if (source.Length is 0)
                return Lease.Empty<TResult>();

            var result = pool.Lease(source.Length, clearOnDispose);
            CopyVector(source, result.Memory.Span, vectorSelector, selector);
            return result;
        }

        static Lease<TResult> ToArray<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, ArrayPool<TResult> pool, bool clearOnDispose, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
        {
            if (source.Length is 0)
                return Lease.Empty<TResult>();

            var result = pool.Lease(source.Length, clearOnDispose);
            Copy(source, result.Memory.Span, selector);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        static TResult[] ToArrayAt<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            if (source.Length is 0)
                return Array.Empty<TResult>();
            
            var result = Utils.AllocateUninitializedArray<TResult>(source.Length);
            CopyAt(source, result.AsSpan(), selector);
            return result;
        }

        static Lease<TResult> ToArrayAt<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, ArrayPool<TResult> pool, bool clearOnDispose, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            if (source.Length is 0)
                return Lease.Empty<TResult>();

            var result = pool.Lease(source.Length, clearOnDispose);
            CopyAt(source, result.Memory.Span, selector);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        static TResult[] ToArray<TSource, TResult, TPredicate, TSelector>(this ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            if (source.Length is 0)
                return Array.Empty<TResult>();

            using var arrayBuilder = ToArrayBuilder(source, ArrayPool<TResult>.Shared, false, predicate, selector);
            return arrayBuilder.ToArray();
        }

        static Lease<TResult> ToArray<TSource, TResult, TPredicate, TSelector>(this ReadOnlySpan<TSource> source, ArrayPool<TResult> pool, bool clearOnDispose, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            if (source.Length is 0)
                return Lease.Empty<TResult>();

            using var arrayBuilder = ToArrayBuilder(source, pool, clearOnDispose, predicate, selector);
            return arrayBuilder.ToArray(pool, clearOnDispose);
        }
    }
}

