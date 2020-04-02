using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static class ValueDisposable
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AnonymousValueDisposable<TState> Create<TState>(TState state, Action<TState> dispose)
            => new AnonymousValueDisposable<TState>(state, dispose);
    }
}
