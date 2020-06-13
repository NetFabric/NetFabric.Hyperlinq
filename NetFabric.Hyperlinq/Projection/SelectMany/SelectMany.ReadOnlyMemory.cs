using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        public static MemorySelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this ReadOnlyMemory<TSource> source, 
            NullableSelector<TSource, TSubEnumerable> selector)
            where TSubEnumerable : notnull, IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
        {
            if (selector is null) Throw.ArgumentNullException(nameof(selector));

            return new MemorySelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult>(source, selector);
        }

        [GeneratorMapping("TSource", "TResult")]
        public readonly partial struct MemorySelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult>
            : IValueEnumerable<TResult, MemorySelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult>.DisposableEnumerator>
            where TSubEnumerable : notnull, IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
        {
            readonly ReadOnlyMemory<TSource> source;
            readonly NullableSelector<TSource, TSubEnumerable> selector;

            internal MemorySelectManyEnumerable(ReadOnlyMemory<TSource> source, NullableSelector<TSource, TSubEnumerable> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            
            public readonly Enumerator GetEnumerator() 
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TResult, MemorySelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult>.DisposableEnumerator>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new DisposableEnumerator(in this);

            public ref struct Enumerator
            {
                readonly ReadOnlySpan<TSource> source;
                readonly NullableSelector<TSource, TSubEnumerable> selector;
                int sourceIndex;
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TSubEnumerator subEnumerator; // do not make readonly
                int state;

                internal Enumerator(in MemorySelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult> enumerable)
                {
                    source = enumerable.source.Span;
                    selector = enumerable.selector;
                    sourceIndex = -1;
                    subEnumerator = default;
                    state = 0;
                }

                [MaybeNull]
                public readonly TResult Current
                    => subEnumerator.Current;

                public bool MoveNext()
                {
                    switch (state)
                    {
                        case 0:
                            state = 1;
                            goto case 1;

                        case 1:
                            if (++sourceIndex >= source.Length)
                                break;

                            var enumerable = selector(source[sourceIndex]);
                            subEnumerator = enumerable.GetEnumerator();
                            
                            state = 2;
                            goto case 2;

                        case 2:
                            if (!subEnumerator.MoveNext())
                            {
                                state = 1;
                                goto case 1;
                            }
                            return true;
                    }
                    return false;
                }
            }

            public struct DisposableEnumerator
                : IEnumerator<TResult>
            {
                readonly ReadOnlyMemory<TSource> source;
                readonly NullableSelector<TSource, TSubEnumerable> selector;
                int sourceIndex;
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TSubEnumerator subEnumerator; // do not make readonly
                int state;

                internal DisposableEnumerator(in MemorySelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    sourceIndex = -1;
                    subEnumerator = default;
                    state = 0;
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
                        case 0:
                            state = 1;
                            goto case 1;

                        case 1:
                            if (++sourceIndex >= source.Length)
                                break;

                            var enumerable = selector(source.Span[sourceIndex]);
                            subEnumerator = enumerable.GetEnumerator();
                            
                            state = 2;
                            goto case 2;

                        case 2:
                            if (!subEnumerator.MoveNext())
                            {
                                state = 1;
                                goto case 1;
                            }
                            return true;
                    }
                    Dispose();
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => throw new NotSupportedException();

                public void Dispose() => subEnumerator.Dispose();
            }
        }
    }
}

