## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

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
|                   Method | Count |        Mean |       Error |      StdDev |      Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|------------:|------------:|------------:|-------:|--------:|--------:|------:|------:|----------:|
|              ForeachLoop |   100 |    335.2 ns |     1.51 ns |     1.34 ns |    335.1 ns |   1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                     Linq |   100 |    631.6 ns |     3.02 ns |     2.68 ns |    631.6 ns |   1.88 |    0.01 |  0.0458 |     - |     - |      96 B |
|                   LinqAF |   100 |    571.8 ns |     2.15 ns |     1.79 ns |    571.7 ns |   1.71 |    0.01 |  0.0191 |     - |     - |      40 B |
|            LinqOptimizer |   100 | 38,195.4 ns | 1,081.15 ns | 3,187.81 ns | 36,298.2 ns | 121.71 |    9.23 | 13.5498 |     - |     - |  28,431 B |
|                  Streams |   100 |  1,622.6 ns |     9.95 ns |     8.82 ns |  1,622.4 ns |   4.84 |    0.04 |  0.2823 |     - |     - |     592 B |
|               StructLinq |   100 |    404.1 ns |     1.07 ns |     0.89 ns |    404.2 ns |   1.20 |    0.00 |  0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |    319.3 ns |     0.99 ns |     0.93 ns |    319.4 ns |   0.95 |    0.00 |  0.0191 |     - |     - |      40 B |
|                Hyperlinq |   100 |    364.4 ns |     1.92 ns |     1.50 ns |    364.3 ns |   1.09 |    0.01 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_ValueDelegate |   100 |    371.1 ns |     4.17 ns |     3.69 ns |    371.8 ns |   1.11 |    0.01 |  0.0191 |     - |     - |      40 B |
