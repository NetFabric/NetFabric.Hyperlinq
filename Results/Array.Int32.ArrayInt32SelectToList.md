## Array.Int32.ArrayInt32SelectToList

### Source
[ArrayInt32SelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SelectToList.cs)

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
|                       Method | Count |         Mean |      Error |     StdDev |       Median |          Ratio | RatioSD |   Gen 0 | Allocated |
|----------------------------- |------ |-------------:|-----------:|-----------:|-------------:|---------------:|--------:|--------:|----------:|
|                      ForLoop |   100 |    324.25 ns |   0.625 ns |   0.488 ns |    324.32 ns |       baseline |         |  0.5660 |   1,184 B |
|                  ForeachLoop |   100 |    345.35 ns |   6.770 ns |   8.059 ns |    343.26 ns |   1.08x slower |   0.02x |  0.5660 |   1,184 B |
|                         Linq |   100 |    307.73 ns |   1.054 ns |   0.934 ns |    307.75 ns |   1.05x faster |   0.00x |  0.2408 |     504 B |
|                   LinqFaster |   100 |    307.16 ns |   1.345 ns |   1.258 ns |    306.93 ns |   1.06x faster |   0.00x |  0.4206 |     880 B |
|              LinqFaster_SIMD |   100 |    146.89 ns |   0.614 ns |   0.545 ns |    146.80 ns |   2.21x faster |   0.01x |  0.4208 |     880 B |
|                 LinqFasterer |   100 |    310.51 ns |   0.379 ns |   0.336 ns |    310.47 ns |   1.04x faster |   0.00x |  0.4206 |     880 B |
|                       LinqAF |   100 |    581.76 ns |   0.872 ns |   0.728 ns |    581.55 ns |   1.79x slower |   0.00x |  0.5655 |   1,184 B |
|                LinqOptimizer |   100 | 36,921.45 ns | 267.281 ns | 250.015 ns | 36,900.57 ns | 113.89x slower |   0.84x | 13.5498 |  28,341 B |
|                     SpanLinq |   100 |    399.95 ns |   7.963 ns |  15.150 ns |    393.52 ns |   1.29x slower |   0.06x |  0.2179 |     456 B |
|                      Streams |   100 |  1,570.85 ns |   1.960 ns |   1.738 ns |  1,570.45 ns |   4.84x slower |   0.01x |  0.7534 |   1,576 B |
|                   StructLinq |   100 |    276.67 ns |   0.714 ns |   0.633 ns |    276.50 ns |   1.17x faster |   0.00x |  0.2484 |     520 B |
|     StructLinq_ValueDelegate |   100 |    206.66 ns |   0.847 ns |   0.751 ns |    206.52 ns |   1.57x faster |   0.00x |  0.2370 |     496 B |
|                    Hyperlinq |   100 |    267.37 ns |   0.402 ns |   0.376 ns |    267.45 ns |   1.21x faster |   0.00x |  0.2179 |     456 B |
|      Hyperlinq_ValueDelegate |   100 |    126.19 ns |   0.463 ns |   0.386 ns |    126.16 ns |   2.57x faster |   0.01x |  0.2179 |     456 B |
|               Hyperlinq_SIMD |   100 |    105.34 ns |   0.361 ns |   0.320 ns |    105.24 ns |   3.08x faster |   0.01x |  0.2180 |     456 B |
| Hyperlinq_ValueDelegate_SIMD |   100 |     71.38 ns |   0.133 ns |   0.111 ns |     71.38 ns |   4.54x faster |   0.01x |  0.2180 |     456 B |
