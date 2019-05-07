using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static AsValueEnumerableEnumerable<TEnumerable, TEnumerator, TSource> AsValueEnumerable<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IReadOnlyList<TSource>
            where TEnumerator : IEnumerator<TSource>
            => new AsValueEnumerableEnumerable<TEnumerable, TEnumerator, TSource>(source);

        public struct AsValueEnumerableEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueReadOnlyList<TSource, AsValueEnumerableEnumerable<TEnumerable, TEnumerator, TSource>.ValueEnumerator>
            where TEnumerable : IReadOnlyList<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            TEnumerable source;

            internal AsValueEnumerableEnumerable(in TEnumerable source)
            {
                this.source = source;
            }

            public Enumerator GetEnumerator() => new Enumerator(source);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(source);

            public long Count => source.Count;

            public TSource this[long index]
            {
                get
                {
                    if (index < 0 || index > source.Count) ThrowHelper.ThrowIndexOutOfRangeException();                    
                    
                    return source[(int)index];
                }
            }
            
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
                readonly IEnumerator<TSource> enumerator;

                internal ValueEnumerator(IReadOnlyList<TSource> enumerable)
                {
                    enumerator = enumerable.GetEnumerator();
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
