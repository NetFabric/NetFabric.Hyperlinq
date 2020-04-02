using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;

namespace NetFabric.Hyperlinq
{
    public struct AnonymousValueDisposable<TState>
        : IDisposable
    {
        TState state;
        volatile Action<TState> dispose;

        internal AnonymousValueDisposable([MaybeNull] TState state, Action<TState> dispose)
        {
            if (dispose is null) Throw.ArgumentNullException(nameof(dispose));
                 
            this.state = state;
            this.dispose = dispose;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            Interlocked.Exchange(ref dispose, default)?.Invoke(state);
            state = default;
        }
    }
}
