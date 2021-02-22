using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    [GeneratorIgnore]
    public static partial class ImmutableListExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ImmutableListValueEnumerable<TSource> AsValueEnumerable<TSource>(this ImmutableList<TSource> source)
            => new(source);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ImmutableListValueEnumerable<TSource>
            : IValueReadOnlyList<TSource, ImmutableList<TSource>.Enumerator>
            , IList<TSource>
        {
            readonly ImmutableList<TSource> source;

            public ImmutableListValueEnumerable(ImmutableList<TSource> source) 
                => this.source = source;

            public int Count
                => source.Count;

            public TSource this[int index]
                => source[index];
            TSource IReadOnlyList<TSource>.this[int index]
                => source[index];
            TSource IList<TSource>.this[int index]
            {
                get => source[index];
                set => throw new NotSupportedException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ImmutableList<TSource>.Enumerator GetEnumerator() 
                => source.GetEnumerator();
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => source.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => source.GetEnumerator();

            bool ICollection<TSource>.IsReadOnly  
                => true;

            void ICollection<TSource>.CopyTo(TSource[] array, int arrayIndex) 
                => source.CopyTo(array, arrayIndex);
            
            void ICollection<TSource>.Add(TSource item) 
                => throw new NotSupportedException();
            void ICollection<TSource>.Clear() 
                => throw new NotSupportedException();
            bool ICollection<TSource>.Contains(TSource item) 
                => source.Contains(item);
            bool ICollection<TSource>.Remove(TSource item) 
                => throw new NotSupportedException();
            int IList<TSource>.IndexOf(TSource item)
                => source.IndexOf(item);
            void IList<TSource>.Insert(int index, TSource item)
                => throw new NotSupportedException();
            void IList<TSource>.RemoveAt(int index)
                => throw new NotSupportedException();
        }

        public static int Count<TSource>(this ImmutableListValueEnumerable<TSource> source)
            => source.Count;
    }
}