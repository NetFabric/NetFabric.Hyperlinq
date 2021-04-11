## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|                                Method |      Job |  Runtime | Start | Count |        Mean |      Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |--------- |--------- |------ |------ |------------:|-----------:|-----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** | **.NET 5.0** | **.NET 5.0** |     **0** |    **10** |   **106.51 ns** |   **1.660 ns** |   **2.039 ns** |   **105.61 ns** | **10.47** |    **0.27** | **0.0305** |     **-** |     **-** |      **64 B** |
|                       ValueLinq_Stack | .NET 5.0 | .NET 5.0 |     0 |    10 |    88.46 ns |   0.321 ns |   0.284 ns |    88.43 ns |  8.68 |    0.13 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Push | .NET 5.0 | .NET 5.0 |     0 |    10 |   313.48 ns |   1.303 ns |   1.219 ns |   313.82 ns | 30.75 |    0.44 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Pull | .NET 5.0 | .NET 5.0 |     0 |    10 |   209.20 ns |   0.510 ns |   0.452 ns |   209.17 ns | 20.52 |    0.26 | 0.0305 |     - |     - |      64 B |
|        ValueLinq_ValueLambda_Standard | .NET 5.0 | .NET 5.0 |     0 |    10 |    95.62 ns |   0.387 ns |   0.323 ns |    95.48 ns |  9.37 |    0.13 | 0.0305 |     - |     - |      64 B |
|           ValueLinq_ValueLambda_Stack | .NET 5.0 | .NET 5.0 |     0 |    10 |    77.81 ns |   0.712 ns |   0.595 ns |    77.62 ns |  7.63 |    0.13 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 5.0 | .NET 5.0 |     0 |    10 |   225.97 ns |   4.261 ns |   3.986 ns |   227.35 ns | 22.20 |    0.30 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 5.0 | .NET 5.0 |     0 |    10 |   197.82 ns |   0.286 ns |   0.223 ns |   197.80 ns | 19.35 |    0.24 | 0.0305 |     - |     - |      64 B |
|                               ForLoop | .NET 5.0 | .NET 5.0 |     0 |    10 |    10.20 ns |   0.160 ns |   0.142 ns |    10.21 ns |  1.00 |    0.00 | 0.0306 |     - |     - |      64 B |
|                                  Linq | .NET 5.0 | .NET 5.0 |     0 |    10 |    69.23 ns |   0.661 ns |   0.618 ns |    69.15 ns |  6.79 |    0.12 | 0.0726 |     - |     - |     152 B |
|                            LinqFaster | .NET 5.0 | .NET 5.0 |     0 |    10 |    36.71 ns |   0.236 ns |   0.197 ns |    36.62 ns |  3.60 |    0.06 | 0.0612 |     - |     - |     128 B |
|                       LinqFaster_SIMD | .NET 5.0 | .NET 5.0 |     0 |    10 |    30.02 ns |   0.312 ns |   0.277 ns |    29.95 ns |  2.94 |    0.05 | 0.0612 |     - |     - |     128 B |
|                                LinqAF | .NET 5.0 | .NET 5.0 |     0 |    10 |   168.29 ns |   3.344 ns |   4.902 ns |   170.04 ns | 16.27 |    0.73 | 0.1185 |     - |     - |     248 B |
|                            StructLinq | .NET 5.0 | .NET 5.0 |     0 |    10 |    45.66 ns |   0.437 ns |   0.409 ns |    45.55 ns |  4.48 |    0.07 | 0.0573 |     - |     - |     120 B |
|                  StructLinq_IFunction | .NET 5.0 | .NET 5.0 |     0 |    10 |    30.67 ns |   0.176 ns |   0.156 ns |    30.64 ns |  3.01 |    0.04 | 0.0305 |     - |     - |      64 B |
|                             Hyperlinq | .NET 5.0 | .NET 5.0 |     0 |    10 |    51.79 ns |   1.105 ns |   2.283 ns |    50.18 ns |  5.13 |    0.23 | 0.0305 |     - |     - |      64 B |
|                   Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |     0 |    10 |    42.17 ns |   0.125 ns |   0.110 ns |    42.18 ns |  4.14 |    0.06 | 0.0305 |     - |     - |      64 B |
|                        Hyperlinq_SIMD | .NET 5.0 | .NET 5.0 |     0 |    10 |    43.49 ns |   0.935 ns |   1.992 ns |    41.94 ns |  4.16 |    0.15 | 0.0306 |     - |     - |      64 B |
|              Hyperlinq_IFunction_SIMD | .NET 5.0 | .NET 5.0 |     0 |    10 |    27.95 ns |   0.245 ns |   0.191 ns |    27.94 ns |  2.73 |    0.04 | 0.0305 |     - |     - |      64 B |
|                                       |          |          |       |       |             |            |            |             |       |         |        |       |       |           |
|                    ValueLinq_Standard | .NET 6.0 | .NET 6.0 |     0 |    10 |   133.59 ns |   5.687 ns |  16.591 ns |   134.03 ns | 12.74 |    2.18 | 0.0305 |     - |     - |      64 B |
|                       ValueLinq_Stack | .NET 6.0 | .NET 6.0 |     0 |    10 |   123.49 ns |   2.544 ns |   4.651 ns |   123.66 ns | 11.80 |    1.12 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Push | .NET 6.0 | .NET 6.0 |     0 |    10 |   377.26 ns |   7.559 ns |  10.347 ns |   377.20 ns | 35.01 |    3.10 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Pull | .NET 6.0 | .NET 6.0 |     0 |    10 |   271.69 ns |   5.508 ns |   8.411 ns |   269.52 ns | 25.47 |    2.23 | 0.0305 |     - |     - |      64 B |
|        ValueLinq_ValueLambda_Standard | .NET 6.0 | .NET 6.0 |     0 |    10 |   111.67 ns |   2.312 ns |   4.976 ns |   109.93 ns | 10.48 |    0.67 | 0.0305 |     - |     - |      64 B |
|           ValueLinq_ValueLambda_Stack | .NET 6.0 | .NET 6.0 |     0 |    10 |    89.02 ns |   4.675 ns |  13.784 ns |    83.26 ns |  8.54 |    1.66 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 6.0 | .NET 6.0 |     0 |    10 |   231.63 ns |   1.009 ns |   0.943 ns |   231.52 ns | 20.20 |    1.08 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 6.0 | .NET 6.0 |     0 |    10 |   200.92 ns |   1.154 ns |   1.023 ns |   201.26 ns | 17.29 |    0.34 | 0.0305 |     - |     - |      64 B |
|                               ForLoop | .NET 6.0 | .NET 6.0 |     0 |    10 |    10.57 ns |   0.290 ns |   0.824 ns |    10.09 ns |  1.00 |    0.00 | 0.0306 |     - |     - |      64 B |
|                                  Linq | .NET 6.0 | .NET 6.0 |     0 |    10 |    62.97 ns |   0.467 ns |   0.414 ns |    62.87 ns |  5.42 |    0.10 | 0.0726 |     - |     - |     152 B |
|                            LinqFaster | .NET 6.0 | .NET 6.0 |     0 |    10 |    37.21 ns |   0.466 ns |   0.436 ns |    37.06 ns |  3.24 |    0.18 | 0.0611 |     - |     - |     128 B |
|                       LinqFaster_SIMD | .NET 6.0 | .NET 6.0 |     0 |    10 |    45.68 ns |   0.199 ns |   0.177 ns |    45.64 ns |  3.93 |    0.07 | 0.0612 |     - |     - |     128 B |
|                                LinqAF | .NET 6.0 | .NET 6.0 |     0 |    10 |   159.26 ns |   0.683 ns |   0.605 ns |   159.28 ns | 13.71 |    0.27 | 0.1183 |     - |     - |     248 B |
|                            StructLinq | .NET 6.0 | .NET 6.0 |     0 |    10 |    51.55 ns |   0.375 ns |   0.351 ns |    51.58 ns |  4.50 |    0.26 | 0.0573 |     - |     - |     120 B |
|                  StructLinq_IFunction | .NET 6.0 | .NET 6.0 |     0 |    10 |    30.44 ns |   0.225 ns |   0.199 ns |    30.38 ns |  2.62 |    0.05 | 0.0305 |     - |     - |      64 B |
|                             Hyperlinq | .NET 6.0 | .NET 6.0 |     0 |    10 |    48.35 ns |   0.145 ns |   0.114 ns |    48.35 ns |  4.15 |    0.07 | 0.0305 |     - |     - |      64 B |
|                   Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |     0 |    10 |    43.78 ns |   0.947 ns |   2.232 ns |    42.24 ns |  4.08 |    0.48 | 0.0306 |     - |     - |      64 B |
|                        Hyperlinq_SIMD | .NET 6.0 | .NET 6.0 |     0 |    10 |    37.44 ns |   0.144 ns |   0.113 ns |    37.44 ns |  3.21 |    0.05 | 0.0305 |     - |     - |      64 B |
|              Hyperlinq_IFunction_SIMD | .NET 6.0 | .NET 6.0 |     0 |    10 |    28.46 ns |   0.184 ns |   0.154 ns |    28.48 ns |  2.44 |    0.04 | 0.0305 |     - |     - |      64 B |
|                                       |          |          |       |       |             |            |            |             |       |         |        |       |       |           |
|                    **ValueLinq_Standard** | **.NET 5.0** | **.NET 5.0** |     **0** |  **1000** | **2,408.34 ns** |  **14.375 ns** |  **12.743 ns** | **2,408.10 ns** |  **2.48** |    **0.12** | **1.9226** |     **-** |     **-** |   **4,024 B** |
|                       ValueLinq_Stack | .NET 5.0 | .NET 5.0 |     0 |  1000 | 3,913.12 ns |  20.292 ns |  17.989 ns | 3,914.20 ns |  4.03 |    0.21 | 3.9139 |     - |     - |   8,200 B |
|             ValueLinq_SharedPool_Push | .NET 5.0 | .NET 5.0 |     0 |  1000 | 3,409.68 ns |  67.544 ns | 146.835 ns | 3,324.62 ns |  3.60 |    0.16 | 1.9226 |     - |     - |   4,024 B |
|             ValueLinq_SharedPool_Pull | .NET 5.0 | .NET 5.0 |     0 |  1000 | 3,697.40 ns |  19.322 ns |  17.129 ns | 3,690.71 ns |  3.81 |    0.18 | 1.9226 |     - |     - |   4,024 B |
|        ValueLinq_ValueLambda_Standard | .NET 5.0 | .NET 5.0 |     0 |  1000 | 2,158.10 ns |  43.023 ns | 126.854 ns | 2,079.63 ns |  2.33 |    0.12 | 1.9226 |     - |     - |   4,024 B |
|           ValueLinq_ValueLambda_Stack | .NET 5.0 | .NET 5.0 |     0 |  1000 | 2,429.97 ns |  26.903 ns |  22.466 ns | 2,422.92 ns |  2.51 |    0.12 | 3.9177 |     - |     - |   8,200 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 5.0 | .NET 5.0 |     0 |  1000 | 2,733.48 ns |  54.734 ns |  71.169 ns | 2,746.42 ns |  2.76 |    0.10 | 1.9226 |     - |     - |   4,024 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 5.0 | .NET 5.0 |     0 |  1000 | 2,323.48 ns |  18.918 ns |  17.695 ns | 2,319.51 ns |  2.39 |    0.11 | 1.9226 |     - |     - |   4,024 B |
|                               ForLoop | .NET 5.0 | .NET 5.0 |     0 |  1000 |   941.55 ns |  18.901 ns |  46.719 ns |   914.85 ns |  1.00 |    0.00 | 1.9226 |     - |     - |   4,024 B |
|                                  Linq | .NET 5.0 | .NET 5.0 |     0 |  1000 | 2,075.18 ns |  14.920 ns |  13.957 ns | 2,066.26 ns |  2.13 |    0.11 | 1.9646 |     - |     - |   4,112 B |
|                            LinqFaster | .NET 5.0 | .NET 5.0 |     0 |  1000 | 2,540.01 ns |  17.032 ns |  15.099 ns | 2,542.61 ns |  2.62 |    0.13 | 3.8452 |     - |     - |   8,048 B |
|                       LinqFaster_SIMD | .NET 5.0 | .NET 5.0 |     0 |  1000 |   831.97 ns |  14.676 ns |  13.728 ns |   834.19 ns |  0.85 |    0.04 | 3.8452 |     - |     - |   8,048 B |
|                                LinqAF | .NET 5.0 | .NET 5.0 |     0 |  1000 | 7,559.62 ns | 145.312 ns | 135.925 ns | 7,584.72 ns |  7.76 |    0.38 | 5.9280 |     - |     - |  12,416 B |
|                            StructLinq | .NET 5.0 | .NET 5.0 |     0 |  1000 | 2,076.91 ns |   8.613 ns |   7.192 ns | 2,074.95 ns |  2.15 |    0.11 | 1.9493 |     - |     - |   4,080 B |
|                  StructLinq_IFunction | .NET 5.0 | .NET 5.0 |     0 |  1000 |   772.17 ns |   7.714 ns |   6.838 ns |   772.26 ns |  0.80 |    0.04 | 1.9226 |     - |     - |   4,024 B |
|                             Hyperlinq | .NET 5.0 | .NET 5.0 |     0 |  1000 | 1,848.51 ns |  20.205 ns |  18.900 ns | 1,840.32 ns |  1.90 |    0.11 | 1.9226 |     - |     - |   4,024 B |
|                   Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |     0 |  1000 | 1,106.63 ns |   8.329 ns |   7.384 ns | 1,106.89 ns |  1.14 |    0.05 | 1.9226 |     - |     - |   4,024 B |
|                        Hyperlinq_SIMD | .NET 5.0 | .NET 5.0 |     0 |  1000 |   475.81 ns |   8.953 ns |   7.476 ns |   476.54 ns |  0.49 |    0.03 | 1.9150 |     - |     - |   4,024 B |
|              Hyperlinq_IFunction_SIMD | .NET 5.0 | .NET 5.0 |     0 |  1000 |   275.20 ns |   4.522 ns |   4.230 ns |   275.13 ns |  0.28 |    0.02 | 1.9155 |     - |     - |   4,024 B |
|                                       |          |          |       |       |             |            |            |             |       |         |        |       |       |           |
|                    ValueLinq_Standard | .NET 6.0 | .NET 6.0 |     0 |  1000 | 2,397.62 ns |  47.237 ns |  66.220 ns | 2,417.94 ns |  2.32 |    0.07 | 1.9226 |     - |     - |   4,024 B |
|                       ValueLinq_Stack | .NET 6.0 | .NET 6.0 |     0 |  1000 | 3,939.37 ns |  24.977 ns |  20.857 ns | 3,934.01 ns |  3.84 |    0.04 | 3.9139 |     - |     - |   8,200 B |
|             ValueLinq_SharedPool_Push | .NET 6.0 | .NET 6.0 |     0 |  1000 | 3,241.30 ns |  64.583 ns | 150.960 ns | 3,148.84 ns |  3.17 |    0.11 | 1.9226 |     - |     - |   4,024 B |
|             ValueLinq_SharedPool_Pull | .NET 6.0 | .NET 6.0 |     0 |  1000 | 3,468.38 ns |  14.189 ns |  11.848 ns | 3,467.95 ns |  3.38 |    0.04 | 1.9226 |     - |     - |   4,024 B |
|        ValueLinq_ValueLambda_Standard | .NET 6.0 | .NET 6.0 |     0 |  1000 | 2,316.85 ns |  45.099 ns |  64.679 ns | 2,338.17 ns |  2.24 |    0.08 | 1.9226 |     - |     - |   4,024 B |
|           ValueLinq_ValueLambda_Stack | .NET 6.0 | .NET 6.0 |     0 |  1000 | 2,475.70 ns |  25.612 ns |  23.958 ns | 2,471.31 ns |  2.41 |    0.02 | 3.9177 |     - |     - |   8,200 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 6.0 | .NET 6.0 |     0 |  1000 | 2,655.85 ns |  11.521 ns |  10.213 ns | 2,655.19 ns |  2.59 |    0.02 | 1.9226 |     - |     - |   4,024 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 6.0 | .NET 6.0 |     0 |  1000 | 2,499.02 ns |  49.528 ns | 132.201 ns | 2,411.71 ns |  2.47 |    0.11 | 1.9226 |     - |     - |   4,024 B |
|                               ForLoop | .NET 6.0 | .NET 6.0 |     0 |  1000 | 1,026.70 ns |  11.203 ns |  10.479 ns | 1,029.58 ns |  1.00 |    0.00 | 1.9226 |     - |     - |   4,024 B |
|                                  Linq | .NET 6.0 | .NET 6.0 |     0 |  1000 | 2,094.18 ns |  13.321 ns |  11.809 ns | 2,092.84 ns |  2.04 |    0.03 | 1.9646 |     - |     - |   4,112 B |
|                            LinqFaster | .NET 6.0 | .NET 6.0 |     0 |  1000 | 2,462.55 ns |  42.428 ns |  39.687 ns | 2,451.16 ns |  2.40 |    0.04 | 3.8452 |     - |     - |   8,048 B |
|                       LinqFaster_SIMD | .NET 6.0 | .NET 6.0 |     0 |  1000 | 2,538.23 ns |  26.862 ns |  20.972 ns | 2,532.46 ns |  2.48 |    0.02 | 3.8452 |     - |     - |   8,048 B |
|                                LinqAF | .NET 6.0 | .NET 6.0 |     0 |  1000 | 6,106.42 ns | 115.429 ns | 245.989 ns | 5,986.59 ns |  6.24 |    0.30 | 5.9280 |     - |     - |  12,416 B |
|                            StructLinq | .NET 6.0 | .NET 6.0 |     0 |  1000 | 2,258.12 ns |  45.020 ns |  77.658 ns | 2,290.28 ns |  2.14 |    0.08 | 1.9493 |     - |     - |   4,080 B |
|                  StructLinq_IFunction | .NET 6.0 | .NET 6.0 |     0 |  1000 |   766.88 ns |  12.055 ns |  10.686 ns |   767.70 ns |  0.75 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|                             Hyperlinq | .NET 6.0 | .NET 6.0 |     0 |  1000 | 1,960.26 ns |  24.436 ns |  22.857 ns | 1,955.41 ns |  1.91 |    0.04 | 1.9226 |     - |     - |   4,024 B |
|                   Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |     0 |  1000 | 1,303.76 ns |  11.100 ns |   9.840 ns | 1,304.78 ns |  1.27 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|                        Hyperlinq_SIMD | .NET 6.0 | .NET 6.0 |     0 |  1000 | 2,525.38 ns |  21.623 ns |  20.226 ns | 2,521.06 ns |  2.46 |    0.02 | 1.9150 |     - |     - |   4,024 B |
|              Hyperlinq_IFunction_SIMD | .NET 6.0 | .NET 6.0 |     0 |  1000 | 1,224.27 ns |   9.379 ns |   8.773 ns | 1,224.31 ns |  1.19 |    0.02 | 1.9150 |     - |     - |   4,024 B |
