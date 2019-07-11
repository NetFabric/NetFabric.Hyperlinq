using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        public static SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TEnumerable, TEnumerator, TSource, TResult>(
            this TEnumerable source, 
            Func<TSource, TResult> selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if(selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>(in source, selector);
        }

        [GenericsTypeMapping("TEnumerable", typeof(SelectEnumerable<,,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(SelectEnumerable<,,,>.Enumerator))]
        [GenericsMapping("TSource", "TResult")]
        public readonly struct SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>
            : IValueReadOnlyCollection<TResult, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator>
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TSource, TResult> selector;

            internal SelectEnumerable(in TEnumerable source, Func<TSource, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public int Count => source.Count;

            public struct Enumerator
                : IEnumerator<TResult>
            {
                TEnumerator enumerator;
                readonly Func<TSource, TResult> selector;

                internal Enumerator(in SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    selector = enumerable.selector;
                }

                public TResult Current => selector(enumerator.Current);
                object IEnumerator.Current => selector(enumerator.Current);


                public bool MoveNext() => enumerator.MoveNext();

                void IEnumerator.Reset() => throw new NotSupportedException();

                public void Dispose() => enumerator.Dispose();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Count != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueReadOnlyCollection.SelectEnumerable<TEnumerable, TEnumerator, TSource, TSelectorResult> Select<TSelectorResult>(Func<TResult, TSelectorResult> selector)
                => ValueReadOnlyCollection.Select<TEnumerable, TEnumerator, TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult First()
                => selector(ValueReadOnlyCollection.First<TEnumerable, TEnumerator, TSource>(source));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult FirstOrDefault()
                => selector(ValueReadOnlyCollection.FirstOrDefault<TEnumerable, TEnumerator, TSource>(source));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult Single()
                => selector(ValueReadOnlyCollection.Single<TEnumerable, TEnumerator, TSource>(source));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult SingleOrDefault()
                => selector(ValueReadOnlyCollection.SingleOrDefault<TEnumerable, TEnumerator, TSource>(source));

            public TResult[] ToArray()
            {
                var array = new TResult[source.Count];

                using (var enumerator = source.GetEnumerator())
                {
                    for (var index = 0; enumerator.MoveNext(); index++)
                        array[index] = selector(enumerator.Current);
                }

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
                readonly Func<TSource, TResult> selector;

                public ToListCollection(in SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source)
                {
                    this.source = source.source;
                    this.selector = source.selector;
                }

                public int Count => source.Count;

                public bool IsReadOnly => true;

                public void CopyTo(TResult[] array, int _)
                {
                    using (var enumerator = source.GetEnumerator())
                    {
                        for (var index = 0; enumerator.MoveNext(); index++)
                            array[index] = selector(enumerator.Current);
                    }
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

