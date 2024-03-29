﻿using System;
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
        public static ValueEnumerable<TEnumerable, TEnumerator, TEnumerator, TSource, FunctionWrapper<TEnumerable, TEnumerator>, FunctionWrapper<TEnumerable, TEnumerator>> AsValueEnumerable<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TEnumerable, TEnumerator> getEnumerator)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
            => AsValueEnumerable<TEnumerable, TEnumerator, TSource, FunctionWrapper<TEnumerable, TEnumerator>>(source, new FunctionWrapper<TEnumerable, TEnumerator>(getEnumerator));

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerable<TEnumerable, TEnumerator, TEnumerator, TSource, TGetEnumerator, TGetEnumerator> AsValueEnumerable<TEnumerable, TEnumerator, TSource, TGetEnumerator>(this TEnumerable source, TGetEnumerator getEnumerator = default)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            => new(source, getEnumerator, getEnumerator);

        
        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, FunctionWrapper<TEnumerable, TEnumerator>, FunctionWrapper<TEnumerable, TEnumerator2>> AsValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource>(this TEnumerable source, Func<TEnumerable, TEnumerator> getEnumerator, Func<TEnumerable, TEnumerator2> getEnumerator2)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
            where TEnumerator2 : struct
            => AsValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, FunctionWrapper<TEnumerable, TEnumerator>, FunctionWrapper<TEnumerable, TEnumerator2>>(source, new FunctionWrapper<TEnumerable, TEnumerator>(getEnumerator), new FunctionWrapper<TEnumerable, TEnumerator2>(getEnumerator2));

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetEnumerator, TGetEnumerator2> AsValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetEnumerator, TGetEnumerator2>(this TEnumerable source, TGetEnumerator getEnumerator = default, TGetEnumerator2 getEnumerator2 = default)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => new(source, getEnumerator, getEnumerator2);

        [StructLayout(LayoutKind.Auto)]
        public partial struct ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetEnumerator, TGetEnumerator2>
            : IValueReadOnlyCollection<TSource, TEnumerator> 
            , ICollection<TSource>
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
        {
            readonly TEnumerable source;
#pragma warning disable IDE0044 // Add readonly modifier
            TGetEnumerator getEnumerator;
            TGetEnumerator2 getEnumerator2;
#pragma warning restore IDE0044 // Add readonly modifier

            internal ValueEnumerable(TEnumerable source, TGetEnumerator getEnumerator, TGetEnumerator2 getEnumerator2)
                => (this.source, this.getEnumerator, this.getEnumerator2) = (source, getEnumerator, getEnumerator2);
            
            public readonly int Count
                => source.Count;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly TEnumerator2 GetEnumerator() 
                => getEnumerator2.Invoke(source);
            readonly TEnumerator IValueEnumerable<TSource, TEnumerator>.GetEnumerator() 
                => getEnumerator.Invoke(source);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => source.GetEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => source.GetEnumerator();

            bool ICollection<TSource>.IsReadOnly  
                => true;

            public readonly void CopyTo(TSource[] array, int arrayIndex)
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
                    using var enumerator = getEnumerator.Invoke(source);
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
            readonly bool ICollection<TSource>.Contains(TSource item)
                => Contains(item, default);

            [ExcludeFromCodeCoverage]
            readonly void ICollection<TSource>.Add(TSource item) 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            readonly void ICollection<TSource>.Clear() 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            readonly bool ICollection<TSource>.Remove(TSource item) 
                => Throw.NotSupportedException<bool>();

            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetEnumerator, TGetEnumerator2> AsValueEnumerable()
                => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly TEnumerable AsEnumerable()
                => source;

            public readonly TSource[] ToArray()
            {
                if (source.Count is 0)
                    return Array.Empty<TSource>();

                var result = Utils.AllocateUninitializedArray<TSource>(source.Count);
                CopyTo(result, 0);
                return result;
            }
            
            public readonly Lease<TSource> ToArray(ArrayPool<TSource> pool, bool clearOnDispose = default)
            {
                if (source.Count is 0)
                    return Lease.Empty<TSource>();

                var result = pool.Lease(source.Count, clearOnDispose);
                CopyTo(result.Rented, 0);
                return result;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly List<TSource> ToList()
                => ToArray().AsList();

            #endregion
            #region Quantifier

            public readonly bool Contains(TSource value, IEqualityComparer<TSource>? comparer = default)
                => Count is not 0 && source.Contains(value, comparer);
            
            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetEnumerator, TGetEnumerator2> source, Func<TSource, bool> predicate)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => source.Count(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetEnumerator, TGetEnumerator2, TPredicate>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetEnumerator, TGetEnumerator2> source, TPredicate predicate = default)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            where TPredicate : struct, IFunction<TSource, bool>
            => source.Count(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetEnumerator, TGetEnumerator2> source, Func<TSource, int, bool> predicate)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => source.Count(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CountAt<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetEnumerator, TGetEnumerator2, TPredicate>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetEnumerator, TGetEnumerator2> source, TPredicate predicate = default)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.CountAt(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, int, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IReadOnlyCollection<int>
            where TEnumerator : struct, IEnumerator<int>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, int, TGetEnumerator, TGetEnumerator2>, TEnumerator, int, int>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, int?, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IReadOnlyCollection<int?>
            where TEnumerator : struct, IEnumerator<int?>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, int?, TGetEnumerator, TGetEnumerator2>, TEnumerator, int?, int>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, nint, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IReadOnlyCollection<nint>
            where TEnumerator : struct, IEnumerator<nint>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, nint, TGetEnumerator, TGetEnumerator2>, TEnumerator, nint, nint>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, nint?, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IReadOnlyCollection<nint?>
            where TEnumerator : struct, IEnumerator<nint?>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, nint?, TGetEnumerator, TGetEnumerator2>, TEnumerator, nint?, nint>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, nuint, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IReadOnlyCollection<nuint>
            where TEnumerator : struct, IEnumerator<nuint>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, nuint, TGetEnumerator, TGetEnumerator2>, TEnumerator, nuint, nuint>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, nuint?, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IReadOnlyCollection<nuint?>
            where TEnumerator : struct, IEnumerator<nuint?>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, nuint?, TGetEnumerator, TGetEnumerator2>, TEnumerator, nuint?, nuint>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, long, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IReadOnlyCollection<long>
            where TEnumerator : struct, IEnumerator<long>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, long, TGetEnumerator, TGetEnumerator2>, TEnumerator, long, long>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, long?, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IReadOnlyCollection<long?>
            where TEnumerator : struct, IEnumerator<long?>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, long?, TGetEnumerator, TGetEnumerator2>, TEnumerator, long?, long>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, float, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IReadOnlyCollection<float>
            where TEnumerator : struct, IEnumerator<float>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, float, TGetEnumerator, TGetEnumerator2>, TEnumerator, float, float>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, float?, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IReadOnlyCollection<float?>
            where TEnumerator : struct, IEnumerator<float?>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, float?, TGetEnumerator, TGetEnumerator2>, TEnumerator, float?, float>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, double, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IReadOnlyCollection<double>
            where TEnumerator : struct, IEnumerator<double>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, double, TGetEnumerator, TGetEnumerator2>, TEnumerator, double, double>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, double?, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IReadOnlyCollection<double?>
            where TEnumerator : struct, IEnumerator<double?>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, double?, TGetEnumerator, TGetEnumerator2>, TEnumerator, double?, double>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, decimal, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IReadOnlyCollection<decimal>
            where TEnumerator : struct, IEnumerator<decimal>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, decimal, TGetEnumerator, TGetEnumerator2>, TEnumerator, decimal, decimal>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, decimal?, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IReadOnlyCollection<decimal?>
            where TEnumerator : struct, IEnumerator<decimal?>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => ValueReadOnlyCollectionExtensions.Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, decimal?, TGetEnumerator, TGetEnumerator2>, TEnumerator, decimal?, decimal>(source);
    }
}