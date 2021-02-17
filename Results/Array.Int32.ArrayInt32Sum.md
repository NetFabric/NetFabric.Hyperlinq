## Array.Int32.ArrayInt32Sum

### Source
[ArrayInt32Sum.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Sum.cs)

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
|               Method | Count |          Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |--------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |     **0** |     **0.4990 ns** |  **0.0065 ns** |  **0.0055 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |     0 |     0.2042 ns |  0.0065 ns |  0.0061 ns |  0.41 |    0.01 |      - |     - |     - |         - |
|                 Linq |     0 |     6.7680 ns |  0.0266 ns |  0.0249 ns | 13.57 |    0.18 |      - |     - |     - |         - |
|           LinqFaster |     0 |     1.1642 ns |  0.0136 ns |  0.0114 ns |  2.33 |    0.04 |      - |     - |     - |         - |
|      LinqFaster_SIMD |     0 |     5.5263 ns |  0.0162 ns |  0.0151 ns | 11.08 |    0.12 |      - |     - |     - |         - |
|               LinqAF |     0 |    14.1242 ns |  0.0396 ns |  0.0371 ns | 28.31 |    0.34 |      - |     - |     - |         - |
|           StructLinq |     0 |     8.9172 ns |  0.0352 ns |  0.0329 ns | 17.88 |    0.22 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |     0 |     2.0182 ns |  0.0177 ns |  0.0165 ns |  4.04 |    0.05 |      - |     - |     - |         - |
|            Hyperlinq |     0 |     2.3403 ns |  0.0194 ns |  0.0182 ns |  4.69 |    0.05 |      - |     - |     - |         - |
|                      |       |               |            |            |       |         |        |       |       |           |
|              **ForLoop** |    **10** |     **5.1086 ns** |  **0.0233 ns** |  **0.0207 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     5.1187 ns |  0.0285 ns |  0.0253 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    50.0561 ns |  0.1354 ns |  0.1200 ns |  9.80 |    0.05 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |    10 |     4.2021 ns |  0.0311 ns |  0.0260 ns |  0.82 |    0.01 |      - |     - |     - |         - |
|      LinqFaster_SIMD |    10 |     6.7527 ns |  0.0297 ns |  0.0248 ns |  1.32 |    0.01 |      - |     - |     - |         - |
|               LinqAF |    10 |    30.6807 ns |  0.1465 ns |  0.1299 ns |  6.01 |    0.03 |      - |     - |     - |         - |
|           StructLinq |    10 |    16.7622 ns |  0.0824 ns |  0.0730 ns |  3.28 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     4.8236 ns |  0.0199 ns |  0.0167 ns |  0.94 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    10.0141 ns |  0.0298 ns |  0.0264 ns |  1.96 |    0.01 |      - |     - |     - |         - |
|                      |       |               |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **525.5274 ns** |  **2.6816 ns** |  **2.3771 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   524.6751 ns |  2.5387 ns |  2.2505 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 3,910.9972 ns | 13.3033 ns | 12.4439 ns |  7.44 |    0.04 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |  1000 |   431.6761 ns |  1.0568 ns |  0.9368 ns |  0.82 |    0.00 |      - |     - |     - |         - |
|      LinqFaster_SIMD |  1000 |    53.7152 ns |  0.2545 ns |  0.2256 ns |  0.10 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 | 1,866.4746 ns | 13.0960 ns | 11.6093 ns |  3.55 |    0.03 |      - |     - |     - |         - |
|           StructLinq |  1000 |   675.7218 ns |  2.1519 ns |  1.9076 ns |  1.29 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |   547.6573 ns |  1.2487 ns |  1.1070 ns |  1.04 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |   108.6650 ns |  0.4791 ns |  0.4000 ns |  0.21 |    0.00 |      - |     - |     - |         - |
