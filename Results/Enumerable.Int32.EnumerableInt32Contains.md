## Enumerable.Int32.EnumerableInt32Contains

### Source
[EnumerableInt32Contains.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Contains.cs)

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
|                   Method | Count |     Mean |   Error |  StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |---------:|--------:|--------:|-------------:|--------:|-------:|----------:|
|              ForeachLoop |   100 | 275.2 ns | 1.15 ns | 1.08 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq |   100 | 361.6 ns | 1.12 ns | 0.99 ns | 1.31x slower |   0.00x | 0.0191 |      40 B |
|                   LinqAF |   100 | 346.8 ns | 1.75 ns | 1.55 ns | 1.26x slower |   0.01x | 0.0191 |      40 B |
|               StructLinq |   100 | 346.2 ns | 0.83 ns | 0.78 ns | 1.26x slower |   0.01x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |   100 | 336.0 ns | 0.62 ns | 0.58 ns | 1.22x slower |   0.01x | 0.0191 |      40 B |
|                Hyperlinq |   100 | 333.5 ns | 0.87 ns | 0.81 ns | 1.21x slower |   0.01x | 0.0191 |      40 B |
