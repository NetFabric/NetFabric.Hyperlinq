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
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |    170.11 ns |   0.349 ns |   0.326 ns |       baseline |         |      - |         - |
|              ForeachLoop |   100 |    398.69 ns |   1.121 ns |   1.048 ns |   2.34x slower |   0.01x |      - |         - |
|                     Linq |   100 |    726.55 ns |   2.408 ns |   2.011 ns |   4.27x slower |   0.02x | 0.0458 |      96 B |
|               LinqFaster |   100 |    390.29 ns |   0.721 ns |   0.639 ns |   2.29x slower |   0.01x |      - |         - |
|             LinqFasterer |   100 |    692.30 ns |   3.511 ns |   3.112 ns |   4.07x slower |   0.02x | 3.0670 |   6,424 B |
|                   LinqAF |   100 |    961.24 ns |   2.468 ns |   2.309 ns |   5.65x slower |   0.01x |      - |         - |
|            LinqOptimizer |   100 | 37,765.24 ns | 328.564 ns | 307.339 ns | 222.01x slower |   1.78x | 9.4604 |  19,829 B |
|                  Streams |   100 |    861.24 ns |   2.594 ns |   2.299 ns |   5.06x slower |   0.02x | 0.1717 |     360 B |
|               StructLinq |   100 |    221.86 ns |   0.587 ns |   0.549 ns |   1.30x slower |   0.00x | 0.0191 |      40 B |
| StructLinq_ValueDelegate |   100 |     95.34 ns |   0.190 ns |   0.178 ns |   1.78x faster |   0.00x |      - |         - |
|                Hyperlinq |   100 |    627.55 ns |   0.403 ns |   0.314 ns |   3.69x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |   100 |    312.18 ns |   0.540 ns |   0.505 ns |   1.84x slower |   0.00x |      - |         - |
