## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|----------:|
|              ForeachLoop |   100 |    274.1 ns |   0.88 ns |   0.73 ns |       baseline |         |  0.0191 |      40 B |
|                     Linq |   100 |    454.4 ns |   1.53 ns |   1.43 ns |   1.66x slower |   0.01x |  0.0458 |      96 B |
|                   LinqAF |   100 |    399.3 ns |   1.36 ns |   1.27 ns |   1.46x slower |   0.01x |  0.0191 |      40 B |
|            LinqOptimizer |   100 | 39,296.5 ns | 242.47 ns | 202.48 ns | 143.35x slower |   0.87x | 13.5498 |  28,431 B |
|                  Streams |   100 |  1,515.7 ns |   9.88 ns |   8.76 ns |   5.53x slower |   0.04x |  0.2823 |     592 B |
|               StructLinq |   100 |    338.0 ns |   1.43 ns |   1.33 ns |   1.23x slower |   0.01x |  0.0305 |      64 B |
| StructLinq_ValueDelegate |   100 |    313.2 ns |   1.08 ns |   1.01 ns |   1.14x slower |   0.00x |  0.0191 |      40 B |
|                Hyperlinq |   100 |    363.2 ns |   1.67 ns |   1.56 ns |   1.32x slower |   0.01x |  0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |   100 |    287.1 ns |   2.36 ns |   2.21 ns |   1.05x slower |   0.00x |  0.0191 |      40 B |
