## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |     73.31 ns |   0.861 ns |   0.806 ns |       baseline |         |       - |         - |
|              ForeachLoop |   100 |     72.99 ns |   0.722 ns |   0.640 ns |   1.01x faster |   0.02x |       - |         - |
|                     Linq |   100 |    354.27 ns |   0.633 ns |   0.592 ns |   4.83x slower |   0.05x |  0.0229 |      48 B |
|               LinqFaster |   100 |    330.20 ns |   0.917 ns |   0.858 ns |   4.50x slower |   0.05x |  0.3171 |     664 B |
|             LinqFasterer |   100 |    499.32 ns |   0.865 ns |   0.675 ns |   6.81x slower |   0.08x |  0.2136 |     448 B |
|                   LinqAF |   100 |    496.92 ns |   3.783 ns |   3.538 ns |   6.78x slower |   0.08x |       - |         - |
|            LinqOptimizer |   100 | 40,606.56 ns | 247.900 ns | 231.886 ns | 553.95x slower |   7.72x | 13.2446 |  27,702 B |
|                 SpanLinq |   100 |    245.08 ns |   0.297 ns |   0.278 ns |   3.34x slower |   0.04x |       - |         - |
|                  Streams |   100 |  1,191.59 ns |   2.056 ns |   1.822 ns |  16.25x slower |   0.19x |  0.2785 |     584 B |
|               StructLinq |   100 |    364.40 ns |   5.663 ns |   5.298 ns |   4.97x slower |   0.09x |  0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |    217.30 ns |   0.343 ns |   0.321 ns |   2.96x slower |   0.03x |       - |         - |
|                Hyperlinq |   100 |    365.38 ns |   3.842 ns |   3.594 ns |   4.98x slower |   0.08x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    222.26 ns |   0.182 ns |   0.162 ns |   3.03x slower |   0.03x |       - |         - |
