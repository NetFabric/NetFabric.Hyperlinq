using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static AsValueEnumerableEnumerable<TEnumerable, TEnumerator, TSource> AsValueEnumerable<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            => new AsValueEnumerableEnumerable<TEnumerable, TEnumerator, TSource>(source);

        public readonly struct AsValueEnumerableEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueReadOnlyCollection<TSource, AsValueEnumerableEnumerable<TEnumerable, TEnumerator, TSource>.ValueEnumerator>
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            readonly TEnumerable source;

            internal AsValueEnumerableEnumerable(in TEnumerable source)
            {
                this.source = source;
            }

            public Enumerator GetEnumerator() => new Enumerator(in source);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in source);

            public long Count => source.Count;
            
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
                TEnumerator enumerator;

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
