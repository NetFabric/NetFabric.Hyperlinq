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
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.0, OS=macOS Catalina 10.15.7 (19H1323) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|--------------:|--------:|--------:|--------:|------:|----------:|
|                  ForLoop |   100 |    955.5 ns |   0.26 ns |   0.23 ns |      baseline |         |       - |       - |     - |         - |
|              ForeachLoop |   100 |  1,236.1 ns |   0.42 ns |   0.38 ns |  1.29x slower |   0.00x |       - |       - |     - |         - |
|                     Linq |   100 |  1,707.6 ns |  10.51 ns |   9.83 ns |  1.79x slower |   0.01x |  0.1793 |       - |     - |     376 B |
|               LinqFaster |   100 |  2,426.1 ns |  35.96 ns |  31.88 ns |  2.54x slower |   0.03x |  3.8605 |       - |     - |   8,088 B |
|             LinqFasterer |   100 |  2,657.6 ns |   5.54 ns |   4.63 ns |  2.78x slower |   0.01x |  6.4087 |       - |     - |  13,416 B |
|                   LinqAF |   100 |  2,241.1 ns |   2.10 ns |   1.96 ns |  2.35x slower |   0.00x |       - |       - |     - |         - |
|            LinqOptimizer |   100 | 59,572.4 ns | 645.40 ns | 503.89 ns | 62.35x slower |   0.53x | 57.6782 | 19.2261 |     - | 157,274 B |
|                 SpanLinq |   100 |  1,576.0 ns |   0.65 ns |   0.51 ns |  1.65x slower |   0.00x |       - |       - |     - |         - |
|                  Streams |   100 |  2,768.0 ns |   2.31 ns |   1.93 ns |  2.90x slower |   0.00x |  0.4768 |       - |     - |   1,000 B |
|               StructLinq |   100 |  1,191.4 ns |   0.63 ns |   0.56 ns |  1.25x slower |   0.00x |  0.0343 |       - |     - |      72 B |
| StructLinq_ValueDelegate |   100 |    979.9 ns |   0.27 ns |   0.25 ns |  1.03x slower |   0.00x |       - |       - |     - |         - |
|                Hyperlinq |   100 |  1,630.6 ns |   2.05 ns |   1.82 ns |  1.71x slower |   0.00x |       - |       - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1,299.7 ns |   1.24 ns |   0.97 ns |  1.36x slower |   0.00x |       - |       - |     - |         - |
