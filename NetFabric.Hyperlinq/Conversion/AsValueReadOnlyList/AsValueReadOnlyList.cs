using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static AsValueReadOnlyListEnumerable<TEnumerable, TEnumerator, TSource> AsValueReadOnlyList<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IReadOnlyList<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            return new AsValueReadOnlyListEnumerable<TEnumerable, TEnumerator, TSource>(source);
        }

        public readonly struct AsValueReadOnlyListEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueReadOnlyList<TSource, AsValueReadOnlyListEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IReadOnlyList<TSource>
            where TEnumerator : IEnumerator<TSource>
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
                TEnumerator enumerator;

                internal Enumerator(AsValueReadOnlyListEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = Dynamic.GetEnumerator<TEnumerable, TEnumerator, TSource>.Invoke(enumerable.source);
                }

                public bool TryMoveNext(out TSource current)
                {
                    if (enumerator.MoveNext())
                    {
                        current = enumerator.Current;
                        return true;
                    }
                    current = default;
                    return false;
                }

                public bool TryMoveNext() => enumerator.MoveNext();

                public void Dispose() => enumerator.Dispose();
            }
        }
    }
}
