using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
#if SPAN_SUPPORTED

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryWhereRefAtEnumerable<TSource> WhereRef<TSource>(this TSource[] source, PredicateAt<TSource> predicate)
            => WhereRef(source.AsMemory(), predicate);

#else

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static WhereRefAtEnumerable<TSource> WhereRef<TSource>(this TSource[] source, PredicateAt<TSource> predicate)
        {
            if (predicate is null)
                Throw.ArgumentNullException(nameof(predicate));

            return new WhereRefAtEnumerable<TSource>(in source, predicate, 0, source.Length);
        }


        static WhereRefAtEnumerable<TSource> WhereRef<TSource>(this TSource[] source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            => new WhereRefAtEnumerable<TSource>(in source, predicate, skipCount, takeCount);

        public readonly partial struct WhereRefAtEnumerable<TSource>
            : IValueEnumerable<TSource, WhereRefAtEnumerable<TSource>.DisposableEnumerator>
        {
            readonly TSource[] source;
            readonly PredicateAt<TSource> predicate;
            readonly int skipCount;
            readonly int takeCount;

            internal WhereRefAtEnumerable(in TSource[] source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            {
                this.source = source;
                this.predicate = predicate;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Length, skipCount, takeCount);
            }

            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, WhereRefAtEnumerable<TSource>.DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            public struct Enumerator
            {
                readonly TSource[] source;
                readonly PredicateAt<TSource> predicate;
                readonly int skipCount;
                readonly int takeCount;
                int index;

                internal Enumerator(in WhereRefAtEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    skipCount = enumerable.skipCount;
                    takeCount = enumerable.takeCount;
                    index = -1;
                }

                [MaybeNull]
                public readonly ref TSource Current
                    => ref source[index + skipCount]!;

                public bool MoveNext()
                {
                    while (++index < takeCount)
                    {
                        if (predicate(source[index + skipCount], index))
                            return true;
                    }
                    return false;
                }
            }

            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                readonly TSource[] source;
                readonly PredicateAt<TSource> predicate;
                readonly int skipCount;
                readonly int takeCount;
                int index;

                internal DisposableEnumerator(in WhereRefAtEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    skipCount = enumerable.skipCount;
                    takeCount = enumerable.takeCount;
                    index = -1;
                }

                [MaybeNull]
                public readonly ref TSource Current
                    => ref source[index + skipCount]!;
                readonly TSource IEnumerator<TSource>.Current
                    => source[index + skipCount];
                readonly object? IEnumerator.Current
                    => source[index + skipCount];

                public bool MoveNext()
                {
                    while (++index < takeCount)
                    {
                        if (predicate(source[index + skipCount], index))
                            return true;
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset()
                    => Throw.NotSupportedException();

                public readonly void Dispose() { }
            }

            public int Count()
                => ArrayExtensions.Count<TSource>(source, predicate, skipCount, takeCount);

            public bool Any()
                => ArrayExtensions.Any<TSource>(source, predicate, skipCount, takeCount);

            public WhereRefAtEnumerable<TSource> WhereRef(Predicate<TSource> predicate)
                => ArrayExtensions.WhereRef<TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);
            public WhereRefAtEnumerable<TSource> WhereRef(PredicateAt<TSource> predicate)
                => ArrayExtensions.WhereRef<TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);

            public Option<TSource> ElementAt(int index)
                => ArrayExtensions.ElementAt<TSource>(source, index, predicate, skipCount, takeCount);

            public Option<TSource> First()
                => ArrayExtensions.First<TSource>(source, predicate, skipCount, takeCount);

            public Option<TSource> Single()
                => ArrayExtensions.Single<TSource>(source, predicate, skipCount, takeCount);

            public TSource[] ToArray()
                => ArrayExtensions.ToArray<TSource>(source, predicate, skipCount, takeCount);

            public List<TSource> ToList()
                => ArrayExtensions.ToList<TSource>(source, predicate, skipCount, takeCount);

            public readonly bool SequenceEqual(IEnumerable<TSource> other, IEqualityComparer<TSource>? comparer = default)
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

