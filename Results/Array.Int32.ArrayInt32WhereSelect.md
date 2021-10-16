## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
|                   Method | Count |         Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |-------------:|----------:|----------:|---------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |     72.36 ns |  0.073 ns |  0.061 ns |       baseline |         |       - |         - |
|              ForeachLoop |   100 |     72.38 ns |  0.103 ns |  0.086 ns |   1.00x slower |   0.00x |       - |         - |
|                     Linq |   100 |    440.79 ns |  0.347 ns |  0.308 ns |   6.09x slower |   0.01x |  0.0496 |     104 B |
|               LinqFaster |   100 |    466.71 ns |  0.732 ns |  0.649 ns |   6.45x slower |   0.01x |  0.3171 |     664 B |
|             LinqFasterer |   100 |    706.10 ns |  1.411 ns |  1.320 ns |   9.76x slower |   0.02x |  0.4129 |     864 B |
|                   LinqAF |   100 |    352.12 ns |  2.650 ns |  2.349 ns |   4.87x slower |   0.03x |       - |         - |
|            LinqOptimizer |   100 | 46,428.21 ns | 93.921 ns | 83.258 ns | 641.57x slower |   1.08x | 14.2212 |  29,775 B |
|                 SpanLinq |   100 |    363.39 ns |  0.348 ns |  0.291 ns |   5.02x slower |   0.01x |       - |         - |
|                  Streams |   100 |  1,564.50 ns |  3.618 ns |  3.384 ns |  21.62x slower |   0.05x |  0.3510 |     736 B |
|               StructLinq |   100 |    352.81 ns |  0.467 ns |  0.390 ns |   4.88x slower |   0.01x |  0.0305 |      64 B |
| StructLinq_ValueDelegate |   100 |    198.20 ns |  0.215 ns |  0.201 ns |   2.74x slower |   0.00x |       - |         - |
|                Hyperlinq |   100 |    359.00 ns |  0.248 ns |  0.220 ns |   4.96x slower |   0.01x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    229.61 ns |  0.197 ns |  0.184 ns |   3.17x slower |   0.00x |       - |         - |
