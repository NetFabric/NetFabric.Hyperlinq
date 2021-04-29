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
|                   Method | Count |        Mean |     Error |    StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    255.2 ns |   3.85 ns |   3.60 ns |   1.00 |    0.00 |  0.3095 |     - |     - |     648 B |
|              ForeachLoop |   100 |    275.8 ns |   3.55 ns |   3.32 ns |   1.08 |    0.02 |  0.3095 |     - |     - |     648 B |
|                     Linq |   100 |    530.7 ns |   3.26 ns |   2.89 ns |   2.08 |    0.03 |  0.3824 |     - |     - |     800 B |
|               LinqFaster |   100 |    473.7 ns |   2.80 ns |   2.34 ns |   1.85 |    0.03 |  0.4396 |     - |     - |     920 B |
|             LinqFasterer |   100 |    509.1 ns |   3.01 ns |   2.66 ns |   1.99 |    0.03 |  0.5617 |     - |     - |   1,176 B |
|                   LinqAF |   100 |  1,037.4 ns |  11.03 ns |  10.32 ns |   4.07 |    0.07 |  0.3090 |     - |     - |     648 B |
|            LinqOptimizer |   100 | 50,169.4 ns | 147.24 ns | 137.73 ns | 196.62 |    3.04 | 15.2588 |     - |     - |  31,924 B |
|                  Streams |   100 |  1,336.9 ns |   8.14 ns |   7.22 ns |   5.24 |    0.07 |  0.5684 |     - |     - |   1,192 B |
|               StructLinq |   100 |    563.7 ns |   3.97 ns |   3.31 ns |   2.21 |    0.03 |  0.1755 |     - |     - |     368 B |
| StructLinq_ValueDelegate |   100 |    356.9 ns |   2.60 ns |   2.43 ns |   1.40 |    0.02 |  0.1297 |     - |     - |     272 B |
|                Hyperlinq |   100 |    618.9 ns |   5.66 ns |   4.73 ns |   2.42 |    0.04 |  0.1297 |     - |     - |     272 B |
|  Hyperlinq_ValueDelegate |   100 |    345.2 ns |   1.96 ns |   1.84 ns |   1.35 |    0.02 |  0.1297 |     - |     - |     272 B |
