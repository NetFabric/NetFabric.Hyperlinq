using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableWrapper<TSource> AsValueEnumerable<TSource>(this IReadOnlyList<TSource> source)
            => new ValueEnumerableWrapper<TSource>(source);

        public readonly partial struct ValueEnumerableWrapper<TSource>
            : IValueReadOnlyList<TSource, ValueEnumerableWrapper<TSource>.Enumerator>
            , IList<TSource>
        {
            readonly IReadOnlyList<TSource> source;

            internal ValueEnumerableWrapper(IReadOnlyList<TSource> source) 
                => this.source = source;

            public readonly int Count
                => source.Count;

            [MaybeNull]
            public readonly TSource this[int index]
                => source[index];
            TSource IReadOnlyList<TSource>.this[int index]
                => source[index];
            TSource IList<TSource>.this[int index]
            {
                get => source[index];
                set => Throw.NotSupportedException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(source);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(source);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(source);


            bool ICollection<TSource>.IsReadOnly  
                => true;

            public void CopyTo(TSource[] array, int arrayIndex) 
            {
                if (source.Count == 0)
                    return;

                if (source is ICollection<TSource> collection)
                {
                    collection.CopyTo(array, arrayIndex);
                }
                else
                {
                    for (var index = 0; index < source.Count; index++)
                        array[arrayIndex + index] = source[index];
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            bool ICollection<TSource>.Contains(TSource item) 
                => ReadOnlyListExtensions.Contains(source, item);

            public int IndexOf(TSource item)
            {
                if (source.Count == 0)
                    return -1;

                if (source is IList<TSource> list)
                    return list.IndexOf(item);

                if (default(TSource) is object)
                {
                    for (var index = 0; index < source.Count; index++)
                    {
                        if (EqualityComparer<TSource>.Default.Equals(source[index], item))
                            return index;
                    }
                }
                else
                {
                    var defaultComparer = EqualityComparer<TSource>.Default;
                    for (var index = 0; index < source.Count; index++)
                    {
                        if (defaultComparer.Equals(source[index], item))
                            return index;
                    }
                }
                return -1;
            }

            void ICollection<TSource>.Add(TSource item)
                => Throw.NotSupportedException();
            bool ICollection<TSource>.Remove(TSource item)
                => Throw.NotSupportedException<bool>();
            void ICollection<TSource>.Clear()
                => Throw.NotSupportedException();

            void IList<TSource>.Insert(int index, TSource item)
                => Throw.NotSupportedException();
            void IList<TSource>.RemoveAt(int index)
                => Throw.NotSupportedException();

            public struct Enumerator
                : IEnumerator<TSource>
            {
                readonly IReadOnlyList<TSource> source;
                int index;

                internal Enumerator(IReadOnlyList<TSource> source) 
                {
                    this.source = source;
                    index = -1;
                }

                [MaybeNull]
                public readonly TSource Current 
                    => source[index];
                readonly TSource IEnumerator<TSource>.Current 
                    => source[index];
                readonly object? IEnumerator.Current
                    => source[index];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index < source.Count;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                [ExcludeFromCodeCoverage]
                public void Reset() 
                    => index = -1;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public readonly void Dispose() { }
            }

            public bool Contains([AllowNull] TSource value, IEqualityComparer<TSource>? comparer = default)
                => ReadOnlyListExtensions.Contains(source, value, comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => ReadOnlyListExtensions.ToArray<IReadOnlyList<TSource>, TSource>(source);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => ReadOnlyListExtensions.ToList<IReadOnlyList<TSource>, TSource>(source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this ValueEnumerableWrapper<TSource> source)
            => source.Count;
    }
}