using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    [StructLayout(LayoutKind.Auto)]
    public ref struct WhereReadOnlyRefEnumerator<TSource, TPredicate>
        where TPredicate : struct, IFunctionIn<TSource, bool>
    {
        readonly ReadOnlySpan<TSource> source;
        TPredicate predicate;
        int index;

        internal WhereReadOnlyRefEnumerator(ReadOnlySpan<TSource> source, TPredicate predicate)
        {
            this.source = source;
            this.predicate = predicate;
            index = -1;
        }

        public readonly ref readonly TSource Current 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref source[index];
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