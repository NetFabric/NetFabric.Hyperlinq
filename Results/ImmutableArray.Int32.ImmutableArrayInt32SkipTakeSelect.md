## ImmutableArray.Int32.ImmutableArrayInt32SkipTakeSelect

### Source
[ImmutableArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32SkipTakeSelect.cs)

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
|                      Method | Skip | Count |          Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |--------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** | **1000** |    **10** |      **7.649 ns** |  **0.0405 ns** |  **0.0379 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  2,181.179 ns |  8.2456 ns |  7.7129 ns | 285.17 |    2.07 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |    10 |    241.640 ns |  1.1821 ns |  1.0479 ns |  31.58 |    0.24 | 0.0839 |     - |     - |     176 B |
|                  StructLinq | 1000 |    10 |     93.242 ns |  0.4592 ns |  0.4070 ns |  12.19 |    0.08 | 0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |    10 |     46.195 ns |  0.1684 ns |  0.1493 ns |   6.04 |    0.04 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |     58.089 ns |  0.2068 ns |  0.1833 ns |   7.59 |    0.04 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |     45.381 ns |  0.1665 ns |  0.1476 ns |   5.93 |    0.04 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |     48.977 ns |  0.1298 ns |  0.1150 ns |   6.40 |    0.04 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |    10 |     34.269 ns |  0.1821 ns |  0.1703 ns |   4.48 |    0.04 |      - |     - |     - |         - |
|                             |      |       |               |            |            |        |         |        |       |       |           |
|                     **ForLoop** | **1000** |  **1000** |    **799.017 ns** |  **2.3988 ns** |  **2.2438 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 |  5,120.511 ns | 26.2032 ns | 21.8809 ns |   6.41 |    0.04 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |  1000 | 15,475.658 ns | 91.3258 ns | 76.2612 ns |  19.36 |    0.13 | 0.0610 |     - |     - |     176 B |
|                  StructLinq | 1000 |  1000 |  3,562.340 ns | 13.3294 ns | 11.8162 ns |   4.46 |    0.02 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |  1000 |  2,467.556 ns | 17.1478 ns | 16.0401 ns |   3.09 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 |  3,976.402 ns | 15.2123 ns | 14.2296 ns |   4.98 |    0.03 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 |  2,683.659 ns | 10.2756 ns |  9.1090 ns |   3.36 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 |  3,757.014 ns | 18.7317 ns | 16.6051 ns |   4.70 |    0.03 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |  1000 |  2,934.446 ns | 10.1837 ns |  9.5259 ns |   3.67 |    0.01 |      - |     - |     - |         - |
