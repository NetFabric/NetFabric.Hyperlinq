## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|                   Method |    Job |  Runtime | Start | Count |        Mean |      Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------- |--------- |------ |------ |------------:|-----------:|-----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                  **ForLoop** | **.NET 5** | **.NET 5.0** |     **0** |    **10** |    **15.04 ns** |   **0.419 ns** |   **1.180 ns** |    **14.93 ns** |  **1.00** |    **0.00** | **0.0306** |     **-** |     **-** |      **64 B** |
|                     Linq | .NET 5 | .NET 5.0 |     0 |    10 |    76.08 ns |   2.811 ns |   8.066 ns |    74.51 ns |  5.11 |    0.63 | 0.0726 |     - |     - |     152 B |
|               LinqFaster | .NET 5 | .NET 5.0 |     0 |    10 |    38.41 ns |   2.049 ns |   6.009 ns |    34.81 ns |  2.58 |    0.40 | 0.0612 |     - |     - |     128 B |
|          LinqFaster_SIMD | .NET 5 | .NET 5.0 |     0 |    10 |    31.75 ns |   0.672 ns |   1.176 ns |    31.88 ns |  2.07 |    0.16 | 0.0612 |     - |     - |     128 B |
|                   LinqAF | .NET 5 | .NET 5.0 |     0 |    10 |   156.32 ns |   2.784 ns |   2.468 ns |   155.91 ns |  9.77 |    1.20 | 0.1185 |     - |     - |     248 B |
|               StructLinq | .NET 5 | .NET 5.0 |     0 |    10 |    46.05 ns |   0.996 ns |   0.832 ns |    45.81 ns |  2.88 |    0.35 | 0.0573 |     - |     - |     120 B |
|     StructLinq_IFunction | .NET 5 | .NET 5.0 |     0 |    10 |    26.38 ns |   0.609 ns |   1.603 ns |    25.63 ns |  1.76 |    0.14 | 0.0305 |     - |     - |      64 B |
|                Hyperlinq | .NET 5 | .NET 5.0 |     0 |    10 |    48.35 ns |   0.255 ns |   0.226 ns |    48.31 ns |  3.02 |    0.36 | 0.0306 |     - |     - |      64 B |
|      Hyperlinq_IFunction | .NET 5 | .NET 5.0 |     0 |    10 |    37.05 ns |   0.179 ns |   0.168 ns |    37.02 ns |  2.33 |    0.26 | 0.0305 |     - |     - |      64 B |
|           Hyperlinq_SIMD | .NET 5 | .NET 5.0 |     0 |    10 |    39.79 ns |   0.343 ns |   0.268 ns |    39.76 ns |  2.47 |    0.30 | 0.0305 |     - |     - |      64 B |
| Hyperlinq_IFunction_SIMD | .NET 5 | .NET 5.0 |     0 |    10 |    25.62 ns |   0.389 ns |   0.364 ns |    25.70 ns |  1.61 |    0.18 | 0.0305 |     - |     - |      64 B |
|                          |        |          |       |       |             |            |            |             |       |         |        |       |       |           |
|                  ForLoop | .NET 6 | .NET 6.0 |     0 |    10 |    10.81 ns |   0.174 ns |   0.163 ns |    10.82 ns |  1.00 |    0.00 | 0.0306 |     - |     - |      64 B |
|                     Linq | .NET 6 | .NET 6.0 |     0 |    10 |    54.19 ns |   0.400 ns |   0.334 ns |    54.24 ns |  5.02 |    0.09 | 0.0727 |     - |     - |     152 B |
|               LinqFaster | .NET 6 | .NET 6.0 |     0 |    10 |    36.53 ns |   0.293 ns |   0.260 ns |    36.50 ns |  3.38 |    0.05 | 0.0612 |     - |     - |     128 B |
|          LinqFaster_SIMD | .NET 6 | .NET 6.0 |     0 |    10 |    46.25 ns |   0.283 ns |   0.236 ns |    46.17 ns |  4.29 |    0.07 | 0.0612 |     - |     - |     128 B |
|                   LinqAF | .NET 6 | .NET 6.0 |     0 |    10 |   163.67 ns |   0.933 ns |   0.779 ns |   163.63 ns | 15.17 |    0.22 | 0.1183 |     - |     - |     248 B |
|               StructLinq | .NET 6 | .NET 6.0 |     0 |    10 |    44.21 ns |   0.623 ns |   0.552 ns |    44.34 ns |  4.09 |    0.09 | 0.0573 |     - |     - |     120 B |
|     StructLinq_IFunction | .NET 6 | .NET 6.0 |     0 |    10 |    27.97 ns |   0.259 ns |   0.242 ns |    27.92 ns |  2.59 |    0.04 | 0.0306 |     - |     - |      64 B |
|                Hyperlinq | .NET 6 | .NET 6.0 |     0 |    10 |    47.14 ns |   1.043 ns |   2.749 ns |    45.53 ns |  4.77 |    0.19 | 0.0306 |     - |     - |      64 B |
|      Hyperlinq_IFunction | .NET 6 | .NET 6.0 |     0 |    10 |    39.83 ns |   0.875 ns |   1.169 ns |    40.20 ns |  3.73 |    0.14 | 0.0306 |     - |     - |      64 B |
|           Hyperlinq_SIMD | .NET 6 | .NET 6.0 |     0 |    10 |    40.55 ns |   0.259 ns |   0.230 ns |    40.53 ns |  3.75 |    0.07 | 0.0306 |     - |     - |      64 B |
| Hyperlinq_IFunction_SIMD | .NET 6 | .NET 6.0 |     0 |    10 |    27.38 ns |   0.182 ns |   0.171 ns |    27.39 ns |  2.53 |    0.04 | 0.0306 |     - |     - |      64 B |
|                          |        |          |       |       |             |            |            |             |       |         |        |       |       |           |
|                  **ForLoop** | **.NET 5** | **.NET 5.0** |     **0** |  **1000** |   **859.02 ns** |  **10.127 ns** |  **18.261 ns** |   **855.69 ns** |  **1.00** |    **0.00** | **1.9226** |     **-** |     **-** |   **4,024 B** |
|                     Linq | .NET 5 | .NET 5.0 |     0 |  1000 | 2,052.84 ns |  27.092 ns |  22.623 ns | 2,044.19 ns |  2.38 |    0.08 | 1.9646 |     - |     - |   4,112 B |
|               LinqFaster | .NET 5 | .NET 5.0 |     0 |  1000 | 2,467.43 ns |  30.832 ns |  28.840 ns | 2,465.34 ns |  2.87 |    0.09 | 3.8452 |     - |     - |   8,048 B |
|          LinqFaster_SIMD | .NET 5 | .NET 5.0 |     0 |  1000 |   845.62 ns |  13.066 ns |  12.222 ns |   851.45 ns |  0.98 |    0.03 | 3.8452 |     - |     - |   8,048 B |
|                   LinqAF | .NET 5 | .NET 5.0 |     0 |  1000 | 7,076.72 ns |  30.255 ns |  25.264 ns | 7,074.76 ns |  8.22 |    0.23 | 5.9280 |     - |     - |  12,416 B |
|               StructLinq | .NET 5 | .NET 5.0 |     0 |  1000 | 2,088.49 ns |  18.090 ns |  16.036 ns | 2,090.65 ns |  2.43 |    0.07 | 1.9493 |     - |     - |   4,080 B |
|     StructLinq_IFunction | .NET 5 | .NET 5.0 |     0 |  1000 |   890.65 ns |  12.893 ns |  12.060 ns |   888.98 ns |  1.03 |    0.03 | 1.9226 |     - |     - |   4,024 B |
|                Hyperlinq | .NET 5 | .NET 5.0 |     0 |  1000 | 2,113.53 ns |  15.816 ns |  14.020 ns | 2,111.01 ns |  2.46 |    0.07 | 1.9226 |     - |     - |   4,024 B |
|      Hyperlinq_IFunction | .NET 5 | .NET 5.0 |     0 |  1000 | 1,169.30 ns |   9.439 ns |   8.368 ns | 1,168.51 ns |  1.36 |    0.04 | 1.9226 |     - |     - |   4,024 B |
|           Hyperlinq_SIMD | .NET 5 | .NET 5.0 |     0 |  1000 |   479.50 ns |   6.912 ns |   5.772 ns |   478.87 ns |  0.56 |    0.01 | 1.9150 |     - |     - |   4,024 B |
| Hyperlinq_IFunction_SIMD | .NET 5 | .NET 5.0 |     0 |  1000 |   282.42 ns |   5.182 ns |   4.847 ns |   280.40 ns |  0.33 |    0.01 | 1.9155 |     - |     - |   4,024 B |
|                          |        |          |       |       |             |            |            |             |       |         |        |       |       |           |
|                  ForLoop | .NET 6 | .NET 6.0 |     0 |  1000 |   885.21 ns |  10.957 ns |  10.249 ns |   884.85 ns |  1.00 |    0.00 | 1.9226 |     - |     - |   4,024 B |
|                     Linq | .NET 6 | .NET 6.0 |     0 |  1000 | 2,277.62 ns |  45.372 ns |  63.606 ns | 2,299.27 ns |  2.56 |    0.10 | 1.9646 |     - |     - |   4,112 B |
|               LinqFaster | .NET 6 | .NET 6.0 |     0 |  1000 | 2,750.91 ns |  27.748 ns |  24.598 ns | 2,750.81 ns |  3.11 |    0.03 | 3.8452 |     - |     - |   8,048 B |
|          LinqFaster_SIMD | .NET 6 | .NET 6.0 |     0 |  1000 | 2,811.53 ns |  56.135 ns | 144.902 ns | 2,736.31 ns |  3.16 |    0.13 | 3.8452 |     - |     - |   8,048 B |
|                   LinqAF | .NET 6 | .NET 6.0 |     0 |  1000 | 6,583.36 ns | 130.532 ns | 305.113 ns | 6,391.40 ns |  7.62 |    0.30 | 5.9280 |     - |     - |  12,416 B |
|               StructLinq | .NET 6 | .NET 6.0 |     0 |  1000 | 1,918.29 ns |  38.308 ns |  92.518 ns | 1,921.76 ns |  2.23 |    0.08 | 1.9493 |     - |     - |   4,080 B |
|     StructLinq_IFunction | .NET 6 | .NET 6.0 |     0 |  1000 |   757.15 ns |  13.724 ns |  12.837 ns |   756.21 ns |  0.86 |    0.02 | 1.9226 |     - |     - |   4,024 B |
|                Hyperlinq | .NET 6 | .NET 6.0 |     0 |  1000 | 2,125.16 ns |  16.292 ns |  14.442 ns | 2,123.26 ns |  2.40 |    0.03 | 1.9226 |     - |     - |   4,024 B |
|      Hyperlinq_IFunction | .NET 6 | .NET 6.0 |     0 |  1000 | 1,051.01 ns |  20.023 ns |  18.729 ns | 1,047.11 ns |  1.19 |    0.02 | 1.9226 |     - |     - |   4,024 B |
|           Hyperlinq_SIMD | .NET 6 | .NET 6.0 |     0 |  1000 | 2,233.92 ns |  47.885 ns | 141.190 ns | 2,149.08 ns |  2.65 |    0.13 | 1.9150 |     - |     - |   4,024 B |
| Hyperlinq_IFunction_SIMD | .NET 6 | .NET 6.0 |     0 |  1000 | 1,440.42 ns |  14.178 ns |  12.569 ns | 1,441.37 ns |  1.63 |    0.02 | 1.9150 |     - |     - |   4,024 B |
