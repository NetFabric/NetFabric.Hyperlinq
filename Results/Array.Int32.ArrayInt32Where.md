## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|                   Method | Count |         Mean |        Error |       StdDev |       Median |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-------------:|-------------:|-------------:|---------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |     69.04 ns |     0.387 ns |     0.323 ns |     68.95 ns |       baseline |         |       - |     - |     - |         - |
|              ForeachLoop |   100 |     69.37 ns |     0.582 ns |     0.516 ns |     69.45 ns |   1.00x slower |   0.01x |       - |     - |     - |         - |
|                     Linq |   100 |    445.58 ns |     4.272 ns |     3.787 ns |    446.01 ns |   6.46x slower |   0.07x |  0.0229 |     - |     - |      48 B |
|               LinqFaster |   100 |    324.09 ns |     6.544 ns |    17.008 ns |    314.31 ns |   5.01x slower |   0.09x |  0.3171 |     - |     - |     664 B |
|             LinqFasterer |   100 |    543.79 ns |     5.688 ns |     5.320 ns |    545.02 ns |   7.88x slower |   0.08x |  0.2136 |     - |     - |     448 B |
|                   LinqAF |   100 |    328.01 ns |     2.226 ns |     1.858 ns |    327.81 ns |   4.75x slower |   0.03x |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 41,178.20 ns | 1,284.098 ns | 3,786.193 ns | 38,960.55 ns | 575.08x slower |  30.32x | 13.3057 |     - |     - |  27,846 B |
|                 SpanLinq |   100 |    281.82 ns |     4.160 ns |     3.891 ns |    281.54 ns |   4.08x slower |   0.07x |       - |     - |     - |         - |
|                  Streams |   100 |  1,325.70 ns |     4.896 ns |     4.340 ns |  1,325.95 ns |  19.20x slower |   0.13x |  0.2785 |     - |     - |     584 B |
|               StructLinq |   100 |    310.60 ns |     6.232 ns |     6.121 ns |    309.85 ns |   4.50x slower |   0.10x |  0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |    173.68 ns |     1.185 ns |     1.109 ns |    173.56 ns |   2.52x slower |   0.02x |       - |     - |     - |         - |
|                Hyperlinq |   100 |    361.54 ns |     2.772 ns |     2.593 ns |    361.35 ns |   5.24x slower |   0.05x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    223.31 ns |     0.780 ns |     0.730 ns |    223.26 ns |   3.24x slower |   0.02x |       - |     - |     - |         - |
