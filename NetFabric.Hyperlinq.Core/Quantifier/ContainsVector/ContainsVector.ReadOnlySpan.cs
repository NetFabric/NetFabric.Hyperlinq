using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        static bool ContainsVector<TSource>(this ReadOnlySpan<TSource> source, TSource value)
            where TSource : struct
        {
            if (source.IsEmpty)
                return false;
            
            if (Vector.IsHardwareAccelerated && source.Length > Vector<TSource>.Count * 2)
            {
                var vectors = MemoryMarshal.Cast<TSource, Vector<TSource>>(source);
                var vectorValue = new Vector<TSource>(value);

                foreach (var vector in vectors)
                {
                    if (Vector.EqualsAny(vector, vectorValue))
                        return true;
                }

                var count = source.Length % Vector<TSource>.Count;
                source = source.Slice(source.Length - count, count);
            }
            foreach (var item in source)
            {
                if (Scalar.Equals(item, value))
                    return true;
            }           
            return false;
        }


        static bool ContainsVector<TSource, TResult, TVectorSelector, TSelector>(this ReadOnlySpan<TSource> source, TResult value, TVectorSelector vectorSelector, TSelector selector)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
        {
            if (source.IsEmpty)
                return false;
            
            if (Vector.IsHardwareAccelerated && source.Length > Vector<TSource>.Count * 2)
            {
                var vectors = MemoryMarshal.Cast<TSource, Vector<TSource>>(source);
                var vectorValue = new Vector<TResult>(value);

                foreach (var vector in vectors)
                {
                    if (Vector.EqualsAny(vectorSelector.Invoke(vector), vectorValue))
                        return true;
                }

                var count = source.Length % Vector<TSource>.Count;
                source = source.Slice(source.Length - count, count);
            }
            foreach (var item in source)
            {
                if (Scalar.Equals(selector.Invoke(item), value))
                    return true;
            }
            return false;
        }
    }
}

