## Array.ValueType.ArrayValueTypeSelectSum

### Source
[ArrayValueTypeSelectSum.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelectSum.cs)

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
|               Method |    Job |  Runtime | Count |          Mean |       Error |      StdDev |        Median |    Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |--------------:|------------:|------------:|--------------:|---------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |      **4.537 ns** |   **0.0419 ns** |   **0.0392 ns** |      **4.528 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |    10 |     15.821 ns |   0.0990 ns |   0.1761 ns |     15.821 ns |     3.50 |    0.06 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |    10 |     82.676 ns |   0.4505 ns |   0.4214 ns |     82.588 ns |    18.22 |    0.17 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 5 | .NET 5.0 |    10 |     34.392 ns |   0.1849 ns |   0.1639 ns |     34.413 ns |     7.58 |    0.05 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |     91.956 ns |   1.7933 ns |   2.8958 ns |     92.035 ns |    20.52 |    0.64 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 29,676.939 ns | 122.1343 ns | 114.2445 ns | 29,618.668 ns | 6,541.60 |   55.84 | 9.0942 |     - |     - |  19,018 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    197.205 ns |   0.8174 ns |   0.7646 ns |    197.086 ns |    43.47 |    0.44 | 0.1721 |     - |     - |     360 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |     29.983 ns |   0.3404 ns |   0.3184 ns |     29.856 ns |     6.61 |    0.10 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |      8.199 ns |   0.0311 ns |   0.0291 ns |      8.204 ns |     1.81 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |     68.884 ns |   0.2960 ns |   0.2769 ns |     68.937 ns |    15.18 |    0.16 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |    10 |     52.213 ns |   0.1714 ns |   0.1603 ns |     52.178 ns |    11.51 |    0.11 |      - |     - |     - |         - |
|                      |        |          |       |               |             |             |               |          |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |    10 |      3.065 ns |   0.2293 ns |   0.6578 ns |      2.681 ns |     1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |     11.759 ns |   0.0262 ns |   0.0486 ns |     11.753 ns |     3.45 |    0.71 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |    10 |     64.106 ns |   1.3159 ns |   1.7110 ns |     63.909 ns |    16.19 |    1.76 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 6 | .NET 6.0 |    10 |     31.501 ns |   0.1658 ns |   0.1551 ns |     31.454 ns |     7.67 |    0.96 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |     82.216 ns |   1.6246 ns |   2.6234 ns |     82.009 ns |    22.35 |    3.86 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 28,677.537 ns | 118.2636 ns | 110.6238 ns | 28,690.210 ns | 6,978.92 |  871.57 | 9.0637 |     - |     - |  18,962 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    199.666 ns |   0.8252 ns |   0.7719 ns |    199.865 ns |    48.59 |    6.08 | 0.1721 |     - |     - |     360 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |     29.539 ns |   0.1858 ns |   0.1647 ns |     29.522 ns |     7.30 |    0.79 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |      6.225 ns |   0.0357 ns |   0.0635 ns |      6.219 ns |     1.79 |    0.36 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |     63.422 ns |   0.3235 ns |   0.2526 ns |     63.463 ns |    16.16 |    1.34 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |    10 |     48.659 ns |   0.1962 ns |   0.1739 ns |     48.602 ns |    12.03 |    1.29 |      - |     - |     - |         - |
|                      |        |          |       |               |             |             |               |          |         |        |       |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** |    **665.281 ns** |   **2.1896 ns** |   **2.0482 ns** |    **665.281 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  1,987.238 ns |  21.2061 ns |  18.7987 ns |  1,988.748 ns |     2.99 |    0.03 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  6,275.249 ns |  18.9000 ns |  16.7543 ns |  6,274.190 ns |     9.43 |    0.04 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |  3,273.812 ns |   6.0257 ns |   5.0317 ns |  3,273.949 ns |     4.92 |    0.01 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  7,388.672 ns | 147.7041 ns | 238.5147 ns |  7,399.977 ns |    11.21 |    0.29 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 32,976.622 ns | 188.9317 ns | 176.7268 ns | 33,003.668 ns |    49.57 |    0.29 | 9.0942 |     - |     - |  19,018 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 |  4,324.660 ns |  31.1813 ns |  26.0378 ns |  4,323.022 ns |     6.50 |    0.05 | 0.1678 |     - |     - |     360 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  2,101.827 ns |   8.7074 ns |   8.1449 ns |  2,101.141 ns |     3.16 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |    787.158 ns |   1.4839 ns |   1.2391 ns |    787.420 ns |     1.18 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  4,773.183 ns |  22.5049 ns |  18.7926 ns |  4,776.093 ns |     7.17 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  3,708.093 ns |   9.0873 ns |   7.5883 ns |  3,706.645 ns |     5.57 |    0.02 |      - |     - |     - |         - |
|                      |        |          |       |               |             |             |               |          |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |    691.575 ns |   2.0348 ns |   1.8038 ns |    691.663 ns |     1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  1,807.547 ns |   6.8966 ns |   5.7590 ns |  1,808.259 ns |     2.61 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  7,013.334 ns |  21.8163 ns |  19.3396 ns |  7,009.065 ns |    10.14 |    0.04 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |  3,519.914 ns |  22.7633 ns |  21.2928 ns |  3,514.100 ns |     5.09 |    0.03 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  6,866.472 ns | 136.6414 ns | 239.3164 ns |  6,869.505 ns |     9.87 |    0.39 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 31,287.550 ns | 156.5786 ns | 146.4637 ns | 31,311.481 ns |    45.28 |    0.15 | 9.0332 |     - |     - |  18,962 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 |  4,123.307 ns |  14.7937 ns |  13.1142 ns |  4,122.193 ns |     5.96 |    0.03 | 0.1678 |     - |     - |     360 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  1,962.027 ns |   6.0154 ns |   5.3325 ns |  1,963.941 ns |     2.84 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |    821.337 ns |   2.3025 ns |   2.1538 ns |    820.915 ns |     1.19 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  4,774.478 ns |  27.4710 ns |  21.4475 ns |  4,781.720 ns |     6.90 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  3,476.039 ns |  10.8413 ns |  10.1410 ns |  3,474.889 ns |     5.03 |    0.02 |      - |     - |     - |         - |
