using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> SkipTake<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int skipCount, int takeCount)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => new(in source, skipCount, takeCount);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueEnumerable<TSource, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly int skipCount;
            readonly int takeCount;

            internal SkipTakeEnumerable(in TEnumerable source, int skipCount, int takeCount)
            {
                this.source = source;
                this.skipCount = skipCount;
                this.takeCount = takeCount;
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() 
                => new(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new Enumerator(in this);

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
                : IEnumerator<TSource>
            {
                int skipCounter;
                int takeCounter;
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly

                internal Enumerator(in SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    skipCounter = enumerable.skipCount;
                    takeCounter = enumerable.takeCount;
                }

                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => enumerator.Current;
                }
                readonly TSource IEnumerator<TSource>.Current 
                    => enumerator.Current;
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => enumerator.Current;

                public bool MoveNext()
                {
                    while (skipCounter > 0)
                    {
                        if (!enumerator.MoveNext())
                            return false;

                        skipCounter--;
                    }

                    if (takeCounter > 0)
                    {
                        if (enumerator.MoveNext())
                        {
                            takeCounter--;
                            return true;
                        }

                        takeCounter = 0;
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public void Dispose() 
                    => enumerator.Dispose();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> Take(int count)
                => source.SkipTake<TEnumerable, TEnumerator, TSource>(skipCount, Math.Min(takeCount, count));
        }
    }
}
