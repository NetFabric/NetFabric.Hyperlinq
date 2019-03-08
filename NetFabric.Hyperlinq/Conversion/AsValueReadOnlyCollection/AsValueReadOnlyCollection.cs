using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static AsValueReadOnlyCollectionEnumerable<TEnumerable, TEnumerator, TSource> AsValueReadOnlyCollection<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            return new AsValueReadOnlyCollectionEnumerable<TEnumerable, TEnumerator, TSource>(source);
        }

        public readonly struct AsValueReadOnlyCollectionEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueReadOnlyCollection<TSource, AsValueReadOnlyCollectionEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            readonly TEnumerable source;

            internal AsValueReadOnlyCollectionEnumerable(in TEnumerable source)
            {
                this.source = source;
            }

            public Enumerator GetValueEnumerator() => new Enumerator(this);

            public int Count() => source.Count;

            public struct Enumerator
                : IValueEnumerator<TSource>
            {
                TEnumerator enumerator;

                internal Enumerator(AsValueReadOnlyCollectionEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
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
