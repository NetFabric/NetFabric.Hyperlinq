## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|              **ForLoop** |     **0** |      **0.2856 ns** |  **0.0090 ns** |  **0.0080 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |     0 |      2.8013 ns |  0.0112 ns |  0.0088 ns |   9.79 |    0.27 |      - |     - |     - |         - |
|                 Linq |     0 |     71.4325 ns |  0.2927 ns |  0.2738 ns | 250.34 |    6.77 | 0.0726 |     - |     - |     152 B |
|           LinqFaster |     0 |      8.9762 ns |  0.0301 ns |  0.0281 ns |  31.46 |    0.88 | 0.0153 |     - |     - |      32 B |
|               LinqAF |     0 |     44.5650 ns |  0.1459 ns |  0.1365 ns | 156.14 |    4.28 |      - |     - |     - |         - |
|           StructLinq |     0 |     32.9139 ns |  0.2176 ns |  0.1817 ns | 115.27 |    3.38 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction |     0 |     36.2400 ns |  0.0772 ns |  0.0722 ns | 126.95 |    3.42 |      - |     - |     - |         - |
|            Hyperlinq |     0 |     25.8798 ns |  0.0477 ns |  0.0398 ns |  90.63 |    2.59 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |     23.6173 ns |  0.0601 ns |  0.0562 ns |  82.72 |    2.22 |      - |     - |     - |         - |
|                      |       |                |            |            |        |         |        |       |       |           |
|              **ForLoop** |    **10** |     **10.4340 ns** |  **0.0329 ns** |  **0.0291 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     31.5103 ns |  0.2614 ns |  0.2317 ns |   3.02 |    0.02 |      - |     - |     - |         - |
|                 Linq |    10 |    124.4098 ns |  0.8324 ns |  0.7379 ns |  11.92 |    0.07 | 0.0725 |     - |     - |     152 B |
|           LinqFaster |    10 |     50.7892 ns |  0.2273 ns |  0.1898 ns |   4.87 |    0.02 | 0.0344 |     - |     - |      72 B |
|               LinqAF |    10 |    112.6483 ns |  0.5022 ns |  0.4698 ns |  10.79 |    0.05 |      - |     - |     - |         - |
|           StructLinq |    10 |     57.1132 ns |  0.1577 ns |  0.1398 ns |   5.47 |    0.02 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |     51.9161 ns |  0.1154 ns |  0.1079 ns |   4.97 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |    10 |     46.1292 ns |  0.0870 ns |  0.0727 ns |   4.42 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     40.9638 ns |  0.0983 ns |  0.0871 ns |   3.93 |    0.01 |      - |     - |     - |         - |
|                      |       |                |            |            |        |         |        |       |       |           |
|              **ForLoop** |  **1000** |    **993.5150 ns** |  **3.3813 ns** |  **3.1628 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  3,712.9222 ns |  7.8810 ns |  6.9863 ns |   3.74 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 11,442.3093 ns | 25.6861 ns | 21.4490 ns |  11.51 |    0.05 | 0.0610 |     - |     - |     152 B |
|           LinqFaster |  1000 |  6,123.7300 ns | 22.5306 ns | 19.9728 ns |   6.16 |    0.03 | 2.0523 |     - |     - |    4304 B |
|               LinqAF |  1000 | 12,493.1015 ns | 33.6940 ns | 29.8688 ns |  12.57 |    0.05 |      - |     - |     - |         - |
|           StructLinq |  1000 |  5,428.3776 ns | 14.9427 ns | 13.2464 ns |   5.46 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 |  1,489.2775 ns |  7.9806 ns |  7.4651 ns |   1.50 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |  4,842.8313 ns | 22.4532 ns | 18.7495 ns |   4.87 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  1,913.5605 ns |  7.3455 ns |  6.5116 ns |   1.93 |    0.01 |      - |     - |     - |         - |
