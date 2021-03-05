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

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                      Method | Skip | Count |          Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |--------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** | **1000** |    **10** |      **7.653 ns** |  **0.0172 ns** |  **0.0153 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  2,124.569 ns |  5.1660 ns |  4.8323 ns | 277.56 |    0.78 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |    10 |    242.012 ns |  0.8311 ns |  0.7367 ns |  31.62 |    0.09 | 0.0839 |     - |     - |     176 B |
|                  StructLinq | 1000 |    10 |     86.680 ns |  0.2353 ns |  0.2201 ns |  11.33 |    0.04 | 0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |    10 |     45.312 ns |  0.0969 ns |  0.0859 ns |   5.92 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |     58.413 ns |  0.2522 ns |  0.2236 ns |   7.63 |    0.04 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |     57.510 ns |  0.0851 ns |  0.0796 ns |   7.51 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |     48.579 ns |  0.1560 ns |  0.1383 ns |   6.35 |    0.02 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |    10 |     38.569 ns |  0.0623 ns |  0.0582 ns |   5.04 |    0.01 |      - |     - |     - |         - |
|                             |      |       |               |            |            |        |         |        |       |       |           |
|                     **ForLoop** | **1000** |  **1000** |    **782.145 ns** |  **1.2616 ns** |  **1.1801 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 |  4,588.633 ns | 12.2419 ns | 10.2226 ns |   5.87 |    0.02 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |  1000 | 15,033.451 ns | 43.5729 ns | 38.6262 ns |  19.22 |    0.06 | 0.0763 |     - |     - |     176 B |
|                  StructLinq | 1000 |  1000 |  3,474.675 ns | 10.4212 ns |  9.2381 ns |   4.44 |    0.01 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |  1000 |  2,724.295 ns |  9.6457 ns |  8.5507 ns |   3.48 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 |  1,858.724 ns |  3.7834 ns |  3.3539 ns |   2.38 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 |  1,543.568 ns |  2.2526 ns |  2.1071 ns |   1.97 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 |  1,845.130 ns |  3.5263 ns |  3.1260 ns |   2.36 |    0.00 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |  1000 |  1,573.190 ns |  2.4569 ns |  2.1779 ns |   2.01 |    0.00 |      - |     - |     - |         - |
