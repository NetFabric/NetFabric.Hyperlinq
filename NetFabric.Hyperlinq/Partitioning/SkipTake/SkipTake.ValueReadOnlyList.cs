using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        public static SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> SkipTake<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => new SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>(in source, skipCount, takeCount);

        [GenericsTypeMapping("TEnumerable", typeof(SkipTakeEnumerable<,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(SkipTakeEnumerable<,,>.Enumerator))]
        public readonly struct SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueReadOnlyList<TSource, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
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

                internal Enumerator(in SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
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
            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> Take(int count)
                => ValueReadOnlyList.SkipTake<TEnumerable, TEnumerator, TSource>(source, skipCount, Math.Min(takeCount, count));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueReadOnlyList.WhereEnumerable<TEnumerable, TEnumerator, TSource> Where(Func<TSource, bool> predicate)
                => ValueReadOnlyList.Where<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueReadOnlyList.WhereIndexEnumerable<TEnumerable, TEnumerator, TSource> Where(Func<TSource, int, bool> predicate)
                => ValueReadOnlyList.Where<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueReadOnlyList.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TResult>(Func<TSource, TResult> selector)
                => ValueReadOnlyList.Select<TEnumerable, TEnumerator, TSource, TResult>(source, selector, skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueReadOnlyList.SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TResult>(Func<TSource, int, TResult> selector)
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
        public static int Count<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source, Func<TSource, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return ValueReadOnlyList.Count<TEnumerable, TEnumerator, TSource>(source.source, predicate, source.skipCount, source.takeCount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source, Func<TSource, int, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return ValueReadOnlyList.Count<TEnumerable, TEnumerator, TSource>(source.source, predicate, source.skipCount, source.takeCount);
        }
    }
}