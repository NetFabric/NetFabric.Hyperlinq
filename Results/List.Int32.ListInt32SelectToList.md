## List.Int32.ListInt32SelectToList

### Source
[ListInt32SelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32SelectToList.cs)

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
|                       Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|----------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|----------:|
|                      ForLoop |   100 |    378.69 ns |   2.211 ns |   1.960 ns |       baseline |         |  0.5660 |   1,184 B |
|                  ForeachLoop |   100 |    382.55 ns |   2.305 ns |   2.044 ns |   1.01x slower |   0.01x |  0.5660 |   1,184 B |
|                         Linq |   100 |    345.33 ns |   1.803 ns |   1.598 ns |   1.10x faster |   0.01x |  0.2522 |     528 B |
|                   LinqFaster |   100 |    361.40 ns |   2.857 ns |   2.386 ns |   1.05x faster |   0.01x |  0.4358 |     912 B |
|                 LinqFasterer |   100 |    382.15 ns |   1.607 ns |   1.503 ns |   1.01x slower |   0.01x |  0.6232 |   1,304 B |
|                       LinqAF |   100 |    682.83 ns |   5.225 ns |   4.887 ns |   1.80x slower |   0.02x |  0.5655 |   1,184 B |
|                LinqOptimizer |   100 | 41,053.99 ns | 353.715 ns | 330.866 ns | 108.46x slower |   1.13x | 14.0381 |  29,360 B |
|                     SpanLinq |   100 |    416.17 ns |   1.084 ns |   0.905 ns |   1.10x slower |   0.01x |  0.2179 |     456 B |
|                      Streams |   100 |  1,523.71 ns |   8.554 ns |   8.001 ns |   4.02x slower |   0.02x |  0.7534 |   1,576 B |
|                   StructLinq |   100 |    284.65 ns |   1.496 ns |   1.399 ns |   1.33x faster |   0.01x |  0.2484 |     520 B |
|     StructLinq_ValueDelegate |   100 |    154.79 ns |   0.920 ns |   0.861 ns |   2.45x faster |   0.02x |  0.2370 |     496 B |
|                    Hyperlinq |   100 |    266.98 ns |   0.311 ns |   0.243 ns |   1.42x faster |   0.01x |  0.2179 |     456 B |
|      Hyperlinq_ValueDelegate |   100 |    130.83 ns |   0.319 ns |   0.249 ns |   2.89x faster |   0.01x |  0.2179 |     456 B |
|               Hyperlinq_SIMD |   100 |    107.19 ns |   1.883 ns |   1.761 ns |   3.54x faster |   0.06x |  0.2180 |     456 B |
| Hyperlinq_ValueDelegate_SIMD |   100 |     70.42 ns |   0.528 ns |   0.441 ns |   5.38x faster |   0.03x |  0.2180 |     456 B |
