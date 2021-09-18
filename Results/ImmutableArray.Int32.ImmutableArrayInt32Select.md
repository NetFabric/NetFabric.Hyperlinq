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
|                  ForLoop |   100 |     61.49 ns |   0.083 ns |   0.065 ns |       baseline |         |       - |         - |
|              ForeachLoop |   100 |     61.97 ns |   0.078 ns |   0.061 ns |   1.01x slower |   0.00x |       - |         - |
|                     Linq |   100 |    351.64 ns |   1.790 ns |   1.495 ns |   5.71x slower |   0.02x |  0.0229 |      48 B |
|             LinqFasterer |   100 |    448.74 ns |   5.462 ns |   4.842 ns |   7.28x slower |   0.06x |  0.4320 |     904 B |
|            LinqOptimizer |   100 | 41,127.22 ns | 322.411 ns | 285.809 ns | 668.26x slower |   5.19x | 13.6108 |  28,584 B |
|                  Streams |   100 |  1,627.01 ns |   9.597 ns |   8.977 ns |  26.47x slower |   0.15x |  0.2899 |     608 B |
|               StructLinq |   100 |    226.56 ns |   0.974 ns |   0.863 ns |   3.69x slower |   0.01x |  0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |    177.05 ns |   1.388 ns |   1.230 ns |   2.88x slower |   0.02x |       - |         - |
|                Hyperlinq |   100 |    255.64 ns |   1.260 ns |   1.117 ns |   4.15x slower |   0.01x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    199.67 ns |   0.469 ns |   0.416 ns |   3.25x slower |   0.01x |       - |         - |
