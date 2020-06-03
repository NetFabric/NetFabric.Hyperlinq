using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanDistinctEnumerable<TSource> Distinct<TSource>(
            this ReadOnlySpan<TSource> source, 
            IEqualityComparer<TSource>? comparer = null)
            => new SpanDistinctEnumerable<TSource>(source, comparer);

        public readonly ref struct SpanDistinctEnumerable<TSource>
        {
            readonly ReadOnlySpan<TSource> source;
            readonly IEqualityComparer<TSource>? comparer;

            internal SpanDistinctEnumerable(ReadOnlySpan<TSource> source, IEqualityComparer<TSource>? comparer)
            {
                this.source = source;
                this.comparer = comparer;
            }

            
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);

            public ref struct Enumerator
            {
                readonly ReadOnlySpan<TSource> source;
                readonly HashSet<TSource> set;
                int index;

                internal Enumerator(in SpanDistinctEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    set = new HashSet<TSource>(enumerable.comparer);
                    index = -1;
                    Current = default!;
                }

                [MaybeNull]
                public TSource Current { get; private set; }

                public bool MoveNext()
                {
                    while (++index < source.Length)
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

            // helper function for optimization of non-lazy operations
            readonly HashSet<TSource> FillSet() 
            {
                var set = new HashSet<TSource>(comparer);
                for (var index = 0; index < source.Length; index++)
                    _ = set.Add(source[index]);
                return set;
            }

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
    }
}

