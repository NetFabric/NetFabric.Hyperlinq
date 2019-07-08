using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        public static SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> SkipTake<TEnumerable, TEnumerator, TSource>(this TEnumerable source, long skipCount, long takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => new SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>(in source, skipCount, takeCount);

        [GenericsTypeMapping("TEnumerable", typeof(SkipTakeEnumerable<,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(SkipTakeEnumerable<,,>.Enumerator))]
        public readonly struct SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueReadOnlyList<TSource, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            internal readonly TEnumerable source;
            internal readonly long skipCount;
            internal readonly long takeCount;

            internal SkipTakeEnumerable(in TEnumerable source, long skipCount, long takeCount)
            {
                this.source = source;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Count, skipCount, takeCount);
            }

            public long Count => takeCount;

            public TSource this[long index]
            {
                get
                {
                    if (index < 0 || index >= takeCount) 
                        ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index));

                    return source[index + skipCount];
                }
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IValueEnumerator<TSource>
            {
                readonly TEnumerable source;
                readonly long end;
                long index;

                internal Enumerator(in SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    source = enumerable.source;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                public TSource Current
                    => source[index];

                public bool MoveNext()
                    => ++index < end;

                public void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> Take(long count)
                => ValueReadOnlyList.SkipTake<TEnumerable, TEnumerator, TSource>(source, skipCount, Math.Min(takeCount, count));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueReadOnlyList.WhereEnumerable<TEnumerable, TEnumerator, TSource> Where(Func<TSource, bool> predicate)
                => ValueReadOnlyList.Where<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueReadOnlyList.WhereIndexEnumerable<TEnumerable, TEnumerator, TSource> Where(Func<TSource, long, bool> predicate)
                => ValueReadOnlyList.Where<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueReadOnlyList.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TResult>(Func<TSource, TResult> selector)
                => ValueReadOnlyList.Select<TEnumerable, TEnumerator, TSource, TResult>(source, selector, skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueReadOnlyList.SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TResult>(Func<TSource, long, TResult> selector)
                => ValueReadOnlyList.Select<TEnumerable, TEnumerator, TSource, TResult>(source, selector, skipCount, takeCount);

            public TSource First()
                => ValueReadOnlyList.TryFirst<TEnumerable, TEnumerator, TSource>(source, skipCount, takeCount).ThrowOnEmpty();
            public TSource First(Func<TSource, bool> predicate)
                => ValueReadOnlyList.TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount).ThrowOnEmpty();
            public TSource FirstOrDefault()
                => ValueReadOnlyList.TryFirst<TEnumerable, TEnumerator, TSource>(source, skipCount, takeCount).DefaultOnEmpty();
            public TSource FirstOrDefault(Func<TSource, bool> predicate)
                => ValueReadOnlyList.TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount).DefaultOnEmpty();
            public (ElementResult Success, TSource Value) TryFirst()
                => ValueReadOnlyList.TryFirst<TEnumerable, TEnumerator, TSource>(source, skipCount, takeCount);
            public (ElementResult Success, TSource Value) TryFirst(Func<TSource, bool> predicate)
                => ValueReadOnlyList.TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount);

            public TSource Single()
                => ValueReadOnlyList.TrySingle<TEnumerable, TEnumerator, TSource>(source, skipCount, takeCount).ThrowOnEmpty();
            public TSource Single(Func<TSource, bool> predicate)
                => ValueReadOnlyList.TrySingle<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount).ThrowOnEmpty();
            public TSource SingleOrDefault()
                => ValueReadOnlyList.TrySingle<TEnumerable, TEnumerator, TSource>(source, skipCount, takeCount).DefaultOnEmpty();
            public TSource SingleOrDefault(Func<TSource, bool> predicate)
                => ValueReadOnlyList.TrySingle<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount).DefaultOnEmpty();
            public (ElementResult Success, TSource Value) TrySingle()
                => ValueReadOnlyList.TrySingle<TEnumerable, TEnumerator, TSource>(source, skipCount, takeCount);
            public (ElementResult Success, TSource Value) TrySingle(Func<TSource, bool> predicate)
                => ValueReadOnlyList.TrySingle<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => ValueReadOnlyList.ToArray<TEnumerable, TEnumerator, TSource>(source, skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => ValueReadOnlyList.ToList<TEnumerable, TEnumerator, TSource>(source, skipCount, takeCount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Count<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Count<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source, Func<TSource, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return ValueReadOnlyList.Count<TEnumerable, TEnumerator, TSource>(source.source, predicate, source.skipCount, source.takeCount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Count<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source, Func<TSource, long, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return ValueReadOnlyList.Count<TEnumerable, TEnumerator, TSource>(source.source, predicate, source.skipCount, source.takeCount);
        }
    }
}