using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
#if NET5_0

    [StructLayout(LayoutKind.Auto)]
    public ref struct SelectVectorEnumerator<TSource, TResult, TVectorSelector, TSelector>
        where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
        where TSelector : struct, IFunction<TSource, TResult>
        where TSource : struct
        where TResult : struct
    {
        readonly int vectorSize;
        TResult current;
        int index;
        int status;
        Vector<TResult> vector;
        ReadOnlySpan<TSource> source;
        TVectorSelector vectorSelector;
        TSelector selector;

        internal SelectVectorEnumerator(ReadOnlySpan<TSource> source, TVectorSelector vectorSelector, TSelector selector)
        {
            this.source = source;
            this.vectorSelector = vectorSelector;
            this.selector = selector;

            vectorSize = Vector<TSource>.Count;
            status = 0;
            current = default;
            index = 0;
            vector = new Vector<TResult>();
        }

        public readonly TResult Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => current;
        }

        public bool MoveNext()
        {
            switch (status)
            {
                case 0: // fill vector
                    if (source.Length < vectorSize)
                    {
                        index = -1;
                        status = 2;
                        goto case 2;
                    }

                    vector = vectorSelector.Invoke(new Vector<TSource>(source));
                    index = 0;
                    current = vector[0];
                    status = 1;
                    break;

                case 1: // handle vector
                    if (++index >= vectorSize)
                    {
                        source = source[vectorSize..];
                        status = 0;
                        goto case 0;
                    }
                    current = vector[index];
                    break;

                case 2: // handle remaining
                    if (++index >= source.Length)
                        return false;

                    current = selector.Invoke(source[index]);
                    break;
            }
            return true;
        }
    }
#endif
}
