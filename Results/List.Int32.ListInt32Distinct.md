## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

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
|               Method | Duplicates | Count |           Mean |       Error |      StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |---------------:|------------:|------------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |          **4** |     **0** |      **6.6292 ns** |   **0.0701 ns** |   **0.0621 ns** |  **1.00** |    **0.00** |  **0.0344** |     **-** |     **-** |      **72 B** |
|          ForeachLoop |          4 |     0 |      9.0077 ns |   0.0390 ns |   0.0325 ns |  1.36 |    0.01 |  0.0344 |     - |     - |      72 B |
|                 Linq |          4 |     0 |     43.4523 ns |   0.2157 ns |   0.2018 ns |  6.56 |    0.07 |  0.0497 |     - |     - |     104 B |
|           LinqFaster |          4 |     0 |      0.8183 ns |   0.0095 ns |   0.0084 ns |  0.12 |    0.00 |       - |     - |     - |         - |
|               LinqAF |          4 |     0 |     89.7155 ns |   0.4131 ns |   0.3864 ns | 13.54 |    0.15 |  0.0994 |     - |     - |     208 B |
|           StructLinq |          4 |     0 |     91.1831 ns |   0.3668 ns |   0.3431 ns | 13.75 |    0.11 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |     0 |     84.6481 ns |   0.3887 ns |   0.3445 ns | 12.77 |    0.10 |       - |     - |     - |         - |
|            Hyperlinq |          4 |     0 |     28.6349 ns |   0.0508 ns |   0.0451 ns |  4.32 |    0.04 |       - |     - |     - |         - |
|                      |            |       |                |             |             |       |         |         |       |       |           |
|              **ForLoop** |          **4** |    **10** |    **370.3970 ns** |   **1.5931 ns** |   **1.4123 ns** |  **1.00** |    **0.00** |  **0.3209** |     **-** |     **-** |     **672 B** |
|          ForeachLoop |          4 |    10 |    441.5926 ns |   1.5835 ns |   1.4038 ns |  1.19 |    0.01 |  0.3209 |     - |     - |     672 B |
|                 Linq |          4 |    10 |    815.8234 ns |   3.1862 ns |   2.8244 ns |  2.20 |    0.01 |  0.2937 |     - |     - |     616 B |
|           LinqFaster |          4 |    10 |     65.9789 ns |   0.4185 ns |   0.3495 ns |  0.18 |    0.00 |       - |     - |     - |         - |
|               LinqAF |          4 |    10 |  1,065.0771 ns |   9.4211 ns |   7.8671 ns |  2.87 |    0.02 |  0.6180 |     - |     - |    1296 B |
|           StructLinq |          4 |    10 |    491.0438 ns |   3.3492 ns |   2.7967 ns |  1.33 |    0.01 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |    10 |    478.9297 ns |   2.6236 ns |   2.3258 ns |  1.29 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |          4 |    10 |    481.8434 ns |   0.9839 ns |   0.8722 ns |  1.30 |    0.01 |       - |     - |     - |         - |
|                      |            |       |                |             |             |       |         |         |       |       |           |
|              **ForLoop** |          **4** |  **1000** | **31,063.4169 ns** | **118.6485 ns** |  **99.0769 ns** |  **1.00** |    **0.00** | **27.7710** |     **-** |     **-** |   **58672 B** |
|          ForeachLoop |          4 |  1000 | 37,715.0960 ns | 134.4233 ns | 125.7396 ns |  1.21 |    0.00 | 27.7710 |     - |     - |   58672 B |
|                 Linq |          4 |  1000 | 67,697.8106 ns | 386.1357 ns | 342.2992 ns |  2.18 |    0.02 | 15.7471 |     - |     - |   33112 B |
|           LinqFaster |          4 |  1000 |  8,703.5247 ns |  28.2141 ns |  25.0111 ns |  0.28 |    0.00 |       - |     - |     - |         - |
|               LinqAF |          4 |  1000 | 90,281.2923 ns | 580.2528 ns | 542.7688 ns |  2.91 |    0.02 | 53.9551 |     - |     - |  113184 B |
|           StructLinq |          4 |  1000 | 32,228.9294 ns | 106.8667 ns |  99.9632 ns |  1.04 |    0.00 |       - |     - |     - |      32 B |
| StructLinq_IFunction |          4 |  1000 | 31,605.0718 ns | 113.4411 ns | 106.1129 ns |  1.02 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |          4 |  1000 | 36,233.8048 ns | 112.4609 ns |  99.6937 ns |  1.17 |    0.01 |       - |     - |     - |         - |
