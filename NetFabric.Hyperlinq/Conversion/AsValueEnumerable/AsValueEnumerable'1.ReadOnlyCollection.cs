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

            public void CopyTo(Span<TSource> span)
            {
                if (Count is 0)
                    return;
                
                if (span.Length < Count)
                    Throw.ArgumentException(Resource.DestinationNotLongEnough, nameof(span));

                using var enumerator = GetEnumerator();
                checked
                {
                    for (var index = 0; enumerator.MoveNext(); index++)
                        span[index] = enumerator.Current;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(TSource[] array, int arrayIndex)
            {
                switch (source)
                {
                    case ICollection<TSource> collection:
                        collection.CopyTo(array, arrayIndex);
                        break;
                    default:
                        CopyTo(array.AsSpan(arrayIndex));
                        break;
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

            public ValueEnumerable<TSource> AsValueEnumerable()
                => this;

            public IReadOnlyCollection<TSource> AsEnumerable()
                => source;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => ValueReadOnlyCollectionExtensions.ToArray<ValueEnumerable<TSource>, ValueEnumerator<TSource>, TSource>(this);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueMemoryOwner<TSource> ToArray(ArrayPool<TSource> pool, bool clearOnDispose = default)
                => ValueReadOnlyCollectionExtensions.ToArray<ValueEnumerable<TSource>, ValueEnumerator<TSource>, TSource>(this, pool, clearOnDispose);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => ValueReadOnlyCollectionExtensions.ToList<ValueEnumerable<TSource>, ValueEnumerator<TSource>, TSource>(this);

            #endregion
            #region Quantifier

            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer = default)
                => Count is not 0 && source.Contains(value);
            
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