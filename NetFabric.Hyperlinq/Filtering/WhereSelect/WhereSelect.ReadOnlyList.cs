using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static WhereSelecEnumerable<TList, TSource, TResult, TPredicate> WhereSelect<TList, TSource, TResult, TPredicate>(
            this TList source,
            TPredicate predicate,
            NullableSelector<TSource, TResult> selector, 
            int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicate<TSource>
            => new WhereSelecEnumerable<TList, TSource, TResult, TPredicate>(in source, predicate, selector, offset, count);

        [GeneratorMapping("TSource", "TResult")]
        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct WhereSelecEnumerable<TList, TSource, TResult, TPredicate>
            : IValueEnumerable<TResult, WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator>
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            readonly TList source;
            readonly TPredicate predicate;
            readonly NullableSelector<TSource, TResult> selector;
            readonly int offset;
            readonly int count;

            internal WhereSelecEnumerable(in TList source, TPredicate predicate, NullableSelector<TSource, TResult> selector, int offset, int count)
            {
                this.source = source;
                this.predicate = predicate;
                this.selector = selector;
                (this.offset, this.count) = Utils.SkipTake(source.Count, offset, count);
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TResult, WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
            {
                int index;
                readonly int end;
                readonly TList source;
                readonly TPredicate predicate;
                readonly NullableSelector<TSource, TResult> selector;

                internal Enumerator(in WhereSelecEnumerable<TList, TSource, TResult, TPredicate> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    index = enumerable.offset - 1;
                    end = index + enumerable.count;
                }

                [MaybeNull]
                public readonly TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector(source[index]);
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate.Invoke(source[index]))
                            return true;
                    }
                    return false;
                }
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct DisposableEnumerator
                : IEnumerator<TResult>
            {
                readonly int end;
                int index;
                readonly TList source;
                readonly TPredicate predicate;
                readonly NullableSelector<TSource, TResult> selector;

                internal DisposableEnumerator(in WhereSelecEnumerable<TList, TSource, TResult, TPredicate> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    index = enumerable.offset - 1;
                    end = index + enumerable.count;
                }

                [MaybeNull]
                public readonly TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector(source[index]);
                }
                readonly TResult IEnumerator<TResult>.Current 
                    => selector(source[index])!;
                readonly object? IEnumerator.Current 
                    => selector(source[index]);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate.Invoke(source[index]))
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
                => ReadOnlyListExtensions.Count<TList, TSource, TPredicate>(source, predicate, offset, count);

            public bool Any()
                => ReadOnlyListExtensions.Any<TList, TSource, TPredicate>(source, predicate, offset, count);
                
            public Option<TResult> ElementAt(int index)
                => ReadOnlyListExtensions.ElementAt<TList, TSource, TResult, TPredicate>(source, index, predicate, selector, offset, count);

            public Option<TResult> First()
                => ReadOnlyListExtensions.First<TList, TSource, TResult, TPredicate>(source, predicate, selector, offset, count);

            public Option<TResult> Single()
                => ReadOnlyListExtensions.Single<TList, TSource, TResult, TPredicate>(source, predicate, selector, offset, count);

            public TResult[] ToArray()
                => ReadOnlyListExtensions.ToArray<TList, TSource, TResult, TPredicate>(source, predicate, selector, offset, count);

            public IMemoryOwner<TResult> ToArray(MemoryPool<TResult> pool)
                => ReadOnlyListExtensions.ToArray<TList, TSource, TResult, TPredicate>(source, predicate, selector, offset, count, pool);

            public List<TResult> ToList()
                => ReadOnlyListExtensions.ToList<TList, TSource, TResult, TPredicate>(source, predicate, selector, offset, count); 

            public Dictionary<TKey, TResult> ToDictionary<TKey>(Selector<TResult, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
            {
                var dictionary = new Dictionary<TKey, TResult>(0, comparer);

                TResult item;
                var end = offset + count - 1;
                for (var index = offset; index <= end; index++)
                {
                    if (predicate.Invoke(source[index]))
                    {
                        item = selector(source[index]);
                        dictionary.Add(keySelector(item), item!);
                    }
                }

                return dictionary;
            }

            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TResult, TKey> keySelector, NullableSelector<TResult, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
            {
                var dictionary = new Dictionary<TKey, TElement>(0, comparer);

                TResult item;
                var end = offset + count - 1;
                for (var index = offset; index <= end; index++)
                {
                    if (predicate.Invoke(source[index]))
                    {
                        item = selector(source[index]);
                        dictionary.Add(keySelector(item), elementSelector(item)!);
                    }
                }

                return dictionary;
            }

            public readonly bool SequenceEqual(IEnumerable<TResult> other, IEqualityComparer<TResult>? comparer = default)
            {
                comparer ??= EqualityComparer<TResult>.Default;

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

                    if (!comparer.Equals(enumerator.Current!, otherEnumerator.Current))
                        return false;
                }
            }
        }
    }
}

