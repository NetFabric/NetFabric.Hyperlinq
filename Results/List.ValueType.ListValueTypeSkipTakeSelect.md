## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

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
|                      Method | Skip | Count |        Mean |       Error |      StdDev |      Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |------------:|------------:|------------:|------------:|------:|--------:|--------:|------:|------:|----------:|
|                     **ForLoop** | **1000** |    **10** |    **182.6 ns** |     **0.48 ns** |     **0.42 ns** |    **182.6 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  5,705.8 ns |    75.59 ns |    63.12 ns |  5,681.7 ns | 31.24 |    0.38 |  0.0458 |     - |     - |      96 B |
|                        Linq | 1000 |    10 |    366.1 ns |     7.31 ns |    12.81 ns |    359.1 ns |  2.08 |    0.06 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | 1000 |    10 |    481.5 ns |     7.01 ns |     6.56 ns |    479.5 ns |  2.64 |    0.03 |  0.9975 |     - |     - |   2,088 B |
|                      LinqAF | 1000 |    10 |  9,184.2 ns |   177.68 ns |   342.33 ns |  9,189.0 ns | 48.89 |    1.59 |       - |     - |     - |         - |
|                  StructLinq | 1000 |    10 |    259.8 ns |     5.03 ns |     7.05 ns |    256.6 ns |  1.44 |    0.04 |  0.0572 |     - |     - |     120 B |
|        StructLinq_IFunction | 1000 |    10 |    233.7 ns |     0.99 ns |     0.82 ns |    233.8 ns |  1.28 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |    245.0 ns |     1.03 ns |     0.97 ns |    244.7 ns |  1.34 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |    222.3 ns |     1.80 ns |     1.68 ns |    221.6 ns |  1.22 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |    240.1 ns |     1.11 ns |     1.04 ns |    240.2 ns |  1.31 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |    10 |    210.9 ns |     1.03 ns |     0.96 ns |    211.0 ns |  1.15 |    0.01 |       - |     - |     - |         - |
|                             |      |       |             |             |             |             |       |         |         |       |       |           |
|                     **ForLoop** | **1000** |  **1000** | **18,040.2 ns** |    **84.05 ns** |    **70.18 ns** | **18,028.8 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 | 25,111.5 ns |    93.36 ns |    82.76 ns | 25,116.4 ns |  1.39 |    0.01 |  0.0305 |     - |     - |      96 B |
|                        Linq | 1000 |  1000 | 26,352.8 ns |    76.98 ns |    60.10 ns | 26,367.2 ns |  1.46 |    0.01 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | 1000 |  1000 | 52,872.3 ns | 1,071.64 ns | 3,159.76 ns | 51,040.6 ns |  2.81 |    0.06 | 90.8813 |     - |     - | 192,168 B |
|                      LinqAF | 1000 |  1000 | 48,195.3 ns |   581.40 ns |   515.40 ns | 48,102.0 ns |  2.67 |    0.03 |       - |     - |     - |         - |
|                  StructLinq | 1000 |  1000 | 19,133.0 ns |   103.92 ns |    97.21 ns | 19,123.3 ns |  1.06 |    0.01 |  0.0305 |     - |     - |     120 B |
|        StructLinq_IFunction | 1000 |  1000 | 17,860.6 ns |   125.97 ns |   117.83 ns | 17,822.5 ns |  0.99 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 | 20,010.9 ns |    75.48 ns |    66.91 ns | 20,001.6 ns |  1.11 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 | 17,942.4 ns |    88.45 ns |    82.73 ns | 17,969.8 ns |  1.00 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 | 20,126.1 ns |    59.68 ns |    52.91 ns | 20,133.0 ns |  1.12 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |  1000 | 17,588.1 ns |    43.70 ns |    38.74 ns | 17,582.4 ns |  0.97 |    0.00 |       - |     - |     - |         - |
