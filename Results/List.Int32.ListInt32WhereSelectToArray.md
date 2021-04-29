## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|                  ForLoop |   100 |    282.0 ns |   1.68 ns |   1.49 ns |   1.00 |    0.00 |  0.4244 |     - |     - |     888 B |
|              ForeachLoop |   100 |    266.2 ns |   1.67 ns |   1.57 ns |   0.94 |    0.01 |  0.4244 |     - |     - |     888 B |
|                     Linq |   100 |    556.9 ns |   6.01 ns |   5.33 ns |   1.97 |    0.02 |  0.4015 |     - |     - |     840 B |
|               LinqFaster |   100 |    465.6 ns |   3.59 ns |   2.99 ns |   1.65 |    0.01 |  0.4244 |     - |     - |     888 B |
|             LinqFasterer |   100 |    438.8 ns |   4.38 ns |   4.10 ns |   1.56 |    0.01 |  0.4320 |     - |     - |     904 B |
|                   LinqAF |   100 |  1,083.3 ns |  13.65 ns |  11.40 ns |   3.84 |    0.05 |  0.4082 |     - |     - |     856 B |
|            LinqOptimizer |   100 | 50,751.0 ns | 265.19 ns | 248.06 ns | 180.01 |    1.46 | 15.0757 |     - |     - |  31,651 B |
|                  Streams |   100 |  1,053.9 ns |   8.48 ns |   7.93 ns |   3.74 |    0.03 |  0.6695 |     - |     - |   1,400 B |
|               StructLinq |   100 |    595.6 ns |   4.69 ns |   4.39 ns |   2.11 |    0.02 |  0.1602 |     - |     - |     336 B |
| StructLinq_ValueDelegate |   100 |    345.6 ns |   1.59 ns |   1.41 ns |   1.23 |    0.01 |  0.1144 |     - |     - |     240 B |
|                Hyperlinq |   100 |    616.8 ns |   5.25 ns |   4.66 ns |   2.19 |    0.01 |  0.1144 |     - |     - |     240 B |
|  Hyperlinq_ValueDelegate |   100 |    332.9 ns |   1.69 ns |   1.58 ns |   1.18 |    0.01 |  0.1144 |     - |     - |     240 B |
