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
        public static MemoryWhereAtEnumerable<TSource> Where<TSource>(this TSource[] source, PredicateAt<TSource> predicate)
            => Where(source.AsMemory(), predicate);

#else

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static WhereAtEnumerable<TSource> Where<TSource>(this TSource[] source, PredicateAt<TSource> predicate)
        {
            if (predicate is null)
                Throw.ArgumentNullException(nameof(predicate));

            return new WhereAtEnumerable<TSource>(in source, predicate, 0, source.Length);
        }


        static WhereAtEnumerable<TSource> Where<TSource>(this TSource[] source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            => new WhereAtEnumerable<TSource>(in source, predicate, skipCount, takeCount);

        public readonly partial struct WhereAtEnumerable<TSource>
            : IValueEnumerable<TSource, WhereAtEnumerable<TSource>.DisposableEnumerator>
        {
            readonly TSource[] source;
            readonly PredicateAt<TSource> predicate;
            readonly int skipCount;
            readonly int takeCount;

            internal WhereAtEnumerable(in TSource[] source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            {
                this.source = source;
                this.predicate = predicate;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Length, skipCount, takeCount);
            }


            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, WhereAtEnumerable<TSource>.DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            public struct Enumerator
            {
                readonly TSource[] source;
                readonly PredicateAt<TSource> predicate;
                readonly int end;
                int index;

                internal Enumerator(in WhereAtEnumerable<TSource> enumerable)
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

                internal DisposableEnumerator(in WhereAtEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                public readonly TSource Current
                    => source[index];
                readonly TSource IEnumerator<TSource>.Current
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
                    => Throw.NotSupportedException();

                public readonly void Dispose() { }
            }

            public int Count()
                => Array.Count<TSource>(source, predicate, skipCount, takeCount);

            public bool Any()
                => Array.Any<TSource>(source, predicate, skipCount, takeCount);

            public WhereAtEnumerable<TSource> Where(Predicate<TSource> predicate)
                => Array.Where<TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);
            public WhereAtEnumerable<TSource> Where(PredicateAt<TSource> predicate)
                => Array.Where<TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);

            public Option<TSource> ElementAt(int index)
                => Array.ElementAt<TSource>(source, index, predicate, skipCount, takeCount);

            public Option<TSource> First()
                => Array.First<TSource>(source, predicate, skipCount, takeCount);

            public Option<TSource> Single()
                => Array.Single<TSource>(source, predicate, skipCount, takeCount);

            public TSource[] ToArray()
                => Array.ToArray<TSource>(source, predicate, skipCount, takeCount);

            public List<TSource> ToList()
                => Array.ToList<TSource>(source, predicate, skipCount, takeCount);

            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector)
                => Array.ToDictionary<TSource, TKey>(source, keySelector, null, predicate, skipCount, takeCount);
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
                => Array.ToDictionary<TSource, TKey>(source, keySelector, comparer, predicate, skipCount, takeCount);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector)
                => Array.ToDictionary<TSource, TKey, TElement>(source, keySelector, elementSelector, null, predicate, skipCount, takeCount);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
                => Array.ToDictionary<TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, predicate, skipCount, takeCount);

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

