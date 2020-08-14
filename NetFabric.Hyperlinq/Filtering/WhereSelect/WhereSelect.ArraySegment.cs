using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ArraySegmentWhereSelectEnumerable<TSource, TResult> WhereSelect<TSource, TResult>(
            this ArraySegment<TSource> source, 
            Predicate<TSource> predicate, 
            NullableSelector<TSource, TResult> selector) 
            => new ArraySegmentWhereSelectEnumerable<TSource, TResult>(source, predicate, selector);

        [GeneratorMapping("TSource", "TResult")]
        public readonly partial struct ArraySegmentWhereSelectEnumerable<TSource, TResult>
            : IValueEnumerable<TResult, ArraySegmentWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator>
        {
            internal readonly ArraySegment<TSource> source;
            internal readonly Predicate<TSource> predicate;
            internal readonly NullableSelector<TSource, TResult> selector;

            internal ArraySegmentWhereSelectEnumerable(ArraySegment<TSource> source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector)
            {
                this.source = source;
                this.predicate = predicate;
                this.selector = selector;
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() 
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TResult, ArraySegmentWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new DisposableEnumerator(in this);

            public struct Enumerator
            {
                readonly TSource[]? source;
                readonly Predicate<TSource> predicate;
                readonly NullableSelector<TSource, TResult> selector;
                readonly int end;
                int index;

                internal Enumerator(in ArraySegmentWhereSelectEnumerable<TSource, TResult> enumerable)
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
                        if (predicate(source![index]))
                            return true;
                    }
                    return false;
                }
            }

            public struct DisposableEnumerator
                : IEnumerator<TResult>
            {
                readonly TSource[]? source;
                readonly Predicate<TSource> predicate;
                readonly NullableSelector<TSource, TResult> selector;
                readonly int end;
                int index;

                internal DisposableEnumerator(in ArraySegmentWhereSelectEnumerable<TSource, TResult> enumerable)
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
                        if (predicate(source![index]))
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
                => ArrayExtensions.Count<TSource>(source, predicate);

            public bool Any()
                => ArrayExtensions.Any<TSource>(source, predicate);
                
            public Option<TResult> ElementAt(int index)
                => ArrayExtensions.ElementAt<TSource, TResult>(source, index, predicate, selector);

            public Option<TResult> First()
                => ArrayExtensions.First<TSource, TResult>(source, predicate, selector);

            public Option<TResult> Single()
                => ArrayExtensions.Single<TSource, TResult>(source, predicate, selector);

            public TResult[] ToArray()
                => ArrayExtensions.ToArray<TSource, TResult>(source, predicate, selector);

            public IMemoryOwner<TResult> ToArray(MemoryPool<TResult> memoryPool)
                => ArrayExtensions.ToArray<TSource, TResult>(source, predicate, selector, memoryPool);

            public List<TResult> ToList()
                => ArrayExtensions.ToList<TSource, TResult>(source, predicate, selector);
        }
    }
}

