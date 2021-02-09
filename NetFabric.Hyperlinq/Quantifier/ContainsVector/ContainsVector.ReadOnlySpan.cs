using System;
using System.Numerics;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
#if NET5_0

        public static bool ContainsVector<TSource>(this ReadOnlySpan<TSource> source, TSource value)
            where TSource : struct
        {
            if (source.Length is 0)
                return false;

            var vectorSize = Vector<TSource>.Count;
            var vectorValue = new Vector<TSource>(value);
            var index = 0;
            for (; index < source.Length - vectorSize; index += vectorSize)
            {
                if (Vector.EqualsAny(new Vector<TSource>(source[index..]), vectorValue))
                    return true;
            }

            for (; index < source.Length; index++)
            {
                var item = source[index];
                if (GenericsOperator.Equals(item, value))
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
            if (source.Length is 0)
                return false;

            var vectorSize = Vector<TSource>.Count;
            var vectorValue = new Vector<TResult>(value);
            var index = 0;
            for (; index < source.Length - vectorSize; index += vectorSize)
            {
                if (Vector.EqualsAny(vectorSelector.Invoke(new Vector<TSource>(source[index..])), vectorValue))
                    return true;
            }

            for (; index < source.Length; index++)
            {
                var item = source[index];
                if (GenericsOperator.Equals(selector.Invoke(item), value))
                    return true;
            }
            return false;
        }

#endif
    }
}

