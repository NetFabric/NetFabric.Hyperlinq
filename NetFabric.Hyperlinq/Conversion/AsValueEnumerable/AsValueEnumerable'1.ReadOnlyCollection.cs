using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollectionExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerable<TSource> AsValueEnumerable<TSource>(this IReadOnlyCollection<TSource> source)
            => new(source);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ValueEnumerable<TSource>
            : IValueReadOnlyCollection<TSource, ValueEnumerator<TSource>>
            , ICollection<TSource>
        {
            readonly IReadOnlyCollection<TSource> source;

            internal ValueEnumerable(IReadOnlyCollection<TSource> source) 
                => this.source = source;

            public int Count
                => source.Count;

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerator<TSource> GetEnumerator() 
                => new(source.GetEnumerator());
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => GetEnumerator();

            bool ICollection<TSource>.IsReadOnly  
                => true;

            public void CopyTo(Span<TSource> span)
            {
                if (span.Length < Count)
                    Throw.ArgumentException(Resource.DestinationNotLongEnough, nameof(span));

                if (source.Count is not 0)
                {
                    using var enumerator = GetEnumerator();
                    checked
                    {
                        for (var index = 0; enumerator.MoveNext(); index++)
                            span[index] = enumerator.Current;
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(TSource[] array, int arrayIndex)
                => CopyTo(array.AsSpan().Slice(arrayIndex));


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource item)
                => Count is not 0 && EnumerableExtensions.Contains(source, item);

            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Add(TSource item) 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Clear() 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            bool ICollection<TSource>.Remove(TSource item) 
                => Throw.NotSupportedException<bool>();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer)
                => Count is not 0 && source.Contains(value, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this ValueEnumerable<TSource> source)
            => source.Count;
    }
}