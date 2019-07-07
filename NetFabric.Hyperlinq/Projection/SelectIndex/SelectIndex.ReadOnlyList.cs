using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectIndexEnumerable<TEnumerable, TSource, TResult> Skip(int count)
                => new SelectIndexEnumerable<TEnumerable, TSource, TResult>(source, selector, skipCount + count, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectIndexEnumerable<TEnumerable, TSource, TResult> Take(int count)
                => new SelectIndexEnumerable<TEnumerable, TSource, TResult>(source, selector, skipCount, Math.Min(takeCount, count));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Count != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyList.SelectIndexEnumerable<TEnumerable, TSource, TSelectorResult> Select<TSelectorResult>(Func<TResult, long, TSelectorResult> selector)
                => ReadOnlyList.Select<TEnumerable, TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult First()
                => selector(ReadOnlyList.First<TEnumerable, TSource>(source), 0);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult FirstOrDefault()
                => selector(ReadOnlyList.FirstOrDefault<TEnumerable, TSource>(source), 0);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult Single()
                => selector(ReadOnlyList.Single<TEnumerable, TSource>(source), 0);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult SingleOrDefault()
                => selector(ReadOnlyList.SingleOrDefault<TEnumerable, TSource>(source), 0);

            public TResult[] ToArray()
            {
                var array = new TResult[takeCount];

                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                    array[index] = selector(source[index], index);

                return array;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TResult> ToList()
                => new List<TResult>(new ToListCollection(this));

            // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
            class ToListCollection
                : ICollection<TResult>
            {
                readonly TEnumerable source;
                readonly Func<TSource, long, TResult> selector;
                readonly int skipCount;
                readonly int takeCount;

                public ToListCollection(in SelectIndexEnumerable<TEnumerable, TSource, TResult> source)
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
                        array[index] = selector(source[index + skipCount], index);
                }

                IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => throw new NotSupportedException();
                IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
                void ICollection<TResult>.Add(TResult item) => throw new NotSupportedException();
                bool ICollection<TResult>.Remove(TResult item) => throw new NotSupportedException();
                void ICollection<TResult>.Clear() => throw new NotSupportedException();
                bool ICollection<TResult>.Contains(TResult item) => throw new NotSupportedException();
            }
        }
    }
}

