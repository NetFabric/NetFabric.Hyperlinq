using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    abstract class Iterator<TSource> 
        : IEnumerable<TSource>
        , IEnumerator<TSource>
    {
        readonly int threadId = Environment.CurrentManagedThreadId;
        protected int state = 0;
        protected TSource current;

        public TSource Current => current;
        object IEnumerator.Current => current;

        protected abstract Iterator<TSource> Clone();

        public IEnumerator<TSource> GetEnumerator()
        {
            var enumerator = state == 0 && threadId == Environment.CurrentManagedThreadId ? this : Clone();
            enumerator.state = 1;
            return enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public abstract bool MoveNext();

        void IEnumerator.Reset() => ThrowHelper.ThrowNotSupportedException();

        public virtual void Dispose()
        {
            current = default;
            state = -1;
        }
    }
}