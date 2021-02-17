## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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
|               Method | Count |           Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |     **0** |      **0.2646 ns** |  **0.0043 ns** |  **0.0033 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |     0 |      3.2777 ns |  0.0207 ns |  0.0183 ns |  12.40 |    0.16 |      - |     - |     - |         - |
|                 Linq |     0 |     41.7443 ns |  0.2301 ns |  0.2039 ns | 157.78 |    1.90 | 0.0344 |     - |     - |      72 B |
|           LinqFaster |     0 |      8.3565 ns |  0.0326 ns |  0.0305 ns |  31.57 |    0.40 | 0.0153 |     - |     - |      32 B |
|               LinqAF |     0 |     34.2512 ns |  0.1199 ns |  0.1002 ns | 129.49 |    1.76 |      - |     - |     - |         - |
|           StructLinq |     0 |     18.4510 ns |  0.0660 ns |  0.0585 ns |  69.75 |    0.87 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |     0 |     21.8842 ns |  0.0379 ns |  0.0354 ns |  82.74 |    1.07 |      - |     - |     - |         - |
|            Hyperlinq |     0 |     18.3261 ns |  0.0332 ns |  0.0311 ns |  69.25 |    0.96 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |     16.6945 ns |  0.0515 ns |  0.0482 ns |  63.10 |    0.95 |      - |     - |     - |         - |
|                      |       |                |            |            |        |         |        |       |       |           |
|              **ForLoop** |    **10** |     **10.3918 ns** |  **0.0187 ns** |  **0.0156 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     31.2607 ns |  0.1747 ns |  0.1548 ns |   3.01 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |     86.7479 ns |  0.3520 ns |  0.3293 ns |   8.35 |    0.03 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |    10 |     48.7489 ns |  0.1599 ns |  0.1418 ns |   4.69 |    0.02 | 0.0344 |     - |     - |      72 B |
|               LinqAF |    10 |     97.5414 ns |  0.3910 ns |  0.3466 ns |   9.39 |    0.03 |      - |     - |     - |         - |
|           StructLinq |    10 |     39.6264 ns |  0.2259 ns |  0.2002 ns |   3.81 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     36.8981 ns |  0.1037 ns |  0.0919 ns |   3.55 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |     35.3204 ns |  0.1730 ns |  0.1445 ns |   3.40 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     31.2651 ns |  0.0559 ns |  0.0496 ns |   3.01 |    0.01 |      - |     - |     - |         - |
|                      |       |                |            |            |        |         |        |       |       |           |
|              **ForLoop** |  **1000** |  **1,127.1881 ns** | **11.0668 ns** | **10.3519 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  4,146.3912 ns | 22.2708 ns | 20.8321 ns |   3.68 |    0.04 |      - |     - |     - |         - |
|                 Linq |  1000 |  9,972.9216 ns | 38.0804 ns | 33.7573 ns |   8.85 |    0.08 | 0.0305 |     - |     - |      72 B |
|           LinqFaster |  1000 |  6,215.4630 ns | 12.5667 ns | 10.4937 ns |   5.51 |    0.05 | 2.0523 |     - |     - |    4304 B |
|               LinqAF |  1000 | 11,565.3601 ns | 22.0730 ns | 20.6471 ns |  10.26 |    0.10 |      - |     - |     - |         - |
|           StructLinq |  1000 |  5,277.2747 ns | 14.6360 ns | 12.9745 ns |   4.68 |    0.05 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |  1,597.5800 ns |  5.9635 ns |  5.2864 ns |   1.42 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |  5,768.5024 ns |  8.2272 ns |  7.2932 ns |   5.12 |    0.05 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  5,241.4720 ns | 10.4277 ns |  9.7541 ns |   4.65 |    0.04 |      - |     - |     - |         - |
