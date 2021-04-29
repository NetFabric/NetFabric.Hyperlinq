## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|                  ForLoop | 1000 |   100 |     63.79 ns |   0.334 ns |   0.261 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                     Linq | 1000 |   100 |    977.81 ns |   7.051 ns |   6.596 ns |  15.33 |    0.14 |  0.0725 |     - |     - |     152 B |
|               LinqFaster | 1000 |   100 |    332.95 ns |   2.790 ns |   2.473 ns |   5.22 |    0.05 |  0.6080 |     - |     - |   1,272 B |
|             LinqFasterer | 1000 |   100 |    463.03 ns |   2.622 ns |   2.452 ns |   7.27 |    0.04 |  0.4206 |     - |     - |     880 B |
|                   LinqAF | 1000 |   100 |  2,780.20 ns |  12.121 ns |  11.338 ns |  43.60 |    0.18 |       - |     - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 40,195.64 ns | 177.896 ns | 157.701 ns | 629.92 |    4.09 | 14.8926 |     - |     - |  31,181 B |
|                  Streams | 1000 |   100 |  6,805.88 ns |  30.537 ns |  27.070 ns | 106.59 |    0.33 |  0.4349 |     - |     - |     912 B |
|               StructLinq | 1000 |   100 |    277.05 ns |   1.781 ns |   1.487 ns |   4.35 |    0.02 |  0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    165.88 ns |   0.499 ns |   0.442 ns |   2.60 |    0.02 |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |    228.69 ns |   1.147 ns |   0.958 ns |   3.59 |    0.02 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    207.03 ns |   0.774 ns |   0.724 ns |   3.25 |    0.02 |       - |     - |     - |         - |
