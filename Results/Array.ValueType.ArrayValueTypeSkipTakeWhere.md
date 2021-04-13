## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|               Method |    Job |  Runtime | Skip | Count |         Mean |        Error |       StdDev |       Median |    Ratio | RatioSD |    Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |----- |------ |-------------:|-------------:|-------------:|-------------:|---------:|--------:|---------:|--------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** | **1000** |    **10** |     **51.13 ns** |     **0.143 ns** |     **0.134 ns** |     **51.10 ns** |     **1.00** |    **0.00** |        **-** |       **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 | 1000 |    10 |  2,452.53 ns |    12.540 ns |    11.116 ns |  2,450.13 ns |    47.96 |    0.26 |   0.0153 |       - |     - |      32 B |
|                 Linq | .NET 5 | .NET 5.0 | 1000 |    10 |    280.27 ns |     1.794 ns |     1.678 ns |    279.59 ns |     5.48 |    0.04 |   0.1526 |       - |     - |     320 B |
|           LinqFaster | .NET 5 | .NET 5.0 | 1000 |    10 |    225.47 ns |     1.743 ns |     1.630 ns |    225.53 ns |     4.41 |    0.03 |   1.1170 |       - |     - |   2,336 B |
|               LinqAF | .NET 5 | .NET 5.0 | 1000 |    10 |  4,937.16 ns |    91.073 ns |   118.420 ns |  4,956.89 ns |    96.65 |    2.64 |        - |       - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |    10 | 56,139.51 ns |   308.172 ns |   288.264 ns | 56,118.76 ns | 1,097.92 |    6.62 |  74.0356 |       - |     - | 155,303 B |
|              Streams | .NET 5 | .NET 5.0 | 1000 |    10 |  6,839.03 ns |    24.080 ns |    18.800 ns |  6,830.65 ns |   133.69 |    0.51 |   0.5493 |       - |     - |   1,152 B |
|           StructLinq | .NET 5 | .NET 5.0 | 1000 |    10 |    120.21 ns |     0.722 ns |     0.675 ns |    120.39 ns |     2.35 |    0.02 |   0.0458 |       - |     - |      96 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |    10 |     87.40 ns |     0.349 ns |     0.327 ns |     87.30 ns |     1.71 |    0.01 |        - |       - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 | 1000 |    10 |    140.46 ns |     1.391 ns |     1.301 ns |    140.58 ns |     2.75 |    0.03 |        - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 | 1000 |    10 |    117.92 ns |     0.954 ns |     0.892 ns |    117.99 ns |     2.31 |    0.02 |        - |       - |     - |         - |
|                      |        |          |      |       |              |              |              |              |          |         |          |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 | 1000 |    10 |     50.84 ns |     0.112 ns |     0.104 ns |     50.88 ns |     1.00 |    0.00 |        - |       - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 | 1000 |    10 |  1,504.96 ns |     4.224 ns |     3.951 ns |  1,503.72 ns |    29.60 |    0.06 |   0.0153 |       - |     - |      32 B |
|                 Linq | .NET 6 | .NET 6.0 | 1000 |    10 |    218.52 ns |     1.319 ns |     1.169 ns |    218.61 ns |     4.30 |    0.03 |   0.1528 |       - |     - |     320 B |
|           LinqFaster | .NET 6 | .NET 6.0 | 1000 |    10 |    229.55 ns |     1.956 ns |     1.830 ns |    229.76 ns |     4.52 |    0.03 |   1.1170 |       - |     - |   2,336 B |
|               LinqAF | .NET 6 | .NET 6.0 | 1000 |    10 |  5,175.63 ns |   102.916 ns |   180.249 ns |  5,154.95 ns |   101.00 |    3.67 |        - |       - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |    10 | 52,445.04 ns |   740.235 ns |   656.199 ns | 52,192.88 ns | 1,031.81 |   13.43 |  74.0356 |       - |     - | 155,055 B |
|              Streams | .NET 6 | .NET 6.0 | 1000 |    10 |  6,279.34 ns |    44.373 ns |    41.506 ns |  6,261.16 ns |   123.52 |    0.82 |   0.5493 |       - |     - |   1,152 B |
|           StructLinq | .NET 6 | .NET 6.0 | 1000 |    10 |    120.26 ns |     0.366 ns |     0.342 ns |    120.29 ns |     2.37 |    0.01 |   0.0458 |       - |     - |      96 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |    10 |     85.12 ns |     0.404 ns |     0.378 ns |     85.06 ns |     1.67 |    0.01 |        - |       - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 | 1000 |    10 |    142.75 ns |     1.274 ns |     1.129 ns |    142.54 ns |     2.81 |    0.02 |        - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 | 1000 |    10 |    119.98 ns |     0.788 ns |     0.737 ns |    120.15 ns |     2.36 |    0.02 |        - |       - |     - |         - |
|                      |        |          |      |       |              |              |              |              |          |         |          |         |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** | **1000** |  **1000** |  **5,025.64 ns** |    **20.534 ns** |    **19.208 ns** |  **5,023.76 ns** |     **1.00** |    **0.00** |        **-** |       **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 | 1000 |  1000 |  5,710.79 ns |    22.855 ns |    21.379 ns |  5,697.34 ns |     1.14 |    0.01 |   0.0153 |       - |     - |      32 B |
|                 Linq | .NET 5 | .NET 5.0 | 1000 |  1000 | 20,620.81 ns |    96.667 ns |    90.423 ns | 20,620.12 ns |     4.10 |    0.03 |   0.1526 |       - |     - |     320 B |
|           LinqFaster | .NET 5 | .NET 5.0 | 1000 |  1000 | 21,747.96 ns |   160.375 ns |   142.168 ns | 21,768.12 ns |     4.33 |    0.03 | 105.2551 |       - |     - | 223,520 B |
|               LinqAF | .NET 5 | .NET 5.0 | 1000 |  1000 | 39,608.90 ns | 1,347.072 ns | 3,971.872 ns | 36,925.45 ns |     8.66 |    0.74 |        - |       - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |  1000 | 73,449.61 ns |   633.203 ns |   494.363 ns | 73,302.28 ns |    14.60 |    0.12 |  68.1152 | 22.7051 |     - | 186,401 B |
|              Streams | .NET 5 | .NET 5.0 | 1000 |  1000 | 29,982.10 ns |    97.499 ns |    91.200 ns | 29,988.96 ns |     5.97 |    0.03 |   0.5493 |       - |     - |   1,152 B |
|           StructLinq | .NET 5 | .NET 5.0 | 1000 |  1000 |  7,986.49 ns |    31.385 ns |    29.358 ns |  7,976.45 ns |     1.59 |    0.01 |   0.0458 |       - |     - |      96 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  7,484.85 ns |    28.370 ns |    26.537 ns |  7,476.85 ns |     1.49 |    0.01 |        - |       - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 | 1000 |  1000 | 11,915.85 ns |    39.300 ns |    36.761 ns | 11,919.04 ns |     2.37 |    0.01 |        - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  8,570.50 ns |    70.272 ns |    58.680 ns |  8,583.40 ns |     1.70 |    0.01 |        - |       - |     - |         - |
|                      |        |          |      |       |              |              |              |              |          |         |          |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  6,449.22 ns |    27.304 ns |    21.317 ns |  6,443.09 ns |     1.00 |    0.00 |        - |       - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  4,653.56 ns |    17.393 ns |    16.269 ns |  4,652.53 ns |     0.72 |    0.00 |   0.0153 |       - |     - |      32 B |
|                 Linq | .NET 6 | .NET 6.0 | 1000 |  1000 | 19,062.38 ns |   106.117 ns |    99.262 ns | 19,047.14 ns |     2.96 |    0.02 |   0.1526 |       - |     - |     320 B |
|           LinqFaster | .NET 6 | .NET 6.0 | 1000 |  1000 | 22,128.75 ns |   201.217 ns |   157.097 ns | 22,115.62 ns |     3.43 |    0.03 | 105.2551 |       - |     - | 223,520 B |
|               LinqAF | .NET 6 | .NET 6.0 | 1000 |  1000 | 30,559.77 ns |   439.521 ns |   389.624 ns | 30,603.63 ns |     4.75 |    0.05 |        - |       - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |  1000 | 69,367.52 ns |   389.375 ns |   364.221 ns | 69,372.35 ns |    10.75 |    0.04 |  68.1152 | 22.7051 |     - | 186,153 B |
|              Streams | .NET 6 | .NET 6.0 | 1000 |  1000 | 27,556.18 ns |   117.974 ns |   110.353 ns | 27,553.93 ns |     4.27 |    0.02 |   0.5493 |       - |     - |   1,152 B |
|           StructLinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  6,526.47 ns |    31.211 ns |    27.668 ns |  6,520.76 ns |     1.01 |    0.00 |   0.0458 |       - |     - |      96 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  5,776.37 ns |    22.979 ns |    21.494 ns |  5,773.44 ns |     0.90 |    0.01 |        - |       - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 | 1000 |  1000 | 12,097.74 ns |    81.727 ns |    68.246 ns | 12,108.72 ns |     1.88 |    0.01 |        - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 | 10,407.61 ns |    49.811 ns |    46.593 ns | 10,397.71 ns |     1.61 |    0.01 |        - |       - |     - |         - |
