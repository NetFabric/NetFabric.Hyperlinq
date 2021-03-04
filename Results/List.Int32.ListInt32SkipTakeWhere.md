## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta43](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta43)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Skip | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **1000** |    **10** |     **11.40 ns** |   **0.046 ns** |   **0.041 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |    10 |  4,328.83 ns |  30.191 ns |  28.241 ns | 379.71 |    2.71 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |    10 |    206.59 ns |   0.510 ns |   0.426 ns |  18.11 |    0.09 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |    10 |    126.71 ns |   0.599 ns |   0.560 ns |  11.11 |    0.07 | 0.1528 |     - |     - |     320 B |
|               LinqAF | 1000 |    10 |  4,339.94 ns |  11.427 ns |   9.542 ns | 380.43 |    1.61 |      - |     - |     - |         - |
|           StructLinq | 1000 |    10 |     82.91 ns |   0.303 ns |   0.269 ns |   7.27 |    0.04 | 0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |    10 |     40.08 ns |   0.066 ns |   0.055 ns |   3.51 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |    10 |     61.73 ns |   0.373 ns |   0.349 ns |   5.41 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |    10 |     55.74 ns |   0.182 ns |   0.161 ns |   4.89 |    0.02 |      - |     - |     - |         - |
|                      |      |       |              |            |            |        |         |        |       |       |           |
|              **ForLoop** | **1000** |  **1000** |  **1,255.80 ns** |  **19.827 ns** |  **18.546 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |  1000 |  7,896.79 ns |  34.925 ns |  32.669 ns |   6.29 |    0.10 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |  1000 | 16,153.30 ns |  76.489 ns |  59.718 ns |  12.88 |    0.19 | 0.0610 |     - |     - |     152 B |
|           LinqFaster | 1000 |  1000 |  8,255.00 ns |  59.297 ns |  55.466 ns |   6.57 |    0.11 | 5.9204 |     - |     - |  12,416 B |
|               LinqAF | 1000 |  1000 | 20,313.51 ns | 276.708 ns | 258.833 ns |  16.18 |    0.32 |      - |     - |     - |         - |
|           StructLinq | 1000 |  1000 |  6,283.03 ns |  17.588 ns |  16.452 ns |   5.00 |    0.07 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |  1000 |  1,853.34 ns |  18.014 ns |  16.850 ns |   1.48 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |  1000 |  6,743.13 ns |  27.921 ns |  23.315 ns |   5.37 |    0.08 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |  1000 |  1,989.55 ns |  28.108 ns |  26.292 ns |   1.58 |    0.03 |      - |     - |     - |         - |
