using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> Single<TSource>(this Memory<TSource> source)
            => ((ReadOnlySpan<TSource>)source.Span).Single();
    }
}
