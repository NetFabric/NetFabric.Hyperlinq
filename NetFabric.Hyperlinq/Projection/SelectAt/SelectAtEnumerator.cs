using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    [StructLayout(LayoutKind.Sequential)]
    public ref struct SelectAtEnumerator<TSource, TResult, TSelector>
        where TSelector : struct, IFunction<TSource, int, TResult>
    {
        int index;
        readonly int end;
        readonly ReadOnlySpan<TSource> source;
        TSelector selector;

        internal SelectAtEnumerator(ReadOnlySpan<TSource> source, TSelector selector)
        {
            this.source = source;
            this.selector = selector;
            index = -1;
            end = index + source.Length;
        }

        public TResult Current 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => selector.Invoke(source[index], index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
            => ++index <= end;
    }
}