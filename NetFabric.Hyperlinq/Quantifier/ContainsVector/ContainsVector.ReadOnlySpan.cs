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

                for (var index = source.Length - (source.Length % Vector<TSource>.Count); index < source.Length; index++)
                {
                    var item = source[index];
                    if (GenericsOperator.Equals(item, value))
                        return true;
                }           
            }
            else
            {
                foreach (var item in source)
                {
                    if (GenericsOperator.Equals(item, value))
                        return true;
                }           
            }

            return false;
        }

        [GeneratorIgnore]
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

                for (var index = source.Length - (source.Length % Vector<TSource>.Count); index < source.Length; index++)
                {
                    var item = source[index];
                    if (GenericsOperator.Equals(selector.Invoke(item), value))
                        return true;
                }
            }
            else
            {
                foreach (var item in source)
                {
                    if (GenericsOperator.Equals(selector.Invoke(item), value))
                        return true;
                }
            }

            return false;
        }
    }
}

