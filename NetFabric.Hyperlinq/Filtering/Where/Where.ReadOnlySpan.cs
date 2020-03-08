using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanWhereEnumerable<TSource> Where<TSource>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate) 
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return new SpanWhereEnumerable<TSource>(source, predicate);
        }

        public readonly ref struct SpanWhereEnumerable<TSource>
        {
            internal readonly ReadOnlySpan<TSource> source;
            internal readonly Predicate<TSource> predicate;

            internal SpanWhereEnumerable(in ReadOnlySpan<TSource> source, Predicate<TSource> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }
            
            [Pure]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);

            public ref struct Enumerator 
            {
                readonly ReadOnlySpan<TSource> source;
                readonly Predicate<TSource> predicate;
                int index;

                internal Enumerator(in SpanWhereEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    index = -1;
                }

                [MaybeNull]
                public readonly ref readonly TSource Current 
                    => ref source[index];

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
                => Array.Count(source, predicate);

            public bool Any()
                => Array.Any(source, predicate);
                
            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer = null)
                => Array.Contains(source, value, comparer, predicate);

            public SpanWhereEnumerable<TSource> Where(Predicate<TSource> predicate)
                => Where<TSource>(source, Utils.Combine(this.predicate, predicate));

            public SpanWhereIndexEnumerable<TSource> Where(PredicateAt<TSource> predicate)
                => Where<TSource>(source, Utils.Combine(this.predicate, predicate));

            public SpanWhereSelectEnumerable<TSource, TResult> Select<TResult>(Selector<TSource, TResult> selector)
                => WhereSelect<TSource, TResult>(source, predicate, selector);

            public ref readonly TSource ElementAt(int index)
                => ref Array.ElementAt<TSource>(source, index, predicate);

            [return: MaybeNull]
            public ref readonly TSource ElementAtOrDefault(int index)
                => ref Array.ElementAtOrDefault<TSource>(source, index, predicate);

            public ref readonly TSource First()
                => ref Array.First<TSource>(source, predicate);

            [return: MaybeNull]
            public ref readonly TSource FirstOrDefault()
                => ref Array.FirstOrDefault<TSource>(source, predicate);

            public ref readonly TSource Single()
                => ref Array.Single<TSource>(source, predicate);

            [return: MaybeNull]
            public ref readonly TSource SingleOrDefault()
                => ref Array.SingleOrDefault<TSource>(source, predicate);

            public TSource[] ToArray()
                => Array.ToArray(source, predicate);

            public List<TSource> ToList()
                => Array.ToList(source, predicate);

            public void ForEach(Action<TSource> action)
                => Array.ForEach(source, action, predicate);
            public void ForEach(ActionAt<TSource> action)
                => Array.ForEach(source, action, predicate);
        }
    }
}

