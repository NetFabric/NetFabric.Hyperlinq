## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

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
|                      Method |      Job |  Runtime | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |--------- |--------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |     **6.164 ns** |  **0.0264 ns** |  **0.0221 ns** |     **6.170 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |     4.775 ns |  0.0323 ns |  0.0270 ns |     4.769 ns |  0.77 |    0.01 |      - |     - |     - |         - |
|                        Linq | .NET 5.0 | .NET 5.0 |    10 |   109.906 ns |  0.3722 ns |  0.3481 ns |   109.874 ns | 17.82 |    0.07 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster | .NET 5.0 | .NET 5.0 |    10 |    32.291 ns |  0.2585 ns |  0.2292 ns |    32.299 ns |  5.23 |    0.03 | 0.0306 |     - |     - |      64 B |
|             LinqFaster_SIMD | .NET 5.0 | .NET 5.0 |    10 |    22.562 ns |  0.4799 ns |  1.2974 ns |    21.833 ns |  3.77 |    0.17 | 0.0306 |     - |     - |      64 B |
|                      LinqAF | .NET 5.0 | .NET 5.0 |    10 |    66.869 ns |  0.3090 ns |  0.2580 ns |    66.928 ns | 10.85 |    0.05 |      - |     - |     - |         - |
|                  StructLinq | .NET 5.0 | .NET 5.0 |    10 |    40.589 ns |  0.1456 ns |  0.1215 ns |    40.596 ns |  6.58 |    0.04 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    38.993 ns |  0.1148 ns |  0.1018 ns |    38.990 ns |  6.33 |    0.03 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5.0 | .NET 5.0 |    10 |    42.695 ns |  0.3072 ns |  0.2565 ns |    42.577 ns |  6.93 |    0.06 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 5.0 | .NET 5.0 |    10 |    41.487 ns |  0.1486 ns |  0.1241 ns |    41.448 ns |  6.73 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For | .NET 5.0 | .NET 5.0 |    10 |    32.426 ns |  0.0960 ns |  0.0802 ns |    32.405 ns |  5.26 |    0.02 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 5.0 | .NET 5.0 |    10 |    25.438 ns |  0.0541 ns |  0.0479 ns |    25.425 ns |  4.13 |    0.02 |      - |     - |     - |         - |
|                             |          |          |       |              |            |            |              |       |         |        |       |       |           |
|                     ForLoop | .NET 6.0 | .NET 6.0 |    10 |     3.443 ns |  0.0227 ns |  0.0190 ns |     3.437 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |     3.573 ns |  0.0147 ns |  0.0137 ns |     3.572 ns |  1.04 |    0.01 |      - |     - |     - |         - |
|                        Linq | .NET 6.0 | .NET 6.0 |    10 |   101.154 ns |  0.4183 ns |  0.3708 ns |   101.086 ns | 29.39 |    0.17 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster | .NET 6.0 | .NET 6.0 |    10 |    28.132 ns |  0.1779 ns |  0.1577 ns |    28.104 ns |  8.17 |    0.07 | 0.0306 |     - |     - |      64 B |
|             LinqFaster_SIMD | .NET 6.0 | .NET 6.0 |    10 |    33.751 ns |  0.4875 ns |  0.4071 ns |    33.584 ns |  9.80 |    0.14 | 0.0306 |     - |     - |      64 B |
|                      LinqAF | .NET 6.0 | .NET 6.0 |    10 |    79.355 ns |  0.3366 ns |  0.2811 ns |    79.356 ns | 23.05 |    0.17 |      - |     - |     - |         - |
|                  StructLinq | .NET 6.0 | .NET 6.0 |    10 |    42.281 ns |  0.8756 ns |  1.4387 ns |    41.498 ns | 12.77 |    0.27 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    38.708 ns |  0.0846 ns |  0.0750 ns |    38.710 ns | 11.24 |    0.07 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6.0 | .NET 6.0 |    10 |    42.287 ns |  0.1760 ns |  0.1470 ns |    42.310 ns | 12.28 |    0.09 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 6.0 | .NET 6.0 |    10 |    41.831 ns |  0.1709 ns |  0.1515 ns |    41.789 ns | 12.15 |    0.07 |      - |     - |     - |         - |
|               Hyperlinq_For | .NET 6.0 | .NET 6.0 |    10 |    32.823 ns |  0.1371 ns |  0.1145 ns |    32.829 ns |  9.53 |    0.07 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 6.0 | .NET 6.0 |    10 |    25.901 ns |  0.0577 ns |  0.0482 ns |    25.905 ns |  7.52 |    0.04 |      - |     - |     - |         - |
|                             |          |          |       |              |            |            |              |       |         |        |       |       |           |
|                     **ForLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** |   **541.594 ns** |  **4.3588 ns** |  **3.8640 ns** |   **541.506 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 |   543.151 ns |  1.9400 ns |  1.6200 ns |   542.845 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                        Linq | .NET 5.0 | .NET 5.0 |  1000 | 6,019.314 ns | 40.6243 ns | 33.9231 ns | 6,008.192 ns | 11.12 |    0.11 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster | .NET 5.0 | .NET 5.0 |  1000 | 2,191.914 ns |  8.5161 ns |  7.5493 ns | 2,190.993 ns |  4.05 |    0.04 | 1.9226 |     - |     - |   4,024 B |
|             LinqFaster_SIMD | .NET 5.0 | .NET 5.0 |  1000 |   916.476 ns | 11.3268 ns |  8.8432 ns |   919.836 ns |  1.69 |    0.02 | 1.9226 |     - |     - |   4,024 B |
|                      LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 4,480.281 ns | 11.8825 ns | 11.1149 ns | 4,479.935 ns |  8.27 |    0.06 |      - |     - |     - |         - |
|                  StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 2,194.049 ns |  6.9674 ns |  6.5173 ns | 2,194.431 ns |  4.05 |    0.03 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 1,460.076 ns |  2.9158 ns |  2.7275 ns | 1,461.073 ns |  2.70 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5.0 | .NET 5.0 |  1000 | 2,121.160 ns | 10.4170 ns |  9.2344 ns | 2,121.472 ns |  3.92 |    0.04 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 5.0 | .NET 5.0 |  1000 | 1,634.749 ns |  4.1634 ns |  3.6907 ns | 1,634.054 ns |  3.02 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For | .NET 5.0 | .NET 5.0 |  1000 | 2,109.516 ns | 12.4567 ns | 11.6520 ns | 2,105.209 ns |  3.90 |    0.03 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 5.0 | .NET 5.0 |  1000 |   809.658 ns |  4.2129 ns |  3.5179 ns |   808.357 ns |  1.50 |    0.01 |      - |     - |     - |         - |
|                             |          |          |       |              |            |            |              |       |         |        |       |       |           |
|                     ForLoop | .NET 6.0 | .NET 6.0 |  1000 |   554.211 ns |  2.2063 ns |  1.9558 ns |   554.746 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 |   546.351 ns |  2.2372 ns |  1.9832 ns |   546.553 ns |  0.99 |    0.01 |      - |     - |     - |         - |
|                        Linq | .NET 6.0 | .NET 6.0 |  1000 | 5,925.697 ns | 47.9218 ns | 42.4815 ns | 5,930.005 ns | 10.69 |    0.07 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster | .NET 6.0 | .NET 6.0 |  1000 | 2,219.320 ns | 14.1253 ns | 12.5217 ns | 2,217.162 ns |  4.00 |    0.03 | 1.9226 |     - |     - |   4,024 B |
|             LinqFaster_SIMD | .NET 6.0 | .NET 6.0 |  1000 | 2,862.676 ns | 60.0073 ns | 56.1309 ns | 2,874.473 ns |  5.16 |    0.10 | 1.9226 |     - |     - |   4,024 B |
|                      LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 5,756.556 ns | 14.0652 ns | 12.4684 ns | 5,757.299 ns | 10.39 |    0.04 |      - |     - |     - |         - |
|                  StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 2,125.471 ns |  7.2658 ns |  6.4410 ns | 2,124.920 ns |  3.84 |    0.02 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 1,474.715 ns |  4.0929 ns |  3.6283 ns | 1,472.942 ns |  2.66 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6.0 | .NET 6.0 |  1000 | 1,847.241 ns |  2.7925 ns |  2.3319 ns | 1,847.165 ns |  3.33 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 6.0 | .NET 6.0 |  1000 | 1,616.513 ns |  4.4928 ns |  4.2026 ns | 1,614.739 ns |  2.92 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For | .NET 6.0 | .NET 6.0 |  1000 | 2,110.596 ns |  9.0637 ns |  7.5686 ns | 2,109.034 ns |  3.81 |    0.02 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 6.0 | .NET 6.0 |  1000 |   815.065 ns |  4.9051 ns |  4.3482 ns |   816.165 ns |  1.47 |    0.01 |      - |     - |     - |         - |
