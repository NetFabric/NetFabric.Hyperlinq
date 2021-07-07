using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static MemoryWhereEnumerable<TSource, FunctionWrapper<TSource, bool>> Where<TSource>(this ReadOnlyMemory<TSource> source, Func<TSource, bool> predicate) 
            => source.Where(new FunctionWrapper<TSource, bool>(predicate));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static MemoryWhereEnumerable<TSource, TPredicate> Where<TSource, TPredicate>(this ReadOnlyMemory<TSource> source, TPredicate predicate = default) 
            where TPredicate : struct, IFunction<TSource, bool>
            => new(source, predicate);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct MemoryWhereEnumerable<TSource, TPredicate>
            : IValueEnumerable<TSource, MemoryWhereEnumerable<TSource, TPredicate>.Enumerator>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            internal readonly ReadOnlyMemory<TSource> source;
            internal readonly TPredicate predicate;

            internal MemoryWhereEnumerable(ReadOnlyMemory<TSource> source, TPredicate predicate)
                => (this.source, this.predicate) = (source, predicate);

            public WhereEnumerator<TSource, TPredicate> GetEnumerator() 
                => new(source.Span, predicate);

            Enumerator IValueEnumerable<TSource, Enumerator>.GetEnumerator() 
                => new(in this);

            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);

            IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator 
                : IEnumerator<TSource>
            {
                readonly ReadOnlyMemory<TSource> source;
#pragma warning disable IDE0044 // Add readonly modifier
                TPredicate predicate;
#pragma warning restore IDE0044 // Add readonly modifier
                int index;

                internal Enumerator(in MemoryWhereEnumerable<TSource, TPredicate> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    index = -1;
                }

                public readonly TSource Current 
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source.Span[index];
                }
                readonly TSource IEnumerator<TSource>.Current 
                    => source.Span[index];
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => source.Span[index];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    var span = source.Span;
                    var index = this.index;
                    while (++index < span.Length)
                    {
                        var item = span[index];
                        if (predicate.Invoke(item))
                        {
                            this.index = index;
                            return true;
                        }
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => throw new NotSupportedException();

                public readonly void Dispose() { }
            }

            #region Aggregation

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count()
                => source.Span.Count(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count(Func<TSource, bool> predicate)
                => Count(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => source.Span.Count(new PredicatePredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count(Func<TSource, int, bool> predicate)
                => CountAt(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int CountAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => source.Span.CountAt(new PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            #endregion
            #region Quantifier


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All()
                => source.Span.All(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, bool> predicate)
                => All(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => source.Span.All(new PredicatePredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, int, bool> predicate)
                => AllAt(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AllAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => source.Span.AllAt(new PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Span.Any(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, bool> predicate)
                => Any(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => source.Span.Any(new PredicatePredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, int, bool> predicate)
                => AnyAt(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AnyAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => source.Span.AnyAt(new PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            #endregion
            #region Filtering

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MemoryWhereEnumerable<TSource, PredicatePredicateCombination<TPredicate, FunctionWrapper<TSource, bool>, TSource>> Where(Func<TSource, bool> predicate)
                => Where(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MemoryWhereEnumerable<TSource, PredicatePredicateCombination<TPredicate, TPredicate2, TSource>> Where<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => source.Where(new PredicatePredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MemoryWhereAtEnumerable<TSource, PredicatePredicateAtCombination<TPredicate, FunctionWrapper<TSource, int, bool>, TSource>> Where(Func<TSource, int, bool> predicate)
                => WhereAt(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MemoryWhereAtEnumerable<TSource, PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>> WhereAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => source.WhereAt(new PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));
            
            #endregion
            #region Projection

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MemoryWhereSelectEnumerable<TSource, TResult, TPredicate, FunctionWrapper<TSource, TResult>> Select<TResult>(Func<TSource, TResult> selector)
                => Select<TResult, FunctionWrapper<TSource, TResult>>(new FunctionWrapper<TSource, TResult>(selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MemoryWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector> Select<TResult, TSelector>(TSelector selector = default)
                where TSelector : struct, IFunction<TSource, TResult>
                => source.WhereSelect<TSource, TResult, TPredicate, TSelector>(predicate, selector);
            
            #endregion
            #region Element

            public Option<TSource> ElementAt(int index)
                => source.Span.ElementAt(index, predicate);

            public Option<TSource> First()
                => source.Span.First(predicate);

            public Option<TSource> Single()
                => source.Span.Single(predicate);
            
            #endregion
            #region Conversion

            public TSource[] ToArray()
                => source.Span.ToArray(predicate);

            public Lease<TSource> ToArray(ArrayPool<TSource> pool, bool clearOnDispose = default)
                => source.Span.ToArray(pool, clearOnDispose, predicate);

            public List<TSource> ToList()
                => source.Span.ToList(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ToDictionary(new FunctionWrapper<TSource, TKey>(keySelector), comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                => source.Span.ToDictionary(keySelector, comparer, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ToDictionary<TKey, TElement, FunctionWrapper<TSource, TKey>, FunctionWrapper<TSource, TElement>>(new FunctionWrapper<TSource, TKey>(keySelector), new FunctionWrapper<TSource, TElement>(elementSelector), comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                where TElementSelector : struct, IFunction<TSource, TElement>
                => source.Span.ToDictionary<TSource, TKey, TElement, TKeySelector, TElementSelector, TPredicate>(keySelector, elementSelector, comparer, predicate);
            
            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TPredicate>(this MemoryWhereEnumerable<int, TPredicate> source)
            where TPredicate : struct, IFunction<int, bool>
            => source.source.Span.Sum<int, int, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TPredicate>(this MemoryWhereEnumerable<int?, TPredicate> source)
            where TPredicate : struct, IFunction<int?, bool>
            => source.source.Span.Sum<int?, int, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TPredicate>(this MemoryWhereEnumerable<nint, TPredicate> source)
            where TPredicate : struct, IFunction<nint, bool>
            => source.source.Span.Sum<nint, nint, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TPredicate>(this MemoryWhereEnumerable<nint?, TPredicate> source)
            where TPredicate : struct, IFunction<nint?, bool>
            => source.source.Span.Sum<nint?, nint, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TPredicate>(this MemoryWhereEnumerable<nuint, TPredicate> source)
            where TPredicate : struct, IFunction<nuint, bool>
            => source.source.Span.Sum<nuint, nuint, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TPredicate>(this MemoryWhereEnumerable<nuint?, TPredicate> source)
            where TPredicate : struct, IFunction<nuint?, bool>
            => source.source.Span.Sum<nuint?, nuint, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TPredicate>(this MemoryWhereEnumerable<long, TPredicate> source)
            where TPredicate : struct, IFunction<long, bool>
            => source.source.Span.Sum<long, long, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TPredicate>(this MemoryWhereEnumerable<long?, TPredicate> source)
            where TPredicate : struct, IFunction<long?, bool>
            => source.source.Span.Sum<long?, long, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TPredicate>(this MemoryWhereEnumerable<float, TPredicate> source)
            where TPredicate : struct, IFunction<float, bool>
            => source.source.Span.Sum<float, float, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TPredicate>(this MemoryWhereEnumerable<float?, TPredicate> source)
            where TPredicate : struct, IFunction<float?, bool>
            => source.source.Span.Sum<float?, float, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TPredicate>(this MemoryWhereEnumerable<double, TPredicate> source)
            where TPredicate : struct, IFunction<double, bool>
            => source.source.Span.Sum<double, double, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TPredicate>(this MemoryWhereEnumerable<double?, TPredicate> source)
            where TPredicate : struct, IFunction<double?, bool>
            => source.source.Span.Sum<double?, double, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TPredicate>(this MemoryWhereEnumerable<decimal, TPredicate> source)
            where TPredicate : struct, IFunction<decimal, bool>
            => source.source.Span.Sum<decimal, decimal, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TPredicate>(this MemoryWhereEnumerable<decimal?, TPredicate> source)
            where TPredicate : struct, IFunction<decimal?, bool>
            => source.source.Span.Sum<decimal?, decimal, TPredicate>(source.predicate);
    }
}

