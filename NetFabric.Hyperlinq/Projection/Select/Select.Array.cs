using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static SelectEnumerable<TSource, TResult> Select<TSource, TResult>(
            this TSource[] source, 
            Func<TSource, TResult> selector)
        {
            if (selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new SelectEnumerable<TSource, TResult>(source, selector, 0, source.Length);
        }

        static SelectEnumerable<TSource, TResult> Select<TSource, TResult>(
            this TSource[] source,
            Func<TSource, TResult> selector,
            int skipCount, int takeCount)
            => new SelectEnumerable<TSource, TResult>(source, selector, skipCount, takeCount);

        [GenericsTypeMapping("TEnumerable", typeof(SelectEnumerable<,>))]
        [GenericsTypeMapping("TEnumerator", typeof(SelectEnumerable<,>.Enumerator))]
        [GenericsMapping("TSource", "TResult")]
        [GenericsMapping("TResult", "TSelectorResult")]
        public readonly struct SelectEnumerable<TSource, TResult>
            : IValueReadOnlyList<TResult, SelectEnumerable<TSource, TResult>.Enumerator>
        {
            internal readonly TSource[] source;
            internal readonly Func<TSource, TResult> selector;
            internal readonly int skipCount;
            internal readonly int takeCount;

            internal SelectEnumerable(TSource[] source, Func<TSource, TResult> selector, int skipCount, int takeCount)
            {
                this.source = source;
                this.selector = selector;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Length, skipCount, takeCount);
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public int Count => takeCount;

            public TResult this[int index]
            {
                get
                {
                    if (index < 0 || index >= takeCount)
                        ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index));

                    return selector(source[index + skipCount]);
                }
            }

            public struct Enumerator
                : IEnumerator<TResult>
            {
                readonly TSource[] source;
                readonly Func<TSource, TResult> selector;
                readonly int end;
                int index;

                internal Enumerator(in SelectEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                public TResult Current
                    => selector(source[index]);
                object IEnumerator.Current
                    => selector(source[index]);

                public bool MoveNext()
                    => ++index < end;

                void IEnumerator.Reset()
                    => throw new NotSupportedException();

                public void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectEnumerable<TSource, TResult> Skip(int count)
                => new SelectEnumerable<TSource, TResult>(source, selector, skipCount + count, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectEnumerable<TSource, TResult> Take(int count)
                => new SelectEnumerable<TSource, TResult>(source, selector, skipCount, Math.Min(takeCount, count));


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => takeCount != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Array.SelectEnumerable<TSource, TSelectorResult> Select<TSelectorResult>(Func<TResult, TSelectorResult> selector)
                => Array.Select<TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector), skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult First()
                => selector(Array.First<TSource>(source, skipCount, takeCount));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult FirstOrDefault()
                => selector(Array.FirstOrDefault<TSource>(source, skipCount, takeCount));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult Single()
                => selector(Array.Single<TSource>(source, skipCount, takeCount));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult SingleOrDefault()
                => selector(Array.SingleOrDefault<TSource>(source, skipCount, takeCount));

            public TResult[] ToArray()
            {
                var array = new TResult[takeCount];

                for (var index = 0; index < takeCount; index++)
                    array[index] = selector(source[index + skipCount]);

                return array;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TResult> ToList()
                => new List<TResult>(new ToListCollection(this));

            public Dictionary<TKey, TResult> ToDictionary<TKey>(Func<TResult, TKey> keySelector)
                => ToDictionary<TKey>(keySelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TResult> ToDictionary<TKey>(Func<TResult, TKey> keySelector, IEqualityComparer<TKey> comparer)
            {
                var dictionary = new Dictionary<TKey, TResult>(source.Length, comparer);

                TResult item;
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    item = selector(source[index]);
                    dictionary.Add(keySelector(item), item);
                }

                return dictionary;
            }

            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TResult, TKey> keySelector, Func<TResult, TElement> elementSelector)
                => ToDictionary<TKey, TElement>(keySelector, elementSelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TResult, TKey> keySelector, Func<TResult, TElement> elementSelector, IEqualityComparer<TKey> comparer)
            {
                var dictionary = new Dictionary<TKey, TElement>(source.Length, comparer);

                TResult item;
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    item = selector(source[index]);
                    dictionary.Add(keySelector(item), elementSelector(item));
                }

                return dictionary;
            }

            // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
            sealed class ToListCollection
                : ICollection<TResult>
            {
                readonly TSource[] source;
                readonly Func<TSource, TResult> selector;
                readonly int skipCount;
                readonly int takeCount;

                public ToListCollection(in SelectEnumerable<TSource, TResult> source)
                {
                    this.source = source.source;
                    this.selector = source.selector;
                    this.skipCount = source.skipCount;
                    this.takeCount = source.takeCount;
                }

                public int Count => takeCount;

                public bool IsReadOnly => true;

                public void CopyTo(TResult[] array, int _)
                {
                    for (var index = 0; index < takeCount; index++)
                        array[index] = selector(source[index + skipCount]);
                }

                IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => throw new NotSupportedException();
                IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
                void ICollection<TResult>.Add(TResult item) => throw new NotSupportedException();
                bool ICollection<TResult>.Remove(TResult item) => throw new NotSupportedException();
                void ICollection<TResult>.Clear() => throw new NotSupportedException();
                bool ICollection<TResult>.Contains(TResult item) => throw new NotSupportedException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource, TResult>(this SelectEnumerable<TSource, TResult> source)
            => source.Count;
    }
}

