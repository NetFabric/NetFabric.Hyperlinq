using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static AsValueReadOnlyListEnumerable<TEnumerable, TSource> AsValueReadOnlyList<TEnumerable, TSource>(this TEnumerable source)
            where TEnumerable : IReadOnlyList<TSource>
            => new AsValueReadOnlyListEnumerable<TEnumerable, TSource>(source);

        public readonly struct AsValueReadOnlyListEnumerable<TEnumerable, TSource>
            : IValueReadOnlyList<TSource, AsValueReadOnlyListEnumerable<TEnumerable, TSource>.Enumerator>
            where TEnumerable : IReadOnlyList<TSource>
        {
            readonly TEnumerable source;

            internal AsValueReadOnlyListEnumerable(in TEnumerable source)
            {
                this.source = source;
            }

            public Enumerator GetValueEnumerator() => new Enumerator(this);

            public int Count() => source.Count;

            public TSource this[int index] => source[index];

            public struct Enumerator
                : IValueEnumerator<TSource>
            {
                readonly TEnumerable source;
                readonly int count;
                int current;

                internal Enumerator(in AsValueReadOnlyListEnumerable<TEnumerable, TSource> enumerable)
                {
                    source = enumerable.source;
                    count = source.Count;
                    current = -1;
                }

                public bool TryMoveNext(out TSource current)
                {
                    if (++this.current < count)
                    {
                        current = source[this.current];
                        return true;
                    }
                    current = default;
                    return false;
                }

                public bool TryMoveNext() => ++current < count;

                public void Dispose() { }
            }
        }
    }
}
