## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

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
|                   Method | Skip | Count |        Mean |     Error |    StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |------------:|----------:|----------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop | 1000 |   100 |    571.5 ns |   2.79 ns |   2.61 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                     Linq | 1000 |   100 |  1,442.8 ns |  15.60 ns |  13.03 ns |   2.52 |    0.03 |  0.1526 |     - |     - |     320 B |
|               LinqFaster | 1000 |   100 |  3,832.6 ns |  73.27 ns |  71.96 ns |   6.70 |    0.13 | 10.0250 |     - |     - |  21,000 B |
|             LinqFasterer | 1000 |   100 |  7,190.5 ns |  93.32 ns |  87.29 ns |  12.58 |    0.18 | 37.0331 |     - |     - |  80,168 B |
|                   LinqAF | 1000 |   100 | 10,852.7 ns |  91.91 ns |  71.76 ns |  18.98 |    0.18 |       - |     - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 66,793.8 ns | 566.01 ns | 529.45 ns | 116.89 |    1.07 | 73.9746 |     - |     - | 159,000 B |
|                  Streams | 1000 |   100 |  9,997.0 ns |  85.01 ns |  70.98 ns |  17.48 |    0.15 |  0.5493 |     - |     - |   1,176 B |
|               StructLinq | 1000 |   100 |    705.0 ns |   4.01 ns |   3.56 ns |   1.23 |    0.01 |  0.0572 |     - |     - |     120 B |
| StructLinq_ValueDelegate | 1000 |   100 |    601.8 ns |   1.89 ns |   1.68 ns |   1.05 |    0.00 |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |  1,612.2 ns |   4.73 ns |   4.43 ns |   2.82 |    0.02 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    803.6 ns |   3.57 ns |   2.98 ns |   1.41 |    0.01 |       - |     - |     - |         - |
