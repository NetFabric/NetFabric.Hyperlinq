using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyMemoryWhereRefAtEnumerable<TSource> WhereRef<TSource>(this ReadOnlyMemory<TSource> source, PredicateAt<TSource> predicate)
        {
            if (predicate is null)
                Throw.ArgumentNullException(nameof(predicate));

            return new ReadOnlyMemoryWhereRefAtEnumerable<TSource>(source, predicate);
        }

        public readonly partial struct ReadOnlyMemoryWhereRefAtEnumerable<TSource>
            : IValueEnumerable<TSource, ReadOnlyMemoryWhereRefAtEnumerable<TSource>.DisposableEnumerator>
        {
            internal readonly ReadOnlyMemory<TSource> source;
            internal readonly PredicateAt<TSource> predicate;

            internal ReadOnlyMemoryWhereRefAtEnumerable(in ReadOnlyMemory<TSource> source, PredicateAt<TSource> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }


            public readonly Enumerator GetEnumerator()
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, ReadOnlyMemoryWhereRefAtEnumerable<TSource>.DisposableEnumerator>.GetEnumerator()
                => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator()
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator()
                => new DisposableEnumerator(in this);

            public ref struct Enumerator
            {
                readonly ReadOnlySpan<TSource> source;
                readonly PredicateAt<TSource> predicate;
                int index;

                internal Enumerator(in ReadOnlyMemoryWhereRefAtEnumerable<TSource> enumerable)
                {
                    source = enumerable.source.Span;
                    predicate = enumerable.predicate;
                    index = -1;
                }

                public readonly ref readonly TSource Current
                    => ref source[index];

                public bool MoveNext()
                {
                    while (++index < source.Length)
                    {
                        if (predicate(source[index], index))
                            return true;
                    }
                    return false;
                }
            }

            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                readonly ReadOnlyMemory<TSource> source;
                readonly PredicateAt<TSource> predicate;
                int index;

                internal DisposableEnumerator(in ReadOnlyMemoryWhereRefAtEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    index = -1;
                }

                [MaybeNull]
                public readonly ref readonly TSource Current
                    => ref source.Span[index]!;
                readonly TSource IEnumerator<TSource>.Current
                    => source.Span[index];
                readonly object? IEnumerator.Current
                    => source.Span[index];

                public bool MoveNext()
                {
                    var span = source.Span;
                    while (++index < source.Length)
                    {
                        if (predicate(span[index], index))
                            return true;
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset()
                    => throw new NotSupportedException();

                public void Dispose() { }
            }

            public int Count()
                => ArrayExtensions.Count(source.Span, predicate);

            public bool Any()
                => ArrayExtensions.Any(source.Span, predicate);

            public ReadOnlyMemoryWhereRefAtEnumerable<TSource> WhereRef(Predicate<TSource> predicate)
                => WhereRef<TSource>(source, Utils.Combine(this.predicate, predicate));

            public ReadOnlyMemoryWhereRefAtEnumerable<TSource> WhereRef(PredicateAt<TSource> predicate)
                => WhereRef<TSource>(source, Utils.Combine(this.predicate, predicate));

            public Option<TSource> ElementAt(int index)
                => ArrayExtensions.ElementAt<TSource>(source.Span, index, predicate);

            public Option<TSource> First()
                => ArrayExtensions.First<TSource>(source.Span, predicate);

            public Option<TSource> Single()
                => ArrayExtensions.Single<TSource>(source.Span, predicate);

            public TSource[] ToArray()
                => ArrayExtensions.ToArray(source.Span, predicate);

            public List<TSource> ToList()
                => ArrayExtensions.ToList(source, predicate); 

            public bool SequenceEqual(IEnumerable<TSource> other, IEqualityComparer<TSource>? comparer = null)
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
