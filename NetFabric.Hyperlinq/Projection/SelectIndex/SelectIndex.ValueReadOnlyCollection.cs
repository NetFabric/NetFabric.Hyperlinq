using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        [Pure]
        public static SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TEnumerable, TEnumerator, TSource, TResult>(
            this TEnumerable source, 
            Func<TSource, int, TResult> selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if(selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TResult>(in source, selector);
        }

        [GenericsTypeMapping("TEnumerable", typeof(SelectIndexEnumerable<,,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(SelectIndexEnumerable<,,,>.Enumerator))]
        [GenericsMapping("TSource", "TResult")]
        public readonly struct SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TResult>
            : IValueReadOnlyCollection<TResult, SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator>
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TSource, int, TResult> selector;

            internal SelectIndexEnumerable(in TEnumerable source, Func<TSource, int, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public readonly int Count => source.Count;

            public struct Enumerator
                : IEnumerator<TResult>
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly
                readonly Func<TSource, int, TResult> selector;
                int index;

                internal Enumerator(in SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TResult> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    selector = enumerable.selector;
                    index = -1;
                }

                public readonly TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector(enumerator.Current, index);
                }
                readonly object IEnumerator.Current => selector(enumerator.Current, index);

                public bool MoveNext()
                {
                    if (enumerator.MoveNext())
                    {
                        index++; 
                        return true;
                    }
                    Dispose();
                    return false;
                }

                public readonly void Reset() => throw new NotSupportedException();

                public void Dispose() => enumerator.Dispose();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long LongCount()
                => source.Count;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Count != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueReadOnlyCollection.SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TSelectorResult> Select<TSelectorResult>(Func<TResult, TSelectorResult> selector)
                => ValueReadOnlyCollection.Select<TEnumerable, TEnumerator, TSource, TSelectorResult>(source, Utils.CombineSelectors(this.selector, selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueReadOnlyCollection.SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TSelectorResult> Select<TSelectorResult>(Func<TResult, int, TSelectorResult> selector)
                => ValueReadOnlyCollection.Select<TEnumerable, TEnumerator, TSource, TSelectorResult>(source, Utils.CombineSelectors(this.selector, selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult First()
                => selector(ValueReadOnlyCollection.First<TEnumerable, TEnumerator, TSource>(source), 0);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult FirstOrDefault()
                => selector(ValueReadOnlyCollection.FirstOrDefault<TEnumerable, TEnumerator, TSource>(source), 0);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult Single()
                => selector(ValueReadOnlyCollection.Single<TEnumerable, TEnumerator, TSource>(source), 0);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult SingleOrDefault()
                => selector(ValueReadOnlyCollection.SingleOrDefault<TEnumerable, TEnumerator, TSource>(source), 0);

            public TResult[] ToArray()
            {
                var array = new TResult[source.Count];

                if (source.Count != 0)
                {
                    var index = 0;
                    foreach (var item in source)
                    {
                        array[index] = selector(item, index);
                        checked { index++; }
                    }
                }

                return array;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TResult> ToList()
                => new List<TResult>(new ToListCollection(this));

            // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
            sealed class ToListCollection
                : ICollection<TResult>
            {
                readonly TEnumerable source;
                readonly Func<TSource, int, TResult> selector;

                public ToListCollection(in SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TResult> source)
                {
                    this.source = source.source;
                    this.selector = source.selector;
                }

                public int Count => source.Count;

                public bool IsReadOnly => true;

                public void CopyTo(TResult[] array, int _)
                {
                    var index = 0;
                    foreach (var item in source)
                    {
                        array[index] = selector(item, index);
                        checked { index++; }
                    }
                }

                IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => throw new NotSupportedException();
                IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
                void ICollection<TResult>.Add(TResult item) => throw new NotSupportedException();
                bool ICollection<TResult>.Remove(TResult item) => throw new NotSupportedException();
                void ICollection<TResult>.Clear() => throw new NotSupportedException();
                bool ICollection<TResult>.Contains(TResult item) => throw new NotSupportedException();

                public Dictionary<TKey, TResult> ToDictionary<TKey>(Func<TResult, TKey> keySelector)
                    => ToDictionary<TKey>(keySelector, EqualityComparer<TKey>.Default);
                public Dictionary<TKey, TResult> ToDictionary<TKey>(Func<TResult, TKey> keySelector, IEqualityComparer<TKey> comparer)
                {
                    var dictionary = new Dictionary<TKey, TResult>(source.Count, comparer);

                    if (source.Count != 0)
                    {
                        var index = 0;
                        TResult result;
                        foreach (var item in source)
                        {
                            result = selector(item, index);
                            dictionary.Add(keySelector(result), result);
                            checked { index++; }
                        }
                    }

                    return dictionary;
                }

                public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TResult, TKey> keySelector, Func<TResult, TElement> elementSelector)
                    => ToDictionary<TKey, TElement>(keySelector, elementSelector, EqualityComparer<TKey>.Default);
                public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TResult, TKey> keySelector, Func<TResult, TElement> elementSelector, IEqualityComparer<TKey> comparer)
                {
                    var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);

                    if (source.Count != 0)
                    {
                        var index = 0;
                        TResult result;
                        foreach (var item in source)
                        {
                            result = selector(item, index);
                            dictionary.Add(keySelector(result), elementSelector(result));
                            checked { index++; }
                        }
                    }

                    return dictionary;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TEnumerable, TEnumerator, TSource, TResult>(this SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TResult> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source.Count;
    }
}

