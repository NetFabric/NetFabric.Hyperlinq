#nullable enable

using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq;

static partial class GeneratedExtensionMethods
{

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count(this NetFabric.Hyperlinq.ArrayExtensions.SpanValueEnumerable<int> source, Func<int, bool> predicate) 
        => NetFabric.Hyperlinq.ArrayExtensions.Count(source.Span, predicate);
}
