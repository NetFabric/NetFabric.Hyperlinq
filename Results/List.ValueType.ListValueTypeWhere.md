## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.985 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |        Mean |       Error |      StdDev |      Median |         Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|------------:|------------:|------------:|--------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    630.5 ns |     6.47 ns |     6.06 ns |    630.0 ns |      baseline |         |       - |     - |     - |         - |
|              ForeachLoop |   100 |    834.1 ns |     9.90 ns |     8.26 ns |    831.8 ns |  1.32x slower |   0.02x |       - |     - |     - |         - |
|                     Linq |   100 |  1,433.5 ns |    15.18 ns |    14.20 ns |  1,433.1 ns |  2.27x slower |   0.03x |  0.0877 |     - |     - |     184 B |
|               LinqFaster |   100 |  1,799.3 ns |    44.82 ns |   132.15 ns |  1,709.1 ns |  2.92x slower |   0.22x |  3.8605 |     - |     - |   8,088 B |
|             LinqFasterer |   100 |  1,813.4 ns |    23.63 ns |    22.10 ns |  1,806.9 ns |  2.88x slower |   0.03x |  4.7379 |     - |     - |   9,936 B |
|                   LinqAF |   100 |  2,296.1 ns |    33.43 ns |    31.27 ns |  2,295.7 ns |  3.64x slower |   0.06x |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 56,593.7 ns | 1,892.04 ns | 5,578.71 ns | 52,845.2 ns | 94.34x slower |   8.51x | 73.1201 |     - |     - | 154,976 B |
|                 SpanLinq |   100 |    839.2 ns |     7.94 ns |     7.04 ns |    836.1 ns |  1.33x slower |   0.01x |       - |     - |     - |         - |
|                  Streams |   100 |  2,391.1 ns |    20.55 ns |    19.23 ns |  2,394.3 ns |  3.79x slower |   0.05x |  0.4044 |     - |     - |     848 B |
|               StructLinq |   100 |    701.0 ns |     4.14 ns |     3.46 ns |    701.2 ns |  1.11x slower |   0.01x |  0.0191 |     - |     - |      40 B |
| StructLinq_ValueDelegate |   100 |    637.0 ns |     7.20 ns |     6.74 ns |    635.5 ns |  1.01x slower |   0.02x |       - |     - |     - |         - |
|                Hyperlinq |   100 |  1,125.6 ns |     7.21 ns |     6.74 ns |  1,124.6 ns |  1.79x slower |   0.02x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    850.7 ns |     4.54 ns |     4.02 ns |    850.4 ns |  1.35x slower |   0.01x |       - |     - |     - |         - |
