## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

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
|                   Method | Skip | Count |        Mean |       Error |      StdDev |      Median |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |------------:|------------:|------------:|------------:|---------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop | 1000 |   100 |    122.2 ns |     1.10 ns |     0.92 ns |    122.1 ns |       baseline |         |       - |     - |     - |         - |
|                     Linq | 1000 |   100 |    673.6 ns |    13.23 ns |    12.37 ns |    674.0 ns |   5.50x slower |   0.11x |  0.0725 |     - |     - |     152 B |
|               LinqFaster | 1000 |   100 |    909.0 ns |    14.70 ns |    30.02 ns |    895.9 ns |   7.67x slower |   0.35x |  0.7458 |     - |     - |   1,560 B |
|             LinqFasterer | 1000 |   100 |    949.5 ns |    16.24 ns |    15.19 ns |    948.2 ns |   7.77x slower |   0.12x |  2.4424 |     - |     - |   5,112 B |
|                   LinqAF | 1000 |   100 |  6,775.8 ns |    29.99 ns |    25.04 ns |  6,774.8 ns |  55.46x slower |   0.49x |       - |     - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 65,072.6 ns | 1,910.15 ns | 5,632.11 ns | 61,561.8 ns | 516.98x slower |  34.02x | 15.6860 |     - |     - |  32,884 B |
|                 SpanLinq | 1000 |   100 |    295.6 ns |     4.46 ns |     3.95 ns |    294.1 ns |   2.42x slower |   0.02x |       - |     - |     - |         - |
|                  Streams | 1000 |   100 |  7,075.6 ns |    63.14 ns |    49.30 ns |  7,056.6 ns |  57.91x slower |   0.75x |  0.4425 |     - |     - |     936 B |
|               StructLinq | 1000 |   100 |    358.4 ns |     7.18 ns |     7.98 ns |    357.7 ns |   2.94x slower |   0.07x |  0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    176.3 ns |     1.97 ns |     1.84 ns |    175.7 ns |   1.44x slower |   0.02x |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |    343.5 ns |     5.49 ns |     4.59 ns |    342.2 ns |   2.81x slower |   0.05x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    238.8 ns |     1.29 ns |     1.15 ns |    239.2 ns |   1.96x slower |   0.02x |       - |     - |     - |         - |
