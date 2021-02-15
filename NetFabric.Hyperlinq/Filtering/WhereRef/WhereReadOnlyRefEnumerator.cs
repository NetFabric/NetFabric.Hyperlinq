﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    [StructLayout(LayoutKind.Sequential)]
    public ref struct WhereReadOnlyRefEnumerator<TSource, TPredicate>
        where TPredicate : struct, IFunctionIn<TSource, bool>
    {
        int index;
        readonly int end;
        readonly ReadOnlySpan<TSource> source;
        TPredicate predicate;

        internal WhereReadOnlyRefEnumerator(ReadOnlySpan<TSource> source, TPredicate predicate)
        {
            this.source = source;
            this.predicate = predicate;
            index = -1;
            end = index + source.Length;
        }

        public readonly ref readonly TSource Current 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref source[index];
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