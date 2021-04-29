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
|                       Method | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|--------:|------:|------:|----------:|
|                      ForLoop |   100 |    347.73 ns |  20.955 ns |  61.788 ns |    322.81 ns |  1.00 |    0.00 |  0.5660 |     - |     - |   1,184 B |
|                  ForeachLoop |   100 |    289.16 ns |   2.253 ns |   2.107 ns |    289.24 ns |  0.73 |    0.14 |  0.5660 |     - |     - |   1,184 B |
|                         Linq |   100 |    262.77 ns |   4.583 ns |   3.578 ns |    262.00 ns |  0.69 |    0.13 |  0.2408 |     - |     - |     504 B |
|                   LinqFaster |   100 |    254.70 ns |   2.352 ns |   2.200 ns |    254.80 ns |  0.65 |    0.12 |  0.4206 |     - |     - |     880 B |
|              LinqFaster_SIMD |   100 |    120.19 ns |   0.814 ns |   0.762 ns |    120.33 ns |  0.30 |    0.06 |  0.4206 |     - |     - |     880 B |
|                 LinqFasterer |   100 |    258.12 ns |   3.316 ns |   2.769 ns |    257.45 ns |  0.66 |    0.14 |  0.4206 |     - |     - |     880 B |
|                       LinqAF |   100 |    805.53 ns |   5.635 ns |   4.995 ns |    805.85 ns |  2.05 |    0.40 |  0.5655 |     - |     - |   1,184 B |
|                LinqOptimizer |   100 | 34,776.32 ns | 270.743 ns | 253.253 ns | 34,804.10 ns | 88.11 |   16.72 | 13.4888 |     - |     - |  28,340 B |
|                      Streams |   100 |  1,415.82 ns |   7.333 ns |   6.859 ns |  1,413.55 ns |  3.59 |    0.68 |  0.7534 |     - |     - |   1,576 B |
|                   StructLinq |   100 |    257.45 ns |   1.791 ns |   1.675 ns |    257.41 ns |  0.65 |    0.13 |  0.2484 |     - |     - |     520 B |
|     StructLinq_ValueDelegate |   100 |    139.30 ns |   1.273 ns |   1.129 ns |    139.68 ns |  0.35 |    0.07 |  0.2370 |     - |     - |     496 B |
|                    Hyperlinq |   100 |    220.96 ns |   1.191 ns |   1.114 ns |    221.14 ns |  0.56 |    0.11 |  0.2179 |     - |     - |     456 B |
|      Hyperlinq_ValueDelegate |   100 |    106.25 ns |   0.373 ns |   0.746 ns |    106.26 ns |  0.28 |    0.05 |  0.2180 |     - |     - |     456 B |
|               Hyperlinq_SIMD |   100 |     93.49 ns |   0.497 ns |   0.415 ns |     93.46 ns |  0.24 |    0.05 |  0.2180 |     - |     - |     456 B |
| Hyperlinq_ValueDelegate_SIMD |   100 |     63.44 ns |   0.630 ns |   0.559 ns |     63.55 ns |  0.16 |    0.03 |  0.2180 |     - |     - |     456 B |
