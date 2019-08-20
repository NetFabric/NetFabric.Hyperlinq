using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static class QueueBindings
    {
        [Pure]
        public static int Count<TSource>(this Queue<TSource> source)
            => source.Count;
        [Pure]
        public static int Count<TSource>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.Count<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static int Count<TSource>(this Queue<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollection.Count<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource> Skip<TSource>(this Queue<TSource> source, int count)
            => ValueReadOnlyCollection.Skip<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        [Pure]
        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource> Take<TSource>(this Queue<TSource> source, int count)
            => ValueReadOnlyCollection.Take<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        [Pure]
        public static bool All<TSource>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static bool All<TSource>(this Queue<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static bool Any<TSource>(this Queue<TSource> source)
            => source.Count != 0;
        [Pure]
        public static bool Any<TSource>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static bool Any<TSource>(this Queue<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static bool Contains<TSource>(this Queue<TSource> source, TSource value)
            => source.Contains(value);

        [Pure]
        public static bool Contains<TSource>(this Queue<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            => ValueReadOnlyCollection.Contains<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), value, comparer);

        [Pure]
        public static ValueReadOnlyCollection.SelectEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this Queue<TSource> source,
            Func<TSource, TResult> selector) 
            => ValueReadOnlyCollection.Select<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);
        [Pure]
        public static ValueReadOnlyCollection.SelectIndexEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this Queue<TSource> source,
            Func<TSource, int, TResult> selector)
            => ValueReadOnlyCollection.Select<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);

        [Pure]
        public static ValueEnumerable.SelectManyEnumerable<ValueWrapper<TSource>,  ValueWrapper<TSource>.Enumerator,  TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this Queue<TSource> source,
            Func<TSource, TSubEnumerable> selector) 
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
            => ValueEnumerable.SelectMany<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TSource>(source), selector);

        [Pure]
        public static ValueEnumerable.WhereEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource> Where<TSource>(
            this Queue<TSource> source,
            Func<TSource, bool> predicate) 
            => ValueEnumerable.Where<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static ValueEnumerable.WhereIndexEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource> Where<TSource>(
            this Queue<TSource> source,
            Func<TSource, int, bool> predicate)
            => ValueEnumerable.Where<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static TSource First<TSource>(this Queue<TSource> source) 
            => ValueReadOnlyCollection.First<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        public static TSource First<TSource>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.First<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static TSource FirstOrDefault<TSource>(this Queue<TSource> source)
            => ValueReadOnlyCollection.FirstOrDefault<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        public static TSource FirstOrDefault<TSource>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.FirstOrDefault<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static (ElementResult Success, TSource Value) TryFirst<TSource>(this Queue<TSource> source)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        public static (ElementResult Success, TSource Value) TryFirst<TSource>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static (int Index, TSource Value) TryFirst<TSource>(this Queue<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static TSource Single<TSource>(this Queue<TSource> source) 
            => ValueReadOnlyCollection.Single<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        public static TSource Single<TSource>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.Single<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static TSource SingleOrDefault<TSource>(this Queue<TSource> source)
            => ValueReadOnlyCollection.SingleOrDefault<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        public static TSource SingleOrDefault<TSource>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.SingleOrDefault<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static (ElementResult Success, TSource Value) TrySingle<TSource>(this Queue<TSource> source)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        public static (ElementResult Success, TSource Value) TrySingle<TSource>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static (int Index, TSource Value) TrySingle<TSource>(this Queue<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static ValueEnumerable.DistinctEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource> Distinct<TSource>(this Queue<TSource> source, IEqualityComparer<TSource> comparer = null)
            => ValueEnumerable.Distinct<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), comparer);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Queue<TSource> AsEnumerable<TSource>(this Queue<TSource> source)
            => source;

        [Pure]
        public static ValueWrapper<TSource> AsValueEnumerable<TSource>(this Queue<TSource> source)
            => new ValueWrapper<TSource>(source);

        [Pure]
        public static TSource[] ToArray<TSource>(this Queue<TSource> source)
            => ValueReadOnlyCollection.ToArray<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        [Pure]
        public static List<TSource> ToList<TSource>(this Queue<TSource> source)
            => ValueReadOnlyCollection.ToList<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        [Pure]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this Queue<TSource> source, Func<TSource, TKey> keySelector)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TKey>(new ValueWrapper<TSource>(source), keySelector);
        [Pure]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this Queue<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TKey>(new ValueWrapper<TSource>(source), keySelector, comparer);
        [Pure]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this Queue<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TKey, TElement>(new ValueWrapper<TSource>(source), keySelector, elementSelector);
        [Pure]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this Queue<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TKey, TElement>(new ValueWrapper<TSource>(source), keySelector, elementSelector, comparer);

        public readonly struct ValueWrapper<TSource> 
            : IValueReadOnlyCollection<TSource, ValueWrapper<TSource>.Enumerator>
        {
            readonly Queue<TSource> source;

            public ValueWrapper(Queue<TSource> source)
            {
                this.source = source;
            }

            public readonly int Count => source.Count;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueWrapper<TSource>.Enumerator GetEnumerator() => new Enumerator(source);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();

            public struct Enumerator
                : IValueEnumerator<TSource>
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                Queue<TSource>.Enumerator enumerator;

                internal Enumerator(Queue<TSource> enumerable)
                {
                    enumerator = enumerable.GetEnumerator();
                }

                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => enumerator.Current;
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() => enumerator.MoveNext();
            }
        }
    }
}