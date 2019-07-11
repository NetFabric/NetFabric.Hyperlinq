using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static AsValueEnumerableEnumerable<TEnumerable, TEnumerator, TSource> AsValueEnumerable<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IReadOnlyList<TSource>
            where TEnumerator : IEnumerator<TSource>
            => new AsValueEnumerableEnumerable<TEnumerable, TEnumerator, TSource>(source);

        [GenericsTypeMapping("TEnumerable", typeof(AsValueEnumerableEnumerable<,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(AsValueEnumerableEnumerable<,,>.Enumerator))]
        public readonly struct AsValueEnumerableEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueReadOnlyList<TSource, AsValueEnumerableEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IReadOnlyList<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            readonly TEnumerable source;

            internal AsValueEnumerableEnumerable(in TEnumerable source)
            {
                this.source = source;
            }

            public Enumerator GetEnumerator() => new Enumerator(source);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(source);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(source);

            public int Count => source.Count;

            public TSource this[int index]
            {
                get
                {
                    if (index < 0 || index > source.Count) ThrowHelper.ThrowIndexOutOfRangeException();                    
                    
                    return source[index];
                }
            }
            
            public struct Enumerator 
                : IEnumerator<TSource>
            {
                TEnumerator enumerator;

                internal Enumerator(in TEnumerable enumerable)
                {
                    enumerator = (TEnumerator)enumerable.GetEnumerator();
                }

                public TSource Current => enumerator.Current;
                object IEnumerator.Current => enumerator.Current;

                public bool MoveNext() => enumerator.MoveNext();

                void IEnumerator.Reset() => throw new NotSupportedException();

                public void Dispose() => enumerator.Dispose();
            }
        }
    }
}
