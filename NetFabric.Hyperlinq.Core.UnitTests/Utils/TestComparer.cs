using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NetFabric.Hyperlinq.UnitTests
{
    class TestComparer<T> : IEqualityComparer<T>
    {
        public int EqualsCounter { get; private set; }
        public int GetHashCodeCounter { get; private set; }

        public bool Equals(T? x, T? y)
        {
            EqualsCounter++;
            return EqualityComparer<T>.Default.Equals(x, y);
        }

        public int GetHashCode([DisallowNull] T obj)
        {
            GetHashCodeCounter++;
            return EqualityComparer<T>.Default.GetHashCode(obj);
        }
    }
}
