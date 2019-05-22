using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static SelectIndexEnumerable<TEnumerable, TSource, TResult> Select<TEnumerable, TSource, TResult>(
            this TEnumerable source, 
            Func<TSource, long, TResult> selector)
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new SelectIndexEnumerable<TEnumerable, TSource, TResult>(source, selector, 0, source.Count);
        }

        [GenericsTypeMapping("TEnumerable", typeof(SelectIndexEnumerable<,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(SelectIndexEnumerable<,,>.Enumerator))]
        [GenericsMapping("TSource", "TResult")]
        public readonly struct SelectIndexEnumerable<TEnumerable, TSource, TResult>
            : IValueReadOnlyList<TResult, SelectIndexEnumerable<TEnumerable, TSource, TResult>.Enumerator>
            where TEnumerable : IReadOnlyList<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TSource, long, TResult> selector;
            readonly int skipCount;
            readonly int takeCount;

            internal SelectIndexEnumerable(in TEnumerable source, Func<TSource, long, TResult> selector, int skipCount, int takeCount)
            {
                this.source = source;
                this.selector = selector;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Count, skipCount, takeCount);
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public int Count => takeCount;
            long IValueReadOnlyCollection<TResult, Enumerator>.Count => takeCount;

            public TResult this[int index]
            {
                get
                {
                    if (index < 0 || index >= takeCount)
                        ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index));

                    var currentIndex = index + skipCount;
                    return selector(source[currentIndex], currentIndex);
                }
            }

            TResult IValueReadOnlyList<TResult, Enumerator>.this[long index]
            {
                get
                {
                    if (index > int.MaxValue)
                        ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index));

                    return this[(int)index];
                }
            }
            
            public struct Enumerator
                : IValueEnumerator<TResult>
            {
                readonly TEnumerable source;
                readonly Func<TSource, long, TResult> selector;
                readonly int end;
                int index;

                internal Enumerator(in SelectIndexEnumerable<TEnumerable, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                public TResult Current
                    => selector(source[index], index);

                public bool MoveNext()
                    => ++index < end;

                public void Dispose() { }
            }

            public SelectIndexEnumerable<TEnumerable, TSource, TResult> Skip(int count)
                => new SelectIndexEnumerable<TEnumerable, TSource, TResult>(source, selector, skipCount + count, takeCount);

            public SelectIndexEnumerable<TEnumerable, TSource, TResult> Take(int count)
                => new SelectIndexEnumerable<TEnumerable, TSource, TResult>(source, selector, skipCount, Math.Min(takeCount, count));

            public bool Any()
                => source.Count != 0;

            public ReadOnlyList.SelectIndexEnumerable<TEnumerable, TSource, TSelectorResult> Select<TSelectorResult>(Func<TResult, long, TSelectorResult> selector)
                => ReadOnlyList.Select<TEnumerable, TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector));

            public TResult First()
                => selector(ReadOnlyList.First<TEnumerable, TSource>(source), 0);
            public TResult FirstOrDefault()
                => selector(ReadOnlyList.FirstOrDefault<TEnumerable, TSource>(source), 0);

            public TResult Single()
                => selector(ReadOnlyList.Single<TEnumerable, TSource>(source), 0);
            public TResult SingleOrDefault()
                => selector(ReadOnlyList.SingleOrDefault<TEnumerable, TSource>(source), 0);
        }
    }
}

