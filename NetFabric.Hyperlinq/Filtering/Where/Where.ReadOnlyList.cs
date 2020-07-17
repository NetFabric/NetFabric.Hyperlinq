using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static WhereEnumerable<TList, TSource> Where<TList, TSource>(this TList source, Predicate<TSource> predicate)
            where TList : IReadOnlyList<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return new WhereEnumerable<TList, TSource>(in source, predicate, 0, source.Count);
        }

        static WhereEnumerable<TList, TSource> Where<TList, TSource>(this TList source, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TList : IReadOnlyList<TSource>
            => new WhereEnumerable<TList, TSource>(in source, predicate, skipCount, takeCount);

        public readonly partial struct WhereEnumerable<TList, TSource>
            : IValueEnumerable<TSource, WhereEnumerable<TList, TSource>.DisposableEnumerator>
            where TList : IReadOnlyList<TSource>
        {
            readonly TList source;
            readonly Predicate<TSource> predicate;
            readonly int skipCount;
            readonly int takeCount;

            internal WhereEnumerable(in TList source, Predicate<TSource> predicate, int skipCount, int takeCount)
            {
                this.source = source;
                this.predicate = predicate;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Count, skipCount, takeCount);
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, WhereEnumerable<TList, TSource>.DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            public struct Enumerator
            {
                readonly TList source;
                readonly Predicate<TSource> predicate;
                readonly int end;
                int index;

                internal Enumerator(in WhereEnumerable<TList, TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    index = enumerable.skipCount - 1;
                    end = index + enumerable.takeCount;
                }

                [MaybeNull]
                public readonly TSource Current
                    => source[index];

                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate(source[index]))
                            return true;
                    }
                    return false;
                }
            }

            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                readonly TList source;
                readonly Predicate<TSource> predicate;
                readonly int end;
                int index;

                internal DisposableEnumerator(in WhereEnumerable<TList, TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    index = enumerable.skipCount - 1;
                    end = index + enumerable.takeCount;
                }

                [MaybeNull]
                public readonly TSource Current 
                    => source[index];
                readonly TSource IEnumerator<TSource>.Current 
                    => source[index];
                readonly object? IEnumerator.Current
                    => source[index];

                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate(source[index]))
                            return true;
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public readonly void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count()
                => ReadOnlyListExtensions.Count<TList, TSource>(source, predicate, skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => ReadOnlyListExtensions.Any<TList, TSource>(source, predicate, skipCount, takeCount);
                
            public ReadOnlyListExtensions.WhereSelectEnumerable<TList, TSource, TResult> Select<TResult>(NullableSelector<TSource, TResult> selector)
            {
                if (selector is null) Throw.ArgumentNullException(nameof(selector));

                return ReadOnlyListExtensions.WhereSelect<TList, TSource, TResult>(source, predicate, selector, skipCount, takeCount);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyListExtensions.WhereEnumerable<TList, TSource> Where(Predicate<TSource> predicate)
                => ReadOnlyListExtensions.Where<TList, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource> Where(PredicateAt<TSource> predicate)
                => ReadOnlyListExtensions.Where<TList, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> ElementAt(int index)
                => ReadOnlyListExtensions.ElementAt<TList, TSource>(source, index, predicate, skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> First()
                => ReadOnlyListExtensions.First<TList, TSource>(source, predicate, skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> Single()
                => ReadOnlyListExtensions.Single<TList, TSource>(source, predicate, skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => ReadOnlyListExtensions.ToArray<TList, TSource>(source, predicate, skipCount, takeCount);

            public IMemoryOwner<TSource> ToArray(MemoryPool<TSource> pool)
                => ReadOnlyListExtensions.ToArray<TList, TSource>(source, predicate, skipCount, takeCount, pool);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => ReadOnlyListExtensions.ToList<TList, TSource>(source, predicate, skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(NullableSelector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                => ReadOnlyListExtensions.ToDictionary<TList, TSource, TKey>(source, keySelector, comparer, predicate, skipCount, takeCount);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(NullableSelector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                => ReadOnlyListExtensions.ToDictionary<TList, TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, predicate, skipCount, takeCount);
        }
    }
}

