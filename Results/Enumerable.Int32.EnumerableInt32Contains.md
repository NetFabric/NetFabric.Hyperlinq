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
|                   Method | Count |     Mean |   Error |  StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |---------:|--------:|--------:|-------------:|--------:|-------:|----------:|
|              ForeachLoop |   100 | 281.3 ns | 5.63 ns | 8.42 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq |   100 | 363.9 ns | 1.67 ns | 1.56 ns | 1.30x slower |   0.03x | 0.0191 |      40 B |
|                   LinqAF |   100 | 322.5 ns | 5.40 ns | 5.05 ns | 1.15x slower |   0.04x | 0.0191 |      40 B |
|               StructLinq |   100 | 352.4 ns | 6.83 ns | 7.31 ns | 1.25x slower |   0.04x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |   100 | 338.0 ns | 1.31 ns | 1.23 ns | 1.21x slower |   0.03x | 0.0191 |      40 B |
|                Hyperlinq |   100 | 309.5 ns | 2.08 ns | 1.74 ns | 1.10x slower |   0.03x | 0.0191 |      40 B |
