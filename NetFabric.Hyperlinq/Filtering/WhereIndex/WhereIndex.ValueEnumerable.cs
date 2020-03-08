using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        [Pure]
        public static WhereIndexEnumerable<TEnumerable, TEnumerator, TSource> Where<TEnumerable, TEnumerator, TSource>(this TEnumerable source, PredicateAt<TSource> predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return new WhereIndexEnumerable<TEnumerable, TEnumerator, TSource>(in source, predicate);
        }

        public readonly partial struct WhereIndexEnumerable<TEnumerable, TEnumerator, TSource> 
            : IValueEnumerable<TSource, WhereIndexEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            internal readonly TEnumerable source;
            internal readonly PredicateAt<TSource> predicate;

            internal WhereIndexEnumerable(in TEnumerable source, PredicateAt<TSource> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IEnumerator<TSource>
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly
                readonly PredicateAt<TSource> predicate;
                int index;

                internal Enumerator(in WhereIndexEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    predicate = enumerable.predicate;
                    index = 0;
                }

                [MaybeNull]
                public readonly TSource Current
                    => enumerator.Current;
                readonly object? IEnumerator.Current 
                    => enumerator.Current;

                public bool MoveNext()
                {
                    checked
                    {
                        for (; enumerator.MoveNext(); index++)
                        {
                            if (predicate(enumerator.Current, index))
                                return true;
                        }
                    }
                    Dispose();
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => throw new NotSupportedException();

                public void Dispose() 
                    => enumerator.Dispose();
            }

            public int Count()
                => ValueEnumerable.Count<TEnumerable, TEnumerator, TSource>(source, predicate);

            public bool Any()
                => ValueEnumerable.Any<TEnumerable, TEnumerator, TSource>(source, predicate);
                
            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer = null)
                => ValueEnumerable.Contains<TEnumerable, TEnumerator, TSource>(source, value, comparer, predicate);

            public ValueEnumerable.WhereIndexEnumerable<TEnumerable, TEnumerator, TSource> Where(Predicate<TSource> predicate)
                => ValueEnumerable.Where<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));
            public ValueEnumerable.WhereIndexEnumerable<TEnumerable, TEnumerator, TSource> Where(PredicateAt<TSource> predicate)
                => ValueEnumerable.Where<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));

            public TSource ElementAt(int index)
                => ValueEnumerable.ElementAt<TEnumerable, TEnumerator, TSource>(source, index, predicate);

            [return: MaybeNull]
            public TSource ElementAtOrDefault(int index)
                => ValueEnumerable.ElementAtOrDefault<TEnumerable, TEnumerator, TSource>(source, index, predicate);

            public TSource First()
                => ValueEnumerable.First<TEnumerable, TEnumerator, TSource>(source, predicate);

            [return: MaybeNull]
            public TSource FirstOrDefault()
                => ValueEnumerable.FirstOrDefault<TEnumerable, TEnumerator, TSource>(source, predicate);

            public TSource Single()
                => ValueEnumerable.Single<TEnumerable, TEnumerator, TSource>(source, predicate);

            [return: MaybeNull]
            public TSource SingleOrDefault()
                => ValueEnumerable.SingleOrDefault<TEnumerable, TEnumerator, TSource>(source, predicate);

            public TSource[] ToArray()
                => ValueEnumerable.ToArray<TEnumerable, TEnumerator, TSource>(source, predicate);

            public List<TSource> ToList()
                => ValueEnumerable.ToList<TEnumerable, TEnumerator, TSource>(source, predicate);

            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector)
                => ValueEnumerable.ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(source, keySelector, EqualityComparer<TKey>.Default, predicate);
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
                => ValueEnumerable.ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(source, keySelector, comparer, predicate);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector)
                => ValueEnumerable.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(source, keySelector, elementSelector, EqualityComparer<TKey>.Default, predicate);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
                => ValueEnumerable.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, predicate);

            public void ForEach(Action<TSource> action)
                => ValueEnumerable.ForEach<TEnumerable, TEnumerator, TSource>(source, action, predicate);
            public void ForEach(ActionAt<TSource> action)
                => ValueEnumerable.ForEach<TEnumerable, TEnumerator, TSource>(source, action, predicate);
        }
    }
}

