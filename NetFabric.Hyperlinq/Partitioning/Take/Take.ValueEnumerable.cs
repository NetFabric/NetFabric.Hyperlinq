using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TakeEnumerable<TEnumerable, TEnumerator, TSource> Take<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int count)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => new TakeEnumerable<TEnumerable, TEnumerator, TSource>(in source, count);

        public readonly partial struct TakeEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueEnumerable<TSource, TakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly int count;

            internal TakeEnumerable(in TEnumerable source, int count)
            {
                this.source = source;
                this.count = count;
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() 
                => new Enumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new Enumerator(in this);

            public struct Enumerator
                : IEnumerator<TSource>
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly
                int counter;

                internal Enumerator(in TakeEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    counter = enumerable.count;
                }

                [MaybeNull]
                public readonly TSource Current
                    => enumerator.Current;
                readonly TSource IEnumerator<TSource>.Current 
                    => enumerator.Current;
                readonly object? IEnumerator.Current 
                    => enumerator.Current;

                public bool MoveNext()
                {
                    if (counter > 0)
                    {
                        if (enumerator.MoveNext())
                        {
                            counter--;
                            return true;
                        }

                        counter = 0;
                    }
                    Dispose();
                    return false; 
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => throw new NotSupportedException();

                public void Dispose() 
                    => enumerator.Dispose();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TakeEnumerable<TEnumerable, TEnumerator, TSource> Take(int count)
                => ValueEnumerable.Take<TEnumerable, TEnumerator, TSource>(source, Math.Min(this.count, count));
        }
    }
}