using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    [StructLayout(LayoutKind.Auto)]
    public ref struct WhereSelectRefEnumerator<TSource, TResult, TPredicate, TSelector>
        where TPredicate : struct, IFunctionIn<TSource, bool>
        where TSelector : struct, IFunctionIn<TSource, TResult>
    {
        readonly Span<TSource> source;
        TPredicate predicate;
        TSelector selector;
        int index;

        internal WhereSelectRefEnumerator(Span<TSource> source, TPredicate predicate, TSelector selector)
        {
            this.source = source;
            this.predicate = predicate;
            this.selector = selector;
            index = -1;
        }

        public TResult Current 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => selector.Invoke(in source[index]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
        {
            var span = source;
            while (++index < span.Length)
            {
                if (predicate.Invoke(in span[index]))
                    return true;
            }
            return false;
        }
    }
}