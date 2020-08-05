## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

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
|               Method |           Job |       Runtime | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |-------------- |-------------- |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|----------:|---------------:|------------------------:|
|              ForLoop |      .NET 4.8 |      .NET 4.8 | 1000 |   100 |    99.47 ns |  0.560 ns |  0.523 ns |  1.00 |    0.00 |      - |     - |     - |         - |     181 B |              0 |                       0 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 3,560.75 ns | 12.482 ns | 11.676 ns | 35.80 |    0.27 | 0.0191 |     - |     - |      40 B |     217 B |              1 |                       1 |
|                 Linq |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 5,672.70 ns | 21.856 ns | 18.251 ns | 57.09 |    0.36 | 0.1068 |     - |     - |     225 B |    1066 B |              3 |                       3 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 1,051.20 ns |  7.828 ns |  6.940 ns | 10.57 |    0.10 | 0.7572 |     - |     - |    1589 B |     966 B |              4 |                       4 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 5,584.19 ns | 21.737 ns | 18.152 ns | 56.20 |    0.35 | 0.0763 |     - |     - |     169 B |     807 B |              3 |                       3 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 5,484.85 ns | 24.780 ns | 21.967 ns | 55.17 |    0.37 | 0.0763 |     - |     - |     169 B |     738 B |              3 |                       3 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 | 1000 |   100 |   375.75 ns |  1.303 ns |  1.155 ns |  3.78 |    0.02 |      - |     - |     - |         - |    1387 B |              0 |                       0 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 |    79.92 ns |  0.264 ns |  0.234 ns |  0.80 |    0.00 |      - |     - |     - |         - |      85 B |              0 |                       0 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 3,810.21 ns | 16.927 ns | 15.005 ns | 38.32 |    0.29 | 0.0191 |     - |     - |      40 B |     228 B |              2 |                       2 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 1,269.28 ns |  4.855 ns |  4.541 ns | 12.76 |    0.05 | 0.0725 |     - |     - |     152 B |    1139 B |              2 |                       1 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 |   811.09 ns |  6.402 ns |  5.676 ns |  8.16 |    0.05 | 0.7458 |     - |     - |    1560 B |     926 B |              3 |                       3 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 1,229.65 ns |  5.728 ns |  5.078 ns | 12.37 |    0.10 | 0.0458 |     - |     - |      96 B |     826 B |              1 |                       1 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 |   923.56 ns |  3.156 ns |  2.797 ns |  9.29 |    0.05 | 0.0458 |     - |     - |      96 B |     778 B |              1 |                       1 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 |   397.79 ns |  1.816 ns |  1.699 ns |  4.00 |    0.03 |      - |     - |     - |         - |     755 B |              0 |                       0 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 |    84.74 ns |  0.365 ns |  0.342 ns |  0.85 |    0.01 |      - |     - |     - |         - |      85 B |              0 |                       0 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 3,535.97 ns | 14.201 ns | 12.589 ns | 35.56 |    0.18 | 0.0191 |     - |     - |      40 B |     218 B |              1 |                       2 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 1,211.03 ns |  6.738 ns |  5.973 ns | 12.18 |    0.08 | 0.0725 |     - |     - |     152 B |    1106 B |              2 |                       1 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 |   803.39 ns |  3.233 ns |  2.524 ns |  8.08 |    0.04 | 0.7458 |     - |     - |    1560 B |     915 B |              3 |                       3 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 1,134.23 ns |  4.742 ns |  4.435 ns | 11.40 |    0.07 | 0.0458 |     - |     - |      96 B |     762 B |              1 |                       1 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 |   864.90 ns |  3.573 ns |  3.167 ns |  8.70 |    0.06 | 0.0458 |     - |     - |      96 B |     717 B |              1 |                       1 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 |   359.19 ns |  0.878 ns |  0.821 ns |  3.61 |    0.02 |      - |     - |     - |         - |     738 B |              0 |                       0 |
