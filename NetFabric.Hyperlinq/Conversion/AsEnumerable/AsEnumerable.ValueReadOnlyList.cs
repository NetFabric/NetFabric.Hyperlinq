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
            
            return new AsEnumerableIterator<TEnumerable, TEnumerator, TSource>(source);
        }

        sealed class AsEnumerableIterator<TEnumerable, TEnumerator, TSource>
            : Iterator<TSource>
            , IReadOnlyList<TSource>
            , IList<TSource>
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            readonly TEnumerable source;
            TEnumerator enumerator;
            int count;
            int index;

            internal AsEnumerableIterator(in TEnumerable source)
            {
                this.source = source;
            }

            protected override Iterator<TSource> Clone()
                => new AsEnumerableIterator<TEnumerable, TEnumerator, TSource>(source);

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
                for (var index = 0; index < count; count++)
                    array[index + arrayIndex] = source[index];
            }

            public int IndexOf(TSource item)
            {
                var count = (int)source.Count;
                for (var index = 0; index < count; count++)
                {
                    if (item.Equals(source[index]))
                        return index;
                }
                return -1;
            }

            void ICollection<TSource>.Add(TSource item) => throw new NotSupportedException();
            bool ICollection<TSource>.Remove(TSource item) => throw new NotSupportedException();
            void ICollection<TSource>.Clear() => throw new NotSupportedException();
            void IList<TSource>.Insert(int index, TSource item) => throw new NotSupportedException();
            void IList<TSource>.RemoveAt(int index) => throw new NotSupportedException();

            public override bool MoveNext()
            {
                switch (state)
                {
                    case 1:
                        enumerator = source.GetValueEnumerator();
                        count = (int)source.Count;
                        index = -1;
                        state = 2;
                        goto case 2;

                    case 2:
                        if (++index < count)
                        {
                            current = source[index];
                            return true;
                        }

                        Dispose();
                        break;
                }

                return false;
            }
        }
    }
}
