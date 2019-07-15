using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        public static SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TEnumerable, TEnumerator, TSource, TResult>(
            this TEnumerable source, 
            Func<TSource, int, TResult> selector)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if(selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TResult>(in source, selector, 0, source.Count);
        }

        static SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TEnumerable, TEnumerator, TSource, TResult>(
            this TEnumerable source,
            Func<TSource, int, TResult> selector,
            int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => new SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TResult>(source, selector, skipCount, takeCount);

        [GenericsTypeMapping("TEnumerable", typeof(SelectIndexEnumerable<,,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(SelectIndexEnumerable<,,,>.Enumerator))]
        [GenericsMapping("TSource", "TResult")]
        public readonly struct SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TResult>
            : IValueReadOnlyList<TResult, SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator>
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TSource, int, TResult> selector;
            readonly int skipCount;
            readonly int takeCount;

            internal SelectIndexEnumerable(in TEnumerable source, Func<TSource, int, TResult> selector, int skipCount, int takeCount)
            {
                this.source = source;
                this.selector = selector;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Count, skipCount, takeCount);
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

                    return selector(source[index + skipCount], index);
                }
            }

            public struct Enumerator
                : IEnumerator<TResult>
            {
                readonly TEnumerable source;
                readonly Func<TSource, int, TResult> selector;
                readonly int end;
                int index;

                internal Enumerator(in SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                public TResult Current
                    => selector(source[index], index);

                object IEnumerator.Current
                    => source[index];

                public bool MoveNext()
                    => ++index < end;

                void IEnumerator.Reset()
                    => throw new NotSupportedException();

                public void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => takeCount != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueReadOnlyList.SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TSelectorResult> Select<TSelectorResult>(Func<TResult, int, TSelectorResult> selector)
                => ValueReadOnlyList.Select<TEnumerable, TEnumerator, TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector), skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult First()
                => selector(ValueReadOnlyList.TryFirst<TEnumerable, TEnumerator, TSource>(source, skipCount, takeCount).ThrowOnEmpty(), skipCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult FirstOrDefault()
                => selector(ValueReadOnlyList.TryFirst<TEnumerable, TEnumerator, TSource>(source, skipCount, takeCount).DefaultOnEmpty(), skipCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult Single()
                => selector(ValueReadOnlyList.TrySingle<TEnumerable, TEnumerator, TSource>(source, skipCount, takeCount).ThrowOnEmpty(), skipCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult SingleOrDefault()
                => selector(ValueReadOnlyList.TrySingle<TEnumerable, TEnumerator, TSource>(source, skipCount, takeCount).DefaultOnEmpty(), skipCount);

            public TResult[] ToArray()
            {
                var array = new TResult[takeCount];

                for (var index = 0; index < takeCount; index++)
                    array[index] = selector(source[index + skipCount], index);

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
                readonly int skipCount;
                readonly int takeCount;

                public ToListCollection(in SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TResult> source)
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TEnumerable, TEnumerator, TSource, TResult>(this SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TResult> source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source.Count;
    }
}

