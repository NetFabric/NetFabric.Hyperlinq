﻿using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        public static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source.Count > int.MaxValue) 
                ThrowHelper.ThrowArgumentTooLargeException(nameof(source), source.Count);
                
            return new List<TSource>(ValueReadOnlyList.AsEnumerable<TEnumerable, TEnumerator, TSource>(source));
        }
    }
}
