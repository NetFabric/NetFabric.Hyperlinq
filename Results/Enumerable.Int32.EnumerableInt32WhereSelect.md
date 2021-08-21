## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|------:|------:|----------:|
|              ForeachLoop |   100 |    188.5 ns |   0.56 ns |   0.46 ns |       baseline |         |  0.0191 |     - |     - |      40 B |
|                     Linq |   100 |    677.9 ns |   0.53 ns |   0.47 ns |   3.60x slower |   0.01x |  0.0763 |     - |     - |     160 B |
|                   LinqAF |   100 |    574.5 ns |   0.36 ns |   0.30 ns |   3.05x slower |   0.01x |  0.0191 |     - |     - |      40 B |
|            LinqOptimizer |   100 | 51,827.1 ns | 124.95 ns | 110.76 ns | 275.04x slower |   0.95x | 14.9536 |     - |     - |  31,276 B |
|                  Streams |   100 |  1,776.8 ns |   0.80 ns |   0.67 ns |   9.43x slower |   0.02x |  0.3548 |     - |     - |     744 B |
|               StructLinq |   100 |    533.9 ns |   2.90 ns |   2.57 ns |   2.83x slower |   0.01x |  0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate |   100 |    380.3 ns |   1.89 ns |   1.58 ns |   2.02x slower |   0.01x |  0.0191 |     - |     - |      40 B |
|                Hyperlinq |   100 |    563.3 ns |   0.52 ns |   0.46 ns |   2.99x slower |   0.01x |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_ValueDelegate |   100 |    375.1 ns |   0.42 ns |   0.38 ns |   1.99x slower |   0.01x |  0.0191 |     - |     - |      40 B |
