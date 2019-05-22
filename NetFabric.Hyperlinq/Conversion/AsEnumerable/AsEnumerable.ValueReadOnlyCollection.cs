using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IReadOnlyCollection<TSource> AsEnumerable<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source.Count > int.MaxValue) ThrowHelper.ThrowArgumentTooLargeException(nameof(source), source.Count);
            
            return new AsEnumerableIterator<TEnumerable, TEnumerator, TSource>(source);
        }

        sealed class AsEnumerableIterator<TEnumerable, TEnumerator, TSource>
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
                
                if (source.Count == 0) return;

                using (var enumerator = source.GetEnumerator())
                {
                    for (var index = arrayIndex; enumerator.MoveNext(); index++)
                        array[index] = enumerator.Current;
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
                        enumerator = source.GetEnumerator();
                        state = 2;
                        goto case 2;

                    case 2:
                        if (enumerator.MoveNext())
                        {
                            current = enumerator.Current;
                            return true;
                        }

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
