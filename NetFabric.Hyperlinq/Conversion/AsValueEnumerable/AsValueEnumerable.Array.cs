using System;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static AsValueEnumerableEnumerable<TSource> AsValueEnumerable<TSource>(this TSource[] source)
            => new AsValueEnumerableEnumerable<TSource>(source);

        public readonly struct AsValueEnumerableEnumerable<TSource>
            : IValueReadOnlyList<TSource, AsValueEnumerableEnumerable<TSource>.ValueEnumerator>
        {
            readonly TSource[] source;

            internal AsValueEnumerableEnumerable(TSource[] source)
            {
                this.source = source;
            }

            public Enumerator GetEnumerator() => new Enumerator(source);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(source);

            public int Count => source.Length;

            public ref TSource this[int index] => ref source[index];
            TSource IValueReadOnlyList<TSource, AsValueEnumerableEnumerable<TSource>.ValueEnumerator>.this[int index] => source[index];
            
            public struct Enumerator 
            {
                readonly TSource[] source;
                readonly int count;
                int index;

                internal Enumerator(TSource[] source)
                {
                    this.source = source;
                    count = source.Length;
                    index = -1;
                }

                public ref TSource Current => ref source[index];

                public bool MoveNext() => ++index < count;
            }

            public struct ValueEnumerator
                : IValueEnumerator<TSource>
            {
                readonly TSource[] source;
                readonly int count;
                int index;

                internal ValueEnumerator(TSource[] source)
                {
                    this.source = source;
                    count = source.Length;
                    index = -1;
                }

                public bool TryMoveNext(out TSource current)
                {
                    if (++index < count)
                    {
                        current = source[index];
                        return true;
                    }
                    
                    current = default;
                    return false;
                }

                public bool TryMoveNext() => ++index < count;

                public void Dispose() { }
            }
        }
    }
}
