using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static class ListExtensions
    {
        // List<TSource> is simply converted to ArraySegment<TSource> and share its IValueEnumerable<TSource> wrapper.
        // It's not converted to ReadOnlySpan<TSource> because its enumerables cannot be casted to IEnumerable<TSource>, restricting its use.
        // It's not converted to ReadOnlyMemory<TSource> because it's less efficient in enumerables (it has to call .Span on each iteration).
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.ArraySegmentValueEnumerable<TSource> AsValueEnumerable<TSource>(this List<TSource> source)
            => source.AsArraySegment().AsValueEnumerable();
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ArraySegment<TSource> AsArraySegment<TSource>(this List<TSource> source)
            => new(source.GetItems(), 0, source.Count);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static List<TSource> AsList<TSource>(this TSource[] source)
        {
            return source switch
            {
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                { Length: 0 } => new List<TSource>(),
                _ => WrapArray(source)
            };

            static List<TSource> WrapArray(TSource[] source)
            {
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                var result = new List<TSource>();
                var layout = Unsafe.As<List<TSource>, ListLayout<TSource>>(ref result);
                layout.items = source;
                layout.size = source.Length;
                result.Capacity = source.Length;
                return result;
            }
        }

        // ReSharper disable once ClassNeverInstantiated.Local
        class ListLayout<TSource>
        {
            public TSource[]? items;
            
#if !NETCOREAPP3_0_OR_GREATER
#pragma warning disable IDE0051 // Remove unused private members
#pragma warning disable 169
            readonly object? syncRoot;
#pragma warning restore 169
#pragma warning restore IDE0051 // Remove unused private members
#endif
            public int size;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] GetItems<TSource>(this List<TSource> source)
            => Unsafe.As<List<TSource>, ListLayout<TSource>>(ref source).items 
               ?? Array.Empty<TSource>();
    }
}