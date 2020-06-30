using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        public static SelectAtEnumerable<TSource, TResult> Select<TSource, TResult>(this in ArraySegment<TSource> source, NullableSelectorAt<TSource, TResult> selector)
        {
            if (selector is null) Throw.ArgumentNullException(nameof(selector));

            return new SelectAtEnumerable<TSource, TResult>(source, selector);
        }

        [GeneratorMapping("TSource", "TResult")]
        public readonly partial struct SelectAtEnumerable<TSource, TResult>
            : IValueReadOnlyList<TResult, SelectAtEnumerable<TSource, TResult>.DisposableEnumerator>
            , IList<TResult>
        {
            readonly ArraySegment<TSource> source;
            readonly NullableSelectorAt<TSource, TResult> selector;

            internal SelectAtEnumerable(in ArraySegment<TSource> source, NullableSelectorAt<TSource, TResult> selector)
                => (this.source, this.selector) = (source, selector);

            public readonly int Count
                => source.Count;

            [MaybeNull]
            public readonly TResult this[int index]
            {
                get
                {
                    if (index < 0 || index >= Count)
                        Throw.ArgumentOutOfRangeException(nameof(index));

                    return selector(source.Array[index + source.Offset], index);
                }
            }
            TResult IReadOnlyList<TResult>.this[int index]
                => this[index];
            TResult IList<TResult>.this[int index]
            {
                get => this[index];
                [ExcludeFromCodeCoverage]
                set => Throw.NotSupportedException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() 
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TResult, SelectAtEnumerable<TSource, TResult>.DisposableEnumerator>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new DisposableEnumerator(in this);

            bool ICollection<TResult>.IsReadOnly
                => true;

            public void CopyTo(TResult[] array, int arrayIndex)
            {
                var sourceArray = source.Array;
                var offset = source.Offset;
                if (offset == 0)
                {
                    if (arrayIndex == 0)
                    {
                        for (var index = 0; index < Count; index++)
                            array[index] = selector(sourceArray[index], index);
                    }
                    else
                    {
                        for (var index = 0; index < Count; index++)
                            array[index + arrayIndex] = selector(sourceArray[index], index);
                    }
                }
                else
                {
                    if (arrayIndex == 0)
                    {
                        for (var index = 0; index < Count; index++)
                            array[index] = selector(sourceArray[index + offset], index);
                    }
                    else
                    {
                        for (var index = 0; index < Count; index++)
                            array[index + arrayIndex] = selector(sourceArray[index + offset], index);
                    }
                }
            }

            public bool Contains(TResult item)
                => ArrayExtensions.Contains<TSource, TResult>(source, item, selector);

            public int IndexOf(TResult item)
            {
                var array = source.Array;
                var offset = source.Offset;
                var end = offset + Count;
                if (Utils.IsValueType<TResult>())
                {
                    if (offset == 0)
                    {
                        for (var index = 0; index < Count; index++)
                        {
                            if (EqualityComparer<TResult>.Default.Equals(selector(array[index], index), item))
                                return index;
                        }
                    }
                    else
                    {
                        for (var index = 0; index < Count; index++)
                        {
                            if (EqualityComparer<TResult>.Default.Equals(selector(array[index + offset], index), item))
                                return index;
                        }
                    }
                }
                else
                {
                    var defaultComparer = EqualityComparer<TResult>.Default;
                    if (offset == 0)
                    {
                        for (var index = 0; index < Count; index++)
                        {
                            if (defaultComparer.Equals(selector(array[index], index), item))
                                return index;
                        }
                    }
                    else
                    {
                        for (var index = 0; index < Count; index++)
                        {
                            if (defaultComparer.Equals(selector(array[index + offset], index), item))
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

            public struct Enumerator
            {
                readonly TSource[] source;
                readonly NullableSelectorAt<TSource, TResult> selector;
                readonly int offset;
                readonly int takeCount;
                int index;

                internal Enumerator(in SelectAtEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source.Array;
                    selector = enumerable.selector;
                    offset = enumerable.source.Offset;
                    takeCount = enumerable.source.Count;
                    index = -1;
                }

                [MaybeNull]
                public readonly TResult Current
                    => selector(source[index + offset], index);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                    => ++index < takeCount;
            }

            public struct DisposableEnumerator
                : IEnumerator<TResult>
            {
                readonly TSource[] source;
                readonly NullableSelectorAt<TSource, TResult> selector;
                readonly int offset;
                readonly int takeCount;
                int index;

                internal DisposableEnumerator(in SelectAtEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source.Array;
                    selector = enumerable.selector;
                    offset = enumerable.source.Offset;
                    takeCount = enumerable.source.Count;
                    index = -1;
                }

                [MaybeNull]
                public readonly TResult Current
                    => selector(source[index + offset], index);
                readonly TResult IEnumerator<TResult>.Current
                    => selector(source[index + offset], index);
                readonly object? IEnumerator.Current
                    => selector(source[index + offset], index);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                    => ++index < takeCount;

                [ExcludeFromCodeCoverage]
                public readonly void Reset()
                    => Throw.NotSupportedException();

                public readonly void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => Count != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectAtEnumerable<TSource, TSelectorResult> Select<TSelectorResult>(NullableSelector<TResult, TSelectorResult> selector)
                => ArrayExtensions.Select<TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectAtEnumerable<TSource, TSelectorResult> Select<TSelectorResult>(NullableSelectorAt<TResult, TSelectorResult> selector)
                => ArrayExtensions.Select<TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector));


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => ArrayExtensions.ElementAt<TSource, TResult>(source, index, selector);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => ArrayExtensions.First<TSource, TResult>(source, selector);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => ArrayExtensions.Single<TSource, TResult>(source, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult[] ToArray()
                => ArrayExtensions.ToArray<TSource, TResult>(source, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TResult> ToList()
                => ArrayExtensions.ToList<TSource, TResult>(source, selector);

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

                    if (!comparer.Equals(enumerator.Current, otherEnumerator.Current))
                        return false;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource, TResult>(this in SelectAtEnumerable<TSource, TResult> source)
            => source.Count;
    }
}

