using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => GetSingle<TEnumerable, TEnumerator, TSource>(source).ThrowOnEmpty();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => GetSingle<TEnumerable, TEnumerator, TSource>(source, predicate).ThrowOnEmpty();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: MaybeNull]
        public static TSource SingleOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => GetSingle<TEnumerable, TEnumerator, TSource>(source).DefaultOnEmpty();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: MaybeNull]
        public static TSource SingleOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => GetSingle<TEnumerable, TEnumerator, TSource>(source, predicate).DefaultOnEmpty();

        [Pure]
        static (ElementResult Success, TSource Value) GetSingle<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = (TEnumerator)source.GetEnumerator();
            if (enumerator.MoveNext())
            {
                var value = enumerator.Current;

                if (enumerator.MoveNext())
                    return (ElementResult.NotSingle, default);

                return (ElementResult.Success, value);
            }

            return (ElementResult.Empty, default);
        }

        [Pure]
        static (ElementResult Success, TSource Value) GetSingle<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (predicate(enumerator.Current))
                {
                    var value = enumerator.Current;

                    // found first, keep going until end or find second
                    while (enumerator.MoveNext())
                    {
                        if (predicate(enumerator.Current))
                            return (ElementResult.NotSingle, default);
                    }

                    return (ElementResult.Success, value);
                }
            }

            return (ElementResult.Empty, default);
        }

        [Pure]
        static (int Index, TSource Value) GetSingle<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var enumerator = (TEnumerator)source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                {
                    if (predicate(enumerator.Current, index))
                    {
                        var value = (index, enumerator.Current);

                        // found first, keep going until end or find second
                        for (index++; enumerator.MoveNext(); index++)
                        {
                            if (predicate(enumerator.Current, index))
                                return ((int)ElementResult.NotSingle, default);
                        }

                        return value;
                    }
                }
            }

            return ((int)ElementResult.Empty, default);
        }
    }
}
