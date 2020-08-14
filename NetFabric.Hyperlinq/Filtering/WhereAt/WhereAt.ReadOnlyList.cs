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
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return new WhereAtEnumerable<TList, TSource>(in source, predicate, 0, source.Count);
        }


        static WhereAtEnumerable<TList, TSource> Where<TList, TSource>(this TList source, PredicateAt<TSource> predicate, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            => new WhereAtEnumerable<TList, TSource>(in source, predicate, offset, count);

        public readonly partial struct WhereAtEnumerable<TList, TSource>
            : IValueEnumerable<TSource, WhereAtEnumerable<TList, TSource>.DisposableEnumerator>
            where TList : notnull, IReadOnlyList<TSource>
        {
            readonly TList source;
            readonly PredicateAt<TSource> predicate;
            readonly int offset;
            readonly int count;

            internal WhereAtEnumerable(in TList source, PredicateAt<TSource> predicate, int offset, int count)
            {
                this.source = source;
                this.predicate = predicate;
                (this.offset, this.count) = Utils.SkipTake(source.Count, offset, count);
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
                    offset = enumerable.offset;
                    index = -1;
                    end = index + enumerable.count;
                }

                [MaybeNull]
                public readonly TSource Current
                    => source[index + offset];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
                    offset = enumerable.offset;
                    index = -1;
                    end = index + enumerable.count;
                }

                [MaybeNull]
                public readonly TSource Current
                    => source[index + offset];
                readonly TSource IEnumerator<TSource>.Current 
                    => source[index + offset];
                readonly object? IEnumerator.Current 
                    => source[index + offset];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
                => ReadOnlyListExtensions.Count<TList, TSource>(source, predicate, offset, count);

            public bool Any()
                => ReadOnlyListExtensions.Any<TList, TSource>(source, predicate, offset, count);
                
            public ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource> Where(Predicate<TSource> predicate)
                => ReadOnlyListExtensions.Where<TList, TSource>(source, Utils.Combine(this.predicate, predicate), offset, count);
            public ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource> Where(PredicateAt<TSource> predicate)
                => ReadOnlyListExtensions.Where<TList, TSource>(source, Utils.Combine(this.predicate, predicate), offset, count);

            public Option<TSource> ElementAt(int index)
                => ReadOnlyListExtensions.ElementAt<TList, TSource>(source, index, predicate, offset, count);

            public Option<TSource> First()
                => ReadOnlyListExtensions.First<TList, TSource>(source, predicate, offset, count);

            public Option<TSource> Single()
                => ReadOnlyListExtensions.Single<TList, TSource>(source, predicate, offset, count);

            public TSource[] ToArray()
                => ReadOnlyListExtensions.ToArray<TList, TSource>(source, predicate, offset, count);

            public IMemoryOwner<TSource> ToArray(MemoryPool<TSource> pool)
                => ReadOnlyListExtensions.ToArray<TList, TSource>(source, predicate, offset, count, pool);

            public List<TSource> ToList()
                => ReadOnlyListExtensions.ToList<TList, TSource>(source, predicate, offset, count);

            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ReadOnlyListExtensions.ToDictionary<TList, TSource, TKey>(source, keySelector, comparer, predicate, offset, count);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ReadOnlyListExtensions.ToDictionary<TList, TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, predicate, offset, count);

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

