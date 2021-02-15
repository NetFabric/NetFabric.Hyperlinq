using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    [StructLayout(LayoutKind.Auto)]
    public ref struct WhereSelectEnumerator<TSource, TResult, TPredicate, TSelector>
        where TPredicate : struct, IFunction<TSource, bool>
        where TSelector : struct, IFunction<TSource, TResult>
    {
        readonly ReadOnlySpan<TSource> source;
        TPredicate predicate;
        TSelector selector;
        int index;

        internal WhereSelectEnumerator(ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector)
        {
            this.source = source;
            this.predicate = predicate;
            this.selector = selector;
            index = -1;
        }

        public TResult Current 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => selector.Invoke(source[index]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
        {
            while (++index < source.Length)
            {
                var item = source[index];
                if (predicate.Invoke(item))
                    return true;
            }
            return false;
        }
    }
}