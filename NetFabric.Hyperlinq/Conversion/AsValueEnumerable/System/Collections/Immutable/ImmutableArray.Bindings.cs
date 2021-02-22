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
    public static partial class ImmutableArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ImmutableArrayValueEnumerable<TSource> AsValueEnumerable<TSource>(this ImmutableArray<TSource> source)
            => new(source);

        [StructLayout(LayoutKind.Auto)]
        public partial struct ImmutableArrayValueEnumerable<TSource>
            : IValueReadOnlyList<TSource, ImmutableArrayValueEnumerable<TSource>.Enumerator>
            , IList<TSource>
        {
            ImmutableArray<TSource> source;

            public ImmutableArrayValueEnumerable(ImmutableArray<TSource> source) 
                => this.source = source;

            public int Count
                => source.Length;

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
            public readonly Enumerator GetEnumerator() 
                => new(source);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(source);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(source);

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

            public struct Enumerator
                : IEnumerator<TSource>
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                // ReSharper disable once FieldCanBeMadeReadOnly.Local
                ImmutableArray<TSource>.Enumerator enumerator; // do not make readonly

                internal Enumerator(ImmutableArray<TSource> enumerable) 
                    => enumerator = enumerable.GetEnumerator();

                public readonly TSource Current 
                    => enumerator.Current;
                readonly TSource IEnumerator<TSource>.Current 
                    => enumerator.Current;
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => enumerator.Current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => enumerator.MoveNext();

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => throw new NotSupportedException();

                public readonly void Dispose() { }
            }
        }

        public static int Count<TSource>(this ImmutableArrayValueEnumerable<TSource> source)
            => source.Count;
    }
}