## List.Int32.ListInt32Sum

### Source
[ListInt32Sum.cs](../LinqBenchmarks/List/Int32/ListInt32Sum.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |       Median |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|-------------:|-------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |     84.37 ns |   0.347 ns |   0.308 ns |     84.40 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 |    138.15 ns |   0.370 ns |   0.309 ns |    138.20 ns |   1.64 |    0.01 |      - |     - |     - |         - |
|                     Linq |   100 |    619.19 ns |   3.712 ns |   3.291 ns |    618.95 ns |   7.34 |    0.04 | 0.0191 |     - |     - |      40 B |
|               LinqFaster |   100 |     78.27 ns |   1.572 ns |   3.484 ns |     76.47 ns |   0.99 |    0.03 |      - |     - |     - |         - |
|                   LinqAF |   100 |    431.49 ns |   1.658 ns |   1.551 ns |    431.67 ns |   5.11 |    0.03 |      - |     - |     - |         - |
|            LinqOptimizer |   100 | 25,608.31 ns | 222.695 ns | 208.309 ns | 25,588.65 ns | 303.28 |    2.94 | 8.1177 |     - |     - |  17,017 B |
|                  Streams |   100 |    262.47 ns |   2.988 ns |   2.795 ns |    262.04 ns |   3.11 |    0.03 | 0.0992 |     - |     - |     208 B |
|               StructLinq |   100 |     85.15 ns |   1.258 ns |   1.051 ns |     85.59 ns |   1.01 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |     60.98 ns |   0.487 ns |   0.432 ns |     60.92 ns |   0.72 |    0.01 |      - |     - |     - |         - |
|                Hyperlinq |   100 |     21.22 ns |   0.493 ns |   0.838 ns |     20.69 ns |   0.26 |    0.01 |      - |     - |     - |         - |
