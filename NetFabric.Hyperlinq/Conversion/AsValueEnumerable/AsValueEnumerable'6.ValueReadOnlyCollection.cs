using System;
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
        public static ValueEnumerable<TEnumerable, TEnumerator, TEnumerator, TSource, FunctionWrapper<TEnumerable, TEnumerator>, FunctionWrapper<TEnumerable, TEnumerator>> AsValueEnumerable<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TEnumerable, TEnumerator> getEnumerator)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => AsValueEnumerable<TEnumerable, TEnumerator, TSource, FunctionWrapper<TEnumerable, TEnumerator>>(source, new FunctionWrapper<TEnumerable, TEnumerator>(getEnumerator));

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerable<TEnumerable, TEnumerator, TEnumerator, TSource, TGetEnumerator, TGetEnumerator> AsValueEnumerable<TEnumerable, TEnumerator, TSource, TGetEnumerator>(this TEnumerable source, TGetEnumerator getEnumerator = default)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            => new(source, getEnumerator, getEnumerator);

        
        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, FunctionWrapper<TEnumerable, TEnumerator>, FunctionWrapper<TEnumerable, TEnumerator2>> AsValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource>(this TEnumerable source, Func<TEnumerable, TEnumerator> getEnumerator, Func<TEnumerable, TEnumerator2> getEnumerator2)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TEnumerator2 : struct
            => AsValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, FunctionWrapper<TEnumerable, TEnumerator>, FunctionWrapper<TEnumerable, TEnumerator2>>(source, new FunctionWrapper<TEnumerable, TEnumerator>(getEnumerator), new FunctionWrapper<TEnumerable, TEnumerator2>(getEnumerator2));

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetEnumerator, TGetEnumerator2> AsValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetEnumerator, TGetEnumerator2>(this TEnumerable source, TGetEnumerator getEnumerator = default, TGetEnumerator2 getEnumerator2 = default)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => new(source, getEnumerator, getEnumerator2);

        [GeneratorBindings(source: "source", sourceImplements: "IValueReadOnlyCollection`2,IValueEnumerable`2")]
        [StructLayout(LayoutKind.Auto)]
        public partial struct ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetEnumerator, TGetEnumerator2>
            : IValueReadOnlyCollection<TSource, TEnumerator> 
            , ICollection<TSource>
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
        {
            readonly TEnumerable source;
            TGetEnumerator getEnumerator;
            TGetEnumerator2 getEnumerator2;

            internal ValueEnumerable(TEnumerable source, TGetEnumerator getEnumerator, TGetEnumerator2 getEnumerator2)
                => (this.source, this.getEnumerator, this.getEnumerator2) = (source, getEnumerator, getEnumerator2);
            
            public readonly int Count
                => source.Count;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TEnumerator2 GetEnumerator() 
                => getEnumerator2.Invoke(source);
            TEnumerator IValueEnumerable<TSource, TEnumerator>.GetEnumerator() 
                => getEnumerator.Invoke(source);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => source.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => source.GetEnumerator();

            bool ICollection<TSource>.IsReadOnly  
                => true;

            public void CopyTo(Span<TSource> span)
            {
                if (Count is 0)
                    return;
                
                if (span.Length < Count)
                    Throw.ArgumentException(Resource.DestinationNotLongEnough, nameof(span));

                using var enumerator = getEnumerator.Invoke(source);
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
                        CopyTo(array.AsSpan().Slice(arrayIndex));
                        break;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource item)
                => source switch
                {
                    ICollection<TSource> collection => collection.Contains(item),
                    _ => Count is not 0 && source.Contains(item),
                };

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

            public ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetEnumerator, TGetEnumerator2> AsValueEnumerable()
                => this;

            public TEnumerable AsEnumerable()
                => source;

            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, int, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IValueReadOnlyCollection<int, TEnumerator>
            where TEnumerator : struct, IEnumerator<int>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, int, TGetEnumerator, TGetEnumerator2>, TEnumerator, int, int>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, int?, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IValueReadOnlyCollection<int?, TEnumerator>
            where TEnumerator : struct, IEnumerator<int?>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, int?, TGetEnumerator, TGetEnumerator2>, TEnumerator, int?, int>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, long, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IValueReadOnlyCollection<long, TEnumerator>
            where TEnumerator : struct, IEnumerator<long>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, long, TGetEnumerator, TGetEnumerator2>, TEnumerator, long, long>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, long?, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IValueReadOnlyCollection<long?, TEnumerator>
            where TEnumerator : struct, IEnumerator<long?>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, long?, TGetEnumerator, TGetEnumerator2>, TEnumerator, long?, long>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, float, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IValueReadOnlyCollection<float, TEnumerator>
            where TEnumerator : struct, IEnumerator<float>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, float, TGetEnumerator, TGetEnumerator2>, TEnumerator, float, float>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, float?, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IValueReadOnlyCollection<float?, TEnumerator>
            where TEnumerator : struct, IEnumerator<float?>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, float?, TGetEnumerator, TGetEnumerator2>, TEnumerator, float?, float>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, double, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IValueReadOnlyCollection<double, TEnumerator>
            where TEnumerator : struct, IEnumerator<double>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, double, TGetEnumerator, TGetEnumerator2>, TEnumerator, double, double>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, double?, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IValueReadOnlyCollection<double?, TEnumerator>
            where TEnumerator : struct, IEnumerator<double?>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, double?, TGetEnumerator, TGetEnumerator2>, TEnumerator, double?, double>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, decimal, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IValueReadOnlyCollection<decimal, TEnumerator>
            where TEnumerator : struct, IEnumerator<decimal>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, decimal, TGetEnumerator, TGetEnumerator2>, TEnumerator, decimal, decimal>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, decimal?, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IValueReadOnlyCollection<decimal?, TEnumerator>
            where TEnumerator : struct, IEnumerator<decimal?>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, decimal?, TGetEnumerator, TGetEnumerator2>, TEnumerator, decimal?, decimal>(source);
    }
}