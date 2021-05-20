## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |      Median |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|------------:|---------------:|--------:|--------:|------:|------:|----------:|
|              ForeachLoop |   100 |    319.4 ns |   2.07 ns |   1.83 ns |    318.9 ns |       baseline |         |  0.0191 |     - |     - |      40 B |
|                     Linq |   100 |    916.2 ns |  10.31 ns |   9.14 ns |    916.6 ns |   2.87x slower |   0.04x |  0.0763 |     - |     - |     160 B |
|                   LinqAF |   100 |    759.8 ns |   3.81 ns |   3.19 ns |    759.8 ns |   2.38x slower |   0.02x |  0.0191 |     - |     - |      40 B |
|            LinqOptimizer |   100 | 50,593.4 ns | 496.93 ns | 464.83 ns | 50,712.9 ns | 158.54x slower |   1.74x | 14.8926 |     - |     - |  31,276 B |
|                  Streams |   100 |  1,903.6 ns |  33.73 ns |  58.18 ns |  1,873.0 ns |   6.01x slower |   0.22x |  0.3548 |     - |     - |     744 B |
|               StructLinq |   100 |    590.6 ns |   3.80 ns |   3.17 ns |    590.9 ns |   1.85x slower |   0.01x |  0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate |   100 |    374.8 ns |   3.63 ns |   3.39 ns |    374.6 ns |   1.17x slower |   0.01x |  0.0191 |     - |     - |      40 B |
|                Hyperlinq |   100 |    651.3 ns |   5.04 ns |   4.46 ns |    650.7 ns |   2.04x slower |   0.02x |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_ValueDelegate |   100 |    448.1 ns |   5.72 ns |   5.07 ns |    445.8 ns |   1.40x slower |   0.01x |  0.0191 |     - |     - |      40 B |
