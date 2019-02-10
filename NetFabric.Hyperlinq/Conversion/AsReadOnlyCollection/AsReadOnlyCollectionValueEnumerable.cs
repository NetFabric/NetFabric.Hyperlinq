using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        public static IReadOnlyCollection<TSource> AsReadOnlyCollection<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();

            return new AsReadOnlyCollectionEnumerable<TEnumerable, TEnumerator, TSource>(source);

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
        }

        class AsReadOnlyCollectionEnumerable<TEnumerable, TEnumerator, TSource>
            : IReadOnlyCollection<TSource>
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            readonly TEnumerable source;

            internal AsReadOnlyCollectionEnumerable(in TEnumerable source)
            {
                this.source = source;
            }

            public IEnumerator<TSource> GetEnumerator() => new Enumerator(this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(this);

            public int Count => source.Count();

            class Enumerator
                : IEnumerator<TSource>
            {
                TEnumerator enumerator;
                TSource current;

                internal Enumerator(AsReadOnlyCollectionEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
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
