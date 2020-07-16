using System.Collections.Generic;

namespace LinqBenchmarks
{
    struct IntEqualityComparer : IEqualityComparer<int>
    {
        public bool Equals(int x, int y)
        {
            return x == y;
        }

        public int GetHashCode(int obj)
        {
            return obj;
        }

    }
}
