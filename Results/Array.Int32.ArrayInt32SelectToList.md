## Array.Int32.ArrayInt32SelectToList

### Source
[ArrayInt32SelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                       Method | Count |         Mean |      Error |     StdDev |       Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |------ |-------------:|-----------:|-----------:|-------------:|-------:|--------:|--------:|------:|------:|----------:|
|                      ForLoop |   100 |    284.51 ns |   2.892 ns |   2.705 ns |    284.77 ns |   1.00 |    0.00 |  0.5660 |     - |     - |   1,184 B |
|                  ForeachLoop |   100 |    281.39 ns |   2.524 ns |   2.361 ns |    281.28 ns |   0.99 |    0.01 |  0.5660 |     - |     - |   1,184 B |
|                         Linq |   100 |    244.66 ns |   1.032 ns |   0.966 ns |    244.93 ns |   0.86 |    0.01 |  0.2408 |     - |     - |     504 B |
|                   LinqFaster |   100 |    240.14 ns |   1.895 ns |   1.479 ns |    240.11 ns |   0.84 |    0.01 |  0.4206 |     - |     - |     880 B |
|              LinqFaster_SIMD |   100 |    114.55 ns |   0.745 ns |   0.660 ns |    114.57 ns |   0.40 |    0.01 |  0.4207 |     - |     - |     880 B |
|                 LinqFasterer |   100 |    251.09 ns |   1.215 ns |   1.137 ns |    251.05 ns |   0.88 |    0.01 |  0.4206 |     - |     - |     880 B |
|                       LinqAF |   100 |    768.45 ns |  14.779 ns |  12.342 ns |    763.58 ns |   2.71 |    0.05 |  0.5655 |     - |     - |   1,184 B |
|                LinqOptimizer |   100 | 33,551.90 ns | 542.355 ns | 507.319 ns | 33,591.62 ns | 117.94 |    2.08 | 13.4888 |     - |     - |  28,340 B |
|                      Streams |   100 |  1,360.14 ns |   5.224 ns |   4.886 ns |  1,359.79 ns |   4.78 |    0.05 |  0.7534 |     - |     - |   1,576 B |
|                   StructLinq |   100 |    249.54 ns |   2.202 ns |   1.952 ns |    249.61 ns |   0.88 |    0.01 |  0.2484 |     - |     - |     520 B |
|     StructLinq_ValueDelegate |   100 |    133.15 ns |   2.721 ns |   5.043 ns |    130.44 ns |   0.49 |    0.02 |  0.2370 |     - |     - |     496 B |
|                    Hyperlinq |   100 |    216.81 ns |   2.229 ns |   1.741 ns |    216.42 ns |   0.76 |    0.01 |  0.2179 |     - |     - |     456 B |
|      Hyperlinq_ValueDelegate |   100 |    107.26 ns |   0.891 ns |   0.834 ns |    106.96 ns |   0.38 |    0.00 |  0.2180 |     - |     - |     456 B |
|               Hyperlinq_SIMD |   100 |     92.30 ns |   0.469 ns |   0.439 ns |     92.29 ns |   0.32 |    0.00 |  0.2180 |     - |     - |     456 B |
| Hyperlinq_ValueDelegate_SIMD |   100 |     62.09 ns |   1.308 ns |   1.092 ns |     61.65 ns |   0.22 |    0.00 |  0.2180 |     - |     - |     456 B |
