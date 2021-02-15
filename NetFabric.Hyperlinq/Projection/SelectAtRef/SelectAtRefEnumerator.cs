using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    [StructLayout(LayoutKind.Sequential)]
    public ref struct SelectAtRefEnumerator<TSource, TResult, TSelector>
        where TSelector : struct, IFunctionIn<TSource, int, TResult>
    {
        int index;
        readonly int end;
        readonly ReadOnlySpan<TSource> source;
        TSelector selector;

        internal SelectAtRefEnumerator(ReadOnlySpan<TSource> source, TSelector selector)
        {
            this.source = source;
            this.selector = selector;
            index = -1;
            end = index + source.Length;
        }

        public TResult Current 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => selector.Invoke(in source[index], index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
            => ++index <= end;
    }
}