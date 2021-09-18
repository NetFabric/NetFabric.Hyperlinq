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
|                   Method | Count |         Mean |        Error |       StdDev |       Median |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |-------------:|-------------:|-------------:|-------------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |    168.70 ns |     6.215 ns |    17.221 ns |    165.85 ns |       baseline |         |      - |         - |
|              ForeachLoop |   100 |    408.22 ns |     8.118 ns |    16.583 ns |    398.47 ns |   2.49x slower |   0.21x |      - |         - |
|                     Linq |   100 |    763.81 ns |     3.027 ns |     2.364 ns |    763.08 ns |   4.44x slower |   0.33x | 0.0458 |      96 B |
|               LinqFaster |   100 |    386.65 ns |     7.666 ns |     7.529 ns |    384.47 ns |   2.30x slower |   0.16x |      - |         - |
|             LinqFasterer |   100 |    930.76 ns |    76.311 ns |   217.720 ns |    855.76 ns |   5.62x slower |   1.40x | 3.0670 |   6,424 B |
|                   LinqAF |   100 |    969.81 ns |    20.231 ns |    56.395 ns |    950.47 ns |   5.80x slower |   0.67x |      - |         - |
|            LinqOptimizer |   100 | 47,032.20 ns | 2,705.808 ns | 7,361.351 ns | 44,767.75 ns | 280.62x slower |  53.81x | 9.3994 |  19,828 B |
|                  Streams |   100 |    988.07 ns |    30.748 ns |    87.725 ns |    965.61 ns |   5.93x slower |   0.82x | 0.1717 |     360 B |
|               StructLinq |   100 |    247.09 ns |     4.055 ns |     4.339 ns |    247.72 ns |   1.49x slower |   0.11x | 0.0191 |      40 B |
| StructLinq_ValueDelegate |   100 |     95.52 ns |     0.364 ns |     0.341 ns |     95.33 ns |   1.77x faster |   0.15x |      - |         - |
|                Hyperlinq |   100 |    522.60 ns |     5.309 ns |     4.966 ns |    523.85 ns |   3.10x slower |   0.24x |      - |         - |
|  Hyperlinq_ValueDelegate |   100 |    291.38 ns |     0.611 ns |     0.571 ns |    291.27 ns |   1.73x slower |   0.14x |      - |         - |
