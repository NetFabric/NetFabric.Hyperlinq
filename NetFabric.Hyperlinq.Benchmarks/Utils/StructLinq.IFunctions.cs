namespace NetFabric.Hyperlinq.Benchmarks
{
    struct IsEven 
        : IFunction<int, bool>
        , StructLinq.IFunction<int, bool>
    {
        public bool Invoke(int element) => (element & 0x01) == 0;
        public bool Eval(int element) => (element & 0x01) == 0;
    }

    struct Double 
        : IFunction<int, int>
        , StructLinq.IFunction<int, int>
    {
        public int Invoke(int element) => element * 2;
        public int Eval(int element) => element * 2;
    }
}