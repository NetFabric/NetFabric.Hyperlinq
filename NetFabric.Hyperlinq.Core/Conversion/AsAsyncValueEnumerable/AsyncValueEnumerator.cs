using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    [StructLayout(LayoutKind.Auto)]
    public readonly struct AsyncValueEnumerator<TSource>
        : IAsyncEnumerator<TSource>
    {
        readonly IAsyncEnumerator<TSource> enumerator;
        
        public AsyncValueEnumerator(IAsyncEnumerator<TSource> enumerator) 
            => this.enumerator = enumerator;

        public TSource Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => enumerator.Current;
        }
        TSource IAsyncEnumerator<TSource>.Current
            => enumerator.Current;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ValueTask<bool> MoveNextAsync() 
            => enumerator.MoveNextAsync();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ValueTask DisposeAsync() 
            => enumerator.DisposeAsync();        
    }
}