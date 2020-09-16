using System;
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
        public static MemorySelectAtEnumerable<TSource, TResult> Select<TSource, TResult>(this ReadOnlyMemory<TSource> source, NullableSelectorAt<TSource, TResult> selector)
        {
            if (selector is null) Throw.ArgumentNullException(nameof(selector));

            return new MemorySelectAtEnumerable<TSource, TResult>(source, selector);
        }

        [GeneratorMapping("TSource", "TResult")]
        [GeneratorMapping("TResult", "TResult2")]
        [StructLayout(LayoutKind.Sequential)]
        public readonly partial struct MemorySelectAtEnumerable<TSource, TResult>
            : IValueReadOnlyList<TResult, MemorySelectAtEnumerable<TSource, TResult>.DisposableEnumerator>
            , IList<TResult>
        {
            internal readonly ReadOnlyMemory<TSource> source;
            internal readonly NullableSelectorAt<TSource, TResult> selector;

            internal MemorySelectAtEnumerable(ReadOnlyMemory<TSource> source, NullableSelectorAt<TSource, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public readonly int Count 
                => source.Length;

            [MaybeNull]
            public readonly TResult this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => selector(source.Span[index], index);
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
            readonly DisposableEnumerator IValueEnumerable<TResult, MemorySelectAtEnumerable<TSource, TResult>.DisposableEnumerator>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new DisposableEnumerator(in this);

            bool ICollection<TResult>.IsReadOnly  
                => true;

            void ICollection<TResult>.CopyTo(TResult[] array, int arrayAt) 
            {
                var span = source.Span;
                for (var index = 0; index < span.Length; index++)
                    array[index + arrayAt] = selector(span[index], index)!;
            }
            void ICollection<TResult>.Add(TResult item) 
                => Throw.NotSupportedException();
            void ICollection<TResult>.Clear() 
                => Throw.NotSupportedException();
            bool ICollection<TResult>.Contains(TResult item)
                => ArrayExtensions.Contains(source.Span, item, selector);
            bool ICollection<TResult>.Remove(TResult item) 
                => Throw.NotSupportedException<bool>();
            int IList<TResult>.IndexOf(TResult item)
            {
                var span = source.Span;
                if (Utils.IsValueType<TResult>())
                {
                    for (var index = 0; index < span.Length; index++)
                    {
                        if (EqualityComparer<TResult>.Default.Equals(selector(span[index], index)!, item))
                            return index;
                    }
                }
                else
                {
                    var defaultComparer = EqualityComparer<TResult>.Default;
                    for (var index = 0; index < span.Length; index++)
                    {
                        if (defaultComparer.Equals(selector(span[index], index)!, item))
                            return index;
                    }
                }
                return -1;
            }
            void IList<TResult>.Insert(int index, TResult item)
                => Throw.NotSupportedException();
            void IList<TResult>.RemoveAt(int index)
                => Throw.NotSupportedException();

            [StructLayout(LayoutKind.Sequential)]
            public ref struct Enumerator
            {
                int index;
                readonly ReadOnlySpan<TSource> source;
                readonly NullableSelectorAt<TSource, TResult> selector;

                internal Enumerator(in MemorySelectAtEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source.Span;
                    selector = enumerable.selector;
                    index = -1;
                }

                [MaybeNull]
                public readonly TResult Current 
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector(source[index], index);
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index < source.Length;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct DisposableEnumerator
                : IEnumerator<TResult>
            {
                int index;
                readonly ReadOnlyMemory<TSource> source;
                readonly NullableSelectorAt<TSource, TResult> selector;

                internal DisposableEnumerator(in MemorySelectAtEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    index = -1;
                }
 
                [MaybeNull]
                public readonly TResult Current 
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector(source.Span[index], index);
                }
                readonly TResult IEnumerator<TResult>.Current 
                    => selector(source.Span[index], index)!;
                readonly object? IEnumerator.Current
                    => selector(source.Span[index], index);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index < source.Length;

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Length != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult2> Select<TResult2>(NullableSelector<TResult, TResult2> selector)
                => ArrayExtensions.Select<TSource, TResult2>(source, Utils.Combine(this.selector, selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult2> Select<TResult2>(NullableSelectorAt<TResult, TResult2> selector)
                => ArrayExtensions.Select<TSource, TResult2>(source, Utils.Combine(this.selector, selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => ArrayExtensions.ElementAt<TSource, TResult>(source.Span, index, selector);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => ArrayExtensions.First<TSource, TResult>(source.Span, selector);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => ArrayExtensions.Single<TSource, TResult>(source.Span, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult[] ToArray()
                => ArrayExtensions.ToArray(source.Span, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TResult> ToList()
                => ArrayExtensions.ToList(source, selector); // memory performs best

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
        public static int Count<TSource, TResult>(this MemorySelectAtEnumerable<TSource, TResult> source)
            => source.Count;
    }
}

