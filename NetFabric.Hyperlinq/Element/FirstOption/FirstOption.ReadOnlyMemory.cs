using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> FirstOption<TSource>(this ReadOnlyMemory<TSource> source)
            => FirstOption(source.Span);
    }
}
