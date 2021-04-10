## List.Int32.ListInt32SelectToList

### Source
[ListInt32SelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32SelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                   Method | Count |        Mean |     Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|-----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                  **ForLoop** |    **10** |    **77.36 ns** |  **0.464 ns** |   **0.411 ns** |    **77.30 ns** |  **1.00** |    **0.00** | **0.1032** |     **-** |     **-** |     **216 B** |
|              ForeachLoop |    10 |    87.92 ns |  0.569 ns |   0.532 ns |    87.83 ns |  1.14 |    0.01 | 0.1032 |     - |     - |     216 B |
|                     Linq |    10 |    77.60 ns |  1.604 ns |   2.195 ns |    78.02 ns |  1.00 |    0.04 | 0.0802 |     - |     - |     168 B |
|               LinqFaster |    10 |    66.53 ns |  0.420 ns |   0.351 ns |    66.51 ns |  0.86 |    0.00 | 0.0918 |     - |     - |     192 B |
|                   LinqAF |    10 |   207.17 ns |  1.039 ns |   0.921 ns |   207.05 ns |  2.68 |    0.02 | 0.1032 |     - |     - |     216 B |
|               StructLinq |    10 |    67.56 ns |  1.384 ns |   1.941 ns |    68.23 ns |  0.86 |    0.03 | 0.0764 |     - |     - |     160 B |
|     StructLinq_IFunction |    10 |    46.06 ns |  0.337 ns |   0.299 ns |    46.10 ns |  0.60 |    0.01 | 0.0650 |     - |     - |     136 B |
|                Hyperlinq |    10 |    54.46 ns |  1.083 ns |   0.960 ns |    54.63 ns |  0.70 |    0.01 | 0.0459 |     - |     - |      96 B |
|      Hyperlinq_IFunction |    10 |    39.54 ns |  0.180 ns |   0.168 ns |    39.53 ns |  0.51 |    0.00 | 0.0459 |     - |     - |      96 B |
|           Hyperlinq_SIMD |    10 |    59.64 ns |  0.321 ns |   0.268 ns |    59.57 ns |  0.77 |    0.01 | 0.0459 |     - |     - |      96 B |
| Hyperlinq_IFunction_SIMD |    10 |    45.53 ns |  0.187 ns |   0.156 ns |    45.53 ns |  0.59 |    0.00 | 0.0459 |     - |     - |      96 B |
|                          |       |             |           |            |             |       |         |        |       |       |           |
|                  **ForLoop** |  **1000** | **2,664.89 ns** | **20.461 ns** |  **17.085 ns** | **2,664.21 ns** |  **1.00** |    **0.00** | **4.0207** |     **-** |     **-** |   **8,424 B** |
|              ForeachLoop |  1000 | 3,751.99 ns | 36.779 ns |  28.715 ns | 3,750.48 ns |  1.41 |    0.01 | 4.0207 |     - |     - |   8,424 B |
|                     Linq |  1000 | 3,063.21 ns | 60.988 ns | 150.747 ns | 2,969.61 ns |  1.12 |    0.03 | 1.9722 |     - |     - |   4,128 B |
|               LinqFaster |  1000 | 3,246.43 ns | 20.995 ns |  30.110 ns | 3,242.95 ns |  1.21 |    0.01 | 3.8757 |     - |     - |   8,112 B |
|                   LinqAF |  1000 | 9,945.73 ns | 68.990 ns |  64.534 ns | 9,940.14 ns |  3.73 |    0.04 | 4.0131 |     - |     - |   8,424 B |
|               StructLinq |  1000 | 2,163.24 ns | 21.555 ns |  18.000 ns | 2,159.35 ns |  0.81 |    0.01 | 1.9684 |     - |     - |   4,120 B |
|     StructLinq_IFunction |  1000 | 1,007.42 ns |  8.467 ns |   7.506 ns | 1,006.49 ns |  0.38 |    0.00 | 1.9569 |     - |     - |   4,096 B |
|                Hyperlinq |  1000 | 2,343.25 ns | 45.590 ns |  59.279 ns | 2,365.93 ns |  0.87 |    0.03 | 1.9341 |     - |     - |   4,056 B |
|      Hyperlinq_IFunction |  1000 |   854.13 ns |  3.936 ns |   3.489 ns |   854.11 ns |  0.32 |    0.00 | 1.9341 |     - |     - |   4,056 B |
|           Hyperlinq_SIMD |  1000 |   590.79 ns |  4.038 ns |   3.777 ns |   591.85 ns |  0.22 |    0.00 | 1.9341 |     - |     - |   4,056 B |
| Hyperlinq_IFunction_SIMD |  1000 |   384.12 ns | 18.127 ns |  51.424 ns |   357.05 ns |  0.14 |    0.01 | 1.9341 |     - |     - |   4,056 B |
