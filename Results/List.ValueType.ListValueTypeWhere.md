## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|               Method |    Job |  Runtime | Count |         Mean |        Error |       StdDev |       Median |    Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |-------------:|-------------:|-------------:|-------------:|---------:|--------:|--------:|--------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |     **37.58 ns** |     **0.231 ns** |     **0.205 ns** |     **37.50 ns** |     **1.00** |    **0.00** |       **-** |       **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |    10 |     67.09 ns |     0.451 ns |     0.400 ns |     67.14 ns |     1.79 |    0.01 |       - |       - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |    10 |    142.34 ns |     2.010 ns |     1.880 ns |    142.25 ns |     3.79 |    0.05 |  0.0880 |       - |     - |     184 B |
|           LinqFaster | .NET 5 | .NET 5.0 |    10 |     77.90 ns |     1.604 ns |     4.551 ns |     75.73 ns |     2.18 |    0.10 |  0.1491 |       - |     - |     312 B |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |    224.96 ns |     4.365 ns |     4.287 ns |    225.44 ns |     5.98 |    0.12 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 51,300.42 ns |   661.915 ns | 1,466.759 ns | 51,220.57 ns | 1,378.37 |   60.69 | 71.4111 |       - |     - | 152,118 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    302.29 ns |     2.696 ns |     2.522 ns |    301.79 ns |     8.05 |    0.08 |  0.4053 |       - |     - |     848 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |     59.41 ns |     0.381 ns |     0.297 ns |     59.42 ns |     1.58 |    0.01 |  0.0191 |       - |     - |      40 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |     60.50 ns |     0.231 ns |     0.216 ns |     60.45 ns |     1.61 |    0.01 |       - |       - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |    104.82 ns |     0.233 ns |     0.218 ns |    104.81 ns |     2.79 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |    10 |     79.66 ns |     0.421 ns |     0.329 ns |     79.61 ns |     2.12 |    0.01 |       - |       - |     - |         - |
|                      |        |          |       |              |              |              |              |          |         |         |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |    10 |     38.60 ns |     0.184 ns |     0.163 ns |     38.57 ns |     1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |     67.39 ns |     0.525 ns |     0.439 ns |     67.36 ns |     1.75 |    0.01 |       - |       - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |    10 |    133.94 ns |     2.028 ns |     1.897 ns |    133.91 ns |     3.47 |    0.05 |  0.0880 |       - |     - |     184 B |
|           LinqFaster | .NET 6 | .NET 6.0 |    10 |     82.83 ns |     1.674 ns |     2.177 ns |     83.52 ns |     2.13 |    0.07 |  0.1491 |       - |     - |     312 B |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |    229.17 ns |     4.565 ns |     4.270 ns |    230.40 ns |     5.93 |    0.12 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 46,994.87 ns |   323.165 ns |   302.288 ns | 46,989.43 ns | 1,217.57 |    9.81 | 71.4111 |       - |     - | 151,678 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    315.93 ns |     2.381 ns |     1.988 ns |    316.41 ns |     8.18 |    0.05 |  0.4053 |       - |     - |     848 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |     57.71 ns |     0.681 ns |     0.568 ns |     57.59 ns |     1.49 |    0.01 |  0.0191 |       - |     - |      40 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |     57.37 ns |     0.293 ns |     0.274 ns |     57.32 ns |     1.49 |    0.01 |       - |       - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |    103.51 ns |     0.369 ns |     0.346 ns |    103.44 ns |     2.68 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |    10 |     75.23 ns |     0.227 ns |     0.189 ns |     75.26 ns |     1.95 |    0.01 |       - |       - |     - |         - |
|                      |        |          |       |              |              |              |              |          |         |         |         |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** |  **6,051.74 ns** |    **25.167 ns** |    **21.015 ns** |  **6,054.56 ns** |     **1.00** |    **0.00** |       **-** |       **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  8,877.23 ns |    38.816 ns |    34.410 ns |  8,892.07 ns |     1.47 |    0.01 |       - |       - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 16,131.25 ns |   193.056 ns |   171.139 ns | 16,122.42 ns |     2.66 |    0.03 |  0.0610 |       - |     - |     184 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 | 17,310.89 ns |   180.060 ns |   320.056 ns | 17,261.88 ns |     2.90 |    0.05 | 31.2195 |       - |     - |  65,504 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 21,237.09 ns |   304.952 ns |   285.252 ns | 21,276.82 ns |     3.51 |    0.05 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 90,532.54 ns | 1,082.671 ns |   959.759 ns | 90,169.42 ns |    14.98 |    0.16 | 79.8340 | 19.8975 |     - | 184,191 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 22,667.49 ns |    69.732 ns |    61.816 ns | 22,665.37 ns |     3.75 |    0.01 |  0.3967 |       - |     - |     848 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  7,968.90 ns |    88.270 ns |    82.568 ns |  7,924.54 ns |     1.32 |    0.01 |  0.0153 |       - |     - |      40 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  6,676.74 ns |    41.928 ns |    35.012 ns |  6,681.85 ns |     1.10 |    0.00 |       - |       - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 | 14,731.85 ns |    33.454 ns |    26.119 ns | 14,731.84 ns |     2.43 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  8,535.86 ns |    37.973 ns |    33.662 ns |  8,532.28 ns |     1.41 |    0.01 |       - |       - |     - |         - |
|                      |        |          |       |              |              |              |              |          |         |         |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |  6,711.14 ns |    28.721 ns |    25.460 ns |  6,710.14 ns |     1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 | 10,008.15 ns |    31.296 ns |    27.743 ns | 10,006.17 ns |     1.49 |    0.01 |       - |       - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 | 15,483.02 ns |   167.433 ns |   148.425 ns | 15,514.64 ns |     2.31 |    0.03 |  0.0610 |       - |     - |     184 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 | 15,079.27 ns |   233.074 ns |   341.637 ns | 14,980.34 ns |     2.27 |    0.06 | 31.2347 |       - |     - |  65,504 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 21,109.24 ns |   365.266 ns |   341.670 ns | 21,197.12 ns |     3.15 |    0.05 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 75,639.93 ns | 1,961.188 ns | 5,782.608 ns | 72,525.05 ns |    11.33 |    0.81 | 86.9141 |       - |     - | 183,759 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 21,523.60 ns |   379.865 ns |   355.326 ns | 21,407.16 ns |     3.21 |    0.06 |  0.3967 |       - |     - |     848 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  6,606.07 ns |    20.764 ns |    19.422 ns |  6,613.90 ns |     0.98 |    0.01 |  0.0153 |       - |     - |      40 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  5,457.97 ns |    15.226 ns |    13.498 ns |  5,450.74 ns |     0.81 |    0.00 |       - |       - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 | 12,311.41 ns |    33.877 ns |    30.031 ns | 12,311.77 ns |     1.83 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  8,518.49 ns |    47.218 ns |    44.167 ns |  8,511.95 ns |     1.27 |    0.01 |       - |       - |     - |         - |
