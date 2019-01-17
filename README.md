# NetFabric.Hyperlinq

This is work in progress!...

This repository contains the results of my exploration on how LINQ performance can be improved by using modern C# features like constrained interfaces, readonly struct, refs, value tuples and so on.

There are alternatives. Please check [FastLinq](https://github.com/ndrwrbgs/FastLinq), [LinqFaster](https://github.com/jackmott/LinqFaster) and [LinqMeta](https://github.com/blowin/LinqMeta).

## Benchmarks

``` ini

BenchmarkDotNet=v0.11.3, OS=macOS High Sierra 10.13.6 (17G4015) [Darwin 17.7.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=2.1.403
  [Host]     : .NET Core 2.1.6 (CoreCLR 4.6.27019.06, CoreFX 4.6.27019.05), 64bit RyuJIT
  DefaultJob : .NET Core 2.1.6 (CoreCLR 4.6.27019.06, CoreFX 4.6.27019.05), 64bit RyuJIT


```

### Source operators

|                             Method |       Categories | Count |           Mean |       Error |      StdDev | Ratio | RatioSD | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|----------------------------------- |----------------- |------ |---------------:|------------:|------------:|------:|--------:|------------:|------------:|------------:|--------------------:|
|                         **Linq_Range** |            **Range** |     **0** |      **9.3160 ns** |   **0.2074 ns** |   **0.2037 ns** |  **1.00** |    **0.00** |           **-** |           **-** |           **-** |                   **-** |
|            Hyperlinq_Range_ForEach |            Range |     0 |     13.2462 ns |   0.0607 ns |   0.0507 ns |  1.42 |    0.03 |           - |           - |           - |                   - |
|                Hyperlinq_Range_For |            Range |     0 |      7.3124 ns |   0.0113 ns |   0.0101 ns |  0.78 |    0.02 |           - |           - |           - |                   - |
|                                    |                  |       |                |             |             |       |         |             |             |             |                     |
|                        Linq_Repeat |           Repeat |     0 |      9.4963 ns |   0.2170 ns |   0.3112 ns |  1.00 |    0.00 |           - |           - |           - |                   - |
|           Hyperlinq_Repeat_ForEach |           Repeat |     0 |     13.7997 ns |   0.0687 ns |   0.0609 ns |  1.45 |    0.05 |           - |           - |           - |                   - |
|               Hyperlinq_Repeat_For |           Repeat |     0 |      6.9974 ns |   0.0096 ns |   0.0080 ns |  0.73 |    0.02 |           - |           - |           - |                   - |
|                                    |                  |       |                |             |             |       |         |             |             |             |                     |
|                          Ix_Repeat | RepeatInfinitely |     0 |     15.9035 ns |   0.3446 ns |   0.4831 ns |  1.00 |    0.00 |      0.0190 |           - |           - |                40 B |
| Hyperlinq_RepeatInfinitely_ForEach | RepeatInfinitely |     0 |      0.3028 ns |   0.0182 ns |   0.0161 ns |  0.02 |    0.00 |           - |           - |           - |                   - |
|     Hyperlinq_RepeatInfinitely_For | RepeatInfinitely |     0 |      0.2522 ns |   0.0101 ns |   0.0094 ns |  0.02 |    0.00 |           - |           - |           - |                   - |
|                                    |                  |       |                |             |             |       |         |             |             |             |                     |
|                          Ix_Create |           Create |     0 |     29.6854 ns |   0.1768 ns |   0.1568 ns |  1.00 |    0.00 |      0.0533 |           - |           - |               112 B |
|           Hyperlinq_Create_ForEach |           Create |     0 |     15.0638 ns |   0.0723 ns |   0.0676 ns |  0.51 |    0.00 |      0.0305 |           - |           - |                64 B |
|               Hyperlinq_Create_For |           Create |     0 |     28.4956 ns |   0.2216 ns |   0.1965 ns |  0.96 |    0.01 |      0.0610 |           - |           - |               128 B |
|                                    |                  |       |                |             |             |       |         |             |             |             |                     |
|                         **Linq_Range** |            **Range** |   **100** |    **548.7455 ns** |   **3.1530 ns** |   **2.9493 ns** |  **1.00** |    **0.00** |      **0.0181** |           **-** |           **-** |                **40 B** |
|            Hyperlinq_Range_ForEach |            Range |   100 |    185.8368 ns |   0.4718 ns |   0.4413 ns |  0.34 |    0.00 |           - |           - |           - |                   - |
|                Hyperlinq_Range_For |            Range |   100 |     71.4169 ns |   1.4434 ns |   1.4823 ns |  0.13 |    0.00 |           - |           - |           - |                   - |
|                                    |                  |       |                |             |             |       |         |             |             |             |                     |
|                        Linq_Repeat |           Repeat |   100 |    543.7472 ns |   8.5043 ns |   7.9549 ns |  1.00 |    0.00 |      0.0143 |           - |           - |                32 B |
|           Hyperlinq_Repeat_ForEach |           Repeat |   100 |    175.8737 ns |   0.1600 ns |   0.1249 ns |  0.32 |    0.01 |           - |           - |           - |                   - |
|               Hyperlinq_Repeat_For |           Repeat |   100 |     66.7061 ns |   0.4298 ns |   0.3355 ns |  0.12 |    0.00 |           - |           - |           - |                   - |
|                                    |                  |       |                |             |             |       |         |             |             |             |                     |
|                          Ix_Repeat | RepeatInfinitely |   100 |    561.8767 ns |   3.9272 ns |   3.6735 ns |  1.00 |    0.00 |      0.0181 |           - |           - |                40 B |
| Hyperlinq_RepeatInfinitely_ForEach | RepeatInfinitely |   100 |     42.9170 ns |   0.7178 ns |   0.6714 ns |  0.08 |    0.00 |           - |           - |           - |                   - |
|     Hyperlinq_RepeatInfinitely_For | RepeatInfinitely |   100 |     36.9333 ns |   0.1905 ns |   0.1782 ns |  0.07 |    0.00 |           - |           - |           - |                   - |
|                                    |                  |       |                |             |             |       |         |             |             |             |                     |
|                          Ix_Create |           Create |   100 |    664.9617 ns |   4.1449 ns |   3.6744 ns |  1.00 |    0.00 |      0.0525 |           - |           - |               112 B |
|           Hyperlinq_Create_ForEach |           Create |   100 |    180.6270 ns |   1.0238 ns |   0.9577 ns |  0.27 |    0.00 |      0.0303 |           - |           - |                64 B |
|               Hyperlinq_Create_For |           Create |   100 |    293.2971 ns |   2.0037 ns |   1.6732 ns |  0.44 |    0.00 |      0.0606 |           - |           - |               128 B |
|                                    |                  |       |                |             |             |       |         |             |             |             |                     |
|                         **Linq_Range** |            **Range** | **10000** | **50,926.7621 ns** | **286.8113 ns** | **239.5004 ns** |  **1.00** |    **0.00** |           **-** |           **-** |           **-** |                **40 B** |
|            Hyperlinq_Range_ForEach |            Range | 10000 | 16,213.3503 ns |  51.1585 ns |  47.8537 ns |  0.32 |    0.00 |           - |           - |           - |                   - |
|                Hyperlinq_Range_For |            Range | 10000 |  5,694.0759 ns |  45.6105 ns |  42.6641 ns |  0.11 |    0.00 |           - |           - |           - |                   - |
|                                    |                  |       |                |             |             |       |         |             |             |             |                     |
|                        Linq_Repeat |           Repeat | 10000 | 51,012.3252 ns | 233.6400 ns | 218.5470 ns |  1.00 |    0.00 |           - |           - |           - |                32 B |
|           Hyperlinq_Repeat_ForEach |           Repeat | 10000 | 14,984.3828 ns |  68.3366 ns |  63.9221 ns |  0.29 |    0.00 |           - |           - |           - |                   - |
|               Hyperlinq_Repeat_For |           Repeat | 10000 |  5,716.2645 ns |  74.1204 ns |  69.3322 ns |  0.11 |    0.00 |           - |           - |           - |                   - |
|                                    |                  |       |                |             |             |       |         |             |             |             |                     |
|                          Ix_Repeat | RepeatInfinitely | 10000 | 53,798.6867 ns | 568.4293 ns | 531.7091 ns |  1.00 |    0.00 |           - |           - |           - |                40 B |
| Hyperlinq_RepeatInfinitely_ForEach | RepeatInfinitely | 10000 |  3,766.3538 ns |  73.1635 ns |  75.1335 ns |  0.07 |    0.00 |           - |           - |           - |                   - |
|     Hyperlinq_RepeatInfinitely_For | RepeatInfinitely | 10000 |  2,850.8999 ns |  12.3672 ns |  11.5682 ns |  0.05 |    0.00 |           - |           - |           - |                   - |
|                                    |                  |       |                |             |             |       |         |             |             |             |                     |
|                          Ix_Create |           Create | 10000 | 62,722.7739 ns | 785.2723 ns | 734.5442 ns |  1.00 |    0.00 |           - |           - |           - |               112 B |
|           Hyperlinq_Create_ForEach |           Create | 10000 | 14,758.4389 ns |  36.8653 ns |  34.4838 ns |  0.24 |    0.00 |      0.0153 |           - |           - |                64 B |
|               Hyperlinq_Create_For |           Create | 10000 | 25,707.8796 ns | 323.3270 ns | 302.4402 ns |  0.41 |    0.01 |      0.0305 |           - |           - |               128 B |


## References

- [Enumeration in .NET](https://blog.usejournal.com/enumeration-in-net-d5674921512e)
- [Performance of value-type vs reference-type enumerators](https://medium.com/@antao.almada/performance-of-value-type-vs-reference-type-enumerators-820ab1acc291)
- [NetFabric.Hyperlinq — Optimizing LINQ](https://medium.com/@antao.almada/netfabric-hyperlinq-optimizing-linq-348e02566cef)
- [Performance Tuning for .NET Core](https://reubenbond.github.io/posts/dotnet-perf-tuning)

