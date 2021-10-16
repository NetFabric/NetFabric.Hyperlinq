## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|                  ForLoop |   100 |    856.0 ns |   4.21 ns |   3.94 ns |      baseline |         |       - |         - |
|              ForeachLoop |   100 |    931.7 ns |   0.77 ns |   0.64 ns |  1.09x slower |   0.01x |       - |         - |
|                     Linq |   100 |  1,474.9 ns |   1.59 ns |   1.48 ns |  1.72x slower |   0.01x |  0.1030 |     216 B |
|               LinqFaster |   100 |  2,025.5 ns |   4.52 ns |   3.53 ns |  2.37x slower |   0.01x |  4.7264 |   9,904 B |
|             LinqFasterer |   100 |  3,777.7 ns |  11.10 ns |   9.84 ns |  4.41x slower |   0.02x |  6.0234 |  12,624 B |
|                   LinqAF |   100 |  2,045.5 ns |   2.21 ns |   1.96 ns |  2.39x slower |   0.01x |       - |         - |
|            LinqOptimizer |   100 | 55,073.1 ns | 193.28 ns | 171.33 ns | 64.36x slower |   0.35x | 74.0356 | 156,327 B |
|                 SpanLinq |   100 |  1,567.2 ns |   1.06 ns |   0.94 ns |  1.83x slower |   0.01x |       - |         - |
|                  Streams |   100 |  2,704.3 ns |   2.90 ns |   2.57 ns |  3.16x slower |   0.02x |  0.4654 |     976 B |
|               StructLinq |   100 |  1,194.4 ns |   0.61 ns |   0.54 ns |  1.40x slower |   0.01x |  0.0305 |      64 B |
| StructLinq_ValueDelegate |   100 |    973.1 ns |   0.57 ns |   0.48 ns |  1.14x slower |   0.01x |       - |         - |
|                Hyperlinq |   100 |  1,611.6 ns |   0.99 ns |   0.92 ns |  1.88x slower |   0.01x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1,313.9 ns |   0.75 ns |   0.67 ns |  1.54x slower |   0.01x |       - |         - |
