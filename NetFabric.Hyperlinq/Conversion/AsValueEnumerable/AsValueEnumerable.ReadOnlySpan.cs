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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanValueEnumerable<TSource> AsValueEnumerable<TSource>(this ReadOnlySpan<TSource> source)
            => new(source);

        [GeneratorIgnore]
        [StructLayout(LayoutKind.Auto)]
        public readonly ref struct SpanValueEnumerable<TSource>
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

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlySpan<TSource> ToArray()
                => source.ToArray();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IMemoryOwner<TSource> ToArray(MemoryPool<TSource> memoryPool)
                => source.ToArray(memoryPool);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => source.ToList();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => source.ToDictionary(keySelector, comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                => source.ToDictionary(keySelector, comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => source.ToDictionary(keySelector, elementSelector, comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                where TElementSelector : struct, IFunction<TSource, TElement>
                => source.ToDictionary<TSource, TKey, TElement, TKeySelector, TElementSelector>(keySelector, elementSelector, comparer);

            #endregion

            #region Element

            public Option<TSource> ElementAt(int index)
                => source.ElementAt(index);

            public Option<TSource> First()
                => source.First();

            public Option<TSource> Single()
                => source.Single();

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
                var (skipCount, takeCount) = Utils.Skip(source.Length, count);
                return new SpanValueEnumerable<TSource>(source.Slice(skipCount, takeCount));
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanValueEnumerable<TSource> Take(int count)
                => new(source.Slice(0, Utils.Take(source.Length, count)));

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

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, bool> predicate)
                => All(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunction<TSource, bool>
                => source.All(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, int, bool> predicate)
                => source.All(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AllAt<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunction<TSource, int, bool>
                => source.AllAt(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Any();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, bool> predicate)
                => source.Any(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunction<TSource, bool>
                => source.Any(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, int, bool> predicate)
                => source.Any(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AnyAt<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunction<TSource, int, bool>
                => source.AnyAt(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer = null)
                => source.Contains(value, comparer);

            #endregion

            #region Set

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanDistinctEnumerable<TSource> Distinct(IEqualityComparer<TSource>? comparer = default)
                => source.Distinct(comparer);

            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count(this SpanValueEnumerable<int> source)
            => source.source.Count();

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