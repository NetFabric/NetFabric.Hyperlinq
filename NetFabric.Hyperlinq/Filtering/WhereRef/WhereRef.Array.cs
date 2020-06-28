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
        public static MemoryWhereRefEnumerable<TSource> WhereRef<TSource>(this TSource[] source, Predicate<TSource> predicate)
            => WhereRef(source.AsMemory(), predicate);

#else

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static WhereRefEnumerable<TSource> WhereRef<TSource>(this TSource[] source, Predicate<TSource> predicate)
        {
            if (predicate is null)
                Throw.ArgumentNullException(nameof(predicate));

            return new WhereRefEnumerable<TSource>(in source, predicate, 0, source.Length);
        }

        static WhereRefEnumerable<TSource> WhereRef<TSource>(this TSource[] source, Predicate<TSource> predicate, int skipCount, int takeCount)
            => new WhereRefEnumerable<TSource>(in source, predicate, skipCount, takeCount);

        public readonly partial struct WhereRefEnumerable<TSource>
            : IValueEnumerable<TSource, WhereRefEnumerable<TSource>.DisposableEnumerator>
        {
            readonly TSource[] source;
            readonly Predicate<TSource> predicate;
            readonly int skipCount;
            readonly int takeCount;

            internal WhereRefEnumerable(in TSource[] source, Predicate<TSource> predicate, int skipCount, int takeCount)
            {
                this.source = source;
                this.predicate = predicate;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Length, skipCount, takeCount);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() 
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, WhereRefEnumerable<TSource>.DisposableEnumerator>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new DisposableEnumerator(in this);

            public struct Enumerator
            {
                readonly TSource[] source;
                readonly Predicate<TSource> predicate;
                readonly int end;
                int index;

                internal Enumerator(in WhereRefEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                public readonly ref TSource Current
                    => ref source[index];

                public bool MoveNext()
                {
                    while (++index < end)
                    {
                        if (predicate(source[index]))
                            return true;
                    }
                    return false;
                }
            }

            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                readonly TSource[] source;
                readonly Predicate<TSource> predicate;
                readonly int end;
                int index;

                internal DisposableEnumerator(in WhereRefEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                public readonly ref TSource Current
                    => ref source[index];
                readonly TSource IEnumerator<TSource>.Current
                    => source[index];
                readonly object? IEnumerator.Current
                    => source[index];

                public bool MoveNext()
                {
                    while (++index < end)
                    {
                        if (predicate(source[index]))
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

            public WhereEnumerable<TSource> Where(Predicate<TSource> predicate)
                => ArrayExtensions.Where<TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);
            public WhereAtEnumerable<TSource> Where(PredicateAt<TSource> predicate)
                => ArrayExtensions.Where<TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);

            public WhereRefEnumerable<TSource> WhereRef(Predicate<TSource> predicate)
                => ArrayExtensions.WhereRef<TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);
            public WhereRefAtEnumerable<TSource> WhereRef(PredicateAt<TSource> predicate)
                => ArrayExtensions.WhereRef<TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);

            public WhereSelectEnumerable<TSource, TResult> Select<TResult>(NullableSelector<TSource, TResult> selector)
            {
                if (selector is null)
                    Throw.ArgumentNullException(nameof(selector));

                return ArrayExtensions.WhereSelect<TSource, TResult>(source, predicate, selector, skipCount, takeCount);
            }

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
        }
#endif
    }
}

