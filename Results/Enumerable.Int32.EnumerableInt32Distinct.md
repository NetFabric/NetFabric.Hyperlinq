## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

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
|                   Method | Count |       Mean |   Error |  StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |-----------:|--------:|--------:|-------------:|--------:|-------:|----------:|
|              ForeachLoop |   100 |   739.7 ns | 3.11 ns | 2.91 ns |     baseline |         | 0.0992 |     208 B |
|                     Linq |   100 |   776.5 ns | 4.56 ns | 3.81 ns | 1.05x slower |   0.01x | 0.1602 |     336 B |
|                   LinqAF |   100 | 1,574.8 ns | 7.27 ns | 6.07 ns | 2.13x slower |   0.01x | 1.2531 |   2,624 B |
|               StructLinq |   100 |   734.9 ns | 2.96 ns | 2.76 ns | 1.01x faster |   0.00x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |   100 |   734.2 ns | 2.69 ns | 2.51 ns | 1.01x faster |   0.01x | 0.0191 |      40 B |
|                Hyperlinq |   100 |   744.0 ns | 2.56 ns | 2.39 ns | 1.01x slower |   0.00x | 0.0191 |      40 B |
