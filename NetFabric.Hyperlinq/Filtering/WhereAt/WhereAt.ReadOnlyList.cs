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
        public static WhereAtEnumerable<TList, TSource> Where<TList, TSource>(this TList source, PredicateAt<TSource> predicate)
            where TList : IReadOnlyList<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return new WhereAtEnumerable<TList, TSource>(in source, predicate, 0, source.Count);
        }


        static WhereAtEnumerable<TList, TSource> Where<TList, TSource>(this TList source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TList : IReadOnlyList<TSource>
            => new WhereAtEnumerable<TList, TSource>(in source, predicate, skipCount, takeCount);

        public readonly partial struct WhereAtEnumerable<TList, TSource>
            : IValueEnumerable<TSource, WhereAtEnumerable<TList, TSource>.DisposableEnumerator>
            where TList : IReadOnlyList<TSource>
        {
            readonly TList source;
            readonly PredicateAt<TSource> predicate;
            readonly int skipCount;
            readonly int takeCount;

            internal WhereAtEnumerable(in TList source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            {
                this.source = source;
                this.predicate = predicate;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Count, skipCount, takeCount);
            }

            
            public readonly Enumerator GetEnumerator() 
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, WhereAtEnumerable<TList, TSource>.DisposableEnumerator>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new DisposableEnumerator(in this);

            public struct Enumerator
            {
                readonly TList source;
                readonly PredicateAt<TSource> predicate;
                readonly int offset;
                readonly int end;
                int index;

                internal Enumerator(in WhereAtEnumerable<TList, TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    offset = enumerable.skipCount;
                    index = -1;
                    end = index + enumerable.takeCount;
                }

                [MaybeNull]
                public readonly TSource Current
                    => source[index + offset];

                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate(source[index + offset], index))
                            return true;
                    }
                    return false;
                }
            }

            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                readonly TList source;
                readonly PredicateAt<TSource> predicate;
                readonly int offset;
                readonly int end;
                int index;

                internal DisposableEnumerator(in WhereAtEnumerable<TList, TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    offset = enumerable.skipCount;
                    index = -1;
                    end = index + enumerable.takeCount;
                }

                [MaybeNull]
                public readonly TSource Current
                    => source[index + offset];
                readonly TSource IEnumerator<TSource>.Current 
                    => source[index + offset];
                readonly object? IEnumerator.Current 
                    => source[index + offset];

                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate(source[index + offset], index))
                            return true;
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public readonly void Dispose() { }
            }

            public int Count()
                => ReadOnlyListExtensions.Count<TList, TSource>(source, predicate, skipCount, takeCount);

            public bool Any()
                => ReadOnlyListExtensions.Any<TList, TSource>(source, predicate, skipCount, takeCount);
                
            public ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource> Where(Predicate<TSource> predicate)
                => ReadOnlyListExtensions.Where<TList, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);
            public ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource> Where(PredicateAt<TSource> predicate)
                => ReadOnlyListExtensions.Where<TList, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);

            public Option<TSource> ElementAt(int index)
                => ReadOnlyListExtensions.ElementAt<TList, TSource>(source, index, predicate, skipCount, takeCount);

            public Option<TSource> First()
                => ReadOnlyListExtensions.First<TList, TSource>(source, predicate, skipCount, takeCount);

            public Option<TSource> Single()
                => ReadOnlyListExtensions.Single<TList, TSource>(source, predicate, skipCount, takeCount);

            public TSource[] ToArray()
                => ReadOnlyListExtensions.ToArray<TList, TSource>(source, predicate, skipCount, takeCount);

            public IMemoryOwner<TSource> ToArray(MemoryPool<TSource> pool)
                => ReadOnlyListExtensions.ToArray<TList, TSource>(source, predicate, skipCount, takeCount, pool);

            public List<TSource> ToList()
                => ReadOnlyListExtensions.ToList<TList, TSource>(source, predicate, skipCount, takeCount);

            public Dictionary<TKey, TSource> ToDictionary<TKey>(NullableSelector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                => ReadOnlyListExtensions.ToDictionary<TList, TSource, TKey>(source, keySelector, comparer, predicate, skipCount, takeCount);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(NullableSelector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                => ReadOnlyListExtensions.ToDictionary<TList, TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, predicate, skipCount, takeCount);

            public readonly bool SequenceEqual(IEnumerable<TSource> other, IEqualityComparer<TSource>? comparer = default)
            {
                comparer ??= EqualityComparer<TSource>.Default;

                var enumerator = GetEnumerator();
                using var otherEnumerator = other.GetEnumerator();
                while (true)
                {
                    var thisEnded = !enumerator.MoveNext();
                    var otherEnded = !otherEnumerator.MoveNext();

                    if (thisEnded != otherEnded)
                        return false;

                    if (thisEnded)
                        return true;

                    if (!comparer.Equals(enumerator.Current!, otherEnumerator.Current))
                        return false;
                }
            }
        }
    }
}

