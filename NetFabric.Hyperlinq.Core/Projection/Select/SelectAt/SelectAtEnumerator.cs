using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    [StructLayout(LayoutKind.Auto)]
    public ref struct SelectAtEnumerator<TSource, TResult, TSelector>
        where TSelector : struct, IFunction<TSource, int, TResult>
    {
        readonly ReadOnlySpan<TSource> source;
        TSelector selector;
        readonly int end;
        int index;

        internal SelectAtEnumerator(ReadOnlySpan<TSource> source, TSelector selector)
        {
            this.source = source;
            this.selector = selector;
            index = -1;
            end = index + source.Length;
        }

        public readonly TResult Current 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => selector.Invoke(source[index], index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
            => ++index <= end;
    }
}