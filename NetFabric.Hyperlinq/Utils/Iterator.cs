using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    [Ignore]
    abstract class Iterator<TSource> 
        : IEnumerable<TSource>
        , IEnumerator<TSource>
    {
        readonly int threadId = Environment.CurrentManagedThreadId;
        protected int state = 0;
        protected TSource current = default!;

        [MaybeNull]
        public TSource Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => current;
        }

        object? IEnumerator.Current 
            => current;

        protected abstract Iterator<TSource> Clone();

        public IEnumerator<TSource> GetEnumerator()
        {
            var enumerator = state == 0 && threadId == Environment.CurrentManagedThreadId 
                ? this 
                : Clone();
            enumerator.state = 1;
            return enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public abstract bool MoveNext();

        public void Reset() => Throw.NotSupportedException();

        public virtual void Dispose()
        {
            current = default!;
            state = -1;
        }
    }
}