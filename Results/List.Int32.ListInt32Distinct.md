## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

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
|               Method | Duplicates | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |          **4** |    **10** |    **373.63 ns** |   **1.192 ns** |   **0.931 ns** |  **1.00** |    **0.00** |  **0.3209** |     **-** |     **-** |     **672 B** |
|          ForeachLoop |          4 |    10 |    456.91 ns |   1.203 ns |   1.067 ns |  1.22 |    0.00 |  0.3209 |     - |     - |     672 B |
|                 Linq |          4 |    10 |    814.49 ns |   1.685 ns |   1.494 ns |  2.18 |    0.01 |  0.2937 |     - |     - |     616 B |
|           LinqFaster |          4 |    10 |     66.21 ns |   0.247 ns |   0.219 ns |  0.18 |    0.00 |       - |     - |     - |         - |
|               LinqAF |          4 |    10 |    993.39 ns |   3.834 ns |   3.399 ns |  2.66 |    0.01 |  0.6180 |     - |     - |   1,296 B |
|           StructLinq |          4 |    10 |    482.77 ns |   1.554 ns |   1.454 ns |  1.29 |    0.01 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |    10 |    481.00 ns |   1.368 ns |   1.213 ns |  1.29 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |          4 |    10 |    413.65 ns |   2.007 ns |   1.676 ns |  1.11 |    0.01 |       - |     - |     - |         - |
|                      |            |       |              |            |            |       |         |         |       |       |           |
|              **ForLoop** |          **4** |  **1000** | **32,384.05 ns** | **169.496 ns** | **150.254 ns** |  **1.00** |    **0.00** | **27.7710** |     **-** |     **-** |  **58,672 B** |
|          ForeachLoop |          4 |  1000 | 37,095.83 ns | 123.708 ns | 109.664 ns |  1.15 |    0.00 | 27.7710 |     - |     - |  58,672 B |
|                 Linq |          4 |  1000 | 67,741.65 ns | 342.043 ns | 303.212 ns |  2.09 |    0.01 | 15.7471 |     - |     - |  33,112 B |
|           LinqFaster |          4 |  1000 |  8,501.51 ns |  18.656 ns |  14.565 ns |  0.26 |    0.00 |       - |     - |     - |         - |
|               LinqAF |          4 |  1000 | 89,995.29 ns | 451.452 ns | 352.464 ns |  2.78 |    0.02 | 53.9551 |     - |     - | 113,184 B |
|           StructLinq |          4 |  1000 | 31,545.32 ns |  90.775 ns |  75.801 ns |  0.97 |    0.01 |       - |     - |     - |      32 B |
| StructLinq_IFunction |          4 |  1000 | 31,097.31 ns | 117.448 ns | 104.115 ns |  0.96 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq |          4 |  1000 | 31,812.04 ns | 101.478 ns |  89.957 ns |  0.98 |    0.00 |       - |     - |     - |         - |
