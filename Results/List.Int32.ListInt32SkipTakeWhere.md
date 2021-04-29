## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Skip | Count |        Mean |     Error |    StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |------------:|----------:|----------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop | 1000 |   100 |    116.6 ns |   0.68 ns |   0.64 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop | 1000 |   100 |  3,748.5 ns |  12.21 ns |  10.82 ns |  32.13 |    0.18 |  0.0191 |     - |     - |      40 B |
|                     Linq | 1000 |   100 |    642.1 ns |   2.75 ns |   2.57 ns |   5.51 |    0.04 |  0.0725 |     - |     - |     152 B |
|               LinqFaster | 1000 |   100 |    907.7 ns |   7.87 ns |   7.36 ns |   7.78 |    0.07 |  0.7458 |     - |     - |   1,560 B |
|                   LinqAF | 1000 |   100 |  6,505.2 ns |  22.97 ns |  21.48 ns |  55.78 |    0.33 |       - |     - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 56,231.6 ns | 390.49 ns | 365.27 ns | 482.21 |    4.32 | 15.6860 |     - |     - |  32,884 B |
|                  Streams | 1000 |   100 |  7,490.0 ns |  41.52 ns |  38.84 ns |  64.23 |    0.57 |  0.4425 |     - |     - |     936 B |
|               StructLinq | 1000 |   100 |    284.9 ns |   4.10 ns |   3.83 ns |   2.44 |    0.04 |  0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    168.6 ns |   0.58 ns |   0.52 ns |   1.45 |    0.01 |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |    288.9 ns |   3.86 ns |   3.22 ns |   2.48 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    221.3 ns |   0.59 ns |   0.50 ns |   1.90 |    0.01 |       - |     - |     - |         - |
