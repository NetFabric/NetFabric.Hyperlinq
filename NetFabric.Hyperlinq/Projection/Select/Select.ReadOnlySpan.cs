﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanSelectEnumerable<TSource, TResult> Select<TSource, TResult>(
            this ReadOnlySpan<TSource> source, 
            Selector<TSource, TResult> selector)
        {
            if (selector is null) Throw.ArgumentNullException(nameof(selector));

            return new SpanSelectEnumerable<TSource, TResult>(in source, selector);
        }

        [GeneratorMapping("TSource", "TResult")]
        public readonly ref struct SpanSelectEnumerable<TSource, TResult>
        {
            internal readonly ReadOnlySpan<TSource> source;
            internal readonly Selector<TSource, TResult> selector;

            internal SpanSelectEnumerable(in ReadOnlySpan<TSource> source, Selector<TSource, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);

            public readonly int Count => source.Length;

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
                readonly Selector<TSource, TResult> selector;
                int index;

                internal Enumerator(in SpanSelectEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    index = -1;
                }

                public readonly TResult Current 
                    => selector(source[index]);

                public bool MoveNext() 
                    => ++index < source.Length;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Length != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TResult value, IEqualityComparer<TResult>? comparer = null)
                => Array.Contains<TSource, TResult>(source, value, comparer, selector);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => Array.ElementAt<TSource, TResult>(source, index, selector);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => Array.First<TSource, TResult>(source, selector);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => Array.Single<TSource, TResult>(source, selector);

            public TResult[] ToArray()
                => Array.ToArray(source, selector);

            public List<TResult> ToList()
                => Array.ToList(source, selector);

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

                    if (!comparer.Equals(enumerator.Current, otherEnumerator.Current))
                        return false;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource, TResult>(this SpanSelectEnumerable<TSource, TResult> source)
            => source.Count;
    }
}

