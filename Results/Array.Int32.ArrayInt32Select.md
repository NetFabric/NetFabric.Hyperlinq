## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

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
|                 ForeachLoop |     0 |      0.0000 ns |   0.0000 ns |   0.0000 ns |     ? |       ? |      - |     - |     - |         - |
|                        Linq |     0 |     40.2154 ns |   1.0231 ns |   2.9681 ns |     ? |       ? |      - |     - |     - |         - |
|                  LinqFaster |     0 |      7.9271 ns |   0.0533 ns |   0.0498 ns |     ? |       ? | 0.0115 |     - |     - |      24 B |
|             LinqFaster_SIMD |     0 |      8.6106 ns |   0.0958 ns |   0.0896 ns |     ? |       ? | 0.0115 |     - |     - |      24 B |
|                      LinqAF |     0 |     45.2861 ns |   0.9019 ns |   1.8012 ns |     ? |       ? |      - |     - |     - |         - |
|                  StructLinq |     0 |     17.6191 ns |   0.0645 ns |   0.0538 ns |     ? |       ? | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |     0 |     17.9877 ns |   0.0345 ns |   0.0270 ns |     ? |       ? |      - |     - |     - |         - |
|           Hyperlinq_Foreach |     0 |     20.4765 ns |   0.4565 ns |   0.4688 ns |     ? |       ? |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |     0 |     14.7115 ns |   0.0656 ns |   0.0582 ns |     ? |       ? |      - |     - |     - |         - |
|               Hyperlinq_For |     0 |      9.4662 ns |   0.2531 ns |   0.2708 ns |     ? |       ? |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |     0 |      6.4058 ns |   0.0138 ns |   0.0129 ns |     ? |       ? |      - |     - |     - |         - |
|              Hyperlinq_SIMD |     0 |     27.2734 ns |   0.5733 ns |   0.7848 ns |     ? |       ? |      - |     - |     - |         - |
|    Hyperlinq_IFunction_SIMD |     0 |     15.3405 ns |   0.0474 ns |   0.0443 ns |     ? |       ? |      - |     - |     - |         - |
|                             |       |                |             |             |       |         |        |       |       |           |
|                     **ForLoop** |    **10** |      **4.0243 ns** |   **0.1465 ns** |   **0.3539 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |      5.8572 ns |   0.1910 ns |   0.3814 ns |  1.47 |    0.16 |      - |     - |     - |         - |
|                        Linq |    10 |    142.8425 ns |   2.8470 ns |   4.4324 ns | 35.68 |    3.07 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster |    10 |     31.6972 ns |   0.2133 ns |   0.1996 ns |  7.90 |    0.50 | 0.0306 |     - |     - |      64 B |
|             LinqFaster_SIMD |    10 |     24.0044 ns |   0.4858 ns |   0.3793 ns |  5.91 |    0.27 | 0.0306 |     - |     - |      64 B |
|                      LinqAF |    10 |    134.7789 ns |   2.6820 ns |   7.4319 ns | 33.82 |    3.52 |      - |     - |     - |         - |
|                  StructLinq |    10 |     47.3512 ns |   0.6968 ns |   0.6177 ns | 11.81 |    0.68 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |    10 |     34.9104 ns |   0.0689 ns |   0.0575 ns |  8.70 |    0.55 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |     69.2160 ns |   1.6837 ns |   4.9643 ns | 17.28 |    1.87 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |    10 |     32.4548 ns |   0.0656 ns |   0.0582 ns |  8.10 |    0.49 |      - |     - |     - |         - |
|               Hyperlinq_For |    10 |     53.0349 ns |   1.4791 ns |   4.3379 ns | 13.32 |    1.65 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |    10 |     13.2315 ns |   0.0546 ns |   0.0484 ns |  3.30 |    0.20 |      - |     - |     - |         - |
|              Hyperlinq_SIMD |    10 |     76.1696 ns |   2.1905 ns |   6.4589 ns | 18.78 |    1.85 |      - |     - |     - |         - |
|    Hyperlinq_IFunction_SIMD |    10 |     32.0151 ns |   0.0871 ns |   0.0772 ns |  7.99 |    0.49 |      - |     - |     - |         - |
|                             |       |                |             |             |       |         |        |       |       |           |
|                     **ForLoop** |  **1000** |    **392.5014 ns** |   **1.2485 ns** |   **0.9748 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 |    392.8126 ns |   0.7968 ns |   0.6654 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                        Linq |  1000 | 11,714.0764 ns | 251.8361 ns | 742.5446 ns | 29.40 |    2.34 | 0.0153 |     - |     - |      48 B |
|                  LinqFaster |  1000 |  2,531.4686 ns |  10.0678 ns |   9.4174 ns |  6.45 |    0.02 | 1.9226 |     - |     - |    4024 B |
|             LinqFaster_SIMD |  1000 |    895.9233 ns |   2.8775 ns |   2.5508 ns |  2.28 |    0.01 | 1.9226 |     - |     - |    4024 B |
|                      LinqAF |  1000 |  8,832.4893 ns | 208.1967 ns | 610.6049 ns | 22.41 |    1.35 |      - |     - |     - |         - |
|                  StructLinq |  1000 |  4,356.3198 ns | 111.1202 ns | 324.1429 ns | 11.12 |    1.02 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |  1000 |  1,389.3531 ns |   2.1220 ns |   1.7719 ns |  3.54 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 |  3,976.1616 ns | 142.6585 ns | 416.1416 ns | 10.17 |    1.07 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |  1000 |  1,420.0325 ns |   7.9481 ns |   7.0458 ns |  3.62 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For |  1000 |  4,166.0116 ns | 151.7940 ns | 445.1857 ns | 10.55 |    1.34 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |  1000 |    783.1845 ns |   2.2407 ns |   1.9864 ns |  2.00 |    0.01 |      - |     - |     - |         - |
|              Hyperlinq_SIMD |  1000 |  4,118.2174 ns | 143.6719 ns | 416.8183 ns | 10.50 |    1.13 |      - |     - |     - |         - |
|    Hyperlinq_IFunction_SIMD |  1000 |  1,413.0950 ns |   4.0168 ns |   3.5608 ns |  3.60 |    0.00 |      - |     - |     - |         - |
