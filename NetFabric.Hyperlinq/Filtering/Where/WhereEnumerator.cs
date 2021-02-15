using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    [StructLayout(LayoutKind.Sequential)]
    public ref struct WhereEnumerator<TSource, TPredicate>
        where TPredicate : struct, IFunction<TSource, bool>
    {
        int index;
        readonly int end;
        readonly ReadOnlySpan<TSource> source;
        TPredicate predicate;

        internal WhereEnumerator(ReadOnlySpan<TSource> source, TPredicate predicate)
        {
            this.source = source;
            this.predicate = predicate;
            index = -1;
            end = index + source.Length;
        }

        public readonly TSource Current 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => source[index];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
        {
            while (++index <= end)
            {
                if (predicate.Invoke(source[index]))
                    return true;
            }
            return false;
        }
    }
}