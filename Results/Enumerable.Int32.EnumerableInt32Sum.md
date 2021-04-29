## Enumerable.Int32.EnumerableInt32Sum

### Source
[EnumerableInt32Sum.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Sum.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForeachLoop |   100 |    283.8 ns |   1.01 ns |   0.94 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                     Linq |   100 |    205.4 ns |   1.11 ns |   1.04 ns |  0.72 |    0.00 | 0.0191 |     - |     - |      40 B |
|                   LinqAF |   100 |    282.0 ns |   1.11 ns |   1.04 ns |  0.99 |    0.01 | 0.0191 |     - |     - |      40 B |
|            LinqOptimizer |   100 | 25,316.7 ns | 205.21 ns | 191.95 ns | 89.20 |    0.73 | 8.1787 |     - |     - |  17,273 B |
|                  Streams |   100 |    521.2 ns |   1.69 ns |   1.42 ns |  1.84 |    0.01 | 0.1183 |     - |     - |     248 B |
|               StructLinq |   100 |    326.2 ns |   2.95 ns |   2.76 ns |  1.15 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |    314.5 ns |   2.15 ns |   1.80 ns |  1.11 |    0.01 | 0.0191 |     - |     - |      40 B |
|                Hyperlinq |   100 |    260.4 ns |   0.83 ns |   0.78 ns |  0.92 |    0.00 | 0.0191 |     - |     - |      40 B |
