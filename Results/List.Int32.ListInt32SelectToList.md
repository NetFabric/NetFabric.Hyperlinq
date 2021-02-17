## List.Int32.ListInt32SelectToList

### Source
[ListInt32SelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32SelectToList.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|                  **ForLoop** |     **0** |     **4.295 ns** |  **0.0384 ns** |  **0.0341 ns** |     **4.283 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **32 B** |
|              ForeachLoop |     0 |     7.108 ns |  0.0294 ns |  0.0245 ns |     7.114 ns |  1.65 |    0.01 | 0.0153 |     - |     - |      32 B |
|                     Linq |     0 |    40.572 ns |  0.0938 ns |  0.0832 ns |    40.576 ns |  9.45 |    0.08 | 0.0497 |     - |     - |     104 B |
|               LinqFaster |     0 |    17.667 ns |  0.1637 ns |  0.1451 ns |    17.684 ns |  4.11 |    0.05 | 0.0306 |     - |     - |      64 B |
|                   LinqAF |     0 |    64.163 ns |  0.2236 ns |  0.2092 ns |    64.165 ns | 14.93 |    0.13 | 0.0153 |     - |     - |      32 B |
|               StructLinq |     0 |    36.469 ns |  0.1470 ns |  0.1227 ns |    36.491 ns |  8.49 |    0.07 | 0.0573 |     - |     - |     120 B |
|     StructLinq_IFunction |     0 |    31.623 ns |  0.1880 ns |  0.1570 ns |    31.634 ns |  7.36 |    0.07 | 0.0458 |     - |     - |      96 B |
|                Hyperlinq |     0 |    15.095 ns |  0.0480 ns |  0.0426 ns |    15.092 ns |  3.51 |    0.03 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_IFunction |     0 |    11.668 ns |  0.0570 ns |  0.0506 ns |    11.658 ns |  2.72 |    0.02 | 0.0153 |     - |     - |      32 B |
|           Hyperlinq_SIMD |     0 |    16.637 ns |  0.1226 ns |  0.1087 ns |    16.624 ns |  3.87 |    0.04 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_IFunction_SIMD |     0 |    11.982 ns |  0.0397 ns |  0.0371 ns |    11.992 ns |  2.79 |    0.02 | 0.0153 |     - |     - |      32 B |
|                          |       |              |            |            |              |       |         |        |       |       |           |
|                  **ForLoop** |    **10** |    **74.969 ns** |  **0.3230 ns** |  **0.3021 ns** |    **74.914 ns** |  **1.00** |    **0.00** | **0.1031** |     **-** |     **-** |     **216 B** |
|              ForeachLoop |    10 |    80.180 ns |  0.4663 ns |  0.3894 ns |    80.103 ns |  1.07 |    0.01 | 0.1032 |     - |     - |     216 B |
|                     Linq |    10 |    67.485 ns |  0.3031 ns |  0.2687 ns |    67.389 ns |  0.90 |    0.01 | 0.0802 |     - |     - |     168 B |
|               LinqFaster |    10 |    62.046 ns |  0.3919 ns |  0.3475 ns |    62.019 ns |  0.83 |    0.00 | 0.0917 |     - |     - |     192 B |
|                   LinqAF |    10 |   195.022 ns |  3.2854 ns |  7.4826 ns |   192.327 ns |  2.69 |    0.17 | 0.1032 |     - |     - |     216 B |
|               StructLinq |    10 |    64.498 ns |  0.3154 ns |  0.2633 ns |    64.489 ns |  0.86 |    0.00 | 0.0764 |     - |     - |     160 B |
|     StructLinq_IFunction |    10 |    45.570 ns |  0.3141 ns |  0.2785 ns |    45.579 ns |  0.61 |    0.00 | 0.0650 |     - |     - |     136 B |
|                Hyperlinq |    10 |    44.020 ns |  0.1770 ns |  0.1382 ns |    44.049 ns |  0.59 |    0.00 | 0.0458 |     - |     - |      96 B |
|      Hyperlinq_IFunction |    10 |    27.382 ns |  0.1180 ns |  0.1104 ns |    27.383 ns |  0.37 |    0.00 | 0.0458 |     - |     - |      96 B |
|           Hyperlinq_SIMD |    10 |    34.413 ns |  0.1627 ns |  0.1442 ns |    34.431 ns |  0.46 |    0.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_IFunction_SIMD |    10 |    24.432 ns |  0.1646 ns |  0.1374 ns |    24.381 ns |  0.33 |    0.00 | 0.0459 |     - |     - |      96 B |
|                          |       |              |            |            |              |       |         |        |       |       |           |
|                  **ForLoop** |  **1000** | **2,475.888 ns** |  **8.9279 ns** |  **7.9143 ns** | **2,477.672 ns** |  **1.00** |    **0.00** | **4.0207** |     **-** |     **-** |    **8424 B** |
|              ForeachLoop |  1000 | 3,325.595 ns | 14.0120 ns | 13.1068 ns | 3,322.443 ns |  1.34 |    0.01 | 4.0207 |     - |     - |    8424 B |
|                     Linq |  1000 | 2,516.161 ns |  9.9057 ns |  9.2658 ns | 2,512.125 ns |  1.02 |    0.01 | 1.9722 |     - |     - |    4128 B |
|               LinqFaster |  1000 | 3,084.677 ns | 30.0572 ns | 28.1155 ns | 3,082.760 ns |  1.25 |    0.01 | 3.8757 |     - |     - |    8112 B |
|                   LinqAF |  1000 | 8,545.707 ns | 23.8879 ns | 19.9475 ns | 8,544.347 ns |  3.45 |    0.02 | 4.0131 |     - |     - |    8424 B |
|               StructLinq |  1000 | 2,068.250 ns | 26.4482 ns | 23.4457 ns | 2,069.688 ns |  0.84 |    0.01 | 1.9684 |     - |     - |    4120 B |
|     StructLinq_IFunction |  1000 |   947.861 ns | 11.5533 ns | 10.2417 ns |   945.363 ns |  0.38 |    0.00 | 1.9569 |     - |     - |    4096 B |
|                Hyperlinq |  1000 | 2,044.301 ns |  8.0235 ns |  7.1126 ns | 2,041.785 ns |  0.83 |    0.00 | 1.9341 |     - |     - |    4056 B |
|      Hyperlinq_IFunction |  1000 |   824.719 ns |  2.5587 ns |  2.2682 ns |   823.501 ns |  0.33 |    0.00 | 1.9341 |     - |     - |    4056 B |
|           Hyperlinq_SIMD |  1000 |   636.497 ns |  2.4738 ns |  2.0657 ns |   636.461 ns |  0.26 |    0.00 | 1.9341 |     - |     - |    4056 B |
| Hyperlinq_IFunction_SIMD |  1000 |   353.842 ns |  2.1798 ns |  1.9324 ns |   354.002 ns |  0.14 |    0.00 | 1.9341 |     - |     - |    4056 B |
