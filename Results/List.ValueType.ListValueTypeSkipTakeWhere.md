## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

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
|                   Method | Skip | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop | 1000 |   100 |    593.7 ns |   3.13 ns |   2.77 ns |       baseline |         |       - |     - |     - |         - |
|                     Linq | 1000 |   100 |  1,552.6 ns |  21.99 ns |  20.57 ns |   2.62x slower |   0.04x |  0.1526 |     - |     - |     320 B |
|               LinqFaster | 1000 |   100 |  3,451.7 ns |  49.99 ns |  44.31 ns |   5.81x slower |   0.09x | 10.0250 |     - |     - |  21,000 B |
|             LinqFasterer | 1000 |   100 |  8,248.6 ns | 103.69 ns |  91.92 ns |  13.89x slower |   0.16x | 37.0331 |     - |     - |  80,168 B |
|                   LinqAF | 1000 |   100 | 11,623.5 ns | 138.91 ns | 123.14 ns |  19.58x slower |   0.23x |       - |     - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 87,767.2 ns | 624.65 ns | 553.73 ns | 147.85x slower |   1.10x | 73.9746 |     - |     - | 159,000 B |
|                 SpanLinq | 1000 |   100 |    796.2 ns |   6.23 ns |   5.52 ns |   1.34x slower |   0.01x |       - |     - |     - |         - |
|                  Streams | 1000 |   100 | 10,747.0 ns | 149.97 ns | 125.23 ns |  18.11x slower |   0.23x |  0.5493 |     - |     - |   1,176 B |
|               StructLinq | 1000 |   100 |    732.4 ns |  14.59 ns |  13.65 ns |   1.24x slower |   0.02x |  0.0572 |     - |     - |     120 B |
| StructLinq_ValueDelegate | 1000 |   100 |    623.0 ns |   3.10 ns |   2.75 ns |   1.05x slower |   0.01x |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |  1,123.9 ns |   7.56 ns |   7.08 ns |   1.89x slower |   0.02x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    848.8 ns |   9.90 ns |   8.78 ns |   1.43x slower |   0.02x |       - |     - |     - |         - |
