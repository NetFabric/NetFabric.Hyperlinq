## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

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
|      Method |           Job |       Runtime | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|------------ |-------------- |-------------- |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|----------:|---------------:|------------------------:|
|     ForLoop |      .NET 4.8 |      .NET 4.8 | 1000 |   100 |   505.8 ns |  2.42 ns |  2.15 ns |  1.00 |    0.00 |      - |     - |     - |         - |     447 B |              0 |                       0 |
| ForeachLoop |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 4,187.6 ns | 18.42 ns | 17.23 ns |  8.28 |    0.04 | 0.0305 |     - |     - |      72 B |     514 B |              2 |                       2 |
|        Linq |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 8,186.5 ns | 35.18 ns | 32.91 ns | 16.18 |    0.11 | 0.1678 |     - |     - |     353 B |    1291 B |              6 |                       4 |
|  LinqFaster |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 2,376.2 ns | 46.50 ns | 51.68 ns |  4.70 |    0.11 | 6.3286 |     - |     - |   13291 B |    1602 B |              8 |                       5 |
|  StructLinq |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 7,683.1 ns | 44.91 ns | 37.50 ns | 15.20 |    0.11 | 0.1221 |     - |     - |     265 B |    1142 B |              5 |                       3 |
|   Hyperlinq |      .NET 4.8 |      .NET 4.8 | 1000 |   100 |   757.1 ns |  1.62 ns |  1.35 ns |  1.50 |    0.01 |      - |     - |     - |         - |    1765 B |              0 |                       0 |
|     ForLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 |   505.4 ns |  1.43 ns |  1.34 ns |  1.00 |    0.00 |      - |     - |     - |         - |     344 B |              0 |                       0 |
| ForeachLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 4,672.4 ns | 24.42 ns | 21.64 ns |  9.24 |    0.05 | 0.0305 |     - |     - |      72 B |     524 B |              2 |                       2 |
|        Linq | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 1,986.7 ns | 12.00 ns | 10.02 ns |  3.93 |    0.02 | 0.1183 |     - |     - |     248 B |    1366 B |              3 |                       1 |
|  LinqFaster | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 2,445.8 ns | 38.36 ns | 35.88 ns |  4.83 |    0.07 | 6.3133 |     - |     - |   13224 B |    1535 B |             10 |                       4 |
|  StructLinq | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 1,562.0 ns |  5.46 ns |  4.84 ns |  3.09 |    0.02 | 0.0763 |     - |     - |     160 B |    1160 B |              2 |                       1 |
|   Hyperlinq | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 |   710.8 ns |  3.45 ns |  3.06 ns |  1.41 |    0.01 |      - |     - |     - |         - |    1092 B |              0 |                       1 |
|     ForLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 |   597.9 ns |  2.85 ns |  2.53 ns |  1.18 |    0.01 |      - |     - |     - |         - |     344 B |              0 |                      14 |
| ForeachLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 4,344.8 ns | 12.64 ns | 10.55 ns |  8.59 |    0.05 | 0.0305 |     - |     - |      72 B |     537 B |              2 |                       2 |
|        Linq | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 1,557.9 ns |  6.90 ns |  6.12 ns |  3.08 |    0.02 | 0.1183 |     - |     - |     248 B |    1326 B |              3 |                       1 |
|  LinqFaster | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 2,301.8 ns | 35.77 ns | 33.46 ns |  4.55 |    0.06 | 6.3133 |     - |     - |   13224 B |    1541 B |             22 |                       6 |
|  StructLinq | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 1,445.4 ns |  7.08 ns |  6.27 ns |  2.86 |    0.01 | 0.0763 |     - |     - |     160 B |    1127 B |              2 |                       1 |
|   Hyperlinq | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 |   703.5 ns |  1.78 ns |  1.39 ns |  1.39 |    0.01 |      - |     - |     - |         - |    1104 B |              0 |                       1 |
