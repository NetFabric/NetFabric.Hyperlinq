using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        [Pure]
        public static SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this TEnumerable source, 
            Func<TSource, TSubEnumerable> selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
        {
            if (selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(in source, selector);
        }

        [GenericsTypeMapping("TEnumerable", typeof(SelectManyEnumerable<,,,,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(SelectManyEnumerable<,,,,,>.Enumerator))]
        public readonly struct SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>
            : IValueEnumerable<TResult, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>.Enumerator>
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
        {
            readonly TEnumerable source;
            readonly Func<TSource, TSubEnumerable> selector;

            internal SelectManyEnumerable(in TEnumerable source, Func<TSource, TSubEnumerable> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IEnumerator<TResult>
            {
                TEnumerator sourceEnumerator;
                readonly Func<TSource, TSubEnumerable> selector;
                TSubEnumerator subEnumerator;
                int state;

                internal Enumerator(in SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> enumerable)
                {
                    sourceEnumerator = enumerable.source.GetEnumerator();
                    selector = enumerable.selector;
                    subEnumerator = default;
                    state = 0;
                }

                public readonly TResult Current
                    => subEnumerator.Current;
                readonly object IEnumerator.Current
                    => subEnumerator.Current;

                public bool MoveNext()
                {
                    switch (state)
                    {
                        case 0:
                            state = 1;
                            goto case 1;

                        case 1:
                            if (!sourceEnumerator.MoveNext())
                                break;

                            var enumerable = selector(sourceEnumerator.Current);
                            subEnumerator = enumerable.GetEnumerator();
                            
                            state = 2;
                            goto case 2;

                        case 2:
                            if (!subEnumerator.MoveNext())
                            {
                                subEnumerator.Dispose();
                                state = 1;
                                goto case 1;
                            }
                            return true;
                    }
                    return false;
                }

                void IEnumerator.Reset()
                    => throw new NotSupportedException();

                public void Dispose()
                {
                    if (state != 0)
                        subEnumerator.Dispose();
                    sourceEnumerator.Dispose();
                }
            }
        }
    }
}

