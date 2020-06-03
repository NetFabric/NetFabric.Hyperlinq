using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DistinctEnumerable<TList, TSource> Distinct<TList, TSource>(
            this TList source, 
            IEqualityComparer<TSource>? comparer = null)
            where TList : notnull, IReadOnlyList<TSource>
            => new DistinctEnumerable<TList, TSource>(source, comparer, 0, source.Count);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static DistinctEnumerable<TList, TSource> Distinct<TList, TSource>(
            this TList source,
            IEqualityComparer<TSource>? comparer,
            int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
            => new DistinctEnumerable<TList, TSource>(source, comparer, skipCount, takeCount);

        public readonly partial struct DistinctEnumerable<TList, TSource>
            : IValueEnumerable<TSource, DistinctEnumerable<TList, TSource>.DisposableEnumerator>
            where TList : notnull, IReadOnlyList<TSource>
        {
            readonly TList source;
            readonly IEqualityComparer<TSource>? comparer;
            internal readonly int skipCount;
            internal readonly int takeCount;

            internal DistinctEnumerable(TList source, IEqualityComparer<TSource>? comparer, int skipCount, int takeCount)
            {
                this.source = source;
                this.comparer = comparer;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Count, skipCount, takeCount);
            }

            
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, DistinctEnumerable<TList, TSource>.DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            public struct Enumerator
            {
                readonly TList source;
                readonly HashSet<TSource> set;
                readonly int end;
                int index;

                internal Enumerator(in DistinctEnumerable<TList, TSource> enumerable)
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
                readonly TList source;
                readonly HashSet<TSource> set;
                readonly int end;
                int index;

                internal DisposableEnumerator(in DistinctEnumerable<TList, TSource> enumerable)
                {
                    source = enumerable.source;
                    set = new HashSet<TSource>(enumerable.comparer);
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                    Current = default!;
                }

                [MaybeNull]
#pragma warning disable CS8766 // Nullability of reference types in return type doesn't match implicitly implemented member (possibly because of nullability attributes).
                public TSource Current { get; private set; }
#pragma warning restore CS8766 // Nullability of reference types in return type doesn't match implicitly implemented member (possibly because of nullability attributes).
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
            public readonly DistinctEnumerable<TList, TSource> Skip(int count)
                => new DistinctEnumerable<TList, TSource>(source, comparer, skipCount + count, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly DistinctEnumerable<TList, TSource> Take(int count)
                => new DistinctEnumerable<TList, TSource>(source, comparer, skipCount, Math.Min(takeCount, count));


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly int Count()
                => FillSet().Count;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any()
                => source.Count != 0;

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
    }
}

