using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        
        public static SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TList, TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this TList source, 
            Selector<TSource, TSubEnumerable> selector)
            where TList : notnull, IReadOnlyList<TSource>
            where TSubEnumerable : notnull, IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
        {
            if (selector is null) Throw.ArgumentNullException(nameof(selector));

            return new SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult>(source, selector);
        }

        [GeneratorMapping("TSource", "TResult")]
        public readonly partial struct SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult>
            : IValueEnumerable<TResult, SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult>.Enumerator>
            where TList : notnull, IReadOnlyList<TSource>
            where TSubEnumerable : notnull, IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
        {
            readonly TList source;
            readonly Selector<TSource, TSubEnumerable> selector;

            internal SelectManyEnumerable(TList source, Selector<TSource, TSubEnumerable> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IEnumerator<TResult>
            {
                readonly TList source;
                readonly Selector<TSource, TSubEnumerable> selector;
                readonly int sourceCount;
                int sourceIndex;
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TSubEnumerator subEnumerator; // do not make readonly
                int state;

                internal Enumerator(in SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    sourceCount = source.Count;
                    sourceIndex = -1;
                    subEnumerator = default;
                    state = 0;
                }

                public readonly TResult Current
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
                            if (++sourceIndex >= sourceCount)
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

