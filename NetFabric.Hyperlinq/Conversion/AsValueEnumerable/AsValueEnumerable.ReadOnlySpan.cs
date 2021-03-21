using System;
using System.Buffers;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanValueEnumerable<TSource> AsValueEnumerable<TSource>(this ReadOnlySpan<TSource> source)
            => new(source);

        [GeneratorBindings(source: "source", sourceImplements: "ReadOnlySpan`1")]
        [StructLayout(LayoutKind.Auto)]
        public readonly ref partial struct SpanValueEnumerable<TSource>
        {
            internal readonly ReadOnlySpan<TSource> source;

            internal SpanValueEnumerable(ReadOnlySpan<TSource> source)
                => this.source = source;

            public readonly int Count
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source.Length;
            }

            public readonly TSource this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly SpanEnumerator<TSource> GetEnumerator()
                => new(source);

            #region Aggregation

            #endregion

            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanValueEnumerable<TSource> AsEnumerable()
                => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanValueEnumerable<TSource> AsValueEnumerable()
                => this;

            #endregion

            #region Element

            #endregion
            
            #region Filtering

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanWhereEnumerable<TSource, FunctionWrapper<TSource, bool>> Where(Func<TSource, bool> predicate)
                => source.Where(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanWhereEnumerable<TSource, TPredicate> Where<TPredicate>(TPredicate predicate = default)
                where TPredicate : struct, IFunction<TSource, bool>
                => source.Where(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanWhereAtEnumerable<TSource, FunctionWrapper<TSource, int, bool>> Where(Func<TSource, int, bool> predicate)
                => source.Where(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanWhereAtEnumerable<TSource, TPredicate> WhereAt<TPredicate>(TPredicate predicate = default)
                where TPredicate : struct, IFunction<TSource, int, bool>
                => source.WhereAt(predicate);

            #endregion
             
            #region Partitioning

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanValueEnumerable<TSource> Skip(int count)
            {
                var (skipCount, takeCount) = Partition.Skip(source.Length, count);
                return new SpanValueEnumerable<TSource>(source.Slice(skipCount, takeCount));
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanValueEnumerable<TSource> Take(int count)
                => new(source.Slice(0, Partition.Take(source.Length, count)));

            #endregion

            #region Projection

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanSelectEnumerable<TSource, TResult, FunctionWrapper<TSource, TResult>> Select<TResult>(Func<TSource, TResult> selector)
                => source.Select(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanSelectEnumerable<TSource, TResult, TSelector> Select<TResult, TSelector>(TSelector selector = default)
                where TSelector : struct, IFunction<TSource, TResult>
                => source.Select<TSource, TResult, TSelector>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanSelectAtEnumerable<TSource, TResult, FunctionWrapper<TSource, int, TResult>> Select<TResult>(Func<TSource, int, TResult> selector)
                => source.Select(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanSelectAtEnumerable<TSource, TResult, TSelector> SelectAt<TResult, TSelector>(TSelector selector = default)
                where TSelector : struct, IFunction<TSource, int, TResult>
                => source.SelectAt<TSource, TResult, TSelector>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, FunctionWrapper<TSource, TSubEnumerable>> SelectMany<TSubEnumerable, TSubEnumerator, TResult>(Func<TSource, TSubEnumerable> selector)
                where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
                where TSubEnumerator : struct, IEnumerator<TResult>
                => source.SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector> SelectMany<TSubEnumerable, TSubEnumerator, TResult, TSelector>(TSelector selector = default)
                where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
                where TSubEnumerator : struct, IEnumerator<TResult>
                where TSelector : struct, IFunction<TSource, TSubEnumerable>
                => source.SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>(selector);

            #endregion

            #region Quantifier

            #endregion

            #region Set

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanDistinctEnumerable<TSource> Distinct(IEqualityComparer<TSource>? comparer = default)
                => source.Distinct(comparer);

            #endregion

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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this SpanValueEnumerable<TSource> source)
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this SpanValueEnumerable<int> source)
            => source.source.Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this SpanValueEnumerable<int?> source)
            => source.source.Sum<int?, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this SpanValueEnumerable<long> source)
            => source.source.Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this SpanValueEnumerable<long?> source)
            => source.source.Sum<long?, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this SpanValueEnumerable<float> source)
            => source.source.Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this SpanValueEnumerable<float?> source)
            => source.source.Sum<float?, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this SpanValueEnumerable<double> source)
            => source.source.Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this SpanValueEnumerable<double?> source)
            => source.source.Sum<double?, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this SpanValueEnumerable<decimal> source)
            => source.source.Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this SpanValueEnumerable<decimal?> source)
            => source.source.Sum<decimal?, decimal>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsVector<TSource>(this SpanValueEnumerable<TSource> source, TSource value)
            where TSource : struct
            => source.source.ContainsVector(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanSelectVectorContext<TSource, TResult, FunctionWrapper<Vector<TSource>, Vector<TResult>>, FunctionWrapper<TSource, TResult>> SelectVector<TSource, TResult>(this SpanValueEnumerable<TSource> source, Func<Vector<TSource>, Vector<TResult>> vectorSelector, Func<TSource, TResult> selector)
            where TSource : struct
            where TResult : struct
            => source.source.SelectVector(vectorSelector, selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanSelectVectorContext<TSource, TResult, TVectorSelector, TSelector> SelectVector<TSource, TResult, TVectorSelector, TSelector>(this SpanValueEnumerable<TSource> source, TVectorSelector vectorSelector = default, TSelector selector = default)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
            => source.source.SelectVector<TSource, TResult, TVectorSelector, TSelector>(vectorSelector, selector);
    }
}