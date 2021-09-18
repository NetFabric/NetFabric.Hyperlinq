## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

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
|                   Method | Skip | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |----- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|----------:|
|                     Linq | 1000 |   100 |  2.616 μs | 0.0132 μs | 0.0123 μs |      baseline |         |  0.0992 |     208 B |
|                   LinqAF | 1000 |   100 | 28.687 μs | 1.7047 μs | 4.9456 μs | 10.80x slower |   1.85x |       - |     712 B |
|            LinqOptimizer | 1000 |   100 | 63.952 μs | 0.6465 μs | 0.6048 μs | 24.45x slower |   0.25x | 15.8691 |  33,278 B |
|                  Streams | 1000 |   100 |  7.512 μs | 0.0365 μs | 0.0305 μs |  2.87x slower |   0.01x |  0.4349 |     920 B |
|               StructLinq | 1000 |   100 |  2.856 μs | 0.0164 μs | 0.0137 μs |  1.09x slower |   0.01x |  0.0610 |     128 B |
| StructLinq_ValueDelegate | 1000 |   100 |  2.861 μs | 0.0126 μs | 0.0118 μs |  1.09x slower |   0.00x |  0.0191 |      40 B |
|                Hyperlinq | 1000 |   100 |  3.031 μs | 0.0144 μs | 0.0134 μs |  1.16x slower |   0.01x |  0.0191 |      40 B |
|  Hyperlinq_ValueDelegate | 1000 |   100 |  2.720 μs | 0.0453 μs | 0.0424 μs |  1.04x slower |   0.02x |  0.0191 |      40 B |
