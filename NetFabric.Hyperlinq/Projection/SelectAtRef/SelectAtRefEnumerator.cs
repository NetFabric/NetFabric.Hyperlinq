using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    [StructLayout(LayoutKind.Auto)]
    public ref struct SelectAtRefEnumerator<TSource, TResult, TSelector>
        where TSelector : struct, IFunctionIn<TSource, int, TResult>
    {
        readonly ReadOnlySpan<TSource> source;
        TSelector selector;
        int index;

        internal SelectAtRefEnumerator(ReadOnlySpan<TSource> source, TSelector selector)
        {
            this.source = source;
            this.selector = selector;
            index = -1;
        }

        public readonly TResult Current 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => selector.Invoke(in source[index], index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
            => ++index < source.Length;
    }
}