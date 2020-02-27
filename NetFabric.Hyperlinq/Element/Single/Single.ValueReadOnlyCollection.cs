using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => GetSingle<TEnumerable, TEnumerator, TSource>(source).ThrowOnEmpty();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Predicate<TSource> predicate) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => predicate is null
                ? Throw.ArgumentNullExceptionRef<TSource>(nameof(predicate))
                : GetSingle<TEnumerable, TEnumerator, TSource>(source, predicate).ThrowOnEmpty();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source, PredicateAt<TSource> predicate) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => predicate is null
                ? Throw.ArgumentNullExceptionRef<TSource>(nameof(predicate))
                : GetSingle<TEnumerable, TEnumerator, TSource>(source, predicate).ThrowOnEmpty();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: MaybeNull]
        public static TSource SingleOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => GetSingle<TEnumerable, TEnumerator, TSource>(source).DefaultOnEmpty();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: MaybeNull]
        public static TSource SingleOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Predicate<TSource> predicate) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => predicate is null
                ? Throw.ArgumentNullExceptionRef<TSource>(nameof(predicate))
                : GetSingle<TEnumerable, TEnumerator, TSource>(source, predicate).DefaultOnEmpty();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: MaybeNull]
        public static TSource SingleOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, PredicateAt<TSource> predicate) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => predicate is null
                ? Throw.ArgumentNullExceptionRef<TSource>(nameof(predicate))
                : GetSingle<TEnumerable, TEnumerator, TSource>(source, predicate).DefaultOnEmpty();

        [Pure]
        static (ElementResult Success, TSource Value) GetSingle<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            switch (source.Count)
            {
                case 0:
                    return (ElementResult.Empty, default);
                case 1:
                    {
                        using var enumerator = source.GetEnumerator();
                        _ = enumerator.MoveNext();
                        return (ElementResult.Success, enumerator.Current);
                    }
            }

            return (ElementResult.NotSingle, default);
        }

        [Pure]
        static (ElementResult Success, TSource Value) GetSingle<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Predicate<TSource> predicate) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count != 0)
            {
                using var enumerator = (TEnumerator)source.GetEnumerator();
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
            }

            return (ElementResult.Empty, default);
        }

        [Pure]
        static (ElementResult Success, TSource Value, int Index) GetSingle<TEnumerable, TEnumerator, TSource>(this TEnumerable source, PredicateAt<TSource> predicate) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count != 0)
            {
                using var enumerator = (TEnumerator)source.GetEnumerator();
                checked
                {
                    for (var index = 0; enumerator.MoveNext(); index++)
                    {
                        if (predicate(enumerator.Current, index))
                        {
                            var value = (ElementResult.Success, enumerator.Current, index);

                            // found first, keep going until end or find second
                            for (index++; enumerator.MoveNext(); index++)
                            {
                                if (predicate(enumerator.Current, index))
                                    return (ElementResult.NotSingle, default, 0);
                            }

                            return value;
                        }
                    }
                }
            }

            return (ElementResult.Empty, default, 0);
        }
    }
}
