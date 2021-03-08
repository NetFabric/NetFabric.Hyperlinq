using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyListExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerable<IValueReadOnlyList<TSource, TEnumerator>, TEnumerator, TSource> AsValueEnumerable<TEnumerator, TSource>(this IValueReadOnlyList<TSource, TEnumerator> source)
            where TEnumerator : struct, IEnumerator<TSource>
            => AsValueEnumerable<IValueReadOnlyList<TSource, TEnumerator>, TEnumerator, TSource>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerable<TList, TEnumerator, TSource> AsValueEnumerable<TList, TEnumerator, TSource>(this TList source)
            where TList : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => new(source, 0, source.Count);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ValueEnumerable<TList, TEnumerator, TSource>
            : IValueReadOnlyList<TSource, ValueEnumerable<TList, TEnumerator, TSource>.DisposableEnumerator>
            , IList<TSource>
            where TList : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            internal readonly TList source;
            internal readonly int offset;

            internal ValueEnumerable(TList source, int offset, int count)
                => (this.source, this.offset, Count) = (source, offset, count);

            public readonly int Count { get; }

            public readonly TSource this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    if (index < 0 || index >= Count) Throw.IndexOutOfRangeException();

                    return source[index + offset];
                }
            }

            TSource IReadOnlyList<TSource>.this[int index]
                => this[index];

            TSource IList<TSource>.this[int index]
            {
                get => this[index];

                [ExcludeFromCodeCoverage]
                // ReSharper disable once ValueParameterNotUsed
                set => Throw.NotSupportedException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator GetEnumerator()
                => new(in this);

            DisposableEnumerator IValueEnumerable<TSource, DisposableEnumerator>.GetEnumerator()
                => new(in this);

            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);

            IEnumerator IEnumerable.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);


            bool ICollection<TSource>.IsReadOnly
                => true;

            public void CopyTo(Span<TSource> span)
            {
                if (span.Length < Count)
                    Throw.ArgumentException(Resource.DestinationNotLongEnough, nameof(span));

                ReadOnlyListExtensions.Copy(this, 0, span, Count);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(TSource[] array, int arrayIndex)
                => CopyTo(array.AsSpan().Slice(arrayIndex));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource item)
                => Count is not 0 && source.Contains(item);

            public int IndexOf(TSource item)
                => ReadOnlyListExtensions.IndexOf(source, item, offset, Count);

            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Add(TSource item)
                => Throw.NotSupportedException();

            [ExcludeFromCodeCoverage]
            bool ICollection<TSource>.Remove(TSource item)
                => Throw.NotSupportedException<bool>();

            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Clear()
                => Throw.NotSupportedException();

            [ExcludeFromCodeCoverage]
            void IList<TSource>.Insert(int index, TSource item)
                => Throw.NotSupportedException();

            [ExcludeFromCodeCoverage]
            void IList<TSource>.RemoveAt(int index)
                => Throw.NotSupportedException();
            
            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
            {
                readonly TList source;
                readonly int end;
                int index;

                internal Enumerator(in ValueEnumerable<TList, TEnumerator, TSource> enumerable)
                {
                    source = enumerable.source;
                    index = enumerable.offset - 1;
                    end = index + enumerable.Count;
                }

                public TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source[index];
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index <= end;
            }

            [StructLayout(LayoutKind.Auto)]
            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                readonly TList source;
                readonly int end;
                int index;

                internal DisposableEnumerator(in ValueEnumerable<TList, TEnumerator, TSource> enumerable)
                {
                    source = enumerable.source;
                    index = enumerable.offset - 1;
                    end = index + enumerable.Count;
                }

                public TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source[index];
                }
                TSource IEnumerator<TSource>.Current 
                    => source[index];
                object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => source[index];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index <= end;

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public readonly void Dispose() { }
            }

            #region Conversion

            ValueEnumerable<TList, TEnumerator, TSource> AsValueEnumerable()
                => this;

            #endregion
            #region Partitioning

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerable<TList, TEnumerator, TSource> Skip(int count)
            {
                var (skipCount, takeCount) = Utils.Skip(Count, count);
                return new ValueEnumerable<TList, TEnumerator, TSource>(source, offset + skipCount, takeCount);
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerable<TList, TEnumerator, TSource> Take(int count)
                => new(source, offset, Utils.Take(Count, count));

            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TList, TEnumerator, TSource>(this in ValueEnumerable<TList, TEnumerator, TSource> source)
            where TList : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TList, TEnumerator>(this ValueEnumerable<TList, TEnumerator, int> source)
            where TList : IValueReadOnlyList<int, TEnumerator>
            where TEnumerator : struct, IEnumerator<int>
            => source.source.Sum<TList, int, int>(source.offset, source.Count);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TList, TEnumerator>(this ValueEnumerable<TList, TEnumerator, int?> source)
            where TList : IValueReadOnlyList<int?, TEnumerator>
            where TEnumerator : struct, IEnumerator<int?>
            => source.source.Sum<TList, int?, int>(source.offset, source.Count);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TList, TEnumerator>(this ValueEnumerable<TList, TEnumerator, long> source)
            where TList : IValueReadOnlyList<long, TEnumerator>
            where TEnumerator : struct, IEnumerator<long>
            => source.source.Sum<TList, long, long>(source.offset, source.Count);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TList, TEnumerator>(this ValueEnumerable<TList, TEnumerator, long?> source)
            where TList : IValueReadOnlyList<long?, TEnumerator>
            where TEnumerator : struct, IEnumerator<long?>
            => source.source.Sum<TList, long?, long>(source.offset, source.Count);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TList, TEnumerator>(this ValueEnumerable<TList, TEnumerator, float> source)
            where TList : IValueReadOnlyList<float, TEnumerator>
            where TEnumerator : struct, IEnumerator<float>
            => source.source.Sum<TList, float, int>(source.offset, source.Count);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TList, TEnumerator>(this ValueEnumerable<TList, TEnumerator, float?> source)
            where TList : IValueReadOnlyList<float?, TEnumerator>
            where TEnumerator : struct, IEnumerator<float?>
            => source.source.Sum<TList, float?, float>(source.offset, source.Count);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TList, TEnumerator>(this ValueEnumerable<TList, TEnumerator, double> source)
            where TList : IValueReadOnlyList<double, TEnumerator>
            where TEnumerator : struct, IEnumerator<double>
            => source.source.Sum<TList, double, double>(source.offset, source.Count);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TList, TEnumerator>(this ValueEnumerable<TList, TEnumerator, double?> source)
            where TList : IValueReadOnlyList<double?, TEnumerator>
            where TEnumerator : struct, IEnumerator<double?>
            => source.source.Sum<TList, double?, double>(source.offset, source.Count);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TList, TEnumerator>(this ValueEnumerable<TList, TEnumerator, decimal> source)
            where TList : IValueReadOnlyList<decimal, TEnumerator>
            where TEnumerator : struct, IEnumerator<decimal>
            => source.source.Sum<TList, decimal, decimal>(source.offset, source.Count);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TList, TEnumerator>(this ValueEnumerable<TList, TEnumerator, decimal?> source)
            where TList : IValueReadOnlyList<decimal?, TEnumerator>
            where TEnumerator : struct, IEnumerator<decimal?>
            => source.source.Sum<TList, decimal?, decimal>(source.offset, source.Count);
    }
}