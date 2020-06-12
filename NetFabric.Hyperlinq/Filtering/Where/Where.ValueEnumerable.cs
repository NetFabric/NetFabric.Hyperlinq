using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static WhereEnumerable<TEnumerable, TEnumerator, TSource> Where<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Predicate<TSource> predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return new WhereEnumerable<TEnumerable, TEnumerator, TSource>(in source, predicate);
        }

        public readonly partial struct WhereEnumerable<TEnumerable, TEnumerator, TSource> 
            : IValueEnumerable<TSource, WhereEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            internal readonly TEnumerable source;
            internal readonly Predicate<TSource> predicate;

            internal WhereEnumerable(in TEnumerable source, Predicate<TSource> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IEnumerator<TSource>
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly
                readonly Predicate<TSource> predicate;

                internal Enumerator(in WhereEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    predicate = enumerable.predicate;
                }

                [MaybeNull]
                public readonly TSource Current 
                    => enumerator.Current;
                readonly TSource IEnumerator<TSource>.Current 
                    => enumerator.Current;
                readonly object? IEnumerator.Current 
                    => enumerator.Current;

                public bool MoveNext()
                {
                    while (enumerator.MoveNext())
                    {
                        if (predicate(enumerator.Current))
                            return true;
                    }
                    Dispose();
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public void Dispose() => enumerator.Dispose();
            }

            public int Count()
                => ValueEnumerableExtensions.Count<TEnumerable, TEnumerator, TSource>(source, predicate);

            public bool Any()
                => ValueEnumerableExtensions.Any<TEnumerable, TEnumerator, TSource>(source, predicate);
                
            public ValueEnumerableExtensions.WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TResult>(Selector<TSource, TResult> selector)
                => ValueEnumerableExtensions.WhereSelect<TEnumerable, TEnumerator, TSource, TResult>(source, predicate, selector);

            public ValueEnumerableExtensions.WhereEnumerable<TEnumerable, TEnumerator, TSource> Where(Predicate<TSource> predicate)
                => ValueEnumerableExtensions.Where<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));
            public ValueEnumerableExtensions.WhereAtEnumerable<TEnumerable, TEnumerator, TSource> Where(PredicateAt<TSource> predicate)
                => ValueEnumerableExtensions.Where<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));

            public Option<TSource> ElementAt(int index)
                => ValueEnumerableExtensions.ElementAt<TEnumerable, TEnumerator, TSource>(source, index, predicate);

            public Option<TSource> First()
                => ValueEnumerableExtensions.First<TEnumerable, TEnumerator, TSource>(source, predicate);

            public Option<TSource> Single()
                => ValueEnumerableExtensions.Single<TEnumerable, TEnumerator, TSource>(source, predicate);
                
            public TSource[] ToArray()
                => ValueEnumerableExtensions.ToArray<TEnumerable, TEnumerator, TSource>(source, predicate);

            public List<TSource> ToList()
                => ValueEnumerableExtensions.ToList<TEnumerable, TEnumerator, TSource>(source, predicate);

            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector)
                => ValueEnumerableExtensions.ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(source, keySelector, null, predicate);
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
                => ValueEnumerableExtensions.ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(source, keySelector, comparer, predicate);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector)
                => ValueEnumerableExtensions.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(source, keySelector, elementSelector, null, predicate);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
                => ValueEnumerableExtensions.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, predicate);
        }
    }
}

