using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static AsValueReadOnlyCollectionEnumerable<TEnumerable, TEnumerator, TSource> AsValueReadOnlyCollection<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            => new AsValueReadOnlyCollectionEnumerable<TEnumerable, TEnumerator, TSource>(source);

        public readonly struct AsValueReadOnlyCollectionEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueReadOnlyCollection<TSource, AsValueReadOnlyCollectionEnumerable<TEnumerable, TEnumerator, TSource>.ValueEnumerator>
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            readonly TEnumerable source;

            internal AsValueReadOnlyCollectionEnumerable(in TEnumerable source)
            {
                this.source = source;
            }

            public Enumerator GetEnumerator() => new Enumerator(in source);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in source);

            public int Count => source.Count;
            
            public struct Enumerator 
                : IDisposable
            {
                TEnumerator enumerator;

                internal Enumerator(in TEnumerable enumerable)
                {
                    enumerator = (TEnumerator)enumerable.GetEnumerator();
                }

                public TSource Current => enumerator.Current;

                public bool MoveNext() => enumerator.MoveNext();

                public void Dispose() => enumerator.Dispose();
            }

            public struct ValueEnumerator
                : IValueEnumerator<TSource>
            {
                readonly TEnumerator enumerator;

                internal ValueEnumerator(in TEnumerable enumerable)
                {
                    enumerator = (TEnumerator)enumerable.GetEnumerator();
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

                public void Dispose() { }
            }
        }
    }
}
