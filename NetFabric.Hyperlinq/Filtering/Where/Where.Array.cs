using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        public static WhereEnumerable<TSource> Where<TSource>(this TSource[] source, Predicate<TSource> predicate) 
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return new WhereEnumerable<TSource>(source, predicate, 0, source.Length);
        }

        [Pure]
        static WhereEnumerable<TSource> Where<TSource>(this TSource[] source, Predicate<TSource> predicate, int skipCount, int takeCount)
            => new WhereEnumerable<TSource>(source, predicate, skipCount, takeCount);

        public readonly partial struct WhereEnumerable<TSource>
            : IValueEnumerable<TSource, WhereEnumerable<TSource>.DisposableEnumerator>
        {
            readonly TSource[] source;
            readonly Predicate<TSource> predicate;
            readonly int skipCount;
            readonly int takeCount;

            internal WhereEnumerable(TSource[] source, Predicate<TSource> predicate, int skipCount, int takeCount)
            {
                this.source = source;
                this.predicate = predicate;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Length, skipCount, takeCount);
            }

            [Pure]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, WhereEnumerable<TSource>.DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            public struct Enumerator 
            {
                readonly TSource[] source;
                readonly Predicate<TSource> predicate;
                readonly int end;
                int index;

                internal Enumerator(in WhereEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                [MaybeNull]
                public readonly ref readonly TSource Current 
                    => ref source[index];
                
                public bool MoveNext()
                {
                    while (++index < end)
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
                readonly TSource[] source;
                readonly Predicate<TSource> predicate;
                readonly int end;
                int index;

                internal DisposableEnumerator(in WhereEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                [MaybeNull]
                public readonly ref readonly TSource Current 
                    => ref source[index];
                [MaybeNull]
                readonly TSource IEnumerator<TSource>.Current 
                    => source[index];
                readonly object? IEnumerator.Current 
                    => source[index];

                public bool MoveNext()
                {
                    while (++index < end)
                    {
                        if (predicate(source[index]))
                            return true;
                    }
                    return false;
                }

                public readonly void Reset() => throw new NotSupportedException();

                public readonly void Dispose() { }
            }

            public int Count()
                => Array.Count<TSource>(source, predicate, skipCount, takeCount);
            public int Count(Predicate<TSource> predicate)
                => Array.Count<TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);
            public int Count(PredicateAt<TSource> predicate)
                => Array.Count<TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);

            public long LongCount()
                => Array.LongCount<TSource>(source, predicate);
            public long LongCount(Predicate<TSource> predicate)
                => Array.LongCount<TSource>(source, Utils.Combine(this.predicate, predicate));

            public bool Any()
                => Array.Any<TSource>(source, predicate, skipCount, takeCount);
            public bool Any(Predicate<TSource> predicate)
                => Array.Any<TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);
            public bool Any(PredicateAt<TSource> predicate)
                => Array.Any<TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);

            public Array.WhereSelectEnumerable<TSource, TResult> Select<TResult>(Selector<TSource, TResult> selector)
                => Array.WhereSelect<TSource, TResult>(source, predicate, selector);

            public Array.WhereEnumerable<TSource> Where(Predicate<TSource> predicate)
                => Array.Where<TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);
            public Array.WhereIndexEnumerable<TSource> Where(PredicateAt<TSource> predicate)
                => Array.Where<TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);

            public ref readonly TSource First()
                => ref Array.First<TSource>(source, predicate, skipCount, takeCount);
            public ref readonly TSource First(Predicate<TSource> predicate)
                => ref Array.First<TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);
            public ref readonly TSource First(PredicateAt<TSource> predicate)
                => ref Array.First<TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);

            [return: MaybeNull]
            public ref readonly TSource FirstOrDefault()
                => ref Array.FirstOrDefault<TSource>(source, predicate, skipCount, takeCount);
            [return: MaybeNull]
            public ref readonly TSource FirstOrDefault(Predicate<TSource> predicate)
                => ref Array.FirstOrDefault<TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);
            [return: MaybeNull]
            public ref readonly TSource FirstOrDefault(PredicateAt<TSource> predicate)
                => ref Array.FirstOrDefault<TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);

            public ref readonly TSource Single()
                => ref Array.Single<TSource>(source, predicate, skipCount, takeCount);
            public ref readonly TSource Single(Predicate<TSource> predicate)
                => ref Array.Single<TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);
            public ref readonly TSource Single(PredicateAt<TSource> predicate)
                => ref Array.Single<TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);

            [return: MaybeNull]
            public ref readonly TSource SingleOrDefault()
                => ref Array.SingleOrDefault<TSource>(source, predicate, skipCount, takeCount);
            [return: MaybeNull]
            public ref readonly TSource SingleOrDefault(Predicate<TSource> predicate)
                => ref Array.SingleOrDefault<TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);
            [return: MaybeNull]
            public ref readonly TSource SingleOrDefault(PredicateAt<TSource> predicate)
                => ref Array.SingleOrDefault<TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);

            public List<TSource> ToList()
                => Array.ToList<TSource>(source, predicate, skipCount, takeCount);

            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector)
                => Array.ToDictionary<TSource, TKey>(source, keySelector, EqualityComparer<TKey>.Default, predicate, skipCount, takeCount);
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
                => Array.ToDictionary<TSource, TKey>(source, keySelector, comparer, predicate, skipCount, takeCount);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector)
                => Array.ToDictionary<TSource, TKey, TElement>(source, keySelector, elementSelector, EqualityComparer<TKey>.Default, predicate, skipCount, takeCount);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
                => Array.ToDictionary<TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, predicate, skipCount, takeCount);

            public void ForEach(Action<TSource> action)
                => Array.ForEach(source, action, predicate, 0, source.Length);
            public void ForEach(ActionAt<TSource> action)
                => Array.ForEach(source, action, predicate, skipCount, takeCount);
        }
    }
}

