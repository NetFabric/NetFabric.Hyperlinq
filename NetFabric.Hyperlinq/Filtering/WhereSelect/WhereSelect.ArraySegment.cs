using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate> WhereSelect<TSource, TResult, TPredicate>(
            this ArraySegment<TSource> source,
            TPredicate predicate, 
            NullableSelector<TSource, TResult> selector)
            where TPredicate : struct, IPredicate<TSource>
            => new ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate>(source, predicate, selector);

        [GeneratorMapping("TSource", "TResult")]
        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate>
            : IValueEnumerable<TResult, ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate>.DisposableEnumerator>
            where TPredicate : struct, IPredicate<TSource>
        {
            internal readonly ArraySegment<TSource> source;
            internal readonly TPredicate predicate;
            internal readonly NullableSelector<TSource, TResult> selector;

            internal ArraySegmentWhereSelectEnumerable(ArraySegment<TSource> source, TPredicate predicate, NullableSelector<TSource, TResult> selector)
                => (this.source, this.predicate, this.selector) = (source, predicate, selector);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() 
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TResult, ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate>.DisposableEnumerator>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new DisposableEnumerator(in this);

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
            {
                int index;
                readonly int end;
                readonly TSource[]? source;
                readonly TPredicate predicate;
                readonly NullableSelector<TSource, TResult> selector;

                internal Enumerator(in ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate> enumerable)
                {
                    source = enumerable.source.Array;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    index = enumerable.source.Offset - 1;
                    end = index + enumerable.source.Count;
                }

                [MaybeNull]
                public TResult Current 
                    => selector(source![index]);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate.Invoke(source![index]))
                            return true;
                    }
                    return false;
                }
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct DisposableEnumerator
                : IEnumerator<TResult>
            {
                int index;
                readonly int end;
                readonly TSource[]? source;
                readonly TPredicate predicate;
                readonly NullableSelector<TSource, TResult> selector;

                internal DisposableEnumerator(in ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate> enumerable)
                {
                    source = enumerable.source.Array;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    index = enumerable.source.Offset - 1;
                    end = index + enumerable.source.Count;
                }

                [MaybeNull]
                public readonly TResult Current 
                    => selector(source![index]);
                readonly TResult IEnumerator<TResult>.Current 
                    => selector(source![index])!;
                readonly object? IEnumerator.Current 
                    => selector(source![index]);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate.Invoke(source![index]))
                            return true;
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => throw new NotSupportedException();

                public void Dispose() { }                
            }

            public int Count()
                => ArrayExtensions.Count<TSource, TPredicate>(source, predicate);

            public bool Any()
                => ArrayExtensions.Any<TSource, TPredicate>(source, predicate);
                
            public Option<TResult> ElementAt(int index)
                => ArrayExtensions.ElementAt<TSource, TResult, TPredicate>(source, index, predicate, selector);

            public Option<TResult> First()
                => ArrayExtensions.First<TSource, TResult, TPredicate>(source, predicate, selector);

            public Option<TResult> Single()
                => ArrayExtensions.Single<TSource, TResult, TPredicate>(source, predicate, selector);

            public TResult[] ToArray()
                => ArrayExtensions.ToArray<TSource, TResult, TPredicate>(source, predicate, selector);

            public IMemoryOwner<TResult> ToArray(MemoryPool<TResult> memoryPool)
                => ArrayExtensions.ToArray<TSource, TResult, TPredicate>(source, predicate, selector, memoryPool);

            public List<TResult> ToList()
                => ArrayExtensions.ToList<TSource, TResult, TPredicate>(source, predicate, selector);
        }
    }
}

