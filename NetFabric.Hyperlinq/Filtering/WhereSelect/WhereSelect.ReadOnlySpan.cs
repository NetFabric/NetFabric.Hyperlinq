using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static SpanWhereSelectEnumerable<TSource, TResult> WhereSelect<TSource, TResult>(
            this ReadOnlySpan<TSource> source, 
            Predicate<TSource> predicate, 
            Selector<TSource, TResult> selector) 
            => new SpanWhereSelectEnumerable<TSource, TResult>(source, predicate, selector);

        [GeneratorMapping("TSource", "TResult")]
        public readonly ref struct SpanWhereSelectEnumerable<TSource, TResult>
        {
            internal readonly ReadOnlySpan<TSource> source;
            internal readonly Predicate<TSource> predicate;
            internal readonly Selector<TSource, TResult> selector;

            internal SpanWhereSelectEnumerable(ReadOnlySpan<TSource> source, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
            {
                this.source = source;
                this.predicate = predicate;
                this.selector = selector;
            }

            
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);

            public ref struct Enumerator
            {
                readonly ReadOnlySpan<TSource> source;
                readonly Predicate<TSource> predicate;
                readonly Selector<TSource, TResult> selector;
                int index;

                internal Enumerator(in SpanWhereSelectEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    index = -1;
                }

                public TResult Current 
                    => selector(source[index]);

                public bool MoveNext()
                {
                    while (++index < source.Length)
                    {
                        if (predicate(source[index]))
                            return true;
                    }
                    return false;
                }
            }

            public int Count()
                => source.Count(predicate);

            public bool Any()
                => ArrayExtensions.Any<TSource>(source, predicate);
                
            public Option<TResult> ElementAt(int index)
                => ArrayExtensions.ElementAt<TSource, TResult>(source, index, predicate, selector);

            public Option<TResult> First()
                => ArrayExtensions.First<TSource, TResult>(source, predicate, selector);

            public Option<TResult> Single()
                => ArrayExtensions.Single<TSource, TResult>(source, predicate, selector);

            public TResult[] ToArray()
                => ArrayExtensions.ToArray(source, predicate, selector);

            public List<TResult> ToList()
                => ArrayExtensions.ToList(source, predicate, selector);

            public bool SequenceEqual(IEnumerable<TResult> other, IEqualityComparer<TResult>? comparer = null)
            {
                comparer ??= EqualityComparer<TResult>.Default;

                var enumerator = GetEnumerator();
                using var otherEnumerator = other.GetEnumerator();
                while (true)
                {
                    var thisEnded = !enumerator.MoveNext();
                    var otherEnded = !otherEnumerator.MoveNext();

                    if (thisEnded != otherEnded)
                        return false;

                    if (thisEnded)
                        return true;

                    if (!comparer.Equals(enumerator.Current, otherEnumerator.Current))
                        return false;
                }
            }
        }
    }
}

