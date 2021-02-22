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
    public static partial class ImmutableQueueExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ImmutableQueueValueEnumerable<TSource> AsValueEnumerable<TSource>(this ImmutableQueue<TSource> source)
            => new(source);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ImmutableQueueValueEnumerable<TSource>
            : IValueEnumerable<TSource, ImmutableQueueValueEnumerable<TSource>.Enumerator>
        {
            readonly ImmutableQueue<TSource> source;

            public ImmutableQueueValueEnumerable(ImmutableQueue<TSource> source) 
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
                ImmutableQueue<TSource>.Enumerator enumerator;

                internal Enumerator(ImmutableQueue<TSource> enumerable) 
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
    }
}