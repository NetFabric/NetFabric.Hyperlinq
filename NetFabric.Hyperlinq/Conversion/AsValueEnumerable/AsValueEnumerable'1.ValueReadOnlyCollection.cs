﻿using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerable<TSource, TEnumerator> AsValueEnumerable<TSource, TEnumerator>(this IValueReadOnlyCollection<TSource, TEnumerator> source)
            where TEnumerator : struct, IEnumerator<TSource>
            => new(source);

        [GeneratorBindings(source: "source", sourceImplements: "IValueReadOnlyCollection`2,IValueEnumerable`2", enumerableType: "IValueReadOnlyCollection<TSource, TEnumerator>")]
        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ValueEnumerable<TSource, TEnumerator>
            : IValueReadOnlyCollection<TSource, TEnumerator>
            , ICollection<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly IValueReadOnlyCollection<TSource, TEnumerator> source;

            internal ValueEnumerable(IValueReadOnlyCollection<TSource, TEnumerator> source) 
                => this.source = source;

            public int Count
                => source.Count;

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TEnumerator GetEnumerator() 
                => source.GetEnumerator();
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => source.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
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
            public ValueEnumerable<TSource, TEnumerator> AsValueEnumerable()
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
                    return Lease.Empty<TSource>();

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
            {
                if (Count is 0)
                    return false;
                
                if (comparer.UseDefaultComparer() && source is ICollection<TSource> collection)
                    return collection.Contains(value);

                return source.Contains<IValueEnumerable<TSource, TEnumerator>, TEnumerator, TSource>(value, comparer);
            }
            #endregion        
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource, TEnumerator>(this ValueEnumerable<TSource, TEnumerator> source)
            where TEnumerator : struct, IEnumerator<TSource>
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource, TEnumerator>(this ValueEnumerable<TSource, TEnumerator> source, Func<TSource, bool> predicate)
            where TEnumerator : struct, IEnumerator<TSource>
            => source.Count(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource, TEnumerator, TPredicate>(this ValueEnumerable<TSource, TEnumerator> source, TPredicate predicate = default)
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            => source.Count(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource, TEnumerator>(this ValueEnumerable<TSource, TEnumerator> source, Func<TSource, int, bool> predicate)
            where TEnumerator : struct, IEnumerator<TSource>
            => source.Count(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CountAt<TSource, TEnumerator, TPredicate>(this ValueEnumerable<TSource, TEnumerator> source, TPredicate predicate = default)
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.CountAt(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerator>(this ValueEnumerable<int, TEnumerator> source)
            where TEnumerator : struct, IEnumerator<int>
            => Sum<ValueEnumerable<int, TEnumerator>, TEnumerator, int, int>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerator>(this ValueEnumerable<int?, TEnumerator> source)
            where TEnumerator : struct, IEnumerator<int?>
            => Sum<ValueEnumerable<int?, TEnumerator>, TEnumerator, int?, int>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TEnumerator>(this ValueEnumerable<nint, TEnumerator> source)
            where TEnumerator : struct, IEnumerator<nint>
            => Sum<ValueEnumerable<nint, TEnumerator>, TEnumerator, nint, nint>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TEnumerator>(this ValueEnumerable<nint?, TEnumerator> source)
            where TEnumerator : struct, IEnumerator<nint?>
            => Sum<ValueEnumerable<nint?, TEnumerator>, TEnumerator, nint?, nint>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TEnumerator>(this ValueEnumerable<nuint, TEnumerator> source)
            where TEnumerator : struct, IEnumerator<nuint>
            => Sum<ValueEnumerable<nuint, TEnumerator>, TEnumerator, nuint, nuint>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TEnumerator>(this ValueEnumerable<nuint?, TEnumerator> source)
            where TEnumerator : struct, IEnumerator<nuint?>
            => Sum<ValueEnumerable<nuint?, TEnumerator>, TEnumerator, nuint?, nuint>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerator>(this ValueEnumerable<long, TEnumerator> source)
            where TEnumerator : struct, IEnumerator<long>
            => Sum<ValueEnumerable<long, TEnumerator>, TEnumerator, long, long>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerator>(this ValueEnumerable<long?, TEnumerator> source)
            where TEnumerator : struct, IEnumerator<long?>
            => Sum<ValueEnumerable<long?, TEnumerator>, TEnumerator, long?, long>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerator>(this ValueEnumerable<float, TEnumerator> source)
            where TEnumerator : struct, IEnumerator<float>
            => Sum<ValueEnumerable<float, TEnumerator>, TEnumerator, float, float>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerator>(this ValueEnumerable<float?, TEnumerator> source)
            where TEnumerator : struct, IEnumerator<float?>
            => Sum<ValueEnumerable<float?, TEnumerator>, TEnumerator, float?, float>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerator>(this ValueEnumerable<double, TEnumerator> source)
            where TEnumerator : struct, IEnumerator<double>
            => Sum<ValueEnumerable<double, TEnumerator>, TEnumerator, double, double>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerator>(this ValueEnumerable<double?, TEnumerator> source)
            where TEnumerator : struct, IEnumerator<double?>
            => Sum<ValueEnumerable<double?, TEnumerator>, TEnumerator, double?, double>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerator>(this ValueEnumerable<decimal, TEnumerator> source)
            where TEnumerator : struct, IEnumerator<decimal>
            => Sum<ValueEnumerable<decimal, TEnumerator>, TEnumerator, decimal, decimal>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerator>(this ValueEnumerable<decimal?, TEnumerator> source)
            where TEnumerator : struct, IEnumerator<decimal?>
            => Sum<ValueEnumerable<decimal?, TEnumerator>, TEnumerator, decimal?, decimal>(source);
    }
}