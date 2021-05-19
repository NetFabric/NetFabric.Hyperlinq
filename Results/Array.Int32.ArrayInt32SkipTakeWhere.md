## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [1.0.0](https://www.nuget.org/packages/SpanLinq/1.0.0)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1538-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Skip | Count |         Mean |        Error |       StdDev |       Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |-------------:|-------------:|-------------:|-------------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop | 1000 |   100 |     88.92 ns |     0.400 ns |     0.334 ns |     88.88 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                     Linq | 1000 |   100 |  1,219.49 ns |     8.236 ns |     7.301 ns |  1,217.60 ns |  13.71 |    0.10 |  0.0725 |     - |     - |     152 B |
|               LinqFaster | 1000 |   100 |    354.13 ns |     4.903 ns |     4.346 ns |    352.94 ns |   3.98 |    0.05 |  0.7191 |     - |     - |   1,504 B |
|             LinqFasterer | 1000 |   100 |    445.33 ns |     4.018 ns |     3.137 ns |    444.46 ns |   5.01 |    0.04 |  0.3285 |     - |     - |     688 B |
|                   LinqAF | 1000 |   100 | 16,085.71 ns | 1,366.151 ns | 3,985.127 ns | 14,650.00 ns | 219.27 |   40.57 |       - |     - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 48,109.25 ns | 1,442.643 ns | 4,253.667 ns | 45,270.03 ns | 564.75 |   46.00 | 15.1367 |     - |     - |  31,784 B |
|                 SpanLinq | 1000 |   100 |    296.10 ns |     2.738 ns |     2.286 ns |    295.42 ns |   3.33 |    0.03 |       - |     - |     - |         - |
|                  Streams | 1000 |   100 |  6,774.97 ns |    47.036 ns |    39.277 ns |  6,767.85 ns |  76.20 |    0.54 |  0.4349 |     - |     - |     912 B |
|               StructLinq | 1000 |   100 |    331.25 ns |     5.052 ns |     4.726 ns |    330.59 ns |   3.72 |    0.06 |  0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    165.16 ns |     0.395 ns |     0.330 ns |    165.29 ns |   1.86 |    0.01 |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |    273.67 ns |     2.393 ns |     2.121 ns |    273.05 ns |   3.08 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    238.70 ns |     4.794 ns |     9.351 ns |    232.73 ns |   2.81 |    0.07 |       - |     - |     - |         - |
