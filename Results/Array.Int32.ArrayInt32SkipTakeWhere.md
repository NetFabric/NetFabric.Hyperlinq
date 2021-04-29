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
|                  ForLoop | 1000 |   100 |     88.80 ns |   0.361 ns |   0.320 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop | 1000 |   100 |  1,430.12 ns |   3.444 ns |   3.053 ns |  16.10 |    0.06 |  0.0153 |     - |     - |      32 B |
|                     Linq | 1000 |   100 |  1,227.29 ns |   5.005 ns |   4.179 ns |  13.83 |    0.06 |  0.0725 |     - |     - |     152 B |
|               LinqFaster | 1000 |   100 |    401.33 ns |   6.293 ns |   5.579 ns |   4.52 |    0.06 |  0.7191 |     - |     - |   1,504 B |
|             LinqFasterer | 1000 |   100 |    613.89 ns |   4.379 ns |   4.096 ns |   6.91 |    0.05 |  0.3128 |     - |     - |     656 B |
|                   LinqAF | 1000 |   100 |  2,766.31 ns |   8.751 ns |   7.307 ns |  31.16 |    0.14 |       - |     - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 44,596.35 ns | 276.256 ns | 244.894 ns | 502.20 |    3.05 | 15.1367 |     - |     - |  31,784 B |
|                  Streams | 1000 |   100 |  6,683.13 ns |  22.702 ns |  18.958 ns |  75.29 |    0.38 |  0.4349 |     - |     - |     912 B |
|               StructLinq | 1000 |   100 |    357.71 ns |   6.311 ns |   5.903 ns |   4.03 |    0.07 |  0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    166.83 ns |   0.591 ns |   0.553 ns |   1.88 |    0.01 |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |    316.63 ns |   4.373 ns |   3.877 ns |   3.57 |    0.05 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    219.58 ns |   0.708 ns |   0.662 ns |   2.47 |    0.01 |       - |     - |     - |         - |
