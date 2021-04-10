## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|                                Method | Count |         Mean |      Error |       StdDev |       Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-------------:|-----------:|-------------:|-------------:|------:|--------:|--------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |    **195.25 ns** |   **0.933 ns** |     **0.779 ns** |    **195.45 ns** |  **2.68** |    **0.02** |  **0.0725** |     **-** |     **-** |     **152 B** |
|                       ValueLinq_Stack |    10 |    173.42 ns |   1.175 ns |     1.042 ns |    173.44 ns |  2.38 |    0.02 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Push |    10 |    421.62 ns |   1.688 ns |     1.410 ns |    421.18 ns |  5.78 |    0.04 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Pull |    10 |    314.30 ns |   2.783 ns |     2.324 ns |    313.94 ns |  4.31 |    0.05 |  0.0725 |     - |     - |     152 B |
|                ValueLinq_Ref_Standard |    10 |    181.03 ns |   1.109 ns |     1.037 ns |    180.58 ns |  2.48 |    0.02 |  0.0725 |     - |     - |     152 B |
|                   ValueLinq_Ref_Stack |    10 |    157.56 ns |   0.716 ns |     0.635 ns |    157.84 ns |  2.16 |    0.02 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Push |    10 |    338.46 ns |   1.631 ns |     1.446 ns |    338.03 ns |  4.64 |    0.04 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Pull |    10 |    312.13 ns |   3.111 ns |     2.429 ns |    311.57 ns |  4.28 |    0.04 |  0.0725 |     - |     - |     152 B |
|        ValueLinq_ValueLambda_Standard |    10 |    204.92 ns |   4.173 ns |     6.857 ns |    201.14 ns |  2.91 |    0.10 |  0.0725 |     - |     - |     152 B |
|           ValueLinq_ValueLambda_Stack |    10 |    167.22 ns |   1.854 ns |     1.643 ns |    167.02 ns |  2.30 |    0.03 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |    374.17 ns |   3.150 ns |     2.630 ns |    373.32 ns |  5.13 |    0.04 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |    337.91 ns |   2.004 ns |     1.777 ns |    337.58 ns |  4.64 |    0.05 |  0.0725 |     - |     - |     152 B |
|                               ForLoop |    10 |     72.90 ns |   0.731 ns |     0.610 ns |     72.76 ns |  1.00 |    0.00 |  0.2218 |     - |     - |     464 B |
|                           ForeachLoop |    10 |     94.10 ns |   0.916 ns |     0.857 ns |     94.41 ns |  1.29 |    0.01 |  0.2218 |     - |     - |     464 B |
|                                  Linq |    10 |    169.41 ns |   2.595 ns |     2.427 ns |    168.58 ns |  2.33 |    0.05 |  0.3097 |     - |     - |     648 B |
|                            LinqFaster |    10 |    103.27 ns |   2.255 ns |     6.650 ns |     99.44 ns |  1.44 |    0.08 |  0.3901 |     - |     - |     816 B |
|                                LinqAF |    10 |    256.21 ns |   4.184 ns |     3.913 ns |    256.58 ns |  3.51 |    0.05 |  0.2065 |     - |     - |     432 B |
|                            StructLinq |    10 |    152.95 ns |   0.988 ns |     0.876 ns |    153.08 ns |  2.10 |    0.02 |  0.1185 |     - |     - |     248 B |
|                  StructLinq_IFunction |    10 |    119.38 ns |   1.075 ns |     0.953 ns |    119.12 ns |  1.64 |    0.02 |  0.0725 |     - |     - |     152 B |
|                             Hyperlinq |    10 |    168.70 ns |   3.425 ns |     7.517 ns |    163.92 ns |  2.28 |    0.09 |  0.0725 |     - |     - |     152 B |
|                   Hyperlinq_IFunction |    10 |    136.71 ns |   1.890 ns |     1.578 ns |    136.23 ns |  1.88 |    0.02 |  0.0725 |     - |     - |     152 B |
|                                       |       |              |            |              |              |       |         |         |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **15,181.90 ns** |  **86.472 ns** |   **178.580 ns** | **15,176.44 ns** |  **1.11** |    **0.02** | **30.2887** |     **-** |     **-** |  **64,080 B** |
|                       ValueLinq_Stack |  1000 | 16,293.63 ns | 410.963 ns | 1,211.733 ns | 15,697.43 ns |  1.26 |    0.08 | 30.2734 |     - |     - |  64,080 B |
|             ValueLinq_SharedPool_Push |  1000 | 17,695.03 ns | 206.842 ns |   161.489 ns | 17,689.81 ns |  1.29 |    0.02 | 15.1367 |     - |     - |  32,216 B |
|             ValueLinq_SharedPool_Pull |  1000 | 16,443.40 ns | 115.291 ns |   102.203 ns | 16,446.38 ns |  1.20 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                ValueLinq_Ref_Standard |  1000 | 15,398.00 ns | 228.551 ns |   213.787 ns | 15,431.47 ns |  1.13 |    0.02 | 30.2734 |     - |     - |  64,080 B |
|                   ValueLinq_Ref_Stack |  1000 | 15,241.74 ns | 302.347 ns |   296.945 ns | 15,164.66 ns |  1.12 |    0.03 | 30.2734 |     - |     - |  64,080 B |
|         ValueLinq_Ref_SharedPool_Push |  1000 | 15,656.52 ns |  89.634 ns |    74.848 ns | 15,664.42 ns |  1.14 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|         ValueLinq_Ref_SharedPool_Pull |  1000 | 15,641.15 ns | 349.715 ns | 1,031.143 ns | 15,077.92 ns |  1.16 |    0.09 | 15.1367 |     - |     - |  32,216 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 17,870.18 ns | 150.534 ns |   140.809 ns | 17,838.05 ns |  1.31 |    0.02 | 30.2734 |     - |     - |  64,080 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 15,537.42 ns | 305.435 ns |   363.598 ns | 15,702.21 ns |  1.14 |    0.04 | 30.2734 |     - |     - |  64,080 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 14,926.48 ns | 137.900 ns |   128.992 ns | 14,919.07 ns |  1.09 |    0.02 | 15.1367 |     - |     - |  32,216 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 16,621.55 ns | 381.147 ns | 1,123.820 ns | 16,132.82 ns |  1.25 |    0.09 | 15.1367 |     - |     - |  32,216 B |
|                               ForLoop |  1000 | 13,666.20 ns | 111.433 ns |   170.170 ns | 13,690.75 ns |  1.00 |    0.00 | 46.5088 |     - |     - |  97,720 B |
|                           ForeachLoop |  1000 | 15,489.90 ns | 125.852 ns |   180.493 ns | 15,494.76 ns |  1.13 |    0.02 | 46.5088 |     - |     - |  97,720 B |
|                                  Linq |  1000 | 17,047.14 ns | 316.564 ns |   296.114 ns | 17,157.82 ns |  1.25 |    0.03 | 31.2195 |     - |     - |  65,792 B |
|                            LinqFaster |  1000 | 14,885.75 ns | 343.940 ns | 1,014.115 ns | 14,297.41 ns |  1.13 |    0.08 | 45.4407 |     - |     - |  96,240 B |
|                                LinqAF |  1000 | 32,987.03 ns | 564.897 ns |   528.405 ns | 32,964.57 ns |  2.41 |    0.05 | 46.5088 |     - |     - |  97,688 B |
|                            StructLinq |  1000 | 15,431.64 ns | 124.720 ns |   110.561 ns | 15,422.82 ns |  1.13 |    0.01 | 15.3809 |     - |     - |  32,312 B |
|                  StructLinq_IFunction |  1000 | 11,409.61 ns |  81.404 ns |   202.724 ns | 11,355.09 ns |  0.84 |    0.02 | 15.1367 |     - |     - |  32,216 B |
|                             Hyperlinq |  1000 | 17,718.71 ns | 384.408 ns | 1,133.434 ns | 17,060.36 ns |  1.33 |    0.08 | 15.1367 |     - |     - |  32,216 B |
|                   Hyperlinq_IFunction |  1000 | 12,210.72 ns | 243.383 ns |   690.436 ns | 11,920.68 ns |  0.94 |    0.06 | 15.1367 |     - |     - |  32,216 B |
