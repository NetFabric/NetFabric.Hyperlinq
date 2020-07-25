using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentSelectEnumerable<TSource, TResult> Select<TSource, TResult>(this in ArraySegment<TSource> source, NullableSelector<TSource, TResult> selector)
        {
            if (selector is null)
                Throw.ArgumentNullException(nameof(selector));

            return new ArraySegmentSelectEnumerable<TSource, TResult>(in source, selector);
        }

        [GeneratorMapping("TSource", "TResult")]
        public readonly partial struct ArraySegmentSelectEnumerable<TSource, TResult>
            : IValueReadOnlyList<TResult, ArraySegmentSelectEnumerable<TSource, TResult>.DisposableEnumerator>
            , IList<TResult>
        {
            internal readonly ArraySegment<TSource> source;
            internal readonly NullableSelector<TSource, TResult> selector;

            internal ArraySegmentSelectEnumerable(in ArraySegment<TSource> source, NullableSelector<TSource, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public readonly int Count
                => source.Count;

            [MaybeNull]
            public readonly TResult this[int index]
            {
                get
                {
                    if (index < 0 || index >= source.Count) Throw.IndexOutOfRangeException();

                    return selector(source.Array[index + source.Offset]);
                }
            }
            TResult IReadOnlyList<TResult>.this[int index]
                => this[index]!;
            TResult IList<TResult>.this[int index]
            {
                get => this[index]!;
                set => Throw.NotSupportedException();
            }

            public readonly Enumerator GetEnumerator()
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TResult, ArraySegmentSelectEnumerable<TSource, TResult>.DisposableEnumerator>.GetEnumerator()
                => new DisposableEnumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator()
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator()
                => new DisposableEnumerator(in this);


            bool ICollection<TResult>.IsReadOnly
                => true;

            void ICollection<TResult>.CopyTo(TResult[] array, int arrayIndex)
                => ArrayExtensions.Copy(source, array.AsSpan(arrayIndex), selector);
            void ICollection<TResult>.Add(TResult item)
                => Throw.NotSupportedException();
            void ICollection<TResult>.Clear()
                => Throw.NotSupportedException();
            bool ICollection<TResult>.Contains(TResult item)
                => ArrayExtensions.Contains(source, item, selector);
            bool ICollection<TResult>.Remove(TResult item)
                => Throw.NotSupportedException<bool>();
            int IList<TResult>.IndexOf(TResult item)
            {
                var array = source.Array;
                if (source.IsWhole())
                {
                    var index = 0;
                    if (Utils.IsValueType<TResult>())
                    {
                        foreach (var sourceItem in array)
                        {
                            if (EqualityComparer<TResult>.Default.Equals(selector(sourceItem)!, item))
                                return index;

                            index++;
                        }
                    }
                    else
                    {
                        var defaultComparer = EqualityComparer<TResult>.Default;
                        foreach (var sourceItem in array)
                        {
                            if (defaultComparer.Equals(selector(sourceItem)!, item))
                                return index;

                            index++;
                        }
                    }
                }
                else
                {
                    var end = source.Offset + source.Count;
                    if (Utils.IsValueType<TResult>())
                    {
                        for (var index = source.Offset; index < end; index++)
                        {
                            if (EqualityComparer<TResult>.Default.Equals(selector(array[index])!, item))
                                return index - source.Offset;
                        }
                    }
                    else
                    {
                        var defaultComparer = EqualityComparer<TResult>.Default;
                        for (var index = source.Offset; index < end; index++)
                        {
                            if (defaultComparer.Equals(selector(array[index])!, item))
                                return index - source.Offset;
                        }
                    }
                }
                return -1;
            }
            void IList<TResult>.Insert(int index, TResult item)
                => Throw.NotSupportedException();
            void IList<TResult>.RemoveAt(int index)
                => Throw.NotSupportedException();

            public struct Enumerator
            {
                readonly TSource[] source;
                readonly NullableSelector<TSource, TResult> selector;
                readonly int end;
                int index;

                internal Enumerator(in ArraySegmentSelectEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source.Array;
                    selector = enumerable.selector;
                    index = enumerable.source.Offset - 1;
                    end = index + enumerable.source.Count;
                }

                [MaybeNull]
                public readonly TResult Current
                    => selector(source[index]);

                public bool MoveNext()
                    => ++index <= end;
            }

            public struct DisposableEnumerator
                : IEnumerator<TResult>
            {
                readonly TSource[] source;
                readonly NullableSelector<TSource, TResult> selector;
                readonly int end;
                int index;

                internal DisposableEnumerator(in ArraySegmentSelectEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source.Array;
                    selector = enumerable.selector;
                    index = enumerable.source.Offset - 1;
                    end = index + enumerable.source.Count;
                }

                [MaybeNull]
                public readonly TResult Current
                    => selector(source[index]);
                readonly TResult IEnumerator<TResult>.Current
                    => selector(source[index])!;
                readonly object? IEnumerator.Current
                    => selector(source[index]);

                public bool MoveNext()
                    => ++index <= end;

                [ExcludeFromCodeCoverage]
                public readonly void Reset()
                    => Throw.NotSupportedException();

                public void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Count != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => ArrayExtensions.ElementAt<TSource, TResult>(source, index, selector);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => ArrayExtensions.First<TSource, TResult>(source, selector);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => ArrayExtensions.Single<TSource, TResult>(source, selector);

            public TResult[] ToArray()
                => ArrayExtensions.ToArray(source, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IMemoryOwner<TResult> ToArray(MemoryPool<TResult> pool)
                => ArrayExtensions.ToArray<TSource, TResult>(source, selector, pool);

            public List<TResult> ToList()
                => ArrayExtensions.ToList(source, selector); // memory performs best
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource, TResult>(this ArraySegmentSelectEnumerable<TSource, TResult> source)
            => source.Count;
    }
}

