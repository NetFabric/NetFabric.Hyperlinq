using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public struct Enumerator<T>
            : IEnumerator<T>
        {
            readonly T[] source;
            int index;

            internal Enumerator(T[] source)
            {
                this.source = source;
                index = -1;
            }

            public readonly T Current
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source[index];
            }
            readonly object? IEnumerator.Current 
                // ReSharper disable once HeapView.PossibleBoxingAllocation
                => source[index];

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext() 
                => ++index < source.Length;
            public void Reset() 
                => index = -1;
            public readonly void Dispose() 
            { }
        }
    }
}