## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

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
|              ForLoop |      .NET 4.8 |      .NET 4.8 |   100 | 108.3 ns | 1.21 ns | 1.14 ns |  1.00 |    0.00 |     166 B |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |   100 | 205.9 ns | 0.87 ns | 0.82 ns |  1.90 |    0.02 |     174 B |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |   100 | 802.3 ns | 1.47 ns | 1.30 ns |  7.42 |    0.07 |     900 B | 0.0381 |     - |     - |      80 B |              1 |                       1 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |   100 | 508.8 ns | 4.09 ns | 3.41 ns |  4.70 |    0.06 |     616 B | 0.2213 |     - |     - |     465 B |              1 |                       1 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |   100 | 261.1 ns | 0.75 ns | 0.58 ns |  2.41 |    0.03 |     587 B |      - |     - |     - |         - |              0 |                       0 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |   100 | 169.1 ns | 0.77 ns | 0.72 ns |  1.56 |    0.02 |     589 B |      - |     - |     - |         - |              0 |                       0 |
|    Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 |   100 | 300.2 ns | 0.92 ns | 0.77 ns |  2.78 |    0.03 |    1070 B |      - |     - |     - |         - |              0 |                       0 |
|        Hyperlinq_For |      .NET 4.8 |      .NET 4.8 |   100 | 371.0 ns | 1.37 ns | 1.14 ns |  3.43 |    0.04 |     927 B |      - |     - |     - |         - |              0 |                       0 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |   100 | 106.4 ns | 0.30 ns | 0.28 ns |  0.98 |    0.01 |      71 B |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |   100 | 201.1 ns | 0.77 ns | 0.72 ns |  1.86 |    0.02 |     173 B |      - |     - |     - |         - |              0 |                       0 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |   100 | 811.3 ns | 4.18 ns | 3.91 ns |  7.49 |    0.07 |    1073 B | 0.0343 |     - |     - |      72 B |              1 |                       1 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |   100 | 363.9 ns | 1.97 ns | 1.85 ns |  3.36 |    0.04 |     509 B | 0.2179 |     - |     - |     456 B |              1 |                       1 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 283.2 ns | 0.98 ns | 0.91 ns |  2.62 |    0.03 |     541 B |      - |     - |     - |         - |              0 |                       0 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |   100 | 167.5 ns | 0.64 ns | 0.60 ns |  1.55 |    0.02 |     538 B |      - |     - |     - |         - |              0 |                       0 |
|    Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 |   100 | 258.7 ns | 1.10 ns | 0.92 ns |  2.39 |    0.03 |     485 B |      - |     - |     - |         - |              0 |                       0 |
|        Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 |   100 | 295.3 ns | 1.84 ns | 1.64 ns |  2.73 |    0.03 |     460 B |      - |     - |     - |         - |              0 |                       0 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |   100 | 106.1 ns | 0.47 ns | 0.42 ns |  0.98 |    0.01 |      71 B |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |   100 | 199.9 ns | 0.69 ns | 0.61 ns |  1.85 |    0.02 |     163 B |      - |     - |     - |         - |              0 |                       0 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |   100 | 744.5 ns | 2.98 ns | 2.49 ns |  6.88 |    0.08 |    1057 B | 0.0343 |     - |     - |      72 B |              1 |                       1 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |   100 | 346.9 ns | 1.63 ns | 1.44 ns |  3.21 |    0.04 |     509 B | 0.2179 |     - |     - |     456 B |              1 |                       1 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 274.9 ns | 0.97 ns | 0.86 ns |  2.54 |    0.03 |     511 B |      - |     - |     - |         - |              0 |                       0 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |   100 | 159.7 ns | 0.53 ns | 0.49 ns |  1.48 |    0.02 |     482 B |      - |     - |     - |         - |              0 |                       0 |
|    Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 |   100 | 277.2 ns | 1.05 ns | 0.98 ns |  2.56 |    0.03 |     467 B |      - |     - |     - |         - |              0 |                       0 |
|        Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 |   100 | 276.1 ns | 1.06 ns | 0.83 ns |  2.55 |    0.02 |     439 B |      - |     - |     - |         - |              0 |                       0 |
