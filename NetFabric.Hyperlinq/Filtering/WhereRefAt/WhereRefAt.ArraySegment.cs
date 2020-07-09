using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        public static WhereRefAtEnumerable<TSource> WhereRef<TSource>(this in ArraySegment<TSource> source, PredicateAt<TSource> predicate)
            => new WhereRefAtEnumerable<TSource>(in source, predicate);

        [GeneratorIgnore]
        public readonly struct WhereRefAtEnumerable<TSource>
        {
            readonly ArraySegment<TSource> source;
            readonly PredicateAt<TSource> predicate;

            internal WhereRefAtEnumerable(in ArraySegment<TSource> source, PredicateAt<TSource> predicate)
                => (this.source, this.predicate) = (source, predicate);

            public readonly Enumerator GetEnumerator() 
                => new Enumerator(in this);

            public struct Enumerator
            {
                readonly TSource[] source;
                readonly PredicateAt<TSource> predicate;
                readonly int offset;
                readonly int count;
                int index;

                internal Enumerator(in WhereRefAtEnumerable<TSource> enumerable)
                {
                    source = enumerable.source.Array;
                    predicate = enumerable.predicate;
                    offset = enumerable.source.Offset;
                    count = enumerable.source.Count;
                    index = -1;
                }

                [MaybeNull]
                public readonly ref TSource Current
                    => ref source[index + offset]!;

                public bool MoveNext()
                {
                    while (++index < count)
                    {
                        if (predicate(source[index + offset], index))
                            return true;
                    }
                    return false;
                }
            }

            public bool SequenceEqual(IEnumerable<TSource> other, IEqualityComparer<TSource>? comparer = null)
            {
                if (Utils.UseDefault(comparer))
                {
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

                        if (!EqualityComparer<TSource>.Default.Equals(enumerator.Current, otherEnumerator.Current))
                            return false;
                    }
                }
                else
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
}

