using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        
        public static EmptyEnumerable<TSource> Empty<TSource>() =>
            EmptyEnumerable<TSource>.Instance;

        public partial class EmptyEnumerable<TSource>
            : IValueReadOnlyList<TSource, EmptyEnumerable<TSource>.DisposableEnumerator>
            , IList<TSource>
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            internal static EmptyEnumerable<TSource> Instance { get; } = new();

            EmptyEnumerable() { }

            public int Count 
                => 0;

            public TSource this[int index]
                => Throw.IndexOutOfRangeException<TSource>();
            TSource IList<TSource>.this[int index]
            {
                get => this[index];
                
                [ExcludeFromCodeCoverage]
                // ReSharper disable once ValueParameterNotUsed
                set => Throw.NotSupportedException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator GetEnumerator() 
                => new();
            DisposableEnumerator IValueEnumerable<TSource, DisposableEnumerator>.GetEnumerator() 
                => new();
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator();
            IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator();

            bool ICollection<TSource>.IsReadOnly  
                => true;

            public void CopyTo(Span<TSource> span) 
            {
                // nothing to do 
            }

            public void CopyTo(TSource[] array, int arrayIndex)
            {
                // nothing to do 
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource item)
                => false;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int IndexOf(TSource item)
                => -1;

            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Add(TSource item) 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Clear() 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            bool ICollection<TSource>.Remove(TSource item) 
                => Throw.NotSupportedException<bool>();

            [ExcludeFromCodeCoverage]
            void IList<TSource>.Insert(int index, TSource item)
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void IList<TSource>.RemoveAt(int index)
                => Throw.NotSupportedException();

            public readonly struct Enumerator
            {
                public readonly TSource Current
                    => default!;

                public readonly bool MoveNext() 
                    => default;
            }

            public readonly struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                public readonly TSource Current
                    => default!;

                readonly TSource IEnumerator<TSource>.Current
                    => default!;

                readonly object? IEnumerator.Current 
                    => default!;

                public readonly bool MoveNext()
                    => default;

                [ExcludeFromCodeCoverage]
                public readonly void Reset() { }

                public readonly void Dispose() { }
            }
        }
    }
}

