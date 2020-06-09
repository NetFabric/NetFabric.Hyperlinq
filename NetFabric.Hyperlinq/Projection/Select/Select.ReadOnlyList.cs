using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SelectEnumerable<TList, TSource, TResult> Select<TList, TSource, TResult>(
            this TList source, 
            Selector<TSource, TResult> selector)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if(selector is null) Throw.ArgumentNullException(nameof(selector));

            return new SelectEnumerable<TList, TSource, TResult>(in source, selector, 0, source.Count);
        }

        static SelectEnumerable<TList, TSource, TResult> Select<TList, TSource, TResult>(
            this TList source,
            Selector<TSource, TResult> selector,
            int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
            => new SelectEnumerable<TList, TSource, TResult>(source, selector, skipCount, takeCount);

        [GeneratorMapping("TSource", "TResult")]
        public readonly partial struct SelectEnumerable<TList, TSource, TResult>
            : IValueReadOnlyList<TResult, SelectEnumerable<TList, TSource, TResult>.DisposableEnumerator>
            , IList<TResult>
            where TList : notnull, IReadOnlyList<TSource>
        {
            readonly TList source;
            readonly Selector<TSource, TResult> selector;
            readonly int skipCount;

            internal SelectEnumerable(in TList source, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            {
                this.source = source;
                this.selector = selector;
                (this.skipCount, Count) = Utils.SkipTake(source.Count, skipCount, takeCount);
            }

            public readonly int Count { get; } 

            public readonly TResult this[int index]
            {
                get
                {
                    if (index < 0 || index >= Count)
                        Throw.ArgumentOutOfRangeException(nameof(index));

                    return selector(source[index + skipCount]);
                }
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TResult, SelectEnumerable<TList, TSource, TResult>.DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            TResult IList<TResult>.this[int index]
            {
                get => this[index];
                set => throw new NotSupportedException();
            }

            bool ICollection<TResult>.IsReadOnly  
                => true;

            void ICollection<TResult>.CopyTo(TResult[] array, int arrayIndex) 
            {
                if (skipCount == 0)
                {
                    if (arrayIndex == 0)
                    {
                        for (var index = 0; index < Count; index++)
                            array[index] = selector(source[index]);
                    }
                    else
                    {
                        for (var index = 0; index < Count; index++)
                            array[index + arrayIndex] = selector(source[index]);
                    }
                }
                else
                {
                    if (arrayIndex == 0)
                    {
                        for (var index = 0; index < Count; index++)
                            array[index] = selector(source[index + skipCount]);
                    }
                    else
                    {
                        for (var index = 0; index < Count; index++)
                            array[index + arrayIndex] = selector(source[index + skipCount]);
                    }
                }
            }
            void ICollection<TResult>.Add(TResult item) 
                => throw new NotSupportedException();
            void ICollection<TResult>.Clear() 
                => throw new NotSupportedException();
            bool ICollection<TResult>.Contains(TResult item) 
            {
                for (var index = skipCount; index < Count; index++)
                {
                    if (EqualityComparer<TResult>.Default.Equals(selector(source[index]), item))
                        return true;
                }
                return false;
            }
            bool ICollection<TResult>.Remove(TResult item) 
                => throw new NotSupportedException();
            int IList<TResult>.IndexOf(TResult item)
            {
                for (var index = skipCount; index < Count; index++)
                {
                    if (EqualityComparer<TResult>.Default.Equals(selector(source[index]), item))
                        return index - skipCount;
                }
                return -1;
            }
            void IList<TResult>.Insert(int index, TResult item)
                => throw new NotSupportedException();
            void IList<TResult>.RemoveAt(int index)
                => throw new NotSupportedException();

            public struct Enumerator
            {
                readonly TList source;
                readonly Selector<TSource, TResult> selector;
                readonly int end;
                int index;

                internal Enumerator(in SelectEnumerable<TList, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    end = enumerable.skipCount + enumerable.Count;
                    index = enumerable.skipCount - 1;
                }

                [MaybeNull]
                public readonly TResult Current
                    => selector(source[index]);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index < end;
            }

            public struct DisposableEnumerator
                : IEnumerator<TResult>
            {
                readonly TList source;
                readonly Selector<TSource, TResult> selector;
                readonly int end;
                int index;

                internal DisposableEnumerator(in SelectEnumerable<TList, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    end = enumerable.skipCount + enumerable.Count;
                    index = enumerable.skipCount - 1;
                }

                public readonly TResult Current
                    => selector(source[index]);
                readonly object? IEnumerator.Current 
                    => selector(source[index]);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index < end;

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => throw new NotSupportedException();

                public readonly void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyList.SelectEnumerable<TList, TSource, TResult> Skip(int count)
                => new ReadOnlyList.SelectEnumerable<TList, TSource, TResult>(source, selector, skipCount + count, Count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyList.SelectEnumerable<TList, TSource, TResult> Take(int count)
                => new ReadOnlyList.SelectEnumerable<TList, TSource, TResult>(source, selector, skipCount, Math.Min(Count, count));


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => Count != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TResult value, IEqualityComparer<TResult>? comparer = null)
                => ReadOnlyList.Contains<TList, TSource, TResult>(source, value, comparer, selector, skipCount, Count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyList.SelectEnumerable<TList, TSource, TSelectorResult> Select<TSelectorResult>(Selector<TResult, TSelectorResult> selector)
                => ReadOnlyList.Select<TList, TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector), skipCount, Count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyList.SelectAtEnumerable<TList, TSource, TSelectorResult> Select<TSelectorResult>(SelectorAt<TResult, TSelectorResult> selector)
                => ReadOnlyList.Select<TList, TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector), skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => ReadOnlyList.ElementAt<TList, TSource, TResult>(source, index, selector, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => ReadOnlyList.First<TList, TSource, TResult>(source, selector, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => ReadOnlyList.Single<TList, TSource, TResult>(source, selector, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult[] ToArray()
                => ReadOnlyList.ToArray<TList, TSource, TResult>(source, selector, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TResult> ToList()
                => ReadOnlyList.ToList<TList, TSource, TResult>(source, selector, skipCount, Count);

            public Dictionary<TKey, TResult> ToDictionary<TKey>(Selector<TResult, TKey> keySelector, IEqualityComparer<TKey>? comparer = null)
                => ToDictionary<TKey>(keySelector, comparer);

            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TResult, TKey> keySelector, Selector<TResult, TElement> elementSelector, IEqualityComparer<TKey>? comparer = null)
                => ToDictionary<TKey, TElement>(keySelector, elementSelector, comparer);

            public readonly bool SequenceEqual(IEnumerable<TResult> other, IEqualityComparer<TResult>? comparer = null)
            {
                comparer ??= EqualityComparer<TResult>.Default;

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
        public static int Count<TList, TSource, TResult>(this SelectEnumerable<TList, TSource, TResult> source)
            where TList : notnull, IReadOnlyList<TSource>
            => source.Count;
    }
}

