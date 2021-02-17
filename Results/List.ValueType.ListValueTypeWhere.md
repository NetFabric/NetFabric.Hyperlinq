## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta38](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta38)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |          Mean |       Error |      StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |--------------:|------------:|------------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |     **0** |      **1.462 ns** |   **0.0058 ns** |   **0.0048 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |     0 |     11.972 ns |   0.0252 ns |   0.0224 ns |  8.19 |    0.03 |       - |     - |     - |         - |
|                 Linq |     0 |     57.154 ns |   0.4123 ns |   0.3856 ns | 39.03 |    0.27 |  0.0650 |     - |     - |     136 B |
|           LinqFaster |     0 |      9.908 ns |   0.0897 ns |   0.0839 ns |  6.79 |    0.07 |  0.0153 |     - |     - |      32 B |
|               LinqAF |     0 |     88.999 ns |   0.2491 ns |   0.2080 ns | 60.89 |    0.28 |       - |     - |     - |         - |
|           StructLinq |     0 |     21.595 ns |   0.0630 ns |   0.0492 ns | 14.78 |    0.06 |  0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |     0 |     28.682 ns |   0.0661 ns |   0.0618 ns | 19.62 |    0.09 |       - |     - |     - |         - |
|            Hyperlinq |     0 |     20.062 ns |   0.0293 ns |   0.0245 ns | 13.73 |    0.05 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |     18.157 ns |   0.0407 ns |   0.0339 ns | 12.42 |    0.04 |       - |     - |     - |         - |
|                      |       |               |             |             |       |         |         |       |       |           |
|              **ForLoop** |    **10** |     **33.893 ns** |   **0.1213 ns** |   **0.1013 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     60.019 ns |   0.1834 ns |   0.1716 ns |  1.77 |    0.01 |       - |     - |     - |         - |
|                 Linq |    10 |    214.033 ns |   0.7003 ns |   0.6550 ns |  6.31 |    0.03 |  0.0648 |     - |     - |     136 B |
|           LinqFaster |    10 |     67.798 ns |   0.3267 ns |   0.2896 ns |  2.00 |    0.01 |  0.1032 |     - |     - |     216 B |
|               LinqAF |    10 |    188.677 ns |   2.1370 ns |   1.8944 ns |  5.57 |    0.06 |       - |     - |     - |         - |
|           StructLinq |    10 |     56.379 ns |   0.1679 ns |   0.1488 ns |  1.66 |    0.01 |  0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |    10 |     56.981 ns |   0.1098 ns |   0.1027 ns |  1.68 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |    10 |     51.192 ns |   0.1214 ns |   0.1135 ns |  1.51 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     41.852 ns |   0.1215 ns |   0.1077 ns |  1.23 |    0.00 |       - |     - |     - |         - |
|                      |       |               |             |             |       |         |         |       |       |           |
|              **ForLoop** |  **1000** |  **4,853.385 ns** |  **15.3727 ns** |  **12.8369 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  7,198.603 ns |  16.2434 ns |  14.3994 ns |  1.48 |    0.00 |       - |     - |     - |         - |
|                 Linq |  1000 | 14,329.309 ns |  73.1208 ns |  64.8196 ns |  2.95 |    0.01 |  0.0610 |     - |     - |     136 B |
|           LinqFaster |  1000 | 13,392.445 ns |  68.5199 ns |  57.2172 ns |  2.76 |    0.02 | 19.6075 |     - |     - |   41024 B |
|               LinqAF |  1000 | 17,512.914 ns | 125.6969 ns | 117.5770 ns |  3.61 |    0.02 |       - |     - |     - |         - |
|           StructLinq |  1000 |  6,062.533 ns |  14.9041 ns |  13.2121 ns |  1.25 |    0.00 |  0.0153 |     - |     - |      40 B |
| StructLinq_IFunction |  1000 |  4,804.125 ns |  14.3112 ns |  13.3867 ns |  0.99 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq |  1000 |  5,906.388 ns |  11.5489 ns |  10.2378 ns |  1.22 |    0.00 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  4,930.680 ns |   9.8028 ns |   8.6899 ns |  1.02 |    0.00 |       - |     - |     - |         - |
