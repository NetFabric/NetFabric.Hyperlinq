using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        public static WhereEnumerable<TSource> Where<TSource>(this TSource[] source, Func<TSource, bool> predicate) 
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return new WhereEnumerable<TSource>(source, predicate, 0, source.Length);
        }

        [Pure]
        static WhereEnumerable<TSource> Where<TSource>(this TSource[] source, Func<TSource, bool> predicate, int skipCount, int takeCount)
            => new WhereEnumerable<TSource>(source, predicate, skipCount, takeCount);

        [GenericsTypeMapping("TEnumerable", typeof(WhereEnumerable<>))]
        [GenericsTypeMapping("TEnumerator", typeof(WhereEnumerable<>.Enumerator))]
        public readonly struct WhereEnumerable<TSource>
            : IValueEnumerable<TSource, WhereEnumerable<TSource>.Enumerator>
        {
            readonly TSource[] source;
            readonly Func<TSource, bool> predicate;
            readonly int skipCount;
            readonly int takeCount;

            internal WhereEnumerable(TSource[] source, Func<TSource, bool> predicate, int skipCount, int takeCount)
            {
                this.source = source;
                this.predicate = predicate;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Length, skipCount, takeCount);
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator 
                : IEnumerator<TSource>
            {
                readonly TSource[] source;
                readonly Func<TSource, bool> predicate;
                readonly int end;
                int index;

                internal Enumerator(in WhereEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                public readonly ref readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => ref source[index];
                }
                readonly TSource IEnumerator<TSource>.Current => source[index];
                readonly object IEnumerator.Current => source[index];

                public bool MoveNext()
                {
                    while (++index < end)
                    {
                        if (predicate(source[index]))
                            return true;
                    }
                    return false;
                }

                public readonly void Reset() => throw new NotSupportedException();

                public readonly void Dispose() { }
            }

            public int Count()
                => Array.Count<TSource>(source, predicate, skipCount, takeCount);
            public int Count(Func<TSource, bool> predicate)
                => Array.Count<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);
            public int Count(Func<TSource, int, bool> predicate)
                => Array.Count<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);

            public long LongCount()
                => Array.LongCount<TSource>(source, predicate);
            public long LongCount(Func<TSource, bool> predicate)
                => Array.LongCount<TSource>(source, Utils.CombinePredicates(this.predicate, predicate));

            public bool Any()
                => Array.Any<TSource>(source, predicate, skipCount, takeCount);
            public bool Any(Func<TSource, bool> predicate)
                => Array.Any<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);
            public bool Any(Func<TSource, int, bool> predicate)
                => Array.Any<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);

            public Array.WhereSelectEnumerable<TSource, TResult> Select<TResult>(Func<TSource, TResult> selector)
                => Array.WhereSelect<TSource, TResult>(source, predicate, selector);

            public Array.WhereEnumerable<TSource> Where(Func<TSource, bool> predicate)
                => Array.Where<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);
            public Array.WhereIndexEnumerable<TSource> Where(Func<TSource, int, bool> predicate)
                => Array.Where<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);

            public ref readonly TSource First()
                => ref Array.First<TSource>(source, predicate, skipCount, takeCount);
            public ref readonly TSource First(Func<TSource, bool> predicate)
                => ref Array.First<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);
            public ref readonly TSource First(Func<TSource, int, bool> predicate)
                => ref Array.First<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);

            public ref readonly TSource FirstOrDefault()
                => ref Array.FirstOrDefault<TSource>(source, predicate, skipCount, takeCount);
            public ref readonly TSource FirstOrDefault(Func<TSource, bool> predicate)
                => ref Array.FirstOrDefault<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);
            public ref readonly TSource FirstOrDefault(Func<TSource, int, bool> predicate)
                => ref Array.FirstOrDefault<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);

            public ref readonly TSource Single()
                => ref Array.Single<TSource>(source, predicate, skipCount, takeCount);
            public ref readonly TSource Single(Func<TSource, bool> predicate)
                => ref Array.Single<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);
            public ref readonly TSource Single(Func<TSource, int, bool> predicate)
                => ref Array.Single<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);

            public ref readonly TSource SingleOrDefault()
                => ref Array.SingleOrDefault<TSource>(source, predicate, skipCount, takeCount);
            public ref readonly TSource SingleOrDefault(Func<TSource, bool> predicate)
                => ref Array.SingleOrDefault<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);
            public ref readonly TSource SingleOrDefault(Func<TSource, int, bool> predicate)
                => ref Array.SingleOrDefault<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);

            public List<TSource> ToList()
                => Array.ToList<TSource>(source, predicate, skipCount, takeCount);

            public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector)
                => Array.ToDictionary<TSource, TKey>(source, keySelector, EqualityComparer<TKey>.Default, predicate, skipCount, takeCount);
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
                => Array.ToDictionary<TSource, TKey>(source, keySelector, comparer, predicate, skipCount, takeCount);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
                => Array.ToDictionary<TSource, TKey, TElement>(source, keySelector, elementSelector, EqualityComparer<TKey>.Default, predicate, skipCount, takeCount);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
                => Array.ToDictionary<TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, predicate, skipCount, takeCount);

            public void ForEach(Action<TSource> action)
            {
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    if (predicate(source[index]))
                        action(source[index]);
                }
            }
            public void ForEach(Action<TSource, int> action)
            {
                var actionIndex = 0;
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    if (predicate(source[index]))
                        action(source[index], actionIndex++);
                }
            }
        }
    }
}

