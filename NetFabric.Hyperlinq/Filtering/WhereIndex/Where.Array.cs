using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        public static WhereIndexEnumerable<TSource> Where<TSource>(this TSource[] source, Func<TSource, int, bool> predicate) 
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return new WhereIndexEnumerable<TSource>(source, predicate, 0, source.Length);
        }

        [Pure]
        static WhereIndexEnumerable<TSource> Where<TSource>(this TSource[] source, Func<TSource, int, bool> predicate, int skipCount, int takeCount)
            => new WhereIndexEnumerable<TSource>(source, predicate, skipCount, takeCount);

        [GenericsTypeMapping("TEnumerable", typeof(WhereEnumerable<>))]
        [GenericsTypeMapping("TEnumerator", typeof(WhereEnumerable<>.Enumerator))]
        public readonly struct WhereIndexEnumerable<TSource>
            : IValueEnumerable<TSource, WhereIndexEnumerable<TSource>.Enumerator>
        {
            readonly TSource[] source;
            readonly Func<TSource, int, bool> predicate;
            readonly int skipCount;
            readonly int takeCount;

            internal WhereIndexEnumerable(TSource[] source, Func<TSource, int, bool> predicate, int skipCount, int takeCount)
            {
                this.source = source;
                this.predicate = predicate;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Length, skipCount, takeCount);
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator 
                : IEnumerator<TSource>
            {
                readonly TSource[] source;
                readonly Func<TSource, int, bool> predicate;
                readonly int end;
                int index;

                internal Enumerator(in WhereIndexEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                public ref TSource Current => ref source[index];
                TSource IEnumerator<TSource>.Current => source[index];
                object IEnumerator.Current => source[index];

                public bool MoveNext()
                {
                    while (++index < end)
                    {
                        if (predicate(source[index], index))
                            return true;
                    }
                    return false;
                }

                void IEnumerator.Reset() => throw new NotSupportedException();

                public void Dispose() { }
            }

            public int Count()
                => Array.Count<TSource>(source, predicate, skipCount, takeCount);
            public int Count(Func<TSource, bool> predicate)
                => Array.Count<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);
            public int Count(Func<TSource, int, bool> predicate)
                => Array.Count<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);

            public bool Any()
                => Array.Any<TSource>(source, predicate, skipCount, takeCount);
            public bool Any(Func<TSource, bool> predicate)
                => Array.Any<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);
            public bool Any(Func<TSource, int, bool> predicate)
                => Array.Any<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);

            public Array.WhereIndexEnumerable<TSource> Where(Func<TSource, bool> predicate)
                => Array.Where<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);
            public Array.WhereIndexEnumerable<TSource> Where(Func<TSource, int, bool> predicate)
                => Array.Where<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);

            public ref readonly TSource First()
                => ref Array.First<TSource>(source, predicate, skipCount, takeCount);
            public ref readonly TSource First(out int index)
                => ref Array.First<TSource>(source, predicate, out index, skipCount, takeCount);
            public ref readonly TSource First(Func<TSource, bool> predicate)
                => ref Array.First<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);
            public ref readonly TSource First(Func<TSource, int, bool> predicate)
                => ref Array.First<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);

            public ref readonly TSource FirstOrDefault()
                => ref Array.FirstOrDefault<TSource>(source, predicate, skipCount, takeCount);
            public ref readonly TSource FirstOrDefault(out int index)
                => ref Array.FirstOrDefault<TSource>(source, predicate, out index, skipCount, takeCount);
            public ref readonly TSource FirstOrDefault(Func<TSource, bool> predicate)
                => ref Array.FirstOrDefault<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);
            public ref readonly TSource FirstOrDefault(Func<TSource, int, bool> predicate)
                => ref Array.FirstOrDefault<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);

            public ref readonly TSource Single()
                => ref Array.Single<TSource>(source, predicate, skipCount, takeCount);
            public ref readonly TSource Single(out int index)
                => ref Array.Single<TSource>(source, predicate, out index, skipCount, takeCount);
            public ref readonly TSource Single(Func<TSource, bool> predicate)
                => ref Array.Single<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);
            public ref readonly TSource Single(Func<TSource, int, bool> predicate)
                => ref Array.Single<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);

            public ref readonly TSource SingleOrDefault()
                => ref Array.SingleOrDefault<TSource>(source, predicate, skipCount, takeCount);
            public ref readonly TSource SingleOrDefault(out int index)
                => ref Array.SingleOrDefault<TSource>(source, predicate, out index, skipCount, takeCount);
            public ref readonly TSource SingleOrDefault(Func<TSource, bool> predicate)
                => ref Array.SingleOrDefault<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);
            public ref readonly TSource SingleOrDefault(Func<TSource, int, bool> predicate)
                => ref Array.SingleOrDefault<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);

            public List<TSource> ToList()
                => Array.ToList<TSource>(source, predicate, skipCount, takeCount);

            public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector)
                => Array.ToDictionary<TSource, TKey>(source, keySelector, EqualityComparer<TKey>.Default, predicate, skipCount, takeCount);
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
                => Array.ToDictionary<TSource, TKey>(source, keySelector, comparer, predicate, skipCount, takeCount);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
                => Array.ToDictionary<TSource, TKey, TElement>(source, keySelector, elementSelector, EqualityComparer<TKey>.Default, predicate, skipCount, takeCount);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
                => Array.ToDictionary<TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, predicate, skipCount, takeCount);
        }
    }
}

