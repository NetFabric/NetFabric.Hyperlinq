using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static SkipTakeEnumerable<TEnumerable, TSource> SkipTake<TEnumerable, TSource>(this TEnumerable source, int skipCount, int takeCount)
            where TEnumerable : IReadOnlyList<TSource>
            => new SkipTakeEnumerable<TEnumerable, TSource>(in source, skipCount, takeCount);

        [GenericsTypeMapping("TEnumerable", typeof(SkipTakeEnumerable<,>))]
        [GenericsTypeMapping("TEnumerator", typeof(SkipTakeEnumerable<,>.Enumerator))]
        public readonly struct SkipTakeEnumerable<TEnumerable, TSource>
            : IValueReadOnlyList<TSource, SkipTakeEnumerable<TEnumerable, TSource>.Enumerator>
            where TEnumerable : IReadOnlyList<TSource>
        {
            internal readonly TEnumerable source;
            internal readonly int skipCount;
            internal readonly int takeCount;

            internal SkipTakeEnumerable(in TEnumerable source, int skipCount, int takeCount)
            {
                this.source = source;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Count, skipCount, takeCount);
            }

            public int Count => takeCount;

            public TSource this[int index]
            {
                get
                {
                    if (index < 0 || index >= takeCount) 
                        ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index));

                    return source[index + skipCount];
                }
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IEnumerator<TSource>
            {
                readonly TEnumerable source;
                readonly int end;
                int index;

                internal Enumerator(in SkipTakeEnumerable<TEnumerable, TSource> enumerable)
                {
                    source = enumerable.source;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                public TSource Current
                    => source[index];

                object IEnumerator.Current
                    => source[index];

                public bool MoveNext()
                    => ++index < end;

                void IEnumerator.Reset()
                    => throw new NotSupportedException();

                public void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TEnumerable, TSource> Take(int count)
                => ReadOnlyList.SkipTake<TEnumerable, TSource>(source, skipCount, Math.Min(takeCount, count));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyList.WhereEnumerable<TEnumerable, TSource> Where(Func<TSource, bool> predicate)
                => ReadOnlyList.Where<TEnumerable, TSource>(source, predicate, skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyList.WhereIndexEnumerable<TEnumerable, TSource> Where(Func<TSource, int, bool> predicate)
                => ReadOnlyList.Where<TEnumerable, TSource>(source, predicate, skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyList.SelectEnumerable<TEnumerable, TSource, TResult> Select<TResult>(Func<TSource, TResult> selector)
                => ReadOnlyList.Select<TEnumerable, TSource, TResult>(source, selector, skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyList.SelectIndexEnumerable<TEnumerable, TSource, TResult> Select<TResult>(Func<TSource, int, TResult> selector)
                => ReadOnlyList.Select<TEnumerable, TSource, TResult>(source, selector, skipCount, takeCount);

            public TSource First()
                => ReadOnlyList.TryFirst<TEnumerable, TSource>(source, skipCount, takeCount).ThrowOnEmpty();
            public TSource First(Func<TSource, bool> predicate)
                => ReadOnlyList.TryFirst<TEnumerable, TSource>(source, predicate, skipCount, takeCount).ThrowOnEmpty();
            public TSource FirstOrDefault()
                => ReadOnlyList.TryFirst<TEnumerable, TSource>(source, skipCount, takeCount).DefaultOnEmpty();
            public TSource FirstOrDefault(Func<TSource, bool> predicate)
                => ReadOnlyList.TryFirst<TEnumerable, TSource>(source, predicate, skipCount, takeCount).DefaultOnEmpty();
            public (ElementResult Success, TSource Value) TryFirst()
                => ReadOnlyList.TryFirst<TEnumerable, TSource>(source, skipCount, takeCount);
            public (ElementResult Success, TSource Value) TryFirst(Func<TSource, bool> predicate)
                => ReadOnlyList.TryFirst<TEnumerable, TSource>(source, predicate, skipCount, takeCount);

            public TSource Single()
                => ReadOnlyList.TrySingle<TEnumerable, TSource>(source, skipCount, takeCount).ThrowOnEmpty();
            public TSource Single(Func<TSource, bool> predicate)
                => ReadOnlyList.TrySingle<TEnumerable, TSource>(source, predicate, skipCount, takeCount).ThrowOnEmpty();
            public TSource SingleOrDefault()
                => ReadOnlyList.TrySingle<TEnumerable, TSource>(source, skipCount, takeCount).DefaultOnEmpty();
            public TSource SingleOrDefault(Func<TSource, bool> predicate)
                => ReadOnlyList.TrySingle<TEnumerable, TSource>(source, predicate, skipCount, takeCount).DefaultOnEmpty();
            public (ElementResult Success, TSource Value) TrySingle()
                => ReadOnlyList.TrySingle<TEnumerable, TSource>(source, skipCount, takeCount);
            public (ElementResult Success, TSource Value) TrySingle(Func<TSource, bool> predicate)
                => ReadOnlyList.TrySingle<TEnumerable, TSource>(source, predicate, skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => ReadOnlyList.ToArray<TEnumerable, TSource>(source, skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => ReadOnlyList.ToList<TEnumerable, TSource>(source, skipCount, takeCount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TEnumerable, TSource>(this SkipTakeEnumerable<TEnumerable, TSource> source)
            where TEnumerable : IReadOnlyList<TSource>
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TEnumerable, TSource>(this SkipTakeEnumerable<TEnumerable, TSource> source, Func<TSource, bool> predicate)
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return ReadOnlyList.Count<TEnumerable, TSource>(source.source, predicate, source.skipCount, source.takeCount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TEnumerable, TSource>(this SkipTakeEnumerable<TEnumerable, TSource> source, Func<TSource, int, bool> predicate)
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return ReadOnlyList.Count<TEnumerable, TSource>(source.source, predicate, source.skipCount, source.takeCount);
        }
    }
}