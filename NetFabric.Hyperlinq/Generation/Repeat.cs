using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static RepeatEnumerable<TSource> Repeat<TSource>(TSource value, int count)
        {
            if (count < 0) ThrowHelper.ThrowArgumentOutOfRangeException(nameof(count));

            return new RepeatEnumerable<TSource>(value, count);
        }

        [GenericsTypeMapping("TEnumerable", typeof(RepeatEnumerable<>))]
        [GenericsTypeMapping("TEnumerator", typeof(RepeatEnumerable<>.Enumerator))]
        public readonly struct RepeatEnumerable<TSource>
            : IValueReadOnlyList<TSource, RepeatEnumerable<TSource>.Enumerator>
        {
            internal readonly TSource value;
            internal readonly int count;

            internal RepeatEnumerable(TSource value, int count)
            {
                this.value = value;
                this.count = count;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public int Count => count;

            public TSource this[int index]
            {
                get
                {
                    if (index < 0 || index >= count) ThrowHelper.ThrowIndexOutOfRangeException();

                    return value;
                }
            }

            public struct Enumerator
                : IEnumerator<TSource>
            {
                readonly TSource value;
                int counter;

                internal Enumerator(in RepeatEnumerable<TSource> enumerable)
                {
                    value = enumerable.value;
                    counter = enumerable.count;
                }

                public TSource Current
                    => value;
                object IEnumerator.Current
                    => value;

                public bool MoveNext()
                    => counter-- > 0;

                void IEnumerator.Reset()
                    => throw new NotSupportedException();

                public void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RepeatEnumerable<TSource> Skip(int count)
            {
                (_, var takeCount) = Utils.Skip(this.count, count);
                return Repeat(value, takeCount);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RepeatEnumerable<TSource> Take(int count)
                => Repeat(value, Utils.Take(this.count, count));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, bool> predicate)
                => count == 0 ? true : predicate(value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => count != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value)
                => count != 0 && this.value.Equals(value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value, IEqualityComparer<TSource> comparer)
                => count != 0 && comparer.Equals(this.value, value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RepeatEnumerable<TResult> Select<TResult>(Func<TSource, TResult> selector) 
                => new RepeatEnumerable<TResult>(selector(value), count);

            public TSource[] ToArray()
            {
                var array = new TSource[count];
                if (value is object)
                {
#if NETCORE    
                    System.Array.Fill<TSource>(array, value);
#else                
                    for (var index = 0; index < count; index++)
                        array[index] = value;
#endif
                }
                return array;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => new List<TSource>(new ToListCollection(this));

            // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
            class ToListCollection
                : ICollection<TSource>
            {
                readonly TSource value;
                readonly int count;

                public ToListCollection(in RepeatEnumerable<TSource> source)
                {
                    this.value = source.value;
                    this.count = source.count;
                }

                public int Count => count;

                public bool IsReadOnly => true;

                public void CopyTo(TSource[] array, int _)
                {
                    if (value == null)
                        return; // no need to initialize
                        
                    for(var index = 0; index < count; index++)
                        array[index] = value;
                }

                IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => throw new NotSupportedException();
                IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
                void ICollection<TSource>.Add(TSource item) => throw new NotSupportedException();
                bool ICollection<TSource>.Remove(TSource item) => throw new NotSupportedException();
                void ICollection<TSource>.Clear() => throw new NotSupportedException();
                bool ICollection<TSource>.Contains(TSource item) => throw new NotSupportedException();
            }
        }
    }
}

