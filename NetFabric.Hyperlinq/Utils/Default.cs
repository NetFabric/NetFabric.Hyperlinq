using System.Diagnostics.CodeAnalysis;

namespace NetFabric.Hyperlinq
{
    static class Default<T>
    {
        static readonly T value = default!;

        [MaybeNull]
        public static ref readonly T Value => ref value;
    }
}
