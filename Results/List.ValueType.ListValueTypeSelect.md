## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

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
|                      Method |    Job |  Runtime | Count |         Mean |     Error |    StdDev |  Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |--------- |------ |-------------:|----------:|----------:|-------:|--------:|--------:|--------:|------:|----------:|
|                     **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |     **172.5 ns** |   **0.60 ns** |   **0.56 ns** |   **1.00** |    **0.00** |       **-** |       **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5 | .NET 5.0 |    10 |     210.0 ns |   0.83 ns |   0.74 ns |   1.22 |    0.00 |       - |       - |     - |         - |
|                        Linq | .NET 5 | .NET 5.0 |    10 |     318.0 ns |   3.51 ns |   2.74 ns |   1.84 |    0.02 |  0.0877 |       - |     - |     184 B |
|                  LinqFaster | .NET 5 | .NET 5.0 |    10 |     282.2 ns |   1.21 ns |   1.13 ns |   1.64 |    0.01 |  0.3324 |       - |     - |     696 B |
|                      LinqAF | .NET 5 | .NET 5.0 |    10 |     415.5 ns |   3.69 ns |   3.08 ns |   2.41 |    0.02 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 5 | .NET 5.0 |    10 |  47,897.5 ns | 243.73 ns | 190.29 ns | 277.85 |    1.58 | 71.4111 |       - |     - | 152,344 B |
|                     Streams | .NET 5 | .NET 5.0 |    10 |   1,261.4 ns |   5.93 ns |   5.26 ns |   7.31 |    0.04 |  0.4044 |       - |     - |     848 B |
|                  StructLinq | .NET 5 | .NET 5.0 |    10 |     208.2 ns |   0.81 ns |   0.76 ns |   1.21 |    0.01 |  0.0191 |       - |     - |      40 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |     209.6 ns |   0.50 ns |   0.39 ns |   1.22 |    0.00 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 |    10 |     224.7 ns |   0.62 ns |   0.58 ns |   1.30 |    0.01 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 | .NET 5.0 |    10 |     199.6 ns |   0.81 ns |   0.68 ns |   1.16 |    0.01 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 |    10 |     213.5 ns |   0.39 ns |   0.35 ns |   1.24 |    0.00 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5 | .NET 5.0 |    10 |     190.3 ns |   0.56 ns |   0.53 ns |   1.10 |    0.00 |       - |       - |     - |         - |
|                             |        |          |       |              |           |           |        |         |         |         |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 |    10 |     172.5 ns |   0.36 ns |   0.30 ns |   1.00 |    0.00 |       - |       - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 |    10 |     209.4 ns |   0.53 ns |   0.49 ns |   1.21 |    0.00 |       - |       - |     - |         - |
|                        Linq | .NET 6 | .NET 6.0 |    10 |     294.4 ns |   0.93 ns |   0.82 ns |   1.71 |    0.01 |  0.0877 |       - |     - |     184 B |
|                  LinqFaster | .NET 6 | .NET 6.0 |    10 |     282.2 ns |   2.27 ns |   1.77 ns |   1.64 |    0.01 |  0.3324 |       - |     - |     696 B |
|                      LinqAF | .NET 6 | .NET 6.0 |    10 |     416.5 ns |   3.19 ns |   2.83 ns |   2.42 |    0.02 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 6 | .NET 6.0 |    10 |  43,057.4 ns | 198.74 ns | 176.18 ns | 249.59 |    1.10 | 71.4111 |       - |     - | 151,904 B |
|                     Streams | .NET 6 | .NET 6.0 |    10 |   1,274.5 ns |  11.47 ns |   9.58 ns |   7.39 |    0.05 |  0.4044 |       - |     - |     848 B |
|                  StructLinq | .NET 6 | .NET 6.0 |    10 |     209.6 ns |   0.68 ns |   0.64 ns |   1.22 |    0.00 |  0.0191 |       - |     - |      40 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |     218.4 ns |   0.50 ns |   0.45 ns |   1.27 |    0.00 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 |    10 |     224.9 ns |   1.15 ns |   0.96 ns |   1.30 |    0.01 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | .NET 6.0 |    10 |     198.8 ns |   0.50 ns |   0.42 ns |   1.15 |    0.00 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 |    10 |     214.7 ns |   0.71 ns |   0.59 ns |   1.24 |    0.00 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6 | .NET 6.0 |    10 |     189.2 ns |   0.59 ns |   0.55 ns |   1.10 |    0.00 |       - |       - |     - |         - |
|                             |        |          |       |              |           |           |        |         |         |         |       |           |
|                     **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** |  **17,113.3 ns** |  **57.75 ns** |  **51.19 ns** |   **1.00** |    **0.00** |       **-** |       **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  19,115.2 ns |  53.76 ns |  47.66 ns |   1.12 |    0.00 |       - |       - |     - |         - |
|                        Linq | .NET 5 | .NET 5.0 |  1000 |  26,789.7 ns | 135.39 ns | 126.64 ns |   1.57 |    0.01 |  0.0610 |       - |     - |     184 B |
|                  LinqFaster | .NET 5 | .NET 5.0 |  1000 |  29,044.4 ns | 191.97 ns | 160.30 ns |   1.70 |    0.01 | 30.2734 |       - |     - |  64,056 B |
|                      LinqAF | .NET 5 | .NET 5.0 |  1000 |  33,969.7 ns | 445.73 ns | 372.20 ns |   1.99 |    0.02 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 5 | .NET 5.0 |  1000 |  86,383.4 ns | 579.36 ns | 513.58 ns |   5.05 |    0.04 | 91.1865 | 16.1133 |     - | 215,726 B |
|                     Streams | .NET 5 | .NET 5.0 |  1000 | 115,698.5 ns | 355.34 ns | 332.39 ns |   6.76 |    0.03 |  0.3662 |       - |     - |     850 B |
|                  StructLinq | .NET 5 | .NET 5.0 |  1000 |  18,441.1 ns |  62.37 ns |  48.70 ns |   1.08 |    0.00 |       - |       - |     - |      40 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  17,378.4 ns |  78.27 ns |  73.21 ns |   1.02 |    0.01 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 |  1000 |  19,428.6 ns |  72.80 ns |  64.54 ns |   1.14 |    0.00 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 | .NET 5.0 |  1000 |  17,062.9 ns |  30.75 ns |  27.26 ns |   1.00 |    0.00 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 |  1000 |  19,378.1 ns |  56.59 ns |  50.17 ns |   1.13 |    0.00 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5 | .NET 5.0 |  1000 |  17,175.5 ns |  55.20 ns |  51.64 ns |   1.00 |    0.00 |       - |       - |     - |         - |
|                             |        |          |       |              |           |           |        |         |         |         |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 |  1000 |  17,028.7 ns |  54.84 ns |  48.61 ns |   1.00 |    0.00 |       - |       - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  19,122.6 ns |  34.48 ns |  30.56 ns |   1.12 |    0.00 |       - |       - |     - |         - |
|                        Linq | .NET 6 | .NET 6.0 |  1000 |  25,670.6 ns |  79.90 ns |  74.74 ns |   1.51 |    0.01 |  0.0610 |       - |     - |     184 B |
|                  LinqFaster | .NET 6 | .NET 6.0 |  1000 |  29,079.0 ns | 266.07 ns | 248.88 ns |   1.71 |    0.01 | 30.2734 |       - |     - |  64,056 B |
|                      LinqAF | .NET 6 | .NET 6.0 |  1000 |  34,407.2 ns | 642.12 ns | 569.22 ns |   2.02 |    0.03 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 6 | .NET 6.0 |  1000 |  89,979.3 ns | 646.97 ns | 605.18 ns |   5.28 |    0.04 | 95.4590 |  6.9580 |     - | 215,291 B |
|                     Streams | .NET 6 | .NET 6.0 |  1000 | 107,525.6 ns | 561.32 ns | 438.24 ns |   6.31 |    0.03 |  0.3662 |       - |     - |     848 B |
|                  StructLinq | .NET 6 | .NET 6.0 |  1000 |  18,461.3 ns | 166.95 ns | 139.41 ns |   1.08 |    0.01 |       - |       - |     - |      40 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  17,979.2 ns | 116.49 ns |  97.28 ns |   1.06 |    0.01 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 |  1000 |  19,536.4 ns |  74.45 ns |  66.00 ns |   1.15 |    0.01 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | .NET 6.0 |  1000 |  17,338.8 ns |  68.33 ns |  63.91 ns |   1.02 |    0.00 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 |  1000 |  19,478.1 ns |  94.86 ns |  88.73 ns |   1.14 |    0.01 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6 | .NET 6.0 |  1000 |  17,179.5 ns |  69.53 ns |  65.04 ns |   1.01 |    0.00 |       - |       - |     - |         - |
