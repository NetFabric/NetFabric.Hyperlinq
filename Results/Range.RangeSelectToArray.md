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

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                                Method | Start | Count |        Mean |     Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |------------:|----------:|-----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |     **0** |    **10** |   **108.09 ns** |  **0.454 ns** |   **0.402 ns** |   **108.00 ns** | **10.42** |    **0.10** | **0.0305** |     **-** |     **-** |      **64 B** |
|                       ValueLinq_Stack |     0 |    10 |    97.94 ns |  0.642 ns |   0.570 ns |    97.83 ns |  9.44 |    0.12 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Push |     0 |    10 |   329.50 ns |  1.824 ns |   1.706 ns |   329.66 ns | 31.75 |    0.31 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Pull |     0 |    10 |   216.94 ns |  0.887 ns |   0.741 ns |   216.98 ns | 20.91 |    0.21 | 0.0305 |     - |     - |      64 B |
|        ValueLinq_ValueLambda_Standard |     0 |    10 |   103.94 ns |  2.142 ns |   3.205 ns |   105.59 ns |  9.74 |    0.26 | 0.0304 |     - |     - |      64 B |
|           ValueLinq_ValueLambda_Stack |     0 |    10 |    79.60 ns |  0.513 ns |   0.480 ns |    79.43 ns |  7.68 |    0.07 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |    10 |   228.97 ns |  2.223 ns |   1.970 ns |   228.20 ns | 22.03 |    0.24 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |    10 |   207.07 ns |  3.872 ns |   3.432 ns |   208.56 ns | 20.01 |    0.40 | 0.0305 |     - |     - |      64 B |
|                               ForLoop |     0 |    10 |    10.37 ns |  0.105 ns |   0.087 ns |    10.34 ns |  1.00 |    0.00 | 0.0306 |     - |     - |      64 B |
|                                  Linq |     0 |    10 |    67.44 ns |  1.424 ns |   3.922 ns |    64.82 ns |  6.51 |    0.30 | 0.0726 |     - |     - |     152 B |
|                            LinqFaster |     0 |    10 |    40.25 ns |  0.885 ns |   2.609 ns |    39.29 ns |  3.72 |    0.13 | 0.0612 |     - |     - |     128 B |
|                       LinqFaster_SIMD |     0 |    10 |    30.87 ns |  0.174 ns |   0.154 ns |    30.87 ns |  2.98 |    0.03 | 0.0612 |     - |     - |     128 B |
|                                LinqAF |     0 |    10 |   157.11 ns |  1.076 ns |   0.954 ns |   156.99 ns | 15.14 |    0.11 | 0.1185 |     - |     - |     248 B |
|                            StructLinq |     0 |    10 |    46.35 ns |  0.393 ns |   0.348 ns |    46.29 ns |  4.46 |    0.05 | 0.0573 |     - |     - |     120 B |
|                  StructLinq_IFunction |     0 |    10 |    35.45 ns |  0.273 ns |   0.256 ns |    35.45 ns |  3.42 |    0.04 | 0.0305 |     - |     - |      64 B |
|                             Hyperlinq |     0 |    10 |    50.00 ns |  0.222 ns |   0.196 ns |    49.99 ns |  4.82 |    0.04 | 0.0306 |     - |     - |      64 B |
|                   Hyperlinq_IFunction |     0 |    10 |    43.15 ns |  0.285 ns |   0.267 ns |    43.16 ns |  4.17 |    0.04 | 0.0305 |     - |     - |      64 B |
|                        Hyperlinq_SIMD |     0 |    10 |    39.59 ns |  0.180 ns |   0.159 ns |    39.59 ns |  3.81 |    0.04 | 0.0305 |     - |     - |      64 B |
|              Hyperlinq_IFunction_SIMD |     0 |    10 |    32.33 ns |  0.250 ns |   0.234 ns |    32.27 ns |  3.12 |    0.03 | 0.0305 |     - |     - |      64 B |
|                                       |       |       |             |           |            |             |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |     **0** |  **1000** | **1,968.22 ns** | **10.637 ns** |   **9.429 ns** | **1,967.65 ns** |  **2.12** |    **0.02** | **1.9226** |     **-** |     **-** |   **4,024 B** |
|                       ValueLinq_Stack |     0 |  1000 | 4,009.09 ns | 21.010 ns |  19.653 ns | 4,004.04 ns |  4.33 |    0.04 | 3.9139 |     - |     - |   8,200 B |
|             ValueLinq_SharedPool_Push |     0 |  1000 | 3,697.32 ns | 50.764 ns |  45.001 ns | 3,703.23 ns |  3.99 |    0.05 | 1.9226 |     - |     - |   4,024 B |
|             ValueLinq_SharedPool_Pull |     0 |  1000 | 3,806.87 ns | 15.118 ns |  12.624 ns | 3,807.80 ns |  4.10 |    0.04 | 1.9226 |     - |     - |   4,024 B |
|        ValueLinq_ValueLambda_Standard |     0 |  1000 | 2,139.47 ns | 15.767 ns |  14.749 ns | 2,133.29 ns |  2.31 |    0.03 | 1.9226 |     - |     - |   4,024 B |
|           ValueLinq_ValueLambda_Stack |     0 |  1000 | 2,711.36 ns | 60.006 ns | 176.929 ns | 2,628.53 ns |  2.83 |    0.15 | 3.9177 |     - |     - |   8,200 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |  1000 | 2,507.04 ns | 15.325 ns |  13.585 ns | 2,506.79 ns |  2.70 |    0.03 | 1.9226 |     - |     - |   4,024 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |  1000 | 2,439.04 ns | 29.553 ns |  26.198 ns | 2,433.57 ns |  2.63 |    0.04 | 1.9226 |     - |     - |   4,024 B |
|                               ForLoop |     0 |  1000 |   926.85 ns |  8.145 ns |   7.618 ns |   923.16 ns |  1.00 |    0.00 | 1.9226 |     - |     - |   4,024 B |
|                                  Linq |     0 |  1000 | 2,151.03 ns | 18.447 ns |  17.255 ns | 2,148.44 ns |  2.32 |    0.02 | 1.9646 |     - |     - |   4,112 B |
|                            LinqFaster |     0 |  1000 | 2,603.30 ns | 17.701 ns |  14.781 ns | 2,598.80 ns |  2.81 |    0.03 | 3.8452 |     - |     - |   8,048 B |
|                       LinqFaster_SIMD |     0 |  1000 |   853.68 ns | 11.630 ns |  10.879 ns |   855.00 ns |  0.92 |    0.01 | 3.8452 |     - |     - |   8,048 B |
|                                LinqAF |     0 |  1000 | 7,151.82 ns | 65.903 ns |  58.421 ns | 7,139.76 ns |  7.71 |    0.05 | 5.9280 |     - |     - |  12,416 B |
|                            StructLinq |     0 |  1000 | 2,339.38 ns | 13.597 ns |  12.053 ns | 2,339.64 ns |  2.52 |    0.03 | 1.9493 |     - |     - |   4,080 B |
|                  StructLinq_IFunction |     0 |  1000 |   786.90 ns |  6.578 ns |   6.153 ns |   787.71 ns |  0.85 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|                             Hyperlinq |     0 |  1000 | 2,012.51 ns | 13.828 ns |  12.258 ns | 2,009.47 ns |  2.17 |    0.03 | 1.9226 |     - |     - |   4,024 B |
|                   Hyperlinq_IFunction |     0 |  1000 |   988.94 ns | 13.826 ns |  11.545 ns |   985.32 ns |  1.07 |    0.02 | 1.9226 |     - |     - |   4,024 B |
|                        Hyperlinq_SIMD |     0 |  1000 |   579.50 ns |  8.924 ns |   8.347 ns |   579.32 ns |  0.63 |    0.01 | 1.9150 |     - |     - |   4,024 B |
|              Hyperlinq_IFunction_SIMD |     0 |  1000 |   283.23 ns |  4.529 ns |   4.237 ns |   284.95 ns |  0.31 |    0.01 | 1.9155 |     - |     - |   4,024 B |
