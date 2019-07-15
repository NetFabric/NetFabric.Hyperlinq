using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource First<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => TryFirst<TEnumerable, TEnumerator, TSource>(source).ThrowOnEmpty();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource FirstOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => TryFirst<TEnumerable, TEnumerator, TSource>(source).DefaultOnEmpty();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource First<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate).ThrowOnEmpty();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource FirstOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate).DefaultOnEmpty();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (ElementResult Success, TSource Value) TryFirst<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => TryFirst<TEnumerable, TEnumerator, TSource>(source, 0, source.Count);

        public static (ElementResult Success, TSource Value) TryFirst<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate, 0, source.Count);
        }

        public static (int Index, TSource Value) TryFirst<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate, 0, source.Count);
        }

        static (ElementResult Success, TSource Value) TryFirst<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count == 0 || takeCount < 1)
                return (ElementResult.Empty, default);

            return (ElementResult.Success, source[skipCount]);
        }

        static (ElementResult Success, TSource Value) TryFirst<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate, int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    return (ElementResult.Success, source[index]);
            }

            return (ElementResult.Empty, default);
        }

        static (int Index, TSource Value) TryFirst<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate, int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index], index))
                    return (index, source[index]);
            }

            return ((int)ElementResult.Empty, default);
        }
    }
}
