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
- NetFabric.Hyperlinq: [3.0.0-beta46](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta46)
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
|                   Method | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|--------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |    854.0 ns |   0.58 ns |   0.52 ns |      baseline |         |       - |         - |
|              ForeachLoop |   100 |    929.3 ns |   1.02 ns |   0.91 ns |  1.09x slower |   0.00x |       - |         - |
|                     Linq |   100 |  1,471.0 ns |   0.88 ns |   0.74 ns |  1.72x slower |   0.00x |  0.1030 |     216 B |
|               LinqFaster |   100 |  1,994.7 ns |   3.09 ns |   2.41 ns |  2.34x slower |   0.00x |  4.7264 |   9,904 B |
|             LinqFasterer |   100 |  3,620.6 ns |   8.13 ns |   7.21 ns |  4.24x slower |   0.01x |  6.0234 |  12,624 B |
|                   LinqAF |   100 |  2,032.0 ns |   1.35 ns |   1.12 ns |  2.38x slower |   0.00x |       - |         - |
|            LinqOptimizer |   100 | 56,657.7 ns | 441.94 ns | 391.76 ns | 66.35x slower |   0.46x | 74.0356 | 156,327 B |
|                 SpanLinq |   100 |  1,586.3 ns |   2.25 ns |   2.10 ns |  1.86x slower |   0.00x |       - |         - |
|                  Streams |   100 |  2,660.6 ns |   3.39 ns |   3.01 ns |  3.12x slower |   0.00x |  0.4654 |     976 B |
|               StructLinq |   100 |  1,194.1 ns |   2.52 ns |   2.10 ns |  1.40x slower |   0.00x |  0.0305 |      64 B |
| StructLinq_ValueDelegate |   100 |    973.8 ns |   0.75 ns |   0.63 ns |  1.14x slower |   0.00x |       - |         - |
|                Hyperlinq |   100 |  1,600.4 ns |   3.09 ns |   2.89 ns |  1.87x slower |   0.00x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1,301.3 ns |   2.49 ns |   2.33 ns |  1.52x slower |   0.00x |       - |         - |
