using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    [StructLayout(LayoutKind.Auto)]
    public ref struct WhereRefEnumerator<TSource, TPredicate>
        where TPredicate : struct, IFunctionIn<TSource, bool>
    {
        readonly Span<TSource> source;
        TPredicate predicate;
        int index;

        internal WhereRefEnumerator(Span<TSource> source, TPredicate predicate)
        {
            this.source = source;
            this.predicate = predicate;
            index = -1;
        }

        public readonly ref TSource Current 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref source[index];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
        {
            while (++index < source.Length)
            {
                ref readonly var item = ref source[index];
                if (predicate.Invoke(in item))
                    return true;
            }
            return false;
        }
    }
}