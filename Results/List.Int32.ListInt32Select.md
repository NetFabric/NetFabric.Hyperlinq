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
- NetFabric.Hyperlinq: [3.0.0-beta46](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta46)
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
|                  ForLoop |   100 |     79.72 ns |   1.143 ns |   1.069 ns |       baseline |         |       - |         - |
|              ForeachLoop |   100 |    151.03 ns |   0.503 ns |   0.471 ns |   1.89x slower |   0.03x |       - |         - |
|                     Linq |   100 |    427.04 ns |   5.139 ns |   4.807 ns |   5.36x slower |   0.11x |  0.0343 |      72 B |
|               LinqFaster |   100 |    380.03 ns |   6.072 ns |   5.680 ns |   4.77x slower |   0.11x |  0.2179 |     456 B |
|             LinqFasterer |   100 |    439.36 ns |   1.596 ns |   1.493 ns |   5.51x slower |   0.07x |  0.4206 |     880 B |
|                   LinqAF |   100 |    359.19 ns |   2.101 ns |   1.862 ns |   4.50x slower |   0.07x |       - |         - |
|            LinqOptimizer |   100 | 40,276.59 ns | 307.320 ns | 272.431 ns | 505.00x slower |   8.35x | 13.4277 |  28,183 B |
|                 SpanLinq |   100 |    305.02 ns |   0.582 ns |   0.486 ns |   3.83x slower |   0.05x |       - |         - |
|                  Streams |   100 |  1,502.88 ns |   5.405 ns |   4.792 ns |  18.84x slower |   0.28x |  0.2899 |     608 B |
|               StructLinq |   100 |    227.77 ns |   0.571 ns |   0.506 ns |   2.86x slower |   0.04x |  0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |    179.41 ns |   0.496 ns |   0.440 ns |   2.25x slower |   0.03x |       - |         - |
|                Hyperlinq |   100 |    227.55 ns |   0.431 ns |   0.403 ns |   2.85x slower |   0.04x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    201.55 ns |   0.338 ns |   0.317 ns |   2.53x slower |   0.04x |       - |         - |
