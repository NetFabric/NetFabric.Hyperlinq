## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

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
|                   Method | Skip | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |----- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop | 1000 |   100 |  1.655 μs | 0.0031 μs | 0.0027 μs |      baseline |         |       - |       - |         - |
|                     Linq | 1000 |   100 |  2.342 μs | 0.0050 μs | 0.0046 μs |  1.42x slower |   0.00x |  0.1526 |       - |     320 B |
|               LinqFaster | 1000 |   100 |  5.010 μs | 0.0228 μs | 0.0213 μs |  3.03x slower |   0.02x |  9.2545 |       - |  19,368 B |
|             LinqFasterer | 1000 |   100 |  8.920 μs | 0.1345 μs | 0.1192 μs |  5.39x slower |   0.07x | 39.2151 |       - |  83,304 B |
|                   LinqAF | 1000 |   100 |  9.133 μs | 0.0276 μs | 0.0245 μs |  5.52x slower |   0.02x |       - |       - |         - |
|            LinqOptimizer | 1000 |   100 | 72.921 μs | 0.5333 μs | 0.4989 μs | 44.09x slower |   0.28x | 72.6318 | 18.0664 | 161,841 B |
|                 SpanLinq | 1000 |   100 |  2.235 μs | 0.0036 μs | 0.0034 μs |  1.35x slower |   0.00x |       - |       - |         - |
|                  Streams | 1000 |   100 | 11.601 μs | 0.0406 μs | 0.0380 μs |  7.01x slower |   0.03x |  0.5493 |       - |   1,176 B |
|               StructLinq | 1000 |   100 |  1.922 μs | 0.0030 μs | 0.0023 μs |  1.16x slower |   0.00x |  0.0572 |       - |     120 B |
| StructLinq_ValueDelegate | 1000 |   100 |  1.623 μs | 0.0015 μs | 0.0014 μs |  1.02x faster |   0.00x |       - |       - |         - |
|                Hyperlinq | 1000 |   100 |  1.925 μs | 0.0041 μs | 0.0038 μs |  1.16x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |  1.729 μs | 0.0017 μs | 0.0016 μs |  1.04x slower |   0.00x |       - |       - |         - |
