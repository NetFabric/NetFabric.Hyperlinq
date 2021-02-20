## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta39](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta39)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                      Method | Count |          Mean |       Error |      StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |--------------:|------------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** |    **10** |      **5.982 ns** |   **0.1811 ns** |   **0.4476 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |      3.802 ns |   0.1348 ns |   0.3015 ns |  0.64 |    0.06 |      - |     - |     - |         - |
|                        Linq |    10 |    144.713 ns |   2.8265 ns |   3.7733 ns | 24.51 |    1.99 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster |    10 |     38.436 ns |   0.1468 ns |   0.1373 ns |  6.71 |    0.60 | 0.0306 |     - |     - |      64 B |
|             LinqFaster_SIMD |    10 |     27.666 ns |   0.0949 ns |   0.0792 ns |  4.86 |    0.44 | 0.0306 |     - |     - |      64 B |
|                      LinqAF |    10 |    102.151 ns |   2.0379 ns |   4.5158 ns | 17.11 |    1.49 |      - |     - |     - |         - |
|                  StructLinq |    10 |     40.932 ns |   0.1110 ns |   0.0927 ns |  7.19 |    0.66 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |    10 |     35.084 ns |   0.0402 ns |   0.0376 ns |  6.12 |    0.54 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |     37.461 ns |   0.3938 ns |   0.3683 ns |  6.54 |    0.58 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |    10 |     32.150 ns |   0.0424 ns |   0.0331 ns |  5.61 |    0.53 |      - |     - |     - |         - |
|               Hyperlinq_For |    10 |     25.791 ns |   0.0661 ns |   0.0552 ns |  4.53 |    0.41 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |    10 |     14.716 ns |   0.0350 ns |   0.0327 ns |  2.57 |    0.23 |      - |     - |     - |         - |
|              Hyperlinq_SIMD |    10 |     41.877 ns |   0.8566 ns |   1.0197 ns |  7.13 |    0.64 |      - |     - |     - |         - |
|    Hyperlinq_IFunction_SIMD |    10 |     32.977 ns |   0.3981 ns |   0.3529 ns |  5.76 |    0.53 |      - |     - |     - |         - |
|                             |       |               |             |             |       |         |        |       |       |           |
|                     **ForLoop** |  **1000** |    **521.570 ns** |   **2.4008 ns** |   **2.2457 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 |    392.222 ns |   0.7109 ns |   0.6302 ns |  0.75 |    0.00 |      - |     - |     - |         - |
|                        Linq |  1000 | 12,505.667 ns | 245.8691 ns | 634.6667 ns | 23.71 |    1.15 | 0.0153 |     - |     - |      48 B |
|                  LinqFaster |  1000 |  2,516.533 ns |   8.5809 ns |   8.0265 ns |  4.82 |    0.02 | 1.9226 |     - |     - |    4024 B |
|             LinqFaster_SIMD |  1000 |    876.357 ns |   3.4331 ns |   3.2113 ns |  1.68 |    0.01 | 1.9226 |     - |     - |    4024 B |
|                      LinqAF |  1000 |  8,366.455 ns | 170.1500 ns | 499.0205 ns | 15.77 |    0.90 |      - |     - |     - |         - |
|                  StructLinq |  1000 |  2,337.140 ns |   4.8112 ns |   4.2650 ns |  4.48 |    0.02 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |  1000 |  1,386.266 ns |   2.4856 ns |   2.2034 ns |  2.66 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 |  1,839.346 ns |   4.3865 ns |   3.8885 ns |  3.53 |    0.02 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |  1000 |  1,426.855 ns |   3.4714 ns |   3.0773 ns |  2.74 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For |  1000 |  1,821.455 ns |   7.3075 ns |   5.7052 ns |  3.49 |    0.02 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |  1000 |    782.380 ns |   1.7225 ns |   1.5270 ns |  1.50 |    0.01 |      - |     - |     - |         - |
|              Hyperlinq_SIMD |  1000 |  2,127.763 ns |  13.0466 ns |  11.5655 ns |  4.08 |    0.03 |      - |     - |     - |         - |
|    Hyperlinq_IFunction_SIMD |  1000 |  1,413.212 ns |   4.8320 ns |   4.2834 ns |  2.71 |    0.01 |      - |     - |     - |         - |
