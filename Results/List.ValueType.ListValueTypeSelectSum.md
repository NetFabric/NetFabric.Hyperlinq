## List.ValueType.ListValueTypeSelectSum

### Source
[ListValueTypeSelectSum.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelectSum.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |    166.46 ns |   0.819 ns |   0.726 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 |    409.74 ns |   4.044 ns |   3.585 ns |   2.46 |    0.03 |      - |     - |     - |         - |
|                     Linq |   100 |  1,002.74 ns |  12.867 ns |  11.406 ns |   6.02 |    0.07 | 0.0458 |     - |     - |      96 B |
|               LinqFaster |   100 |    397.54 ns |   1.867 ns |   1.655 ns |   2.39 |    0.02 |      - |     - |     - |         - |
|             LinqFasterer |   100 |    647.40 ns |  11.451 ns |  10.151 ns |   3.89 |    0.06 | 3.0670 |     - |     - |   6,424 B |
|                   LinqAF |   100 |  1,089.63 ns |  21.442 ns |  27.117 ns |   6.53 |    0.17 |      - |     - |     - |         - |
|            LinqOptimizer |   100 | 35,869.80 ns | 510.886 ns | 426.613 ns | 215.49 |    2.59 | 9.4604 |     - |     - |  19,861 B |
|                  Streams |   100 |    695.09 ns |   9.955 ns |   8.825 ns |   4.18 |    0.06 | 0.1717 |     - |     - |     360 B |
|               StructLinq |   100 |    230.56 ns |   2.158 ns |   1.913 ns |   1.39 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_ValueDelegate |   100 |     95.82 ns |   1.095 ns |   0.971 ns |   0.58 |    0.01 |      - |     - |     - |         - |
|                Hyperlinq |   100 |    486.22 ns |   2.084 ns |   1.847 ns |   2.92 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    342.02 ns |   0.740 ns |   0.692 ns |   2.06 |    0.01 |      - |     - |     - |         - |
