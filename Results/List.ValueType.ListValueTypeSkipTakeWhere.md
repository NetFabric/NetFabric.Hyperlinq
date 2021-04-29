## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

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
|                   Method | Skip | Count |        Mean |       Error |      StdDev |      Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |------------:|------------:|------------:|------------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop | 1000 |   100 |    573.4 ns |     2.04 ns |     1.81 ns |    574.0 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop | 1000 |   100 |  5,486.6 ns |    38.83 ns |    34.42 ns |  5,489.3 ns |   9.57 |    0.06 |  0.0458 |     - |     - |      96 B |
|                     Linq | 1000 |   100 |  1,475.8 ns |    27.95 ns |    26.15 ns |  1,477.9 ns |   2.58 |    0.04 |  0.1526 |     - |     - |     320 B |
|               LinqFaster | 1000 |   100 |  3,211.5 ns |    63.70 ns |    59.59 ns |  3,216.4 ns |   5.60 |    0.10 | 10.0250 |     - |     - |  21,000 B |
|                   LinqAF | 1000 |   100 | 11,322.2 ns |   221.92 ns |   246.67 ns | 11,300.8 ns |  19.76 |    0.46 |       - |     - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 68,526.8 ns | 1,985.32 ns | 5,853.77 ns | 64,817.4 ns | 124.16 |    9.64 | 73.9746 |     - |     - | 158,999 B |
|                  Streams | 1000 |   100 | 10,236.8 ns |    36.55 ns |    30.52 ns | 10,235.0 ns |  17.86 |    0.09 |  0.5493 |     - |     - |   1,176 B |
|               StructLinq | 1000 |   100 |    689.9 ns |     7.69 ns |     6.82 ns |    691.6 ns |   1.20 |    0.01 |  0.0572 |     - |     - |     120 B |
| StructLinq_ValueDelegate | 1000 |   100 |    579.4 ns |     3.04 ns |     2.70 ns |    579.0 ns |   1.01 |    0.01 |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |  1,081.6 ns |     3.27 ns |     2.90 ns |  1,081.8 ns |   1.89 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    802.6 ns |     2.21 ns |     2.07 ns |    802.4 ns |   1.40 |    0.00 |       - |     - |     - |         - |
