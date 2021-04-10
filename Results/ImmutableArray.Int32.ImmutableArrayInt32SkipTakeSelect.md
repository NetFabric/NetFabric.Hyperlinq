## ImmutableArray.Int32.ImmutableArrayInt32SkipTakeSelect

### Source
[ImmutableArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32SkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                      Method | Skip | Count |          Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |--------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** | **1000** |    **10** |      **5.764 ns** |  **0.0267 ns** |  **0.0223 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  2,204.362 ns | 13.9850 ns | 11.6781 ns | 382.46 |    2.68 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |    10 |    263.416 ns |  2.0035 ns |  1.7761 ns |  45.71 |    0.36 | 0.0839 |     - |     - |     176 B |
|                  StructLinq | 1000 |    10 |     88.280 ns |  0.3722 ns |  0.3300 ns |  15.32 |    0.09 | 0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |    10 |     47.725 ns |  0.1316 ns |  0.1167 ns |   8.28 |    0.03 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |     60.351 ns |  0.1337 ns |  0.1250 ns |  10.47 |    0.04 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |     61.541 ns |  0.3441 ns |  0.3219 ns |  10.67 |    0.05 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |     50.121 ns |  0.4604 ns |  0.4307 ns |   8.70 |    0.11 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |    10 |     45.097 ns |  0.1405 ns |  0.1173 ns |   7.82 |    0.03 |      - |     - |     - |         - |
|                             |      |       |               |            |            |        |         |        |       |       |           |
|                     **ForLoop** | **1000** |  **1000** |    **616.249 ns** |  **6.7646 ns** |  **5.9967 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 |  4,908.736 ns | 24.5324 ns | 22.9476 ns |   7.97 |    0.07 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |  1000 | 14,420.506 ns | 38.4392 ns | 34.0754 ns |  23.40 |    0.21 | 0.0763 |     - |     - |     176 B |
|                  StructLinq | 1000 |  1000 |  3,012.397 ns | 11.4178 ns | 10.1215 ns |   4.89 |    0.05 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |  1000 |  2,130.784 ns | 11.8177 ns |  9.8683 ns |   3.46 |    0.04 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 |  1,919.617 ns |  8.7392 ns |  8.1747 ns |   3.12 |    0.03 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 |  1,810.480 ns | 10.0766 ns |  9.4256 ns |   2.94 |    0.03 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 |  2,205.288 ns | 15.7946 ns | 14.0015 ns |   3.58 |    0.04 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |  1000 |  1,612.778 ns |  6.3569 ns |  5.3083 ns |   2.62 |    0.03 |      - |     - |     - |         - |
