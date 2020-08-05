## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta22](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta22)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET 4.8      : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT


```
|               Method |           Job |       Runtime | Duplicates | Count |       Mean |     Error |    StdDev | Ratio |     Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |-------------- |-------------- |----------- |------ |-----------:|----------:|----------:|------:|----------:|------:|------:|----------:|----------:|---------------:|------------------------:|
|              ForLoop |      .NET 4.8 |      .NET 4.8 |          4 |   100 | 672.442 μs | 3.8023 μs | 3.3706 μs | 1.000 | 1095.7031 |     - |     - | 2298983 B |    1342 B |          2,801 |                     638 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |          4 |   100 | 685.514 μs | 4.0063 μs | 3.7475 μs | 1.020 | 1095.7031 |     - |     - | 2298983 B |    1523 B |          3,124 |                     612 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |          4 |   100 | 684.662 μs | 3.3732 μs | 3.1553 μs | 1.018 | 1092.7734 |     - |     - | 2293481 B |     530 B |          2,651 |                     586 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |          4 |   100 |   2.678 μs | 0.0327 μs | 0.0306 μs | 0.004 |    0.0114 |     - |     - |      24 B |    1265 B |              1 |                       2 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |          4 |   100 | 724.837 μs | 2.6714 μs | 2.3681 μs | 1.078 | 1086.9141 |     - |     - | 2280335 B |    1993 B |          2,917 |                     611 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |          4 |   100 |  37.401 μs | 0.1200 μs | 0.1064 μs | 0.056 |   12.2070 |     - |     - |   25676 B |    2307 B |            119 |                      88 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |          4 |   100 | 660.818 μs | 6.3667 μs | 5.3164 μs | 0.983 | 1045.8984 |     - |     - | 2194068 B |    1440 B |          2,643 |                     568 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |          4 |   100 | 600.441 μs | 2.7486 μs | 2.5710 μs | 0.893 | 1095.7031 |     - |     - | 2292177 B |    1200 B |          3,217 |                     775 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |          4 |   100 | 730.184 μs | 3.7223 μs | 3.4818 μs | 1.085 | 1095.7031 |     - |     - | 2292177 B |    1454 B |          3,467 |                     689 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |          4 |   100 | 635.348 μs | 8.5775 μs | 7.6037 μs | 0.945 | 1092.7734 |     - |     - | 2286713 B |     570 B |          2,846 |                     607 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |          4 |   100 |   2.372 μs | 0.0465 μs | 0.0457 μs | 0.004 |    0.0114 |     - |     - |      24 B |    1113 B |              1 |                       2 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |          4 |   100 | 651.995 μs | 4.9200 μs | 4.6022 μs | 0.970 | 1086.9141 |     - |     - | 2273601 B |    1770 B |          2,665 |                     588 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |          4 |   100 |  23.488 μs | 0.0877 μs | 0.0685 μs | 0.035 |    6.1035 |     - |     - |   12800 B |    2023 B |             80 |                      69 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |          4 |   100 | 572.539 μs | 5.0639 μs | 4.4891 μs | 0.851 | 1045.8984 |     - |     - | 2187585 B |     976 B |          2,934 |                     491 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |          4 |   100 | 510.961 μs | 5.7609 μs | 5.3887 μs | 0.760 | 1095.7031 |     - |     - | 2292184 B |    1723 B |          2,551 |                     560 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |          4 |   100 | 523.343 μs | 2.6212 μs | 2.3236 μs | 0.778 | 1095.7031 |     - |     - | 2292184 B |    1930 B |          2,333 |                     456 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |          4 |   100 | 529.328 μs | 4.6274 μs | 4.3285 μs | 0.787 | 1092.7734 |     - |     - | 2286712 B |     533 B |          2,192 |                     531 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |          4 |   100 |   2.366 μs | 0.0121 μs | 0.0101 μs | 0.004 |    0.0114 |     - |     - |      24 B |    1145 B |              1 |                       2 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |          4 |   100 | 566.104 μs | 4.7225 μs | 4.4174 μs | 0.842 | 1086.9141 |     - |     - | 2273601 B |    1776 B |          2,443 |                     551 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |          4 |   100 |  22.767 μs | 0.0642 μs | 0.0569 μs | 0.034 |         - |     - |     - |         - |    1915 B |              9 |                      47 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |          4 |   100 | 493.384 μs | 4.1515 μs | 3.8833 μs | 0.734 | 1045.8984 |     - |     - | 2187585 B |     948 B |          2,334 |                     461 |
