using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static IReadOnlyList<TSource> AsReadOnlyList<TSource>(this TSource[] source)
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            return new AsReadOnlyListEnumerable<TSource>(source);
        }

        class AsReadOnlyListEnumerable<TSource>
            : IReadOnlyList<TSource>
        {
            readonly TSource[] source;

            internal AsReadOnlyListEnumerable(TSource[] source)
            {
                this.source = source;
            }

            public IEnumerator<TSource> GetEnumerator() => new Enumerator(this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(this);

            public int Count => source.Count();

            public ref readonly TSource this[int index] => ref source[index];
            TSource IReadOnlyList<TSource>.this[int index] => source[index];

            class Enumerator
                : IEnumerator<TSource>
            {
                TSource[] source;
                readonly int count;
                int index;

                internal Enumerator(AsReadOnlyListEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    count = source.Count();
                    index = -1;
                }

                public TSource Current => source[index];
                object IEnumerator.Current => source[index];

                public bool MoveNext()
                {
                    index++;
                    return index < count;
                }

                public void Reset() => index = -1;

                public void Dispose() { }
            }
        }
    }
}
