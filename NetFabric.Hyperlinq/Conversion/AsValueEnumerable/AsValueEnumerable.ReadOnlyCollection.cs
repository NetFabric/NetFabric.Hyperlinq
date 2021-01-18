using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollectionExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableWrapper<TSource> AsValueEnumerable<TSource>(this IReadOnlyCollection<TSource> source)
            => new(source);

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableWrapper<TEnumerable, TEnumerator, TSource, FunctionWrapper<TEnumerable, TEnumerator>> AsValueEnumerable<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TEnumerable, TEnumerator> getEnumerator)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
            => AsValueEnumerable<TEnumerable, TEnumerator, TSource, FunctionWrapper<TEnumerable, TEnumerator>>(source, new FunctionWrapper<TEnumerable, TEnumerator>(getEnumerator));

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableWrapper<TEnumerable, TEnumerator, TSource, TEnumeratorGenerator> AsValueEnumerable<TEnumerable, TEnumerator, TSource, TEnumeratorGenerator>(this TEnumerable source, TEnumeratorGenerator getEnumerator)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
            where TEnumeratorGenerator : struct, IFunction<TEnumerable, TEnumerator>
            => new(source, getEnumerator);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ValueEnumerableWrapper<TEnumerable, TEnumerator, TSource, TEnumeratorGenerator>
            : IValueReadOnlyCollection<TSource, TEnumerator>
            , ICollection<TSource>
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
            where TEnumeratorGenerator : struct, IFunction<TEnumerable, TEnumerator>
        {
            readonly TEnumerable source;
            readonly TEnumeratorGenerator getEnumerator;

            internal ValueEnumerableWrapper(TEnumerable source, TEnumeratorGenerator getEnumerator)
            {
                this.source = source;
                this.getEnumerator = getEnumerator;
            }

            public readonly int Count
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source.Count;
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly TEnumerator GetEnumerator() 
                => getEnumerator.Invoke(source);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => getEnumerator.Invoke(source);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => getEnumerator.Invoke(source);

            bool ICollection<TSource>.IsReadOnly  
                => true;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(TSource[] array, int arrayIndex)
            {
                if (source.Count is not 0)
                {
                    switch (source)
                    {
                        // ReSharper disable once HeapView.PossibleBoxingAllocation
                        case ICollection<TSource> collection:
                            collection.CopyTo(array, arrayIndex);
                            break;

                        default:
                            {
                                using var enumerator = GetEnumerator();
                                checked
                                {
                                    for (var index = arrayIndex; enumerator.MoveNext(); index++)
                                        array[index] = enumerator.Current;
                                }
                            }
                            break;
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource item)
                => Count is not 0 && source.Contains<TEnumerable, TEnumerator, TSource, TEnumeratorGenerator>(getEnumerator, item);

            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Add(TSource item) 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Clear() 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            bool ICollection<TSource>.Remove(TSource item) 
                => Throw.NotSupportedException<bool>();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer)
                => Count is not 0 && source.Contains<TEnumerable, TEnumerator, TSource, TEnumeratorGenerator>(getEnumerator, value, comparer);
        }

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ValueEnumerableWrapper<TSource>
            : IValueReadOnlyCollection<TSource, ValueEnumerableWrapper<TSource>.Enumerator>
            , ICollection<TSource>
        {
            readonly IReadOnlyCollection<TSource> source;

            internal ValueEnumerableWrapper(IReadOnlyCollection<TSource> source) 
                => this.source = source;

            public readonly int Count
                => source.Count;

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() 
                => new(source);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(source);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(source);

            bool ICollection<TSource>.IsReadOnly  
                => true;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(TSource[] array, int arrayIndex)
            {
                if (source.Count is not 0)
                {
                    switch (source)
                    {
                        case ICollection<TSource> collection:
                            collection.CopyTo(array, arrayIndex);
                            break;

                        default:
                            {
                                using var enumerator = GetEnumerator();
                                checked
                                {
                                    for (var index = arrayIndex; enumerator.MoveNext(); index++)
                                        array[index] = enumerator.Current;
                                }
                            }
                            break;
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource item)
                => Count is not 0 && EnumerableExtensions.Contains(source, item);

            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Add(TSource item) 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Clear() 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            bool ICollection<TSource>.Remove(TSource item) 
                => Throw.NotSupportedException<bool>();

            [StructLayout(LayoutKind.Auto)]
            public readonly struct Enumerator
                : IEnumerator<TSource>
            {
                readonly IEnumerator<TSource> enumerator;

                internal Enumerator(IReadOnlyCollection<TSource> enumerable) 
                    => enumerator = enumerable.GetEnumerator();

                public readonly TSource Current 
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => enumerator.Current;
                }
                readonly TSource IEnumerator<TSource>.Current
                    => enumerator.Current;
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => enumerator.Current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public readonly bool MoveNext() 
                    => enumerator.MoveNext();

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => enumerator.Reset();

                public readonly void Dispose() 
                    => enumerator.Dispose();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer)
                => Count is not 0 && source.Contains(value, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this ValueEnumerableWrapper<TSource> source)
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TEnumerable, TEnumerator, TSource, TEnumeratorGenerator>(this ValueEnumerableWrapper<TEnumerable, TEnumerator, TSource, TEnumeratorGenerator> source)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
            where TEnumeratorGenerator : struct, IFunction<TEnumerable, TEnumerator>
            => source.Count;
    }
}