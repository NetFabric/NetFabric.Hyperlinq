using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NetFabric.Hyperlinq.UnitTests
{
    class TestComparer<T> : IEqualityComparer<T>
    {
        TestComparer() { }

        public static TestComparer<T> Instance { get; } 
            = new();

        public bool Equals(T? x, T? y) 
            => EqualityComparer<T>.Default.Equals(x, y);

        public int GetHashCode([DisallowNull]T obj) 
            => EqualityComparer<T>.Default.GetHashCode(obj);
    }
}
