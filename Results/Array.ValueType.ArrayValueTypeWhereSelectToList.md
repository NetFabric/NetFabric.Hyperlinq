## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|               Method |    Job |  Runtime | Count |         Mean |      Error |     StdDev |       Median |    Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |-------------:|-----------:|-----------:|-------------:|---------:|--------:|--------:|--------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |     **50.76 ns** |   **0.479 ns** |   **0.448 ns** |     **50.86 ns** |     **1.00** |    **0.00** |  **0.1492** |       **-** |     **-** |     **312 B** |
|          ForeachLoop | .NET 5 | .NET 5.0 |    10 |     64.99 ns |   1.158 ns |   1.083 ns |     65.00 ns |     1.28 |    0.03 |  0.1491 |       - |     - |     312 B |
|                 Linq | .NET 5 | .NET 5.0 |    10 |    133.54 ns |   1.480 ns |   1.384 ns |    133.76 ns |     2.63 |    0.04 |  0.2525 |       - |     - |     528 B |
|           LinqFaster | .NET 5 | .NET 5.0 |    10 |    132.42 ns |   0.925 ns |   0.820 ns |    132.33 ns |     2.61 |    0.03 |  0.4780 |       - |     - |   1,000 B |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |    233.99 ns |   4.050 ns |   3.789 ns |    232.44 ns |     4.61 |    0.09 |  0.1490 |       - |     - |     312 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 54,497.86 ns | 218.636 ns | 170.697 ns | 54,449.41 ns | 1,070.09 |    6.53 | 68.9697 | 17.2119 |     - | 154,321 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    481.22 ns |   2.188 ns |   2.047 ns |    481.24 ns |     9.48 |    0.10 |  0.4091 |       - |     - |     856 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |    166.74 ns |   0.901 ns |   0.799 ns |    166.82 ns |     3.28 |    0.04 |  0.1338 |       - |     - |     280 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |    126.38 ns |   1.889 ns |   1.578 ns |    126.83 ns |     2.49 |    0.04 |  0.0880 |       - |     - |     184 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |    160.20 ns |   2.110 ns |   1.974 ns |    159.91 ns |     3.16 |    0.06 |  0.0880 |       - |     - |     184 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |    10 |    142.02 ns |   1.446 ns |   1.353 ns |    142.94 ns |     2.80 |    0.05 |  0.0880 |       - |     - |     184 B |
|                      |        |          |       |              |            |            |              |          |         |         |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |    10 |     51.03 ns |   0.468 ns |   0.390 ns |     51.04 ns |     1.00 |    0.00 |  0.1492 |       - |     - |     312 B |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |     60.26 ns |   0.808 ns |   0.756 ns |     60.18 ns |     1.18 |    0.02 |  0.1491 |       - |     - |     312 B |
|                 Linq | .NET 6 | .NET 6.0 |    10 |    126.76 ns |   1.859 ns |   1.739 ns |    126.47 ns |     2.49 |    0.04 |  0.2525 |       - |     - |     528 B |
|           LinqFaster | .NET 6 | .NET 6.0 |    10 |    124.98 ns |   0.977 ns |   0.763 ns |    124.87 ns |     2.45 |    0.02 |  0.4780 |       - |     - |   1,000 B |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |    235.94 ns |   4.693 ns |   6.730 ns |    235.78 ns |     4.62 |    0.15 |  0.1490 |       - |     - |     312 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 50,836.48 ns | 225.570 ns | 199.962 ns | 50,830.92 ns |   996.58 |    9.22 | 70.4956 |  3.1128 |     - | 154,067 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    502.56 ns |   2.130 ns |   1.779 ns |    502.58 ns |     9.85 |    0.08 |  0.4091 |       - |     - |     856 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |    150.78 ns |   0.832 ns |   0.779 ns |    150.53 ns |     2.95 |    0.02 |  0.1338 |       - |     - |     280 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |    120.22 ns |   0.757 ns |   0.591 ns |    120.17 ns |     2.36 |    0.01 |  0.0880 |       - |     - |     184 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |    159.26 ns |   1.800 ns |   1.684 ns |    159.57 ns |     3.12 |    0.03 |  0.0880 |       - |     - |     184 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |    10 |    143.49 ns |   1.460 ns |   1.219 ns |    143.38 ns |     2.81 |    0.03 |  0.0880 |       - |     - |     184 B |
|                      |        |          |       |              |            |            |              |          |         |         |         |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** | **11,372.40 ns** |  **33.991 ns** |  **30.132 ns** | **11,373.51 ns** |     **1.00** |    **0.00** | **10.4218** |  **5.2032** |     **-** |  **65,504 B** |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 | 13,015.17 ns |  47.486 ns |  44.419 ns | 13,027.42 ns |     1.14 |    0.01 | 10.4218 |  5.2032 |     - |  65,504 B |
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 16,205.63 ns | 212.500 ns | 165.906 ns | 16,165.71 ns |     1.43 |    0.02 | 10.4370 |  5.2185 |     - |  65,720 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 | 17,544.13 ns |  73.320 ns |  68.584 ns | 17,563.07 ns |     1.54 |    0.01 | 20.4163 | 10.1929 |     - | 128,488 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 25,202.30 ns | 344.490 ns | 322.236 ns | 25,111.34 ns |     2.22 |    0.03 | 31.2195 |       - |     - |  65,504 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 74,325.95 ns | 259.518 ns | 216.709 ns | 74,357.91 ns |     6.54 |    0.03 | 78.3691 | 19.5313 |     - | 218,460 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 61,883.57 ns | 268.871 ns | 238.347 ns | 61,883.07 ns |     5.44 |    0.03 | 10.4980 |  5.2490 |     - |  66,048 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 | 14,820.99 ns | 119.531 ns | 111.810 ns | 14,781.35 ns |     1.30 |    0.01 |  5.1270 |  2.5635 |     - |  32,344 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 10,982.34 ns |  75.505 ns |  70.627 ns | 10,975.71 ns |     0.96 |    0.01 |  5.1270 |  2.5635 |     - |  32,248 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 | 15,669.27 ns | 164.680 ns | 154.042 ns | 15,625.82 ns |     1.38 |    0.01 |  5.1270 |  2.5635 |     - |  32,248 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 11,619.02 ns |  79.737 ns |  74.586 ns | 11,632.54 ns |     1.02 |    0.01 | 15.3503 |       - |     - |  32,248 B |
|                      |        |          |       |              |            |            |              |          |         |         |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 | 11,401.90 ns |  27.941 ns |  26.136 ns | 11,402.81 ns |     1.00 |    0.00 | 10.4218 |  5.2032 |     - |  65,504 B |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 | 13,009.63 ns |  34.911 ns |  29.152 ns | 13,007.74 ns |     1.14 |    0.00 | 10.4218 |  5.2032 |     - |  65,504 B |
|                 Linq | .NET 6 | .NET 6.0 |  1000 | 15,465.56 ns | 303.727 ns | 836.553 ns | 15,030.91 ns |     1.45 |    0.06 | 31.2195 |       - |     - |  65,720 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 | 18,197.08 ns |  53.222 ns |  47.180 ns | 18,211.24 ns |     1.60 |    0.01 | 20.4163 | 10.1929 |     - | 128,488 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 25,737.48 ns | 486.292 ns | 499.386 ns | 25,689.93 ns |     2.26 |    0.05 | 31.2195 |       - |     - |  65,504 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 70,598.63 ns | 476.103 ns | 445.347 ns | 70,489.12 ns |     6.19 |    0.04 | 74.2188 | 18.5547 |     - | 218,200 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 61,529.42 ns | 288.993 ns | 256.184 ns | 61,475.80 ns |     5.40 |    0.02 | 10.4980 |  5.2490 |     - |  66,048 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 | 14,148.70 ns | 109.582 ns | 102.503 ns | 14,154.92 ns |     1.24 |    0.01 |  5.1270 |  2.5635 |     - |  32,344 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 15,157.23 ns |  44.187 ns |  39.170 ns | 15,167.68 ns |     1.33 |    0.01 |  5.1270 |  2.5635 |     - |  32,248 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 | 16,988.87 ns | 256.494 ns | 227.376 ns | 17,022.21 ns |     1.49 |    0.02 | 15.3198 |       - |     - |  32,248 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 12,600.97 ns | 141.689 ns | 132.536 ns | 12,565.08 ns |     1.11 |    0.01 |  5.1270 |  2.5635 |     - |  32,248 B |
