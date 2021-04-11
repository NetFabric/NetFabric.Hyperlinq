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
  .NET 6.0 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|                      Method |      Job |  Runtime | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |--------- |--------- |----- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                     **ForLoop** | **.NET 5.0** | **.NET 5.0** | **1000** |    **10** |    **182.5 ns** |   **0.54 ns** |   **0.50 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5.0 | .NET 5.0 | 1000 |    10 |  4,355.6 ns |  29.96 ns |  26.55 ns | 23.88 |    0.19 |  0.0458 |     - |     - |      96 B |
|                        Linq | .NET 5.0 | .NET 5.0 | 1000 |    10 |    366.8 ns |   6.52 ns |   5.44 ns |  2.01 |    0.03 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | .NET 5.0 | .NET 5.0 | 1000 |    10 |    464.8 ns |   5.39 ns |   4.78 ns |  2.55 |    0.02 |  0.9980 |     - |     - |   2,088 B |
|                      LinqAF | .NET 5.0 | .NET 5.0 | 1000 |    10 |  8,482.4 ns | 168.77 ns | 257.73 ns | 46.30 |    1.38 |       - |     - |     - |         - |
|                  StructLinq | .NET 5.0 | .NET 5.0 | 1000 |    10 |    263.3 ns |   1.11 ns |   0.93 ns |  1.44 |    0.01 |  0.0572 |     - |     - |     120 B |
|        StructLinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |    10 |    229.0 ns |   0.51 ns |   0.45 ns |  1.26 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5.0 | .NET 5.0 | 1000 |    10 |    244.5 ns |   3.80 ns |   3.73 ns |  1.34 |    0.02 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5.0 | .NET 5.0 | 1000 |    10 |    217.7 ns |   0.50 ns |   0.42 ns |  1.19 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5.0 | .NET 5.0 | 1000 |    10 |    231.1 ns |   0.70 ns |   0.62 ns |  1.27 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5.0 | .NET 5.0 | 1000 |    10 |    209.0 ns |   1.11 ns |   0.98 ns |  1.15 |    0.01 |       - |     - |     - |         - |
|                             |          |          |      |       |             |           |           |       |         |         |       |       |           |
|                     ForLoop | .NET 6.0 | .NET 6.0 | 1000 |    10 |    179.8 ns |   0.65 ns |   0.54 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6.0 | .NET 6.0 | 1000 |    10 |  5,506.6 ns |  13.25 ns |  11.74 ns | 30.62 |    0.09 |  0.0458 |     - |     - |      96 B |
|                        Linq | .NET 6.0 | .NET 6.0 | 1000 |    10 |    326.4 ns |   1.36 ns |   1.21 ns |  1.81 |    0.01 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | .NET 6.0 | .NET 6.0 | 1000 |    10 |    526.2 ns |   6.48 ns |   5.74 ns |  2.92 |    0.03 |  0.9975 |     - |     - |   2,088 B |
|                      LinqAF | .NET 6.0 | .NET 6.0 | 1000 |    10 |  8,802.2 ns | 174.54 ns | 356.54 ns | 49.75 |    2.46 |       - |     - |     - |         - |
|                  StructLinq | .NET 6.0 | .NET 6.0 | 1000 |    10 |    250.1 ns |   1.21 ns |   1.01 ns |  1.39 |    0.01 |  0.0572 |     - |     - |     120 B |
|        StructLinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |    10 |    231.1 ns |   1.10 ns |   0.98 ns |  1.28 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6.0 | .NET 6.0 | 1000 |    10 |    239.9 ns |   1.25 ns |   1.17 ns |  1.34 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6.0 | .NET 6.0 | 1000 |    10 |    217.1 ns |   0.69 ns |   0.61 ns |  1.21 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6.0 | .NET 6.0 | 1000 |    10 |    235.7 ns |   4.61 ns |   6.46 ns |  1.33 |    0.04 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6.0 | .NET 6.0 | 1000 |    10 |    209.8 ns |   0.53 ns |   0.41 ns |  1.17 |    0.00 |       - |     - |     - |         - |
|                             |          |          |      |       |             |           |           |       |         |         |       |       |           |
|                     **ForLoop** | **.NET 5.0** | **.NET 5.0** | **1000** |  **1000** | **17,874.3 ns** |  **75.02 ns** |  **70.17 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 23,419.2 ns |  77.18 ns |  68.42 ns |  1.31 |    0.01 |  0.0305 |     - |     - |      96 B |
|                        Linq | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 26,048.8 ns | 170.28 ns | 142.19 ns |  1.46 |    0.01 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 49,325.7 ns | 796.07 ns | 744.64 ns |  2.76 |    0.05 | 90.8813 |     - |     - | 192,168 B |
|                      LinqAF | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 46,900.7 ns | 897.41 ns | 839.43 ns |  2.62 |    0.05 |       - |     - |     - |         - |
|                  StructLinq | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 18,977.7 ns |  91.57 ns |  81.17 ns |  1.06 |    0.00 |  0.0305 |     - |     - |     120 B |
|        StructLinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 17,458.0 ns |  48.30 ns |  45.18 ns |  0.98 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 19,616.3 ns |  45.72 ns |  42.76 ns |  1.10 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 17,464.1 ns |  53.97 ns |  50.48 ns |  0.98 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 20,154.4 ns |  61.85 ns |  57.85 ns |  1.13 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 17,333.3 ns |  43.68 ns |  40.86 ns |  0.97 |    0.00 |       - |     - |     - |         - |
|                             |          |          |      |       |             |           |           |       |         |         |       |       |           |
|                     ForLoop | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 17,845.5 ns |  27.70 ns |  23.13 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 24,409.5 ns |  82.87 ns |  73.47 ns |  1.37 |    0.00 |  0.0305 |     - |     - |      96 B |
|                        Linq | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 25,831.7 ns |  98.79 ns |  87.57 ns |  1.45 |    0.00 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 49,184.0 ns | 982.35 ns | 918.89 ns |  2.76 |    0.05 | 90.8813 |     - |     - | 192,168 B |
|                      LinqAF | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 47,903.6 ns | 937.57 ns | 877.00 ns |  2.68 |    0.05 |       - |     - |     - |         - |
|                  StructLinq | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 18,787.8 ns | 133.83 ns | 111.76 ns |  1.05 |    0.01 |  0.0305 |     - |     - |     120 B |
|        StructLinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 17,473.4 ns |  67.39 ns |  63.04 ns |  0.98 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 19,665.6 ns |  85.92 ns |  76.17 ns |  1.10 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 17,508.9 ns |  81.01 ns |  71.81 ns |  0.98 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 19,902.0 ns |  30.12 ns |  25.15 ns |  1.12 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 17,292.3 ns |  39.48 ns |  36.93 ns |  0.97 |    0.00 |       - |     - |     - |         - |
