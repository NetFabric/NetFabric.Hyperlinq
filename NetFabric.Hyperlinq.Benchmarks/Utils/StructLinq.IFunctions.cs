using StructLinq;

namespace NetFabric.Hyperlinq.Benchmarks
{
    struct IsEven : IFunction<int, bool>
    {
        public bool Eval(int element) => (element & 0x01) == 0;
    }

    struct Double : IFunction<int, int>
    {
        public int Eval(int element) => element * 2;
    }
}