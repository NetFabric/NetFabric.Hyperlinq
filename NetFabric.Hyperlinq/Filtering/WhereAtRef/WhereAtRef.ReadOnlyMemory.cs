﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [GeneratorMapping("TPredicate", "NetFabric.Hyperlinq.FunctionInWrapper<TSource, int, bool>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ReadOnlyMemoryWhereAtRefEnumerable<TSource, FunctionInWrapper<TSource, int, bool>> Where<TSource>(this ReadOnlyMemory<TSource> source, FunctionIn<TSource, int, bool> predicate)
            => source.WhereAtRef(new FunctionInWrapper<TSource, int, bool>(predicate));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ReadOnlyMemoryWhereAtRefEnumerable<TSource, TPredicate> WhereAtRef<TSource, TPredicate>(this ReadOnlyMemory<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
            => new(source, predicate);

        [GeneratorIgnore]
        [StructLayout(LayoutKind.Auto)]
        public readonly struct ReadOnlyMemoryWhereAtRefEnumerable<TSource, TPredicate>
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
        {
            internal readonly ReadOnlyMemory<TSource> source;
            internal readonly TPredicate predicate;

            internal ReadOnlyMemoryWhereAtRefEnumerable(ReadOnlyMemory<TSource> source, TPredicate predicate)
                => (this.source, this.predicate) = (source, predicate);

            public readonly WhereAtReadOnlyRefEnumerator<TSource, TPredicate> GetEnumerator()
                => new (source.Span, predicate);

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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TPredicate>(this ReadOnlyMemoryWhereAtRefEnumerable<int, TPredicate> source)
            where TPredicate : struct, IFunctionIn<int, int, bool>
            => source.source.Span.SumAtRef<int, int, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TPredicate>(this ReadOnlyMemoryWhereAtRefEnumerable<int?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<int?, int, bool>
            => source.source.Span.SumAtRef<int?, int, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TPredicate>(this ReadOnlyMemoryWhereAtRefEnumerable<long, TPredicate> source)
            where TPredicate : struct, IFunctionIn<long, int, bool>
            => source.source.Span.SumAtRef<long, long, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TPredicate>(this ReadOnlyMemoryWhereAtRefEnumerable<long?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<long?, int, bool>
            => source.source.Span.SumAtRef<long?, long, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TPredicate>(this ReadOnlyMemoryWhereAtRefEnumerable<float, TPredicate> source)
            where TPredicate : struct, IFunctionIn<float, int, bool>
            => source.source.Span.SumAtRef<float, float, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TPredicate>(this ReadOnlyMemoryWhereAtRefEnumerable<float?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<float?, int, bool>
            => source.source.Span.SumAtRef<float?, float, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TPredicate>(this ReadOnlyMemoryWhereAtRefEnumerable<double, TPredicate> source)
            where TPredicate : struct, IFunctionIn<double, int, bool>
            => source.source.Span.SumAtRef<double, double, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TPredicate>(this ReadOnlyMemoryWhereAtRefEnumerable<double?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<double?, int, bool>
            => source.source.Span.SumAtRef<double?, double, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TPredicate>(this ReadOnlyMemoryWhereAtRefEnumerable<decimal, TPredicate> source)
            where TPredicate : struct, IFunctionIn<decimal, int, bool>
            => source.source.Span.SumAtRef<decimal, decimal, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TPredicate>(this ReadOnlyMemoryWhereAtRefEnumerable<decimal?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<decimal?, int, bool>
            => source.source.Span.SumAtRef<decimal?, decimal, TPredicate>(source.predicate);
    }
}
