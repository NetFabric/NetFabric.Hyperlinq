using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DistinctEnumerable<TEnumerable, TEnumerator, TSource> Distinct<TEnumerable, TEnumerator, TSource>(
            this TEnumerable source, 
            IEqualityComparer<TSource> comparer = null)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => new DistinctEnumerable<TEnumerable, TEnumerator, TSource>(source, comparer);

        public readonly struct DistinctEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueEnumerable<TSource, DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly IEqualityComparer<TSource> comparer;

            internal DistinctEnumerable(TEnumerable source, IEqualityComparer<TSource> comparer)
            {
                this.source = source;
                this.comparer = comparer;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IEnumerator<TSource>
            {
                readonly TEnumerator enumerator;
                readonly IEqualityComparer<TSource> comparer;
                readonly HashSet<TSource> set;

                internal Enumerator(in DistinctEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    comparer = enumerable.comparer;
                    set = new HashSet<TSource>(enumerable.comparer);
                }

                public TSource Current => enumerator.Current;
                object IEnumerator.Current => enumerator.Current;

                public bool MoveNext()
                {
                    while (enumerator.MoveNext())
                    {
                        if (set.Add(enumerator.Current))
                            return true;
                    }
                    Dispose();
                    return false;
                }

                void IEnumerator.Reset() => throw new NotSupportedException();

                public void Dispose() => set.Clear();
            }

            // helper function for optimization of non-lazy operations
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            HashSet<TSource> FillSet() 
                => new HashSet<TSource>(source, comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count()
                => FillSet().Count;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => FillSet().Count != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => HashSetBindings.ToArray<TSource>(FillSet());

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => HashSetBindings.ToList<TSource>(FillSet());
        }
    }
}

