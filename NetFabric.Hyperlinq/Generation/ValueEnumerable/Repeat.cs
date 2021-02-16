using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        
        public static RepeatEnumerable<TSource> Repeat<TSource>(TSource value, int count)
        {
            if (count < 0) Throw.ArgumentOutOfRangeException(nameof(count));

            return new RepeatEnumerable<TSource>(value, count);
        }

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct RepeatEnumerable<TSource>
            : IValueReadOnlyCollection<TSource, RepeatEnumerable<TSource>.DisposableEnumerator>
            , ICollection<TSource>
        {
            internal readonly TSource value;
            internal readonly int count;

            internal RepeatEnumerable(TSource value, int count)
            {
                this.value = value;
                this.count = count;
            }

            public readonly int Count 
                => count;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() 
                => new(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, DisposableEnumerator>.GetEnumerator() 
                => new(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);

            bool ICollection<TSource>.IsReadOnly  
                => true;

            public void CopyTo(Span<TSource> span) 
            {
                if (span.Length < Count)
                    Throw.ArgumentException(Resource.DestinationNotLongEnough, nameof(span));

                span.Slice(0, Count).Fill(value);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(TSource[] array, int arrayIndex)
                => CopyTo(array.AsSpan().Slice(arrayIndex));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource item)
                => count is not 0 && EqualityComparer<TSource>.Default.Equals(value, item);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int IndexOf(TSource item)
                => Contains(item)
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

                public readonly TSource Current { get; }
                readonly TSource IEnumerator<TSource>.Current 
                    => Current;
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
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
            public bool All(Func<TSource, bool> predicate)
                => count is 0 || predicate(value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => count is not 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer)
                => comparer switch
                {
                    null => count is not 0 && EqualityComparer<TSource>.Default.Equals(this.value, value),
                    _ => count is not 0 && comparer.Equals(this.value, value)
                };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RepeatEnumerable<TResult> Select<TResult>(Func<TSource, TResult> selector)
                => Select<TResult, FunctionWrapper<TSource, TResult>>(new FunctionWrapper<TSource, TResult>(selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RepeatEnumerable<TResult> Select<TResult, TSelector>(TSelector selector = default) 
                where TSelector : struct, IFunction<TSource, TResult>
                => new(selector.Invoke(value), count);

            public TSource[] ToArray()
            {
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                var array = new TSource[Count];
                CopyTo(array.AsSpan());
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
                => Count switch
                {
                    0 => new List<TSource>(),
                    _ => ToArray().AsList()
                };
        }

#if NET5_0
        public static void CopyToVector<TSource>(this RepeatEnumerable<TSource> source, Span<TSource> span)
            where TSource : struct
        {
            var count = source.count;
            if (span.Length < count)
                Throw.ArgumentException(Resource.DestinationNotLongEnough, nameof(span));

            var value = source.value;
            if (Vector.IsHardwareAccelerated && source.Count >= Vector<TSource>.Count)
            {
                var vector = new Vector<TSource>(value);

                var index = 0;
                for (; index <= count - Vector<TSource>.Count; index += Vector<TSource>.Count)
                    vector.CopyTo(span.Slice(index, Vector<TSource>.Count));

                for (; index < span.Length; index++)
                    span[index] = value;
            }
            else
            {
                for (var index = 0; index < span.Length; index++)
                    span[index] = value;
            }
        }

        public static TSource[] ToArrayVector<TSource>(this RepeatEnumerable<TSource> source)
            where TSource : struct
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var array = new TSource[source.count];
            source.CopyToVector(array.AsSpan());
            return array;
        }

        public static IMemoryOwner<TSource> ToArrayVector<TSource>(this RepeatEnumerable<TSource> source, MemoryPool<TSource> pool)
            where TSource : struct
        {
            var result = pool.RentSliced(source.count);
            source.CopyToVector(result.Memory.Span);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToListVector<TSource>(this RepeatEnumerable<TSource> source)
            where TSource : struct
            => source.count switch
            {
                0 => new List<TSource>(),
                _ => source.ToArrayVector().AsList()
            };
#endif
    }
}

