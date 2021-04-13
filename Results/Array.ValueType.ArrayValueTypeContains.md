## Array.ValueType.ArrayValueTypeContains

### Source
[ArrayValueTypeContains.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeContains.cs)

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
|               Method |    Job |  Runtime | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |------------:|----------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |    **51.55 ns** |  **0.140 ns** |  **0.131 ns** |    **51.56 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |    10 |    48.10 ns |  0.101 ns |  0.090 ns |    48.10 ns |  0.93 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |    10 |    25.01 ns |  0.202 ns |  0.189 ns |    24.92 ns |  0.49 |    0.00 |      - |     - |     - |         - |
|           LinqFaster | .NET 5 | .NET 5.0 |    10 |    25.67 ns |  0.100 ns |  0.094 ns |    25.64 ns |  0.50 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |    27.73 ns |  0.481 ns |  1.066 ns |    27.32 ns |  0.56 |    0.03 |      - |     - |     - |         - |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |    47.54 ns |  0.219 ns |  0.205 ns |    47.56 ns |  0.92 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |    43.21 ns |  0.310 ns |  0.290 ns |    43.10 ns |  0.84 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |    27.48 ns |  0.414 ns |  0.367 ns |    27.36 ns |  0.53 |    0.01 |      - |     - |     - |         - |
|                      |        |          |       |             |           |           |             |       |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |    10 |    44.83 ns |  0.156 ns |  0.146 ns |    44.82 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |    49.05 ns |  0.224 ns |  0.209 ns |    49.03 ns |  1.09 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |    10 |    24.90 ns |  0.103 ns |  0.086 ns |    24.93 ns |  0.56 |    0.00 |      - |     - |     - |         - |
|           LinqFaster | .NET 6 | .NET 6.0 |    10 |    25.87 ns |  0.072 ns |  0.063 ns |    25.87 ns |  0.58 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |    31.07 ns |  0.136 ns |  0.127 ns |    31.07 ns |  0.69 |    0.00 |      - |     - |     - |         - |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |    60.17 ns |  0.497 ns |  0.465 ns |    60.23 ns |  1.34 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |    52.71 ns |  0.119 ns |  0.112 ns |    52.71 ns |  1.18 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |    28.19 ns |  0.299 ns |  0.280 ns |    28.31 ns |  0.63 |    0.01 |      - |     - |     - |         - |
|                      |        |          |       |             |           |           |             |       |         |        |       |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** | **5,053.61 ns** | **15.360 ns** | **13.617 ns** | **5,056.09 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 | 4,704.10 ns | 13.383 ns | 11.863 ns | 4,704.96 ns |  0.93 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 1,842.19 ns |  9.969 ns |  9.325 ns | 1,843.90 ns |  0.36 |    0.00 |      - |     - |     - |         - |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 | 1,842.56 ns |  7.411 ns |  6.932 ns | 1,841.91 ns |  0.36 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 1,841.15 ns |  6.997 ns |  6.545 ns | 1,840.10 ns |  0.36 |    0.00 |      - |     - |     - |         - |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 | 3,888.41 ns | 13.005 ns | 12.165 ns | 3,887.20 ns |  0.77 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 3,926.47 ns | 22.011 ns | 19.512 ns | 3,923.83 ns |  0.78 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 | 1,740.67 ns |  6.504 ns |  6.084 ns | 1,740.59 ns |  0.34 |    0.00 |      - |     - |     - |         - |
|                      |        |          |       |             |           |           |             |       |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 | 4,778.32 ns | 27.877 ns | 26.076 ns | 4,774.18 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 | 4,974.86 ns | 20.344 ns | 18.034 ns | 4,970.12 ns |  1.04 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 | 1,838.90 ns |  5.789 ns |  5.415 ns | 1,837.71 ns |  0.38 |    0.00 |      - |     - |     - |         - |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 | 1,838.14 ns |  5.126 ns |  4.280 ns | 1,838.67 ns |  0.38 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 1,838.86 ns |  5.344 ns |  4.462 ns | 1,839.64 ns |  0.38 |    0.00 |      - |     - |     - |         - |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 | 5,510.74 ns | 21.605 ns | 18.041 ns | 5,503.84 ns |  1.15 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 4,937.66 ns | 24.054 ns | 18.780 ns | 4,935.62 ns |  1.03 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 | 1,852.17 ns |  6.475 ns |  6.057 ns | 1,851.30 ns |  0.39 |    0.00 |      - |     - |     - |         - |
