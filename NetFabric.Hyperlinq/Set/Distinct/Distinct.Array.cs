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
        public static ArrayDistinctEnumerable<TSource> Distinct<TSource>(
            this TSource[] source, 
            IEqualityComparer<TSource>? comparer = null)
            => new ArrayDistinctEnumerable<TSource>(source, comparer, 0, source.Length);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ArrayDistinctEnumerable<TSource> Distinct<TSource>(
            this TSource[] source,
            IEqualityComparer<TSource>? comparer,
            int skipCount, int takeCount)
            => new ArrayDistinctEnumerable<TSource>(source, comparer, skipCount, takeCount);

        public readonly partial struct ArrayDistinctEnumerable<TSource>
            : IValueEnumerable<TSource, ArrayDistinctEnumerable<TSource>.DisposableEnumerator>
        {
            readonly TSource[] source;
            readonly IEqualityComparer<TSource>? comparer;
            internal readonly int skipCount;
            internal readonly int takeCount;

            internal ArrayDistinctEnumerable(TSource[] source, IEqualityComparer<TSource>? comparer, int skipCount, int takeCount)
            {
                this.source = source;
                this.comparer = comparer;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Length, skipCount, takeCount);
            }

            [Pure]
            public readonly Enumerator GetEnumerator() 
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, ArrayDistinctEnumerable<TSource>.DisposableEnumerator>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new DisposableEnumerator(in this);

            public struct Enumerator
            {
                readonly TSource[] source;
                readonly HashSet<TSource> set;
                readonly int end;
                int index;
                TSource current;

                internal Enumerator(in ArrayDistinctEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    set = new HashSet<TSource>(enumerable.comparer);
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                    current = default!;
                }

                [MaybeNull]
                public readonly TSource Current
                    => current;

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
            }

            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                readonly TSource[] source;
                readonly HashSet<TSource> set;
                readonly int end;
                int index;
                TSource current;

                internal DisposableEnumerator(in ArrayDistinctEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    set = new HashSet<TSource>(enumerable.comparer);
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                    current = default!;
                }

                [MaybeNull]
                public readonly TSource Current 
                    => current;
                readonly object? IEnumerator.Current 
                    => current;

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
            public readonly ArrayDistinctEnumerable<TSource> Skip(int count)
                => new ArrayDistinctEnumerable<TSource>(source, comparer, skipCount + count, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ArrayDistinctEnumerable<TSource> Take(int count)
                => new ArrayDistinctEnumerable<TSource>(source, comparer, skipCount, Math.Min(takeCount, count));


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

