## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                      Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** |    **10** |     **6.284 ns** |  **0.0318 ns** |  **0.0282 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |     4.838 ns |  0.0254 ns |  0.0198 ns |  0.77 |    0.00 |      - |     - |     - |         - |
|                        Linq |    10 |   111.445 ns |  0.5132 ns |  0.4800 ns | 17.73 |    0.13 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster |    10 |    31.394 ns |  0.4201 ns |  0.3508 ns |  4.99 |    0.07 | 0.0306 |     - |     - |      64 B |
|             LinqFaster_SIMD |    10 |    19.925 ns |  0.1070 ns |  0.1001 ns |  3.17 |    0.02 | 0.0306 |     - |     - |      64 B |
|                      LinqAF |    10 |    67.885 ns |  0.2478 ns |  0.2069 ns | 10.80 |    0.06 |      - |     - |     - |         - |
|                  StructLinq |    10 |    40.829 ns |  0.2594 ns |  0.2426 ns |  6.50 |    0.05 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |    10 |    39.520 ns |  0.1215 ns |  0.1077 ns |  6.29 |    0.04 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |    43.203 ns |  0.1585 ns |  0.1323 ns |  6.87 |    0.04 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |    10 |    43.570 ns |  0.1168 ns |  0.1092 ns |  6.93 |    0.03 |      - |     - |     - |         - |
|               Hyperlinq_For |    10 |    33.814 ns |  0.1722 ns |  0.1610 ns |  5.38 |    0.03 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |    10 |    25.491 ns |  0.0476 ns |  0.0446 ns |  4.06 |    0.02 |      - |     - |     - |         - |
|                             |       |              |            |            |       |         |        |       |       |           |
|                     **ForLoop** |  **1000** |   **546.571 ns** |  **3.3766 ns** |  **2.8196 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 |   548.980 ns |  4.6820 ns |  3.9097 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                        Linq |  1000 | 6,178.549 ns | 31.5740 ns | 27.9896 ns | 11.30 |    0.09 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster |  1000 | 2,621.040 ns | 12.5003 ns | 11.0812 ns |  4.80 |    0.03 | 1.9226 |     - |     - |   4,024 B |
|             LinqFaster_SIMD |  1000 |   897.029 ns | 13.0890 ns | 10.9299 ns |  1.64 |    0.02 | 1.9226 |     - |     - |   4,024 B |
|                      LinqAF |  1000 | 4,543.109 ns | 31.0969 ns | 29.0881 ns |  8.30 |    0.07 |      - |     - |     - |         - |
|                  StructLinq |  1000 | 2,248.333 ns | 20.8583 ns | 18.4904 ns |  4.11 |    0.04 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |  1000 | 1,482.416 ns |  9.0742 ns |  8.0440 ns |  2.71 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 | 2,153.798 ns | 13.7519 ns | 12.1907 ns |  3.94 |    0.03 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |  1000 | 1,702.478 ns |  4.8644 ns |  3.7978 ns |  3.12 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For |  1000 | 2,163.925 ns |  9.9796 ns |  8.8467 ns |  3.96 |    0.02 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |  1000 | 1,079.026 ns |  3.6468 ns |  3.2328 ns |  1.97 |    0.01 |      - |     - |     - |         - |
