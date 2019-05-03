using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public static IEnumerable<TSource> AsEnumerable<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => new AsEnumerableIterator<TEnumerable, TEnumerator, TSource>(source);

        sealed class AsEnumerableIterator<TEnumerable, TEnumerator, TSource>
            : Iterator<TSource>
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            readonly TEnumerable source;
            TEnumerator enumerator;

            public AsEnumerableIterator(in TEnumerable source)
            {
                this.source = source;
            }

            protected override Iterator<TSource> Clone()
                => new AsEnumerableIterator<TEnumerable, TEnumerator, TSource>(source);

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
