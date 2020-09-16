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
        public static SelectEnumerable<TList, TSource, TResult> Select<TList, TSource, TResult>(
            this TList source, 
            NullableSelector<TSource, TResult> selector)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if(selector is null) Throw.ArgumentNullException(nameof(selector));

            return new SelectEnumerable<TList, TSource, TResult>(in source, selector, 0, source.Count);
        }

        static SelectEnumerable<TList, TSource, TResult> Select<TList, TSource, TResult>(
            this TList source,
            NullableSelector<TSource, TResult> selector,
            int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            => new SelectEnumerable<TList, TSource, TResult>(source, selector, offset, count);

        [GeneratorMapping("TSource", "TResult")]
        [GeneratorMapping("TResult", "TResult2")]
        [StructLayout(LayoutKind.Sequential)]
        public readonly partial struct SelectEnumerable<TList, TSource, TResult>
            : IValueReadOnlyList<TResult, SelectEnumerable<TList, TSource, TResult>.DisposableEnumerator>
            , IList<TResult>
            where TList : notnull, IReadOnlyList<TSource>
        {
            readonly int offset;
            readonly TList source;
            readonly NullableSelector<TSource, TResult> selector;

            internal SelectEnumerable(in TList source, NullableSelector<TSource, TResult> selector, int offset, int count)
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

                    return selector(source[index + offset]);
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
            readonly DisposableEnumerator IValueEnumerable<TResult, SelectEnumerable<TList, TSource, TResult>.DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            bool ICollection<TResult>.IsReadOnly  
                => true;

            public void CopyTo(TResult[] array, int arrayIndex)
                => ReadOnlyListExtensions.Copy(source, offset, array, arrayIndex, Count, selector);

            public bool Contains(TResult item)
                => ReadOnlyListExtensions.Contains<TList, TSource, TResult>(source, item, selector, offset, Count);

            public int IndexOf(TResult item)
            {
                var end = offset + Count - 1;
                if (Utils.IsValueType<TResult>())
                {
                    for (var index = offset; index <= end; index++)
                    {
                        if (EqualityComparer<TResult>.Default.Equals(selector(source[index])!, item))
                            return index - offset;
                    }
                }
                else
                {
                    var defaultComparer = EqualityComparer<TResult>.Default;
                    for (var index = offset; index <= end; index++)
                    {
                        if (defaultComparer.Equals(selector(source[index])!, item))
                            return index - offset;
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
                readonly int end;
                readonly TList source;
                readonly NullableSelector<TSource, TResult> selector;

                internal Enumerator(in SelectEnumerable<TList, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    index = enumerable.offset - 1;
                    end = index + enumerable.Count;
                }

                [MaybeNull]
                public readonly TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector(source[index]);
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
                readonly int end;
                readonly TList source;
                readonly NullableSelector<TSource, TResult> selector;

                internal DisposableEnumerator(in SelectEnumerable<TList, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    index = enumerable.offset - 1;
                    end = index + enumerable.Count;
                }

                [MaybeNull]
                public readonly TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector(source[index]);
                }
                readonly TResult IEnumerator<TResult>.Current 
                    => selector(source[index])!;
                readonly object? IEnumerator.Current
                    => selector(source[index]);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index <= end;

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public readonly void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyListExtensions.SelectEnumerable<TList, TSource, TResult> Skip(int count)
                => new ReadOnlyListExtensions.SelectEnumerable<TList, TSource, TResult>(source, selector, offset + count, Count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyListExtensions.SelectEnumerable<TList, TSource, TResult> Take(int count)
                => new ReadOnlyListExtensions.SelectEnumerable<TList, TSource, TResult>(source, selector, offset, Math.Min(Count, count));


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => Count != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyListExtensions.SelectEnumerable<TList, TSource, TResult2> Select<TResult2>(NullableSelector<TResult, TResult2> selector)
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
        public static int Count<TList, TSource, TResult>(this in SelectEnumerable<TList, TSource, TResult> source)
            where TList : notnull, IReadOnlyList<TSource>
            => source.Count;
    }
}

