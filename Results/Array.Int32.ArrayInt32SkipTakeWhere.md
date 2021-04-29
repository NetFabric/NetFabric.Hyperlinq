## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
|                  ForLoop | 1000 |   100 |     94.34 ns |   1.041 ns |   0.973 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                     Linq | 1000 |   100 |  1,205.43 ns |  11.220 ns |   9.369 ns |  12.80 |    0.14 |  0.0725 |     - |     - |     152 B |
|               LinqFaster | 1000 |   100 |    357.26 ns |   7.027 ns |   7.216 ns |   3.79 |    0.09 |  0.7191 |     - |     - |   1,504 B |
|             LinqFasterer | 1000 |   100 |    467.88 ns |   2.933 ns |   2.743 ns |   4.96 |    0.05 |  0.3285 |     - |     - |     688 B |
|                   LinqAF | 1000 |   100 |  3,082.35 ns |  10.453 ns |   9.778 ns |  32.68 |    0.39 |       - |     - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 45,206.95 ns | 310.924 ns | 290.838 ns | 479.24 |    4.63 | 15.1367 |     - |     - |  31,784 B |
|                  Streams | 1000 |   100 |  6,885.21 ns |  50.404 ns |  39.352 ns |  73.07 |    0.89 |  0.4349 |     - |     - |     912 B |
|               StructLinq | 1000 |   100 |    328.47 ns |   6.350 ns |   6.795 ns |   3.47 |    0.09 |  0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    169.98 ns |   1.428 ns |   1.335 ns |   1.80 |    0.02 |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |    300.13 ns |   3.754 ns |   3.135 ns |   3.19 |    0.05 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    248.38 ns |   1.970 ns |   1.842 ns |   2.63 |    0.04 |       - |     - |     - |         - |
