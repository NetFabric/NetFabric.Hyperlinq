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
    public static partial class ImmutableStackExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ImmutableStackValueEnumerable<TSource> AsValueEnumerable<TSource>(this ImmutableStack<TSource> source)
            => new(source);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ImmutableStackValueEnumerable<TSource>
            : IValueEnumerable<TSource, ImmutableStackValueEnumerable<TSource>.Enumerator>
        {
            readonly ImmutableStack<TSource> source;

            public ImmutableStackValueEnumerable(ImmutableStack<TSource> source) 
                => this.source = source;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() 
                => new(source);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(source);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(source);

            public struct Enumerator
                : IEnumerator<TSource>
            {
                ImmutableStack<TSource>.Enumerator enumerator;

                internal Enumerator(ImmutableStack<TSource> enumerable) 
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

                public void Dispose() { }
            }
        }
    }
}