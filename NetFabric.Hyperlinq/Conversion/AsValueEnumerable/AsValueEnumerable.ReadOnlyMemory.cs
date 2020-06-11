using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryValueEnumerableWrapper<TSource> AsValueEnumerable<TSource>(this ReadOnlyMemory<TSource> source)
            => new MemoryValueEnumerableWrapper<TSource>(source);

        public readonly partial struct MemoryValueEnumerableWrapper<TSource>
            : IValueReadOnlyList<TSource, MemoryValueEnumerableWrapper<TSource>.DisposableEnumerator>
            , IList<TSource>
        {
            readonly ReadOnlyMemory<TSource> source;

            internal MemoryValueEnumerableWrapper(ReadOnlyMemory<TSource> source) 
                => this.source = source;

            public readonly int Count 
                => source.Length;

            public readonly ref readonly TSource this[int index] 
                => ref source.Span[index];
            readonly TSource IReadOnlyList<TSource>.this[int index]
                => source.Span[index];
            TSource IList<TSource>.this[int index]
            {
                get => source.Span[index];
                set => throw new NotSupportedException();
            }

            public readonly Enumerator GetEnumerator() 
                => new Enumerator(source);
            readonly DisposableEnumerator IValueEnumerable<TSource, MemoryValueEnumerableWrapper<TSource>.DisposableEnumerator>.GetEnumerator() 
                => new DisposableEnumerator(source);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => new DisposableEnumerator(source);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new DisposableEnumerator(source);

            bool ICollection<TSource>.IsReadOnly  
                => true;

            void ICollection<TSource>.CopyTo(TSource[] array, int arrayIndex) 
            {
                var span = source.Span;
                for (var index = 0; index < source.Length; index++)
                    array[arrayIndex + index] = span[index];
            }
            void ICollection<TSource>.Add(TSource item) 
                => throw new NotSupportedException();
            void ICollection<TSource>.Clear() 
                => throw new NotSupportedException();
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            bool ICollection<TSource>.Contains(TSource item) 
                => source.Contains(item);
            bool ICollection<TSource>.Remove(TSource item) 
                => throw new NotSupportedException();
            int IList<TSource>.IndexOf(TSource item)
            {
                var span = source.Span;
                if (default(TSource) is object)
                {
                    for (var index = 0; index < source.Length; index++)
                    {
                        if (EqualityComparer<TSource>.Default.Equals(span[index], item))
                            return index;
                    }
                }
                else
                {
                    var defaultComparer = EqualityComparer<TSource>.Default;
                    for (var index = 0; index < source.Length; index++)
                    {
                        if (defaultComparer.Equals(span[index], item))
                            return index;
                    }
                }
                return -1;
            }
            void IList<TSource>.Insert(int index, TSource item)
                => throw new NotSupportedException();
            void IList<TSource>.RemoveAt(int index)
                => throw new NotSupportedException();

            public ref struct Enumerator
            {
                readonly ReadOnlySpan<TSource> source;
                int index;

                internal Enumerator(ReadOnlyMemory<TSource> source)
                {
                    this.source = source.Span;
                    index = -1;
                }

                public readonly ref readonly TSource Current 
                    => ref source[index];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index < source.Length;
            }

            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                readonly ReadOnlyMemory<TSource> source;
                int index;

                internal DisposableEnumerator(ReadOnlyMemory<TSource> source)
                {
                    this.source = source;
                    index = -1;
                }

                public readonly ref readonly TSource Current 
                    => ref source.Span[index];
                readonly TSource IEnumerator<TSource>.Current 
                    => source.Span[index];
                readonly object? IEnumerator.Current 
                    => source.Span[index];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() => ++index < source.Length;

                [ExcludeFromCodeCoverage]
                public void Reset() => index = -1;

                public readonly void Dispose() { }
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => source.Span.ToArray();

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => Array.ToList<TSource>(source.Span);
        }

        public static int Count<TSource>(this MemoryValueEnumerableWrapper<TSource> source)
            => source.Count;
    }
}