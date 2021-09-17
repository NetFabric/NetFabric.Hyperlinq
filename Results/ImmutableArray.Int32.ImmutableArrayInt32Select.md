## ImmutableArray.Int32.ImmutableArrayInt32Select

### Source
[ImmutableArrayInt32Select.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Select.cs)

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
|                  ForLoop |   100 |     61.46 ns |   0.157 ns |   0.147 ns |       baseline |         |       - |         - |
|              ForeachLoop |   100 |     61.94 ns |   0.093 ns |   0.072 ns |   1.01x slower |   0.00x |       - |         - |
|                     Linq |   100 |    379.47 ns |   1.456 ns |   1.216 ns |   6.18x slower |   0.03x |  0.0229 |      48 B |
|             LinqFasterer |   100 |    444.11 ns |   2.548 ns |   2.259 ns |   7.23x slower |   0.04x |  0.4320 |     904 B |
|            LinqOptimizer |   100 | 40,275.61 ns | 273.803 ns | 256.115 ns | 655.35x slower |   4.88x | 13.6108 |  28,584 B |
|                  Streams |   100 |  1,592.38 ns |   5.598 ns |   5.236 ns |  25.91x slower |   0.06x |  0.2899 |     608 B |
|               StructLinq |   100 |    225.99 ns |   0.998 ns |   0.885 ns |   3.68x slower |   0.02x |  0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |    175.00 ns |   0.464 ns |   0.434 ns |   2.85x slower |   0.01x |       - |         - |
|                Hyperlinq |   100 |    255.71 ns |   1.255 ns |   1.048 ns |   4.16x slower |   0.02x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    199.78 ns |   0.441 ns |   0.413 ns |   3.25x slower |   0.01x |       - |         - |
