using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpanWhereRefAtEnumerable<TSource, ValuePredicateAt<TSource>> WhereRef<TSource>(this ReadOnlySpan<TSource> source, PredicateAt<TSource> predicate) 
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return WhereRefAt(source, new ValuePredicateAt<TSource>(predicate));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpanWhereRefAtEnumerable<TSource, TPredicate> WhereRefAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IPredicateAt<TSource>
            => new ReadOnlySpanWhereRefAtEnumerable<TSource, TPredicate>(source, predicate);

        [GeneratorIgnore]
        [StructLayout(LayoutKind.Auto)]
        public readonly ref struct ReadOnlySpanWhereRefAtEnumerable<TSource, TPredicate>
            where TPredicate : struct, IPredicateAt<TSource>
        {
            internal readonly ReadOnlySpan<TSource> source;
            internal readonly TPredicate predicate;

            internal ReadOnlySpanWhereRefAtEnumerable(ReadOnlySpan<TSource> source, TPredicate predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }


            public readonly Enumerator GetEnumerator() => new Enumerator(in this);

            [StructLayout(LayoutKind.Sequential)]
            public ref struct Enumerator
            {
                int index;
                readonly int end;
                readonly ReadOnlySpan<TSource> source;
                readonly TPredicate predicate;

                internal Enumerator(in ReadOnlySpanWhereRefAtEnumerable<TSource, TPredicate> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    index = -1;
                    end = index + source.Length;
                }

                public readonly TSource Current
                    => source[index];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate.Invoke(source[index], index))
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

