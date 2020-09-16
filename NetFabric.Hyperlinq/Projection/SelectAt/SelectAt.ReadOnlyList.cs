using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SelectAtEnumerable<TList, TSource, TResult> Select<TList, TSource, TResult>(
            this TList source, 
            NullableSelectorAt<TSource, TResult> selector)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (selector is null) Throw.ArgumentNullException(nameof(selector));

            return new SelectAtEnumerable<TList, TSource, TResult>(in source, selector, 0, source.Count);
        }


        static SelectAtEnumerable<TList, TSource, TResult> Select<TList, TSource, TResult>(
            this TList source,
            NullableSelectorAt<TSource, TResult> selector,
            int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            => new SelectAtEnumerable<TList, TSource, TResult>(source, selector, offset, count);

        [GeneratorMapping("TSource", "TResult")]
        [GeneratorMapping("TResult", "TResult2")]
        [StructLayout(LayoutKind.Sequential)]
        public readonly partial struct SelectAtEnumerable<TList, TSource, TResult>
            : IValueReadOnlyList<TResult, SelectAtEnumerable<TList, TSource, TResult>.DisposableEnumerator>
            , IList<TResult>
            where TList : notnull, IReadOnlyList<TSource>
        {
            readonly int offset;
            readonly TList source;
            readonly NullableSelectorAt<TSource, TResult> selector;

            internal SelectAtEnumerable(in TList source, NullableSelectorAt<TSource, TResult> selector, int offset, int count)
            {
                this.source = source;
                this.selector = selector;
                (this.offset, Count) = Utils.SkipTake(source.Count, offset, count);
            }

            public readonly int Count { get; }

            [MaybeNull]
            public readonly TResult this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    if (index < 0 || index >= Count) Throw.IndexOutOfRangeException();

                    return selector(source[index + offset], index);
                }
            }
            TResult IReadOnlyList<TResult>.this[int index]
                => this[index]!;
            TResult IList<TResult>.this[int index]
            {
                get => this[index]!;
                [ExcludeFromCodeCoverage]
                set => Throw.NotSupportedException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TResult, SelectAtEnumerable<TList, TSource, TResult>.DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            bool ICollection<TResult>.IsReadOnly  
                => true;

            public void CopyTo(TResult[] array) 
            {
                var end = Count - 1;
                if (offset == 0)
                {
                    for (var index = 0; index <= end; index++)
                        array[index] = selector(source[index], index)!;
                }
                else
                {
                    for (var index = 0; index <= end; index++)
                        array[index] = selector(source[index + offset], index)!;
                }
            }

            public void CopyTo(TResult[] array, int arrayIndex)
            {
                if (arrayIndex == 0)
                {
                    CopyTo(array);
                }
                else
                {
                    var end = Count - 1;
                    if (offset == 0)
                    {
                        for (var index = 0; index <= end; index++)
                            array[index + arrayIndex] = selector(source[index], index)!;
                    }
                    else
                    {
                        for (var index = 0; index <= end; index++)
                            array[index + arrayIndex] = selector(source[index + offset], index)!;
                    }
                }
            }

            public bool Contains(TResult item)
                => ReadOnlyListExtensions.Contains<TList, TSource, TResult>(source, item, selector, offset, Count);

            public int IndexOf(TResult item)
            {
                var end = Count - 1;
                if (Utils.IsValueType<TResult>())
                {
                    if (offset == 0)
                    {
                        for (var index = 0; index <= end; index++)
                        {
                            if (EqualityComparer<TResult>.Default.Equals(selector(source[index], index)!, item))
                                return index;
                        }
                    }
                    else
                    {
                        for (var index = 0; index <= end; index++)
                        {
                            if (EqualityComparer<TResult>.Default.Equals(selector(source[index + offset], index)!, item))
                                return index;
                        }
                    }
                }
                else
                {
                    var defaultComparer = EqualityComparer<TResult>.Default;

                    if (offset == 0)
                    {
                        for (var index = 0; index <= end; index++)
                        {
                            if (defaultComparer.Equals(selector(source[index], index)!, item))
                                return index;
                        }
                    }
                    else
                    {
                        for (var index = 0; index <= end; index++)
                        {
                            if (defaultComparer.Equals(selector(source[index + offset], index)!, item))
                                return index;
                        }
                    }
                }
                return -1;
            }

            [ExcludeFromCodeCoverage]
            void ICollection<TResult>.Add(TResult item) 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void ICollection<TResult>.Clear() 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            bool ICollection<TResult>.Remove(TResult item) 
                => Throw.NotSupportedException<bool>();

            [ExcludeFromCodeCoverage]
            void IList<TResult>.Insert(int index, TResult item)
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void IList<TResult>.RemoveAt(int index)
                => Throw.NotSupportedException();

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
            {
                int index;
                readonly int offset;
                readonly int end;
                readonly TList source;
                readonly NullableSelectorAt<TSource, TResult> selector;

                internal Enumerator(in SelectAtEnumerable<TList, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    offset = enumerable.offset;
                    index = -1;
                    end = index + enumerable.Count;
                }

                [MaybeNull]
                public readonly TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector(source[index + offset], index);
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index <= end;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct DisposableEnumerator
                : IEnumerator<TResult>
            {
                int index;
                readonly int offset;
                readonly int end;
                readonly TList source;
                readonly NullableSelectorAt<TSource, TResult> selector;

                internal DisposableEnumerator(in SelectAtEnumerable<TList, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    offset = enumerable.offset;
                    index = -1;
                    end = index + enumerable.Count;
                }

                [MaybeNull]
                public readonly TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector(source[index + offset], index);
                }
                readonly TResult IEnumerator<TResult>.Current 
                    => selector(source[index + offset], index)!;
                readonly object? IEnumerator.Current
                    => selector(source[index + offset], index);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index <= end;

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public readonly void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => Count != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyListExtensions.SelectAtEnumerable<TList, TSource, TResult2> Select<TResult2>(NullableSelector<TResult, TResult2> selector)
                => ReadOnlyListExtensions.Select<TList, TSource, TResult2>(source, Utils.Combine(this.selector, selector), offset, Count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyListExtensions.SelectAtEnumerable<TList, TSource, TResult2> Select<TResult2>(NullableSelectorAt<TResult, TResult2> selector)
                => ReadOnlyListExtensions.Select<TList, TSource, TResult2>(source, Utils.Combine(this.selector, selector), offset, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => ReadOnlyListExtensions.ElementAt<TList, TSource, TResult>(source, index, selector, offset, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => ReadOnlyListExtensions.First<TList, TSource, TResult>(source, selector, offset, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => ReadOnlyListExtensions.Single<TList, TSource, TResult>(source, selector, offset, Count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult[] ToArray()
                => ReadOnlyListExtensions.ToArray<TList, TSource, TResult>(source, selector, offset, Count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IMemoryOwner<TResult> ToArray(MemoryPool<TResult> pool)
                => ReadOnlyListExtensions.ToArray<TList, TSource, TResult>(source, selector, offset, Count, pool);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TResult> ToList()
                => ReadOnlyListExtensions.ToList<TList, TSource, TResult>(source, selector, offset, Count);

            public Dictionary<TKey, TResult> ToDictionary<TKey>(Selector<TResult, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ToDictionary<TKey>(keySelector, comparer);

            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TResult, TKey> keySelector, NullableSelector<TResult, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ToDictionary<TKey, TElement>(keySelector, elementSelector, comparer);

            public readonly bool SequenceEqual(IEnumerable<TResult> other, IEqualityComparer<TResult>? comparer = default)
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

                    if (!comparer.Equals(enumerator.Current!, otherEnumerator.Current))
                        return false;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TList, TSource, TResult>(this in SelectAtEnumerable<TList, TSource, TResult> source)
            where TList : notnull, IReadOnlyList<TSource>
            => source.Count;
    }
}

