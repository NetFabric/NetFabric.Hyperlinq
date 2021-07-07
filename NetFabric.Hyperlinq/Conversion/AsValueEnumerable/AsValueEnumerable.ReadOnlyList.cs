using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerable<IReadOnlyList<TSource>, TSource> AsValueEnumerable<TSource>(this IReadOnlyList<TSource> source)
            => new(source);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerable<TList, TSource> AsValueEnumerable<TList, TSource>(this TList source)
            where TList : IReadOnlyList<TSource>
            => new(source);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ValueEnumerable<TList, TSource>
            : IValueReadOnlyList<TSource, ValueEnumerator<TSource>>
            , IList<TSource>
            where TList : IReadOnlyList<TSource>
        {
            readonly TList source;

            internal ValueEnumerable(TList source) 
                => this.source = source;

            public TSource this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source[index];
            }

            TSource IList<TSource>.this[int index]
            {
                get => source[index];
                [DoesNotReturn]
                // ReSharper disable once ValueParameterNotUsed
                set => Throw.NotSupportedException();
            }

            public int Count
                => source.Count;

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerator<TSource> GetEnumerator() 
                => new(source.GetEnumerator());
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => source.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() 
                => source.GetEnumerator();

            bool ICollection<TSource>.IsReadOnly  
                => true;

            public void CopyTo(Span<TSource> span)
            {
                if (Count is 0)
                    return;
                
                if (span.Length < Count)
                    Throw.ArgumentException(Resource.DestinationNotLongEnough, nameof(span));

                using var enumerator = GetEnumerator();
                checked
                {
                    for (var index = 0; enumerator.MoveNext(); index++)
                        span[index] = enumerator.Current;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(TSource[] array)
                => CopyTo(array, 0);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(TSource[] array, int arrayIndex)
            {
                switch (source)
                {
                    case ICollection<TSource> collection:
                        collection.CopyTo(array, arrayIndex);
                        break;
                    default:
                        CopyTo(array.AsSpan(arrayIndex));
                        break;
                }
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource item)
                => Count is not 0 && source.Contains(item);

            public int IndexOf(TSource item)
            {
                return source switch
                {
                    IList<TSource> list => list.IndexOf(item),
                    _ => IndexOfEnumerable(this, item),
                };

                static int IndexOfEnumerable(ValueEnumerable<TList, TSource> source, TSource item)
                {
                    using var enumerator = source.GetEnumerator();
                    for (var index = 0; enumerator.MoveNext(); index++)
                    {
                        if (EqualityComparer<TSource>.Default.Equals(enumerator.Current, item))
                            return index;
                    }
                    return -1;
                }
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

            [ExcludeFromCodeCoverage]
            void IList<TSource>.Insert(int index, TSource item) 
                => Throw.NotSupportedException<bool>();
            [ExcludeFromCodeCoverage]
            void IList<TSource>.RemoveAt(int index) 
                => Throw.NotSupportedException<bool>();

            #region Partitioning

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<ValueEnumerable<TList, TSource>, TSource> Skip(int count)
                => this.Skip<ValueEnumerable<TList, TSource>, TSource>(count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<ValueEnumerable<TList, TSource>, TSource> Take(int count)
                => this.Take<ValueEnumerable<TList, TSource>, TSource>(count);

            #endregion
        }
    }
}