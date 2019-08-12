using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DistinctEnumerable<TEnumerable, TEnumerator, TSource> Distinct<TEnumerable, TEnumerator, TSource>(
            this TEnumerable source, 
            IEqualityComparer<TSource> comparer = null)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => new DistinctEnumerable<TEnumerable, TEnumerator, TSource>(source, comparer, 0, source.Count);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static DistinctEnumerable<TEnumerable, TEnumerator, TSource> Distinct<TEnumerable, TEnumerator, TSource>(
            this TEnumerable source,
            IEqualityComparer<TSource> comparer,
            int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => new DistinctEnumerable<TEnumerable, TEnumerator, TSource>(source, comparer, skipCount, takeCount);

        public readonly struct DistinctEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueEnumerable<TSource, DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly IEqualityComparer<TSource> comparer;
            internal readonly int skipCount;
            internal readonly int takeCount;

            internal DistinctEnumerable(TEnumerable source, IEqualityComparer<TSource> comparer, int skipCount, int takeCount)
            {
                this.source = source;
                this.comparer = comparer;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Count, skipCount, takeCount);
            }

            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IEnumerator<TSource>
            {
                readonly TEnumerable source;
                readonly HashSet<TSource> set;
                readonly int end;
                int index;
                TSource current;

                internal Enumerator(in DistinctEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    source = enumerable.source;
#if NET461 || NETSTANDARD2_0                   
                    set = new HashSet<TSource>(enumerable.comparer);
#else
                    set = new HashSet<TSource>(enumerable.takeCount, enumerable.comparer);
#endif
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                    current = default;
                }

                public TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => current;
                }
                object IEnumerator.Current => current;

                public bool MoveNext()
                {
                    while (++index < end)
                    {
                        if (set.Add(source[index]))
                        {
                            current = source[index];
                            return true;
                        }
                    }
                    Dispose();
                    return false;
                }

                readonly void IEnumerator.Reset() => throw new NotSupportedException();

                public void Dispose() => set.Clear();
            }

            // helper function for optimization of non-lazy operations
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            HashSet<TSource> FillSet() 
                => new HashSet<TSource>(source, comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public DistinctEnumerable<TEnumerable, TEnumerator, TSource> Skip(int count)
                => new DistinctEnumerable<TEnumerable, TEnumerator, TSource>(source, comparer, skipCount + count, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public DistinctEnumerable<TEnumerable, TEnumerator, TSource> Take(int count)
                => new DistinctEnumerable<TEnumerable, TEnumerator, TSource>(source, comparer, skipCount, Math.Min(takeCount, count));


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

