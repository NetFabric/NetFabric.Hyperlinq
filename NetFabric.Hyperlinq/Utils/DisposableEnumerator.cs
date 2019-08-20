using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    sealed class DisposableEnumerator<TSource, TEnumerator>
        : IEnumerator<TSource>
        where TEnumerator
        : struct
        , IValueEnumerator<TSource>
    {
        TEnumerator source; // do not make readonly
        Action<TEnumerator> disposeAction;

        public DisposableEnumerator(in TEnumerator source, Action<TEnumerator> disposeAction = null)
        {
            this.source = source;
            this.disposeAction = disposeAction;
        }

        public TSource Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => source.Current;
        }
        object IEnumerator.Current => source.Current;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext() => source.MoveNext();

        public void Reset() => throw new NotSupportedException();

        public void Dispose() 
        {
            if (disposeAction is object)
                disposeAction(source);
        }
    }
}
