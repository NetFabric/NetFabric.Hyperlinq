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
                (this.skipCount, Count) = Utils.SkipTake(source.Count, skipCount, takeCount);
            }

            public readonly int Count { get; }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() 
                => new(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new Enumerator(in this);

            bool ICollection<TSource>.IsReadOnly  
                => true;

            public void CopyTo(Span<TSource> span)
            {
                if (span.Length < Count)
                    Throw.ArgumentException(Resource.DestinationNotLongEnough, nameof(span));

                if (Count is 0)
                    return;

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
                => CopyTo(array.AsSpan().Slice(arrayIndex));

            public bool Contains(TSource item)
            {
                if (Count is 0)
                    return false;

                if (skipCount is 0 && Count == source.Count && source is ICollection<TSource> collection)
                    return collection.Contains(item);

                using var enumerator = source.GetEnumerator();

                // skip
                for (var counter = 0; counter < skipCount; counter++)
                {
                    if (!enumerator.MoveNext())
                        Throw.InvalidOperationException();
                }

                // take
                if (Utils.IsValueType<TSource>())
                {
                    for (var counter = 0; counter < Count; counter++)
                    {
                        if (!enumerator.MoveNext())
                            Throw.InvalidOperationException();

                        if (EqualityComparer<TSource>.Default.Equals(enumerator.Current, item))
                            return true;
                    }
                }
                else
                {
                    var defaultComparer = EqualityComparer<TSource>.Default;
                    for (var counter = 0; counter < Count; counter++)
                    {
                        if (!enumerator.MoveNext())
                            Throw.InvalidOperationException();

                        if (defaultComparer.Equals(enumerator.Current, item))
                            return true;
                    }
                }
                return false;
            }

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

                if (comparer is null || ReferenceEquals(comparer, EqualityComparer<TSource>.Default))
                {
                    if (skipCount is 0 && Count == source.Count && source is ICollection<TSource> collection)
                        return collection.Contains(value);

                    if (Utils.IsValueType<TSource>())
                        return DefaultContains(source, value, skipCount, Count);
                }

                comparer ??= EqualityComparer<TSource>.Default;
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

                static bool ComparerContains(TEnumerable source, TSource value, IEqualityComparer<TSource> comparer, int skipCount, int takeCount)
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

                        if (comparer.Equals(enumerator.Current, value!))
                            return true;
                    }
                    return false;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> Take(int count)
                => source.SkipTake<TEnumerable, TEnumerator, TSource>(skipCount, Math.Min(Count, count));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TEnumerable, TEnumerator, TSource>(this in SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source.Count;
    }
}