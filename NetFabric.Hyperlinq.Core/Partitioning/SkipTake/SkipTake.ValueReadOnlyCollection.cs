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

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueReadOnlyCollection<TSource, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            , ICollection<TSource>
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly int offset;

            internal SkipTakeEnumerable(in TEnumerable source, int offset, int count)
                => (this.source, this.offset, Count) = (source, offset, count);

            internal SkipTakeEnumerable(in TEnumerable source, (int Offset, int Count) slice)
                => (this.source, offset, Count) = (source, slice.Offset, slice.Count);

            public int Count { get; }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator GetEnumerator() 
                => new(in this);

            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => new Enumerator(in this);

            IEnumerator IEnumerable.GetEnumerator() 
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
                for (var counter = 0; counter < offset; counter++)
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
                if (offset is 0 && Count == source.Count && source is ICollection<TSource> collection)
                    collection.CopyTo(array, arrayIndex);
                else
                    CopyTo(array.AsSpan(arrayIndex));
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
#pragma warning disable IDE0044 // Add readonly modifier
                TEnumerator enumerator;
#pragma warning restore IDE0044 // Add readonly modifier
                int skipCounter;
                int takeCounter;
                EnumeratorState state;

                internal Enumerator(in SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    skipCounter = enumerable.offset;
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
                [DoesNotReturn]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public void Dispose() 
                    => enumerator.Dispose();
            }

            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer)
            {
                if (source.Count is 0)
                    return false;

                if (comparer.UseDefaultComparer())
                {
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    if (offset is 0 && Count == source.Count && source is ICollection<TSource> collection)
                        return collection.Contains(value);

                    return DefaultContains(source, value, offset, Count);
                }

                return ComparerContains(source, value, comparer, offset, Count);

                static bool DefaultContains(TEnumerable source, TSource value, int offset, int count)
                {
                    using var enumerator = source.GetEnumerator();

                    // skip
                    for (var counter = 0; counter < offset; counter++)
                    {
                        if (!enumerator.MoveNext())
                            Throw.InvalidOperationException();
                    }

                    // take
                    for (var counter = 0; counter < count; counter++)
                    {
                        if (!enumerator.MoveNext())
                            Throw.InvalidOperationException();

                        if (EqualityComparer<TSource>.Default.Equals(enumerator.Current, value!))
                            return true;
                    }
                    return false;
                }

                static bool ComparerContains(TEnumerable source, TSource value, IEqualityComparer<TSource>? comparer, int offset, int count)
                {
                    comparer ??= EqualityComparer<TSource>.Default;
                    using var enumerator = source.GetEnumerator();

                    // skip
                    for (var counter = 0; counter < offset; counter++)
                    {
                        if (!enumerator.MoveNext())
                            Throw.InvalidOperationException();
                    }

                    // take
                    for (var counter = 0; counter < count; counter++)
                    {
                        if (!enumerator.MoveNext())
                            Throw.InvalidOperationException();

                        if (comparer.Equals(enumerator.Current, value!))
                            return true;
                    }
                    return false;
                }
            }

            #region Partitioning

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> Skip(int count)
            {
                var (newOffset, newCount) = Utils.Skip(Count, count);
                return new SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>(source, offset + newOffset, newCount);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> Take(int count)
                => new(source, offset, Utils.Take(Count, count));
            
            #endregion
        }
    }
}