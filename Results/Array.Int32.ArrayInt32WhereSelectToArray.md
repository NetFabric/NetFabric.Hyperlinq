## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta39](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta39)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                Method | Count |        Mean |      Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------------:|-----------:|-----------:|------------:|------:|--------:|-------:|-------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |   **169.07 ns** |   **0.954 ns** |   **0.745 ns** |   **169.07 ns** |  **4.57** |    **0.16** | **0.0153** |      **-** |     **-** |      **32 B** |
|                       ValueLinq_Stack |    10 |   133.16 ns |   0.745 ns |   0.582 ns |   133.21 ns |  3.60 |    0.12 | 0.0150 |      - |     - |      32 B |
|             ValueLinq_SharedPool_Push |    10 |   354.27 ns |   1.040 ns |   0.869 ns |   354.20 ns |  9.57 |    0.31 | 0.0153 | 0.0005 |     - |      32 B |
|             ValueLinq_SharedPool_Pull |    10 |   261.50 ns |   0.479 ns |   0.374 ns |   261.55 ns |  7.07 |    0.24 | 0.0153 |      - |     - |      32 B |
|        ValueLinq_ValueLambda_Standard |    10 |   143.62 ns |   0.608 ns |   0.508 ns |   143.50 ns |  3.88 |    0.13 | 0.0150 |      - |     - |      32 B |
|           ValueLinq_ValueLambda_Stack |    10 |   108.02 ns |   0.260 ns |   0.203 ns |   108.04 ns |  2.92 |    0.10 | 0.0151 |      - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |   281.09 ns |   0.590 ns |   0.551 ns |   281.09 ns |  7.59 |    0.23 | 0.0153 |      - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |   250.70 ns |   0.877 ns |   0.732 ns |   250.78 ns |  6.77 |    0.22 | 0.0153 |      - |     - |      32 B |
|                               ForLoop |    10 |    36.79 ns |   0.726 ns |   0.993 ns |    36.41 ns |  1.00 |    0.00 | 0.0497 |      - |     - |     104 B |
|                           ForeachLoop |    10 |    36.69 ns |   0.188 ns |   0.167 ns |    36.71 ns |  0.99 |    0.03 | 0.0497 |      - |     - |     104 B |
|                                  Linq |    10 |   134.22 ns |   1.055 ns |   0.935 ns |   134.05 ns |  3.62 |    0.12 | 0.0839 |      - |     - |     176 B |
|                            LinqFaster |    10 |    39.56 ns |   0.211 ns |   0.165 ns |    39.52 ns |  1.07 |    0.04 | 0.0459 |      - |     - |      96 B |
|                                LinqAF |    10 |   116.69 ns |   1.270 ns |   1.126 ns |   116.40 ns |  3.15 |    0.10 | 0.0342 |      - |     - |      72 B |
|                            StructLinq |    10 |   124.05 ns |   1.323 ns |   1.105 ns |   124.11 ns |  3.35 |    0.13 | 0.0610 |      - |     - |     128 B |
|                  StructLinq_IFunction |    10 |    94.92 ns |   0.450 ns |   0.421 ns |    94.85 ns |  2.56 |    0.08 | 0.0153 |      - |     - |      32 B |
|                             Hyperlinq |    10 |   110.82 ns |   2.018 ns |   2.829 ns |   109.49 ns |  3.01 |    0.09 | 0.0153 |      - |     - |      32 B |
|                   Hyperlinq_IFunction |    10 |    71.57 ns |   0.302 ns |   0.282 ns |    71.55 ns |  1.93 |    0.06 | 0.0153 |      - |     - |      32 B |
|                                       |       |             |            |            |             |       |         |        |        |       |           |
|                    **ValueLinq_Standard** |  **1000** | **6,467.21 ns** | **106.656 ns** | **186.799 ns** | **6,418.37 ns** |  **2.48** |    **0.10** | **1.9760** |      **-** |     **-** |    **4144 B** |
|                       ValueLinq_Stack |  1000 | 6,640.27 ns | 131.827 ns | 275.171 ns | 6,488.95 ns |  2.62 |    0.12 | 1.9760 |      - |     - |    4144 B |
|             ValueLinq_SharedPool_Push |  1000 | 6,233.46 ns | 120.437 ns | 118.286 ns | 6,176.92 ns |  2.38 |    0.04 | 0.9689 |      - |     - |    2040 B |
|             ValueLinq_SharedPool_Pull |  1000 | 6,596.47 ns |  16.220 ns |  13.544 ns | 6,598.08 ns |  2.52 |    0.01 | 0.9689 |      - |     - |    2040 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 2,501.80 ns |  11.639 ns |  10.887 ns | 2,500.71 ns |  0.96 |    0.01 | 1.9798 |      - |     - |    4144 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 2,550.46 ns |  12.385 ns |  10.979 ns | 2,550.86 ns |  0.97 |    0.01 | 1.9798 |      - |     - |    4144 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 2,596.10 ns |  11.948 ns |  10.592 ns | 2,596.49 ns |  0.99 |    0.01 | 0.9727 |      - |     - |    2040 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 2,561.07 ns |  14.585 ns |  12.930 ns | 2,561.36 ns |  0.98 |    0.01 | 0.9727 |      - |     - |    2040 B |
|                               ForLoop |  1000 | 2,617.49 ns |  11.927 ns |  11.157 ns | 2,616.41 ns |  1.00 |    0.00 | 3.0289 |      - |     - |    6344 B |
|                           ForeachLoop |  1000 | 2,717.75 ns |  10.680 ns |   9.990 ns | 2,718.08 ns |  1.04 |    0.01 | 3.0289 |      - |     - |    6344 B |
|                                  Linq |  1000 | 5,211.13 ns |  19.744 ns |  18.469 ns | 5,209.38 ns |  1.99 |    0.01 | 2.1667 |      - |     - |    4544 B |
|                            LinqFaster |  1000 | 4,866.77 ns |  19.141 ns |  16.968 ns | 4,869.92 ns |  1.86 |    0.01 | 2.8915 |      - |     - |    6064 B |
|                                LinqAF |  1000 | 7,492.11 ns |  18.125 ns |  15.135 ns | 7,492.09 ns |  2.86 |    0.01 | 3.0136 |      - |     - |    6312 B |
|                            StructLinq |  1000 | 5,414.14 ns |  16.568 ns |  12.936 ns | 5,414.39 ns |  2.07 |    0.01 | 1.0147 |      - |     - |    2136 B |
|                  StructLinq_IFunction |  1000 | 2,786.07 ns |  17.105 ns |  15.163 ns | 2,779.96 ns |  1.06 |    0.01 | 0.9727 |      - |     - |    2040 B |
|                             Hyperlinq |  1000 | 4,942.84 ns |  23.395 ns |  20.739 ns | 4,941.76 ns |  1.89 |    0.01 | 0.9689 |      - |     - |    2040 B |
|                   Hyperlinq_IFunction |  1000 | 3,516.12 ns |  10.727 ns |  10.034 ns | 3,516.85 ns |  1.34 |    0.01 | 0.9727 |      - |     - |    2040 B |
