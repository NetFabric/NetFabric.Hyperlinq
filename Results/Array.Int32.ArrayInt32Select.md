## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                      Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** |    **10** |     **6.104 ns** |  **0.0188 ns** |  **0.0176 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |     6.108 ns |  0.0443 ns |  0.0370 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                        Linq |    10 |   111.269 ns |  0.4781 ns |  0.3993 ns | 18.23 |    0.08 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster |    10 |    33.136 ns |  0.1286 ns |  0.1203 ns |  5.43 |    0.02 | 0.0306 |     - |     - |      64 B |
|             LinqFaster_SIMD |    10 |    19.766 ns |  0.4261 ns |  0.3777 ns |  3.24 |    0.06 | 0.0306 |     - |     - |      64 B |
|                      LinqAF |    10 |    68.720 ns |  0.3075 ns |  0.2876 ns | 11.26 |    0.06 |      - |     - |     - |         - |
|                  StructLinq |    10 |    39.883 ns |  0.1233 ns |  0.1030 ns |  6.53 |    0.03 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |    10 |    38.047 ns |  0.1152 ns |  0.1021 ns |  6.23 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |    41.310 ns |  0.0980 ns |  0.0818 ns |  6.77 |    0.02 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |    10 |    40.868 ns |  0.1275 ns |  0.1193 ns |  6.69 |    0.03 |      - |     - |     - |         - |
|               Hyperlinq_For |    10 |    32.091 ns |  0.0982 ns |  0.0870 ns |  5.26 |    0.02 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |    10 |    22.197 ns |  0.1048 ns |  0.0980 ns |  3.64 |    0.02 |      - |     - |     - |         - |
|                             |       |              |            |            |       |         |        |       |       |           |
|                     **ForLoop** |  **1000** |   **502.827 ns** |  **1.1559 ns** |  **1.0246 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 |   502.591 ns |  1.3505 ns |  1.2633 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                        Linq |  1000 | 5,963.589 ns | 27.9958 ns | 23.3778 ns | 11.86 |    0.05 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster |  1000 | 2,653.355 ns | 10.2729 ns |  9.6093 ns |  5.28 |    0.02 | 1.9226 |     - |     - |   4,024 B |
|             LinqFaster_SIMD |  1000 |   860.985 ns |  6.2858 ns |  6.1735 ns |  1.71 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|                      LinqAF |  1000 | 3,908.455 ns | 20.0565 ns | 17.7796 ns |  7.77 |    0.04 |      - |     - |     - |         - |
|                  StructLinq |  1000 | 2,080.765 ns |  7.7827 ns |  7.2799 ns |  4.14 |    0.02 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |  1000 | 1,394.484 ns |  2.5189 ns |  2.2330 ns |  2.77 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 | 2,167.539 ns |  5.6147 ns |  5.2520 ns |  4.31 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |  1000 | 1,511.413 ns |  5.7742 ns |  5.1187 ns |  3.01 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For |  1000 | 2,078.338 ns |  4.6718 ns |  3.9012 ns |  4.13 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |  1000 |   794.770 ns |  1.9515 ns |  1.7299 ns |  1.58 |    0.00 |      - |     - |     - |         - |
