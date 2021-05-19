## Array.Int32.ArrayInt32SelectToList

### Source
[ArrayInt32SelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [1.0.0](https://www.nuget.org/packages/SpanLinq/1.0.0)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1538-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                       Method | Count |         Mean |      Error |     StdDev |       Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |------ |-------------:|-----------:|-----------:|-------------:|-------:|--------:|--------:|------:|------:|----------:|
|                      ForLoop |   100 |    306.57 ns |   3.168 ns |   2.809 ns |    307.37 ns |   1.00 |    0.00 |  0.5660 |     - |     - |   1,184 B |
|                  ForeachLoop |   100 |    304.09 ns |   3.688 ns |   3.450 ns |    304.32 ns |   0.99 |    0.01 |  0.5660 |     - |     - |   1,184 B |
|                         Linq |   100 |    253.81 ns |   4.490 ns |   3.980 ns |    252.37 ns |   0.83 |    0.01 |  0.2408 |     - |     - |     504 B |
|                   LinqFaster |   100 |    304.13 ns |   2.410 ns |   2.136 ns |    304.55 ns |   0.99 |    0.01 |  0.4206 |     - |     - |     880 B |
|              LinqFaster_SIMD |   100 |    122.34 ns |   2.062 ns |   1.928 ns |    122.09 ns |   0.40 |    0.01 |  0.4206 |     - |     - |     880 B |
|                 LinqFasterer |   100 |    307.36 ns |   2.778 ns |   2.462 ns |    306.98 ns |   1.00 |    0.01 |  0.4206 |     - |     - |     880 B |
|                       LinqAF |   100 |    890.72 ns |   6.435 ns |   5.705 ns |    889.50 ns |   2.91 |    0.04 |  0.5655 |     - |     - |   1,184 B |
|                LinqOptimizer |   100 | 42,179.28 ns | 387.650 ns | 362.608 ns | 42,261.69 ns | 137.70 |    1.80 | 13.4888 |     - |     - |  28,340 B |
|                     SpanLinq |   100 |    346.63 ns |   2.334 ns |   2.069 ns |    346.46 ns |   1.13 |    0.01 |  0.2179 |     - |     - |     456 B |
|                      Streams |   100 |  1,422.18 ns |   7.605 ns |   6.742 ns |  1,423.03 ns |   4.64 |    0.05 |  0.7534 |     - |     - |   1,576 B |
|                   StructLinq |   100 |    278.20 ns |   2.577 ns |   2.410 ns |    277.33 ns |   0.91 |    0.01 |  0.2484 |     - |     - |     520 B |
|     StructLinq_ValueDelegate |   100 |    137.71 ns |   2.012 ns |   1.783 ns |    137.41 ns |   0.45 |    0.01 |  0.2370 |     - |     - |     496 B |
|                    Hyperlinq |   100 |    241.25 ns |   2.453 ns |   2.295 ns |    240.56 ns |   0.79 |    0.01 |  0.2179 |     - |     - |     456 B |
|      Hyperlinq_ValueDelegate |   100 |    118.54 ns |   2.493 ns |   7.351 ns |    114.31 ns |   0.38 |    0.01 |  0.2180 |     - |     - |     456 B |
|               Hyperlinq_SIMD |   100 |     96.02 ns |   0.589 ns |   0.523 ns |     96.06 ns |   0.31 |    0.00 |  0.2180 |     - |     - |     456 B |
| Hyperlinq_ValueDelegate_SIMD |   100 |     68.66 ns |   1.100 ns |   1.029 ns |     68.58 ns |   0.22 |    0.00 |  0.2180 |     - |     - |     456 B |
