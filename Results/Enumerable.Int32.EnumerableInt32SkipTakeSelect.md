## Enumerable.Int32.EnumerableInt32SkipTakeSelect

### Source
[EnumerableInt32SkipTakeSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Skip | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |----- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|----------:|
|                     Linq | 1000 |   100 |  3.093 μs | 0.0084 μs | 0.0079 μs |      baseline |         |  0.0992 |     208 B |
|                   LinqAF | 1000 |   100 |  3.110 μs | 0.0098 μs | 0.0092 μs |  1.01x slower |   0.00x |  0.0191 |      40 B |
|            LinqOptimizer | 1000 |   100 | 55.203 μs | 0.2786 μs | 0.2606 μs | 17.85x slower |   0.10x | 15.5640 |  32,618 B |
|                  Streams | 1000 |   100 |  7.424 μs | 0.0189 μs | 0.0147 μs |  2.40x slower |   0.01x |  0.4349 |     920 B |
|               StructLinq | 1000 |   100 |  2.652 μs | 0.0052 μs | 0.0047 μs |  1.17x faster |   0.00x |  0.0610 |     128 B |
| StructLinq_ValueDelegate | 1000 |   100 |  2.435 μs | 0.0040 μs | 0.0036 μs |  1.27x faster |   0.00x |  0.0191 |      40 B |
|                Hyperlinq | 1000 |   100 |  3.615 μs | 0.0095 μs | 0.0089 μs |  1.17x slower |   0.00x |  0.0191 |      40 B |
|  Hyperlinq_ValueDelegate | 1000 |   100 |  2.868 μs | 0.0078 μs | 0.0073 μs |  1.08x faster |   0.00x |  0.0191 |      40 B |
