using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        [Pure]
        public static SkipEnumerable<TEnumerable, TEnumerator, TSource> Skip<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int count)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => new SkipEnumerable<TEnumerable, TEnumerator, TSource>(in source, count);

        [GenericsTypeMapping("TEnumerable", typeof(SkipEnumerable<,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(SkipEnumerable<,,>.Enumerator))]
        public readonly struct SkipEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueEnumerable<TSource, SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly int count;

            internal SkipEnumerable(in TEnumerable source, int count)
            {
                this.source = source;
                this.count = count;
            }

            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new DisposableEnumerator<TSource, Enumerator>(new Enumerator(in this));
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator<TSource, Enumerator>(new Enumerator(in this));

            public struct Enumerator
                : IValueEnumerator<TSource>
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly
                int counter;

                internal Enumerator(in SkipEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    counter = enumerable.count;
                }

                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => enumerator.Current;
                }

                public bool MoveNext()
                {
                    while (counter > 0)
                    {
                        if(!enumerator.MoveNext())
                            return false;

                        counter--;
                    }

                    return enumerator.MoveNext();                    
                }
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