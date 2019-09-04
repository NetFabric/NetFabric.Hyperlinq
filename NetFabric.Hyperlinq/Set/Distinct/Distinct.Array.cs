using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DistinctEnumerable<TSource> Distinct<TSource>(
            this TSource[] source, 
            IEqualityComparer<TSource> comparer = null)
            => new DistinctEnumerable<TSource>(source, comparer, 0, source.Length);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static DistinctEnumerable<TSource> Distinct<TSource>(
            this TSource[] source,
            IEqualityComparer<TSource> comparer,
            int skipCount, int takeCount)
            => new DistinctEnumerable<TSource>(source, comparer, skipCount, takeCount);

        public readonly struct DistinctEnumerable<TSource>
            : IValueEnumerable<TSource, DistinctEnumerable<TSource>.Enumerator>
        {
            readonly TSource[] source;
            readonly IEqualityComparer<TSource> comparer;
            internal readonly int skipCount;
            internal readonly int takeCount;

            internal DistinctEnumerable(TSource[] source, IEqualityComparer<TSource> comparer, int skipCount, int takeCount)
            {
                this.source = source;
                this.comparer = comparer;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Length, skipCount, takeCount);
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IEnumerator<TSource>
            {
                readonly TSource[] source;
                readonly HashSet<TSource> set;
                readonly int end;
                int index;
                TSource current;

                internal Enumerator(in DistinctEnumerable<TSource> enumerable)
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

                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => current;
                }
                readonly object IEnumerator.Current => current;

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
                    return false;
                }

                public readonly void Reset() => throw new NotSupportedException();

                public readonly void Dispose() { }
            }

            // helper function for optimization of non-lazy operations
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly HashSet<TSource> FillSet() 
                => new HashSet<TSource>(source, comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly DistinctEnumerable<TSource> Skip(int count)
                => new DistinctEnumerable<TSource>(source, comparer, skipCount + count, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly DistinctEnumerable<TSource> Take(int count)
                => new DistinctEnumerable<TSource>(source, comparer, skipCount, Math.Min(takeCount, count));


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly int Count()
                => FillSet().Count;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly long LongCount()
                => FillSet().Count;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any()
                => FillSet().Count != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly TSource[] ToArray()
                => HashSetBindings.ToArray<TSource>(FillSet());

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly List<TSource> ToList()
                => HashSetBindings.ToList<TSource>(FillSet());
        }
    }
}

