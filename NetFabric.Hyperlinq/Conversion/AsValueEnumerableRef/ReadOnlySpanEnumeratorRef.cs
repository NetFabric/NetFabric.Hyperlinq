using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    [StructLayout(LayoutKind.Auto)]
    public ref struct ReadOnlySpanEnumeratorRef<TSource>
    {
        readonly ReadOnlySpan<TSource> source;
        int index;

        internal ReadOnlySpanEnumeratorRef(ReadOnlySpan<TSource> source) 
        {
            this.source = source;
            index = -1;
        }

        public readonly ref readonly TSource Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref source[index];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
            => ++index < source.Length;
    }   
}