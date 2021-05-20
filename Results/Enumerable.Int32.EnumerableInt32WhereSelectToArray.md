## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|--------------:|--------:|--------:|------:|------:|----------:|
|              ForeachLoop |   100 |    587.3 ns |   7.10 ns |  11.27 ns |      baseline |         |  0.7877 |     - |     - |   1,648 B |
|                     Linq |   100 |  1,000.7 ns |  10.59 ns |   9.91 ns |  1.70x slower |   0.04x |  0.6266 |     - |     - |   1,312 B |
|                   LinqAF |   100 |  1,101.0 ns |  16.44 ns |  15.38 ns |  1.87x slower |   0.05x |  0.7725 |     - |     - |   1,616 B |
|            LinqOptimizer |   100 | 53,754.9 ns | 832.97 ns | 779.16 ns | 91.51x slower |   2.12x | 15.3809 |     - |     - |  32,189 B |
|                  Streams |   100 |  1,751.0 ns |  23.67 ns |  22.14 ns |  2.98x slower |   0.05x |  1.0319 |     - |     - |   2,160 B |
|               StructLinq |   100 |  1,009.1 ns |   8.80 ns |   7.80 ns |  1.72x slower |   0.04x |  0.2632 |     - |     - |     552 B |
| StructLinq_ValueDelegate |   100 |    662.7 ns |   5.44 ns |   4.25 ns |  1.13x slower |   0.03x |  0.2213 |     - |     - |     464 B |
|                Hyperlinq |   100 |  1,019.6 ns |   9.61 ns |   8.51 ns |  1.73x slower |   0.04x |  0.2213 |     - |     - |     464 B |
|  Hyperlinq_ValueDelegate |   100 |    750.3 ns |  15.06 ns |  19.58 ns |  1.27x slower |   0.05x |  0.2213 |     - |     - |     464 B |
