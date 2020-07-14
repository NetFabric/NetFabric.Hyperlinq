using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanSelectEnumerable<TSource, TResult> Select<TSource, TResult>(
            this ReadOnlySpan<TSource> source, 
            NullableSelector<TSource, TResult> selector)
        {
            if (selector is null) Throw.ArgumentNullException(nameof(selector));

            return new SpanSelectEnumerable<TSource, TResult>(in source, selector);
        }

        [GeneratorMapping("TSource", "TResult")]
        public readonly ref struct SpanSelectEnumerable<TSource, TResult>
        {
            internal readonly ReadOnlySpan<TSource> source;
            internal readonly NullableSelector<TSource, TResult> selector;

            internal SpanSelectEnumerable(in ReadOnlySpan<TSource> source, NullableSelector<TSource, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            
            public readonly Enumerator GetEnumerator() 
                => new Enumerator(in this);

            public readonly int Count 
                => source.Length;

            [MaybeNull]
            public readonly TResult this[int index]
            {
                get
                {
                    if (index < 0 || index >= source.Length)
                        Throw.ArgumentOutOfRangeException(nameof(index));

                    return selector(source[index]);
                }
            }

            public ref struct Enumerator
            {
                readonly ReadOnlySpan<TSource> source;
                readonly NullableSelector<TSource, TResult> selector;
                int index;

                internal Enumerator(in SpanSelectEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    index = -1;
                }

                [MaybeNull]
                public readonly TResult Current 
                    => selector(source[index]);

                public bool MoveNext() 
                    => ++index < source.Length;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Length != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => ArrayExtensions.ElementAt<TSource, TResult>(source, index, selector);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => ArrayExtensions.First<TSource, TResult>(source, selector);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => ArrayExtensions.Single<TSource, TResult>(source, selector);

            public TResult[] ToArray()
                => ArrayExtensions.ToArray(source, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IMemoryOwner<TResult> ToArray(MemoryPool<TResult> pool)
                => ArrayExtensions.ToArray<TSource, TResult>(source, selector, pool);

            public List<TResult> ToList()
                => ArrayExtensions.ToList(source, selector);

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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource, TResult>(this SpanSelectEnumerable<TSource, TResult> source)
            => source.Count;
    }
}

