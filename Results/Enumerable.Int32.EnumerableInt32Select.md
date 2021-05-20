## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|------:|------:|----------:|
|              ForeachLoop |   100 |    349.6 ns |   5.53 ns |   4.90 ns |       baseline |         |  0.0191 |     - |     - |      40 B |
|                     Linq |   100 |    678.8 ns |  11.83 ns |  10.49 ns |   1.94x slower |   0.05x |  0.0458 |     - |     - |      96 B |
|                   LinqAF |   100 |    617.3 ns |   5.77 ns |   5.39 ns |   1.77x slower |   0.02x |  0.0191 |     - |     - |      40 B |
|            LinqOptimizer |   100 | 39,783.2 ns | 685.30 ns | 607.50 ns | 113.81x slower |   2.77x | 13.5498 |     - |     - |  28,432 B |
|                  Streams |   100 |  1,731.0 ns |  13.19 ns |  11.69 ns |   4.95x slower |   0.08x |  0.2823 |     - |     - |     592 B |
|               StructLinq |   100 |    410.7 ns |   3.14 ns |   2.78 ns |   1.17x slower |   0.02x |  0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |    279.3 ns |   4.49 ns |   3.98 ns |   1.25x faster |   0.02x |  0.0191 |     - |     - |      40 B |
|                Hyperlinq |   100 |    384.5 ns |   7.18 ns |   6.72 ns |   1.10x slower |   0.03x |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_ValueDelegate |   100 |    379.6 ns |   2.89 ns |   2.56 ns |   1.09x slower |   0.02x |  0.0191 |     - |     - |      40 B |
