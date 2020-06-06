using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
#if SPAN_SUPPORTED

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryDistinctEnumerable<TSource> Distinct<TSource>(this TSource[] source, IEqualityComparer<TSource>? comparer = null)
            => Distinct((ReadOnlyMemory<TSource>)source.AsMemory(), comparer);

#else

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DistinctEnumerable<TSource> Distinct<TSource>(
            this TSource[] source, 
            IEqualityComparer<TSource>? comparer = null)
            => new DistinctEnumerable<TSource>(source, comparer, 0, source.Length);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static DistinctEnumerable<TSource> Distinct<TSource>(
            this TSource[] source,
            IEqualityComparer<TSource>? comparer,
            int skipCount, int takeCount)
            => new DistinctEnumerable<TSource>(source, comparer, skipCount, takeCount);

        public readonly partial struct DistinctEnumerable<TSource>
            : IValueEnumerable<TSource, DistinctEnumerable<TSource>.DisposableEnumerator>
        {
            readonly TSource[] source;
            readonly IEqualityComparer<TSource>? comparer;
            internal readonly int skipCount;
            internal readonly int takeCount;

            internal DistinctEnumerable(TSource[] source, IEqualityComparer<TSource>? comparer, int skipCount, int takeCount)
            {
                this.source = source;
                this.comparer = comparer;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Length, skipCount, takeCount);
            }

            
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, DistinctEnumerable<TSource>.DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            public struct Enumerator
            {
                readonly TSource[] source;
                readonly HashSet<TSource> set;
                readonly int end;
                int index;

                internal Enumerator(in DistinctEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    set = new HashSet<TSource>(enumerable.comparer);
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                    Current = default!;
                }

                [MaybeNull]
                public TSource Current { get; private set; }

                public bool MoveNext()
                {
                    while (++index < end)
                    {
                        if (set.Add(source[index]))
                        {
                            Current = source[index];
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

                internal DisposableEnumerator(in DistinctEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    set = new HashSet<TSource>(enumerable.comparer);
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                    Current = default!;
                }

                [MaybeNull]
                public TSource Current { get; private set; }
                readonly TSource IEnumerator<TSource>.Current 
                    => Current;
                readonly object? IEnumerator.Current
                    => Current;

                public bool MoveNext()
                {
                    while (++index < end)
                    {
                        if (set.Add(source[index]))
                        {
                            Current = source[index];
                            return true;
                        }
                    }

                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => throw new NotSupportedException();

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
            public readonly bool Any()
                => source.Length != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly TSource[] ToArray()
                => HashSetBindings.ToArray<TSource>(FillSet());

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly List<TSource> ToList()
                => HashSetBindings.ToList<TSource>(FillSet());

            public readonly bool SequenceEqual(IEnumerable<TSource> other, IEqualityComparer<TSource>? comparer = null)
            {
                comparer ??= EqualityComparer<TSource>.Default;

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

                    if (!comparer.Equals(enumerator.Current, otherEnumerator.Current))
                        return false;
                }
            }
        }

#endif
    }
}

