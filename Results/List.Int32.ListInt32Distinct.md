## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

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
|               Method |           Job |       Runtime | Duplicates | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |-------------- |-------------- |----------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|----------:|---------------:|------------------------:|
|              ForLoop |      .NET 4.8 |      .NET 4.8 |          4 |   100 | 5,929.0 ns | 26.04 ns | 21.75 ns |  1.00 | 2.8610 |     - |     - |    6019 B |     804 B |             18 |                       7 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |          4 |   100 | 6,393.1 ns | 40.18 ns | 35.62 ns |  1.08 | 2.8610 |     - |     - |    6019 B |     809 B |             21 |                       8 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |          4 |   100 | 7,514.0 ns | 32.83 ns | 30.71 ns |  1.27 | 2.0676 |     - |     - |    4349 B |     283 B |             21 |                       7 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |          4 |   100 |   843.2 ns |  3.63 ns |  3.03 ns |  0.14 |      - |     - |     - |         - |     580 B |              0 |                       3 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |          4 |   100 | 6,083.5 ns | 19.05 ns | 16.89 ns |  1.03 |      - |     - |     - |         - |    1781 B |              2 |                       6 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |          4 |   100 | 4,780.9 ns | 19.77 ns | 17.52 ns |  0.81 |      - |     - |     - |         - |    1730 B |              1 |                       5 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |          4 |   100 | 5,219.6 ns | 18.59 ns | 16.48 ns |  0.88 |      - |     - |     - |         - |    1116 B |              2 |                       7 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |          4 |   100 | 5,022.2 ns | 28.82 ns | 25.55 ns |  0.85 | 2.8610 |     - |     - |    6000 B |     671 B |             18 |                       7 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |          4 |   100 | 5,397.6 ns | 35.22 ns | 32.95 ns |  0.91 | 2.8610 |     - |     - |    6000 B |     765 B |             20 |                       8 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |          4 |   100 | 7,559.3 ns | 40.96 ns | 36.31 ns |  1.28 | 2.0599 |     - |     - |    4320 B |     345 B |             23 |                       7 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |          4 |   100 |   723.3 ns |  2.22 ns |  2.08 ns |  0.12 |      - |     - |     - |         - |     464 B |              0 |                       1 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |          4 |   100 | 5,424.7 ns | 16.15 ns | 14.31 ns |  0.91 |      - |     - |     - |         - |    1562 B |              2 |                       5 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |          4 |   100 | 3,943.0 ns | 27.13 ns | 22.66 ns |  0.67 |      - |     - |     - |         - |    1507 B |              1 |                       4 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |          4 |   100 | 3,994.4 ns | 18.36 ns | 17.17 ns |  0.67 |      - |     - |     - |         - |     674 B |              1 |                       3 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |          4 |   100 | 3,236.7 ns | 19.06 ns | 16.89 ns |  0.55 | 2.8687 |     - |     - |    6008 B |     887 B |             12 |                       4 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |          4 |   100 | 3,676.1 ns | 28.50 ns | 25.26 ns |  0.62 | 2.8687 |     - |     - |    6008 B |     960 B |             13 |                       6 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |          4 |   100 | 7,146.9 ns | 32.53 ns | 28.84 ns |  1.21 | 2.0599 |     - |     - |    4320 B |     333 B |             22 |                       8 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |          4 |   100 |   642.5 ns |  4.24 ns |  3.31 ns |  0.11 |      - |     - |     - |         - |     434 B |              0 |                       2 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |          4 |   100 | 5,288.6 ns | 17.56 ns | 15.57 ns |  0.89 |      - |     - |     - |         - |    1582 B |              2 |                       5 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |          4 |   100 | 3,735.9 ns | 15.19 ns | 13.47 ns |  0.63 |      - |     - |     - |         - |    1416 B |              1 |                       4 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |          4 |   100 | 3,783.6 ns | 18.99 ns | 17.76 ns |  0.64 |      - |     - |     - |         - |     655 B |              1 |                       3 |
