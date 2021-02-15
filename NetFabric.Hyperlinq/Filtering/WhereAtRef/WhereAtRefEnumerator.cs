using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    [StructLayout(LayoutKind.Sequential)]
    public ref struct WhereAtRefEnumerator<TSource, TPredicate>
        where TPredicate : struct, IFunctionIn<TSource, int, bool>
    {
        int index;
        readonly int end;
        readonly Span<TSource> source;
        TPredicate predicate;

        internal WhereAtRefEnumerator(Span<TSource> source, TPredicate predicate)
        {
            this.source = source;
            this.predicate = predicate;
            index = -1;
            end = index + source.Length;
        }

        public readonly ref TSource Current 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref source[index];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
        {
            while (++index <= end)
            {
                if (predicate.Invoke(in source[index], index))
                    return true;
            }
            return false;
        }
    }
}