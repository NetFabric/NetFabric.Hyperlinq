using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {
        public static WhereEnumerable<TEnumerable, TEnumerator, TSource, FunctionWrapper<TSource, bool>> Where<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => Where<TEnumerable, TEnumerator, TSource, FunctionWrapper<TSource, bool>>(source, new FunctionWrapper<TSource, bool>(predicate));

        public static WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate> Where<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            => new WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

        public readonly partial struct WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>
            : IValueEnumerable<TSource, WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>.DisposableEnumerator>
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            readonly TEnumerable source;
            readonly TPredicate predicate;

            internal WhereEnumerable(TEnumerable source, TPredicate predicate)
                => (this.source, this.predicate) = (source, predicate);

            public readonly Enumerator GetEnumerator()
                => new Enumerator();
            readonly DisposableEnumerator IValueEnumerable<TSource, WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>.DisposableEnumerator>.GetEnumerator()
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

            public WhereEnumerable<TEnumerable, TEnumerator, TSource, PredicateCombination<TPredicate, FunctionWrapper<TSource, bool>, TSource>> Where(Func<TSource, bool> predicate)
                => Where(new FunctionWrapper<TSource, bool>(predicate));

            public WhereEnumerable<TEnumerable, TEnumerator, TSource, PredicateCombination<TPredicate, TPredicate2, TSource>> Where<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => Where<TEnumerable, TEnumerator, TSource, PredicateCombination<TPredicate, TPredicate2, TSource>>(source, new PredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));
        }
    }
}

