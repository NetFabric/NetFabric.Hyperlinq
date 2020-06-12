using System.Collections.Generic;

namespace NetFabric.Hyperlinq.UnitTests
{
    class TestComparer<T> : IEqualityComparer<T>
    {
        private TestComparer() { }

        public static TestComparer<T> Instance { get; } = new TestComparer<T>();

        public bool Equals(T x, T y) 
            => EqualityComparer<T>.Default.Equals(x, y);

        public int GetHashCode(T obj) 
            => EqualityComparer<T>.Default.GetHashCode(obj);
    }
}
