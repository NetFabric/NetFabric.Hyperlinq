using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        public static ArraySegmentWhereEnumerable<TSource, FunctionWrapper<TSource, bool>> Where<TSource>(this in ArraySegment<TSource> source, Func<TSource, bool> predicate)
            => Where(source, new FunctionWrapper<TSource, bool>(predicate));

        public static ArraySegmentWhereEnumerable<TSource, TPredicate> Where<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, bool>
            => new ArraySegmentWhereEnumerable<TSource, TPredicate>(source, predicate);

        public readonly partial struct ArraySegmentWhereEnumerable<TSource, TPredicate>
            : IValueEnumerable<TSource, ArraySegmentWhereEnumerable<TSource, TPredicate>.DisposableEnumerator>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            readonly ArraySegment<TSource> source;
            readonly TPredicate predicate;

            internal ArraySegmentWhereEnumerable(in ArraySegment<TSource> source, TPredicate predicate)
                => (this.source, this.predicate) = (source, predicate);

            public readonly Enumerator GetEnumerator()
                => new Enumerator();
            readonly DisposableEnumerator IValueEnumerable<TSource, ArraySegmentWhereEnumerable<TSource, TPredicate>.DisposableEnumerator>.GetEnumerator()
                => new DisposableEnumerator();
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator()
                => new DisposableEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator()
                => new DisposableEnumerator();

            public struct Enumerator
            {
            }

            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                public readonly TSource Current => default!;
                readonly TSource IEnumerator<TSource>.Current => default!;
                readonly object? IEnumerator.Current => default;

                public bool MoveNext()
                    => false;

                public readonly void Reset()
                    => throw new NotSupportedException();

                public void Dispose() { }
            }

            public ArraySegmentWhereEnumerable<TSource, PredicateCombination<TPredicate, FunctionWrapper<TSource, bool>, TSource>> Where(Func<TSource, bool> predicate)
                => Where(new FunctionWrapper<TSource, bool>(predicate));

            public ArraySegmentWhereEnumerable<TSource, PredicateCombination<TPredicate, TPredicate2, TSource>> Where<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => Where<TSource, PredicateCombination<TPredicate, TPredicate2, TSource>>(source, new PredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));
        }
    }
}

