using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    [GeneratorIgnore]
    public static partial class ImmutableHashSetExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ImmutableHashSetValueEnumerable<TSource> AsValueEnumerable<TSource>(this ImmutableHashSet<TSource> source)
            => new(source);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ImmutableHashSetValueEnumerable<TSource>
            : IValueReadOnlyCollection<TSource, ImmutableHashSet<TSource>.Enumerator>
            , ICollection<TSource>
        {
            readonly ImmutableHashSet<TSource> source;

            public ImmutableHashSetValueEnumerable(ImmutableHashSet<TSource> source) 
                => this.source = source;

            public int Count 
                => source.Count;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ImmutableHashSet<TSource>.Enumerator GetEnumerator() 
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
                => ((ICollection<TSource>)source).CopyTo(array, arrayIndex);

            void ICollection<TSource>.Add(TSource item) 
                => throw new NotSupportedException();
            void ICollection<TSource>.Clear() 
                => throw new NotSupportedException();
            bool ICollection<TSource>.Contains(TSource item) 
                => throw new NotSupportedException();
            bool ICollection<TSource>.Remove(TSource item) 
                => throw new NotSupportedException();
        }

        public static int Count<TSource>(this ImmutableHashSetValueEnumerable<TSource> source)
            => source.Count;
    }
}