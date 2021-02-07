using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
#if NET5_0

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanSelectVectorEnumerable<TSource, TResult, FunctionWrapper<Vector<TSource>, Vector<TResult>>, FunctionWrapper<TSource, TResult>> SelectVector<TSource, TResult>(this ReadOnlySpan<TSource> source, Func<Vector<TSource>, Vector<TResult>> vectorSelector, Func<TSource, TResult> selector)
            where TSource : struct
            where TResult : struct
            => source.SelectVector<TSource, TResult, FunctionWrapper<Vector<TSource>, Vector<TResult>>, FunctionWrapper<TSource, TResult>>(new FunctionWrapper<Vector<TSource>, Vector<TResult>>(vectorSelector), new FunctionWrapper<TSource, TResult>(selector));

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanSelectVectorEnumerable<TSource, TResult, TVectorSelector, TSelector> SelectVector<TSource, TResult, TVectorSelector, TSelector>(this ReadOnlySpan<TSource> source, TVectorSelector vectorSelector = default, TSelector selector = default)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
            => new(source, vectorSelector, selector);

        [GeneratorIgnore]
        [StructLayout(LayoutKind.Auto)]
        public ref struct SpanSelectVectorEnumerable<TSource, TResult, TVectorSelector, TSelector>
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
        {
            readonly ReadOnlySpan<TSource> source;
            TVectorSelector vectorSelector;
            TSelector selector;

            internal SpanSelectVectorEnumerable(ReadOnlySpan<TSource> source, TVectorSelector vectorSelector, TSelector selector)
            {
                if (Vector<TSource>.Count != Vector<TResult>.Count)
                    Throw.NotSupportedException();

                this.source = source;
                this.vectorSelector = vectorSelector;
                this.selector = selector;
            }

            public readonly Enumerator GetEnumerator()
                => new(in this);

            [StructLayout(LayoutKind.Sequential)]
            public ref struct Enumerator
            {
                int index;
                int resultIndex;
                TResult current;
                Vector<TResult> result;
                readonly int remainingIndex;
                readonly int end;
                readonly int count;
                readonly ReadOnlySpan<TSource> source;
                TVectorSelector vectorSelector;
                TSelector selector;

                internal Enumerator(in SpanSelectVectorEnumerable<TSource, TResult, TVectorSelector, TSelector> enumerable)
                {
                    source = enumerable.source;
                    vectorSelector = enumerable.vectorSelector;
                    selector = enumerable.selector;
                    current = default;
                    index = -1;
                    end = index + source.Length;
                    result = new Vector<TResult>();
                    count = Vector<TSource>.Count;
                    remainingIndex = source.Length - (source.Length % count);
                    resultIndex = count;
                }

                public readonly TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => current;
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    if (++index > end)
                    {
                        current = default;
                        return false;
                    }

                    if (index >= remainingIndex)
                    {
                        current = selector.Invoke(source[index]);
                    }
                    else
                    {
                        if (++resultIndex >= count)
                        {
                            result = vectorSelector.Invoke(new Vector<TSource>(source[index..]));
                            resultIndex = 0;
                        }
                        current = result[resultIndex];
                    }
                    return true;
                }
            }

            #region Aggregation

            public int Count()
                => source.Length;

            #endregion

            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Length is not 0;

            #endregion

            public bool SequenceEqual(IEnumerable<TResult> other, IEqualityComparer<TResult>? comparer = null)
            {
                comparer ??= EqualityComparer<TResult>.Default;

                var enumerator = GetEnumerator();
                using var otherEnumerator = other.GetEnumerator();
                while (true)
                {
                    var thisEnded = !enumerator.MoveNext();
                    var otherEnded = !otherEnumerator.MoveNext();

                    if (thisEnded != otherEnded)
                        return false;

                    if (thisEnded)
                        return true;

                    if (!comparer.Equals(enumerator.Current!, otherEnumerator.Current))
                        return false;
                }
            }
        }

#endif    
    }
}

