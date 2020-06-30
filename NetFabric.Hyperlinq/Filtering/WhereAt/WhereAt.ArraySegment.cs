using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        public static WhereAtEnumerable<TSource> Where<TSource>(this in ArraySegment<TSource> source, PredicateAt<TSource> predicate)
            => new WhereAtEnumerable<TSource>(source, predicate);

        public readonly partial struct WhereAtEnumerable<TSource>
            : IValueEnumerable<TSource, WhereAtEnumerable<TSource>.DisposableEnumerator>
        {
            readonly ArraySegment<TSource> source;
            readonly PredicateAt<TSource> predicate;

            internal WhereAtEnumerable(in ArraySegment<TSource> source, PredicateAt<TSource> predicate)
                => (this.source, this.predicate) = (source, predicate);

            public readonly Enumerator GetEnumerator() 
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, WhereAtEnumerable<TSource>.DisposableEnumerator>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new DisposableEnumerator(in this);

            public struct Enumerator
            {
                readonly TSource[] source;
                readonly PredicateAt<TSource> predicate;
                readonly int offset;
                readonly int count;
                int index;

                internal Enumerator(in WhereAtEnumerable<TSource> enumerable)
                {
                    source = enumerable.source.Array;
                    predicate = enumerable.predicate;
                    offset = enumerable.source.Offset;
                    count = enumerable.source.Count;
                    index = -1;
                }

                [MaybeNull]
                public readonly TSource Current
                    => source[index + offset];

                public bool MoveNext()
                {
                    while (++index < count)
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
                readonly TSource[] source;
                readonly PredicateAt<TSource> predicate;
                readonly int offset;
                readonly int count;
                int index;

                internal DisposableEnumerator(in WhereAtEnumerable<TSource> enumerable)
                {
                    source = enumerable.source.Array;
                    predicate = enumerable.predicate;
                    offset = enumerable.source.Offset;
                    count = enumerable.source.Count;
                    index = -1;
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
                    while (++index < count)
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
                => ArrayExtensions.Count<TSource>(source, predicate);

            public bool Any()
                => ArrayExtensions.Any<TSource>(source, predicate);

            public WhereAtEnumerable<TSource> Where(Predicate<TSource> predicate)
                => ArrayExtensions.Where<TSource>(source, Utils.Combine(this.predicate, predicate));
            public WhereAtEnumerable<TSource> Where(PredicateAt<TSource> predicate)
                => ArrayExtensions.Where<TSource>(source, Utils.Combine(this.predicate, predicate));

            public Option<TSource> ElementAt(int index)
                => ArrayExtensions.ElementAt<TSource>(source, index, predicate);

            public Option<TSource> First()
                => ArrayExtensions.First<TSource>(source, predicate);

            public Option<TSource> Single()
                => ArrayExtensions.Single<TSource>(source, predicate);

            public TSource[] ToArray()
                => ArrayExtensions.ToArray<TSource>(source, predicate);

            public List<TSource> ToList()
                => ArrayExtensions.ToList<TSource>(source, predicate);

            public Dictionary<TKey, TSource> ToDictionary<TKey>(NullableSelector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                => ArrayExtensions.ToDictionary<TSource, TKey>(source, keySelector, comparer, predicate);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(NullableSelector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                => ArrayExtensions.ToDictionary<TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, predicate);

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

                    if (!comparer.Equals(enumerator.Current, otherEnumerator.Current))
                        return false;
                }
            }
        }
    }
}

