## List.ValueType.ListValueTypeSelectSum

### Source
[ListValueTypeSelectSum.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelectSum.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |    168.52 ns |   0.608 ns |   0.569 ns |       baseline |         |      - |     - |     - |         - |
|              ForeachLoop |   100 |    428.68 ns |   7.046 ns |   6.591 ns |   2.54x slower |   0.04x |      - |     - |     - |         - |
|                     Linq |   100 |  1,015.72 ns |  12.281 ns |  10.887 ns |   6.03x slower |   0.06x | 0.0458 |     - |     - |      96 B |
|               LinqFaster |   100 |    445.67 ns |   1.388 ns |   1.230 ns |   2.64x slower |   0.01x |      - |     - |     - |         - |
|             LinqFasterer |   100 |    665.62 ns |   7.733 ns |   7.233 ns |   3.95x slower |   0.04x | 3.0670 |     - |     - |   6,424 B |
|                   LinqAF |   100 |  1,116.80 ns |  22.289 ns |  21.891 ns |   6.62x slower |   0.15x |      - |     - |     - |         - |
|            LinqOptimizer |   100 | 46,352.89 ns | 635.111 ns | 563.010 ns | 274.99x slower |   3.34x | 9.4604 |     - |     - |  19,860 B |
|                  Streams |   100 |    730.89 ns |  10.318 ns |   9.147 ns |   4.34x slower |   0.06x | 0.1717 |     - |     - |     360 B |
|               StructLinq |   100 |    238.84 ns |   2.030 ns |   1.899 ns |   1.42x slower |   0.01x | 0.0191 |     - |     - |      40 B |
| StructLinq_ValueDelegate |   100 |     97.35 ns |   0.329 ns |   0.257 ns |   1.73x faster |   0.01x |      - |     - |     - |         - |
|                Hyperlinq |   100 |    511.48 ns |   3.391 ns |   3.006 ns |   3.03x slower |   0.02x |      - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    347.81 ns |   1.368 ns |   1.213 ns |   2.06x slower |   0.01x |      - |     - |     - |         - |
