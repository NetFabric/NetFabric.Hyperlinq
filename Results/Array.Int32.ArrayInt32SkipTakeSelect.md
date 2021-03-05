## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                      Method | Skip | Count |          Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |--------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** | **1000** |    **10** |      **5.537 ns** |  **0.0178 ns** |  **0.0149 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  2,385.522 ns | 12.4903 ns | 11.6834 ns | 431.10 |    2.16 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |    10 |    194.729 ns |  0.6265 ns |  0.5860 ns |  35.16 |    0.16 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |    10 |     54.248 ns |  0.2844 ns |  0.2522 ns |   9.80 |    0.06 | 0.0918 |     - |     - |     192 B |
|                      LinqAF | 1000 |    10 |  1,868.676 ns |  8.3737 ns |  7.4231 ns | 337.53 |    1.66 |      - |     - |     - |         - |
|                  StructLinq | 1000 |    10 |     85.708 ns |  0.6837 ns |  0.5710 ns |  15.48 |    0.09 | 0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |    10 |     37.471 ns |  0.0514 ns |  0.0456 ns |   6.77 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |     59.368 ns |  0.0910 ns |  0.0760 ns |  10.72 |    0.04 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |     57.594 ns |  0.0822 ns |  0.0769 ns |  10.40 |    0.03 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |     48.813 ns |  0.1401 ns |  0.1242 ns |   8.82 |    0.03 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |    10 |     38.291 ns |  0.0819 ns |  0.0726 ns |   6.92 |    0.02 |      - |     - |     - |         - |
|                             |      |       |               |            |            |        |         |        |       |       |           |
|                     **ForLoop** | **1000** |  **1000** |    **544.134 ns** |  **0.9864 ns** |  **0.8744 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 |  4,198.779 ns | 24.9768 ns | 20.8567 ns |   7.72 |    0.04 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |  1000 |  9,255.977 ns | 27.5600 ns | 23.0138 ns |  17.01 |    0.05 | 0.0610 |     - |     - |     152 B |
|                  LinqFaster | 1000 |  1000 |  2,793.920 ns | 18.1556 ns | 16.0944 ns |   5.13 |    0.03 | 5.7678 |     - |     - |  12,072 B |
|                      LinqAF | 1000 |  1000 | 10,998.226 ns | 37.7405 ns | 35.3025 ns |  20.21 |    0.08 |      - |     - |     - |         - |
|                  StructLinq | 1000 |  1000 |  1,933.704 ns |  9.4802 ns |  7.9164 ns |   3.55 |    0.02 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |  1000 |  1,405.198 ns |  2.3883 ns |  2.1171 ns |   2.58 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 |  2,119.250 ns |  5.8905 ns |  5.2218 ns |   3.89 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 |  1,490.455 ns |  4.2005 ns |  3.5076 ns |   2.74 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 |  2,359.777 ns |  4.7943 ns |  4.2500 ns |   4.34 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |  1000 |    812.528 ns |  1.4870 ns |  1.2417 ns |   1.49 |    0.00 |      - |     - |     - |         - |
