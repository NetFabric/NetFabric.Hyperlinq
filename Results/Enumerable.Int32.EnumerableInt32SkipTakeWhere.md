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
|                   Method | Skip | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |----- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|----------:|
|                     Linq | 1000 |   100 |  2.707 μs | 0.0080 μs | 0.0071 μs |      baseline |         |  0.0992 |     208 B |
|                   LinqAF | 1000 |   100 |  3.128 μs | 0.0098 μs | 0.0087 μs |  1.16x slower |   0.00x |  0.0191 |      40 B |
|            LinqOptimizer | 1000 |   100 | 62.028 μs | 0.3809 μs | 0.3563 μs | 22.90x slower |   0.17x | 15.8691 |  33,278 B |
|                  Streams | 1000 |   100 |  7.461 μs | 0.0121 μs | 0.0107 μs |  2.76x slower |   0.01x |  0.4349 |     920 B |
|               StructLinq | 1000 |   100 |  2.846 μs | 0.0139 μs | 0.0123 μs |  1.05x slower |   0.01x |  0.0610 |     128 B |
| StructLinq_ValueDelegate | 1000 |   100 |  2.813 μs | 0.0059 μs | 0.0055 μs |  1.04x slower |   0.00x |  0.0191 |      40 B |
|                Hyperlinq | 1000 |   100 |  2.553 μs | 0.0067 μs | 0.0062 μs |  1.06x faster |   0.00x |  0.0191 |      40 B |
|  Hyperlinq_ValueDelegate | 1000 |   100 |  2.683 μs | 0.0053 μs | 0.0050 μs |  1.01x faster |   0.00x |  0.0191 |      40 B |
