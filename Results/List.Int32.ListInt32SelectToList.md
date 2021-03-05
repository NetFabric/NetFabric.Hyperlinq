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

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                   Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                  **ForLoop** |    **10** |    **67.91 ns** |  **0.217 ns** |  **0.203 ns** |  **1.00** |    **0.00** | **0.1032** |     **-** |     **-** |     **216 B** |
|              ForeachLoop |    10 |    85.08 ns |  0.390 ns |  0.365 ns |  1.25 |    0.00 | 0.1031 |     - |     - |     216 B |
|                     Linq |    10 |    66.96 ns |  0.185 ns |  0.173 ns |  0.99 |    0.00 | 0.0802 |     - |     - |     168 B |
|               LinqFaster |    10 |    61.18 ns |  0.181 ns |  0.160 ns |  0.90 |    0.00 | 0.0917 |     - |     - |     192 B |
|                   LinqAF |    10 |   199.30 ns |  0.525 ns |  0.466 ns |  2.93 |    0.01 | 0.1032 |     - |     - |     216 B |
|               StructLinq |    10 |    60.56 ns |  0.193 ns |  0.171 ns |  0.89 |    0.00 | 0.0764 |     - |     - |     160 B |
|     StructLinq_IFunction |    10 |    42.40 ns |  0.143 ns |  0.127 ns |  0.62 |    0.00 | 0.0650 |     - |     - |     136 B |
|                Hyperlinq |    10 |    45.79 ns |  0.137 ns |  0.122 ns |  0.67 |    0.00 | 0.0459 |     - |     - |      96 B |
|      Hyperlinq_IFunction |    10 |    34.81 ns |  0.081 ns |  0.072 ns |  0.51 |    0.00 | 0.0459 |     - |     - |      96 B |
|           Hyperlinq_SIMD |    10 |    57.00 ns |  0.264 ns |  0.234 ns |  0.84 |    0.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_IFunction_SIMD |    10 |    40.07 ns |  0.123 ns |  0.102 ns |  0.59 |    0.00 | 0.0458 |     - |     - |      96 B |
|                          |       |             |           |           |       |         |        |       |       |           |
|                  **ForLoop** |  **1000** | **2,232.17 ns** | **13.883 ns** | **12.986 ns** |  **1.00** |    **0.00** | **4.0207** |     **-** |     **-** |   **8,424 B** |
|              ForeachLoop |  1000 | 3,327.96 ns | 14.905 ns | 13.213 ns |  1.49 |    0.01 | 4.0207 |     - |     - |   8,424 B |
|                     Linq |  1000 | 2,776.96 ns |  8.765 ns |  6.843 ns |  1.24 |    0.01 | 1.9722 |     - |     - |   4,128 B |
|               LinqFaster |  1000 | 3,040.11 ns | 13.259 ns | 11.754 ns |  1.36 |    0.01 | 3.8757 |     - |     - |   8,112 B |
|                   LinqAF |  1000 | 8,705.74 ns | 24.909 ns | 23.299 ns |  3.90 |    0.02 | 4.0131 |     - |     - |   8,424 B |
|               StructLinq |  1000 | 2,064.61 ns |  5.165 ns |  4.313 ns |  0.92 |    0.01 | 1.9684 |     - |     - |   4,120 B |
|     StructLinq_IFunction |  1000 |   948.04 ns |  7.845 ns |  7.338 ns |  0.42 |    0.00 | 1.9569 |     - |     - |   4,096 B |
|                Hyperlinq |  1000 | 2,053.26 ns |  4.691 ns |  4.158 ns |  0.92 |    0.01 | 1.9341 |     - |     - |   4,056 B |
|      Hyperlinq_IFunction |  1000 |   789.87 ns |  1.514 ns |  1.416 ns |  0.35 |    0.00 | 1.9341 |     - |     - |   4,056 B |
|           Hyperlinq_SIMD |  1000 |   546.27 ns |  2.127 ns |  1.886 ns |  0.24 |    0.00 | 1.9341 |     - |     - |   4,056 B |
| Hyperlinq_IFunction_SIMD |  1000 |   325.01 ns |  1.117 ns |  0.872 ns |  0.15 |    0.00 | 1.9341 |     - |     - |   4,056 B |
