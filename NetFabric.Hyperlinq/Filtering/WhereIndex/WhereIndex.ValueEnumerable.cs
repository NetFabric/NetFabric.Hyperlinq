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
        public static WhereIndexEnumerable<TEnumerable, TEnumerator, TSource> Where<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return new WhereIndexEnumerable<TEnumerable, TEnumerator, TSource>(in source, predicate);
        }

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
                readonly Func<TSource, int, bool> predicate;
                int index;

                internal Enumerator(in WhereIndexEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    predicate = enumerable.predicate;
                    index = 0;
                }

                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => enumerator.Current;
                }
                readonly object IEnumerator.Current => enumerator.Current;

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

                public readonly void Reset() => throw new NotSupportedException();

                public void Dispose() => enumerator.Dispose();
            }

            public TSource First()
                => ValueEnumerable.GetFirst<TEnumerable, TEnumerator, TSource>(source, predicate).ThrowOnEmpty();
            public TSource First(Func<TSource, bool> predicate)
                => ValueEnumerable.GetFirst<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate)).ThrowOnEmpty();
            public TSource First(Func<TSource, int, bool> predicate)
                => ValueEnumerable.GetFirst<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate)).ThrowOnEmpty();

            public TSource FirstOrDefault()
                => ValueEnumerable.GetFirst<TEnumerable, TEnumerator, TSource>(source, predicate).DefaultOnEmpty();
            public TSource FirstOrDefault(Func<TSource, bool> predicate)
                => ValueEnumerable.GetFirst<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate)).DefaultOnEmpty();
            public TSource FirstOrDefault(Func<TSource, int, bool> predicate)
                => ValueEnumerable.GetFirst<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate)).DefaultOnEmpty();

            public (int Index, TSource Value) TryFirst()
                => ValueEnumerable.GetFirst<TEnumerable, TEnumerator, TSource>(source, predicate);
            public (int Index, TSource Value) TryFirst(Func<TSource, bool> predicate)
                => ValueEnumerable.GetFirst<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate));
            public (int Index, TSource Value) TryFirst(Func<TSource, int, bool> predicate)
                => ValueEnumerable.GetFirst<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate));

            public TSource Single()
                => ValueEnumerable.GetSingle<TEnumerable, TEnumerator, TSource>(source, predicate).ThrowOnEmpty();
            public TSource Single(Func<TSource, bool> predicate)
                => ValueEnumerable.GetSingle<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate)).ThrowOnEmpty();
            public TSource Single(Func<TSource, int, bool> predicate)
                => ValueEnumerable.GetSingle<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate)).ThrowOnEmpty();

            public TSource SingleOrDefault()
                => ValueEnumerable.GetSingle<TEnumerable, TEnumerator, TSource>(source, predicate).DefaultOnEmpty();
            public TSource SingleOrDefault(Func<TSource, bool> predicate)
                => ValueEnumerable.GetSingle<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate)).DefaultOnEmpty();
            public TSource SingleOrDefault(Func<TSource, int, bool> predicate)
                => ValueEnumerable.GetSingle<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate)).DefaultOnEmpty();

            public List<TSource> ToList()
                => ValueEnumerable.ToList<TEnumerable, TEnumerator, TSource>(source, predicate);

            public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector)
                => ValueEnumerable.ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(source, keySelector, EqualityComparer<TKey>.Default, predicate);
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
                => ValueEnumerable.ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(source, keySelector, comparer, predicate);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
                => ValueEnumerable.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(source, keySelector, elementSelector, EqualityComparer<TKey>.Default, predicate);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
                => ValueEnumerable.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, predicate);
        }
    }
}

