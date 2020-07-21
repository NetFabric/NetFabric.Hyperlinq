using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemorySelectEnumerable<TSource, TResult> Select<TSource, TResult>(
            this ReadOnlyMemory<TSource> source, 
            NullableSelector<TSource, TResult> selector)
        {
            if (selector is null) Throw.ArgumentNullException(nameof(selector));

            return new MemorySelectEnumerable<TSource, TResult>(in source, selector);
        }

        [GeneratorMapping("TSource", "TResult")]
        public readonly partial struct MemorySelectEnumerable<TSource, TResult>
            : IValueReadOnlyList<TResult, MemorySelectEnumerable<TSource, TResult>.DisposableEnumerator>
            , IList<TResult>
        {
            internal readonly ReadOnlyMemory<TSource> source;
            internal readonly NullableSelector<TSource, TResult> selector;

            internal MemorySelectEnumerable(in ReadOnlyMemory<TSource> source, NullableSelector<TSource, TResult> selector)
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
                get => selector(source.Span[index]);
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
            readonly DisposableEnumerator IValueEnumerable<TResult, MemorySelectEnumerable<TSource, TResult>.DisposableEnumerator>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new DisposableEnumerator(in this);


            bool ICollection<TResult>.IsReadOnly  
                => true;

            void ICollection<TResult>.CopyTo(TResult[] array, int arrayIndex) 
            {
                var span = source.Span;
                for (var index = 0; index < source.Length; index++)
                    array[index + arrayIndex] = selector(span[index])!;
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
                if (default(TResult) is object)
                {
                    for (var index = 0; index < source.Length; index++)
                    {
                        if (EqualityComparer<TResult>.Default.Equals(selector(span[index])!, item))
                            return index;
                    }
                }
                else
                {
                    var defaultComparer = EqualityComparer<TResult>.Default;
                    for (var index = 0; index < source.Length; index++)
                    {
                        if (defaultComparer.Equals(selector(span[index])!, item))
                            return index;
                    }
                }
                return -1;
            }
            void IList<TResult>.Insert(int index, TResult item)
                => Throw.NotSupportedException();
            void IList<TResult>.RemoveAt(int index)
                => Throw.NotSupportedException();

            public ref struct Enumerator
            {
                readonly ReadOnlySpan<TSource> source;
                readonly NullableSelector<TSource, TResult> selector;
                readonly int end;
                int index;

                internal Enumerator(in MemorySelectEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source.Span;
                    selector = enumerable.selector;
                    index = -1;
                    end = index + source.Length;
                }

                [MaybeNull]
                public readonly TResult Current 
                    => selector(source[index]);

                public bool MoveNext() 
                    => ++index <= end;
            }

            public struct DisposableEnumerator
                : IEnumerator<TResult>
            {
                readonly ReadOnlyMemory<TSource> source;
                readonly NullableSelector<TSource, TResult> selector;
                readonly int end;
                int index;

                internal DisposableEnumerator(in MemorySelectEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    index = -1;
                    end = index + source.Length;
                }

                [MaybeNull]
                public readonly TResult Current 
                    => selector(source.Span[index]);
                readonly TResult IEnumerator<TResult>.Current 
                    => selector(source.Span[index])!;
                readonly object? IEnumerator.Current
                    => selector(source.Span[index]);

                public bool MoveNext() 
                    => ++index <= end;

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Length != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => ArrayExtensions.ElementAt<TSource, TResult>(source.Span, index, selector);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => ArrayExtensions.First<TSource, TResult>(source.Span, selector);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => ArrayExtensions.Single<TSource, TResult>(source.Span, selector);

            public TResult[] ToArray()
                => ArrayExtensions.ToArray(source.Span, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IMemoryOwner<TResult> ToArray(MemoryPool<TResult> pool)
                => ArrayExtensions.ToArray<TSource, TResult>(source, selector, pool);

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
        public static int Count<TSource, TResult>(this MemorySelectEnumerable<TSource, TResult> source)
            => source.Count;
    }
}

