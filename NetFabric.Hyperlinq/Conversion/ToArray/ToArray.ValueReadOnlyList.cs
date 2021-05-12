using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyListExtensions
    {
        [GeneratorIgnore(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TSource[] ToArray<TList, TSource>(this TList source)
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
                var result = Utils.AllocateUninitializedArray<TSource>(count);
                Copy(source, offset, result.AsSpan(), count);
                return result;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ValueMemoryOwner<TSource> ToArray<TList, TSource>(this TList source, ArrayPool<TSource> pool, bool clearOnDispose, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
        {
            var result = pool.RentSliced(count, clearOnDispose);
            Copy(source, offset, result.Memory.Span, count);
            return result;
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
                using var arrayBuilder = ToArrayBuilder(source, ArrayPool<TSource>.Shared, false, predicate, offset, count);
                return arrayBuilder.ToArray();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ValueMemoryOwner<TSource> ToArray<TList, TSource, TPredicate>(this TList source, ArrayPool<TSource> pool, bool clearOnDispose, TPredicate predicate, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            using var arrayBuilder = ToArrayBuilder(source, pool, clearOnDispose, predicate, offset, count);
            return arrayBuilder.ToArray(pool, clearOnDispose);
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
                using var arrayBuilder = ToArrayBuilderAt(source, ArrayPool<TSource>.Shared, false, predicate, offset, count);
                return arrayBuilder.ToArray();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ValueMemoryOwner<TSource> ToArrayAt<TList, TSource, TPredicate>(this TList source, ArrayPool<TSource> pool, bool clearOnDispose, TPredicate predicate, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            using var arrayBuilder = ToArrayBuilderAt(source, pool, clearOnDispose, predicate, offset, count);
            return arrayBuilder.ToArray(pool, clearOnDispose);
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
        static ValueMemoryOwner<TResult> ToArray<TList, TSource, TResult, TSelector>(this TList source, ArrayPool<TResult> pool, bool clearOnDispose, TSelector selector, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            var result = pool.RentSliced(count, clearOnDispose);
            Copy<TList, TSource, TResult, TSelector>(source, offset, result.Memory.Span, count, selector);
            return result;
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
        static ValueMemoryOwner<TResult> ToArrayAt<TList, TSource, TResult, TSelector>(this TList source, ArrayPool<TResult> pool, bool clearOnDispose, TSelector selector, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            var result = pool.RentSliced(count, clearOnDispose);
            CopyAt<TList, TSource, TResult, TSelector>(source, offset, result.Memory.Span, count, selector);
            return result;
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
                using var arrayBuilder = ToArrayBuilder<TList, TSource, TResult, TPredicate, TSelector>(source, ArrayPool<TResult>.Shared, false, predicate, selector, offset, count);
                return arrayBuilder.ToArray();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ValueMemoryOwner<TResult> ToArray<TList, TSource, TResult, TPredicate, TSelector>(this TList source, ArrayPool<TResult> pool, bool clearOnDispose, TPredicate predicate, TSelector selector, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            using var arrayBuilder = ToArrayBuilder<TList, TSource, TResult, TPredicate, TSelector>(source, pool, clearOnDispose, predicate, selector, offset, count);
            return arrayBuilder.ToArray(pool, clearOnDispose);
        }
    }
}

