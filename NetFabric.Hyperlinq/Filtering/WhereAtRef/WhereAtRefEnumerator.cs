using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    [StructLayout(LayoutKind.Auto)]
    public ref struct WhereAtRefEnumerator<TSource, TPredicate>
        where TPredicate : struct, IFunctionIn<TSource, int, bool>
    {
        readonly Span<TSource> source;
        TPredicate predicate;
        int index;

        internal WhereAtRefEnumerator(Span<TSource> source, TPredicate predicate)
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
            var span = source;
            while (++index < span.Length)
            {
                ref readonly var item = ref span[index];
                if (predicate.Invoke(in item, index))
                    return true;
            }
            return false;
        }
    }
}