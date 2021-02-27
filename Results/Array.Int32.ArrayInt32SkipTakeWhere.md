## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta41](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta41)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Skip | Count |          Mean |       Error |      StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |--------------:|------------:|------------:|-------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **1000** |    **10** |      **9.381 ns** |   **0.1127 ns** |   **0.0942 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |    10 |  2,210.300 ns |  11.9502 ns |  10.5936 ns | 235.63 |    2.53 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |    10 |    228.011 ns |   1.5585 ns |   1.4578 ns |  24.28 |    0.27 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |    10 |     75.394 ns |   0.3857 ns |   0.3012 ns |   8.03 |    0.09 | 0.1147 |     - |     - |     240 B |
|               LinqAF | 1000 |    10 |  2,044.945 ns |   8.5202 ns |   7.9698 ns | 218.01 |    2.24 |      - |     - |     - |         - |
|           StructLinq | 1000 |    10 |     85.706 ns |   0.7589 ns |   0.6727 ns |   9.14 |    0.08 | 0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |    10 |     40.153 ns |   0.1747 ns |   0.1459 ns |   4.28 |    0.05 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |    10 |     62.662 ns |   0.3256 ns |   0.2719 ns |   6.68 |    0.09 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |    10 |     56.895 ns |   0.2205 ns |   0.1955 ns |   6.07 |    0.07 |      - |     - |     - |         - |
|                      |      |       |               |             |             |        |         |        |       |       |           |
|              **ForLoop** | **1000** |  **1000** |    **996.226 ns** |   **7.2436 ns** |   **6.0487 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |  1000 |  4,680.272 ns |  49.7438 ns |  46.5304 ns |   4.70 |    0.06 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |  1000 | 16,269.497 ns | 164.7112 ns | 128.5957 ns |  16.32 |    0.15 | 0.0610 |     - |     - |     152 B |
|           LinqFaster | 1000 |  1000 |  5,012.797 ns |  42.4175 ns |  37.6021 ns |   5.03 |    0.06 | 6.7215 |     - |     - |  14,064 B |
|               LinqAF | 1000 |  1000 | 15,787.402 ns | 121.4692 ns |  94.8351 ns |  15.84 |    0.14 |      - |     - |     - |         - |
|           StructLinq | 1000 |  1000 |  5,830.948 ns |  15.0570 ns |  13.3477 ns |   5.85 |    0.04 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |  1000 |  1,677.861 ns |  23.9653 ns |  22.4171 ns |   1.68 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |  1000 |  4,961.424 ns |  21.5485 ns |  19.1022 ns |   4.98 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |  1000 |  2,035.864 ns |  24.0477 ns |  20.0809 ns |   2.04 |    0.01 |      - |     - |     - |         - |
