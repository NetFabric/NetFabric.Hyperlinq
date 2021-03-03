## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta42](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta42)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                      Method | Skip | Count |          Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |--------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** | **1000** |    **10** |      **5.592 ns** |  **0.0222 ns** |  **0.0185 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  2,383.386 ns |  9.0207 ns |  7.9966 ns | 426.37 |    2.01 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |    10 |    194.588 ns |  0.4937 ns |  0.4123 ns |  34.80 |    0.15 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |    10 |     55.252 ns |  0.2161 ns |  0.1805 ns |   9.88 |    0.04 | 0.0918 |     - |     - |     192 B |
|                      LinqAF | 1000 |    10 |  2,009.833 ns |  5.1469 ns |  4.2979 ns | 359.44 |    1.68 |      - |     - |     - |         - |
|                  StructLinq | 1000 |    10 |     73.320 ns |  0.1445 ns |  0.1128 ns |  13.11 |    0.05 | 0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |    10 |     37.065 ns |  0.0647 ns |  0.0573 ns |   6.63 |    0.03 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |     58.947 ns |  0.1568 ns |  0.1390 ns |  10.54 |    0.05 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |     57.892 ns |  0.0864 ns |  0.0808 ns |  10.35 |    0.04 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |     47.073 ns |  0.1041 ns |  0.0973 ns |   8.42 |    0.03 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |    10 |     37.273 ns |  0.0813 ns |  0.0761 ns |   6.67 |    0.02 |      - |     - |     - |         - |
|                             |      |       |               |            |            |        |         |        |       |       |           |
|                     **ForLoop** | **1000** |  **1000** |    **777.972 ns** |  **1.4753 ns** |  **1.3078 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 |  4,426.482 ns |  8.6176 ns |  7.6392 ns |   5.69 |    0.01 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |  1000 |  9,480.585 ns | 21.9939 ns | 18.3659 ns |  12.19 |    0.02 | 0.0610 |     - |     - |     152 B |
|                  LinqFaster | 1000 |  1000 |  2,774.632 ns | 11.0043 ns | 10.2934 ns |   3.57 |    0.02 | 5.7678 |     - |     - |  12,072 B |
|                      LinqAF | 1000 |  1000 | 11,128.965 ns | 37.8325 ns | 33.5375 ns |  14.31 |    0.05 |      - |     - |     - |         - |
|                  StructLinq | 1000 |  1000 |  1,899.896 ns |  3.5215 ns |  3.1217 ns |   2.44 |    0.00 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |  1000 |  1,564.612 ns |  2.1766 ns |  1.9295 ns |   2.01 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 |  2,110.961 ns |  3.9347 ns |  3.4880 ns |   2.71 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 |  1,458.906 ns |  2.1237 ns |  1.8826 ns |   1.88 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 |  2,104.089 ns |  8.2585 ns |  7.7250 ns |   2.70 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |  1000 |  1,562.502 ns |  4.0667 ns |  3.3959 ns |   2.01 |    0.01 |      - |     - |     - |         - |
