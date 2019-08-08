using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public static SkipEnumerable<TEnumerable, TEnumerator, TSource> Skip<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int count)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => new SkipEnumerable<TEnumerable, TEnumerator, TSource>(in source, count);

        [GenericsTypeMapping("TEnumerable", typeof(SkipEnumerable<,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(SkipEnumerable<,,>.Enumerator))]
        public readonly struct SkipEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueEnumerable<TSource, SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly int count;

            internal SkipEnumerable(in TEnumerable source, int count)
            {
                this.source = source;
                this.count = count;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IEnumerator<TSource>
            {
                TEnumerator enumerator;
                int counter;

                internal Enumerator(in SkipEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    counter = enumerable.count;
                }

                public TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => enumerator.Current;
                }
                object IEnumerator.Current
                    => enumerator.Current;

                public bool MoveNext()
                {
                    while (counter > 0)
                    {
                        if(!enumerator.MoveNext())
                        {
                            Dispose();
                            return false;
                        }

                        counter--;
                    }

                    return enumerator.MoveNext();                    
                }

                void IEnumerator.Reset()
                    => throw new NotSupportedException();

                public void Dispose() => enumerator.Dispose();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipEnumerable<TEnumerable, TEnumerator, TSource> Skip(int count)
                => ValueEnumerable.Skip<TEnumerable, TEnumerator, TSource>(source, this.count + count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> Take(int count)
                => ValueEnumerable.SkipTake<TEnumerable, TEnumerator, TSource>(source, this.count, count);
        }
    }
}