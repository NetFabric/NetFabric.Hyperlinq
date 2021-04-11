## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

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
|                    Method |      Job |  Runtime | Start | Count |        Mean |     Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |--------- |--------- |------ |------ |------------:|----------:|-----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|        **ValueLinq_Standard** | **.NET 5.0** | **.NET 5.0** |     **0** |    **10** |    **76.93 ns** |  **1.582 ns** |   **1.553 ns** |    **76.58 ns** |  **1.11** |    **0.03** | **0.0459** |     **-** |     **-** |      **96 B** |
|           ValueLinq_Stack | .NET 5.0 | .NET 5.0 |     0 |    10 |    71.28 ns |  1.034 ns |   0.917 ns |    71.15 ns |  1.03 |    0.01 | 0.0459 |     - |     - |      96 B |
| ValueLinq_SharedPool_Push | .NET 5.0 | .NET 5.0 |     0 |    10 |   180.88 ns |  0.837 ns |   0.699 ns |   180.91 ns |  2.61 |    0.05 | 0.0458 |     - |     - |      96 B |
| ValueLinq_SharedPool_Pull | .NET 5.0 | .NET 5.0 |     0 |    10 |   187.90 ns |  1.474 ns |   1.231 ns |   187.64 ns |  2.71 |    0.04 | 0.0458 |     - |     - |      96 B |
|                   ForLoop | .NET 5.0 | .NET 5.0 |     0 |    10 |    69.30 ns |  1.163 ns |   1.087 ns |    68.70 ns |  1.00 |    0.00 | 0.1032 |     - |     - |     216 B |
|               ForeachLoop | .NET 5.0 | .NET 5.0 |     0 |    10 |   127.86 ns |  2.187 ns |   2.148 ns |   126.88 ns |  1.84 |    0.04 | 0.1297 |     - |     - |     272 B |
|                      Linq | .NET 5.0 | .NET 5.0 |     0 |    10 |    42.93 ns |  0.461 ns |   0.385 ns |    42.94 ns |  0.62 |    0.01 | 0.0650 |     - |     - |     136 B |
|                LinqFaster | .NET 5.0 | .NET 5.0 |     0 |    10 |    39.34 ns |  0.656 ns |   0.614 ns |    39.17 ns |  0.57 |    0.01 | 0.0764 |     - |     - |     160 B |
|                    LinqAF | .NET 5.0 | .NET 5.0 |     0 |    10 |    61.39 ns |  1.181 ns |   1.312 ns |    61.21 ns |  0.88 |    0.02 | 0.0459 |     - |     - |      96 B |
|                StructLinq | .NET 5.0 | .NET 5.0 |     0 |    10 |    19.14 ns |  0.211 ns |   0.187 ns |    19.10 ns |  0.28 |    0.00 | 0.0459 |     - |     - |      96 B |
|                 Hyperlinq | .NET 5.0 | .NET 5.0 |     0 |    10 |    24.13 ns |  0.394 ns |   0.350 ns |    24.07 ns |  0.35 |    0.01 | 0.0459 |     - |     - |      96 B |
|                           |          |          |       |       |             |           |            |             |       |         |        |       |       |           |
|        ValueLinq_Standard | .NET 6.0 | .NET 6.0 |     0 |    10 |    77.35 ns |  0.871 ns |   0.772 ns |    77.38 ns |  1.20 |    0.01 | 0.0459 |     - |     - |      96 B |
|           ValueLinq_Stack | .NET 6.0 | .NET 6.0 |     0 |    10 |    69.72 ns |  0.367 ns |   0.343 ns |    69.60 ns |  1.09 |    0.01 | 0.0458 |     - |     - |      96 B |
| ValueLinq_SharedPool_Push | .NET 6.0 | .NET 6.0 |     0 |    10 |   178.44 ns |  0.599 ns |   0.531 ns |   178.41 ns |  2.78 |    0.01 | 0.0458 |     - |     - |      96 B |
| ValueLinq_SharedPool_Pull | .NET 6.0 | .NET 6.0 |     0 |    10 |   183.00 ns |  0.649 ns |   0.607 ns |   182.85 ns |  2.85 |    0.01 | 0.0458 |     - |     - |      96 B |
|                   ForLoop | .NET 6.0 | .NET 6.0 |     0 |    10 |    64.24 ns |  0.271 ns |   0.253 ns |    64.22 ns |  1.00 |    0.00 | 0.1031 |     - |     - |     216 B |
|               ForeachLoop | .NET 6.0 | .NET 6.0 |     0 |    10 |   119.71 ns |  0.931 ns |   0.871 ns |   119.86 ns |  1.86 |    0.02 | 0.1297 |     - |     - |     272 B |
|                      Linq | .NET 6.0 | .NET 6.0 |     0 |    10 |    39.94 ns |  0.163 ns |   0.153 ns |    39.94 ns |  0.62 |    0.00 | 0.0650 |     - |     - |     136 B |
|                LinqFaster | .NET 6.0 | .NET 6.0 |     0 |    10 |    39.21 ns |  0.461 ns |   0.431 ns |    39.13 ns |  0.61 |    0.01 | 0.0764 |     - |     - |     160 B |
|                    LinqAF | .NET 6.0 | .NET 6.0 |     0 |    10 |    65.04 ns |  0.701 ns |   0.835 ns |    64.85 ns |  1.01 |    0.02 | 0.0459 |     - |     - |      96 B |
|                StructLinq | .NET 6.0 | .NET 6.0 |     0 |    10 |    20.25 ns |  0.334 ns |   0.296 ns |    20.16 ns |  0.32 |    0.00 | 0.0459 |     - |     - |      96 B |
|                 Hyperlinq | .NET 6.0 | .NET 6.0 |     0 |    10 |    24.72 ns |  0.133 ns |   0.118 ns |    24.69 ns |  0.38 |    0.00 | 0.0459 |     - |     - |      96 B |
|                           |          |          |       |       |             |           |            |             |       |         |        |       |       |           |
|        **ValueLinq_Standard** | **.NET 5.0** | **.NET 5.0** |     **0** |  **1000** | **2,444.26 ns** | **11.320 ns** |  **10.589 ns** | **2,442.72 ns** |  **1.01** |    **0.05** | **1.9379** |     **-** |     **-** |   **4,056 B** |
|           ValueLinq_Stack | .NET 5.0 | .NET 5.0 |     0 |  1000 | 2,706.67 ns | 43.683 ns |  40.861 ns | 2,704.67 ns |  1.12 |    0.06 | 3.9330 |     - |     - |   8,232 B |
| ValueLinq_SharedPool_Push | .NET 5.0 | .NET 5.0 |     0 |  1000 | 2,469.97 ns | 20.429 ns |  19.109 ns | 2,466.87 ns |  1.02 |    0.05 | 1.9379 |     - |     - |   4,056 B |
| ValueLinq_SharedPool_Pull | .NET 5.0 | .NET 5.0 |     0 |  1000 | 2,467.47 ns | 21.419 ns |  18.987 ns | 2,463.99 ns |  1.03 |    0.05 | 1.9379 |     - |     - |   4,056 B |
|                   ForLoop | .NET 5.0 | .NET 5.0 |     0 |  1000 | 2,392.87 ns | 47.904 ns | 131.137 ns | 2,327.78 ns |  1.00 |    0.00 | 4.0207 |     - |     - |   8,424 B |
|               ForeachLoop | .NET 5.0 | .NET 5.0 |     0 |  1000 | 6,491.79 ns | 40.309 ns |  74.715 ns | 6,494.25 ns |  2.62 |    0.15 | 4.0436 |     - |     - |   8,480 B |
|                      Linq | .NET 5.0 | .NET 5.0 |     0 |  1000 | 1,931.48 ns | 38.711 ns | 113.533 ns | 1,859.89 ns |  0.81 |    0.06 | 1.9569 |     - |     - |   4,096 B |
|                LinqFaster | .NET 5.0 | .NET 5.0 |     0 |  1000 |   958.10 ns | 18.919 ns |  22.522 ns |   953.75 ns |  0.39 |    0.02 | 3.8605 |     - |     - |   8,080 B |
|                    LinqAF | .NET 5.0 | .NET 5.0 |     0 |  1000 | 2,802.30 ns | 54.557 ns |  64.946 ns | 2,806.98 ns |  1.14 |    0.06 | 1.9379 |     - |     - |   4,056 B |
|                StructLinq | .NET 5.0 | .NET 5.0 |     0 |  1000 |   761.70 ns | 14.472 ns |  16.085 ns |   760.01 ns |  0.31 |    0.02 | 1.9379 |     - |     - |   4,056 B |
|                 Hyperlinq | .NET 5.0 | .NET 5.0 |     0 |  1000 |   305.83 ns |  6.060 ns |   7.879 ns |   305.56 ns |  0.12 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|                           |          |          |       |       |             |           |            |             |       |         |        |       |       |           |
|        ValueLinq_Standard | .NET 6.0 | .NET 6.0 |     0 |  1000 | 2,270.62 ns | 45.361 ns | 129.417 ns | 2,187.27 ns |  0.98 |    0.05 | 1.9379 |     - |     - |   4,056 B |
|           ValueLinq_Stack | .NET 6.0 | .NET 6.0 |     0 |  1000 | 2,790.46 ns | 34.815 ns |  30.863 ns | 2,783.20 ns |  1.20 |    0.02 | 3.9330 |     - |     - |   8,232 B |
| ValueLinq_SharedPool_Push | .NET 6.0 | .NET 6.0 |     0 |  1000 | 2,701.90 ns | 54.003 ns | 126.231 ns | 2,613.18 ns |  1.19 |    0.05 | 1.9379 |     - |     - |   4,056 B |
| ValueLinq_SharedPool_Pull | .NET 6.0 | .NET 6.0 |     0 |  1000 | 2,901.29 ns | 14.071 ns |  13.162 ns | 2,905.40 ns |  1.25 |    0.02 | 1.9379 |     - |     - |   4,056 B |
|                   ForLoop | .NET 6.0 | .NET 6.0 |     0 |  1000 | 2,318.15 ns | 36.717 ns |  34.345 ns | 2,309.76 ns |  1.00 |    0.00 | 4.0207 |     - |     - |   8,424 B |
|               ForeachLoop | .NET 6.0 | .NET 6.0 |     0 |  1000 | 5,673.10 ns | 42.848 ns |  35.780 ns | 5,677.29 ns |  2.45 |    0.04 | 4.0436 |     - |     - |   8,480 B |
|                      Linq | .NET 6.0 | .NET 6.0 |     0 |  1000 | 1,908.79 ns | 38.243 ns | 104.044 ns | 1,844.98 ns |  0.85 |    0.05 | 1.9569 |     - |     - |   4,096 B |
|                LinqFaster | .NET 6.0 | .NET 6.0 |     0 |  1000 |   956.74 ns |  5.322 ns |   4.978 ns |   957.00 ns |  0.41 |    0.01 | 3.8605 |     - |     - |   8,080 B |
|                    LinqAF | .NET 6.0 | .NET 6.0 |     0 |  1000 | 2,400.71 ns | 14.434 ns |  12.795 ns | 2,400.55 ns |  1.04 |    0.02 | 1.9379 |     - |     - |   4,056 B |
|                StructLinq | .NET 6.0 | .NET 6.0 |     0 |  1000 |   859.97 ns |  6.835 ns |  10.438 ns |   858.61 ns |  0.37 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|                 Hyperlinq | .NET 6.0 | .NET 6.0 |     0 |  1000 |   306.75 ns |  5.882 ns |   7.002 ns |   306.75 ns |  0.13 |    0.00 | 1.9379 |     - |     - |   4,056 B |
