using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    static partial class ValueReadOnlyList
    {
        static IList<TSource> AsList<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source.Count > int.MaxValue) ThrowHelper.ThrowArgumentTooLargeException(nameof(source), source.Count);
            
            return new AsListEnumerable<TEnumerable, TEnumerator, TSource>(source);
        }

        class AsListEnumerable<TEnumerable, TEnumerator, TSource>
            : IList<TSource>
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            readonly TEnumerable source;

            internal AsListEnumerable(in TEnumerable source)
            {
                this.source = source;
            }

            public IEnumerator<TSource> GetEnumerator() => new Enumerator(this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(this);

            public void Add(TSource item) => throw new NotImplementedException();

            public void Clear() => throw new NotImplementedException();

            public bool Contains(TSource item) => throw new NotImplementedException();

            public void CopyTo(TSource[] array, int arrayIndex)
            {
                for (var index = arrayIndex; index < arrayIndex + Count; index++)
                {
                    array[index] = source[index];
                }
            }

            public bool Remove(TSource item) => throw new NotImplementedException();

            public int IndexOf(TSource item) => throw new NotImplementedException();

            public void Insert(int index, TSource item) => throw new NotImplementedException();

            public void RemoveAt(int index) => throw new NotImplementedException();

            public int Count => (int)source.Count;

            public bool IsReadOnly => true;

            public TSource this[int index]
            {
                get => source[index];
                set => throw new NotImplementedException();
            }

            class Enumerator
                : IEnumerator<TSource>
            {
                readonly TEnumerable source;
                readonly long count;
                long index;

                internal Enumerator(AsListEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    source = enumerable.source;
                    count = enumerable.Count;
                    index = -1;
                }

                public TSource Current => source[index];
                object IEnumerator.Current => source[index];

                public bool MoveNext() => ++index < count;

                public void Reset() => throw new NotSupportedException();

                public void Dispose() { }
            }
        }
    }
}
