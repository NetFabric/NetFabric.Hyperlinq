using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource First<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => TryFirst<TEnumerable, TEnumerator, TSource>(source).ThrowOnEmpty();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource FirstOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => TryFirst<TEnumerable, TEnumerator, TSource>(source).DefaultOnEmpty();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource First<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate).ThrowOnEmpty();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource FirstOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate).DefaultOnEmpty();

        public static (ElementResult Success, TSource Value) TryFirst<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => TryFirst<TEnumerable, TEnumerator, TSource>(source, 0, source.Count);

        public static (ElementResult Success, TSource Value) TryFirst<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate, 0, source.Count);
        }

        public static (long Index, TSource Value) TryFirst<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate, 0, source.Count);
        }

        static (ElementResult Success, TSource Value) TryFirst<TEnumerable, TEnumerator, TSource>(this TEnumerable source, long skipCount, long takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source.Count == 0 || takeCount < 1)
                return (ElementResult.Empty, default);

            return (ElementResult.Success, source[skipCount]);
        }

        static (ElementResult Success, TSource Value) TryFirst<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate, long skipCount, long takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    return (ElementResult.Success, source[index]);
            }

            return (ElementResult.Empty, default);
        }

        static (long Index, TSource Value) TryFirst<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate, long skipCount, long takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index], index))
                    return (index, source[index]);
            }

            return ((long)ElementResult.Empty, default);
        }
    }
}
