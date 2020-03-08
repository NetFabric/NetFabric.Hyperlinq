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
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => GetSingle<TEnumerable, TEnumerator, TSource>(source).ThrowOnEmpty();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Predicate<TSource> predicate) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => GetSingle<TEnumerable, TEnumerator, TSource>(source, predicate).ThrowOnEmpty();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source, PredicateAt<TSource> predicate) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => GetSingle<TEnumerable, TEnumerator, TSource>(source, predicate).ThrowOnEmpty();

        [Pure]
        static TResult Single<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Selector<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var (success, result) = GetSingle<TEnumerable, TEnumerator, TSource>(source);
            return success switch
            {
                ElementResult.Empty => Throw.EmptySequence<TResult>(),
                ElementResult.Success => selector(result),
                _ => Throw.NotSingleSequence<TResult>(),
            };
        }

        [Pure]
        static TResult Single<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, SelectorAt<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var (success, result) = GetSingle<TEnumerable, TEnumerator, TSource>(source);
            return success switch
            {
                ElementResult.Empty => Throw.EmptySequence<TResult>(),
                ElementResult.Success => selector(result, 0),
                _ => Throw.NotSingleSequence<TResult>(),
            };
        }

        [Pure]
        static TResult Single<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Predicate<TSource> predicate, Selector<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var (success, result) = GetSingle<TEnumerable, TEnumerator, TSource>(source, predicate);
            return success switch
            {
                ElementResult.Empty => Throw.EmptySequence<TResult>(),
                ElementResult.Success => selector(result),
                _ => Throw.NotSingleSequence<TResult>(),
            };
        }

        ////////////////////////////////
        // SingleOrDefault 

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: MaybeNull]
        public static TSource SingleOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => GetSingle<TEnumerable, TEnumerator, TSource>(source).DefaultOnEmpty();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: MaybeNull]
        public static TSource SingleOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Predicate<TSource> predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => GetSingle<TEnumerable, TEnumerator, TSource>(source, predicate).DefaultOnEmpty();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: MaybeNull]
        public static TSource SingleOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, PredicateAt<TSource> predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => GetSingle<TEnumerable, TEnumerator, TSource>(source, predicate).DefaultOnEmpty();

        [Pure]
        static TResult SingleOrDefault<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Selector<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var (success, result) = GetSingle<TEnumerable, TEnumerator, TSource>(source);
            return success switch
            {
                ElementResult.Empty => default,
                ElementResult.Success => selector(result),
                _ => Throw.NotSingleSequence<TResult>(),
            };
        }

        [Pure]
        static TResult SingleOrDefault<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, SelectorAt<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var (success, result) = GetSingle<TEnumerable, TEnumerator, TSource>(source);
            return success switch
            {
                ElementResult.Empty => default,
                ElementResult.Success => selector(result, 0),
                _ => Throw.NotSingleSequence<TResult>(),
            };
        }

        [Pure]
        static TResult SingleOrDefault<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Predicate<TSource> predicate, Selector<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var (success, result) = GetSingle<TEnumerable, TEnumerator, TSource>(source, predicate);
            return success switch
            {
                ElementResult.Empty => default,
                ElementResult.Success => selector(result),
                _ => Throw.NotSingleSequence<TResult>(),
            };
        }

        ////////////////////////////////
        // GetSingle 

        [Pure]
        static (ElementResult Success, TSource Value) GetSingle<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            if (enumerator.MoveNext())
            {
                var value = enumerator.Current;

                return enumerator.MoveNext() 
                    ? (ElementResult.NotSingle, default) 
                    : (ElementResult.Success, value);
            }
            return (ElementResult.Empty, default);
        }

        [Pure]
        static (ElementResult Success, TSource Value) GetSingle<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Predicate<TSource> predicate) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
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
        static (ElementResult Success, TSource Value, int Index) GetSingle<TEnumerable, TEnumerator, TSource>(this TEnumerable source, PredicateAt<TSource> predicate) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var enumerator = source.GetEnumerator();
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
            return (ElementResult.Empty, default, 0);
        }
    }
}
