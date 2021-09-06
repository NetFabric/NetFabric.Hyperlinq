using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollectionExtensions
    {

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerable<TSource> AsValueEnumerable<TSource>(this IReadOnlyCollection<TSource> source)
            => new(source);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ValueEnumerable<TSource>
            : IValueReadOnlyCollection<TSource, ValueEnumerator<TSource>>
            , ICollection<TSource>
        {
            readonly IReadOnlyCollection<TSource> source;

            internal ValueEnumerable(IReadOnlyCollection<TSource> source) 
                => this.source = source;

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

            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Add(TSource item) 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Clear() 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            bool ICollection<TSource>.Remove(TSource item) 
                => Throw.NotSupportedException<bool>();
            
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerable<TSource> AsValueEnumerable()
                => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IReadOnlyCollection<TSource> AsEnumerable()
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
            #region Quantifier

            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer = default)
                => Count is not 0 && source.Contains(value, comparer);
            
            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this ValueEnumerable<TSource> source)
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this ValueEnumerable<TSource> source, Func<TSource, bool> predicate)
            => source.Count(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource, TPredicate>(this ValueEnumerable<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, bool>
            => source.Count(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this ValueEnumerable<TSource> source, Func<TSource, int, bool> predicate)
            => source.Count(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CountAt<TSource, TPredicate>(this ValueEnumerable<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.CountAt(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ValueEnumerable<int> source)
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<int>, ValueEnumerator<int>, int, int>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ValueEnumerable<int?> source)
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<int?>, ValueEnumerator<int?>, int?, int>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum(this ValueEnumerable<nint> source)
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<nint>, ValueEnumerator<nint>, nint, nint>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum(this ValueEnumerable<nint?> source)
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<nint?>, ValueEnumerator<nint?>, nint?, nint>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum(this ValueEnumerable<nuint> source)
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<nuint>, ValueEnumerator<nuint>, nuint, nuint>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum(this ValueEnumerable<nuint?> source)
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<nuint?>, ValueEnumerator<nuint?>, nuint?, nuint>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this ValueEnumerable<long> source)
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<long>, ValueEnumerator<long>, long, long>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this ValueEnumerable<long?> source)
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<long?>, ValueEnumerator<long?>, long?, long>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this ValueEnumerable<float> source)
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<float>, ValueEnumerator<float>, float, float>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this ValueEnumerable<float?> source)
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<float?>, ValueEnumerator<float?>, float?, float>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this ValueEnumerable<double> source)
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<double>, ValueEnumerator<double>, double, double>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this ValueEnumerable<double?> source)
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<double?>, ValueEnumerator<double?>, double?, double>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this ValueEnumerable<decimal> source)
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<decimal>, ValueEnumerator<decimal>, decimal, decimal>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this ValueEnumerable<decimal?> source)
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<decimal?>, ValueEnumerator<decimal?>, decimal?, decimal>(source);
    }
}