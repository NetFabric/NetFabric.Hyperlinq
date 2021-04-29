## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |      Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|------------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    275.8 ns |   5.56 ns |   9.14 ns |    279.1 ns |   1.00 |    0.00 |  0.3095 |     - |     - |     648 B |
|              ForeachLoop |   100 |    277.4 ns |   2.13 ns |   1.89 ns |    277.5 ns |   1.03 |    0.05 |  0.3095 |     - |     - |     648 B |
|                     Linq |   100 |    518.0 ns |   2.36 ns |   2.20 ns |    518.0 ns |   1.92 |    0.08 |  0.3824 |     - |     - |     800 B |
|               LinqFaster |   100 |    529.6 ns |   4.16 ns |   3.89 ns |    528.1 ns |   1.96 |    0.08 |  0.4396 |     - |     - |     920 B |
|                   LinqAF |   100 |  1,079.5 ns |  20.47 ns |  21.02 ns |  1,070.3 ns |   3.99 |    0.21 |  0.3090 |     - |     - |     648 B |
|            LinqOptimizer |   100 | 51,033.0 ns | 293.47 ns | 229.12 ns | 51,110.1 ns | 191.21 |    8.48 | 15.2588 |     - |     - |  31,924 B |
|                  Streams |   100 |  1,361.7 ns |  27.15 ns |  52.31 ns |  1,335.9 ns |   4.99 |    0.34 |  0.5684 |     - |     - |   1,192 B |
|               StructLinq |   100 |    561.0 ns |   2.16 ns |   2.02 ns |    561.2 ns |   2.08 |    0.09 |  0.1755 |     - |     - |     368 B |
| StructLinq_ValueDelegate |   100 |    378.4 ns |   2.25 ns |   1.99 ns |    378.1 ns |   1.41 |    0.06 |  0.1297 |     - |     - |     272 B |
|                Hyperlinq |   100 |    577.3 ns |   3.31 ns |   2.94 ns |    577.5 ns |   2.15 |    0.08 |  0.1297 |     - |     - |     272 B |
|  Hyperlinq_ValueDelegate |   100 |    356.5 ns |   5.20 ns |   4.87 ns |    355.7 ns |   1.32 |    0.06 |  0.1297 |     - |     - |     272 B |
