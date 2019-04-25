using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        public static IReadOnlyCollection<TSource> AsEnumerable<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source.Count > int.MaxValue) ThrowHelper.ThrowArgumentTooLargeException(nameof(source), source.Count);
            
            return new AsEnumerableEnumerable<TEnumerable, TEnumerator, TSource>(source);
        }

        class AsEnumerableEnumerable<TEnumerable, TEnumerator, TSource>
            : IReadOnlyCollection<TSource>
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
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

            class Enumerator
                : IEnumerator<TSource>
            {
                readonly TEnumerator enumerator;
                TSource current;

                internal Enumerator(AsEnumerableEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = enumerable.source.GetValueEnumerator();
                }

                public TSource Current => current;
                object IEnumerator.Current => current;

                public bool MoveNext() => enumerator.TryMoveNext(out current);

                public void Reset() => throw new NotSupportedException();

                public void Dispose() => enumerator.Dispose();
            }
        }
    }
}
