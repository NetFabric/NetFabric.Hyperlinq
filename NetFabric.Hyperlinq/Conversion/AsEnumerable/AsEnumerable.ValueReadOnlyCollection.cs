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
            
            return new AsEnumerableIterator<TEnumerable, TEnumerator, TSource>(source);
        }

        class AsEnumerableIterator<TEnumerable, TEnumerator, TSource>
            : Iterator<TSource>
            , IReadOnlyCollection<TSource>
            , ICollection<TSource>
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            readonly TEnumerable source;
            TEnumerator enumerator;

            internal AsEnumerableIterator(in TEnumerable source)
            {
                this.source = source;
            }

            protected override Iterator<TSource> Clone()
                => new AsEnumerableIterator<TEnumerable, TEnumerator, TSource>(source);

            public int Count => (int)source.Count;

            public bool IsReadOnly => true;

            public bool Contains(TSource item) 
                => ValueReadOnlyCollection.Contains<TEnumerable, TEnumerator, TSource>(source, item);

            public void CopyTo(TSource[] array, int arrayIndex)
            {
                if (arrayIndex < 0) ThrowHelper.ThrowArgumentOutOfRangeException(nameof(arrayIndex));
                
                var index = arrayIndex;
                using (var enumerator = source.GetValueEnumerator())
                {
                    while (enumerator.TryMoveNext(out var current))
                    {
                        array[index] = current;
                        unchecked { index++; }
                    }                   
                }
            }

            void ICollection<TSource>.Add(TSource item) => throw new NotSupportedException();
            bool ICollection<TSource>.Remove(TSource item) => throw new NotSupportedException();
            void ICollection<TSource>.Clear() => throw new NotSupportedException();

            public override bool MoveNext()
            {
                switch (state)
                {
                    case 1:
                        enumerator = source.GetValueEnumerator();
                        state = 2;
                        goto case 2;

                    case 2:
                        if (enumerator.TryMoveNext(out current))
                            return true;

                        Dispose();
                        break;
                }

                return false;
            }

            public override void Dispose()
            {
                if (state > 0)
                {
                    enumerator.Dispose();
                }

                base.Dispose();
            }
        }
    }
}
