﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    [StructLayout(LayoutKind.Auto)]
    public ref struct WhereAtEnumerator<TSource, TPredicate>
        where TPredicate : struct, IFunction<TSource, int, bool>
    {
        readonly ReadOnlySpan<TSource> source;
        TPredicate predicate;
        int index;

        internal WhereAtEnumerator(ReadOnlySpan<TSource> source, TPredicate predicate)
        {
            this.source = source;
            this.predicate = predicate;
            index = -1;
        }

        public readonly TSource Current 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => source[index];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
        {
            var span = source;
            while (++index < span.Length)
            {
                var item = span[index];
                if (predicate.Invoke(item, index))
                    return true;
            }
            return false;
        }
    }
}