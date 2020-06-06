using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
#if SPAN_SUPPORTED

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryWhereIndexEnumerable<TSource> Where<TSource>(this TSource[] source, PredicateAt<TSource> predicate)
            => Where(source.AsMemory(), predicate);

#else

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static WhereIndexEnumerable<TSource> Where<TSource>(this TSource[] source, PredicateAt<TSource> predicate)
        {
            if (predicate is null)
                Throw.ArgumentNullException(nameof(predicate));

            return new WhereIndexEnumerable<TSource>(in source, predicate, 0, source.Length);
        }


        static WhereIndexEnumerable<TSource> Where<TSource>(this TSource[] source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            => new WhereIndexEnumerable<TSource>(in source, predicate, skipCount, takeCount);

        public readonly partial struct WhereIndexEnumerable<TSource>
            : IValueEnumerable<TSource, WhereIndexEnumerable<TSource>.DisposableEnumerator>
        {
            readonly TSource[] source;
            readonly PredicateAt<TSource> predicate;
            readonly int skipCount;
            readonly int takeCount;

            internal WhereIndexEnumerable(in TSource[] source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            {
                this.source = source;
                this.predicate = predicate;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Length, skipCount, takeCount);
            }


            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, WhereIndexEnumerable<TSource>.DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            public struct Enumerator
            {
                readonly TSource[] source;
                readonly PredicateAt<TSource> predicate;
                readonly int end;
                int index;

                internal Enumerator(in WhereIndexEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                [MaybeNull]
                public readonly TSource Current
                    => source[index];

                public bool MoveNext()
                {
                    while (++index < end)
                    {
                        if (predicate(source[index], index))
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
                readonly int end;
                int index;

                internal DisposableEnumerator(in WhereIndexEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                public readonly TSource Current
                    => source[index];
                readonly object? IEnumerator.Current
                    => source[index];

                public bool MoveNext()
                {
                    while (++index < end)
                    {
                        if (predicate(source[index], index))
                            return true;
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset()
                    => throw new NotSupportedException();

                public readonly void Dispose() { }
            }

            public int Count()
                => Count<TSource>(source, predicate, skipCount, takeCount);

            public bool Any()
                => Any<TSource>(source, predicate, skipCount, takeCount);

            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer = null)
                => Contains<TSource>(source, value, comparer, predicate, skipCount, takeCount);

            public WhereIndexEnumerable<TSource> Where(Predicate<TSource> predicate)
                => Where<TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);
            public WhereIndexEnumerable<TSource> Where(PredicateAt<TSource> predicate)
                => Where<TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);

            public Option<TSource> ElementAt(int index)
                => ElementAt<TSource>(source, index, predicate, skipCount, takeCount);

            public Option<TSource> First()
                => First<TSource>(source, predicate, skipCount, takeCount);

            public Option<TSource> Single()
                => Single<TSource>(source, predicate, skipCount, takeCount);

            public TSource[] ToArray()
                => ToArray<TSource>(source, predicate, skipCount, takeCount);

            public List<TSource> ToList()
                => ToList<TSource>(source, predicate, skipCount, takeCount);

            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector)
                => ToDictionary<TSource, TKey>(source, keySelector, EqualityComparer<TKey>.Default, predicate, skipCount, takeCount);
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
                => ToDictionary<TSource, TKey>(source, keySelector, comparer, predicate, skipCount, takeCount);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector)
                => ToDictionary<TSource, TKey, TElement>(source, keySelector, elementSelector, EqualityComparer<TKey>.Default, predicate, skipCount, takeCount);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
                => ToDictionary<TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, predicate, skipCount, takeCount);

            public readonly bool SequenceEqual(IEnumerable<TSource> other, IEqualityComparer<TSource>? comparer = null)
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

#endif
    }
}

