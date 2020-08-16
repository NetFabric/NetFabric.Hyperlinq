using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryWhereRefEnumerable<TSource> WhereRef<TSource>(this Memory<TSource> source, Predicate<TSource> predicate)
        {
            if (predicate is null)
                Throw.ArgumentNullException(nameof(predicate));

            return new MemoryWhereRefEnumerable<TSource>(source, predicate);
        }

        [GeneratorIgnore]
        [StructLayout(LayoutKind.Auto)]
        public readonly struct MemoryWhereRefEnumerable<TSource>
        {
            internal readonly Memory<TSource> source;
            internal readonly Predicate<TSource> predicate;

            internal MemoryWhereRefEnumerable(Memory<TSource> source, Predicate<TSource> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }


            public readonly Enumerator GetEnumerator()
                => new Enumerator(in this);

            [StructLayout(LayoutKind.Sequential)]
            public ref struct Enumerator
            {
                int index;
                readonly int end;
                readonly Span<TSource> source;
                readonly Predicate<TSource> predicate;

                internal Enumerator(in MemoryWhereRefEnumerable<TSource> enumerable)
                {
                    source = enumerable.source.Span;
                    predicate = enumerable.predicate;
                    index = -1;
                    end = index + source.Length;
                }

                public readonly ref TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => ref source[index];
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate(source[index]))
                            return true;
                    }
                    return false;
                }
            }

            public bool SequenceEqual(IEnumerable<TSource> other, IEqualityComparer<TSource>? comparer = null)
            {
                if (Utils.UseDefault(comparer))
                {
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

                        if (!EqualityComparer<TSource>.Default.Equals(enumerator.Current, otherEnumerator.Current))
                            return false;
                    }
                }
                else
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
}

