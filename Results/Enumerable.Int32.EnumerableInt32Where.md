## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|--------------:|--------:|--------:|----------:|
|                     Linq |   100 |    522.5 ns |   0.87 ns |   0.68 ns |      baseline |         |  0.0458 |      96 B |
|                   LinqAF |   100 |    412.8 ns |   7.25 ns |   6.78 ns |  1.27x faster |   0.02x |  0.0191 |      40 B |
|            LinqOptimizer |   100 | 46,174.8 ns | 276.00 ns | 258.17 ns | 88.36x slower |   0.51x | 13.8550 |  29,092 B |
|                  Streams |   100 |  1,551.1 ns |   6.73 ns |   6.30 ns |  2.97x slower |   0.01x |  0.2823 |     592 B |
|               StructLinq |   100 |    451.9 ns |   2.67 ns |   2.36 ns |  1.16x faster |   0.01x |  0.0305 |      64 B |
| StructLinq_ValueDelegate |   100 |    288.1 ns |   0.57 ns |   0.45 ns |  1.81x faster |   0.00x |  0.0191 |      40 B |
|                Hyperlinq |   100 |    444.7 ns |   2.74 ns |   2.43 ns |  1.18x faster |   0.01x |  0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |   100 |    343.6 ns |   2.26 ns |   2.00 ns |  1.52x faster |   0.01x |  0.0191 |      40 B |
