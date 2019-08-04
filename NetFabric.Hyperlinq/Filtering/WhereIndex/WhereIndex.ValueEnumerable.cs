﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public static WhereIndexEnumerable<TEnumerable, TEnumerator, TSource> Where<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => new WhereIndexEnumerable<TEnumerable, TEnumerator, TSource>(in source, predicate);

        [GenericsTypeMapping("TEnumerable", typeof(WhereIndexEnumerable<,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(WhereIndexEnumerable<,,>.Enumerator))]
        public readonly struct WhereIndexEnumerable<TEnumerable, TEnumerator, TSource> 
            : IValueEnumerable<TSource, WhereIndexEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            internal readonly TEnumerable source;
            internal readonly Func<TSource, int, bool> predicate;

            internal WhereIndexEnumerable(in TEnumerable source, Func<TSource, int, bool> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IEnumerator<TSource>
            {
                TEnumerator enumerator;
                readonly Func<TSource, int, bool> predicate;
                int index;

                internal Enumerator(in WhereIndexEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    predicate = enumerable.predicate;
                    index = 0;
                }

                public TSource Current
                    => enumerator.Current;
                object IEnumerator.Current
                    => enumerator.Current;

                public bool MoveNext()
                {
                    checked
                    {
                        while (enumerator.MoveNext())
                        {
                            if (predicate(enumerator.Current, index))
                                return true;

                            index++;
                        }
                    }
                    return false;
                }

                void IEnumerator.Reset()
                    => throw new NotSupportedException();

                public void Dispose() => enumerator.Dispose();
            }

            public TSource First()
                => ValueEnumerable.TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate).ThrowOnEmpty();
            public TSource First(Func<TSource, bool> predicate)
                => ValueEnumerable.TryFirst<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate)).ThrowOnEmpty();
            public TSource First(Func<TSource, int, bool> predicate)
                => ValueEnumerable.TryFirst<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate)).ThrowOnEmpty();

            public TSource FirstOrDefault()
                => ValueEnumerable.TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate).DefaultOnEmpty();
            public TSource FirstOrDefault(Func<TSource, bool> predicate)
                => ValueEnumerable.TryFirst<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate)).DefaultOnEmpty();
            public TSource FirstOrDefault(Func<TSource, int, bool> predicate)
                => ValueEnumerable.TryFirst<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate)).DefaultOnEmpty();

            public (int Index, TSource Value) TryFirst()
                => ValueEnumerable.TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate);
            public (int Index, TSource Value) TryFirst(Func<TSource, bool> predicate)
                => ValueEnumerable.TryFirst<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate));
            public (int Index, TSource Value) TryFirst(Func<TSource, int, bool> predicate)
                => ValueEnumerable.TryFirst<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate));

            public TSource Single()
                => ValueEnumerable.TrySingle<TEnumerable, TEnumerator, TSource>(source, predicate).ThrowOnEmpty();
            public TSource Single(Func<TSource, bool> predicate)
                => ValueEnumerable.TrySingle<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate)).ThrowOnEmpty();
            public TSource Single(Func<TSource, int, bool> predicate)
                => ValueEnumerable.TrySingle<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate)).ThrowOnEmpty();

            public TSource SingleOrDefault()
                => ValueEnumerable.TrySingle<TEnumerable, TEnumerator, TSource>(source, predicate).DefaultOnEmpty();
            public TSource SingleOrDefault(Func<TSource, bool> predicate)
                => ValueEnumerable.TrySingle<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate)).DefaultOnEmpty();
            public TSource SingleOrDefault(Func<TSource, int, bool> predicate)
                => ValueEnumerable.TrySingle<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate)).DefaultOnEmpty();

            public (int Index, TSource Value) TrySingle()
                => ValueEnumerable.TrySingle<TEnumerable, TEnumerator, TSource>(source, predicate);
            public (int Index, TSource Value) TrySingle(Func<TSource, bool> predicate)
                => ValueEnumerable.TrySingle<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate));
            public (int Index, TSource Value) TrySingle(Func<TSource, int, bool> predicate)
                => ValueEnumerable.TrySingle<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate));

            public List<TSource> ToList()
                => ValueEnumerable.ToList<TEnumerable, TEnumerator, TSource>(source, predicate);

            public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector)
                => ValueEnumerable.ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(source, keySelector, EqualityComparer<TKey>.Default, predicate);
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
                => ValueEnumerable.ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(source, keySelector, comparer, predicate);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
                => ValueEnumerable.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(source, keySelector, elementSelector, EqualityComparer<TKey>.Default, predicate);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
                => ValueEnumerable.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, predicate);
        }
    }
}

