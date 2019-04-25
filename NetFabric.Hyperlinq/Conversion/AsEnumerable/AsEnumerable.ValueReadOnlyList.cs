using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        public static IReadOnlyList<TSource> AsEnumerable<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source.Count > int.MaxValue) ThrowHelper.ThrowArgumentTooLargeException(nameof(source), source.Count);
            
            return new AsEnumerableEnumerable<TEnumerable, TEnumerator, TSource>(source);
        }

        class AsEnumerableEnumerable<TEnumerable, TEnumerator, TSource>
            : IReadOnlyList<TSource>
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            readonly TEnumerable source;

            internal AsEnumerableEnumerable(in TEnumerable source)
            {
                this.source = source;
            }

            public IEnumerator<TSource> GetEnumerator() => new Enumerator(this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(this);

            public int Count => (int)source.Count;

            public TSource this[int index] => source[index];

            class Enumerator
                : IEnumerator<TSource>
            {
                TEnumerable source;
                readonly long count;
                long index;

                internal Enumerator(AsEnumerableEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
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
