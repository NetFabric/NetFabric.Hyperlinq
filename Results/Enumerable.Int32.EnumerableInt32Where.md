## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|                     Linq |   100 |    684.3 ns |   4.30 ns |   3.59 ns |      baseline |         |  0.0458 |     - |     - |      96 B |
|                   LinqAF |   100 |    606.1 ns |   7.51 ns |   6.27 ns |  1.13x faster |   0.01x |  0.0191 |     - |     - |      40 B |
|            LinqOptimizer |   100 | 44,830.0 ns | 378.80 ns | 543.26 ns | 65.36x slower |   0.90x | 13.9160 |     - |     - |  29,235 B |
|                  Streams |   100 |  1,620.1 ns |  32.24 ns |  38.38 ns |  2.34x slower |   0.05x |  0.2823 |     - |     - |     592 B |
|               StructLinq |   100 |    467.0 ns |   6.47 ns |   6.05 ns |  1.46x faster |   0.02x |  0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |    379.8 ns |   3.48 ns |   3.25 ns |  1.80x faster |   0.02x |  0.0191 |     - |     - |      40 B |
|                Hyperlinq |   100 |    511.7 ns |   2.28 ns |   1.90 ns |  1.34x faster |   0.01x |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_ValueDelegate |   100 |    441.9 ns |   5.68 ns |   5.32 ns |  1.55x faster |   0.02x |  0.0191 |     - |     - |      40 B |
