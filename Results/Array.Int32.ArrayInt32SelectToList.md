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

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                   Method | Count |        Mean |      Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|-----------:|-----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                  **ForLoop** |    **10** |    **68.65 ns** |   **0.556 ns** |   **0.493 ns** |    **68.64 ns** |  **1.00** |    **0.00** | **0.1032** |     **-** |     **-** |     **216 B** |
|              ForeachLoop |    10 |    71.85 ns |   1.506 ns |   4.321 ns |    69.24 ns |  1.04 |    0.04 | 0.1032 |     - |     - |     216 B |
|                     Linq |    10 |    68.88 ns |   0.440 ns |   0.390 ns |    68.85 ns |  1.00 |    0.01 | 0.0687 |     - |     - |     144 B |
|               LinqFaster |    10 |    65.30 ns |   1.379 ns |   1.744 ns |    66.07 ns |  0.94 |    0.03 | 0.0764 |     - |     - |     160 B |
|          LinqFaster_SIMD |    10 |    48.23 ns |   0.397 ns |   0.352 ns |    48.12 ns |  0.70 |    0.01 | 0.0765 |     - |     - |     160 B |
|                   LinqAF |    10 |   170.63 ns |   1.279 ns |   1.134 ns |   170.48 ns |  2.49 |    0.03 | 0.1032 |     - |     - |     216 B |
|               StructLinq |    10 |    71.84 ns |   1.425 ns |   2.089 ns |    72.47 ns |  1.03 |    0.04 | 0.0764 |     - |     - |     160 B |
|     StructLinq_IFunction |    10 |    44.96 ns |   0.248 ns |   0.220 ns |    44.93 ns |  0.65 |    0.01 | 0.0650 |     - |     - |     136 B |
|                Hyperlinq |    10 |    49.95 ns |   0.294 ns |   0.275 ns |    49.89 ns |  0.73 |    0.01 | 0.0459 |     - |     - |      96 B |
|      Hyperlinq_IFunction |    10 |    40.18 ns |   0.576 ns |   1.082 ns |    39.84 ns |  0.59 |    0.03 | 0.0459 |     - |     - |      96 B |
|           Hyperlinq_SIMD |    10 |    63.31 ns |   1.342 ns |   3.342 ns |    61.61 ns |  0.89 |    0.03 | 0.0459 |     - |     - |      96 B |
| Hyperlinq_IFunction_SIMD |    10 |    45.97 ns |   0.274 ns |   0.243 ns |    45.92 ns |  0.67 |    0.01 | 0.0459 |     - |     - |      96 B |
|                          |       |             |            |            |             |       |         |        |       |       |           |
|                  **ForLoop** |  **1000** | **2,326.29 ns** |  **14.061 ns** |  **13.152 ns** | **2,327.45 ns** |  **1.00** |    **0.00** | **4.0207** |     **-** |     **-** |   **8,424 B** |
|              ForeachLoop |  1000 | 2,656.69 ns |  21.758 ns |  20.352 ns | 2,666.18 ns |  1.14 |    0.01 | 4.0207 |     - |     - |   8,424 B |
|                     Linq |  1000 | 2,454.49 ns |  20.083 ns |  17.803 ns | 2,449.25 ns |  1.06 |    0.01 | 1.9608 |     - |     - |   4,104 B |
|               LinqFaster |  1000 | 2,436.18 ns |  22.317 ns |  18.636 ns | 2,433.02 ns |  1.05 |    0.01 | 3.8605 |     - |     - |   8,080 B |
|          LinqFaster_SIMD |  1000 |   831.16 ns |  15.882 ns |  16.310 ns |   831.34 ns |  0.36 |    0.01 | 3.8605 |     - |     - |   8,080 B |
|                   LinqAF |  1000 | 7,823.62 ns | 156.189 ns | 365.088 ns | 7,749.06 ns |  3.48 |    0.11 | 4.0207 |     - |     - |   8,424 B |
|               StructLinq |  1000 | 2,169.12 ns |  13.355 ns |  11.839 ns | 2,168.79 ns |  0.93 |    0.01 | 1.9684 |     - |     - |   4,120 B |
|     StructLinq_IFunction |  1000 | 1,012.51 ns |  10.141 ns |   8.990 ns | 1,009.29 ns |  0.44 |    0.01 | 1.9569 |     - |     - |   4,096 B |
|                Hyperlinq |  1000 | 2,246.81 ns |  44.623 ns | 115.981 ns | 2,162.97 ns |  0.95 |    0.04 | 1.9341 |     - |     - |   4,056 B |
|      Hyperlinq_IFunction |  1000 |   908.03 ns |  20.986 ns |  61.878 ns |   866.90 ns |  0.38 |    0.02 | 1.9341 |     - |     - |   4,056 B |
|           Hyperlinq_SIMD |  1000 |   599.76 ns |   6.063 ns |   5.374 ns |   598.84 ns |  0.26 |    0.00 | 1.9341 |     - |     - |   4,056 B |
| Hyperlinq_IFunction_SIMD |  1000 |   363.99 ns |   4.094 ns |   3.830 ns |   363.61 ns |  0.16 |    0.00 | 1.9341 |     - |     - |   4,056 B |
