using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static WhereRefEnumerable<TSource> WhereRef<TSource>(this in ArraySegment<TSource> source, Predicate<TSource> predicate)
            => new WhereRefEnumerable<TSource>(source, predicate);

        [GeneratorIgnore]
        public readonly struct WhereRefEnumerable<TSource>
        {
            readonly ArraySegment<TSource> source;
            readonly Predicate<TSource> predicate;

            internal WhereRefEnumerable(in ArraySegment<TSource> source, Predicate<TSource> predicate)
                => (this.source, this.predicate) = (source, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator()
                => new Enumerator(in this);

            public struct Enumerator
            {
                readonly TSource[] source;
                readonly Predicate<TSource> predicate;
                readonly int end;
                int index;

                internal Enumerator(in WhereRefEnumerable<TSource> enumerable)
                {
                    source = enumerable.source.Array;
                    predicate = enumerable.predicate;
                    end = enumerable.source.Offset + enumerable.source.Count;
                    index = enumerable.source.Offset - 1;
                }

                public readonly ref TSource Current
                    => ref source[index];

                public bool MoveNext()
                {
                    while (++index < end)
                    {
                        if (predicate(source[index]))
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

