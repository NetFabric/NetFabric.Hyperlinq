## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

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
|               Method | Skip | Count |           Mean |       Error |        StdDev |    Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |---------------:|------------:|--------------:|---------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **1000** |     **0** |      **0.7435 ns** |   **0.1158 ns** |     **0.3379 ns** |        **?** |       **?** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |     0 |  6,720.7451 ns | 133.9687 ns |   231.0893 ns |        ? |       ? | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |     0 |     73.4543 ns |   0.4156 ns |     0.3471 ns |        ? |       ? | 0.0497 |     - |     - |     104 B |
|           LinqFaster | 1000 |     0 |     34.2618 ns |   0.1065 ns |     0.0831 ns |        ? |       ? | 0.0459 |     - |     - |      96 B |
|               LinqAF | 1000 |     0 |    118.1340 ns |   1.4382 ns |     1.3453 ns |        ? |       ? |      - |     - |     - |         - |
|           StructLinq | 1000 |     0 |     57.0626 ns |   0.4017 ns |     0.3561 ns |        ? |       ? | 0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |     0 |     20.8648 ns |   0.0424 ns |     0.0376 ns |        ? |       ? |      - |     - |     - |         - |
|            Hyperlinq | 1000 |     0 |     26.6545 ns |   0.5904 ns |     0.7250 ns |        ? |       ? |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |     0 |     18.3985 ns |   0.1706 ns |     0.1595 ns |        ? |       ? |      - |     - |     - |         - |
|                      |      |       |                |             |               |          |         |        |       |       |           |
|              **ForLoop** | **1000** |    **10** |      **9.4953 ns** |   **0.2646 ns** |     **0.3622 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |    10 |  7,191.3723 ns | 143.7078 ns |   269.9180 ns |   763.28 |   41.17 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |    10 |    280.6125 ns |   5.5954 ns |     6.2193 ns |    29.75 |    1.37 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |    10 |    148.0458 ns |   1.1616 ns |     1.0866 ns |    15.68 |    0.67 | 0.1528 |     - |     - |     320 B |
|               LinqAF | 1000 |    10 | 11,795.9665 ns | 235.6657 ns |   653.0285 ns | 1,217.61 |   78.43 |      - |     - |     - |         - |
|           StructLinq | 1000 |    10 |     90.2201 ns |   1.1706 ns |     1.0950 ns |     9.56 |    0.41 | 0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |    10 |     37.1821 ns |   0.0899 ns |     0.0841 ns |     3.94 |    0.16 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |    10 |     81.4098 ns |   1.6619 ns |     4.7146 ns |     8.56 |    0.56 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |    10 |     34.4737 ns |   0.2153 ns |     0.1908 ns |     3.64 |    0.16 |      - |     - |     - |         - |
|                      |      |       |                |             |               |          |         |        |       |       |           |
|              **ForLoop** | **1000** |  **1000** |    **895.9720 ns** |   **5.1468 ns** |     **4.5625 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |  1000 | 14,261.8305 ns | 283.6984 ns |   532.8544 ns |    16.15 |    0.75 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |  1000 | 29,374.1002 ns | 583.1903 ns | 1,682.6372 ns |    34.04 |    1.84 | 0.0610 |     - |     - |     152 B |
|           LinqFaster | 1000 |  1000 | 11,131.1218 ns |  72.9858 ns |    68.2709 ns |    12.43 |    0.10 | 5.9204 |     - |     - |   12416 B |
|               LinqAF | 1000 |  1000 | 42,933.9466 ns | 848.1879 ns | 2,032.2041 ns |    48.37 |    2.15 |      - |     - |     - |         - |
|           StructLinq | 1000 |  1000 |  6,327.1111 ns | 125.4306 ns |   226.1772 ns |     7.00 |    0.28 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |  1000 |  1,785.2386 ns |   6.2932 ns |     5.5788 ns |     1.99 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |  1000 |  7,584.2229 ns | 148.2151 ns |   243.5216 ns |     8.49 |    0.33 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |  1000 |  5,516.4914 ns |  17.1402 ns |    16.0330 ns |     6.16 |    0.03 |      - |     - |     - |         - |
