## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    129.8 ns |   1.02 ns |   0.95 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop |   100 |    167.6 ns |   1.04 ns |   0.92 ns |   1.29 |    0.01 |       - |     - |     - |         - |
|                     Linq |   100 |    602.5 ns |   3.92 ns |   3.48 ns |   4.64 |    0.05 |  0.0343 |     - |     - |      72 B |
|               LinqFaster |   100 |    433.9 ns |   3.29 ns |   3.08 ns |   3.34 |    0.04 |  0.3095 |     - |     - |     648 B |
|             LinqFasterer |   100 |    468.2 ns |   2.54 ns |   2.25 ns |   3.61 |    0.04 |  0.3328 |     - |     - |     696 B |
|                   LinqAF |   100 |    800.0 ns |   2.92 ns |   2.59 ns |   6.16 |    0.05 |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 42,471.2 ns | 442.91 ns | 369.85 ns | 326.85 |    3.38 | 13.7329 |     - |     - |  28,794 B |
|                  Streams |   100 |  1,396.2 ns |   6.28 ns |   5.88 ns |  10.76 |    0.10 |  0.2899 |     - |     - |     608 B |
|               StructLinq |   100 |    219.3 ns |   1.83 ns |   1.71 ns |   1.69 |    0.02 |  0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |    177.5 ns |   0.58 ns |   0.51 ns |   1.37 |    0.01 |       - |     - |     - |         - |
|                Hyperlinq |   100 |    281.5 ns |   2.64 ns |   2.47 ns |   2.17 |    0.02 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    215.0 ns |   0.80 ns |   0.75 ns |   1.66 |    0.01 |       - |     - |     - |         - |
