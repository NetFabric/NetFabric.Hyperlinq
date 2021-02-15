using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [GeneratorMapping("TPredicate", "NetFabric.Hyperlinq.FunctionInWrapper<TSource, int, bool>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanWhereAtRefEnumerable<TSource, FunctionInWrapper<TSource, int, bool>> Where<TSource>(this Span<TSource> source, FunctionIn<TSource, int, bool> predicate)
            => source.WhereAtRef(new FunctionInWrapper<TSource, int, bool>(predicate));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanWhereAtRefEnumerable<TSource, TPredicate> WhereAtRef<TSource, TPredicate>(this Span<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
            => new(source, predicate);

        [GeneratorIgnore]
        [StructLayout(LayoutKind.Auto)]
        public readonly ref struct SpanWhereAtRefEnumerable<TSource, TPredicate>
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
        {
            readonly Span<TSource> source;
            readonly TPredicate predicate;

            internal SpanWhereAtRefEnumerable(Span<TSource> source, TPredicate predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            public readonly WhereAtRefEnumerator<TSource, TPredicate> GetEnumerator() 
                => new(source, predicate);

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

