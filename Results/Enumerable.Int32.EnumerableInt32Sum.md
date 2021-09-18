## Enumerable.Int32.EnumerableInt32Sum

### Source
[EnumerableInt32Sum.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Sum.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|---------------:|--------:|-------:|----------:|
|              ForeachLoop |   100 |    247.8 ns |   0.65 ns |   0.51 ns |       baseline |         | 0.0191 |      40 B |
|                     Linq |   100 |    275.0 ns |   0.46 ns |   0.36 ns |   1.11x slower |   0.00x | 0.0191 |      40 B |
|                   LinqAF |   100 |    314.9 ns |   1.13 ns |   1.00 ns |   1.27x slower |   0.00x | 0.0191 |      40 B |
|            LinqOptimizer |   100 | 28,433.0 ns | 163.26 ns | 152.72 ns | 114.78x slower |   0.67x | 8.2397 |  17,274 B |
|                  Streams |   100 |    389.5 ns |   2.07 ns |   1.84 ns |   1.57x slower |   0.01x | 0.1183 |     248 B |
|               StructLinq |   100 |    288.7 ns |   0.61 ns |   0.47 ns |   1.17x slower |   0.00x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |   100 |    282.1 ns |   5.40 ns |   5.55 ns |   1.14x slower |   0.02x | 0.0191 |      40 B |
|                Hyperlinq |   100 |    248.6 ns |   1.57 ns |   1.39 ns |   1.00x slower |   0.01x | 0.0191 |      40 B |
