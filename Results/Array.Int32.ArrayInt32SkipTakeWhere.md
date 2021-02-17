## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
|               Method | Skip | Count |           Mean |       Error |        StdDev |         Median |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |---------------:|------------:|--------------:|---------------:|-------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **1000** |     **0** |      **0.5842 ns** |   **0.1086 ns** |     **0.3185 ns** |      **0.5720 ns** |      **?** |       **?** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |     0 |  4,804.4762 ns | 122.1184 ns |   360.0689 ns |  4,809.1106 ns |      ? |       ? | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |     0 |     92.8043 ns |   0.7146 ns |     0.6684 ns |     92.6921 ns |      ? |       ? | 0.0497 |     - |     - |     104 B |
|           LinqFaster | 1000 |     0 |     41.0756 ns |   0.5475 ns |     0.4853 ns |     40.9921 ns |      ? |       ? | 0.0344 |     - |     - |      72 B |
|               LinqAF | 1000 |     0 |     96.4253 ns |   1.4024 ns |     1.3118 ns |     96.6220 ns |      ? |       ? |      - |     - |     - |         - |
|           StructLinq | 1000 |     0 |     58.5539 ns |   0.4744 ns |     0.4206 ns |     58.5353 ns |      ? |       ? | 0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |     0 |     18.4626 ns |   0.0565 ns |     0.0501 ns |     18.4735 ns |      ? |       ? |      - |     - |     - |         - |
|            Hyperlinq | 1000 |     0 |     28.0076 ns |   0.5887 ns |     0.9338 ns |     27.8004 ns |      ? |       ? |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |     0 |     18.0931 ns |   0.1789 ns |     0.1586 ns |     18.0774 ns |      ? |       ? |      - |     - |     - |         - |
|                      |      |       |                |             |               |                |        |         |        |       |       |           |
|              **ForLoop** | **1000** |    **10** |      **9.4634 ns** |   **0.1934 ns** |     **0.3124 ns** |      **9.4589 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |    10 |  2,388.0519 ns |   9.8527 ns |     8.2275 ns |  2,389.2159 ns | 250.22 |    6.72 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |    10 |    276.2157 ns |   5.4268 ns |     7.0564 ns |    274.4250 ns |  29.03 |    1.15 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |    10 |     78.8251 ns |   0.6638 ns |     0.6209 ns |     78.5494 ns |   8.27 |    0.29 | 0.1147 |     - |     - |     240 B |
|               LinqAF | 1000 |    10 |  5,397.8495 ns | 508.1778 ns | 1,441.6158 ns |  4,600.0000 ns | 571.42 |  136.40 |      - |     - |     - |         - |
|           StructLinq | 1000 |    10 |     93.5102 ns |   1.0679 ns |     0.9989 ns |     93.4641 ns |   9.81 |    0.38 | 0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |    10 |     38.1718 ns |   0.0872 ns |     0.0773 ns |     38.1721 ns |   4.02 |    0.12 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |    10 |     76.5959 ns |   1.5190 ns |     4.3093 ns |     76.9089 ns |   8.09 |    0.51 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |    10 |     35.4290 ns |   0.1533 ns |     0.1434 ns |     35.4525 ns |   3.72 |    0.12 |      - |     - |     - |         - |
|                      |      |       |                |             |               |                |        |         |        |       |       |           |
|              **ForLoop** | **1000** |  **1000** |    **925.3875 ns** |   **3.0498 ns** |     **2.8527 ns** |    **925.0288 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |  1000 |  8,836.3076 ns | 178.9511 ns |   527.6413 ns |  8,860.5682 ns |   9.60 |    0.60 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |  1000 | 27,412.4614 ns | 547.5546 ns | 1,247.0589 ns | 27,562.4908 ns |  29.86 |    1.53 | 0.0610 |     - |     - |     152 B |
|           LinqFaster | 1000 |  1000 |  4,634.3268 ns |  31.5195 ns |    26.3202 ns |  4,631.5331 ns |   5.01 |    0.04 | 6.7215 |     - |     - |   14064 B |
|               LinqAF | 1000 |  1000 | 28,269.0449 ns | 557.1899 ns | 1,060.1117 ns | 28,146.7926 ns |  30.32 |    1.46 |      - |     - |     - |         - |
|           StructLinq | 1000 |  1000 |  6,772.7201 ns | 133.9644 ns |   238.1216 ns |  6,794.6381 ns |   7.39 |    0.27 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |  1000 |  1,462.5778 ns |   6.6997 ns |     5.9391 ns |  1,463.1971 ns |   1.58 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |  1000 |  6,675.7185 ns | 131.9526 ns |   213.0788 ns |  6,665.5888 ns |   7.23 |    0.25 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |  1000 |  1,900.9218 ns |   7.5106 ns |     7.0254 ns |  1,899.4698 ns |   2.05 |    0.01 |      - |     - |     - |         - |
