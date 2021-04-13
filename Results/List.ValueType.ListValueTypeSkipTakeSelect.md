## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

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
|                      Method |    Job |  Runtime | Skip | Count |         Mean |       Error |      StdDev |       Median |  Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |--------- |----- |------ |-------------:|------------:|------------:|-------------:|-------:|--------:|--------:|--------:|------:|----------:|
|                     **ForLoop** | **.NET 5** | **.NET 5.0** | **1000** |    **10** |     **177.8 ns** |     **0.62 ns** |     **0.48 ns** |     **177.8 ns** |   **1.00** |    **0.00** |       **-** |       **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5 | .NET 5.0 | 1000 |    10 |   5,760.2 ns |    52.19 ns |    40.75 ns |   5,747.8 ns |  32.39 |    0.25 |  0.0458 |       - |     - |      96 B |
|                        Linq | .NET 5 | .NET 5.0 | 1000 |    10 |     354.4 ns |     1.69 ns |     1.41 ns |     354.1 ns |   1.99 |    0.01 |  0.1526 |       - |     - |     320 B |
|                  LinqFaster | .NET 5 | .NET 5.0 | 1000 |    10 |     472.6 ns |     8.96 ns |    10.67 ns |     473.5 ns |   2.67 |    0.06 |  0.9975 |       - |     - |   2,088 B |
|                      LinqAF | .NET 5 | .NET 5.0 | 1000 |    10 |   9,177.0 ns |   179.22 ns |   206.39 ns |   9,155.7 ns |  51.61 |    1.36 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |    10 |  72,731.5 ns | 2,100.70 ns | 6,193.97 ns |  69,280.2 ns | 443.23 |   29.09 | 73.9746 |       - |     - | 156,546 B |
|                     Streams | .NET 5 | .NET 5.0 | 1000 |    10 |   9,364.9 ns |    53.39 ns |    49.94 ns |   9,355.7 ns |  52.66 |    0.37 |  0.5493 |       - |     - |   1,176 B |
|                  StructLinq | .NET 5 | .NET 5.0 | 1000 |    10 |     258.8 ns |     1.10 ns |     0.98 ns |     258.9 ns |   1.45 |    0.01 |  0.0572 |       - |     - |     120 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |    10 |     229.5 ns |     0.42 ns |     0.39 ns |     229.5 ns |   1.29 |    0.00 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 | 1000 |    10 |     237.6 ns |     0.87 ns |     0.77 ns |     237.3 ns |   1.33 |    0.00 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 | .NET 5.0 | 1000 |    10 |     212.8 ns |     0.61 ns |     0.51 ns |     212.7 ns |   1.20 |    0.00 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 | 1000 |    10 |     227.7 ns |     0.68 ns |     0.63 ns |     227.8 ns |   1.28 |    0.00 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5 | .NET 5.0 | 1000 |    10 |     202.7 ns |     0.92 ns |     0.86 ns |     202.6 ns |   1.14 |    0.01 |       - |       - |     - |         - |
|                             |        |          |      |       |              |             |             |              |        |         |         |         |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 | 1000 |    10 |     182.5 ns |     0.54 ns |     0.48 ns |     182.6 ns |   1.00 |    0.00 |       - |       - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 | 1000 |    10 |   5,549.2 ns |    47.67 ns |    44.59 ns |   5,527.1 ns |  30.42 |    0.31 |  0.0458 |       - |     - |      96 B |
|                        Linq | .NET 6 | .NET 6.0 | 1000 |    10 |     303.2 ns |     1.47 ns |     1.37 ns |     303.1 ns |   1.66 |    0.01 |  0.1526 |       - |     - |     320 B |
|                  LinqFaster | .NET 6 | .NET 6.0 | 1000 |    10 |     462.0 ns |     3.43 ns |     2.87 ns |     460.6 ns |   2.53 |    0.02 |  0.9975 |       - |     - |   2,088 B |
|                      LinqAF | .NET 6 | .NET 6.0 | 1000 |    10 |   9,290.4 ns |   184.20 ns |   322.61 ns |   9,332.4 ns |  49.59 |    1.43 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |    10 |  67,926.5 ns | 1,118.00 ns | 1,045.78 ns |  67,655.9 ns | 372.32 |    6.49 | 73.9746 |       - |     - | 156,107 B |
|                     Streams | .NET 6 | .NET 6.0 | 1000 |    10 |   9,344.8 ns |    52.94 ns |    46.93 ns |   9,349.0 ns |  51.20 |    0.31 |  0.5493 |       - |     - |   1,176 B |
|                  StructLinq | .NET 6 | .NET 6.0 | 1000 |    10 |     246.9 ns |     0.49 ns |     0.38 ns |     246.9 ns |   1.35 |    0.01 |  0.0572 |       - |     - |     120 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |    10 |     226.0 ns |     0.47 ns |     0.42 ns |     226.1 ns |   1.24 |    0.00 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 | 1000 |    10 |     238.0 ns |     0.67 ns |     0.59 ns |     237.8 ns |   1.30 |    0.01 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | .NET 6.0 | 1000 |    10 |     211.8 ns |     0.51 ns |     0.46 ns |     211.8 ns |   1.16 |    0.00 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 | 1000 |    10 |     227.8 ns |     0.44 ns |     0.39 ns |     227.9 ns |   1.25 |    0.00 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6 | .NET 6.0 | 1000 |    10 |     203.5 ns |     0.57 ns |     0.51 ns |     203.5 ns |   1.11 |    0.00 |       - |       - |     - |         - |
|                             |        |          |      |       |              |             |             |              |        |         |         |         |       |           |
|                     **ForLoop** | **.NET 5** | **.NET 5.0** | **1000** |  **1000** |  **17,687.5 ns** |    **45.29 ns** |    **37.82 ns** |  **17,678.4 ns** |   **1.00** |    **0.00** |       **-** |       **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5 | .NET 5.0 | 1000 |  1000 |  24,702.3 ns |   134.29 ns |   112.14 ns |  24,705.6 ns |   1.40 |    0.01 |  0.0305 |       - |     - |      96 B |
|                        Linq | .NET 5 | .NET 5.0 | 1000 |  1000 |  26,072.9 ns |   184.15 ns |   163.25 ns |  26,014.3 ns |   1.47 |    0.01 |  0.1526 |       - |     - |     320 B |
|                  LinqFaster | .NET 5 | .NET 5.0 | 1000 |  1000 |  49,066.0 ns |   702.48 ns |   657.10 ns |  49,170.2 ns |   2.77 |    0.04 | 90.8813 |       - |     - | 192,168 B |
|                      LinqAF | .NET 5 | .NET 5.0 | 1000 |  1000 |  50,989.8 ns |   973.38 ns | 1,081.91 ns |  51,353.4 ns |   2.88 |    0.07 |       - |       - |     - |       1 B |
|               LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |  1000 | 109,339.5 ns | 1,074.00 ns | 1,193.75 ns | 108,887.0 ns |   6.18 |    0.05 | 95.2148 | 23.6816 |     - | 219,938 B |
|                     Streams | .NET 5 | .NET 5.0 | 1000 |  1000 | 121,984.5 ns |   957.94 ns |   799.93 ns | 121,933.2 ns |   6.90 |    0.05 |  0.4883 |       - |     - |   1,176 B |
|                  StructLinq | .NET 5 | .NET 5.0 | 1000 |  1000 |  18,582.2 ns |    95.77 ns |    89.59 ns |  18,554.3 ns |   1.05 |    0.01 |  0.0305 |       - |     - |     120 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  18,265.3 ns |    49.45 ns |    43.84 ns |  18,265.8 ns |   1.03 |    0.00 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 | 1000 |  1000 |  19,607.5 ns |    67.83 ns |    60.13 ns |  19,614.3 ns |   1.11 |    0.00 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  17,429.0 ns |    84.07 ns |    74.53 ns |  17,453.8 ns |   0.99 |    0.00 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 | 1000 |  1000 |  19,857.0 ns |    55.72 ns |    46.53 ns |  19,847.4 ns |   1.12 |    0.00 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  17,268.6 ns |    53.99 ns |    47.86 ns |  17,262.7 ns |   0.98 |    0.00 |       - |       - |     - |         - |
|                             |        |          |      |       |              |             |             |              |        |         |         |         |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  17,769.4 ns |    84.11 ns |    78.68 ns |  17,752.5 ns |   1.00 |    0.00 |       - |       - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  23,020.4 ns |    66.06 ns |    58.56 ns |  23,033.3 ns |   1.30 |    0.01 |  0.0305 |       - |     - |      96 B |
|                        Linq | .NET 6 | .NET 6.0 | 1000 |  1000 |  23,872.9 ns |    99.87 ns |    88.53 ns |  23,866.0 ns |   1.34 |    0.01 |  0.1526 |       - |     - |     320 B |
|                  LinqFaster | .NET 6 | .NET 6.0 | 1000 |  1000 |  48,759.6 ns |   680.62 ns |   603.36 ns |  48,812.6 ns |   2.74 |    0.03 | 90.8813 |       - |     - | 192,168 B |
|                      LinqAF | .NET 6 | .NET 6.0 | 1000 |  1000 |  51,524.9 ns | 1,007.42 ns | 1,309.93 ns |  51,334.9 ns |   2.88 |    0.05 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |  1000 | 126,731.4 ns | 1,393.92 ns | 1,163.99 ns | 126,707.0 ns |   7.13 |    0.07 | 95.9473 | 19.2871 |     - | 219,499 B |
|                     Streams | .NET 6 | .NET 6.0 | 1000 |  1000 | 118,708.3 ns |   662.29 ns |   553.04 ns | 118,519.1 ns |   6.68 |    0.05 |  0.4883 |       - |     - |   1,176 B |
|                  StructLinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  18,807.1 ns |    64.99 ns |    57.61 ns |  18,782.4 ns |   1.06 |    0.01 |  0.0305 |       - |     - |     120 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  19,021.4 ns |   295.27 ns |   246.57 ns |  19,043.1 ns |   1.07 |    0.02 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 | 1000 |  1000 |  19,741.7 ns |    52.46 ns |    46.50 ns |  19,745.0 ns |   1.11 |    0.01 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  17,437.0 ns |   275.84 ns |   244.52 ns |  17,329.3 ns |   0.98 |    0.01 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 | 1000 |  1000 |  19,733.3 ns |    84.36 ns |    78.91 ns |  19,739.4 ns |   1.11 |    0.01 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  17,177.2 ns |    85.63 ns |    80.10 ns |  17,156.3 ns |   0.97 |    0.00 |       - |       - |     - |         - |
