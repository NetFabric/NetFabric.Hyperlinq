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
  .NET 6.0 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|                   Method |      Job |  Runtime | Count |        Mean |      Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |--------- |--------- |------ |------------:|-----------:|-----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                  **ForLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |    **66.42 ns** |   **0.451 ns** |   **0.400 ns** |    **66.32 ns** |  **1.00** |    **0.00** | **0.1032** |     **-** |     **-** |     **216 B** |
|              ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |    66.58 ns |   0.604 ns |   0.535 ns |    66.52 ns |  1.00 |    0.01 | 0.1032 |     - |     - |     216 B |
|                     Linq | .NET 5.0 | .NET 5.0 |    10 |    71.23 ns |   1.471 ns |   1.963 ns |    71.85 ns |  1.06 |    0.04 | 0.0688 |     - |     - |     144 B |
|               LinqFaster | .NET 5.0 | .NET 5.0 |    10 |    56.12 ns |   0.417 ns |   0.370 ns |    56.06 ns |  0.84 |    0.01 | 0.0763 |     - |     - |     160 B |
|          LinqFaster_SIMD | .NET 5.0 | .NET 5.0 |    10 |    44.96 ns |   0.423 ns |   0.395 ns |    44.89 ns |  0.68 |    0.01 | 0.0764 |     - |     - |     160 B |
|                   LinqAF | .NET 5.0 | .NET 5.0 |    10 |   180.75 ns |   3.614 ns |   4.571 ns |   182.09 ns |  2.70 |    0.09 | 0.1032 |     - |     - |     216 B |
|               StructLinq | .NET 5.0 | .NET 5.0 |    10 |    62.33 ns |   0.254 ns |   0.237 ns |    62.31 ns |  0.94 |    0.01 | 0.0763 |     - |     - |     160 B |
|     StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    43.49 ns |   0.314 ns |   0.263 ns |    43.43 ns |  0.65 |    0.01 | 0.0650 |     - |     - |     136 B |
|                Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    48.64 ns |   0.945 ns |   1.579 ns |    47.92 ns |  0.75 |    0.03 | 0.0459 |     - |     - |      96 B |
|      Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    44.05 ns |   0.325 ns |   0.271 ns |    44.07 ns |  0.66 |    0.00 | 0.0459 |     - |     - |      96 B |
|           Hyperlinq_SIMD | .NET 5.0 | .NET 5.0 |    10 |    58.31 ns |   0.422 ns |   0.352 ns |    58.19 ns |  0.88 |    0.01 | 0.0459 |     - |     - |      96 B |
| Hyperlinq_IFunction_SIMD | .NET 5.0 | .NET 5.0 |    10 |    44.35 ns |   0.170 ns |   0.142 ns |    44.31 ns |  0.67 |    0.00 | 0.0458 |     - |     - |      96 B |
|                          |          |          |       |             |            |            |             |       |         |        |       |       |           |
|                  ForLoop | .NET 6.0 | .NET 6.0 |    10 |    73.62 ns |   0.452 ns |   0.401 ns |    73.56 ns |  1.00 |    0.00 | 0.1031 |     - |     - |     216 B |
|              ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |    79.38 ns |   1.660 ns |   2.272 ns |    79.82 ns |  1.07 |    0.04 | 0.1032 |     - |     - |     216 B |
|                     Linq | .NET 6.0 | .NET 6.0 |    10 |    64.94 ns |   0.324 ns |   0.271 ns |    64.90 ns |  0.88 |    0.01 | 0.0687 |     - |     - |     144 B |
|               LinqFaster | .NET 6.0 | .NET 6.0 |    10 |    56.64 ns |   1.206 ns |   2.818 ns |    54.83 ns |  0.81 |    0.03 | 0.0765 |     - |     - |     160 B |
|          LinqFaster_SIMD | .NET 6.0 | .NET 6.0 |    10 |    67.11 ns |   0.462 ns |   0.432 ns |    67.17 ns |  0.91 |    0.01 | 0.0763 |     - |     - |     160 B |
|                   LinqAF | .NET 6.0 | .NET 6.0 |    10 |   153.13 ns |   0.841 ns |   0.745 ns |   153.07 ns |  2.08 |    0.01 | 0.1032 |     - |     - |     216 B |
|               StructLinq | .NET 6.0 | .NET 6.0 |    10 |    66.13 ns |   0.232 ns |   0.206 ns |    66.07 ns |  0.90 |    0.00 | 0.0763 |     - |     - |     160 B |
|     StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    45.89 ns |   0.989 ns |   2.725 ns |    44.80 ns |  0.62 |    0.04 | 0.0650 |     - |     - |     136 B |
|                Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    48.56 ns |   0.195 ns |   0.163 ns |    48.59 ns |  0.66 |    0.00 | 0.0459 |     - |     - |      96 B |
|      Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    38.97 ns |   0.192 ns |   0.170 ns |    38.94 ns |  0.53 |    0.00 | 0.0458 |     - |     - |      96 B |
|           Hyperlinq_SIMD | .NET 6.0 | .NET 6.0 |    10 |    57.33 ns |   1.216 ns |   2.371 ns |    55.95 ns |  0.82 |    0.02 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_IFunction_SIMD | .NET 6.0 | .NET 6.0 |    10 |    42.88 ns |   0.163 ns |   0.152 ns |    42.91 ns |  0.58 |    0.00 | 0.0458 |     - |     - |      96 B |
|                          |          |          |       |             |            |            |             |       |         |        |       |       |           |
|                  **ForLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** | **2,562.72 ns** |  **16.342 ns** |  **15.286 ns** | **2,563.39 ns** |  **1.00** |    **0.00** | **4.0207** |     **-** |     **-** |   **8,424 B** |
|              ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 | 2,279.10 ns |  28.094 ns |  24.905 ns | 2,275.66 ns |  0.89 |    0.01 | 4.0207 |     - |     - |   8,424 B |
|                     Linq | .NET 5.0 | .NET 5.0 |  1000 | 2,436.32 ns |  15.595 ns |  13.825 ns | 2,432.17 ns |  0.95 |    0.01 | 1.9608 |     - |     - |   4,104 B |
|               LinqFaster | .NET 5.0 | .NET 5.0 |  1000 | 2,480.00 ns |  49.668 ns | 130.845 ns | 2,415.55 ns |  0.95 |    0.04 | 3.8605 |     - |     - |   8,080 B |
|          LinqFaster_SIMD | .NET 5.0 | .NET 5.0 |  1000 |   806.20 ns |   6.632 ns |  16.016 ns |   806.62 ns |  0.32 |    0.01 | 3.8605 |     - |     - |   8,080 B |
|                   LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 7,803.78 ns | 152.856 ns | 169.899 ns | 7,855.52 ns |  3.03 |    0.08 | 4.0207 |     - |     - |   8,424 B |
|               StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 2,097.59 ns |  11.579 ns |  10.831 ns | 2,094.12 ns |  0.82 |    0.01 | 1.9684 |     - |     - |   4,120 B |
|     StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |   987.26 ns |  18.356 ns |  17.170 ns |   982.14 ns |  0.39 |    0.01 | 1.9569 |     - |     - |   4,096 B |
|                Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 | 1,917.67 ns |  38.430 ns |  98.511 ns | 1,861.46 ns |  0.73 |    0.03 | 1.9341 |     - |     - |   4,056 B |
|      Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |   844.67 ns |   7.693 ns |   6.424 ns |   845.90 ns |  0.33 |    0.00 | 1.9341 |     - |     - |   4,056 B |
|           Hyperlinq_SIMD | .NET 5.0 | .NET 5.0 |  1000 |   606.07 ns |  13.026 ns |  38.407 ns |   587.49 ns |  0.26 |    0.01 | 1.9341 |     - |     - |   4,056 B |
| Hyperlinq_IFunction_SIMD | .NET 5.0 | .NET 5.0 |  1000 |   364.85 ns |   7.343 ns |  20.951 ns |   356.58 ns |  0.14 |    0.01 | 1.9341 |     - |     - |   4,056 B |
|                          |          |          |       |             |            |            |             |       |         |        |       |       |           |
|                  ForLoop | .NET 6.0 | .NET 6.0 |  1000 | 2,159.68 ns |  28.081 ns |  23.449 ns | 2,155.33 ns |  1.00 |    0.00 | 4.0207 |     - |     - |   8,424 B |
|              ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 | 2,425.60 ns |  23.628 ns |  18.447 ns | 2,430.11 ns |  1.12 |    0.01 | 4.0207 |     - |     - |   8,424 B |
|                     Linq | .NET 6.0 | .NET 6.0 |  1000 | 2,729.14 ns |  12.545 ns |  10.476 ns | 2,732.40 ns |  1.26 |    0.02 | 1.9608 |     - |     - |   4,104 B |
|               LinqFaster | .NET 6.0 | .NET 6.0 |  1000 | 2,135.36 ns |  34.017 ns |  31.820 ns | 2,121.32 ns |  0.99 |    0.01 | 3.8605 |     - |     - |   8,080 B |
|          LinqFaster_SIMD | .NET 6.0 | .NET 6.0 |  1000 | 2,543.23 ns |  37.710 ns |  35.274 ns | 2,524.14 ns |  1.18 |    0.02 | 3.8605 |     - |     - |   8,080 B |
|                   LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 7,520.76 ns | 147.468 ns | 144.834 ns | 7,562.75 ns |  3.48 |    0.07 | 4.0207 |     - |     - |   8,424 B |
|               StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 2,402.01 ns |  14.139 ns |  12.534 ns | 2,402.38 ns |  1.11 |    0.01 | 1.9684 |     - |     - |   4,120 B |
|     StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |   986.80 ns |  14.793 ns |  13.114 ns |   980.18 ns |  0.46 |    0.01 | 1.9569 |     - |     - |   4,096 B |
|                Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 | 2,308.70 ns |  12.458 ns |  11.044 ns | 2,308.30 ns |  1.07 |    0.01 | 1.9341 |     - |     - |   4,056 B |
|      Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |   852.23 ns |   4.084 ns |   3.410 ns |   852.67 ns |  0.39 |    0.00 | 1.9341 |     - |     - |   4,056 B |
|           Hyperlinq_SIMD | .NET 6.0 | .NET 6.0 |  1000 | 2,275.50 ns |  10.341 ns |   9.167 ns | 2,273.67 ns |  1.05 |    0.01 | 1.9341 |     - |     - |   4,056 B |
| Hyperlinq_IFunction_SIMD | .NET 6.0 | .NET 6.0 |  1000 | 1,362.21 ns |  27.197 ns |  77.596 ns | 1,360.64 ns |  0.65 |    0.02 | 1.9341 |     - |     - |   4,056 B |
