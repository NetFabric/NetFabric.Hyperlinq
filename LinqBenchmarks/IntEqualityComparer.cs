using System.Collections.Generic;

namespace LinqBenchmarks
{
    struct IntEqualityComparer : IEqualityComparer<int>
    {
        public bool Equals(int x, int y) 
            => x == y;

        public int GetHashCode(int obj) 
            => obj;

    }
}
