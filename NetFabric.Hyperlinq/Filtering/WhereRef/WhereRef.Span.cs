using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [GeneratorMapping("TPredicate", "NetFabric.Hyperlinq.FunctionWrapper<TSource, bool>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanWhereRefEnumerable<TSource, FunctionWrapper<TSource, bool>> WhereRef<TSource>(this in Span<TSource> source, Func<TSource, bool> predicate)
            => new(source, new FunctionWrapper<TSource, bool>(predicate));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanWhereRefEnumerable<TSource, TPredicate> WhereRef<TSource, TPredicate>(this in Span<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, bool>
            => new(source, predicate);

        [GeneratorIgnore]
        [StructLayout(LayoutKind.Auto)]
        public readonly ref struct SpanWhereRefEnumerable<TSource, TPredicate>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            readonly Span<TSource> source;
            readonly TPredicate predicate;

            internal SpanWhereRefEnumerable(Span<TSource> source, TPredicate predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            public readonly Enumerator GetEnumerator()
                => new (in this);

            [StructLayout(LayoutKind.Sequential)]
            public ref struct Enumerator
            {
                int index;
                readonly Span<TSource> source;
                TPredicate predicate;

                internal Enumerator(in SpanWhereRefEnumerable<TSource, TPredicate> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    index = -1;
                }

                public readonly ref readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => ref source[index];
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (++index < source.Length)
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

