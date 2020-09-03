using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerable
    {
        
        public static ReturnEnumerable<TSource> Return<TSource>([AllowNull] TSource value) =>
            new ReturnEnumerable<TSource>(value);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ReturnEnumerable<TSource>
            : IAsyncValueEnumerable<TSource, ReturnEnumerable<TSource>.DisposableEnumerator>
        {
            [AllowNull, MaybeNull] internal readonly TSource value;

            internal ReturnEnumerable([AllowNull] TSource value) 
                => this.value = value;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetAsyncEnumerator() 
                => new Enumerator(in this);
            readonly DisposableEnumerator IAsyncValueEnumerable<TSource, DisposableEnumerator>.GetAsyncEnumerator(CancellationToken _) 
                => new DisposableEnumerator(in this);
            readonly IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken _) 
                => new DisposableEnumerator(in this);

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
            {
                bool moveNext;

                internal Enumerator(in ReturnEnumerable<TSource> enumerable)
                {
                    Current = enumerable.value;
                    moveNext = true;
                }

                [MaybeNull]
                public readonly TSource Current { get; }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public ValueTask<bool> MoveNextAsync()
                {
                    var previous = moveNext;
                    moveNext = false;
                    return new ValueTask<bool>(previous);
                }
            }

            [StructLayout(LayoutKind.Auto)]
            public struct DisposableEnumerator
                : IAsyncEnumerator<TSource>
            {
                bool moveNext;

                internal DisposableEnumerator(in ReturnEnumerable<TSource> enumerable)
                {
                    Current = enumerable.value;
                    moveNext = true;
                }

                [MaybeNull]
                public readonly TSource Current { get; }
                readonly TSource IAsyncEnumerator<TSource>.Current 
                    => Current!;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public ValueTask<bool> MoveNextAsync()
                {
                    var previous = moveNext;
                    moveNext = false;
                    return new ValueTask<bool>(previous);
                }

                public readonly ValueTask DisposeAsync() 
                    => default;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AnyAsync()
                => new ValueTask<bool>(result: true);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> ContainsAsync(TSource value, IEqualityComparer<TSource>? comparer)
                => comparer is null
                    ? new ValueTask<bool>(result: EqualityComparer<TSource>.Default.Equals(this.value, value))
                    : new ValueTask<bool>(result: comparer.Equals(this.value, value));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReturnEnumerable<TResult> Select<TResult>(AsyncSelector<TSource, TResult> selector)
                => new ReturnEnumerable<TResult>(selector(value, CancellationToken.None).GetAwaiter().GetResult());

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Option<TSource>> ElementAtAsync(int index)
                => index switch
                { 
                    0 => new ValueTask<Option<TSource>>(result: Option.Some(value)),
                    _ => default,
                };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Option<TSource>> FirstAsync()
                => new ValueTask<Option<TSource>>(result: Option.Some(value));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Option<TSource>> SingleAsync()
                => new ValueTask<Option<TSource>>(result: Option.Some(value));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<TSource[]> ToArrayAsync()
                => new ValueTask<TSource[]>(result: new TSource[] { value });

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<List<TSource>> ToListAsync()
                => new ValueTask<List<TSource>>(result: new List<TSource>(1) { value });

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Dictionary<TKey, TSource>> ToDictionaryAsync<TKey>(Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => new ValueTask<Dictionary<TKey, TSource>>(result: new Dictionary<TKey, TSource>(1, comparer) { { keySelector(value), value } });

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement>(Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => new ValueTask<Dictionary<TKey, TElement>>(result: new Dictionary<TKey, TElement>(1, comparer) { { keySelector(value), elementSelector(value)! } });
        }

#pragma warning disable IDE0060 // Remove unused parameter
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<int> CountAsync<TSource>(this in ReturnEnumerable<TSource> source)
            => new ValueTask<int>(result: 1);
#pragma warning restore IDE0060 // Remove unused parameter
    }
}

