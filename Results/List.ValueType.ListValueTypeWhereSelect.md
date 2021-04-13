## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|               Method |    Job |  Runtime | Count |          Mean |        Error |       StdDev |        Median |    Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |--------------:|-------------:|-------------:|--------------:|---------:|--------:|--------:|--------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |      **49.33 ns** |     **0.166 ns** |     **0.139 ns** |      **49.34 ns** |     **1.00** |    **0.00** |       **-** |       **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |    10 |      83.49 ns |     1.109 ns |     0.926 ns |      83.36 ns |     1.69 |    0.02 |       - |       - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |    10 |     190.40 ns |     2.400 ns |     1.874 ns |     190.33 ns |     3.86 |    0.04 |  0.1798 |       - |     - |     376 B |
|           LinqFaster | .NET 5 | .NET 5.0 |    10 |     117.14 ns |     1.510 ns |     1.338 ns |     117.42 ns |     2.37 |    0.03 |  0.1490 |       - |     - |     312 B |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |     266.50 ns |     5.252 ns |     7.532 ns |     265.39 ns |     5.37 |    0.12 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 |  59,156.17 ns |   446.110 ns |   372.522 ns |  59,229.55 ns | 1,199.10 |    8.59 | 73.1201 |       - |     - | 154,470 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |     600.88 ns |     4.940 ns |     4.379 ns |     600.71 ns |    12.18 |    0.10 |  0.4778 |       - |     - |   1,000 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |      91.97 ns |     0.656 ns |     0.548 ns |      91.70 ns |     1.86 |    0.01 |  0.0343 |       - |     - |      72 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |      92.47 ns |     0.121 ns |     0.101 ns |      92.48 ns |     1.87 |    0.01 |       - |       - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |     133.53 ns |     0.449 ns |     0.398 ns |     133.47 ns |     2.71 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |    10 |     106.22 ns |     0.273 ns |     0.255 ns |     106.29 ns |     2.15 |    0.01 |       - |       - |     - |         - |
|                      |        |          |       |               |              |              |               |          |         |         |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |    10 |      54.57 ns |     0.108 ns |     0.084 ns |      54.59 ns |     1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |      83.81 ns |     0.569 ns |     0.504 ns |      83.86 ns |     1.54 |    0.01 |       - |       - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |    10 |     174.93 ns |     2.454 ns |     2.176 ns |     175.19 ns |     3.21 |    0.04 |  0.1798 |       - |     - |     376 B |
|           LinqFaster | .NET 6 | .NET 6.0 |    10 |     111.24 ns |     2.622 ns |     7.731 ns |     109.92 ns |     2.20 |    0.12 |  0.1490 |       - |     - |     312 B |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |     363.88 ns |     1.471 ns |     1.304 ns |     363.70 ns |     6.66 |    0.02 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 |  53,744.03 ns |   686.802 ns | 1,564.195 ns |  53,213.73 ns |   995.51 |   31.78 | 68.9697 | 17.2119 |     - | 154,017 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |     579.52 ns |     4.164 ns |     3.691 ns |     579.51 ns |    10.62 |    0.07 |  0.4778 |       - |     - |   1,000 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |      91.71 ns |     0.609 ns |     0.540 ns |      91.74 ns |     1.68 |    0.01 |  0.0343 |       - |     - |      72 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |      91.65 ns |     0.456 ns |     0.356 ns |      91.54 ns |     1.68 |    0.01 |       - |       - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |     125.60 ns |     0.376 ns |     0.333 ns |     125.66 ns |     2.30 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |    10 |     106.53 ns |     0.290 ns |     0.242 ns |     106.59 ns |     1.95 |    0.00 |       - |       - |     - |         - |
|                      |        |          |       |               |              |              |               |          |         |         |         |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** |  **10,410.99 ns** |    **61.805 ns** |    **51.610 ns** |  **10,401.38 ns** |     **1.00** |    **0.00** |       **-** |       **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  12,417.00 ns |    36.308 ns |    33.962 ns |  12,420.04 ns |     1.19 |    0.01 |       - |       - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  19,819.30 ns |   217.471 ns |   203.423 ns |  19,831.83 ns |     1.90 |    0.02 |  0.1526 |       - |     - |     376 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |  23,671.41 ns |   470.807 ns | 1,163.719 ns |  23,053.71 ns |     2.31 |    0.11 | 31.2195 |       - |     - |  65,504 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  28,652.42 ns |   322.732 ns |   251.968 ns |  28,636.25 ns |     2.75 |    0.02 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 109,499.71 ns |   907.136 ns |   757.499 ns | 109,526.22 ns |    10.52 |    0.09 | 68.1152 | 22.7051 |     - | 186,528 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 |  66,454.93 ns |   315.294 ns |   263.285 ns |  66,434.94 ns |     6.38 |    0.04 |  0.3662 |       - |     - |   1,000 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  12,171.05 ns |    44.590 ns |    37.234 ns |  12,169.10 ns |     1.17 |    0.01 |  0.0305 |       - |     - |      72 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  10,456.73 ns |   100.079 ns |    88.718 ns |  10,415.93 ns |     1.01 |    0.01 |       - |       - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  18,036.20 ns |    63.612 ns |    56.391 ns |  18,044.01 ns |     1.73 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  13,027.26 ns |    49.000 ns |    38.256 ns |  13,020.19 ns |     1.25 |    0.01 |       - |       - |     - |         - |
|                      |        |          |       |               |              |              |               |          |         |         |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |  10,412.41 ns |    47.659 ns |    44.580 ns |  10,406.83 ns |     1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  12,358.64 ns |    43.900 ns |    38.916 ns |  12,368.86 ns |     1.19 |    0.01 |       - |       - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  20,097.68 ns |   156.293 ns |   122.023 ns |  20,129.21 ns |     1.93 |    0.01 |  0.1526 |       - |     - |     376 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |  27,003.67 ns |   519.873 ns |   638.451 ns |  27,106.71 ns |     2.58 |    0.07 | 31.2195 |       - |     - |  65,504 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  28,494.98 ns |   217.612 ns |   203.555 ns |  28,465.57 ns |     2.74 |    0.02 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 |  82,104.42 ns | 1,454.544 ns | 1,891.318 ns |  81,647.11 ns |     7.92 |    0.23 | 68.1152 | 22.7051 |     - | 186,080 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 |  65,581.86 ns |   862.082 ns |   806.392 ns |  65,714.99 ns |     6.30 |    0.08 |  0.3662 |       - |     - |   1,000 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  11,227.07 ns |    55.125 ns |    46.032 ns |  11,227.08 ns |     1.08 |    0.01 |  0.0305 |       - |     - |      72 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  10,040.26 ns |    55.506 ns |    51.921 ns |  10,047.53 ns |     0.96 |    0.01 |       - |       - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  17,885.27 ns |    45.452 ns |    40.292 ns |  17,892.11 ns |     1.72 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  12,589.85 ns |   126.186 ns |   111.860 ns |  12,589.64 ns |     1.21 |    0.01 |       - |       - |     - |         - |
