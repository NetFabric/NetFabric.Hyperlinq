using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> SkipTake<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => new(in source, skipCount, takeCount);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueReadOnlyCollection<TSource, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            , ICollection<TSource>
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly int skipCount;

            internal SkipTakeEnumerable(in TEnumerable source, int skipCount, int takeCount)
            {
                this.source = source;
                (this.skipCount, Count) = Partition.SkipTake(source.Count, skipCount, takeCount);
            }

            public readonly int Count { get; }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() 
                => new(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);

            bool ICollection<TSource>.IsReadOnly  
                => true;

            public void CopyTo(Span<TSource> span)
            {
                if (Count is 0)
                    return;

                if (span.Length < Count)
                    Throw.ArgumentException(Resource.DestinationNotLongEnough, nameof(span));

                using var enumerator = source.GetEnumerator();

                // skip
                for (var counter = 0; counter < skipCount; counter++)
                {
                    if (!enumerator.MoveNext())
                        Throw.InvalidOperationException();
                }

                // take
                for (var counter = 0; counter < Count; counter++)
                {
                    if (!enumerator.MoveNext())
                        Throw.InvalidOperationException();

                    span[counter] = enumerator.Current;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(TSource[] array, int arrayIndex)
            {
                if (Count is 0)
                    return;

                // ReSharper disable once HeapView.PossibleBoxingAllocation
                if (skipCount is 0 && Count == source.Count && source is ICollection<TSource> collection)
                    collection.CopyTo(array, arrayIndex);
                else
                    CopyTo(array.AsSpan().Slice(arrayIndex));
            }
            
            public bool Contains(TSource item)
                => Contains(item, EqualityComparer<TSource>.Default);

            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Add(TSource item) 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Clear() 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            bool ICollection<TSource>.Remove(TSource item) 
                => Throw.NotSupportedException<bool>();

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
                : IEnumerator<TSource>
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly
                int skipCounter;
                int takeCounter;
                EnumeratorState state;

                internal Enumerator(in SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    skipCounter = enumerable.skipCount;
                    takeCounter = enumerable.Count;
                    state = takeCounter > 0 ? EnumeratorState.Uninitialized : EnumeratorState.Complete;
                }

                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => enumerator.Current;
                }
                readonly TSource IEnumerator<TSource>.Current 
                    => enumerator.Current;
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => enumerator.Current;

                public bool MoveNext()
                {
                    switch (state)
                    {
                        case EnumeratorState.Uninitialized:
                            while (skipCounter > 0)
                            {
                                if (enumerator.MoveNext())
                                {
                                    skipCounter--;
                                }
                                else
                                {
                                    state = EnumeratorState.Complete;
                                    goto case EnumeratorState.Complete;
                                }
                            }                
                            state = EnumeratorState.Enumerating;
                            goto case EnumeratorState.Enumerating;
                            
                        case EnumeratorState.Enumerating:
                            if (enumerator.MoveNext())
                            {
                                takeCounter--;
                                if (takeCounter is 0)
                                    state = EnumeratorState.Complete;

                                return true;
                            }
                            state = EnumeratorState.Complete;
                            goto case EnumeratorState.Complete;

                        case EnumeratorState.Complete:
                        default:
                            return false;
                    }
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public void Dispose() 
                    => enumerator.Dispose();
            }

            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer)
            {
                if (source.Count is 0)
                    return false;

                if (Utils.UseDefault(comparer))
                {
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    if (skipCount is 0 && Count == source.Count && source is ICollection<TSource> collection)
                        return collection.Contains(value);

                    return DefaultContains(source, value, skipCount, Count);
                }

                return ComparerContains(source, value, comparer, skipCount, Count);

                static bool DefaultContains(TEnumerable source, TSource value, int skipCount, int takeCount)
                {
                    using var enumerator = source.GetEnumerator();

                    // skip
                    for (var counter = 0; counter < skipCount; counter++)
                    {
                        if (!enumerator.MoveNext())
                            Throw.InvalidOperationException();
                    }

                    // take
                    for (var counter = 0; counter < takeCount; counter++)
                    {
                        if (!enumerator.MoveNext())
                            Throw.InvalidOperationException();

                        if (EqualityComparer<TSource>.Default.Equals(enumerator.Current, value!))
                            return true;
                    }
                    return false;
                }

                static bool ComparerContains(TEnumerable source, TSource value, IEqualityComparer<TSource>? comparer, int skipCount, int takeCount)
                {
                    comparer ??= EqualityComparer<TSource>.Default;
                    using var enumerator = source.GetEnumerator();

                    // skip
                    for (var counter = 0; counter < skipCount; counter++)
                    {
                        if (!enumerator.MoveNext())
                            Throw.InvalidOperationException();
                    }

                    // take
                    for (var counter = 0; counter < takeCount; counter++)
                    {
                        if (!enumerator.MoveNext())
                            Throw.InvalidOperationException();

                        if (comparer.Equals(enumerator.Current, value!))
                            return true;
                    }
                    return false;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> AsValueEnumerable()
                => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> Skip(int count)
            {
                var (skipCount, takeCount) = Partition.Skip(Count, count);
                return source.SkipTake<TEnumerable, TEnumerator, TSource>(this.skipCount + skipCount, takeCount);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> Take(int count)
                => source.SkipTake<TEnumerable, TEnumerator, TSource>(skipCount, Partition.Take(Count, count));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TEnumerable, TEnumerator, TSource>(this in SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source.Count;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator>(this SkipTakeEnumerable<TEnumerable, TEnumerator, int> source)
            where TEnumerable : IValueReadOnlyCollection<int, TEnumerator>
            where TEnumerator : struct, IEnumerator<int>
            => Sum<SkipTakeEnumerable<TEnumerable, TEnumerator, int>, SkipTakeEnumerable<TEnumerable, TEnumerator, int>.Enumerator, int, int>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator>(this SkipTakeEnumerable<TEnumerable, TEnumerator, int?> source)
            where TEnumerable : IValueReadOnlyCollection<int?, TEnumerator>
            where TEnumerator : struct, IEnumerator<int?>
            => Sum<SkipTakeEnumerable<TEnumerable, TEnumerator, int?>, SkipTakeEnumerable<TEnumerable, TEnumerator, int?>.Enumerator, int?, int>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator>(this SkipTakeEnumerable<TEnumerable, TEnumerator, long> source)
            where TEnumerable : IValueReadOnlyCollection<long, TEnumerator>
            where TEnumerator : struct, IEnumerator<long>
            => Sum<SkipTakeEnumerable<TEnumerable, TEnumerator, long>, SkipTakeEnumerable<TEnumerable, TEnumerator, long>.Enumerator, long, long>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator>(this SkipTakeEnumerable<TEnumerable, TEnumerator, long?> source)
            where TEnumerable : IValueReadOnlyCollection<long?, TEnumerator>
            where TEnumerator : struct, IEnumerator<long?>
            => Sum<SkipTakeEnumerable<TEnumerable, TEnumerator, long?>, SkipTakeEnumerable<TEnumerable, TEnumerator, long?>.Enumerator, long?, long>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator>(this SkipTakeEnumerable<TEnumerable, TEnumerator, float> source)
            where TEnumerable : IValueReadOnlyCollection<float, TEnumerator>
            where TEnumerator : struct, IEnumerator<float>
            => Sum<SkipTakeEnumerable<TEnumerable, TEnumerator, float>, SkipTakeEnumerable<TEnumerable, TEnumerator, float>.Enumerator, float, float>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator>(this SkipTakeEnumerable<TEnumerable, TEnumerator, float?> source)
            where TEnumerable : IValueReadOnlyCollection<float?, TEnumerator>
            where TEnumerator : struct, IEnumerator<float?>
            => Sum<SkipTakeEnumerable<TEnumerable, TEnumerator, float?>, SkipTakeEnumerable<TEnumerable, TEnumerator, float?>.Enumerator, float?, float>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator>(this SkipTakeEnumerable<TEnumerable, TEnumerator, double> source)
            where TEnumerable : IValueReadOnlyCollection<double, TEnumerator>
            where TEnumerator : struct, IEnumerator<double>
            => Sum<SkipTakeEnumerable<TEnumerable, TEnumerator, double>, SkipTakeEnumerable<TEnumerable, TEnumerator, double>.Enumerator, double, double>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator>(this SkipTakeEnumerable<TEnumerable, TEnumerator, double?> source)
            where TEnumerable : IValueReadOnlyCollection<double?, TEnumerator>
            where TEnumerator : struct, IEnumerator<double?>
            => Sum<SkipTakeEnumerable<TEnumerable, TEnumerator, double?>, SkipTakeEnumerable<TEnumerable, TEnumerator, double?>.Enumerator, double?, double>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator>(this SkipTakeEnumerable<TEnumerable, TEnumerator, decimal> source)
            where TEnumerable : IValueReadOnlyCollection<decimal, TEnumerator>
            where TEnumerator : struct, IEnumerator<decimal>
            => Sum<SkipTakeEnumerable<TEnumerable, TEnumerator, decimal>, SkipTakeEnumerable<TEnumerable, TEnumerator, decimal>.Enumerator, decimal, decimal>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator>(this SkipTakeEnumerable<TEnumerable, TEnumerator, decimal?> source)
            where TEnumerable : IValueReadOnlyCollection<decimal?, TEnumerator>
            where TEnumerator : struct, IEnumerator<decimal?>
            => Sum<SkipTakeEnumerable<TEnumerable, TEnumerator, decimal?>, SkipTakeEnumerable<TEnumerable, TEnumerator, decimal?>.Enumerator, decimal?, decimal>(source);
    }
}