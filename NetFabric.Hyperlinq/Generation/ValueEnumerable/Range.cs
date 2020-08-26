using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {

        public static RangeEnumerable Range(int start, int count)
        {
            if (count < 0)
                Throw.ArgumentOutOfRangeException(nameof(count));

            var end = 0;
            try
            {
                end = checked(start + count);
            }
            catch (OverflowException)
            {
                Throw.ArgumentOutOfRangeException(nameof(count));
            }

            return new RangeEnumerable(start, count, end);
        }

        [GeneratorMapping("TSource", "int", true)]
        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct RangeEnumerable
            : IValueReadOnlyCollection<int, RangeEnumerable.DisposableEnumerator>
            , ICollection<int>
        {
            readonly int start;
            readonly int end;

            internal RangeEnumerable(int start, int count, int end)
            {
                this.start = start;
                Count = count;
                this.end = end;
            }

            public readonly int Count { get; }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator()
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<int, DisposableEnumerator>.GetEnumerator()
                => new DisposableEnumerator(in this);
            readonly IEnumerator<int> IEnumerable<int>.GetEnumerator()
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator()
                => new DisposableEnumerator(in this);

            bool ICollection<int>.IsReadOnly
                => true;

            public void CopyTo(Span<int> array)
            {
                if (start == 0)
                {
                    for (var index = 0; index < Count; index++)
                        array[index] = index;
                }
                else
                {
                    for (var index = 0; index < Count; index++)
                        array[index] = index + start;
                }
            }

            public void CopyTo(int[] array)
            {
                if (start == 0)
                {
                    for (var index = 0; index < Count; index++)
                        array[index] = index;
                }
                else
                {
                    for (var index = 0; index < Count; index++)
                        array[index] = index + start;
                }
            }

            public void CopyTo(int[] array, int arrayIndex)
            {
                if (start == 0)
                {
                    if (arrayIndex == 0)
                    {
                        for (var index = 0; index < Count; index++)
                            array[index] = index;
                    }
                    else
                    {
                        for (var index = 0; index < Count; index++)
                            array[index + arrayIndex] = index;
                    }
                }
                else
                {
                    if (arrayIndex == 0)
                    {
                        for (var index = 0; index < Count; index++)
                            array[index] = index + start;
                    }
                    else
                    {
                        for (var index = 0; index < Count; index++)
                            array[index + arrayIndex] = index + start;
                    }
                }
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(int value)
                => value >= start && value < end;

            [ExcludeFromCodeCoverage]
            void ICollection<int>.Add(int item)
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void ICollection<int>.Clear()
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            bool ICollection<int>.Remove(int item)
                => Throw.NotSupportedException<bool>();

            [StructLayout(LayoutKind.Explicit)]
            public struct Enumerator
            {
                [FieldOffset(0)] int current;
                [FieldOffset(4)] readonly int end;
                [FieldOffset(8)] readonly long pad;

                internal Enumerator(in RangeEnumerable enumerable)
                {
                    current = enumerable.start - 1;
                    end = current + enumerable.Count;
                    pad = default;
                }

                public int Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => current;
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                    => ++current <= end;
            }

            [StructLayout(LayoutKind.Explicit)]
            public struct DisposableEnumerator
                : IEnumerator<int>
            {
                [FieldOffset(0)] int current;
                [FieldOffset(4)] readonly int end;
                [FieldOffset(8)] readonly long pad;

                internal DisposableEnumerator(in RangeEnumerable enumerable)
                {
                    current = enumerable.start - 1;
                    end = current + enumerable.Count;
                    pad = default;
                }

                public int Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => current;
                }
                object IEnumerator.Current
                    => current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                    => ++current <= end;

                [ExcludeFromCodeCoverage]
                public readonly void Reset()
                    => Throw.NotSupportedException();

                public readonly void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RangeEnumerable Skip(int count)
            {
                var (skipCount, takeCount) = Utils.Skip(Count, count);
                return Range(start + skipCount, takeCount);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RangeEnumerable Take(int count)
                => Range(start, Utils.Take(Count, count));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => Count != 0;

            public bool Contains(int value, IEqualityComparer<int>? comparer)
            {
                if (Count == 0)
                    return false;

                if (comparer is null || ReferenceEquals(comparer, EqualityComparer<int>.Default))
                    return value >= start && value < end;

                for (var item = start; item < end; item++)
                {
                    if (comparer.Equals(item, value))
                        return true;
                }
                return false;
            }

            public int[] ToArray()
            {
                var array = new int[Count];
                CopyTo(array);
                return array;
            }

            public IMemoryOwner<int> ToArray(MemoryPool<int> pool)
            {
                var result = pool.RentSliced(Count);
                CopyTo(result.Memory.Span);
                return result;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<int> ToList()
                => new List<int>(this);
        }
    }
}
