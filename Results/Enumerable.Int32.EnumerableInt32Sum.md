## Enumerable.Int32.EnumerableInt32Sum

### Source
[EnumerableInt32Sum.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Sum.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|--------------:|--------:|-------:|------:|------:|----------:|
|              ForeachLoop |   100 |    347.7 ns |   4.08 ns |   3.81 ns |      baseline |         | 0.0191 |     - |     - |      40 B |
|                     Linq |   100 |    215.1 ns |   4.34 ns |   4.26 ns |  1.61x faster |   0.04x | 0.0191 |     - |     - |      40 B |
|                   LinqAF |   100 |    288.8 ns |   2.29 ns |   2.15 ns |  1.20x faster |   0.02x | 0.0191 |     - |     - |      40 B |
|            LinqOptimizer |   100 | 27,602.4 ns | 389.00 ns | 303.71 ns | 79.53x slower |   1.32x | 8.2397 |     - |     - |  17,274 B |
|                  Streams |   100 |    558.4 ns |   5.61 ns |   4.69 ns |  1.61x slower |   0.02x | 0.1183 |     - |     - |     248 B |
|               StructLinq |   100 |    280.8 ns |   2.66 ns |   2.22 ns |  1.24x faster |   0.02x | 0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |    291.8 ns |   1.45 ns |   1.21 ns |  1.19x faster |   0.01x | 0.0191 |     - |     - |      40 B |
|                Hyperlinq |   100 |    331.4 ns |   2.41 ns |   2.14 ns |  1.05x faster |   0.01x | 0.0191 |     - |     - |      40 B |
