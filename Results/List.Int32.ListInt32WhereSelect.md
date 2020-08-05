## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|               Method |           Job |       Runtime | Count |     Mean |   Error |  StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |-------------- |-------------- |------ |---------:|--------:|--------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |      .NET 4.8 |      .NET 4.8 |   100 | 152.2 ns | 0.80 ns | 0.71 ns |  1.00 |    0.00 |     170 B |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |   100 | 203.6 ns | 0.67 ns | 0.59 ns |  1.34 |    0.01 |     179 B |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |   100 | 714.8 ns | 4.31 ns | 4.03 ns |  4.69 |    0.04 |    1498 B | 0.0725 |     - |     - |     152 B |              1 |                       1 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |   100 | 672.7 ns | 3.29 ns | 2.75 ns |  4.42 |    0.02 |     903 B | 0.3128 |     - |     - |     658 B |              2 |                       3 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |   100 | 460.0 ns | 3.57 ns | 3.16 ns |  3.02 |    0.02 |    1241 B |      - |     - |     - |         - |              0 |                       0 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |   100 | 210.9 ns | 0.86 ns | 0.81 ns |  1.39 |    0.01 |    1069 B |      - |     - |     - |         - |              0 |                       0 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |   100 | 479.2 ns | 1.89 ns | 1.68 ns |  3.15 |    0.02 |    1471 B |      - |     - |     - |         - |              0 |                       0 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |   100 | 125.0 ns | 0.41 ns | 0.32 ns |  0.82 |    0.00 |      77 B |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |   100 | 224.7 ns | 0.46 ns | 0.41 ns |  1.48 |    0.01 |     178 B |      - |     - |     - |         - |              0 |                       0 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |   100 | 773.5 ns | 2.83 ns | 2.65 ns |  5.08 |    0.03 |    1699 B | 0.0725 |     - |     - |     152 B |              1 |                       1 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |   100 | 548.7 ns | 3.25 ns | 2.72 ns |  3.60 |    0.03 |     804 B | 0.3090 |     - |     - |     648 B |              2 |                       2 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 456.3 ns | 1.68 ns | 1.40 ns |  3.00 |    0.02 |    1144 B |      - |     - |     - |         - |              0 |                       0 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |   100 | 193.5 ns | 0.83 ns | 0.77 ns |  1.27 |    0.01 |     988 B |      - |     - |     - |         - |              0 |                       0 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 467.2 ns | 1.40 ns | 1.31 ns |  3.07 |    0.02 |     986 B |      - |     - |     - |         - |              0 |                       0 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |   100 | 124.7 ns | 0.55 ns | 0.52 ns |  0.82 |    0.01 |      77 B |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |   100 | 232.4 ns | 2.18 ns | 1.93 ns |  1.53 |    0.01 |     168 B |      - |     - |     - |         - |              0 |                       0 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |   100 | 728.6 ns | 2.23 ns | 1.86 ns |  4.79 |    0.02 |    1674 B | 0.0725 |     - |     - |     152 B |              1 |                       1 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |   100 | 498.3 ns | 6.79 ns | 5.67 ns |  3.27 |    0.04 |     785 B | 0.3090 |     - |     - |     648 B |              1 |                       2 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 446.4 ns | 3.98 ns | 3.72 ns |  2.93 |    0.03 |    1035 B |      - |     - |     - |         - |              0 |                       0 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |   100 | 184.9 ns | 1.39 ns | 1.30 ns |  1.22 |    0.01 |     886 B |      - |     - |     - |         - |              0 |                       0 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 511.3 ns | 2.91 ns | 2.43 ns |  3.36 |    0.03 |     955 B |      - |     - |     - |         - |              0 |                       0 |
