using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TEnumerable, TEnumerator, TSource, TResult>(
            this TEnumerable source, 
            NullableSelectorAt<TSource, TResult> selector)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (selector is null) Throw.ArgumentNullException(nameof(selector));

            return new SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>(in source, selector);
        }

        [GeneratorMapping("TSource", "TResult")]
        public readonly partial struct SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult> 
            : IValueEnumerable<TResult, SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator>
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly NullableSelectorAt<TSource, TResult> selector;

            internal SelectAtEnumerable(in TEnumerable source, NullableSelectorAt<TSource, TResult> selector)
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
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly
                readonly NullableSelectorAt<TSource, TResult> selector;
                int index;

                internal Enumerator(in SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    selector = enumerable.selector;
                    index = -1;
                }

                [MaybeNull]
                public readonly TResult Current
                    => selector(enumerator.Current, index);
                readonly TResult IEnumerator<TResult>.Current 
                    => selector(enumerator.Current, index)!;
                readonly object? IEnumerator.Current
                    => selector(enumerator.Current, index);

                public bool MoveNext()
                {
                    if (enumerator.MoveNext())
                    {
                        checked { index++; }
                        return true;
                    }
                    Dispose();
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public void Dispose() => enumerator.Dispose();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count()
                => ValueEnumerableExtensions.Count<TEnumerable, TEnumerator, TSource>(source);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => ValueEnumerableExtensions.Any<TEnumerable, TEnumerator, TSource>(source);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TSelectorResult> Select<TSelectorResult>(NullableSelector<TResult, TSelectorResult> selector)
                => ValueEnumerableExtensions.Select<TEnumerable, TEnumerator, TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TSelectorResult> Select<TSelectorResult>(NullableSelectorAt<TResult, TSelectorResult> selector)
                => ValueEnumerableExtensions.Select<TEnumerable, TEnumerator, TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector));


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => ValueEnumerableExtensions.ElementAt<TEnumerable, TEnumerator, TSource, TResult>(source, index, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => ValueEnumerableExtensions.First<TEnumerable, TEnumerator, TSource, TResult>(source, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => ValueEnumerableExtensions.Single<TEnumerable, TEnumerator, TSource, TResult>(source, selector);

            public TResult[] ToArray()
                => ValueEnumerableExtensions.ToArray<TEnumerable, TEnumerator, TSource, TResult>(source, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IMemoryOwner<TResult> ToArray(MemoryPool<TResult> pool)
                => ValueEnumerableExtensions.ToArray<TEnumerable, TEnumerator, TSource, TResult>(source, selector, pool);

            public List<TResult> ToList()
                => ValueEnumerableExtensions.ToList<TEnumerable, TEnumerator, TSource, TResult>(source, selector);
        }
    }
}

