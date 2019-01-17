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

|                             Method |       Categories | Count |           Mean |       Error |      StdDev | Ratio | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|----------------------------------- |----------------- |------ |---------------:|------------:|------------:|------:|------------:|------------:|------------:|--------------------:|
|                         Linq_Range |            Range |     0 |      8.9125 ns |   0.0786 ns |   0.0697 ns |  1.00 |           - |           - |           - |                   - |
|            Hyperlinq_Range_ForEach |            Range |     0 |     13.2258 ns |   0.0941 ns |   0.0834 ns |  1.48 |           - |           - |           - |                   - |
|                Hyperlinq_Range_For |            Range |     0 |      7.3083 ns |   0.0623 ns |   0.0583 ns |  0.82 |           - |           - |           - |                   - |
|                                    |                  |       |                |             |             |       |             |             |             |                     |
|                        Linq_Repeat |           Repeat |     0 |      9.4664 ns |   0.0277 ns |   0.0259 ns |  1.00 |           - |           - |           - |                   - |
|           Hyperlinq_Repeat_ForEach |           Repeat |     0 |     13.8353 ns |   0.1298 ns |   0.1214 ns |  1.46 |           - |           - |           - |                   - |
|               Hyperlinq_Repeat_For |           Repeat |     0 |      7.0069 ns |   0.0193 ns |   0.0171 ns |  0.74 |           - |           - |           - |                   - |
|                                    |                  |       |                |             |             |       |             |             |             |                     |
|                          Ix_Repeat | RepeatInfinitely |     0 |     15.3938 ns |   0.1367 ns |   0.1141 ns |  1.00 |      0.0190 |           - |           - |                40 B |
| Hyperlinq_RepeatInfinitely_ForEach | RepeatInfinitely |     0 |      0.2620 ns |   0.0118 ns |   0.0104 ns |  0.02 |           - |           - |           - |                   - |
|     Hyperlinq_RepeatInfinitely_For | RepeatInfinitely |     0 |      0.2900 ns |   0.0225 ns |   0.0188 ns |  0.02 |           - |           - |           - |                   - |
|                                    |                  |       |                |             |             |       |             |             |             |                     |
|                          Ix_Create |           Create |     0 |     30.0690 ns |   0.2024 ns |   0.1894 ns |  1.00 |      0.0533 |           - |           - |               112 B |
|           Hyperlinq_Create_ForEach |           Create |     0 |     16.0685 ns |   0.3059 ns |   0.2862 ns |  0.53 |      0.0305 |           - |           - |                64 B |
|                                    |                  |       |                |             |             |       |             |             |             |                     |
|                         Linq_Range |            Range |   100 |    501.2129 ns |   7.0096 ns |   6.2138 ns |  1.00 |      0.0181 |           - |           - |                40 B |
|            Hyperlinq_Range_ForEach |            Range |   100 |    187.1682 ns |   1.8038 ns |   1.6873 ns |  0.37 |           - |           - |           - |                   - |
|                Hyperlinq_Range_For |            Range |   100 |     69.8803 ns |   0.2458 ns |   0.2179 ns |  0.14 |           - |           - |           - |                   - |
|                                    |                  |       |                |             |             |       |             |             |             |                     |
|                        Linq_Repeat |           Repeat |   100 |    520.6640 ns |  12.8152 ns |  14.2441 ns |  1.00 |      0.0143 |           - |           - |                32 B |
|           Hyperlinq_Repeat_ForEach |           Repeat |   100 |    176.1847 ns |   0.2039 ns |   0.1592 ns |  0.34 |           - |           - |           - |                   - |
|               Hyperlinq_Repeat_For |           Repeat |   100 |     65.4933 ns |   1.1149 ns |   1.0429 ns |  0.13 |           - |           - |           - |                   - |
|                                    |                  |       |                |             |             |       |             |             |             |                     |
|                          Ix_Repeat | RepeatInfinitely |   100 |    533.3029 ns |   1.5483 ns |   1.2929 ns |  1.00 |      0.0181 |           - |           - |                40 B |
| Hyperlinq_RepeatInfinitely_ForEach | RepeatInfinitely |   100 |     37.0459 ns |   0.1423 ns |   0.1262 ns |  0.07 |           - |           - |           - |                   - |
|     Hyperlinq_RepeatInfinitely_For | RepeatInfinitely |   100 |     61.8521 ns |   0.2423 ns |   0.2148 ns |  0.12 |           - |           - |           - |                   - |
|                                    |                  |       |                |             |             |       |             |             |             |                     |
|                          Ix_Create |           Create |   100 |    695.0436 ns |   5.8041 ns |   5.1452 ns |  1.00 |      0.0525 |           - |           - |               112 B |
|           Hyperlinq_Create_ForEach |           Create |   100 |    181.4476 ns |   0.5483 ns |   0.5129 ns |  0.26 |      0.0303 |           - |           - |                64 B |
|                                    |                  |       |                |             |             |       |             |             |             |                     |
|                         Linq_Range |            Range | 10000 | 45,531.7638 ns | 431.4816 ns | 403.6082 ns |  1.00 |           - |           - |           - |                40 B |
|            Hyperlinq_Range_ForEach |            Range | 10000 | 16,254.9760 ns |  95.0312 ns |  84.2427 ns |  0.36 |           - |           - |           - |                   - |
|                Hyperlinq_Range_For |            Range | 10000 |  5,677.3884 ns |  43.6699 ns |  38.7122 ns |  0.12 |           - |           - |           - |                   - |
|                                    |                  |       |                |             |             |       |             |             |             |                     |
|                        Linq_Repeat |           Repeat | 10000 | 47,996.3037 ns |  61.8541 ns |  48.2916 ns |  1.00 |           - |           - |           - |                32 B |
|           Hyperlinq_Repeat_ForEach |           Repeat | 10000 | 14,937.1337 ns |  43.7105 ns |  38.7483 ns |  0.31 |           - |           - |           - |                   - |
|               Hyperlinq_Repeat_For |           Repeat | 10000 |  5,640.4397 ns |  11.8557 ns |  10.5097 ns |  0.12 |           - |           - |           - |                   - |
|                                    |                  |       |                |             |             |       |             |             |             |                     |
|                          Ix_Repeat | RepeatInfinitely | 10000 | 50,699.3746 ns | 142.7772 ns | 126.5683 ns |  1.00 |           - |           - |           - |                40 B |
| Hyperlinq_RepeatInfinitely_ForEach | RepeatInfinitely | 10000 |  2,843.6562 ns |  13.9229 ns |  11.6263 ns |  0.06 |           - |           - |           - |                   - |
|     Hyperlinq_RepeatInfinitely_For | RepeatInfinitely | 10000 |  5,686.8204 ns |  43.7448 ns |  36.5289 ns |  0.11 |           - |           - |           - |                   - |
|                                    |                  |       |                |             |             |       |             |             |             |                     |
|                          Ix_Create |           Create | 10000 | 65,020.3012 ns | 220.5993 ns | 206.3487 ns |  1.00 |           - |           - |           - |               112 B |
|           Hyperlinq_Create_ForEach |           Create | 10000 | 14,740.7169 ns |  30.9912 ns |  25.8791 ns |  0.23 |      0.0153 |           - |           - |                64 B |


## References

- [Enumeration in .NET](https://blog.usejournal.com/enumeration-in-net-d5674921512e)
- [Performance of value-type vs reference-type enumerators](https://medium.com/@antao.almada/performance-of-value-type-vs-reference-type-enumerators-820ab1acc291)
- [NetFabric.Hyperlinq — Optimizing LINQ](https://medium.com/@antao.almada/netfabric-hyperlinq-optimizing-linq-348e02566cef)
- [Performance Tuning for .NET Core](https://reubenbond.github.io/posts/dotnet-perf-tuning)

