#nullable enable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static partial class GeneratedExtensionMethods
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count(this NetFabric.Hyperlinq.ArrayExtensions.SpanValueEnumerable<int> source, Func<int, bool> predicate) => ArrayExtensions.Count(source.Span, predicate);
    }
}
