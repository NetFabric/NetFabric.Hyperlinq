using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        public static SelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this TSource[] source, 
            Func<TSource, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
        {
            if (selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new SelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult>(source, selector);
        }

        [GenericsTypeMapping("TEnumerable", typeof(SelectManyEnumerable<,,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(SelectManyEnumerable<,,,>.Enumerator))]
        public readonly struct SelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult>
            : IValueEnumerable<TResult, SelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult>.Enumerator>
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
        {
            readonly TSource[] source;
            readonly Func<TSource, TSubEnumerable> selector;

            internal SelectManyEnumerable(TSource[] source, Func<TSource, TSubEnumerable> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new DisposableEnumerator<TResult, Enumerator>(new Enumerator(in this));
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator<TResult, Enumerator>(new Enumerator(in this));

            public struct Enumerator
                : IValueEnumerator<TResult>
            {
                readonly TSource[] source;
                readonly Func<TSource, TSubEnumerable> selector;
                readonly int sourceCount;
                int sourceIndex;
                TSubEnumerator subEnumerator;
                int state;

                internal Enumerator(in SelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    sourceCount = source.Length;
                    sourceIndex = -1;
                    subEnumerator = default;
                    state = 0;
                }

                public readonly TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => subEnumerator.Current;
                }

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
                    return false;
                }
            }
        }
    }
}

