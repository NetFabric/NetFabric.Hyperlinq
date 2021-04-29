## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

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
|                   Method | Skip | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop | 1000 |   100 |     74.61 ns |   0.402 ns |   0.376 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                     Linq | 1000 |   100 |    716.49 ns |   3.460 ns |   3.068 ns |   9.61 |    0.05 |  0.0725 |     - |     - |     152 B |
|               LinqFaster | 1000 |   100 |    816.72 ns |   7.766 ns |   6.485 ns |  10.95 |    0.08 |  0.6533 |     - |     - |   1,368 B |
|             LinqFasterer | 1000 |   100 |    719.80 ns |   3.180 ns |   2.974 ns |   9.65 |    0.07 |  2.5311 |     - |     - |   5,304 B |
|                   LinqAF | 1000 |   100 |  6,097.91 ns |  26.861 ns |  22.430 ns |  81.78 |    0.49 |       - |     - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 52,797.29 ns | 183.244 ns | 162.441 ns | 708.20 |    3.31 | 15.3809 |     - |     - |  32,273 B |
|                  Streams | 1000 |   100 |  7,125.44 ns |  26.793 ns |  23.751 ns |  95.58 |    0.53 |  0.4425 |     - |     - |     936 B |
|               StructLinq | 1000 |   100 |    225.61 ns |   1.107 ns |   1.035 ns |   3.02 |    0.02 |  0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    166.78 ns |   0.783 ns |   0.732 ns |   2.24 |    0.01 |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |    229.32 ns |   0.767 ns |   0.718 ns |   3.07 |    0.02 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    210.26 ns |   0.448 ns |   0.349 ns |   2.82 |    0.01 |       - |     - |     - |         - |
