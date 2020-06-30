using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpanWhereRefEnumerable<TSource> WhereRef<TSource>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate) 
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return new ReadOnlySpanWhereRefEnumerable<TSource>(source, predicate);
        }

        public readonly ref struct ReadOnlySpanWhereRefEnumerable<TSource>
        {
            internal readonly ReadOnlySpan<TSource> source;
            internal readonly Predicate<TSource> predicate;

            internal ReadOnlySpanWhereRefEnumerable(in ReadOnlySpan<TSource> source, Predicate<TSource> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }
            
            
            public readonly Enumerator GetEnumerator() 
                => new Enumerator(in this);

            public ref struct Enumerator 
            {
                readonly ReadOnlySpan<TSource> source;
                readonly Predicate<TSource> predicate;
                int index;

                internal Enumerator(in ReadOnlySpanWhereRefEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    index = -1;
                }

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
                => ArrayExtensions.Count(source, predicate);

            public bool Any()
                => ArrayExtensions.Any(source, predicate);
                
            public SpanWhereEnumerable<TSource> Where(Predicate<TSource> predicate)
                => ArrayExtensions.Where<TSource>(source, Utils.Combine(this.predicate, predicate));

            public SpanWhereAtEnumerable<TSource> Where(PredicateAt<TSource> predicate)
                => ArrayExtensions.Where<TSource>(source, Utils.Combine(this.predicate, predicate));

            public ReadOnlySpanWhereRefEnumerable<TSource> WhereRef(Predicate<TSource> predicate)
                => ArrayExtensions.WhereRef<TSource>(source, Utils.Combine(this.predicate, predicate));

            public ReadOnlySpanWhereRefAtEnumerable<TSource> WhereRef(PredicateAt<TSource> predicate)
                => ArrayExtensions.WhereRef<TSource>(source, Utils.Combine(this.predicate, predicate));

            public SpanWhereSelectEnumerable<TSource, TResult> Select<TResult>(NullableSelector<TSource, TResult> selector)
            {
                if (selector is null) Throw.ArgumentNullException(nameof(selector));

                return WhereSelect<TSource, TResult>(source, predicate, selector);
            }

            public Option<TSource> ElementAt(int index)
                => ArrayExtensions.ElementAt<TSource>(source, index, predicate);

            public Option<TSource> First()
                => ArrayExtensions.First<TSource>(source, predicate);

            public Option<TSource> Single()
                => ArrayExtensions.Single<TSource>(source, predicate);

            public TSource[] ToArray()
                => ArrayExtensions.ToArray(source, predicate);

            public List<TSource> ToList()
                => ArrayExtensions.ToList(source, predicate);

            public bool SequenceEqual(IEnumerable<TSource> other, IEqualityComparer<TSource>? comparer = null)
            {
                comparer ??= EqualityComparer<TSource>.Default;

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

