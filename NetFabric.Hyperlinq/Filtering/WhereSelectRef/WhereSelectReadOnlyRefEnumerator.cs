using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    [StructLayout(LayoutKind.Sequential)]
    public ref struct WhereSelectReadOnlyRefEnumerator<TSource, TResult, TPredicate, TSelector>
        where TPredicate : struct, IFunctionIn<TSource, bool>
        where TSelector : struct, IFunction<TSource, TResult>
    {
        int index;
        readonly int end;
        readonly ReadOnlySpan<TSource> source;
        TPredicate predicate;
        TSelector selector;

        internal WhereSelectReadOnlyRefEnumerator(ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector)
        {
            this.source = source;
            this.predicate = predicate;
            this.selector = selector;
            index = -1;
            end = index + source.Length;
        }

        public TResult Current 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => selector.Invoke(source[index]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
        {
            while (++index <= end)
            {
                if (predicate.Invoke(in source[index]))
                    return true;
            }
            return false;
        }
    }
}