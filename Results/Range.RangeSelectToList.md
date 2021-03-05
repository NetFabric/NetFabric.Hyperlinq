## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                                Method | Start | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |     **0** |    **10** |   **104.11 ns** |  **0.334 ns** |  **0.296 ns** |  **1.64** |    **0.01** | **0.0459** |     **-** |     **-** |      **96 B** |
|                       ValueLinq_Stack |     0 |    10 |   117.57 ns |  0.269 ns |  0.224 ns |  1.85 |    0.01 | 0.0458 |     - |     - |      96 B |
|             ValueLinq_SharedPool_Push |     0 |    10 |   325.70 ns |  0.621 ns |  0.551 ns |  5.13 |    0.04 | 0.0458 |     - |     - |      96 B |
|             ValueLinq_SharedPool_Pull |     0 |    10 |   226.42 ns |  0.439 ns |  0.389 ns |  3.56 |    0.02 | 0.0458 |     - |     - |      96 B |
|        ValueLinq_ValueLambda_Standard |     0 |    10 |    99.47 ns |  0.239 ns |  0.212 ns |  1.57 |    0.01 | 0.0459 |     - |     - |      96 B |
|           ValueLinq_ValueLambda_Stack |     0 |    10 |   104.52 ns |  0.357 ns |  0.317 ns |  1.65 |    0.01 | 0.0459 |     - |     - |      96 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |    10 |   240.32 ns |  0.785 ns |  0.656 ns |  3.78 |    0.02 | 0.0458 |     - |     - |      96 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |    10 |   215.54 ns |  0.431 ns |  0.382 ns |  3.39 |    0.02 | 0.0458 |     - |     - |      96 B |
|                               ForLoop |     0 |    10 |    63.53 ns |  0.485 ns |  0.430 ns |  1.00 |    0.00 | 0.1032 |     - |     - |     216 B |
|                           ForeachLoop |     0 |    10 |   129.84 ns |  0.601 ns |  0.502 ns |  2.04 |    0.02 | 0.1299 |     - |     - |     272 B |
|                                  Linq |     0 |    10 |    71.53 ns |  0.238 ns |  0.199 ns |  1.13 |    0.01 | 0.0879 |     - |     - |     184 B |
|                            LinqFaster |     0 |    10 |    64.41 ns |  0.243 ns |  0.227 ns |  1.01 |    0.01 | 0.1070 |     - |     - |     224 B |
|                                LinqAF |     0 |    10 |   154.01 ns |  0.964 ns |  0.902 ns |  2.43 |    0.03 | 0.1032 |     - |     - |     216 B |
|                            StructLinq |     0 |    10 |    54.30 ns |  0.169 ns |  0.150 ns |  0.85 |    0.01 | 0.0726 |     - |     - |     152 B |
|                  StructLinq_IFunction |     0 |    10 |    36.42 ns |  0.104 ns |  0.092 ns |  0.57 |    0.00 | 0.0458 |     - |     - |      96 B |
|                             Hyperlinq |     0 |    10 |    56.84 ns |  0.319 ns |  0.283 ns |  0.89 |    0.01 | 0.0459 |     - |     - |      96 B |
|                   Hyperlinq_IFunction |     0 |    10 |    45.06 ns |  0.113 ns |  0.100 ns |  0.71 |    0.00 | 0.0458 |     - |     - |      96 B |
|                        Hyperlinq_SIMD |     0 |    10 |    50.45 ns |  0.172 ns |  0.144 ns |  0.79 |    0.01 | 0.0458 |     - |     - |      96 B |
|              Hyperlinq_IFunction_SIMD |     0 |    10 |    34.43 ns |  0.121 ns |  0.107 ns |  0.54 |    0.00 | 0.0458 |     - |     - |      96 B |
|                                       |       |       |             |           |           |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |     **0** |  **1000** | **2,946.55 ns** | **11.605 ns** | **10.288 ns** |  **1.38** |    **0.01** | **1.9379** |     **-** |     **-** |   **4,056 B** |
|                       ValueLinq_Stack |     0 |  1000 | 3,755.37 ns |  9.549 ns |  8.465 ns |  1.75 |    0.01 | 3.9330 |     - |     - |   8,232 B |
|             ValueLinq_SharedPool_Push |     0 |  1000 | 3,276.28 ns | 12.632 ns | 11.198 ns |  1.53 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|             ValueLinq_SharedPool_Pull |     0 |  1000 | 3,743.42 ns | 10.854 ns |  9.064 ns |  1.75 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|        ValueLinq_ValueLambda_Standard |     0 |  1000 | 2,192.57 ns | 13.304 ns | 11.110 ns |  1.02 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|           ValueLinq_ValueLambda_Stack |     0 |  1000 | 2,636.43 ns | 16.642 ns | 14.752 ns |  1.23 |    0.01 | 3.9330 |     - |     - |   8,232 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |  1000 | 2,430.60 ns | 11.330 ns | 10.598 ns |  1.14 |    0.01 | 1.9379 |     - |     - |   4,056 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |  1000 | 2,434.46 ns |  7.175 ns |  6.360 ns |  1.14 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|                               ForLoop |     0 |  1000 | 2,139.42 ns |  9.674 ns |  9.049 ns |  1.00 |    0.00 | 4.0207 |     - |     - |   8,424 B |
|                           ForeachLoop |     0 |  1000 | 6,484.27 ns | 22.309 ns | 19.776 ns |  3.03 |    0.01 | 4.0436 |     - |     - |   8,480 B |
|                                  Linq |     0 |  1000 | 2,355.99 ns | 10.441 ns |  9.767 ns |  1.10 |    0.01 | 1.9798 |     - |     - |   4,144 B |
|                            LinqFaster |     0 |  1000 | 2,898.31 ns |  5.826 ns |  5.450 ns |  1.35 |    0.01 | 5.7793 |     - |     - |  12,104 B |
|                                LinqAF |     0 |  1000 | 6,063.31 ns | 12.876 ns | 10.053 ns |  2.83 |    0.01 | 4.0207 |     - |     - |   8,424 B |
|                            StructLinq |     0 |  1000 | 2,062.44 ns | 16.171 ns | 13.504 ns |  0.96 |    0.01 | 1.9646 |     - |     - |   4,112 B |
|                  StructLinq_IFunction |     0 |  1000 |   731.82 ns |  3.641 ns |  3.406 ns |  0.34 |    0.00 | 1.9379 |     - |     - |   4,056 B |
|                             Hyperlinq |     0 |  1000 | 2,077.33 ns |  6.847 ns |  6.070 ns |  0.97 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|                   Hyperlinq_IFunction |     0 |  1000 | 1,264.82 ns |  8.019 ns |  7.109 ns |  0.59 |    0.00 | 1.9379 |     - |     - |   4,056 B |
|                        Hyperlinq_SIMD |     0 |  1000 |   576.90 ns |  2.450 ns |  2.046 ns |  0.27 |    0.00 | 1.9341 |     - |     - |   4,056 B |
|              Hyperlinq_IFunction_SIMD |     0 |  1000 |   318.52 ns |  0.969 ns |  0.906 ns |  0.15 |    0.00 | 1.9341 |     - |     - |   4,056 B |
