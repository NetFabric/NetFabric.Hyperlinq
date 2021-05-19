## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|                  ForLoop | 1000 |   100 |     63.01 ns |     0.610 ns |     0.510 ns |     62.92 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                     Linq | 1000 |   100 |    994.89 ns |    10.935 ns |     9.694 ns |    993.72 ns |  15.80 |    0.23 |  0.0725 |     - |     - |     152 B |
|               LinqFaster | 1000 |   100 |    328.75 ns |     4.483 ns |     3.974 ns |    328.47 ns |   5.22 |    0.09 |  0.6080 |     - |     - |   1,272 B |
|             LinqFasterer | 1000 |   100 |    453.96 ns |     3.032 ns |     2.688 ns |    454.42 ns |   7.20 |    0.08 |  0.4206 |     - |     - |     880 B |
|                   LinqAF | 1000 |   100 |  2,765.21 ns |    16.980 ns |    15.052 ns |  2,762.35 ns |  43.87 |    0.41 |       - |     - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 44,432.25 ns | 1,493.930 ns | 4,381.437 ns | 41,327.53 ns | 780.67 |   14.82 | 14.8926 |     - |     - |  31,181 B |
|                 SpanLinq | 1000 |   100 |    234.90 ns |     1.195 ns |     1.118 ns |    234.48 ns |   3.73 |    0.03 |       - |     - |     - |         - |
|                  Streams | 1000 |   100 |  6,738.10 ns |    82.460 ns |    73.098 ns |  6,712.27 ns | 106.80 |    1.06 |  0.4349 |     - |     - |     912 B |
|               StructLinq | 1000 |   100 |    260.47 ns |     2.106 ns |     1.970 ns |    260.16 ns |   4.14 |    0.05 |  0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    176.49 ns |     0.533 ns |     0.498 ns |    176.47 ns |   2.80 |    0.02 |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |    225.38 ns |     0.514 ns |     0.456 ns |    225.28 ns |   3.58 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    224.17 ns |     0.550 ns |     0.488 ns |    224.12 ns |   3.56 |    0.03 |       - |     - |     - |         - |
