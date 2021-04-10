## ImmutableArray.Int32.ImmutableArrayInt32Select

### Source
[ImmutableArrayInt32Select.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Select.cs)

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
|                      Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** |    **10** |     **4.911 ns** |  **0.0348 ns** |  **0.0645 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |     6.319 ns |  0.0382 ns |  0.0358 ns |  1.28 |    0.02 |      - |     - |     - |         - |
|                        Linq |    10 |   111.233 ns |  0.4283 ns |  0.3344 ns | 22.39 |    0.34 | 0.0229 |     - |     - |      48 B |
|                  StructLinq |    10 |    54.526 ns |  1.0018 ns |  0.8881 ns | 11.00 |    0.26 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |    10 |    44.442 ns |  0.4613 ns |  0.4315 ns |  8.97 |    0.16 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |    43.145 ns |  0.1138 ns |  0.1009 ns |  8.70 |    0.15 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |    10 |    42.481 ns |  0.1590 ns |  0.1487 ns |  8.58 |    0.14 |      - |     - |     - |         - |
|               Hyperlinq_For |    10 |    34.022 ns |  0.2251 ns |  0.1995 ns |  6.86 |    0.11 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |    10 |    25.769 ns |  0.0855 ns |  0.0758 ns |  5.20 |    0.09 |      - |     - |     - |         - |
|                             |       |              |            |            |       |         |        |       |       |           |
|                     **ForLoop** |  **1000** |   **551.462 ns** |  **2.2478 ns** |  **1.9926 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 |   626.033 ns |  2.4244 ns |  2.2678 ns |  1.14 |    0.01 |      - |     - |     - |         - |
|                        Linq |  1000 | 6,289.792 ns | 60.5858 ns | 53.7077 ns | 11.41 |    0.10 | 0.0229 |     - |     - |      48 B |
|                  StructLinq |  1000 | 3,223.243 ns | 13.5807 ns | 11.3405 ns |  5.85 |    0.03 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |  1000 | 2,303.580 ns | 25.5804 ns | 23.9279 ns |  4.18 |    0.05 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 | 2,196.406 ns | 11.0749 ns | 10.3595 ns |  3.98 |    0.02 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |  1000 | 1,709.360 ns |  4.6783 ns |  4.1472 ns |  3.10 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For |  1000 | 1,897.318 ns | 12.5030 ns | 11.0836 ns |  3.44 |    0.03 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |  1000 |   823.369 ns |  2.4981 ns |  2.2145 ns |  1.49 |    0.01 |      - |     - |     - |         - |
