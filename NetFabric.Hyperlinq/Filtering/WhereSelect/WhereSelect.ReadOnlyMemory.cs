using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static MemoryWhereSelectEnumerable<TSource, TResult, TPredicate> WhereSelect<TSource, TResult, TPredicate>(
            this ReadOnlyMemory<TSource> source,
            TPredicate predicate, 
            NullableSelector<TSource, TResult> selector)
            where TPredicate : struct, IPredicate<TSource>
            => new MemoryWhereSelectEnumerable<TSource, TResult, TPredicate>(source, predicate, selector);

        [GeneratorMapping("TSource", "TResult")]
        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct MemoryWhereSelectEnumerable<TSource, TResult, TPredicate>
            : IValueEnumerable<TResult, MemoryWhereSelectEnumerable<TSource, TResult, TPredicate>.DisposableEnumerator>
            where TPredicate : struct, IPredicate<TSource>
        {
            internal readonly ReadOnlyMemory<TSource> source;
            internal readonly TPredicate predicate;
            internal readonly NullableSelector<TSource, TResult> selector;

            internal MemoryWhereSelectEnumerable(ReadOnlyMemory<TSource> source, TPredicate predicate, NullableSelector<TSource, TResult> selector)
                => (this.source, this.predicate, this.selector) = (source, predicate, selector);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() 
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TResult, MemoryWhereSelectEnumerable<TSource, TResult, TPredicate>.DisposableEnumerator>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new DisposableEnumerator(in this);

            [StructLayout(LayoutKind.Sequential)]
            public ref struct Enumerator
            {
                int index;
                readonly int end;
                readonly ReadOnlySpan<TSource> source;
                readonly TPredicate predicate;
                readonly NullableSelector<TSource, TResult> selector;

                internal Enumerator(in MemoryWhereSelectEnumerable<TSource, TResult, TPredicate> enumerable)
                {
                    source = enumerable.source.Span;
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

            [StructLayout(LayoutKind.Sequential)]
            public struct DisposableEnumerator
                : IEnumerator<TResult>
            {
                int index;
                readonly int end;
                readonly ReadOnlyMemory<TSource> source;
                readonly TPredicate predicate;
                readonly NullableSelector<TSource, TResult> selector;

                internal DisposableEnumerator(in MemoryWhereSelectEnumerable<TSource, TResult, TPredicate> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    index = -1;
                    end = index + source.Length;
                }

                [MaybeNull]
                public readonly TResult Current 
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector(source.Span[index]);
                }
                readonly TResult IEnumerator<TResult>.Current 
                    => selector(source.Span[index])!;
                readonly object? IEnumerator.Current 
                    => selector(source.Span[index]);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    var span = source.Span;
                    while (++index <= end)
                    {
                        if (predicate.Invoke(span[index]))
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
                => ArrayExtensions.Count<TSource, TPredicate>(source.Span, predicate);

            public bool Any()
                => ArrayExtensions.Any<TSource, TPredicate>(source.Span, predicate);
                
            public Option<TResult> ElementAt(int index)
                => ArrayExtensions.ElementAt<TSource, TResult, TPredicate>(source.Span, index, predicate, selector);

            public Option<TResult> First()
                => ArrayExtensions.First<TSource, TResult, TPredicate>(source.Span, predicate, selector);

            public Option<TResult> Single()
                => ArrayExtensions.Single<TSource, TResult, TPredicate>(source.Span, predicate, selector);

            public TResult[] ToArray()
                => ArrayExtensions.ToArray<TSource, TResult, TPredicate>(source.Span, predicate, selector);

            public IMemoryOwner<TResult> ToArray(MemoryPool<TResult> memoryPool)
                => ArrayExtensions.ToArray<TSource, TResult, TPredicate>(source, predicate, selector, memoryPool);

            public List<TResult> ToList()
                => ArrayExtensions.ToList<TSource, TResult, TPredicate>(source, predicate, selector); // memory performs best

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

