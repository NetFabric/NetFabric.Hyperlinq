## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|                      Method | Skip | Count |          Mean |       Error |        StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |--------------:|------------:|--------------:|-------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** | **1000** |    **10** |      **6.462 ns** |   **0.2134 ns** |     **0.3624 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  5,226.097 ns | 118.3369 ns |   348.9190 ns | 815.11 |   75.28 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |    10 |    268.889 ns |   5.3021 ns |     4.4275 ns |  41.26 |    2.11 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |    10 |     71.852 ns |   0.3387 ns |     0.2828 ns |  11.03 |    0.56 | 0.0918 |     - |     - |     192 B |
|                      LinqAF | 1000 |    10 |  1,966.628 ns |  19.5278 ns |    17.3109 ns | 302.57 |   13.41 |      - |     - |     - |         - |
|                  StructLinq | 1000 |    10 |     79.034 ns |   0.3039 ns |     0.2694 ns |  12.16 |    0.59 | 0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |    10 |     35.740 ns |   0.0675 ns |     0.0598 ns |   5.50 |    0.26 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |     51.697 ns |   0.6148 ns |     0.5751 ns |   8.01 |    0.43 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |     31.989 ns |   0.1362 ns |     0.1274 ns |   4.96 |    0.26 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |     33.515 ns |   0.0703 ns |     0.0623 ns |   5.16 |    0.25 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |    10 |     17.615 ns |   0.0492 ns |     0.0436 ns |   2.71 |    0.13 |      - |     - |     - |         - |
|                             |      |       |               |             |               |        |         |        |       |       |           |
|                     **ForLoop** | **1000** |  **1000** |    **617.080 ns** |   **1.4496 ns** |     **1.2850 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 | 10,410.050 ns | 243.3369 ns |   705.9645 ns |  16.66 |    0.98 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |  1000 | 21,101.090 ns | 561.7886 ns | 1,647.6288 ns |  34.62 |    2.27 | 0.0610 |     - |     - |     152 B |
|                  LinqFaster | 1000 |  1000 |  3,049.346 ns |  10.8782 ns |     9.6433 ns |   4.94 |    0.02 | 5.7678 |     - |     - |   12072 B |
|                      LinqAF | 1000 |  1000 | 22,931.561 ns | 452.1158 ns |   860.1974 ns |  37.13 |    1.26 |      - |     - |     - |         - |
|                  StructLinq | 1000 |  1000 |  2,404.079 ns |   5.7318 ns |     5.3615 ns |   3.90 |    0.01 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |  1000 |  1,562.395 ns |   3.4785 ns |     3.2538 ns |   2.53 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 |  2,363.508 ns |   4.9506 ns |     4.6308 ns |   3.83 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 |  1,412.760 ns |   3.4682 ns |     3.0745 ns |   2.29 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 |  2,594.569 ns |   7.6028 ns |     6.3487 ns |   4.20 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |  1000 |  1,295.428 ns |   2.3027 ns |     2.0412 ns |   2.10 |    0.01 |      - |     - |     - |         - |
