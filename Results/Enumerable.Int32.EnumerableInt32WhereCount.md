## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|---------------:|--------:|-------:|------:|------:|----------:|
|              ForeachLoop |   100 |    300.0 ns |   0.20 ns |   0.18 ns |       baseline |         | 0.0191 |     - |     - |      40 B |
|                     Linq |   100 |    358.4 ns |   0.20 ns |   0.16 ns |   1.19x slower |   0.00x | 0.0191 |     - |     - |      40 B |
|                   LinqAF |   100 |    405.6 ns |   0.45 ns |   0.35 ns |   1.35x slower |   0.00x | 0.0191 |     - |     - |      40 B |
|            LinqOptimizer |   100 | 41,115.4 ns | 622.47 ns | 485.99 ns | 137.08x slower |   1.62x | 9.7046 |     - |     - |  20,389 B |
|                  Streams |   100 |    775.4 ns |   3.41 ns |   2.84 ns |   2.59x slower |   0.01x | 0.1907 |     - |     - |     400 B |
|               StructLinq |   100 |    420.1 ns |   0.69 ns |   0.58 ns |   1.40x slower |   0.00x | 0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate |   100 |    280.8 ns |   0.93 ns |   0.87 ns |   1.07x faster |   0.00x | 0.0191 |     - |     - |      40 B |
|                Hyperlinq |   100 |    364.8 ns |   0.23 ns |   0.22 ns |   1.22x slower |   0.00x | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_ValueDelegate |   100 |    207.5 ns |   0.26 ns |   0.24 ns |   1.45x faster |   0.00x | 0.0191 |     - |     - |      40 B |
