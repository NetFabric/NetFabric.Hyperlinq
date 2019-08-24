using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => TrySingle<TEnumerable, TEnumerator, TSource>(source).ThrowOnEmpty();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource SingleOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => TrySingle<TEnumerable, TEnumerator, TSource>(source).DefaultOnEmpty();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => TrySingle<TEnumerable, TEnumerator, TSource>(source, predicate).ThrowOnEmpty();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource SingleOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => TrySingle<TEnumerable, TEnumerator, TSource>(source, predicate).DefaultOnEmpty();

        [Pure]
        public static (ElementResult Success, TSource Value) TrySingle<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            switch (source.Count)
            {
                case 0:
                    return (ElementResult.Empty, default);
                case 1:
                    foreach (var item in source)
                    {
                        return (ElementResult.Success, item);
                    }
                    break;
            }

            return (ElementResult.NotSingle, default);
        }

        [Pure]
        public static (ElementResult Success, TSource Value) TrySingle<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count == 0)
                return (ElementResult.Empty, default);

            var first = true;
            TSource value = default;
            foreach (var item in source)
            {
                if (first)
                {
                    if (predicate(item))
                    {
                        value = item;
                        first = false;
                    }
                }
                else
                {
                    if (predicate(item))
                        return (ElementResult.NotSingle, default);
                }
            }

            if (first)
                return (ElementResult.Empty, default);

            return (ElementResult.Success, value);
        }

        [Pure]
        public static (int Index, TSource Value) TrySingle<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count == 0)
                return ((int)ElementResult.Empty, default);

            var index = 0;
            var first = true;
            TSource value = default;
            foreach (var item in source)
            {
                if (first)
                {
                    if (predicate(item, index))
                    {
                        value = item;
                        first = false;
                    }
                }
                else
                {
                    if (predicate(item, index))
                        return ((int)ElementResult.NotSingle, default);
                }

                checked { index++; }
            }

            if (first)
                return ((int)ElementResult.Empty, default);

            return (index, value);
        }
    }
}
