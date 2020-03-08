using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        public static MemorySelectEnumerable<TSource, TResult> Select<TSource, TResult>(
            this ReadOnlyMemory<TSource> source, 
            Selector<TSource, TResult> selector)
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
            internal readonly Selector<TSource, TResult> selector;

            internal MemorySelectEnumerable(in ReadOnlyMemory<TSource> source, Selector<TSource, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public readonly int Count => source.Length;

            [MaybeNull]
            public readonly TResult this[int index]
            {
                get
                {
                    if (index < 0 || index >= source.Length)
                        Throw.ArgumentOutOfRangeException(nameof(index));

                    return selector(source.Span[index]);
                }
            }

            [Pure]
            public readonly Enumerator GetEnumerator() 
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TResult, MemorySelectEnumerable<TSource, TResult>.DisposableEnumerator>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new DisposableEnumerator(in this);

            [MaybeNull]
            TResult IList<TResult>.this[int index]
            {
                get => this[index];
                set => throw new NotImplementedException();
            }

            bool ICollection<TResult>.IsReadOnly  
                => true;

            void ICollection<TResult>.CopyTo(TResult[] array, int arrayIndex) 
            {
                var span = source.Span;
                for (var index = 0; index < source.Length; index++)
                    array[index + arrayIndex] = selector(span[index]);
            }
            void ICollection<TResult>.Add(TResult item) 
                => throw new NotImplementedException();
            void ICollection<TResult>.Clear() 
                => throw new NotImplementedException();
            bool ICollection<TResult>.Contains(TResult item) 
            {
                var span = source.Span;
                for (var index = 0; index < source.Length; index++)
                {
                    if (EqualityComparer<TResult>.Default.Equals(selector(span[index]), item))
                        return true;
                }
                return false;
            }
            bool ICollection<TResult>.Remove(TResult item) 
                => throw new NotImplementedException();
            int IList<TResult>.IndexOf(TResult item)
            {
                var span = source.Span;
                for (var index = 0; index < source.Length; index++)
                {
                    if (EqualityComparer<TResult>.Default.Equals(selector(span[index]), item))
                        return index;
                }
                return -1;
            }
            void IList<TResult>.Insert(int index, TResult item)
                => throw new NotImplementedException();
            void IList<TResult>.RemoveAt(int index)
                => throw new NotImplementedException();

            public ref struct Enumerator
            {
                readonly ReadOnlySpan<TSource> source;
                readonly Selector<TSource, TResult> selector;
                int index;

                internal Enumerator(in MemorySelectEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source.Span;
                    selector = enumerable.selector;
                    index = -1;
                }

                public readonly TResult Current 
                    => selector(source[index]);

                public bool MoveNext() 
                    => ++index < source.Length;
            }

            public struct DisposableEnumerator
                : IEnumerator<TResult>
            {
                readonly ReadOnlyMemory<TSource> source;
                readonly Selector<TSource, TResult> selector;
                int index;

                internal DisposableEnumerator(in MemorySelectEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    index = -1;
                }
 
                [MaybeNull] 
                public readonly TResult Current 
                    => selector(source.Span[index]);
                readonly object? IEnumerator.Current 
                    => selector(source.Span[index]);

                public bool MoveNext() 
                    => ++index < source.Length;

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => throw new NotSupportedException();

                public void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Length != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TResult value, IEqualityComparer<TResult>? comparer = null)
                => Array.Contains<TSource, TResult>(source.Span, value, comparer, selector);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult ElementAt(int index)
                => Array.ElementAt<TSource, TResult>(source.Span, index, selector);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TResult ElementAtOrDefault(int index)
                => Array.ElementAtOrDefault<TSource, TResult>(source.Span, index, selector);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult First()
                => Array.First<TSource, TResult>(source.Span, selector);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TResult FirstOrDefault()
                => Array.FirstOrDefault<TSource, TResult>(source.Span, selector);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult Single()
                => Array.Single<TSource, TResult>(source.Span, selector);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TResult SingleOrDefault()
                => Array.SingleOrDefault<TSource, TResult>(source.Span, selector);

            public TResult[] ToArray()
                => Array.ToArray(source.Span, selector);

            public List<TResult> ToList()
                => Array.ToList(source, selector); // memory performs best

            public void ForEach(Action<TResult> action)
                => Array.ForEach(source.Span, action, selector);
            public void ForEach(ActionAt<TResult> action)
                => Array.ForEach(source.Span, action, selector);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource, TResult>(this MemorySelectEnumerable<TSource, TResult> source)
            => source.Count;
    }
}

