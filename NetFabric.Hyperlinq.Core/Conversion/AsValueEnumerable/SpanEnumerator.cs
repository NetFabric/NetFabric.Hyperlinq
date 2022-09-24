using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    [StructLayout(LayoutKind.Auto)]
    public ref struct SpanEnumerator<TSource>
    {
        readonly ReadOnlySpan<TSource> source;
        int index;

        internal SpanEnumerator(ReadOnlySpan<TSource> source) 
        {
            this.source = source;
            index = -1;
        }

        public readonly TSource Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => source[index];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
            => ++index < source.Length;
    }   
}