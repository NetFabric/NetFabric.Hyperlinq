using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate> WhereSelect<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(
            this TEnumerable source,
            TPredicate predicate,
            NullableSelector<TSource, TResult> selector)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicate<TSource>
            => new WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(in source, predicate, selector);

        [GeneratorMapping("TSource", "TResult")]
        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate> 
            : IValueEnumerable<TResult, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate>.Enumerator>
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            readonly TEnumerable source;
            readonly TPredicate predicate;
            readonly NullableSelector<TSource, TResult> selector;

            internal WhereSelectEnumerable(in TEnumerable source, TPredicate predicate, NullableSelector<TSource, TResult> selector)
                => (this.source, this.predicate, this.selector) = (source, predicate, selector);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
                : IEnumerator<TResult>
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly
                readonly TPredicate predicate;
                readonly NullableSelector<TSource, TResult> selector;

                internal Enumerator(in WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                }

                [MaybeNull]
                public readonly TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector(enumerator.Current);
                }
                readonly TResult IEnumerator<TResult>.Current 
                    => selector(enumerator.Current)!;
                readonly object? IEnumerator.Current 
                    => selector(enumerator.Current);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (enumerator.MoveNext())
                    {
                        if (predicate.Invoke(enumerator.Current))
                            return true;
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public void Dispose() 
                    => enumerator.Dispose();
            }

            public int Count()
                => ValueEnumerableExtensions.Count<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

            public bool Any()
                => ValueEnumerableExtensions.Any<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);
                
            public Option<TResult> ElementAt(int index)
                => ValueEnumerableExtensions.ElementAt<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(source, index, predicate, selector);

            public Option<TResult> First()
                => ValueEnumerableExtensions.First<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(source, predicate, selector);

            public Option<TResult> Single()
                => ValueEnumerableExtensions.Single<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(source, predicate, selector);

            public TResult[] ToArray()
                => ValueEnumerableExtensions.ToArray<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(source, predicate, selector);

            public IMemoryOwner<TResult> ToArray(MemoryPool<TResult> pool)
                => ValueEnumerableExtensions.ToArray<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(source, predicate, selector, pool);

            public List<TResult> ToList()
                => ValueEnumerableExtensions.ToList<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(source, predicate, selector);
        }
    }
}

