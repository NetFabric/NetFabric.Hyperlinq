using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpanWhereRefEnumerable<TSource, ValuePredicate<TSource>> WhereRef<TSource>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate) 
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return WhereRef(source, new ValuePredicate<TSource>(predicate));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpanWhereRefEnumerable<TSource, TPredicate> WhereRef<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IPredicate<TSource>
            => new ReadOnlySpanWhereRefEnumerable<TSource, TPredicate>(source, predicate);

        [GeneratorIgnore]
        [StructLayout(LayoutKind.Auto)]
        public readonly ref struct ReadOnlySpanWhereRefEnumerable<TSource, TPredicate>
            where TPredicate : struct, IPredicate<TSource>
        {
            internal readonly ReadOnlySpan<TSource> source;
            internal readonly TPredicate predicate;

            internal ReadOnlySpanWhereRefEnumerable(ReadOnlySpan<TSource> source, TPredicate predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            public readonly Enumerator GetEnumerator()
                => new Enumerator(in this);

            [StructLayout(LayoutKind.Sequential)]
            public ref struct Enumerator
            {
                int index;
                readonly int end;
                readonly ReadOnlySpan<TSource> source;
                readonly TPredicate predicate;

                internal Enumerator(in ReadOnlySpanWhereRefEnumerable<TSource, TPredicate> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    index = -1;
                    end = index + source.Length;
                }

                public readonly ref readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => ref source[index];
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate.Invoke(source[index]))
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

