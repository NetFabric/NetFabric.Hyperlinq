using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static SelectEnumerable<TEnumerable, TSource, TResult> Select<TEnumerable, TSource, TResult>(
            this TEnumerable source, 
            Func<TSource, TResult> selector)
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new SelectEnumerable<TEnumerable, TSource, TResult>(source, selector, 0, source.Count);
        }

        [GenericsTypeMapping("TEnumerable", typeof(SelectEnumerable<,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(SelectEnumerable<,,>.Enumerator))]
        [GenericsMapping("TSource", "TResult")]
        public readonly struct SelectEnumerable<TEnumerable, TSource, TResult>
            : IValueReadOnlyList<TResult, SelectEnumerable<TEnumerable, TSource, TResult>.Enumerator>
            where TEnumerable : IReadOnlyList<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TSource, TResult> selector;
            readonly int skipCount;
            readonly int takeCount;

            internal SelectEnumerable(in TEnumerable source, Func<TSource, TResult> selector, int skipCount, int takeCount)
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
                    return selector(source[currentIndex]);
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
                readonly Func<TSource, TResult> selector;
                readonly int end;
                int index;

                internal Enumerator(in SelectEnumerable<TEnumerable, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                public TResult Current
                    => selector(source[index]);

                public bool MoveNext()
                    => ++index < end;

                public void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectEnumerable<TEnumerable, TSource, TResult> Skip(int count)
                => new SelectEnumerable<TEnumerable, TSource, TResult>(source, selector, skipCount + count, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectEnumerable<TEnumerable, TSource, TResult> Take(int count)
                => new SelectEnumerable<TEnumerable, TSource, TResult>(source, selector, skipCount, Math.Min(takeCount, count));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Count != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyList.SelectEnumerable<TEnumerable, TSource, TSelectorResult> Select<TSelectorResult>(Func<TResult, TSelectorResult> selector)
                => ReadOnlyList.Select<TEnumerable, TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult First()
                => selector(ReadOnlyList.First<TEnumerable, TSource>(source));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult FirstOrDefault()
                => selector(ReadOnlyList.FirstOrDefault<TEnumerable, TSource>(source));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult Single()
                => selector(ReadOnlyList.Single<TEnumerable, TSource>(source));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult SingleOrDefault()
                => selector(ReadOnlyList.SingleOrDefault<TEnumerable, TSource>(source));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Count<TEnumerable, TSource, TResult>(this SelectEnumerable<TEnumerable, TSource, TResult> source)
            where TEnumerable : IReadOnlyList<TSource>
            => source.Count;
    }
}

