using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class EnumerableExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerable<TSource> AsValueEnumerable<TSource>(this IEnumerable<TSource> source)
            => new(source);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ValueEnumerable<TSource>
            : IValueEnumerable<TSource, ValueEnumerator<TSource>>
        {
            readonly IEnumerable<TSource> source;

            internal ValueEnumerable(IEnumerable<TSource> source) 
                => this.source = source;

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerator<TSource> GetEnumerator() 
                => new(source.GetEnumerator());
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => source.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() 
                => source.GetEnumerator();
        }
    }
}