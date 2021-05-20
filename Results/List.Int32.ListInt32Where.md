## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |         P95 |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|------------:|---------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    133.9 ns |   2.22 ns |   1.97 ns |    137.1 ns |       baseline |         |       - |     - |     - |         - |
|              ForeachLoop |   100 |    173.7 ns |   3.00 ns |   6.66 ns |    193.7 ns |   1.30x slower |   0.05x |       - |     - |     - |         - |
|                     Linq |   100 |    555.3 ns |   2.76 ns |   2.16 ns |    558.2 ns |   4.15x slower |   0.07x |  0.0343 |     - |     - |      72 B |
|               LinqFaster |   100 |    407.7 ns |   2.16 ns |   1.91 ns |    410.2 ns |   3.05x slower |   0.04x |  0.3095 |     - |     - |     648 B |
|             LinqFasterer |   100 |    473.1 ns |   3.70 ns |   3.28 ns |    478.5 ns |   3.54x slower |   0.07x |  0.3328 |     - |     - |     696 B |
|                   LinqAF |   100 |    829.8 ns |   6.17 ns |   5.77 ns |    839.2 ns |   6.20x slower |   0.11x |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 42,361.2 ns | 428.81 ns | 380.13 ns | 42,879.2 ns | 316.54x slower |   5.46x | 13.7329 |     - |     - |  28,794 B |
|                 SpanLinq |   100 |    287.7 ns |   4.02 ns |   3.76 ns |    294.1 ns |   2.15x slower |   0.03x |       - |     - |     - |         - |
|                  Streams |   100 |  1,340.2 ns |   4.47 ns |   3.49 ns |  1,344.5 ns |  10.03x slower |   0.16x |  0.2899 |     - |     - |     608 B |
|               StructLinq |   100 |    373.8 ns |   4.06 ns |   3.79 ns |    379.6 ns |   2.80x slower |   0.06x |  0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |    182.2 ns |   1.43 ns |   1.27 ns |    184.6 ns |   1.36x slower |   0.02x |       - |     - |     - |         - |
|                Hyperlinq |   100 |    285.9 ns |   5.70 ns |   6.57 ns |    297.3 ns |   2.14x slower |   0.06x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    219.9 ns |   0.99 ns |   0.93 ns |    221.4 ns |   1.64x slower |   0.02x |       - |     - |     - |         - |
