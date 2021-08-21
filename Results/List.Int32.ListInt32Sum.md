## List.Int32.ListInt32Sum

### Source
[ListInt32Sum.cs](../LinqBenchmarks/List/Int32/ListInt32Sum.cs)

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
|                   Method | Count |         Mean |     Error |    StdDev |       Median |          Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|----------:|----------:|-------------:|---------------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |    118.07 ns |  0.034 ns |  0.030 ns |    118.07 ns |       baseline |         |      - |     - |     - |         - |
|              ForeachLoop |   100 |     81.99 ns |  0.023 ns |  0.019 ns |     81.99 ns |   1.44x faster |   0.00x |      - |     - |     - |         - |
|                     Linq |   100 |    274.38 ns |  0.362 ns |  0.321 ns |    274.26 ns |   2.32x slower |   0.00x | 0.0191 |     - |     - |      40 B |
|               LinqFaster |   100 |    119.24 ns |  0.039 ns |  0.035 ns |    119.24 ns |   1.01x slower |   0.00x |      - |     - |     - |         - |
|             LinqFasterer |   100 |    110.05 ns |  0.470 ns |  0.440 ns |    110.09 ns |   1.07x faster |   0.00x | 0.2027 |     - |     - |     424 B |
|                   LinqAF |   100 |    307.77 ns |  0.201 ns |  0.178 ns |    307.76 ns |   2.61x slower |   0.00x |      - |     - |     - |         - |
|            LinqOptimizer |   100 | 28,340.37 ns | 50.235 ns | 44.532 ns | 28,339.39 ns | 240.02x slower |   0.39x | 8.1177 |     - |     - |  17,017 B |
|                  Streams |   100 |    200.28 ns |  0.117 ns |  0.098 ns |    200.26 ns |   1.70x slower |   0.00x | 0.0994 |     - |     - |     208 B |
|               StructLinq |   100 |     81.82 ns |  0.103 ns |  0.091 ns |     81.79 ns |   1.44x faster |   0.00x | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |     65.90 ns |  0.032 ns |  0.025 ns |     65.91 ns |   1.79x faster |   0.00x |      - |     - |     - |         - |
|                Hyperlinq |   100 |     20.51 ns |  0.467 ns |  0.780 ns |     19.91 ns |   5.50x faster |   0.02x |      - |     - |     - |         - |
