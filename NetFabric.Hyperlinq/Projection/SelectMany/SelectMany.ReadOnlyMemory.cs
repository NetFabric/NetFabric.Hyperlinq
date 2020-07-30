using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        public static MemorySelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this ReadOnlyMemory<TSource> source, 
            Selector<TSource, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
        {
            if (selector is null) Throw.ArgumentNullException(nameof(selector));

            return new MemorySelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult>(source, selector);
        }

        [GeneratorMapping("TSource", "TResult")]
        public readonly partial struct MemorySelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult>
            : IValueEnumerable<TResult, MemorySelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult>.Enumerator>
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
        {
            readonly ReadOnlyMemory<TSource> source;
            readonly Selector<TSource, TSubEnumerable> selector;

            internal MemorySelectManyEnumerable(ReadOnlyMemory<TSource> source, Selector<TSource, TSubEnumerable> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() 
                => new Enumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() 
                => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new Enumerator(in this);

            public struct Enumerator
                : IEnumerator<TResult>
            {
                readonly ReadOnlyMemory<TSource> source;
                readonly Selector<TSource, TSubEnumerable> selector;
                readonly int end;
                EnumeratorState state;
                int sourceIndex;
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TSubEnumerator subEnumerator; // do not make readonly

                internal Enumerator(in MemorySelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    state = EnumeratorState.Enumerating;
                    sourceIndex = -1;
                    end = sourceIndex + enumerable.source.Length;
                    subEnumerator = default;
                }

                [MaybeNull]
                public readonly TResult Current
                    => subEnumerator.Current;
                readonly TResult IEnumerator<TResult>.Current 
                    => subEnumerator.Current;
                readonly object? IEnumerator.Current 
                    => subEnumerator.Current;

                public bool MoveNext()
                {
                    switch (state)
                    {
                        case EnumeratorState.Enumerating:
                            if (++sourceIndex >= end)
                            {
                                Dispose();
                                state = EnumeratorState.Complete;
                                return false;
                            }

                            var enumerable = selector(source.Span[sourceIndex]);
                            subEnumerator = enumerable.GetEnumerator();

                            state = EnumeratorState.EnumeratingSub;
                            goto case EnumeratorState.EnumeratingSub;

                        case EnumeratorState.EnumeratingSub:
                            if (!subEnumerator.MoveNext())
                            {
                                state = EnumeratorState.Enumerating;
                                goto case EnumeratorState.Enumerating;
                            }
                            return true;

                        default:
                            return false;
                    }
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => throw new NotSupportedException();

                public void Dispose() 
                    => subEnumerator.Dispose();
            }
        }
    }
}

