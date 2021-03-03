## List.Int32.ListInt32SelectToList

### Source
[ListInt32SelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32SelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta42](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta42)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                   Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                  **ForLoop** |    **10** |    **67.84 ns** |  **0.496 ns** |  **0.464 ns** |  **1.00** |    **0.00** | **0.1032** |     **-** |     **-** |     **216 B** |
|              ForeachLoop |    10 |    81.47 ns |  0.238 ns |  0.199 ns |  1.20 |    0.01 | 0.1032 |     - |     - |     216 B |
|                     Linq |    10 |    68.24 ns |  0.348 ns |  0.325 ns |  1.01 |    0.01 | 0.0802 |     - |     - |     168 B |
|               LinqFaster |    10 |    60.67 ns |  0.200 ns |  0.177 ns |  0.89 |    0.01 | 0.0917 |     - |     - |     192 B |
|                   LinqAF |    10 |   198.51 ns |  1.033 ns |  0.967 ns |  2.93 |    0.02 | 0.1032 |     - |     - |     216 B |
|               StructLinq |    10 |    57.07 ns |  0.145 ns |  0.128 ns |  0.84 |    0.01 | 0.0764 |     - |     - |     160 B |
|     StructLinq_IFunction |    10 |    42.39 ns |  0.123 ns |  0.109 ns |  0.62 |    0.00 | 0.0650 |     - |     - |     136 B |
|                Hyperlinq |    10 |    47.06 ns |  0.176 ns |  0.156 ns |  0.69 |    0.00 | 0.0459 |     - |     - |      96 B |
|      Hyperlinq_IFunction |    10 |    34.78 ns |  0.145 ns |  0.136 ns |  0.51 |    0.00 | 0.0459 |     - |     - |      96 B |
|           Hyperlinq_SIMD |    10 |    55.65 ns |  0.140 ns |  0.131 ns |  0.82 |    0.01 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_IFunction_SIMD |    10 |    39.70 ns |  0.125 ns |  0.110 ns |  0.58 |    0.00 | 0.0459 |     - |     - |      96 B |
|                          |       |             |           |           |       |         |        |       |       |           |
|                  **ForLoop** |  **1000** | **2,456.16 ns** | **16.451 ns** | **15.388 ns** |  **1.00** |    **0.00** | **4.0207** |     **-** |     **-** |   **8,424 B** |
|              ForeachLoop |  1000 | 3,303.94 ns | 16.724 ns | 14.826 ns |  1.34 |    0.01 | 4.0207 |     - |     - |   8,424 B |
|                     Linq |  1000 | 2,912.52 ns | 10.006 ns |  9.359 ns |  1.19 |    0.01 | 1.9722 |     - |     - |   4,128 B |
|               LinqFaster |  1000 | 3,115.29 ns | 20.740 ns | 18.385 ns |  1.27 |    0.01 | 3.8757 |     - |     - |   8,112 B |
|                   LinqAF |  1000 | 9,006.32 ns | 34.273 ns | 28.620 ns |  3.67 |    0.03 | 4.0131 |     - |     - |   8,424 B |
|               StructLinq |  1000 | 2,058.11 ns |  6.397 ns |  5.342 ns |  0.84 |    0.01 | 1.9684 |     - |     - |   4,120 B |
|     StructLinq_IFunction |  1000 |   937.34 ns |  9.197 ns |  8.603 ns |  0.38 |    0.00 | 1.9569 |     - |     - |   4,096 B |
|                Hyperlinq |  1000 | 1,790.31 ns |  4.335 ns |  3.843 ns |  0.73 |    0.00 | 1.9341 |     - |     - |   4,056 B |
|      Hyperlinq_IFunction |  1000 |   811.08 ns |  1.650 ns |  1.377 ns |  0.33 |    0.00 | 1.9341 |     - |     - |   4,056 B |
|           Hyperlinq_SIMD |  1000 |   556.57 ns |  1.999 ns |  1.772 ns |  0.23 |    0.00 | 1.9341 |     - |     - |   4,056 B |
| Hyperlinq_IFunction_SIMD |  1000 |   320.07 ns |  1.292 ns |  1.145 ns |  0.13 |    0.00 | 1.9341 |     - |     - |   4,056 B |
