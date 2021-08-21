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
|                   Method | Skip | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|------:|------:|----------:|
|                     Linq | 1000 |   100 |  2.805 μs | 0.0029 μs | 0.0024 μs |      baseline |         |  0.0992 |     - |     - |     208 B |
|                   LinqAF | 1000 |   100 |  3.122 μs | 0.0031 μs | 0.0026 μs |  1.11x slower |   0.00x |  0.0191 |     - |     - |      40 B |
|            LinqOptimizer | 1000 |   100 | 61.944 μs | 0.1768 μs | 0.1476 μs | 22.09x slower |   0.06x | 15.8691 |     - |     - |  33,278 B |
|                  Streams | 1000 |   100 |  7.396 μs | 0.0054 μs | 0.0042 μs |  2.64x slower |   0.00x |  0.4349 |     - |     - |     920 B |
|               StructLinq | 1000 |   100 |  2.824 μs | 0.0018 μs | 0.0017 μs |  1.01x slower |   0.00x |  0.0610 |     - |     - |     128 B |
| StructLinq_ValueDelegate | 1000 |   100 |  2.806 μs | 0.0026 μs | 0.0023 μs |  1.00x slower |   0.00x |  0.0191 |     - |     - |      40 B |
|                Hyperlinq | 1000 |   100 |  3.054 μs | 0.0023 μs | 0.0019 μs |  1.09x slower |   0.00x |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_ValueDelegate | 1000 |   100 |  2.655 μs | 0.0012 μs | 0.0009 μs |  1.06x faster |   0.00x |  0.0191 |     - |     - |      40 B |
