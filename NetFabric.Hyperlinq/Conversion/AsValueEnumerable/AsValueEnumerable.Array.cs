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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayValueEnumerableWrapper<TSource> AsValueEnumerable<TSource>(this TSource[] source)
            => new ArrayValueEnumerableWrapper<TSource>(source);

        public readonly partial struct ArrayValueEnumerableWrapper<TSource>
            : IValueReadOnlyList<TSource, ArrayValueEnumerableWrapper<TSource>.DisposableEnumerator>
            , IList<TSource>
        {
            readonly TSource[] source;

            internal ArrayValueEnumerableWrapper(TSource[] source) 
                => this.source = source;

            public readonly int Count => source.Length;

            [MaybeNull]
            public readonly ref readonly TSource this[int index] 
                => ref source[index];

            [Pure]
            public readonly Enumerator GetEnumerator() 
                => new Enumerator(source);
            readonly DisposableEnumerator IValueEnumerable<TSource, ArrayValueEnumerableWrapper<TSource>.DisposableEnumerator>.GetEnumerator() 
                => new DisposableEnumerator(source);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => new DisposableEnumerator(source);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new DisposableEnumerator(source);

            [MaybeNull]
            TSource IList<TSource>.this[int index]
            {
                get => source[index];
                set => throw new NotImplementedException();
            }

            [MaybeNull]
            TSource IReadOnlyList<TSource>.this[int index]
                => source[index];

            bool ICollection<TSource>.IsReadOnly  
                => true;

            void ICollection<TSource>.CopyTo(TSource[] array, int arrayIndex) 
                => source.CopyTo(array, arrayIndex);
            void ICollection<TSource>.Add(TSource item) 
                => throw new NotImplementedException();
            void ICollection<TSource>.Clear() 
                => throw new NotImplementedException();
            bool ICollection<TSource>.Contains(TSource item) 
                => source.Contains(item);
            bool ICollection<TSource>.Remove(TSource item) 
                => throw new NotImplementedException();
            int IList<TSource>.IndexOf(TSource item)
            {
                for (var index = 0; index < source.Length; index++)
                {
                    if (EqualityComparer<TSource>.Default.Equals(source[index], item))
                        return index;
                }
                return -1;
            }
            void IList<TSource>.Insert(int index, TSource item)
                => throw new NotImplementedException();
            void IList<TSource>.RemoveAt(int index)
                => throw new NotImplementedException();

            public struct Enumerator
            {
                readonly TSource[] source;
                int index;

                internal Enumerator(TSource[] source)
                {
                    this.source = source;
                    index = -1;
                }

                [MaybeNull]
                public readonly ref readonly TSource Current 
                    => ref source[index];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() => ++index < source.Length;
            }

            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                readonly TSource[] source;
                int index;

                internal DisposableEnumerator(TSource[] source)
                {
                    this.source = source;
                    index = -1;
                }

                [MaybeNull]
                public readonly ref readonly TSource Current 
                    => ref source[index];
                [MaybeNull]
                readonly TSource IEnumerator<TSource>.Current 
                    => source[index];
                readonly object? IEnumerator.Current 
                    => source[index];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() => ++index < source.Length;

                [ExcludeFromCodeCoverage]
                public void Reset() => index = -1;

                public readonly void Dispose() { }
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => Array.ToArray(source);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => Array.ToList(source);
        }

        public static int Count<TSource>(this ArrayValueEnumerableWrapper<TSource> source)
            => source.Count;
    }
}