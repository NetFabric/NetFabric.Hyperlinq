using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        
        public static RepeatEnumerable<TSource> Repeat<TSource>([AllowNull] TSource value, int count)
        {
            if (count < 0) Throw.ArgumentOutOfRangeException(nameof(count));

            return new RepeatEnumerable<TSource>(value, count);
        }

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct RepeatEnumerable<TSource>
            : IValueReadOnlyCollection<TSource, RepeatEnumerable<TSource>.DisposableEnumerator>
            , ICollection<TSource>
        {
            [AllowNull, MaybeNull] internal readonly TSource value;
            internal readonly int count;

            internal RepeatEnumerable([AllowNull] TSource value, int count)
            {
                this.value = value;
                this.count = count;
            }

            public readonly int Count 
                => count;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() 
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, DisposableEnumerator>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new DisposableEnumerator(in this);

            bool ICollection<TSource>.IsReadOnly  
                => true;

            public void CopyTo(Span<TSource> span) 
            {
                var end = count - 1;
                for (var index = 0; index <= end; index++)
                    span[index] = value;
            }

            public void CopyTo(TSource[] array, int arrayIndex)
            {
                var end = arrayIndex + count - 1;
                for (var index = arrayIndex; index <= end; index++)
                    array[index] = value;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource item)
                => count != 0 && EqualityComparer<TSource>.Default.Equals(value, item);

            public int IndexOf(TSource item)
                => count != 0 && EqualityComparer<TSource>.Default.Equals(value, item)
                    ? 0
                    : -1;

            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Add(TSource item) 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Clear() 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            bool ICollection<TSource>.Remove(TSource item) 
                => Throw.NotSupportedException<bool>();

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
            {
                int counter;
                readonly int end;

                internal Enumerator(in RepeatEnumerable<TSource> enumerable)
                {
                    Current = enumerable.value;
                    counter = -1;
                    end = counter + enumerable.Count;
                }

                [MaybeNull]
                public readonly TSource Current { get; }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++counter <= end;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                int counter;
                readonly int end;

                internal DisposableEnumerator(in RepeatEnumerable<TSource> enumerable)
                {
                    Current = enumerable.value;
                    counter = -1;
                    end = counter + enumerable.Count;
                }

                [MaybeNull]
                public readonly TSource Current { get; }
                readonly TSource IEnumerator<TSource>.Current 
                    => Current!;
                readonly object? IEnumerator.Current 
                    => Current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++counter <= end;

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public readonly void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RepeatEnumerable<TSource> Skip(int count)
            {
                var (_, takeCount) = Utils.Skip(this.count, count);
                return Repeat(value, takeCount);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RepeatEnumerable<TSource> Take(int count)
                => Repeat(value, Utils.Take(this.count, count));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Predicate<TSource> predicate)
                => count == 0 || predicate(value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => count != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer)
                => comparer is null
                    ? count != 0 && EqualityComparer<TSource>.Default.Equals(this.value, value)
                    : count != 0 && comparer.Equals(this.value, value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RepeatEnumerable<TResult> Select<TResult>(NullableSelector<TSource, TResult> selector) 
                => new RepeatEnumerable<TResult>(selector(value), count);

            public TSource[] ToArray()
            {
                var array = new TSource[count];
                if (value is object)
                {
#if NETSTANDARD2_1
                    Array.Fill(array, value);
#else
                    CopyTo(array);
#endif
                }
                return array;
            }

            public IMemoryOwner<TSource> ToArray(MemoryPool<TSource> pool)
            {
                var result = pool.RentSliced(Count);
                CopyTo(result.Memory.Span);
                return result;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => new List<TSource>(this);
        }
    }
}

