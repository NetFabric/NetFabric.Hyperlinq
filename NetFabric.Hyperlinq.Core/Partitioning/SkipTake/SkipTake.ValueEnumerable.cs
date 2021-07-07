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

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueEnumerable<TSource, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly int offset;
            readonly int count;

            internal SkipTakeEnumerable(in TEnumerable source, int offset, int count)
                => (this.source, this.offset, this.count) = (source, offset, count);

            internal SkipTakeEnumerable(in TEnumerable source, (int Offset, int Count) slice)
                => (this.source, offset, count) = (source, slice.Offset, slice.Count);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator GetEnumerator() 
                => new(in this);

            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => new Enumerator(in this);

            IEnumerator IEnumerable.GetEnumerator() 
                => new Enumerator(in this);

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
                : IEnumerator<TSource>
            {
#pragma warning disable IDE0044 // Add readonly modifier
                TEnumerator enumerator;
#pragma warning restore IDE0044 // Add readonly modifier
                int skipCounter;
                int takeCounter;

                internal Enumerator(in SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    skipCounter = enumerable.offset;
                    takeCounter = enumerable.count;
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
                [DoesNotReturn]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public void Dispose() 
                    => enumerator.Dispose();
            }

            #region Partitioning

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> Skip(int count)
                => new(source, Utils.Skip(this.count, offset + count));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> Take(int count)
                => new(source, offset, Utils.Take(this.count, count));

            #endregion
        }
    }
}
