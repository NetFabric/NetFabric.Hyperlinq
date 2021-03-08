using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public struct AsyncEnumerator<T>
            : IAsyncEnumerator<T>
        {
            readonly T[] source;
            int index;

            internal AsyncEnumerator(T[] source)
            {
                this.source = source;
                index = -1;
            }

            public readonly T Current
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> MoveNextAsync() 
                => new(++index < source.Length);
            
            public readonly ValueTask DisposeAsync() 
                => default;
        }
    }
}