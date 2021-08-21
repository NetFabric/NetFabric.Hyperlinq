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
|                       Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|------:|------:|----------:|
|                      ForLoop |   100 |    391.00 ns |   7.503 ns |   7.018 ns |       baseline |         |  0.5660 |     - |     - |   1,184 B |
|                  ForeachLoop |   100 |    385.64 ns |   0.627 ns |   0.556 ns |   1.01x faster |   0.02x |  0.5660 |     - |     - |   1,184 B |
|                         Linq |   100 |    334.36 ns |   0.400 ns |   0.334 ns |   1.17x faster |   0.02x |  0.2522 |     - |     - |     528 B |
|                   LinqFaster |   100 |    364.69 ns |   0.262 ns |   0.219 ns |   1.07x faster |   0.02x |  0.4358 |     - |     - |     912 B |
|                 LinqFasterer |   100 |    357.72 ns |   5.488 ns |   5.133 ns |   1.09x faster |   0.03x |  0.6232 |     - |     - |   1,304 B |
|                       LinqAF |   100 |    683.89 ns |   3.304 ns |   2.929 ns |   1.75x slower |   0.04x |  0.5655 |     - |     - |   1,184 B |
|                LinqOptimizer |   100 | 39,827.17 ns | 124.632 ns | 116.581 ns | 101.89x slower |   1.66x | 13.9771 |     - |     - |  29,360 B |
|                     SpanLinq |   100 |    352.13 ns |   1.018 ns |   0.850 ns |   1.11x faster |   0.02x |  0.2179 |     - |     - |     456 B |
|                      Streams |   100 |  1,395.73 ns |   1.066 ns |   0.945 ns |   3.57x slower |   0.06x |  0.7534 |     - |     - |   1,576 B |
|                   StructLinq |   100 |    270.85 ns |   0.299 ns |   0.279 ns |   1.44x faster |   0.03x |  0.2484 |     - |     - |     520 B |
|     StructLinq_ValueDelegate |   100 |    154.85 ns |   0.349 ns |   0.291 ns |   2.53x faster |   0.04x |  0.2370 |     - |     - |     496 B |
|                    Hyperlinq |   100 |    266.96 ns |   0.353 ns |   0.313 ns |   1.47x faster |   0.03x |  0.2179 |     - |     - |     456 B |
|      Hyperlinq_ValueDelegate |   100 |    130.06 ns |   2.690 ns |   3.098 ns |   2.98x faster |   0.05x |  0.2179 |     - |     - |     456 B |
|               Hyperlinq_SIMD |   100 |    105.81 ns |   0.522 ns |   0.488 ns |   3.70x faster |   0.06x |  0.2180 |     - |     - |     456 B |
| Hyperlinq_ValueDelegate_SIMD |   100 |     71.01 ns |   0.261 ns |   0.245 ns |   5.51x faster |   0.11x |  0.2180 |     - |     - |     456 B |
