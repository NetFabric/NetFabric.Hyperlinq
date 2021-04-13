## Array.Int32.ArrayInt32SelectToList

### Source
[ArrayInt32SelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT

EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  

```
|                   Method |    Job |  Runtime | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------- |--------- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|                  **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |     **58.67 ns** |   **0.435 ns** |   **0.385 ns** |   **1.00** |    **0.00** |  **0.1032** |     **-** |     **-** |     **216 B** |
|              ForeachLoop | .NET 5 | .NET 5.0 |    10 |     58.33 ns |   0.408 ns |   0.382 ns |   0.99 |    0.01 |  0.1032 |     - |     - |     216 B |
|                     Linq | .NET 5 | .NET 5.0 |    10 |     65.30 ns |   1.173 ns |   0.980 ns |   1.11 |    0.02 |  0.0687 |     - |     - |     144 B |
|               LinqFaster | .NET 5 | .NET 5.0 |    10 |     53.75 ns |   0.237 ns |   0.222 ns |   0.92 |    0.01 |  0.0765 |     - |     - |     160 B |
|          LinqFaster_SIMD | .NET 5 | .NET 5.0 |    10 |     46.07 ns |   0.357 ns |   0.333 ns |   0.79 |    0.01 |  0.0765 |     - |     - |     160 B |
|                   LinqAF | .NET 5 | .NET 5.0 |    10 |    161.48 ns |   0.940 ns |   0.880 ns |   2.75 |    0.02 |  0.1032 |     - |     - |     216 B |
|            LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 36,190.97 ns | 176.608 ns | 156.558 ns | 616.93 |    4.74 | 13.3057 |     - |     - |  27,900 B |
|                  Streams | .NET 5 | .NET 5.0 |    10 |    330.07 ns |   2.227 ns |   2.083 ns |   5.62 |    0.05 |  0.2904 |     - |     - |     608 B |
|               StructLinq | .NET 5 | .NET 5.0 |    10 |     57.60 ns |   0.806 ns |   0.754 ns |   0.98 |    0.01 |  0.0764 |     - |     - |     160 B |
|     StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |     43.27 ns |   0.153 ns |   0.128 ns |   0.74 |    0.00 |  0.0650 |     - |     - |     136 B |
|                Hyperlinq | .NET 5 | .NET 5.0 |    10 |     47.93 ns |   0.548 ns |   0.486 ns |   0.82 |    0.01 |  0.0458 |     - |     - |      96 B |
|      Hyperlinq_IFunction | .NET 5 | .NET 5.0 |    10 |     38.47 ns |   0.489 ns |   0.457 ns |   0.66 |    0.01 |  0.0459 |     - |     - |      96 B |
|           Hyperlinq_SIMD | .NET 5 | .NET 5.0 |    10 |     58.59 ns |   0.507 ns |   0.423 ns |   1.00 |    0.01 |  0.0459 |     - |     - |      96 B |
| Hyperlinq_IFunction_SIMD | .NET 5 | .NET 5.0 |    10 |     45.01 ns |   0.326 ns |   0.304 ns |   0.77 |    0.01 |  0.0459 |     - |     - |      96 B |
|                          |        |          |       |              |            |            |        |         |         |       |       |           |
|                  ForLoop | .NET 6 | .NET 6.0 |    10 |     68.58 ns |   0.618 ns |   0.516 ns |   1.00 |    0.00 |  0.1032 |     - |     - |     216 B |
|              ForeachLoop | .NET 6 | .NET 6.0 |    10 |     68.37 ns |   0.588 ns |   0.459 ns |   1.00 |    0.01 |  0.1032 |     - |     - |     216 B |
|                     Linq | .NET 6 | .NET 6.0 |    10 |     61.97 ns |   0.435 ns |   0.385 ns |   0.90 |    0.01 |  0.0688 |     - |     - |     144 B |
|               LinqFaster | .NET 6 | .NET 6.0 |    10 |     57.27 ns |   0.501 ns |   0.391 ns |   0.83 |    0.01 |  0.0764 |     - |     - |     160 B |
|          LinqFaster_SIMD | .NET 6 | .NET 6.0 |    10 |     57.06 ns |   0.347 ns |   0.308 ns |   0.83 |    0.01 |  0.0764 |     - |     - |     160 B |
|                   LinqAF | .NET 6 | .NET 6.0 |    10 |    157.50 ns |   0.704 ns |   0.624 ns |   2.30 |    0.02 |  0.1032 |     - |     - |     216 B |
|            LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 34,356.67 ns | 157.875 ns | 147.676 ns | 501.14 |    3.96 | 13.1836 |     - |     - |  27,652 B |
|                  Streams | .NET 6 | .NET 6.0 |    10 |    334.61 ns |   3.676 ns |   3.439 ns |   4.87 |    0.06 |  0.2904 |     - |     - |     608 B |
|               StructLinq | .NET 6 | .NET 6.0 |    10 |     64.90 ns |   0.544 ns |   0.482 ns |   0.95 |    0.01 |  0.0764 |     - |     - |     160 B |
|     StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |     43.80 ns |   0.377 ns |   0.352 ns |   0.64 |    0.01 |  0.0650 |     - |     - |     136 B |
|                Hyperlinq | .NET 6 | .NET 6.0 |    10 |     46.98 ns |   0.880 ns |   0.823 ns |   0.69 |    0.00 |  0.0459 |     - |     - |      96 B |
|      Hyperlinq_IFunction | .NET 6 | .NET 6.0 |    10 |     38.53 ns |   0.164 ns |   0.137 ns |   0.56 |    0.00 |  0.0459 |     - |     - |      96 B |
|           Hyperlinq_SIMD | .NET 6 | .NET 6.0 |    10 |     54.70 ns |   0.441 ns |   0.368 ns |   0.80 |    0.01 |  0.0459 |     - |     - |      96 B |
| Hyperlinq_IFunction_SIMD | .NET 6 | .NET 6.0 |    10 |     40.76 ns |   0.269 ns |   0.251 ns |   0.59 |    0.01 |  0.0459 |     - |     - |      96 B |
|                          |        |          |       |              |            |            |        |         |         |       |       |           |
|                  **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** |  **2,085.11 ns** |  **19.842 ns** |  **18.560 ns** |   **1.00** |    **0.00** |  **4.0207** |     **-** |     **-** |   **8,424 B** |
|              ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  2,041.26 ns |  11.257 ns |  10.530 ns |   0.98 |    0.01 |  4.0207 |     - |     - |   8,424 B |
|                     Linq | .NET 5 | .NET 5.0 |  1000 |  2,867.05 ns |  27.124 ns |  25.371 ns |   1.38 |    0.02 |  1.9608 |     - |     - |   4,104 B |
|               LinqFaster | .NET 5 | .NET 5.0 |  1000 |  2,099.58 ns |   9.482 ns |   8.869 ns |   1.01 |    0.01 |  3.8605 |     - |     - |   8,080 B |
|          LinqFaster_SIMD | .NET 5 | .NET 5.0 |  1000 |    783.69 ns |  11.710 ns |  10.954 ns |   0.38 |    0.01 |  3.8605 |     - |     - |   8,080 B |
|                   LinqAF | .NET 5 | .NET 5.0 |  1000 |  6,823.53 ns |  22.253 ns |  19.726 ns |   3.27 |    0.03 |  4.0207 |     - |     - |   8,424 B |
|            LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 39,252.73 ns | 194.656 ns | 172.557 ns |  18.83 |    0.22 | 17.0898 |     - |     - |  35,823 B |
|                  Streams | .NET 5 | .NET 5.0 |  1000 | 10,357.92 ns |  55.276 ns |  49.001 ns |   4.97 |    0.06 |  4.1962 |     - |     - |   8,816 B |
|               StructLinq | .NET 5 | .NET 5.0 |  1000 |  2,066.99 ns |  14.184 ns |  13.268 ns |   0.99 |    0.01 |  1.9684 |     - |     - |   4,120 B |
|     StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  1,034.64 ns |   7.197 ns |   6.732 ns |   0.50 |    0.01 |  1.9569 |     - |     - |   4,096 B |
|                Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  2,091.86 ns |  24.434 ns |  22.856 ns |   1.00 |    0.01 |  1.9341 |     - |     - |   4,056 B |
|      Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |    797.54 ns |   7.024 ns |   5.865 ns |   0.38 |    0.01 |  1.9341 |     - |     - |   4,056 B |
|           Hyperlinq_SIMD | .NET 5 | .NET 5.0 |  1000 |    538.13 ns |   2.447 ns |   2.169 ns |   0.26 |    0.00 |  1.9341 |     - |     - |   4,056 B |
| Hyperlinq_IFunction_SIMD | .NET 5 | .NET 5.0 |  1000 |    347.98 ns |   2.129 ns |   1.887 ns |   0.17 |    0.00 |  1.9341 |     - |     - |   4,056 B |
|                          |        |          |       |              |            |            |        |         |         |       |       |           |
|                  ForLoop | .NET 6 | .NET 6.0 |  1000 |  2,120.41 ns |  21.552 ns |  19.105 ns |   1.00 |    0.00 |  4.0207 |     - |     - |   8,424 B |
|              ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  2,130.26 ns |  22.523 ns |  19.966 ns |   1.00 |    0.01 |  4.0207 |     - |     - |   8,424 B |
|                     Linq | .NET 6 | .NET 6.0 |  1000 |  2,089.58 ns |  11.921 ns |   9.955 ns |   0.99 |    0.01 |  1.9608 |     - |     - |   4,104 B |
|               LinqFaster | .NET 6 | .NET 6.0 |  1000 |  2,670.06 ns |  16.069 ns |  15.031 ns |   1.26 |    0.01 |  3.8605 |     - |     - |   8,080 B |
|          LinqFaster_SIMD | .NET 6 | .NET 6.0 |  1000 |  2,513.49 ns |  21.578 ns |  18.019 ns |   1.19 |    0.01 |  3.8605 |     - |     - |   8,080 B |
|                   LinqAF | .NET 6 | .NET 6.0 |  1000 |  5,959.07 ns |  16.984 ns |  15.056 ns |   2.81 |    0.03 |  4.0207 |     - |     - |   8,424 B |
|            LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 37,112.45 ns | 155.265 ns | 145.235 ns |  17.51 |    0.15 | 16.9678 |     - |     - |  35,575 B |
|                  Streams | .NET 6 | .NET 6.0 |  1000 | 11,001.26 ns |  58.749 ns |  45.868 ns |   5.19 |    0.06 |  4.1962 |     - |     - |   8,816 B |
|               StructLinq | .NET 6 | .NET 6.0 |  1000 |  2,371.62 ns |  16.388 ns |  15.330 ns |   1.12 |    0.01 |  1.9684 |     - |     - |   4,120 B |
|     StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  1,036.97 ns |   6.624 ns |   6.196 ns |   0.49 |    0.01 |  1.9569 |     - |     - |   4,096 B |
|                Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  2,099.08 ns |   9.281 ns |   8.681 ns |   0.99 |    0.01 |  1.9341 |     - |     - |   4,056 B |
|      Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |    925.69 ns |   5.359 ns |   5.013 ns |   0.44 |    0.00 |  1.9341 |     - |     - |   4,056 B |
|           Hyperlinq_SIMD | .NET 6 | .NET 6.0 |  1000 |  2,175.91 ns |  23.341 ns |  21.833 ns |   1.03 |    0.01 |  1.9341 |     - |     - |   4,056 B |
| Hyperlinq_IFunction_SIMD | .NET 6 | .NET 6.0 |  1000 |  1,285.81 ns |   6.242 ns |   5.534 ns |   0.61 |    0.01 |  1.9341 |     - |     - |   4,056 B |
