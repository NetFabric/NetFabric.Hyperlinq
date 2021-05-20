## ImmutableArray.Int32.ImmutableArrayInt32Select

### Source
[ImmutableArrayInt32Select.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Select.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |     61.43 ns |   0.366 ns |   0.324 ns |       baseline |         |       - |     - |     - |         - |
|              ForeachLoop |   100 |     61.48 ns |   0.527 ns |   0.493 ns |   1.00x slower |   0.01x |       - |     - |     - |         - |
|                     Linq |   100 |    507.24 ns |   7.142 ns |   5.964 ns |   8.25x slower |   0.11x |  0.0229 |     - |     - |      48 B |
|             LinqFasterer |   100 |    428.43 ns |   3.151 ns |   2.793 ns |   6.98x slower |   0.06x |  0.4320 |     - |     - |     904 B |
|            LinqOptimizer |   100 | 40,466.76 ns | 453.208 ns | 378.450 ns | 658.56x slower |   6.68x | 13.6108 |     - |     - |  28,584 B |
|                  Streams |   100 |  1,784.36 ns |  31.967 ns |  29.902 ns |  29.06x slower |   0.57x |  0.2899 |     - |     - |     608 B |
|               StructLinq |   100 |    218.36 ns |   1.813 ns |   1.607 ns |   3.55x slower |   0.04x |  0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |    184.49 ns |   0.784 ns |   0.733 ns |   3.00x slower |   0.02x |       - |     - |     - |         - |
|                Hyperlinq |   100 |    222.11 ns |   2.106 ns |   1.867 ns |   3.62x slower |   0.04x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    206.28 ns |   0.658 ns |   0.584 ns |   3.36x slower |   0.02x |       - |     - |     - |         - |
