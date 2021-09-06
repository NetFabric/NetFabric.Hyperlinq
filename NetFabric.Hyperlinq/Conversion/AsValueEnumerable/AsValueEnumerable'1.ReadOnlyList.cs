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

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerable<IReadOnlyList<TSource>, TSource> AsValueEnumerable<TSource>(this IReadOnlyList<TSource> source)
            => new(source);

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerable<TList, TSource> AsValueEnumerable<TList, TSource>(this TList source)
            where TList : IReadOnlyList<TSource>
            => new(source);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ValueEnumerable<TList, TSource>
            : IValueReadOnlyList<TSource, ValueEnumerator<TSource>>
            , IList<TSource>
            where TList : IReadOnlyList<TSource>
        {
            readonly TList source;

            internal ValueEnumerable(TList source) 
                => this.source = source;

            public TSource this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source[index];
            }

            TSource IList<TSource>.this[int index]
            {
                get => source[index];
                [DoesNotReturn]
                // ReSharper disable once ValueParameterNotUsed
                set => Throw.NotSupportedException();
            }

            public int Count
                => source.Count;

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerator<TSource> GetEnumerator() 
                => new(source.GetEnumerator());
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => source.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() 
                => source.GetEnumerator();

            bool ICollection<TSource>.IsReadOnly  
                => true;

            public void CopyTo(TSource[] array, int arrayIndex)
            {
                if (Count is 0)
                    return;
                
                if (array.Length - arrayIndex < Count)
                    Throw.ArgumentException(Resource.DestinationNotLongEnough, nameof(array));

                // ReSharper disable once HeapView.PossibleBoxingAllocation
                if (source is ICollection<TSource> collection)
                {
                    collection.CopyTo(array, arrayIndex);
                }
                else
                {
                    using var enumerator = GetEnumerator();
                    if (arrayIndex is 0 && array.Length == Count) // to enable range check elimination
                    {
                        for (var index = 0; index < array.Length; index++)
                        {
                            _ = enumerator.MoveNext();
                            array[index] = enumerator.Current;
                        }
                    }
                    else
                    {
                        checked
                        {
                            for (var index = arrayIndex; enumerator.MoveNext(); index++)
                                array[index] = enumerator.Current;
                        }
                    }
                }
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            bool ICollection<TSource>.Contains(TSource item)
                => Contains(item, default);

            public int IndexOf(TSource item)
            {
                return source switch
                {
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    IList<TSource> list => list.IndexOf(item),
                    
                    _ => IndexOfEnumerable(this, item),
                };

                static int IndexOfEnumerable(ValueEnumerable<TList, TSource> source, TSource item)
                {
                    using var enumerator = source.GetEnumerator();
                    for (var index = 0; enumerator.MoveNext(); index++)
                    {
                        if (EqualityComparer<TSource>.Default.Equals(enumerator.Current, item))
                            return index;
                    }
                    return -1;
                }
            }

            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Add(TSource item) 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Clear() 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            bool ICollection<TSource>.Remove(TSource item) 
                => Throw.NotSupportedException<bool>();

            [ExcludeFromCodeCoverage]
            void IList<TSource>.Insert(int index, TSource item) 
                => Throw.NotSupportedException<bool>();
            [ExcludeFromCodeCoverage]
            void IList<TSource>.RemoveAt(int index) 
                => Throw.NotSupportedException<bool>();

            #region Partitioning

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<ValueEnumerable<TList, TSource>, TSource> Skip(int count)
                => this.Skip<ValueEnumerable<TList, TSource>, TSource>(count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<ValueEnumerable<TList, TSource>, TSource> Take(int count)
                => this.Take<ValueEnumerable<TList, TSource>, TSource>(count);

            #endregion

            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerable<TList, TSource> AsValueEnumerable()
                => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IReadOnlyCollection<TSource> AsEnumerable()
                // ReSharper disable once HeapView.PossibleBoxingAllocation
                => source;

            public TSource[] ToArray()
            {
                if (source.Count is 0)
                    return Array.Empty<TSource>();

                var result = Utils.AllocateUninitializedArray<TSource>(source.Count);
                CopyTo(result, 0);
                return result;
            }
            
            public Lease<TSource> ToArray(ArrayPool<TSource> pool, bool clearOnDispose = default)
            {
                if (source.Count is 0)
                    return Lease<TSource>.Default;

                var result = pool.Lease(source.Count, clearOnDispose);
                CopyTo(result.Rented, 0);
                return result;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => ToArray().AsList();

            #endregion
            
            #region Projection

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueReadOnlyListExtensions.SelectEnumerable<ValueEnumerable<TList, TSource>, ValueEnumerator<TSource>, TSource, TResult, FunctionWrapper<TSource, TResult>> Select<TResult>(Func<TSource, TResult> selector)
                => ValueReadOnlyListExtensions.Select<ValueEnumerable<TList, TSource>, ValueEnumerator<TSource>, TSource, TResult>(this, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueReadOnlyListExtensions.SelectEnumerable<ValueEnumerable<TList, TSource>, ValueEnumerator<TSource>, TSource, TResult, TSelector> Select<TResult, TSelector>(TSelector selector = default)
                where TSelector : struct, IFunction<TSource, TResult>
                => ValueReadOnlyListExtensions.Select<ValueEnumerable<TList, TSource>, ValueEnumerator<TSource>, TSource, TResult, TSelector>(this, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueReadOnlyListExtensions.SelectAtEnumerable<ValueEnumerable<TList, TSource>, ValueEnumerator<TSource>, TSource, TResult, FunctionWrapper<TSource, int, TResult>> Select<TResult>(Func<TSource, int, TResult> selector)
                => ValueReadOnlyListExtensions.Select<ValueEnumerable<TList, TSource>, ValueEnumerator<TSource>, TSource, TResult>(this, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueReadOnlyListExtensions.SelectAtEnumerable<ValueEnumerable<TList, TSource>, ValueEnumerator<TSource>, TSource, TResult, TSelector> SelectAt<TResult, TSelector>(TSelector selector = default)
                where TSelector : struct, IFunction<TSource, int, TResult>
                => ValueReadOnlyListExtensions.SelectAt<ValueEnumerable<TList, TSource>, ValueEnumerator<TSource>, TSource, TResult, TSelector>(this, selector);

            #endregion
            
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer = default)
                => Count is not 0 && source.Contains(value);
            
            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TList, TSource>(this ValueEnumerable<TList, TSource> source)
            where TList : IReadOnlyList<TSource>
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TList, TSource>(this ValueEnumerable<TList, TSource> source, Func<TSource, bool> predicate)
            where TList : IReadOnlyList<TSource>
            => source.Count(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TList, TSource, TPredicate>(this ValueEnumerable<TList, TSource> source, TPredicate predicate = default)
            where TList : IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            => source.Count(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TList, TSource>(this ValueEnumerable<TList, TSource> source, Func<TSource, int, bool> predicate)
            where TList : IReadOnlyList<TSource>
            => source.Count(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CountAt<TList, TSource, TPredicate>(this ValueEnumerable<TList, TSource> source, TPredicate predicate = default)
            where TList : IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.CountAt(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TList>(this ValueEnumerable<TList, int> source)
            where TList : IReadOnlyList<int>
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<TList, int>, ValueEnumerator<int>, int, int>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TList>(this ValueEnumerable<TList, int?> source)
            where TList : IReadOnlyList<int?>
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<TList, int?>, ValueEnumerator<int?>, int?, int>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TList>(this ValueEnumerable<TList, nint> source)
            where TList : IReadOnlyList<nint>
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<TList, nint>, ValueEnumerator<nint>, nint, nint>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TList>(this ValueEnumerable<TList, nint?> source)
            where TList : IReadOnlyList<nint?>
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<TList, nint?>, ValueEnumerator<nint?>, nint?, nint>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TList>(this ValueEnumerable<TList, nuint> source)
            where TList : IReadOnlyList<nuint>
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<TList, nuint>, ValueEnumerator<nuint>, nuint, nuint>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TList>(this ValueEnumerable<TList, nuint?> source)
            where TList : IReadOnlyList<nuint?>
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<TList, nuint?>, ValueEnumerator<nuint?>, nuint?, nuint>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TList>(this ValueEnumerable<TList, long> source)
            where TList : IReadOnlyList<long>
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<TList, long>, ValueEnumerator<long>, long, long>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TList>(this ValueEnumerable<TList, long?> source)
            where TList : IReadOnlyList<long?>
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<TList, long?>, ValueEnumerator<long?>, long?, long>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TList>(this ValueEnumerable<TList, float> source)
            where TList : IReadOnlyList<float>
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<TList, float>, ValueEnumerator<float>, float, float>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TList>(this ValueEnumerable<TList, float?> source)
            where TList : IReadOnlyList<float?>
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<TList, float?>, ValueEnumerator<float?>, float?, float>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TList>(this ValueEnumerable<TList, double> source)
            where TList : IReadOnlyList<double>
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<TList, double>, ValueEnumerator<double>, double, double>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TList>(this ValueEnumerable<TList, double?> source)
            where TList : IReadOnlyList<double?>
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<TList, double?>, ValueEnumerator<double?>, double?, double>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TList>(this ValueEnumerable<TList, decimal> source)
            where TList : IReadOnlyList<decimal>
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<TList, decimal>, ValueEnumerator<decimal>, decimal, decimal>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TList>(this ValueEnumerable<TList, decimal?> source)
            where TList : IReadOnlyList<decimal?>
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<TList, decimal?>, ValueEnumerator<decimal?>, decimal?, decimal>(source);
    }
}