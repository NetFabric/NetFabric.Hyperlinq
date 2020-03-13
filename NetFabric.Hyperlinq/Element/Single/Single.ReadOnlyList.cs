using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TList, TSource>(this TList source) 
            where TList : notnull, IReadOnlyList<TSource>
            => Single<TList, TSource>(source, 0, source.Count);

        [Pure]
        static TSource Single<TList, TSource>(this TList source, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
            => takeCount switch
            {
                0 => Throw.EmptySequence<TSource>(),
                1 => source[skipCount],
                _ => Throw.NotSingleSequence<TSource>(),
            };

        [Pure]
        static TSource Single<TList, TSource>(this TList source, Predicate<TSource> predicate, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
            => GetSingle<TList, TSource>(source, predicate, skipCount, takeCount).ThrowOnEmpty();

        [Pure]
        static TSource Single<TList, TSource>(this TList source, PredicateAt<TSource> predicate, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
            => GetSingle<TList, TSource>(source, predicate, skipCount, takeCount).ThrowOnEmpty();

        [Pure]
        static TResult Single<TList, TSource, TResult>(this TList source, Selector<TSource, TResult> selector, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
            => takeCount switch
            {
                0 => Throw.EmptySequence<TResult>(),
                1 => selector(source[skipCount]),
                _ => Throw.NotSingleSequence<TResult>(),
            };

        [Pure]
        static TResult Single<TList, TSource, TResult>(this TList source, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
            => takeCount switch
            {
                0 => Throw.EmptySequence<TResult>(),
                1 => selector(source[skipCount], 0),
                _ => Throw.NotSingleSequence<TResult>(),
            };

        [Pure]
        static TResult Single<TList, TSource, TResult>(this TList source, Predicate<TSource> predicate, Selector<TSource, TResult> selector, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
            => selector(GetSingle<TList, TSource>(source, predicate, skipCount, takeCount).ThrowOnEmpty());

        ////////////////////////////////
        // SingleOrDefault 

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource SingleOrDefault<TList, TSource>(this TList source) 
            where TList : notnull, IReadOnlyList<TSource>
            => SingleOrDefault<TList, TSource>(source, 0, source.Count);

        [Pure]
        static TSource SingleOrDefault<TList, TSource>(this TList source, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
            => takeCount switch
            {
                0 => default,
                1 => source[skipCount],
                _ => Throw.NotSingleSequence<TSource>(),
            };

        [Pure]
        static TSource SingleOrDefault<TList, TSource>(this TList source, Predicate<TSource> predicate, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
            => GetSingle<TList, TSource>(source, predicate, skipCount, takeCount).DefaultOnEmpty();

        [Pure]
        static TSource SingleOrDefault<TList, TSource>(this TList source, PredicateAt<TSource> predicate, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
            => GetSingle<TList, TSource>(source, predicate, skipCount, takeCount).DefaultOnEmpty();

        [Pure]
        static TResult SingleOrDefault<TList, TSource, TResult>(this TList source, Selector<TSource, TResult> selector, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
            => takeCount switch
            {
                0 => default,
                1 => selector(source[skipCount]),
                _ => Throw.NotSingleSequence<TResult>(),
            };

        [Pure]
        static TResult SingleOrDefault<TList, TSource, TResult>(this TList source, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
            => takeCount switch
            {
                0 => default,
                1 => selector(source[skipCount], 0),
                _ => Throw.NotSingleSequence<TResult>(),
            };

        [Pure]
        static TResult SingleOrDefault<TList, TSource, TResult>(this TList source, Predicate<TSource> predicate, Selector<TSource, TResult> selector, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
        {
            var (success, result) = GetSingle<TList, TSource>(source, predicate, skipCount, takeCount);
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
        static (ElementResult Success, TSource Value) GetSingle<TList, TSource>(this TList source, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
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
        static (ElementResult Success, TSource Value, int Index) GetSingle<TList, TSource>(this TList source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (skipCount == 0)
            {
                for (var index = 0; index < takeCount; index++)
                {
                    if (predicate(source[index], index))
                    {
                        var value = (ElementResult.Success, source[index], index);

                        for (index++; index < takeCount; index++)
                        {
                            if (predicate(source[index], index))
                                return (ElementResult.NotSingle, default, 0);
                        }

                        return value;
                    }
                }
            }
            else
            {
                for (var index = 0; index < takeCount; index++)
                {
                    if (predicate(source[index + skipCount], index))
                    {
                        var value = (ElementResult.Success, source[index + skipCount], index);

                        for (index++; index < takeCount; index++)
                        {
                            if (predicate(source[index + skipCount], index))
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
