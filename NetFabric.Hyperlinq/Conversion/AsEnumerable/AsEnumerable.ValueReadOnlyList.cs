using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        public static IReadOnlyList<TSource> AsEnumerable<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source.Count > int.MaxValue) ThrowHelper.ThrowArgumentTooLargeException(nameof(source), source.Count);
            
            return new AsEnumerableEnumerable<TEnumerable, TEnumerator, TSource>(source);
        }

        class AsEnumerableEnumerable<TEnumerable, TEnumerator, TSource>
            : IReadOnlyList<TSource>
            , IList<TSource>
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            readonly TEnumerable source;

            internal AsEnumerableEnumerable(in TEnumerable source)
            {
                this.source = source;
            }

            public IEnumerator<TSource> GetEnumerator() => new Enumerator(this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(this);

            public int Count => (int)source.Count;

            public bool IsReadOnly => true;

            public TSource this[int index] 
            {
                get => source[index];
                set => throw new NotSupportedException();
            }

            public bool Contains(TSource item) 
                => ValueReadOnlyCollection.Contains<TEnumerable, TEnumerator, TSource>(source, item);

            public void CopyTo(TSource[] array, int arrayIndex)
            {
                if (arrayIndex < 0) ThrowHelper.ThrowArgumentOutOfRangeException(nameof(arrayIndex));

                var count = (int)source.Count;
                unchecked
                {
                    for (var index = 0; index < count; count++)
                        array[index + arrayIndex] = source[index];
                }
            }

            public int IndexOf(TSource item)
            {
                var count = (int)source.Count;
                unchecked
                {
                    for (var index = 0; index < count; count++)
                    {
                        if (item.Equals(source[index]))
                            return index;
                    }
                }
                return -1;
            }

            void ICollection<TSource>.Add(TSource item) => throw new NotSupportedException();
            bool ICollection<TSource>.Remove(TSource item) => throw new NotSupportedException();
            void ICollection<TSource>.Clear() => throw new NotSupportedException();
            void IList<TSource>.Insert(int index, TSource item) => throw new NotSupportedException();
            void IList<TSource>.RemoveAt(int index) => throw new NotSupportedException();

            class Enumerator
                : IEnumerator<TSource>
            {
                TEnumerable source;
                readonly long count;
                int index;

                internal Enumerator(AsEnumerableEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    source = enumerable.source;
                    count = source.Count;
                    index = -1;
                }

                public TSource Current => source[index];
                object IEnumerator.Current => source[index];

                public bool MoveNext() => ++index < count;

                public void Reset() => index = -1;

                public void Dispose() { }
            }
        }
    }
}
