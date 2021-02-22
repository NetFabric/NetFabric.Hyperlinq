using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    [StructLayout(LayoutKind.Auto)]
    public ref struct SpanEnumeratorRef<TSource>
    {
        readonly Span<TSource> source;
        int index;

        internal SpanEnumeratorRef(Span<TSource> source) 
        {
            this.source = source;
            index = -1;
        }

        public readonly ref TSource Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref source[index];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
            => ++index < source.Length;
    }   
}