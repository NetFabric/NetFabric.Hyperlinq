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
        public static MemoryWhereEnumerable<TSource> Where<TSource>(this ReadOnlyMemory<TSource> source, Predicate<TSource> predicate) 
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return new MemoryWhereEnumerable<TSource>(source, predicate);
        }

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct MemoryWhereEnumerable<TSource>
            : IValueEnumerable<TSource, MemoryWhereEnumerable<TSource>.DisposableEnumerator>
        {
            internal readonly ReadOnlyMemory<TSource> source;
            internal readonly Predicate<TSource> predicate;

            internal MemoryWhereEnumerable(ReadOnlyMemory<TSource> source, Predicate<TSource> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            
            public readonly Enumerator GetEnumerator() 
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, MemoryWhereEnumerable<TSource>.DisposableEnumerator>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new DisposableEnumerator(in this);

            [StructLayout(LayoutKind.Sequential)]
            public ref struct Enumerator 
            {
                int index;
                readonly int end;
                readonly ReadOnlySpan<TSource> source;
                readonly Predicate<TSource> predicate;

                internal Enumerator(in MemoryWhereEnumerable<TSource> enumerable)
                {
                    source = enumerable.source.Span;
                    predicate = enumerable.predicate;
                    index = -1;
                    end = index + source.Length;
                }

                public readonly TSource Current 
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source[index];
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate(source[index]))
                            return true;
                    }
                    return false;
                }
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct DisposableEnumerator 
                : IEnumerator<TSource>
            {
                int index;
                readonly int end;
                readonly ReadOnlyMemory<TSource> source;
                readonly Predicate<TSource> predicate;

                internal DisposableEnumerator(in MemoryWhereEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    index = -1;
                    end = index + source.Length;
                }

                [MaybeNull]
                public readonly TSource Current 
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source.Span[index];
                }
                readonly TSource IEnumerator<TSource>.Current 
                    => source.Span[index];
                readonly object? IEnumerator.Current 
                    => source.Span[index];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    var span = source.Span;
                    while (++index <= end)
                    {
                        if (predicate(span[index]))
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
                => ArrayExtensions.Count<TSource>(source.Span, predicate);

            public bool Any()
                => ArrayExtensions.Any<TSource>(source.Span, predicate);
                
            public MemoryWhereEnumerable<TSource> Where(Predicate<TSource> predicate)
                => ArrayExtensions.Where<TSource>(source, Utils.Combine(this.predicate, predicate));

            public MemoryWhereAtEnumerable<TSource> Where(PredicateAt<TSource> predicate)
                => ArrayExtensions.Where<TSource>(source, Utils.Combine(this.predicate, predicate));

            public MemoryWhereSelectEnumerable<TSource, TResult> Select<TResult>(NullableSelector<TSource, TResult> selector)
            {
                if (selector is null)
                    Throw.ArgumentNullException(nameof(selector));

                return ArrayExtensions.WhereSelect<TSource, TResult>(source, predicate, selector);
            }

            public Option<TSource> ElementAt(int index)
                => ArrayExtensions.ElementAt(source.Span, index, predicate);

            public Option<TSource> First()
                => ArrayExtensions.First(source.Span, predicate);

            public Option<TSource> Single()
#pragma warning disable HLQ005 // Avoid Single() and SingleOrDefault()
                => ArrayExtensions.Single(source.Span, predicate);
#pragma warning restore HLQ005 // Avoid Single() and SingleOrDefault()

            public TSource[] ToArray()
                => ArrayExtensions.ToArray<TSource>(source.Span, predicate);

            public IMemoryOwner<TSource> ToArray(MemoryPool<TSource> memoryPool)
                => ArrayExtensions.ToArray<TSource>(source, predicate, memoryPool);

            public List<TSource> ToList()
                => ArrayExtensions.ToList<TSource>(source, predicate); // memory performs best

            public bool SequenceEqual(IEnumerable<TSource> other, IEqualityComparer<TSource>? comparer = null)
            {
                comparer ??= EqualityComparer<TSource>.Default;

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
    }
}

