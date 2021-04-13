## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

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
|               Method |    Job |  Runtime | Skip | Count |         Mean |        Error |       StdDev |    Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |----- |------ |-------------:|-------------:|-------------:|---------:|--------:|--------:|--------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** | **1000** |    **10** |     **58.98 ns** |     **0.231 ns** |     **0.216 ns** |     **1.00** |    **0.00** |       **-** |       **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 | 1000 |    10 |  5,352.89 ns |    29.230 ns |    22.821 ns |    90.70 |    0.59 |  0.0458 |       - |     - |      96 B |
|                 Linq | .NET 5 | .NET 5.0 | 1000 |    10 |    259.06 ns |     1.124 ns |     0.877 ns |     4.39 |    0.02 |  0.1526 |       - |     - |     320 B |
|           LinqFaster | .NET 5 | .NET 5.0 | 1000 |    10 |    325.64 ns |     4.487 ns |     4.197 ns |     5.52 |    0.07 |  1.0710 |       - |     - |   2,240 B |
|               LinqAF | .NET 5 | .NET 5.0 | 1000 |    10 |  8,784.43 ns |   173.792 ns |   313.383 ns |   149.83 |    4.41 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |    10 | 66,871.46 ns |   741.963 ns |   657.731 ns | 1,133.76 |   13.76 | 73.9746 |       - |     - | 156,528 B |
|              Streams | .NET 5 | .NET 5.0 | 1000 |    10 |  8,292.93 ns |    48.518 ns |    43.010 ns |   140.60 |    0.74 |  0.5493 |       - |     - |   1,176 B |
|           StructLinq | .NET 5 | .NET 5.0 | 1000 |    10 |    123.23 ns |     0.859 ns |     0.803 ns |     2.09 |    0.02 |  0.0572 |       - |     - |     120 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |    10 |    100.35 ns |     0.769 ns |     0.719 ns |     1.70 |    0.01 |       - |       - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 | 1000 |    10 |    142.22 ns |     0.890 ns |     0.743 ns |     2.41 |    0.02 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 | 1000 |    10 |    117.11 ns |     1.248 ns |     1.042 ns |     1.99 |    0.02 |       - |       - |     - |         - |
|                      |        |          |      |       |              |              |              |          |         |         |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 | 1000 |    10 |     58.76 ns |     0.486 ns |     0.431 ns |     1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 | 1000 |    10 |  5,140.68 ns |    77.609 ns |    68.799 ns |    87.50 |    1.42 |  0.0458 |       - |     - |      96 B |
|                 Linq | .NET 6 | .NET 6.0 | 1000 |    10 |    201.28 ns |     3.683 ns |     3.445 ns |     3.43 |    0.06 |  0.1528 |       - |     - |     320 B |
|           LinqFaster | .NET 6 | .NET 6.0 | 1000 |    10 |    329.71 ns |     4.654 ns |     4.354 ns |     5.61 |    0.09 |  1.0710 |       - |     - |   2,240 B |
|               LinqAF | .NET 6 | .NET 6.0 | 1000 |    10 |  9,283.44 ns |   184.411 ns |   297.790 ns |   158.21 |    5.30 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |    10 | 62,911.90 ns | 1,063.966 ns |   995.235 ns | 1,071.96 |   18.01 | 73.9746 |       - |     - | 156,088 B |
|              Streams | .NET 6 | .NET 6.0 | 1000 |    10 |  8,656.73 ns |   172.514 ns |   263.447 ns |   150.76 |    3.82 |  0.5493 |       - |     - |   1,176 B |
|           StructLinq | .NET 6 | .NET 6.0 | 1000 |    10 |    124.33 ns |     2.503 ns |     2.342 ns |     2.12 |    0.04 |  0.0572 |       - |     - |     120 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |    10 |     99.58 ns |     0.709 ns |     0.663 ns |     1.69 |    0.02 |       - |       - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 | 1000 |    10 |    142.23 ns |     1.192 ns |     1.115 ns |     2.42 |    0.02 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 | 1000 |    10 |    117.25 ns |     1.311 ns |     1.162 ns |     2.00 |    0.02 |       - |       - |     - |         - |
|                      |        |          |      |       |              |              |              |          |         |         |         |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** | **1000** |  **1000** |  **6,049.19 ns** |    **63.195 ns** |    **56.021 ns** |     **1.00** |    **0.00** |       **-** |       **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 | 1000 |  1000 |  9,531.06 ns |   183.223 ns |   231.718 ns |     1.58 |    0.04 |  0.0458 |       - |     - |      96 B |
|                 Linq | .NET 5 | .NET 5.0 | 1000 |  1000 | 20,647.72 ns |   369.994 ns |   346.093 ns |     3.42 |    0.08 |  0.1526 |       - |     - |     320 B |
|           LinqFaster | .NET 5 | .NET 5.0 | 1000 |  1000 | 32,870.28 ns |   464.648 ns |   434.632 ns |     5.44 |    0.09 | 90.8813 |       - |     - | 193,616 B |
|               LinqAF | .NET 5 | .NET 5.0 | 1000 |  1000 | 38,903.30 ns |   760.968 ns |   905.878 ns |     6.44 |    0.16 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |  1000 | 98,718.27 ns |   635.409 ns |   594.362 ns |    16.31 |    0.20 | 72.6318 | 18.1885 |     - | 187,630 B |
|              Streams | .NET 5 | .NET 5.0 | 1000 |  1000 | 45,852.99 ns |   270.530 ns |   253.054 ns |     7.57 |    0.09 |  0.5493 |       - |     - |   1,176 B |
|           StructLinq | .NET 5 | .NET 5.0 | 1000 |  1000 |  8,103.82 ns |    40.604 ns |    37.981 ns |     1.34 |    0.02 |  0.0458 |       - |     - |     120 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  7,321.11 ns |    21.724 ns |    19.258 ns |     1.21 |    0.01 |       - |       - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 | 1000 |  1000 | 11,994.78 ns |    35.037 ns |    29.258 ns |     1.98 |    0.02 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  8,904.57 ns |    35.357 ns |    31.343 ns |     1.47 |    0.01 |       - |       - |     - |         - |
|                      |        |          |      |       |              |              |              |          |         |         |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  6,168.71 ns |    22.765 ns |    21.294 ns |     1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  8,741.45 ns |    46.564 ns |    41.278 ns |     1.42 |    0.01 |  0.0458 |       - |     - |      96 B |
|                 Linq | .NET 6 | .NET 6.0 | 1000 |  1000 | 15,975.60 ns |   111.652 ns |   104.439 ns |     2.59 |    0.02 |  0.1526 |       - |     - |     320 B |
|           LinqFaster | .NET 6 | .NET 6.0 | 1000 |  1000 | 35,237.87 ns |   602.427 ns |   563.510 ns |     5.71 |    0.09 | 90.8813 |       - |     - | 193,616 B |
|               LinqAF | .NET 6 | .NET 6.0 | 1000 |  1000 | 39,797.37 ns |   657.797 ns |   583.120 ns |     6.45 |    0.08 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |  1000 | 93,829.43 ns | 1,116.390 ns | 1,490.349 ns |    15.11 |    0.12 | 70.9229 | 19.8975 |     - | 187,188 B |
|              Streams | .NET 6 | .NET 6.0 | 1000 |  1000 | 31,806.92 ns |   199.551 ns |   176.896 ns |     5.16 |    0.04 |  0.5493 |       - |     - |   1,176 B |
|           StructLinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  6,714.22 ns |    45.651 ns |    35.641 ns |     1.09 |    0.01 |  0.0534 |       - |     - |     120 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  5,584.21 ns |    30.621 ns |    28.643 ns |     0.91 |    0.01 |       - |       - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 | 1000 |  1000 | 13,189.96 ns |    33.739 ns |    29.909 ns |     2.14 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  9,381.99 ns |    53.203 ns |    44.427 ns |     1.52 |    0.01 |       - |       - |     - |         - |
