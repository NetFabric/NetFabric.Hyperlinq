## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta41](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta41)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                                Method | Start | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |     **0** |    **10** |   **109.25 ns** |  **0.793 ns** |  **0.703 ns** |  **9.79** |    **0.12** | **0.0305** |     **-** |     **-** |      **64 B** |
|                       ValueLinq_Stack |     0 |    10 |    95.80 ns |  0.359 ns |  0.300 ns |  8.59 |    0.10 | 0.0304 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Push |     0 |    10 |   321.55 ns |  1.532 ns |  1.358 ns | 28.83 |    0.28 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Pull |     0 |    10 |   217.79 ns |  1.998 ns |  1.771 ns | 19.53 |    0.25 | 0.0305 |     - |     - |      64 B |
|        ValueLinq_ValueLambda_Standard |     0 |    10 |    96.24 ns |  0.552 ns |  0.461 ns |  8.63 |    0.10 | 0.0304 |     - |     - |      64 B |
|           ValueLinq_ValueLambda_Stack |     0 |    10 |    77.79 ns |  0.260 ns |  0.230 ns |  6.97 |    0.07 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |    10 |   233.29 ns |  1.098 ns |  0.973 ns | 20.91 |    0.24 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |    10 |   204.48 ns |  1.069 ns |  0.948 ns | 18.33 |    0.15 | 0.0305 |     - |     - |      64 B |
|                               ForLoop |     0 |    10 |    11.16 ns |  0.125 ns |  0.117 ns |  1.00 |    0.00 | 0.0306 |     - |     - |      64 B |
|                                  Linq |     0 |    10 |    67.06 ns |  0.319 ns |  0.249 ns |  6.01 |    0.08 | 0.0726 |     - |     - |     152 B |
|                            LinqFaster |     0 |    10 |    40.71 ns |  0.199 ns |  0.166 ns |  3.65 |    0.04 | 0.0612 |     - |     - |     128 B |
|                       LinqFaster_SIMD |     0 |    10 |    34.77 ns |  0.255 ns |  0.199 ns |  3.11 |    0.03 | 0.0612 |     - |     - |     128 B |
|                                LinqAF |     0 |    10 |   165.89 ns |  0.908 ns |  0.758 ns | 14.87 |    0.19 | 0.1183 |     - |     - |     248 B |
|                            StructLinq |     0 |    10 |    49.15 ns |  0.418 ns |  0.370 ns |  4.41 |    0.05 | 0.0573 |     - |     - |     120 B |
|                  StructLinq_IFunction |     0 |    10 |    28.52 ns |  0.213 ns |  0.199 ns |  2.56 |    0.03 | 0.0306 |     - |     - |      64 B |
|                             Hyperlinq |     0 |    10 |    50.16 ns |  0.226 ns |  0.189 ns |  4.50 |    0.05 | 0.0305 |     - |     - |      64 B |
|                   Hyperlinq_IFunction |     0 |    10 |    39.12 ns |  0.185 ns |  0.155 ns |  3.51 |    0.04 | 0.0306 |     - |     - |      64 B |
|                        Hyperlinq_SIMD |     0 |    10 |    39.42 ns |  0.197 ns |  0.165 ns |  3.53 |    0.04 | 0.0305 |     - |     - |      64 B |
|              Hyperlinq_IFunction_SIMD |     0 |    10 |    28.89 ns |  0.231 ns |  0.205 ns |  2.59 |    0.03 | 0.0305 |     - |     - |      64 B |
|                                       |       |       |             |           |           |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |     **0** |  **1000** | **2,620.53 ns** | **15.634 ns** | **13.055 ns** |  **2.73** |    **0.03** | **1.9226** |     **-** |     **-** |   **4,024 B** |
|                       ValueLinq_Stack |     0 |  1000 | 4,096.96 ns | 32.023 ns | 26.741 ns |  4.27 |    0.05 | 3.9139 |     - |     - |   8,200 B |
|             ValueLinq_SharedPool_Push |     0 |  1000 | 3,503.58 ns | 25.561 ns | 19.957 ns |  3.66 |    0.03 | 1.9226 |     - |     - |   4,024 B |
|             ValueLinq_SharedPool_Pull |     0 |  1000 | 4,185.85 ns | 23.737 ns | 21.042 ns |  4.37 |    0.04 | 1.9226 |     - |     - |   4,024 B |
|        ValueLinq_ValueLambda_Standard |     0 |  1000 | 2,014.21 ns | 22.947 ns | 20.342 ns |  2.10 |    0.03 | 1.9226 |     - |     - |   4,024 B |
|           ValueLinq_ValueLambda_Stack |     0 |  1000 | 2,703.97 ns | 15.685 ns | 13.097 ns |  2.82 |    0.02 | 3.9177 |     - |     - |   8,200 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |  1000 | 2,622.13 ns | 23.880 ns | 21.169 ns |  2.74 |    0.04 | 1.9226 |     - |     - |   4,024 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |  1000 | 2,522.06 ns | 13.682 ns | 11.425 ns |  2.63 |    0.02 | 1.9226 |     - |     - |   4,024 B |
|                               ForLoop |     0 |  1000 |   958.61 ns |  9.662 ns |  8.565 ns |  1.00 |    0.00 | 1.9226 |     - |     - |   4,024 B |
|                                  Linq |     0 |  1000 | 2,251.76 ns | 12.565 ns | 11.139 ns |  2.35 |    0.03 | 1.9646 |     - |     - |   4,112 B |
|                            LinqFaster |     0 |  1000 | 2,918.12 ns | 18.132 ns | 15.141 ns |  3.04 |    0.03 | 3.8452 |     - |     - |   8,048 B |
|                       LinqFaster_SIMD |     0 |  1000 | 1,006.70 ns | 10.088 ns |  8.424 ns |  1.05 |    0.01 | 3.8452 |     - |     - |   8,048 B |
|                                LinqAF |     0 |  1000 | 6,878.97 ns | 43.133 ns | 36.018 ns |  7.17 |    0.06 | 5.9280 |     - |     - |  12,416 B |
|                            StructLinq |     0 |  1000 | 2,194.83 ns | 14.842 ns | 13.883 ns |  2.29 |    0.02 | 1.9493 |     - |     - |   4,080 B |
|                  StructLinq_IFunction |     0 |  1000 |   849.94 ns |  9.239 ns |  8.642 ns |  0.89 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|                             Hyperlinq |     0 |  1000 | 2,251.92 ns | 13.733 ns | 12.846 ns |  2.35 |    0.02 | 1.9226 |     - |     - |   4,024 B |
|                   Hyperlinq_IFunction |     0 |  1000 | 1,409.75 ns |  6.111 ns |  5.417 ns |  1.47 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|                        Hyperlinq_SIMD |     0 |  1000 |   568.12 ns |  6.196 ns |  5.493 ns |  0.59 |    0.01 | 1.9150 |     - |     - |   4,024 B |
|              Hyperlinq_IFunction_SIMD |     0 |  1000 |   351.14 ns |  3.879 ns |  3.438 ns |  0.37 |    0.01 | 1.9155 |     - |     - |   4,024 B |
