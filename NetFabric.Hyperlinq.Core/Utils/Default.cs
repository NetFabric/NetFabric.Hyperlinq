namespace NetFabric.Hyperlinq
{
    static class Default<T>
    {
        static readonly T value = default!;

        public static ref readonly T Value => ref value;
    }
}
