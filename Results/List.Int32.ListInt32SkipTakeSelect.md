## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

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
|                      Method | Skip | Count |         Mean |     Error |    StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |-------------:|----------:|----------:|-------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** | **1000** |    **10** |     **10.01 ns** |  **0.024 ns** |  **0.021 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  4,219.27 ns |  9.942 ns |  8.813 ns | 421.49 |    1.41 | 0.0153 |     - |     - |      40 B |
|                        Linq | 1000 |    10 |    175.83 ns |  0.391 ns |  0.347 ns |  17.56 |    0.04 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |    10 |    106.23 ns |  0.630 ns |  0.558 ns |  10.61 |    0.06 | 0.1377 |     - |     - |     288 B |
|                      LinqAF | 1000 |    10 |  4,139.11 ns | 14.714 ns | 13.044 ns | 413.48 |    1.06 |      - |     - |     - |         - |
|                  StructLinq | 1000 |    10 |     73.48 ns |  0.330 ns |  0.293 ns |   7.34 |    0.03 | 0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |    10 |     37.97 ns |  0.070 ns |  0.062 ns |   3.79 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |     59.07 ns |  0.125 ns |  0.098 ns |   5.90 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |     58.08 ns |  0.097 ns |  0.086 ns |   5.80 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |     47.97 ns |  0.079 ns |  0.073 ns |   4.79 |    0.01 |      - |     - |     - |         - |
|                             |      |       |              |           |           |        |         |        |       |       |           |
|                     **ForLoop** | **1000** |  **1000** |  **1,040.25 ns** |  **1.609 ns** |  **1.426 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 |  7,051.46 ns | 19.152 ns | 16.978 ns |   6.78 |    0.02 | 0.0153 |     - |     - |      40 B |
|                        Linq | 1000 |  1000 |  8,991.13 ns | 23.842 ns | 19.909 ns |   8.64 |    0.02 | 0.0610 |     - |     - |     152 B |
|                  LinqFaster | 1000 |  1000 |  7,331.30 ns | 17.419 ns | 15.442 ns |   7.05 |    0.02 | 5.8136 |     - |     - |  12,168 B |
|                      LinqAF | 1000 |  1000 | 15,536.16 ns | 19.038 ns | 14.864 ns |  14.93 |    0.02 |      - |     - |     - |         - |
|                  StructLinq | 1000 |  1000 |  1,920.34 ns |  9.436 ns |  8.365 ns |   1.85 |    0.01 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |  1000 |  1,412.01 ns |  2.343 ns |  1.956 ns |   1.36 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 |  2,130.49 ns |  6.633 ns |  6.204 ns |   2.05 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 |  1,585.54 ns |  3.817 ns |  3.571 ns |   1.52 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 |  2,112.10 ns |  6.198 ns |  5.494 ns |   2.03 |    0.01 |      - |     - |     - |         - |
