## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|------------:|------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    606.6 ns |   2.94 ns |   2.61 ns |    605.7 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop |   100 |    798.2 ns |   5.12 ns |   4.79 ns |    798.1 ns |  1.32 |    0.01 |       - |     - |     - |         - |
|                     Linq |   100 |  1,354.8 ns |   5.52 ns |   4.89 ns |  1,354.1 ns |  2.23 |    0.01 |  0.0877 |     - |     - |     184 B |
|               LinqFaster |   100 |  1,698.3 ns |  33.94 ns |  95.72 ns |  1,642.4 ns |  2.99 |    0.11 |  3.8605 |     - |     - |   8,088 B |
|             LinqFasterer |   100 |  1,791.8 ns |  26.78 ns |  25.05 ns |  1,789.6 ns |  2.95 |    0.05 |  4.7379 |     - |     - |   9,936 B |
|                   LinqAF |   100 |  1,989.6 ns |  38.55 ns |  42.85 ns |  1,984.8 ns |  3.28 |    0.09 |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 49,301.7 ns | 725.09 ns | 942.82 ns | 49,079.0 ns | 81.57 |    1.99 | 72.9980 |     - |     - | 154,976 B |
|                  Streams |   100 |  2,133.5 ns |  16.01 ns |  14.19 ns |  2,134.3 ns |  3.52 |    0.03 |  0.4044 |     - |     - |     848 B |
|               StructLinq |   100 |    682.8 ns |   6.88 ns |   6.10 ns |    684.7 ns |  1.13 |    0.01 |  0.0191 |     - |     - |      40 B |
| StructLinq_ValueDelegate |   100 |    616.3 ns |   6.03 ns |   5.35 ns |    614.9 ns |  1.02 |    0.01 |       - |     - |     - |         - |
|                Hyperlinq |   100 |  1,087.0 ns |   3.09 ns |   2.74 ns |  1,086.4 ns |  1.79 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    815.1 ns |   1.48 ns |   1.31 ns |    815.4 ns |  1.34 |    0.01 |       - |     - |     - |         - |
