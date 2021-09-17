## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1417) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.1.21458.32
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |     79.18 ns |   0.335 ns |   0.313 ns |       baseline |         |       - |         - |
|              ForeachLoop |   100 |    150.64 ns |   0.597 ns |   0.529 ns |   1.90x slower |   0.01x |       - |         - |
|                     Linq |   100 |    413.02 ns |   1.674 ns |   1.566 ns |   5.22x slower |   0.03x |  0.0343 |      72 B |
|               LinqFaster |   100 |    427.29 ns |   1.661 ns |   1.553 ns |   5.40x slower |   0.03x |  0.2179 |     456 B |
|             LinqFasterer |   100 |    436.46 ns |   1.645 ns |   1.538 ns |   5.51x slower |   0.02x |  0.4206 |     880 B |
|                   LinqAF |   100 |    392.38 ns |   1.634 ns |   1.529 ns |   4.96x slower |   0.02x |       - |         - |
|            LinqOptimizer |   100 | 40,178.23 ns | 795.931 ns | 744.515 ns | 507.42x slower |   9.54x | 13.4277 |  28,183 B |
|                 SpanLinq |   100 |    304.73 ns |   1.515 ns |   1.418 ns |   3.85x slower |   0.02x |       - |         - |
|                  Streams |   100 |  1,491.45 ns |   6.213 ns |   5.812 ns |  18.84x slower |   0.12x |  0.2899 |     608 B |
|               StructLinq |   100 |    203.81 ns |   0.710 ns |   0.664 ns |   2.57x slower |   0.01x |  0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |    179.06 ns |   0.422 ns |   0.395 ns |   2.26x slower |   0.01x |       - |         - |
|                Hyperlinq |   100 |    253.21 ns |   0.363 ns |   0.283 ns |   3.20x slower |   0.01x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    208.36 ns |   0.601 ns |   0.533 ns |   2.63x slower |   0.01x |       - |         - |
