using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentWhereRefAtEnumerable<TSource, ValuePredicateAt<TSource>> WhereRef<TSource>(this in ArraySegment<TSource> source, PredicateAt<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return WhereRefAt(source, new ValuePredicateAt<TSource>(predicate));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentWhereRefAtEnumerable<TSource, TPredicate> WhereRefAt<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IPredicateAt<TSource>
            => new ArraySegmentWhereRefAtEnumerable<TSource, TPredicate>(source, predicate);

        [GeneratorIgnore]
        [StructLayout(LayoutKind.Auto)]
        public readonly struct ArraySegmentWhereRefAtEnumerable<TSource, TPredicate>
            where TPredicate : struct, IPredicateAt<TSource>
        {
            internal readonly ArraySegment<TSource> source;
            internal readonly TPredicate predicate;

            internal ArraySegmentWhereRefAtEnumerable(in ArraySegment<TSource> source, TPredicate predicate)
                => (this.source, this.predicate) = (source, predicate);


            public readonly Enumerator GetEnumerator()
                => new Enumerator(in this);

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
            {
                int index;
                readonly int end;
                readonly int offset;
                readonly TSource[]? source;
                readonly TPredicate predicate;

                internal Enumerator(in ArraySegmentWhereRefAtEnumerable<TSource, TPredicate> enumerable)
                {
                    source = enumerable.source.Array;
                    predicate = enumerable.predicate;
                    offset = enumerable.source.Offset;
                    index = -1;
                    end = index + enumerable.source.Count;
                }

                public ref TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => ref source![index + offset];
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate.Invoke(source![index + offset], index))
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

