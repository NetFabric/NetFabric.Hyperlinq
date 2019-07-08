using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TEnumerable, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyList<TSource>
            => TrySingle<TEnumerable, TSource>(source).ThrowOnEmpty();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource SingleOrDefault<TEnumerable, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyList<TSource>
            => TrySingle<TEnumerable, TSource>(source).DefaultOnEmpty();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
            => TrySingle<TEnumerable, TSource>(source, predicate).ThrowOnEmpty();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource SingleOrDefault<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
            => TrySingle<TEnumerable, TSource>(source, predicate).DefaultOnEmpty();

        public static (ElementResult Success, TSource Value) TrySingle<TEnumerable, TSource>(this TEnumerable source)
            where TEnumerable : IReadOnlyList<TSource>
            => TrySingle<TEnumerable, TSource>(source, 0, source.Count);

        public static (ElementResult Success, TSource Value) TrySingle<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return TrySingle<TEnumerable, TSource>(source, predicate, 0, source.Count);
        }

        public static (int Index, TSource Value) TrySingle<TEnumerable, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate)
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return TrySingle<TEnumerable, TSource>(source, predicate, 0, source.Count);
        }

        static (ElementResult Success, TSource Value) TrySingle<TEnumerable, TSource>(this TEnumerable source, int skipCount, int takeCount)
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (takeCount < 1)
                return (ElementResult.Empty, default);

            switch (source.Count)
            {
                case 0:
                    return (ElementResult.Empty, default);
                case 1:
                    return (ElementResult.Success, source[skipCount]);
                default:
                    return (ElementResult.NotSingle, default);
            }
        }

        static (ElementResult Success, TSource Value) TrySingle<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate, int skipCount, int takeCount)
            where TEnumerable : IReadOnlyList<TSource>
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

        static (int Index, TSource Value) TrySingle<TEnumerable, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate, int skipCount, int takeCount)
            where TEnumerable : IReadOnlyList<TSource>
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
