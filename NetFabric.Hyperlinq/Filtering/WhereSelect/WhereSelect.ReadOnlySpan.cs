using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static SpanWhereSelectEnumerable<TSource, TResult, TPredicate> WhereSelect<TSource, TResult, TPredicate>(
            this ReadOnlySpan<TSource> source,
            TPredicate predicate, 
            NullableSelector<TSource, TResult> selector)
            where TPredicate : struct, IPredicate<TSource>
            => new SpanWhereSelectEnumerable<TSource, TResult, TPredicate>(source, predicate, selector);

        [GeneratorMapping("TSource", "TResult")]
        [StructLayout(LayoutKind.Auto)]
        public readonly ref struct SpanWhereSelectEnumerable<TSource, TResult, TPredicate>
            where TPredicate : struct, IPredicate<TSource>
        {
            internal readonly ReadOnlySpan<TSource> source;
            internal readonly TPredicate predicate;
            internal readonly NullableSelector<TSource, TResult> selector;

            internal SpanWhereSelectEnumerable(ReadOnlySpan<TSource> source, TPredicate predicate, NullableSelector<TSource, TResult> selector)
            {
                this.source = source;
                this.predicate = predicate;
                this.selector = selector;
            }

            
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);

            [StructLayout(LayoutKind.Sequential)]
            public ref struct Enumerator
            {
                int index;
                readonly int end;
                readonly ReadOnlySpan<TSource> source;
                readonly TPredicate predicate;
                readonly NullableSelector<TSource, TResult> selector;

                internal Enumerator(in SpanWhereSelectEnumerable<TSource, TResult, TPredicate> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    index = -1;
                    end = index + source.Length;
                }

                [MaybeNull]
                public TResult Current 
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

            public int Count()
                => source.Count(predicate);

            public bool Any()
                => ArrayExtensions.Any<TSource, TPredicate>(source, predicate);
                
            public Option<TResult> ElementAt(int index)
                => ArrayExtensions.ElementAt<TSource, TResult, TPredicate>(source, index, predicate, selector);

            public Option<TResult> First()
                => ArrayExtensions.First<TSource, TResult, TPredicate>(source, predicate, selector);

            public Option<TResult> Single()
                => ArrayExtensions.Single<TSource, TResult, TPredicate>(source, predicate, selector);

            public TResult[] ToArray()
                => ArrayExtensions.ToArray<TSource, TResult, TPredicate>(source, predicate, selector);

            public IMemoryOwner<TResult> ToArray(MemoryPool<TResult> memoryPool)
                => ArrayExtensions.ToArray<TSource, TResult, TPredicate>(source, predicate, selector, memoryPool);

            public List<TResult> ToList()
                => ArrayExtensions.ToList<TSource, TResult, TPredicate>(source, predicate, selector);

            public bool SequenceEqual(IEnumerable<TResult> other, IEqualityComparer<TResult>? comparer = null)
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

