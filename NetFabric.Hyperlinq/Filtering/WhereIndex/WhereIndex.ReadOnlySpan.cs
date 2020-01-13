using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RefWhereIndexEnumerable<TSource> Where<TSource>(this ReadOnlySpan<TSource> source, PredicateAt<TSource> predicate) 
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return new RefWhereIndexEnumerable<TSource>(source, predicate);
        }

        public readonly ref struct RefWhereIndexEnumerable<TSource>
        {
            internal readonly ReadOnlySpan<TSource> source;
            internal readonly PredicateAt<TSource> predicate;

            internal RefWhereIndexEnumerable(in ReadOnlySpan<TSource> source, PredicateAt<TSource> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            [Pure]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);

            public ref struct Enumerator 
            {
                readonly ReadOnlySpan<TSource> source;
                readonly PredicateAt<TSource> predicate;
                int index;

                internal Enumerator(in RefWhereIndexEnumerable<TSource> enumerable)
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
                        if (predicate(source[index], index))
                            return true;
                    }
                    return false;
                }
            }

            public int Count()
                => source.Count(predicate);

            public TSource First()
                => source.First(predicate);

            [return: MaybeNull]
            public TSource FirstOrDefault()
                => source.FirstOrDefault(predicate);

            public TSource Single()
                => source.Single(predicate);

            [return: MaybeNull]
            public TSource SingleOrDefault()
                => source.SingleOrDefault(predicate);

            public void ForEach(Action<TSource> action)
                => source.ForEach<TSource>(action, predicate);
            public void ForEach(Action<TSource, int> action)
                => source.ForEach<TSource>(action, predicate);
        }
    }
}

