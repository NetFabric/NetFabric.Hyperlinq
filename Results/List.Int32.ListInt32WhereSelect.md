## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1417) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.1.21458.32
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |     93.49 ns |   0.226 ns |   0.201 ns |       baseline |         |       - |         - |
|              ForeachLoop |   100 |     90.77 ns |   0.329 ns |   0.274 ns |   1.03x faster |   0.00x |       - |         - |
|                     Linq |   100 |    489.56 ns |   0.593 ns |   0.495 ns |   5.24x slower |   0.01x |  0.0725 |     152 B |
|               LinqFaster |   100 |    544.72 ns |   0.539 ns |   0.421 ns |   5.83x slower |   0.01x |  0.3090 |     648 B |
|             LinqFasterer |   100 |    537.64 ns |   3.797 ns |   3.552 ns |   5.75x slower |   0.05x |  0.4473 |     936 B |
|                   LinqAF |   100 |    442.42 ns |   1.570 ns |   1.469 ns |   4.73x slower |   0.02x |       - |         - |
|            LinqOptimizer |   100 | 50,364.38 ns | 333.013 ns | 295.208 ns | 538.73x slower |   3.13x | 14.6484 |  30,787 B |
|                 SpanLinq |   100 |    373.79 ns |   1.484 ns |   1.388 ns |   4.00x slower |   0.01x |       - |         - |
|                  Streams |   100 |  1,424.57 ns |   5.859 ns |   5.480 ns |  15.24x slower |   0.07x |  0.3624 |     760 B |
|               StructLinq |   100 |    359.28 ns |   1.004 ns |   0.784 ns |   3.84x slower |   0.01x |  0.0305 |      64 B |
| StructLinq_ValueDelegate |   100 |    199.19 ns |   0.570 ns |   0.533 ns |   2.13x slower |   0.01x |       - |         - |
|                Hyperlinq |   100 |    355.95 ns |   1.598 ns |   1.247 ns |   3.81x slower |   0.01x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    229.37 ns |   0.385 ns |   0.341 ns |   2.45x slower |   0.01x |       - |         - |
