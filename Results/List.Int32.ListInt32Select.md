## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

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
|                      Method | Count |           Mean |       Error |      StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |---------------:|------------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** |     **0** |      **0.0000 ns** |   **0.0000 ns** |   **0.0000 ns** |     **?** |       **?** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |     0 |      7.5722 ns |   0.2397 ns |   0.7067 ns |     ? |       ? |      - |     - |     - |         - |
|                        Linq |     0 |     56.0542 ns |   0.4862 ns |   0.4548 ns |     ? |       ? | 0.0344 |     - |     - |      72 B |
|                  LinqFaster |     0 |      8.7720 ns |   0.0796 ns |   0.0706 ns |     ? |       ? | 0.0153 |     - |     - |      32 B |
|                      LinqAF |     0 |     66.1829 ns |   1.3134 ns |   2.6829 ns |     ? |       ? |      - |     - |     - |         - |
|                  StructLinq |     0 |     16.8851 ns |   0.0910 ns |   0.0807 ns |     ? |       ? | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |     0 |     19.2025 ns |   0.0321 ns |   0.0300 ns |     ? |       ? |      - |     - |     - |         - |
|           Hyperlinq_Foreach |     0 |     20.5919 ns |   0.3077 ns |   0.2728 ns |     ? |       ? |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |     0 |     17.0806 ns |   0.0354 ns |   0.0331 ns |     ? |       ? |      - |     - |     - |         - |
|               Hyperlinq_For |     0 |      9.4334 ns |   0.1450 ns |   0.1356 ns |     ? |       ? |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |     0 |      4.0510 ns |   0.0146 ns |   0.0137 ns |     ? |       ? |      - |     - |     - |         - |
|              Hyperlinq_SIMD |     0 |     30.4911 ns |   0.6472 ns |   0.7948 ns |     ? |       ? |      - |     - |     - |         - |
|    Hyperlinq_SIMD_IFunction |     0 |     17.3611 ns |   0.0370 ns |   0.0346 ns |     ? |       ? |      - |     - |     - |         - |
|                             |       |                |             |             |       |         |        |       |       |           |
|                     **ForLoop** |    **10** |     **14.4396 ns** |   **0.3528 ns** |   **0.6626 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |     65.6106 ns |   1.3725 ns |   3.9600 ns |  4.57 |    0.36 |      - |     - |     - |         - |
|                        Linq |    10 |    184.7743 ns |   3.6570 ns |   3.2418 ns | 12.90 |    0.63 | 0.0343 |     - |     - |      72 B |
|                  LinqFaster |    10 |     65.2243 ns |   0.6362 ns |   0.5951 ns |  4.55 |    0.20 | 0.0459 |     - |     - |      96 B |
|                      LinqAF |    10 |    202.7233 ns |   3.9580 ns |   5.1466 ns | 14.05 |    0.82 |      - |     - |     - |         - |
|                  StructLinq |    10 |     49.7002 ns |   1.0530 ns |   1.0342 ns |  3.46 |    0.15 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |    10 |     35.3641 ns |   0.0956 ns |   0.0799 ns |  2.47 |    0.11 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |     68.4482 ns |   1.8677 ns |   5.5069 ns |  4.79 |    0.46 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |    10 |     29.8447 ns |   0.1713 ns |   0.1519 ns |  2.08 |    0.09 |      - |     - |     - |         - |
|               Hyperlinq_For |    10 |     54.2065 ns |   1.9951 ns |   5.8199 ns |  3.72 |    0.45 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |    10 |     16.0185 ns |   0.0684 ns |   0.0640 ns |  1.12 |    0.05 |      - |     - |     - |         - |
|              Hyperlinq_SIMD |    10 |     80.5103 ns |   1.9352 ns |   5.7061 ns |  5.64 |    0.46 |      - |     - |     - |         - |
|    Hyperlinq_SIMD_IFunction |    10 |     29.8862 ns |   0.0923 ns |   0.0818 ns |  2.09 |    0.09 |      - |     - |     - |         - |
|                             |       |                |             |             |       |         |        |       |       |           |
|                     **ForLoop** |  **1000** |  **1,304.5536 ns** |  **13.9284 ns** |  **10.8743 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 |  5,445.3743 ns | 123.4901 ns | 364.1132 ns |  3.99 |    0.19 |      - |     - |     - |         - |
|                        Linq |  1000 | 15,622.8739 ns | 309.2915 ns | 872.3622 ns | 11.95 |    0.59 | 0.0305 |     - |     - |      72 B |
|                  LinqFaster |  1000 |  4,935.8266 ns |  97.5565 ns |  91.2544 ns |  3.78 |    0.06 | 1.9379 |     - |     - |    4056 B |
|                      LinqAF |  1000 | 13,146.6469 ns | 260.8051 ns | 526.8391 ns | 10.03 |    0.37 |      - |     - |     - |         - |
|                  StructLinq |  1000 |  3,981.2154 ns | 160.2549 ns | 472.5152 ns |  3.09 |    0.35 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |  1000 |  1,388.9455 ns |   3.4421 ns |   3.0514 ns |  1.06 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 |  3,991.1035 ns |  98.2097 ns | 289.5736 ns |  3.06 |    0.17 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |  1000 |  1,567.2173 ns |   3.7766 ns |   3.3478 ns |  1.20 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For |  1000 |  4,609.5918 ns | 139.0889 ns | 407.9236 ns |  3.44 |    0.25 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |  1000 |    788.9073 ns |   2.2613 ns |   1.8883 ns |  0.60 |    0.01 |      - |     - |     - |         - |
|              Hyperlinq_SIMD |  1000 |  4,476.3050 ns | 163.4157 ns | 476.6913 ns |  3.47 |    0.39 |      - |     - |     - |         - |
|    Hyperlinq_SIMD_IFunction |  1000 |  1,428.4614 ns |   2.9556 ns |   2.7647 ns |  1.10 |    0.01 |      - |     - |     - |         - |
