using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    [StructLayout(LayoutKind.Auto)]
    public readonly struct ValueEnumerator<TSource>
        : IEnumerator<TSource>
    {
        readonly IEnumerator<TSource> enumerator;
        
        public ValueEnumerator(IEnumerator<TSource> enumerator) 
            => this.enumerator = enumerator;

        public TSource Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => enumerator.Current;
        }
        object? IEnumerator.Current
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            => enumerator.Current;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext() 
            => enumerator.MoveNext();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ExcludeFromCodeCoverage]
        public void Reset() 
            => enumerator.Reset();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose() 
            => enumerator.Dispose();        
    }
}