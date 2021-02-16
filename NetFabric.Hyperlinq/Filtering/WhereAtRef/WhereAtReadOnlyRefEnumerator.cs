using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    [StructLayout(LayoutKind.Auto)]
    public ref struct WhereAtReadOnlyRefEnumerator<TSource, TPredicate>
        where TPredicate : struct, IFunctionIn<TSource, int, bool>
    {
        readonly ReadOnlySpan<TSource> source;
        TPredicate predicate;
        int index;

        internal WhereAtReadOnlyRefEnumerator(ReadOnlySpan<TSource> source, TPredicate predicate)
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
                if (predicate.Invoke(in span[index], index))
                    return true;
            }
            return false;
        }
    }
}