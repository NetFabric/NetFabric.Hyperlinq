using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
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
                => Array.Any<TSource>(source, predicate);
                
            public bool Contains(TResult value, IEqualityComparer<TResult>? comparer = null)
                => Array.Contains<TSource, TResult>(source, value, comparer, predicate, selector);

            public Option<TResult> ElementAt(int index)
                => Array.ElementAt<TSource, TResult>(source, index, predicate, selector);

            public Option<TResult> First()
                => Array.First<TSource, TResult>(source, predicate, selector);

            public Option<TResult> Single()
                => Array.Single<TSource, TResult>(source, predicate, selector);

            public TResult[] ToArray()
                => Array.ToArray(source, predicate, selector);

            public List<TResult> ToList()
                => Array.ToList(source, predicate, selector);
        }
    }
}

