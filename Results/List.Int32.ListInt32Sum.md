## List.Int32.ListInt32Sum

### Source
[ListInt32Sum.cs](../LinqBenchmarks/List/Int32/ListInt32Sum.cs)

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
|               Method | Count |           Mean |       Error |      StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------------:|------------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |     **0** |      **0.0000 ns** |   **0.0000 ns** |   **0.0000 ns** |     **?** |       **?** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |     0 |      7.0614 ns |   0.2258 ns |   0.6658 ns |     ? |       ? |      - |     - |     - |         - |
|                 Linq |     0 |     20.2540 ns |   0.2147 ns |   0.1903 ns |     ? |       ? | 0.0191 |     - |     - |      40 B |
|           LinqFaster |     0 |     20.7867 ns |   0.1910 ns |   0.1787 ns |     ? |       ? | 0.0191 |     - |     - |      40 B |
|               LinqAF |     0 |     54.5876 ns |   1.0883 ns |   2.5224 ns |     ? |       ? |      - |     - |     - |         - |
|           StructLinq |     0 |     11.1291 ns |   0.1639 ns |   0.1453 ns |     ? |       ? | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |     0 |      4.6947 ns |   0.1225 ns |   0.2301 ns |     ? |       ? |      - |     - |     - |         - |
|            Hyperlinq |     0 |     10.6259 ns |   0.2404 ns |   0.5524 ns |     ? |       ? |      - |     - |     - |         - |
|                      |       |                |             |             |       |         |        |       |       |           |
|              **ForLoop** |    **10** |      **8.0170 ns** |   **0.0238 ns** |   **0.0211 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     58.2562 ns |   1.3402 ns |   3.9515 ns |  7.43 |    0.62 |      - |     - |     - |         - |
|                 Linq |    10 |    151.5928 ns |   2.9347 ns |   4.4815 ns | 18.78 |    0.65 | 0.0191 |     - |     - |      40 B |
|           LinqFaster |    10 |    151.7297 ns |   3.0429 ns |   5.4871 ns | 18.87 |    0.65 | 0.0191 |     - |     - |      40 B |
|               LinqAF |    10 |    174.8449 ns |   3.4696 ns |   9.3804 ns | 21.61 |    1.14 |      - |     - |     - |         - |
|           StructLinq |    10 |     18.1425 ns |   0.1201 ns |   0.1003 ns |  2.26 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |      8.3439 ns |   0.2324 ns |   0.2387 ns |  1.04 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |    10 |     18.1562 ns |   0.4284 ns |   0.7274 ns |  2.26 |    0.09 |      - |     - |     - |         - |
|                      |       |                |             |             |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |    **971.8077 ns** |   **4.2494 ns** |   **3.5484 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  4,766.2595 ns |  96.8539 ns | 284.0558 ns |  4.87 |    0.31 |      - |     - |     - |         - |
|                 Linq |  1000 | 13,549.8144 ns | 270.5181 ns | 576.4962 ns | 14.21 |    0.62 | 0.0153 |     - |     - |      40 B |
|           LinqFaster |  1000 | 13,523.6909 ns | 270.4634 ns | 587.9652 ns | 13.92 |    0.60 | 0.0153 |     - |     - |      40 B |
|               LinqAF |  1000 | 10,475.6454 ns | 203.0553 ns | 576.0340 ns | 10.67 |    0.68 |      - |     - |     - |         - |
|           StructLinq |  1000 |    685.5494 ns |   1.3363 ns |   1.1159 ns |  0.71 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |    557.1298 ns |   3.4648 ns |   3.2410 ns |  0.57 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |    119.7597 ns |   0.4875 ns |   0.4321 ns |  0.12 |    0.00 |      - |     - |     - |         - |
