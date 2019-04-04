using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        public static IReadOnlyList<TSource> AsReadOnlyList<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => new AsReadOnlyListEnumerable<TEnumerable, TEnumerator, TSource>(source);

        class AsReadOnlyListEnumerable<TEnumerable, TEnumerator, TSource>
            : IReadOnlyList<TSource>
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            readonly TEnumerable source;

            internal AsReadOnlyListEnumerable(in TEnumerable source)
            {
                this.source = source;
            }

            public IEnumerator<TSource> GetEnumerator() => new Enumerator(this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(this);

            public int Count => source.Count;

            public TSource this[int index] => source[index];

            class Enumerator
                : IEnumerator<TSource>
            {
                TEnumerable source;
                readonly int count;
                int index;

                internal Enumerator(AsReadOnlyListEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
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
