using System;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static AsValueEnumerableEnumerable<TSource> AsValueEnumerable<TSource>(this TSource[] source)
            => new AsValueEnumerableEnumerable<TSource>(source);

        [GenericsTypeMapping("TEnumerable", typeof(AsValueEnumerableEnumerable<>))]
        [GenericsTypeMapping("TEnumerator", typeof(AsValueEnumerableEnumerable<>.Enumerator))]
        public readonly struct AsValueEnumerableEnumerable<TSource>
            : IValueReadOnlyList<TSource, AsValueEnumerableEnumerable<TSource>.Enumerator>
        {
            readonly TSource[] source;

            internal AsValueEnumerableEnumerable(TSource[] source)
            {
                this.source = source;
            }

            public Enumerator GetEnumerator() => new Enumerator(source);

            public long Count => source.Length;

            public ref TSource this[long index] => ref source[index];
            TSource IValueReadOnlyList<TSource, AsValueEnumerableEnumerable<TSource>.Enumerator>.this[long index] => source[index];
            
            public struct Enumerator 
                : IValueEnumerator<TSource>
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
                TSource IValueEnumerator<TSource>.Current => source[index];

                public bool MoveNext() => ++index < count;

                public void Dispose() { }
            }
        }
    }
}
