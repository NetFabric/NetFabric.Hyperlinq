## Array.Int32.ArrayInt32SelectToList

### Source
[ArrayInt32SelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                   Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                  **ForLoop** |    **10** |    **65.47 ns** |  **0.310 ns** |  **0.275 ns** |  **1.00** |    **0.00** | **0.1032** |     **-** |     **-** |     **216 B** |
|              ForeachLoop |    10 |    65.76 ns |  0.386 ns |  0.343 ns |  1.00 |    0.01 | 0.1032 |     - |     - |     216 B |
|                     Linq |    10 |    66.76 ns |  0.345 ns |  0.288 ns |  1.02 |    0.01 | 0.0688 |     - |     - |     144 B |
|               LinqFaster |    10 |    56.14 ns |  0.233 ns |  0.218 ns |  0.86 |    0.00 | 0.0764 |     - |     - |     160 B |
|          LinqFaster_SIMD |    10 |    45.46 ns |  0.245 ns |  0.205 ns |  0.69 |    0.00 | 0.0764 |     - |     - |     160 B |
|                   LinqAF |    10 |   162.85 ns |  1.006 ns |  0.840 ns |  2.49 |    0.02 | 0.1032 |     - |     - |     216 B |
|               StructLinq |    10 |    57.54 ns |  0.264 ns |  0.234 ns |  0.88 |    0.01 | 0.0764 |     - |     - |     160 B |
|     StructLinq_IFunction |    10 |    41.01 ns |  0.097 ns |  0.086 ns |  0.63 |    0.00 | 0.0650 |     - |     - |     136 B |
|                Hyperlinq |    10 |    46.83 ns |  0.676 ns |  0.599 ns |  0.72 |    0.01 | 0.0459 |     - |     - |      96 B |
|      Hyperlinq_IFunction |    10 |    34.65 ns |  0.173 ns |  0.162 ns |  0.53 |    0.00 | 0.0459 |     - |     - |      96 B |
|           Hyperlinq_SIMD |    10 |    57.10 ns |  0.236 ns |  0.209 ns |  0.87 |    0.01 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_IFunction_SIMD |    10 |    40.00 ns |  0.134 ns |  0.119 ns |  0.61 |    0.00 | 0.0459 |     - |     - |      96 B |
|                          |       |             |           |           |       |         |        |       |       |           |
|                  **ForLoop** |  **1000** | **2,036.90 ns** | **14.971 ns** | **13.271 ns** |  **1.00** |    **0.00** | **4.0207** |     **-** |     **-** |   **8,424 B** |
|              ForeachLoop |  1000 | 2,040.20 ns | 11.289 ns | 10.560 ns |  1.00 |    0.01 | 4.0207 |     - |     - |   8,424 B |
|                     Linq |  1000 | 2,568.46 ns |  7.419 ns |  6.576 ns |  1.26 |    0.01 | 1.9608 |     - |     - |   4,104 B |
|               LinqFaster |  1000 | 2,293.80 ns | 16.436 ns | 15.374 ns |  1.13 |    0.01 | 3.8605 |     - |     - |   8,080 B |
|          LinqFaster_SIMD |  1000 |   747.13 ns | 12.832 ns | 11.375 ns |  0.37 |    0.01 | 3.8605 |     - |     - |   8,080 B |
|                   LinqAF |  1000 | 7,087.20 ns | 11.142 ns |  9.304 ns |  3.48 |    0.02 | 4.0207 |     - |     - |   8,424 B |
|               StructLinq |  1000 | 2,060.17 ns | 18.585 ns | 14.510 ns |  1.01 |    0.01 | 1.9684 |     - |     - |   4,120 B |
|     StructLinq_IFunction |  1000 |   954.36 ns | 10.398 ns |  9.218 ns |  0.47 |    0.00 | 1.9569 |     - |     - |   4,096 B |
|                Hyperlinq |  1000 | 2,064.18 ns |  5.705 ns |  5.336 ns |  1.01 |    0.01 | 1.9341 |     - |     - |   4,056 B |
|      Hyperlinq_IFunction |  1000 |   768.35 ns |  2.737 ns |  2.285 ns |  0.38 |    0.00 | 1.9341 |     - |     - |   4,056 B |
|           Hyperlinq_SIMD |  1000 |   557.10 ns |  4.250 ns |  3.549 ns |  0.27 |    0.00 | 1.9341 |     - |     - |   4,056 B |
| Hyperlinq_IFunction_SIMD |  1000 |   326.12 ns |  1.659 ns |  1.471 ns |  0.16 |    0.00 | 1.9341 |     - |     - |   4,056 B |
