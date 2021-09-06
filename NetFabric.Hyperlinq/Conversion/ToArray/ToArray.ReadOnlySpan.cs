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

        public static IMemoryOwner<TSource> ToArray<TSource>(this ReadOnlySpan<TSource> source, ArrayPool<TSource> pool, bool clearOnDispose = default)
        {
            if (source.Length is 0)
                return EmptyMemoryOwner<TSource>.Instance;

            var result = pool.RentDisposable(source.Length, clearOnDispose);
            Copy(source, result.Memory.Span);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [GeneratorIgnore]
        static TSource[] ToArray<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, bool>
        {
            if (source.Length is 0)
                return Array.Empty<TSource>();

            using var arrayBuilder = ToArrayBuilder(source, ArrayPool<TSource>.Shared, clearOnDispose: false, predicate);
            return arrayBuilder.ToArray();
        }

        [GeneratorIgnore]
        static IMemoryOwner<TSource> ToArray<TSource, TPredicate>(this ReadOnlySpan<TSource> source, ArrayPool<TSource> pool, bool clearOnDispose, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, bool>
        {
            if (source.Length is 0)
                return EmptyMemoryOwner<TSource>.Instance;

            using var arrayBuilder = ToArrayBuilder(source, pool, clearOnDispose, predicate);
            return arrayBuilder.ToArray(pool, clearOnDispose);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [GeneratorIgnore]
        static TSource[] ToArrayAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            if (source.Length is 0)
                return Array.Empty<TSource>();
            
            using var arrayBuilder = ToArrayBuilderAt(source, ArrayPool<TSource>.Shared, clearOnDispose: false, predicate);
            return arrayBuilder.ToArray();
        }

        [GeneratorIgnore]
        static IMemoryOwner<TSource> ToArrayAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, ArrayPool<TSource> pool, bool clearOnDispose, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            if (source.Length is 0)
                return EmptyMemoryOwner<TSource>.Instance;

            using var arrayBuilder = ToArrayBuilderAt(source, pool, clearOnDispose, predicate);
            return arrayBuilder.ToArray(pool, clearOnDispose);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [GeneratorIgnore]
        static TResult[] ToArray<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
        {
            if (source.Length is 0)
                return Array.Empty<TResult>();

            var result = Utils.AllocateUninitializedArray<TResult>(source.Length);
            Copy(source, result.AsSpan(), selector);
            return result;
        }

        [GeneratorIgnore]
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

        [GeneratorIgnore]
        static IMemoryOwner<TResult> ToArrayVector<TSource, TResult, TVectorSelector, TSelector>(this ReadOnlySpan<TSource> source, ArrayPool<TResult> pool, bool clearOnDispose, TVectorSelector vectorSelector, TSelector selector)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
        {
            if (source.Length is 0)
                return EmptyMemoryOwner<TResult>.Instance;

            var result = pool.RentDisposable(source.Length, clearOnDispose);
            CopyVector(source, result.Memory.Span, vectorSelector, selector);
            return result;
        }

        [GeneratorIgnore]
        static IMemoryOwner<TResult> ToArray<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, ArrayPool<TResult> pool, bool clearOnDispose, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
        {
            if (source.Length is 0)
                return EmptyMemoryOwner<TResult>.Instance;

            var result = pool.RentDisposable(source.Length, clearOnDispose);
            Copy(source, result.Memory.Span, selector);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [GeneratorIgnore]
        static TResult[] ToArrayAt<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            if (source.Length is 0)
                return Array.Empty<TResult>();
            
            var result = Utils.AllocateUninitializedArray<TResult>(source.Length);
            CopyAt(source, result.AsSpan(), selector);
            return result;
        }

        [GeneratorIgnore]
        static IMemoryOwner<TResult> ToArrayAt<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, ArrayPool<TResult> pool, bool clearOnDispose, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            if (source.Length is 0)
                return EmptyMemoryOwner<TResult>.Instance;

            var result = pool.RentDisposable(source.Length, clearOnDispose);
            CopyAt(source, result.Memory.Span, selector);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [GeneratorIgnore]
        static TResult[] ToArray<TSource, TResult, TPredicate, TSelector>(this ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            if (source.Length is 0)
                return Array.Empty<TResult>();

            using var arrayBuilder = ToArrayBuilder(source, ArrayPool<TResult>.Shared, false, predicate, selector);
            return arrayBuilder.ToArray();
        }

        [GeneratorIgnore]
        static IMemoryOwner<TResult> ToArray<TSource, TResult, TPredicate, TSelector>(this ReadOnlySpan<TSource> source, ArrayPool<TResult> pool, bool clearOnDispose, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            if (source.Length is 0)
                return EmptyMemoryOwner<TResult>.Instance;

            using var arrayBuilder = ToArrayBuilder(source, pool, clearOnDispose, predicate, selector);
            return arrayBuilder.ToArray(pool, clearOnDispose);
        }
    }
}

