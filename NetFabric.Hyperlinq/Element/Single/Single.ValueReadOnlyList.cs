using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => GetSingle<TEnumerable, TEnumerator, TSource>(source, 0, source.Count).ThrowOnEmpty();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => GetSingle<TEnumerable, TEnumerator, TSource>(source, predicate, 0, source.Count).ThrowOnEmpty();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource SingleOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => GetSingle<TEnumerable, TEnumerator, TSource>(source, 0, source.Count).DefaultOnEmpty();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource SingleOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => GetSingle<TEnumerable, TEnumerator, TSource>(source, predicate, 0, source.Count).DefaultOnEmpty();

        [Pure]
        static (ElementResult Success, TSource Value) GetSingle<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count == 0 || skipCount > source.Count || takeCount < 1)
                return (ElementResult.Empty, default);

            if (takeCount > 1 && skipCount < source.Count)
                return (ElementResult.NotSingle, default);

            return (ElementResult.Success, source[skipCount]);
        }

        [Pure]
        static (ElementResult Success, TSource Value) GetSingle<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate, int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                {
                    var value = source[index];

                    for (index++; index < end; index++)
                    {
                        if (predicate(source[index]))
                            return (ElementResult.NotSingle, default);
                    }

                    return (ElementResult.Success, value);
                }
            }

            return (ElementResult.Empty, default);
        }

        [Pure]
        static (int Index, TSource Value) GetSingle<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate, int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = 0; index < end; index++)
            {
                if (predicate(source[index], index))
                {
                    var value = (index, source[index]);

                    for (index++; index < end; index++)
                    {
                        if (predicate(source[index], index))
                            return ((int)ElementResult.NotSingle, default);
                    }

                    return value;
                }
            }

            return ((int)ElementResult.Empty, default);
        }
    }
}
