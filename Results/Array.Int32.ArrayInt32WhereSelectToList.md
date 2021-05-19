## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |      Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|------------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    229.5 ns |   4.64 ns |  11.29 ns |    223.9 ns |   1.00 |    0.00 |  0.3097 |     - |     - |     648 B |
|              ForeachLoop |   100 |    244.0 ns |   2.26 ns |   2.12 ns |    243.2 ns |   1.02 |    0.06 |  0.3095 |     - |     - |     648 B |
|                     Linq |   100 |    451.0 ns |   3.62 ns |   3.21 ns |    450.3 ns |   1.89 |    0.11 |  0.3595 |     - |     - |     752 B |
|               LinqFaster |   100 |    361.4 ns |   3.58 ns |   3.18 ns |    360.8 ns |   1.51 |    0.08 |  0.4473 |     - |     - |     936 B |
|             LinqFasterer |   100 |    550.4 ns |   4.15 ns |   3.68 ns |    551.4 ns |   2.30 |    0.13 |  0.6113 |     - |     - |   1,280 B |
|                   LinqAF |   100 |    658.9 ns |   5.44 ns |   4.83 ns |    657.8 ns |   2.76 |    0.16 |  0.3090 |     - |     - |     648 B |
|            LinqOptimizer |   100 | 44,861.9 ns | 425.76 ns | 332.40 ns | 44,783.7 ns | 188.51 |   11.61 | 14.6484 |     - |     - |  30,760 B |
|                 SpanLinq |   100 |    540.9 ns |   6.77 ns |   6.00 ns |    538.8 ns |   2.27 |    0.14 |  0.3090 |     - |     - |     648 B |
|                  Streams |   100 |  1,313.0 ns |  26.17 ns |  40.75 ns |  1,329.5 ns |   5.55 |    0.34 |  0.5684 |     - |     - |   1,192 B |
|               StructLinq |   100 |    641.3 ns |   3.91 ns |   3.46 ns |    641.4 ns |   2.68 |    0.15 |  0.1755 |     - |     - |     368 B |
| StructLinq_ValueDelegate |   100 |    339.9 ns |   6.85 ns |  10.46 ns |    343.0 ns |   1.43 |    0.08 |  0.1297 |     - |     - |     272 B |
|                Hyperlinq |   100 |    602.3 ns |   3.93 ns |   3.28 ns |    601.4 ns |   2.53 |    0.14 |  0.1297 |     - |     - |     272 B |
|  Hyperlinq_ValueDelegate |   100 |    373.4 ns |   7.28 ns |   9.72 ns |    372.9 ns |   1.55 |    0.07 |  0.1297 |     - |     - |     272 B |
