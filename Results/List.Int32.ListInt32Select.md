## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta42](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta42)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                      Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** |    **10** |    **11.86 ns** |  **0.023 ns** |  **0.021 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |    27.49 ns |  0.070 ns |  0.062 ns |  2.32 |    0.01 |      - |     - |     - |         - |
|                        Linq |    10 |   122.35 ns |  0.432 ns |  0.383 ns | 10.32 |    0.03 | 0.0343 |     - |     - |      72 B |
|                  LinqFaster |    10 |    49.00 ns |  0.112 ns |  0.094 ns |  4.13 |    0.01 | 0.0459 |     - |     - |      96 B |
|                      LinqAF |    10 |   112.91 ns |  0.231 ns |  0.193 ns |  9.52 |    0.02 |      - |     - |     - |         - |
|                  StructLinq |    10 |    40.10 ns |  0.231 ns |  0.205 ns |  3.38 |    0.02 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |    10 |    36.88 ns |  0.069 ns |  0.061 ns |  3.11 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |    42.53 ns |  0.151 ns |  0.134 ns |  3.59 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |    10 |    40.43 ns |  0.092 ns |  0.086 ns |  3.41 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For |    10 |    32.26 ns |  0.093 ns |  0.087 ns |  2.72 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |    10 |    21.72 ns |  0.028 ns |  0.023 ns |  1.83 |    0.00 |      - |     - |     - |         - |
|                             |       |             |           |           |       |         |        |       |       |           |
|                     **ForLoop** |  **1000** | **1,297.09 ns** |  **3.126 ns** |  **2.771 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 | 2,366.36 ns | 45.270 ns | 55.595 ns |  1.83 |    0.05 |      - |     - |     - |         - |
|                        Linq |  1000 | 6,802.45 ns | 17.134 ns | 14.308 ns |  5.25 |    0.02 | 0.0305 |     - |     - |      72 B |
|                  LinqFaster |  1000 | 3,751.36 ns | 13.586 ns | 11.345 ns |  2.89 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|                      LinqAF |  1000 | 6,930.16 ns | 34.865 ns | 30.907 ns |  5.34 |    0.02 |      - |     - |     - |         - |
|                  StructLinq |  1000 | 2,134.23 ns |  8.979 ns |  8.399 ns |  1.65 |    0.01 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |  1000 | 1,390.95 ns |  4.536 ns |  4.021 ns |  1.07 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 | 2,183.77 ns |  5.357 ns |  4.749 ns |  1.68 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |  1000 | 1,454.17 ns |  2.910 ns |  2.579 ns |  1.12 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_For |  1000 | 2,147.77 ns |  4.784 ns |  3.735 ns |  1.66 |    0.00 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |  1000 | 1,298.08 ns |  2.764 ns |  2.158 ns |  1.00 |    0.00 |      - |     - |     - |         - |
