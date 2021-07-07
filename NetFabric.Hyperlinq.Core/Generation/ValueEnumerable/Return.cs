using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        
        public static ReturnEnumerable<TSource> Return<TSource>(TSource value) =>
            new(value);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ReturnEnumerable<TSource>
            : IValueReadOnlyList<TSource, ReturnEnumerable<TSource>.DisposableEnumerator>
            , IList<TSource>
        {
            readonly TSource value;

            internal ReturnEnumerable(TSource value) 
                => this.value = value;

            public int Count 
                => 1;

            
            public TSource this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => index switch
                {
                    0 => value,
                    _ => Throw.ArgumentOutOfRangeException<TSource>(nameof(index))
                };
            }

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

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(Span<TSource> span)
            {
                if (span.Length < Count)
                    Throw.ArgumentException(Resource.DestinationNotLongEnough, nameof(span));

                span[0] = value;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(TSource[] array, int arrayIndex)
                => CopyTo(array.AsSpan(arrayIndex));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource item)
                => EqualityComparer<TSource>.Default.Equals(value, item);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            int IList<TSource>.IndexOf(TSource item)
                => EqualityComparer<TSource>.Default.Equals(value, item) switch
                {
                    true => 0,
                    _ => -1
                };

            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Add(TSource item) 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Clear() 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            bool ICollection<TSource>.Remove(TSource item) 
                => Throw.NotSupportedException<bool>();

            [ExcludeFromCodeCoverage]
            void IList<TSource>.Insert(int index, TSource item)
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void IList<TSource>.RemoveAt(int index)
                => Throw.NotSupportedException();

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
            {
                bool moveNext;

                internal Enumerator(in ReturnEnumerable<TSource> enumerable)
                    => (Current, moveNext) = (enumerable.value, true);

                
                public TSource Current { get; }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    var previous = moveNext;
                    moveNext = false;
                    return previous;
                }
            }

            [StructLayout(LayoutKind.Auto)]
            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                bool moveNext;

                internal DisposableEnumerator(in ReturnEnumerable<TSource> enumerable)
                {
                    Current = enumerable.value;
                    moveNext = true;
                }

                
                public TSource Current { get; }
                readonly TSource IEnumerator<TSource>.Current 
                    => Current;
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => Current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    var previous = moveNext;
                    moveNext = false;
                    return previous;
                }

                [ExcludeFromCodeCoverage]
                public void Reset() 
                    => moveNext = true;

                public readonly void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => true;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer)
                => comparer switch
                {
                    null => EqualityComparer<TSource>.Default.Equals(this.value, value),
                    _ => comparer.Equals(this.value, value)
                };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReturnEnumerable<TResult> Select<TResult, TSelector>(TSelector selector = default) 
                where TSelector : struct, IFunction<TSource, TResult>
                => new(selector.Invoke(value));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> ElementAt(int index)
                => index switch
                { 
                    0 => Option.Some(value),
                    _ => Option.None,
                };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> First()
                => Option.Some(value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> Single()
                => Option.Some(value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                => new TSource[] { value };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => new(1) { value };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                => new(new Dictionary<TKey, TSource>(1, comparer) { { keySelector.Invoke(value), value } });

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                where TElementSelector : struct, IFunction<TSource, TElement>
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                => new(new Dictionary<TKey, TElement>(1, comparer) { { keySelector.Invoke(value), elementSelector.Invoke(value) } });
        }

#pragma warning disable IDE0060 // Remove unused parameter
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this in ReturnEnumerable<TSource> source)
            => 1;
#pragma warning restore IDE0060 // Remove unused parameter
    }
}

