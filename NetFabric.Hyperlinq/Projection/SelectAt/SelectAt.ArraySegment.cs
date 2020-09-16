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
        public static ArraySegmentSelectAtEnumerable<TSource, TResult> Select<TSource, TResult>(this in ArraySegment<TSource> source, NullableSelectorAt<TSource, TResult> selector)
        {
            if (selector is null)
                Throw.ArgumentNullException(nameof(selector));

            return new ArraySegmentSelectAtEnumerable<TSource, TResult>(in source, selector);
        }

        [GeneratorMapping("TSource", "TResult")]
        [GeneratorMapping("TResult", "TResult2")]
        [StructLayout(LayoutKind.Sequential)]
        public readonly partial struct ArraySegmentSelectAtEnumerable<TSource, TResult>
            : IValueReadOnlyList<TResult, ArraySegmentSelectAtEnumerable<TSource, TResult>.DisposableEnumerator>
            , IList<TResult>
        {
            internal readonly ArraySegment<TSource> source;
            internal readonly NullableSelectorAt<TSource, TResult> selector;

            internal ArraySegmentSelectAtEnumerable(in ArraySegment<TSource> source, NullableSelectorAt<TSource, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public readonly int Count
                => source.Count;

            [MaybeNull]
            public readonly TResult this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    if (index < 0 || index >= source.Count) Throw.IndexOutOfRangeException();

                    return selector(source.Array[index + source.Offset], index);
                }
            }
            TResult IReadOnlyList<TResult>.this[int index]
                => this[index]!;
            TResult IList<TResult>.this[int index]
            {
                get => this[index]!;
                set => Throw.NotSupportedException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator()
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TResult, ArraySegmentSelectAtEnumerable<TSource, TResult>.DisposableEnumerator>.GetEnumerator()
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
                if (source.Any())
                {
                    if (source.IsWhole())
                    {
                        if (Utils.IsValueType<TResult>())
                        {
                            var index = 0;
                            foreach (var sourceItem in source.Array)
                            {
                                if (EqualityComparer<TResult>.Default.Equals(selector(sourceItem, index)!, item))
                                    return index;
                            }
                        }
                        else
                        {
                            var defaultComparer = EqualityComparer<TResult>.Default;
                            var array = source.Array;
                            for (var index = 0; index < array.Length; index++)
                            {
                                if (defaultComparer.Equals(selector(array![index], index)!, item))
                                    return index;
                            }
                        }
                    }
                    else
                    {
                        var end = source.Count - 1;
                        if (source.Offset == 0)
                        {
                            if (Utils.IsValueType<TResult>())
                            {
                                var array = source.Array;
                                for (var index = 0; index <= end; index++)
                                {
                                    if (EqualityComparer<TResult>.Default.Equals(selector(array![index], index)!, item))
                                        return index;
                                }
                            }
                            else
                            {
                                var defaultComparer = EqualityComparer<TResult>.Default;
                                var array = source.Array;
                                for (var index = 0; index <= end; index++)
                                {
                                    if (defaultComparer.Equals(selector(array![index], index)!, item))
                                        return index;
                                }
                            }
                        }
                        else
                        {
                            var offset = source.Offset;
                            if (Utils.IsValueType<TResult>())
                            {
                                var array = source.Array;
                                for (var index = 0; index <= end; index++)
                                {
                                    if (EqualityComparer<TResult>.Default.Equals(selector(array![index + offset], index)!, item))
                                        return index;
                                }
                            }
                            else
                            {
                                var defaultComparer = EqualityComparer<TResult>.Default;
                                var array = source.Array;
                                for (var index = 0; index <= end; index++)
                                {
                                    if (defaultComparer.Equals(selector(array![index + offset], index)!, item))
                                        return index;
                                }
                            }
                        }
                    }
                }
                return -1;
            }
            void IList<TResult>.Insert(int index, TResult item)
                => Throw.NotSupportedException();
            void IList<TResult>.RemoveAt(int index)
                => Throw.NotSupportedException();

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
            {
                int index;
                readonly int end;
                readonly TSource[]? source;
                readonly NullableSelectorAt<TSource, TResult> selector;
                readonly int offset;

                internal Enumerator(in ArraySegmentSelectAtEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source.Array;
                    selector = enumerable.selector;
                    offset = enumerable.source.Offset;
                    index = -1;
                    end = index + enumerable.source.Count;
                }

                [MaybeNull]
                public readonly TResult Current
                    => selector(source![index + offset], index);

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
                readonly int offset;
                readonly TSource[]? source;
                readonly NullableSelectorAt<TSource, TResult> selector;

                internal DisposableEnumerator(in ArraySegmentSelectAtEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source.Array;
                    selector = enumerable.selector;
                    offset = enumerable.source.Offset;
                    index = -1;
                    end = index + enumerable.source.Count;
                }

                [MaybeNull]
                public readonly TResult Current
                    => selector(source![index + offset], index);
                readonly TResult IEnumerator<TResult>.Current
                    => selector(source![index + offset], index)!;
                readonly object? IEnumerator.Current
                    => selector(source![index + offset], index);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
            public ArrayExtensions.ArraySegmentSelectAtEnumerable<TSource, TResult2> Select<TResult2>(NullableSelector<TResult, TResult2> selector)
                => ArrayExtensions.Select<TSource, TResult2>(source, Utils.Combine(this.selector, selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArrayExtensions.ArraySegmentSelectAtEnumerable<TSource, TResult2> Select<TResult2>(NullableSelectorAt<TResult, TResult2> selector)
                => ArrayExtensions.Select<TSource, TResult2>(source, Utils.Combine(this.selector, selector));

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
                => ArrayExtensions.ToList(source, selector);

            public bool SequenceEqual(IEnumerable<TResult> other, IEqualityComparer<TResult>? comparer = null)
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
        public static int Count<TSource, TResult>(this ArraySegmentSelectAtEnumerable<TSource, TResult> source)
            => source.Count;
    }
}

