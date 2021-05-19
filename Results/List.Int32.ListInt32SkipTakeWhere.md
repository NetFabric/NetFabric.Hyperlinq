## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

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
|                   Method | Skip | Count |        Mean |       Error |      StdDev |      Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |------------:|------------:|------------:|------------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop | 1000 |   100 |    116.3 ns |     0.73 ns |     0.68 ns |    116.0 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                     Linq | 1000 |   100 |    627.2 ns |     4.78 ns |     4.24 ns |    626.3 ns |   5.40 |    0.05 |  0.0725 |     - |     - |     152 B |
|               LinqFaster | 1000 |   100 |    879.8 ns |    17.58 ns |    42.13 ns |    853.4 ns |   7.89 |    0.29 |  0.7458 |     - |     - |   1,560 B |
|             LinqFasterer | 1000 |   100 |    852.1 ns |     7.21 ns |     6.39 ns |    852.5 ns |   7.33 |    0.06 |  2.4424 |     - |     - |   5,112 B |
|                   LinqAF | 1000 |   100 |  6,499.3 ns |    46.35 ns |    43.36 ns |  6,486.4 ns |  55.89 |    0.59 |       - |     - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 62,343.3 ns | 1,778.95 ns | 5,132.68 ns | 58,689.4 ns | 586.19 |   17.54 | 15.6860 |     - |     - |  32,884 B |
|                  Streams | 1000 |   100 |  7,338.0 ns |    29.68 ns |    23.17 ns |  7,340.5 ns |  63.10 |    0.39 |  0.4425 |     - |     - |     936 B |
|               StructLinq | 1000 |   100 |    320.2 ns |     1.86 ns |     1.65 ns |    319.9 ns |   2.76 |    0.02 |  0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    164.9 ns |     1.32 ns |     2.89 ns |    163.8 ns |   1.44 |    0.04 |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |    289.8 ns |     2.20 ns |     1.84 ns |    289.9 ns |   2.49 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    234.3 ns |     0.47 ns |     0.41 ns |    234.4 ns |   2.02 |    0.01 |       - |     - |     - |         - |
