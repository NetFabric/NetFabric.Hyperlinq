using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace NetFabric.Hyperlinq.Benchmarks.Benchmarks
{
    [SimpleJob(RuntimeMoniker.NetCoreApp50)]
    public class IterationBenchmarks
    {
        [Params(100_000_000)]
        public int Count { get; set; }

        [Benchmark(Baseline = true)]
        public int LessThan()
        {
            var sum = 0;
            foreach (var item in new EnumerableLessThan(Count))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LessThanOrEqual()
        {
            var sum = 0;
            foreach (var item in new EnumerableLessThanOrEqual(Count))
                sum += item;
            return sum;
        }

        readonly struct EnumerableLessThan
        {
            readonly int count;

            public EnumerableLessThan(int count) => this.count = count;

            public Enumerator GetEnumerator() => new(count);

            public struct Enumerator
            {
                int current;
                readonly int end;

                public Enumerator(int count) => (current, end) = (-1, count);

                public int Current => 1;

                public bool MoveNext() => ++current < end;
            }
        }

        readonly struct EnumerableLessThanOrEqual
        {
            readonly int count;

            public EnumerableLessThanOrEqual(int count) => this.count = count;

            public Enumerator GetEnumerator() => new(count);

            public struct Enumerator
            {
                int current;
                readonly int end;

                public Enumerator(int count) => (current, end) = (-1, count - 1);

                public int Current => 1;

                public bool MoveNext() => ++current <= end;
            }
        }
    }
}
