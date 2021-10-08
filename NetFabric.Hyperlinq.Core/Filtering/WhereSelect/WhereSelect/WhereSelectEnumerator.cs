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
#pragma warning disable IDE0044 // Add readonly modifier
        TPredicate predicate;
        TSelector selector;
#pragma warning restore IDE0044 // Add readonly modifier
        int index;

        internal WhereSelectEnumerator(ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector)
        {
            this.source = source;
            this.predicate = predicate;
            this.selector = selector;
            index = -1;
        }

        public readonly TResult Current 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => selector.Invoke(source[index]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
        {
            var span = source;
            while (++index < span.Length)
            {
                var item = span[index];
                if (predicate.Invoke(item))
                    return true;
            }
            return false;
        }
    }
}