## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |   100 |    956.3 ns |   2.83 ns |   2.37 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop |   100 |  1,219.5 ns |   3.78 ns |   3.35 ns |  1.28x slower |   0.01x |       - |       - |         - |
|                     Linq |   100 |  1,687.6 ns |   4.98 ns |   4.66 ns |  1.77x slower |   0.01x |  0.1793 |       - |     376 B |
|               LinqFaster |   100 |  2,369.7 ns |   6.44 ns |   5.03 ns |  2.48x slower |   0.01x |  3.8605 |       - |   8,088 B |
|             LinqFasterer |   100 |  2,657.3 ns |  43.40 ns |  40.59 ns |  2.78x slower |   0.04x |  6.4087 |       - |  13,416 B |
|                   LinqAF |   100 |  2,217.8 ns |   6.33 ns |   5.28 ns |  2.32x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer |   100 | 60,507.2 ns | 744.07 ns | 696.00 ns | 63.28x slower |   0.69x | 57.7393 | 19.1650 | 157,275 B |
|                 SpanLinq |   100 |  1,571.1 ns |   3.85 ns |   3.61 ns |  1.64x slower |   0.01x |       - |       - |         - |
|                  Streams |   100 |  2,769.7 ns |   2.57 ns |   2.00 ns |  2.90x slower |   0.01x |  0.4768 |       - |   1,000 B |
|               StructLinq |   100 |  1,194.1 ns |   3.37 ns |   2.99 ns |  1.25x slower |   0.00x |  0.0343 |       - |      72 B |
| StructLinq_ValueDelegate |   100 |    980.8 ns |   2.18 ns |   1.93 ns |  1.03x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |   100 |  1,602.6 ns |   4.38 ns |   4.10 ns |  1.68x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1,300.9 ns |   4.06 ns |   3.80 ns |  1.36x slower |   0.01x |       - |       - |         - |
