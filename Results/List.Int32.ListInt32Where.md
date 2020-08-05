## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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
|               Method |           Job |       Runtime | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |-------------- |-------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|----------:|---------------:|------------------------:|
|              ForLoop |      .NET 4.8 |      .NET 4.8 |   100 | 152.0 ns | 0.62 ns | 0.52 ns |  1.00 |    0.00 |      - |     - |     - |         - |     169 B |              0 |                       0 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |   100 | 206.1 ns | 2.29 ns | 1.92 ns |  1.36 |    0.01 |      - |     - |     - |         - |     178 B |              0 |                       0 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |   100 | 616.0 ns | 2.19 ns | 1.95 ns |  4.05 |    0.01 | 0.0343 |     - |     - |      72 B |     867 B |              1 |                       1 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |   100 | 495.8 ns | 2.09 ns | 1.95 ns |  3.26 |    0.02 | 0.3128 |     - |     - |     658 B |     497 B |              2 |                       3 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |   100 | 301.2 ns | 1.04 ns | 0.97 ns |  1.98 |    0.01 |      - |     - |     - |         - |     624 B |              0 |                       0 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |   100 | 188.1 ns | 0.64 ns | 0.57 ns |  1.24 |    0.01 |      - |     - |     - |         - |     495 B |              0 |                       0 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |   100 | 389.1 ns | 1.16 ns | 1.09 ns |  2.56 |    0.01 |      - |     - |     - |         - |    1142 B |              0 |                       0 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |   100 | 125.2 ns | 0.88 ns | 0.74 ns |  0.82 |    0.01 |      - |     - |     - |         - |      76 B |              0 |                       0 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |   100 | 250.0 ns | 1.46 ns | 1.14 ns |  1.64 |    0.01 |      - |     - |     - |         - |     177 B |              0 |                       0 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |   100 | 624.6 ns | 2.37 ns | 2.22 ns |  4.11 |    0.02 | 0.0343 |     - |     - |      72 B |     860 B |              1 |                       1 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |   100 | 442.4 ns | 2.94 ns | 2.60 ns |  2.91 |    0.02 | 0.3095 |     - |     - |     648 B |     367 B |              2 |                       2 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 338.4 ns | 1.02 ns | 0.96 ns |  2.23 |    0.01 |      - |     - |     - |         - |     575 B |              0 |                       0 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |   100 | 173.3 ns | 0.96 ns | 0.85 ns |  1.14 |    0.01 |      - |     - |     - |         - |     438 B |              0 |                       0 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 350.8 ns | 1.00 ns | 0.89 ns |  2.31 |    0.01 |      - |     - |     - |         - |     564 B |              0 |                       1 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |   100 | 124.6 ns | 0.57 ns | 0.50 ns |  0.82 |    0.00 |      - |     - |     - |         - |      76 B |              0 |                       0 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |   100 | 231.9 ns | 1.21 ns | 0.94 ns |  1.53 |    0.01 |      - |     - |     - |         - |     167 B |              0 |                       0 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |   100 | 657.8 ns | 4.27 ns | 3.99 ns |  4.32 |    0.03 | 0.0343 |     - |     - |      72 B |     845 B |              1 |                       1 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |   100 | 432.8 ns | 2.22 ns | 2.07 ns |  2.85 |    0.01 | 0.3095 |     - |     - |     648 B |     356 B |              1 |                       2 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 295.2 ns | 1.41 ns | 1.25 ns |  1.94 |    0.01 |      - |     - |     - |         - |     546 B |              0 |                       0 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |   100 | 166.9 ns | 0.73 ns | 0.65 ns |  1.10 |    0.01 |      - |     - |     - |         - |     410 B |              0 |                       0 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 368.8 ns | 1.43 ns | 1.19 ns |  2.43 |    0.01 |      - |     - |     - |         - |     547 B |              0 |                       0 |
