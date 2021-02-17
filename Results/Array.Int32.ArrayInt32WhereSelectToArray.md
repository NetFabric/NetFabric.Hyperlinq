## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|                                Method | Count |         Mean |       Error |      StdDev | Ratio | RatioSD |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-------------:|------------:|------------:|------:|--------:|-------:|-------:|------:|----------:|
|                    **ValueLinq_Standard** |     **0** |    **57.919 ns** |   **0.1718 ns** |   **0.1523 ns** | **13.03** |    **0.22** |      **-** |      **-** |     **-** |         **-** |
|                       ValueLinq_Stack |     0 |   100.513 ns |   1.8741 ns |   1.5650 ns | 22.64 |    0.49 |      - |      - |     - |         - |
|             ValueLinq_SharedPool_Push |     0 |   339.182 ns |   2.2878 ns |   2.0281 ns | 76.30 |    1.48 |      - |      - |     - |         - |
|             ValueLinq_SharedPool_Pull |     0 |   201.582 ns |   0.3396 ns |   0.2651 ns | 45.49 |    0.80 |      - |      - |     - |         - |
|        ValueLinq_ValueLambda_Standard |     0 |    87.519 ns |   1.8141 ns |   1.8629 ns | 19.63 |    0.45 |      - |      - |     - |         - |
|           ValueLinq_ValueLambda_Stack |     0 |    95.935 ns |   1.7128 ns |   1.6022 ns | 21.59 |    0.64 |      - |      - |     - |         - |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |   232.366 ns |   0.5916 ns |   0.5244 ns | 52.27 |    0.90 |      - |      - |     - |         - |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |   232.246 ns |   3.8632 ns |   3.6137 ns | 52.27 |    0.83 |      - |      - |     - |         - |
|                               ForLoop |     0 |     4.447 ns |   0.0888 ns |   0.0787 ns |  1.00 |    0.00 | 0.0153 |      - |     - |      32 B |
|                           ForeachLoop |     0 |     4.630 ns |   0.1181 ns |   0.1105 ns |  1.04 |    0.04 | 0.0153 |      - |     - |      32 B |
|                                  Linq |     0 |    65.138 ns |   1.4071 ns |   4.1488 ns | 14.65 |    0.86 |      - |      - |     - |         - |
|                            LinqFaster |     0 |    13.206 ns |   0.1957 ns |   0.1831 ns |  2.97 |    0.07 | 0.0114 |      - |     - |      24 B |
|                                LinqAF |     0 |    87.431 ns |   0.7830 ns |   0.7324 ns | 19.66 |    0.32 | 0.0304 |      - |     - |      64 B |
|                            StructLinq |     0 |    70.549 ns |   0.5826 ns |   0.4865 ns | 15.89 |    0.32 | 0.0572 |      - |     - |     120 B |
|                  StructLinq_IFunction |     0 |    58.082 ns |   0.1729 ns |   0.1617 ns | 13.06 |    0.25 | 0.0113 |      - |     - |      24 B |
|                             Hyperlinq |     0 |    56.442 ns |   0.9245 ns |   0.8648 ns | 12.70 |    0.27 | 0.0114 |      - |     - |      24 B |
|                   Hyperlinq_IFunction |     0 |    52.709 ns |   0.6573 ns |   0.5827 ns | 11.86 |    0.28 | 0.0114 |      - |     - |      24 B |
|                                       |       |              |             |             |       |         |        |        |       |           |
|                    **ValueLinq_Standard** |    **10** |   **194.200 ns** |   **2.2641 ns** |   **2.1178 ns** |  **4.86** |    **0.06** | **0.0153** |      **-** |     **-** |      **32 B** |
|                       ValueLinq_Stack |    10 |   155.976 ns |   1.9349 ns |   1.8099 ns |  3.91 |    0.05 | 0.0150 |      - |     - |      32 B |
|             ValueLinq_SharedPool_Push |    10 |   380.196 ns |   3.4031 ns |   2.8418 ns |  9.52 |    0.09 | 0.0153 |      - |     - |      32 B |
|             ValueLinq_SharedPool_Pull |    10 |   258.005 ns |   1.7470 ns |   1.5487 ns |  6.46 |    0.06 | 0.0153 | 0.0005 |     - |      32 B |
|        ValueLinq_ValueLambda_Standard |    10 |   143.986 ns |   0.3483 ns |   0.3088 ns |  3.61 |    0.02 | 0.0150 |      - |     - |      32 B |
|           ValueLinq_ValueLambda_Stack |    10 |   109.189 ns |   0.3157 ns |   0.2953 ns |  2.73 |    0.02 | 0.0153 |      - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |   273.676 ns |   0.7631 ns |   0.7139 ns |  6.85 |    0.04 | 0.0153 |      - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |   250.871 ns |   0.7134 ns |   0.5957 ns |  6.28 |    0.04 | 0.0153 |      - |     - |      32 B |
|                               ForLoop |    10 |    39.925 ns |   0.2308 ns |   0.2046 ns |  1.00 |    0.00 | 0.0497 |      - |     - |     104 B |
|                           ForeachLoop |    10 |    37.417 ns |   0.2043 ns |   0.1706 ns |  0.94 |    0.01 | 0.0497 |      - |     - |     104 B |
|                                  Linq |    10 |   134.542 ns |   0.9347 ns |   0.8286 ns |  3.37 |    0.03 | 0.0842 |      - |     - |     176 B |
|                            LinqFaster |    10 |    40.611 ns |   0.2049 ns |   0.1711 ns |  1.02 |    0.01 | 0.0459 |      - |     - |      96 B |
|                                LinqAF |    10 |   109.820 ns |   0.6560 ns |   0.5478 ns |  2.75 |    0.02 | 0.0342 |      - |     - |      72 B |
|                            StructLinq |    10 |   129.364 ns |   0.4687 ns |   0.4384 ns |  3.24 |    0.02 | 0.0610 |      - |     - |     128 B |
|                  StructLinq_IFunction |    10 |    93.702 ns |   0.3774 ns |   0.3345 ns |  2.35 |    0.02 | 0.0153 |      - |     - |      32 B |
|                             Hyperlinq |    10 |   126.567 ns |   1.9764 ns |   1.8487 ns |  3.17 |    0.04 | 0.0153 |      - |     - |      32 B |
|                   Hyperlinq_IFunction |    10 |    89.727 ns |   0.4536 ns |   0.3787 ns |  2.25 |    0.02 | 0.0153 |      - |     - |      32 B |
|                                       |       |              |             |             |       |         |        |        |       |           |
|                    **ValueLinq_Standard** |  **1000** | **6,998.298 ns** |  **96.5647 ns** |  **90.3267 ns** |  **2.62** |    **0.04** | **1.9760** |      **-** |     **-** |    **4144 B** |
|                       ValueLinq_Stack |  1000 | 7,542.688 ns | 126.6307 ns | 118.4504 ns |  2.82 |    0.04 | 1.9760 |      - |     - |    4144 B |
|             ValueLinq_SharedPool_Push |  1000 | 5,610.637 ns |  18.0899 ns |  16.0362 ns |  2.10 |    0.01 | 0.9689 |      - |     - |    2040 B |
|             ValueLinq_SharedPool_Pull |  1000 | 7,428.252 ns |  66.9082 ns |  62.5860 ns |  2.78 |    0.03 | 0.9689 |      - |     - |    2040 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 2,627.442 ns |  15.7348 ns |  14.7183 ns |  0.98 |    0.01 | 1.9798 |      - |     - |    4144 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 2,627.704 ns |  18.3514 ns |  17.1659 ns |  0.98 |    0.01 | 1.9798 |      - |     - |    4144 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 2,646.467 ns |  14.1486 ns |  12.5424 ns |  0.99 |    0.01 | 0.9727 |      - |     - |    2040 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 2,864.203 ns |  13.3277 ns |  12.4668 ns |  1.07 |    0.01 | 0.9727 |      - |     - |    2040 B |
|                               ForLoop |  1000 | 2,671.078 ns |  15.0183 ns |  14.0481 ns |  1.00 |    0.00 | 3.0289 |      - |     - |    6344 B |
|                           ForeachLoop |  1000 | 2,662.297 ns |  21.7115 ns |  19.2467 ns |  1.00 |    0.01 | 3.0289 |      - |     - |    6344 B |
|                                  Linq |  1000 | 5,285.053 ns |  17.8984 ns |  15.8665 ns |  1.98 |    0.01 | 2.1667 |      - |     - |    4544 B |
|                            LinqFaster |  1000 | 4,121.933 ns |  14.1896 ns |  13.2730 ns |  1.54 |    0.01 | 2.8915 |      - |     - |    6064 B |
|                                LinqAF |  1000 | 9,588.882 ns | 126.7262 ns | 105.8221 ns |  3.59 |    0.04 | 3.0060 |      - |     - |    6312 B |
|                            StructLinq |  1000 | 5,454.876 ns |  25.5833 ns |  21.3632 ns |  2.04 |    0.01 | 1.0147 |      - |     - |    2136 B |
|                  StructLinq_IFunction |  1000 | 3,055.530 ns |  16.7212 ns |  13.9630 ns |  1.14 |    0.01 | 0.9727 |      - |     - |    2040 B |
|                             Hyperlinq |  1000 | 5,276.976 ns |  12.6472 ns |  11.2114 ns |  1.98 |    0.01 | 0.9689 |      - |     - |    2040 B |
|                   Hyperlinq_IFunction |  1000 | 2,415.852 ns |   8.6499 ns |   8.0912 ns |  0.90 |    0.00 | 0.9727 |      - |     - |    2040 B |
