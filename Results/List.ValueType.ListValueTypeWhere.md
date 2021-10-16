## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|--------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |    551.1 ns |   0.96 ns |   0.85 ns |      baseline |         |       - |         - |
|              ForeachLoop |   100 |    781.4 ns |   1.44 ns |   1.34 ns |  1.42x slower |   0.00x |       - |         - |
|                     Linq |   100 |  1,175.8 ns |   6.16 ns |   5.76 ns |  2.13x slower |   0.01x |  0.0877 |     184 B |
|               LinqFaster |   100 |  1,761.6 ns |  11.84 ns |  10.49 ns |  3.20x slower |   0.02x |  3.8605 |   8,088 B |
|             LinqFasterer |   100 |  1,759.8 ns |  33.31 ns |  31.16 ns |  3.20x slower |   0.06x |  4.7379 |   9,936 B |
|                   LinqAF |   100 |  1,396.2 ns |   6.16 ns |   5.76 ns |  2.53x slower |   0.01x |       - |         - |
|            LinqOptimizer |   100 | 53,804.4 ns | 373.98 ns | 312.29 ns | 97.63x slower |   0.62x | 73.1812 | 154,832 B |
|                 SpanLinq |   100 |    787.2 ns |   1.29 ns |   1.20 ns |  1.43x slower |   0.00x |       - |         - |
|                  Streams |   100 |  2,072.9 ns |   2.80 ns |   2.19 ns |  3.76x slower |   0.01x |  0.4044 |     848 B |
|               StructLinq |   100 |    653.1 ns |   1.32 ns |   1.24 ns |  1.19x slower |   0.00x |  0.0191 |      40 B |
| StructLinq_ValueDelegate |   100 |    592.6 ns |   1.01 ns |   0.90 ns |  1.08x slower |   0.00x |       - |         - |
|                Hyperlinq |   100 |  1,106.3 ns |   9.14 ns |   8.55 ns |  2.01x slower |   0.02x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    885.9 ns |   1.48 ns |   1.38 ns |  1.61x slower |   0.00x |       - |         - |
