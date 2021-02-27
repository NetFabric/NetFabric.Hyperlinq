## Array.Int32.ArrayInt32Sum

### Source
[ArrayInt32Sum.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Sum.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta41](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta41)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **3.390 ns** |  **0.0196 ns** |  **0.0174 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     3.453 ns |  0.0398 ns |  0.0353 ns |  1.02 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    55.851 ns |  0.2308 ns |  0.1928 ns | 16.47 |    0.07 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |    10 |     5.717 ns |  0.0201 ns |  0.0157 ns |  1.69 |    0.01 |      - |     - |     - |         - |
|      LinqFaster_SIMD |    10 |     7.053 ns |  0.0394 ns |  0.0350 ns |  2.08 |    0.01 |      - |     - |     - |         - |
|               LinqAF |    10 |    27.061 ns |  0.1614 ns |  0.1431 ns |  7.98 |    0.05 |      - |     - |     - |         - |
|           StructLinq |    10 |    18.218 ns |  0.1574 ns |  0.1315 ns |  5.37 |    0.06 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     4.978 ns |  0.0324 ns |  0.0288 ns |  1.47 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    16.265 ns |  0.1096 ns |  0.0915 ns |  4.80 |    0.04 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **397.430 ns** |  **2.6743 ns** |  **2.3707 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   543.601 ns |  2.5733 ns |  2.2812 ns |  1.37 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 4,348.560 ns | 38.9688 ns | 34.5448 ns | 10.94 |    0.12 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |  1000 |   543.280 ns |  2.7913 ns |  2.3309 ns |  1.37 |    0.01 |      - |     - |     - |         - |
|      LinqFaster_SIMD |  1000 |    53.983 ns |  0.2152 ns |  0.1797 ns |  0.14 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 | 2,022.474 ns |  9.3443 ns |  7.8029 ns |  5.09 |    0.04 |      - |     - |     - |         - |
|           StructLinq |  1000 |   699.102 ns |  2.0340 ns |  1.6985 ns |  1.76 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |   560.736 ns |  3.0634 ns |  2.7156 ns |  1.41 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |    90.953 ns |  0.3590 ns |  0.2998 ns |  0.23 |    0.00 |      - |     - |     - |         - |
