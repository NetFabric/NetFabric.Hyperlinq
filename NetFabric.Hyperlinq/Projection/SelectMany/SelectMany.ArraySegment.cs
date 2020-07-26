using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this in ArraySegment<TSource> source,
            Selector<TSource, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
        {
            if (selector is null)
                Throw.ArgumentNullException(nameof(selector));

            return new ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult>(source, selector);
        }

        [GeneratorMapping("TSource", "TResult")]
        public readonly partial struct ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult>
            : IValueEnumerable<TResult, ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult>.DisposableEnumerator>
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
        {
            readonly ArraySegment<TSource> source;
            readonly Selector<TSource, TSubEnumerable> selector;

            internal ArraySegmentSelectManyEnumerable(ArraySegment<TSource> source, Selector<TSource, TSubEnumerable> selector)
            {
                this.source = source;
                this.selector = selector;
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator()
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TResult, ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult>.DisposableEnumerator>.GetEnumerator()
                => new DisposableEnumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator()
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator()
                => new DisposableEnumerator(in this);

            public struct Enumerator
            {
                readonly TSource[] source;
                readonly Selector<TSource, TSubEnumerable> selector;
                readonly int end;
                int sourceIndex;
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TSubEnumerator subEnumerator; // do not make readonly
                int state;

                internal Enumerator(in ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult> enumerable)
                {
                    source = enumerable.source.Array;
                    selector = enumerable.selector;
                    sourceIndex = enumerable.source.Offset - 1;
                    end = sourceIndex + enumerable.source.Count;
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
                            if (++sourceIndex >= end)
                                break;

                            var enumerable = selector(source[sourceIndex]);
                            if (enumerable is null)
                                Throw.InvalidOperationException("The 'selector' in SelectMany returned 'null'.");
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
                readonly TSource[] source;
                readonly Selector<TSource, TSubEnumerable> selector;
                readonly int end;
                int sourceIndex;
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TSubEnumerator subEnumerator; // do not make readonly
                int state;

                internal DisposableEnumerator(in ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult> enumerable)
                {
                    source = enumerable.source.Array;
                    selector = enumerable.selector;
                    sourceIndex = enumerable.source.Offset - 1;
                    end = sourceIndex + enumerable.source.Count;
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
                            if (++sourceIndex >= end)
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

