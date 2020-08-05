## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|               Method |           Job |       Runtime | Count |     Mean |    Error |  StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |-------------- |-------------- |------ |---------:|---------:|--------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |      .NET 4.8 |      .NET 4.8 |   100 | 381.9 ns |  5.41 ns | 5.06 ns |  1.00 |    0.00 |     381 B | 0.4206 |     - |     - |     883 B |              1 |                       1 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |   100 | 441.7 ns |  4.07 ns | 3.81 ns |  1.16 |    0.02 |     388 B | 0.4206 |     - |     - |     883 B |              1 |                       1 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |   100 | 932.8 ns |  7.79 ns | 7.29 ns |  2.44 |    0.03 |    1458 B | 0.4740 |     - |     - |     995 B |              1 |                       4 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |   100 | 628.0 ns |  7.89 ns | 7.38 ns |  1.64 |    0.03 |     846 B | 0.4206 |     - |     - |     883 B |              1 |                       2 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |   100 | 728.2 ns |  8.49 ns | 7.53 ns |  1.91 |    0.03 |    1733 B | 0.1297 |     - |     - |     273 B |              1 |                       2 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |   100 | 474.6 ns |  7.19 ns | 5.61 ns |  1.24 |    0.02 |    1575 B | 0.1297 |     - |     - |     273 B |              1 |                       1 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |   100 | 726.7 ns |  6.08 ns | 5.69 ns |  1.90 |    0.03 |    1358 B | 0.1068 |     - |     - |     225 B |              1 |                       2 |
|       Hyperlinq_Pool |      .NET 4.8 |      .NET 4.8 |   100 | 818.9 ns |  8.92 ns | 8.34 ns |  2.14 |    0.03 |    1958 B | 0.0267 |     - |     - |      56 B |              1 |                       2 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |   100 | 295.8 ns |  2.46 ns | 2.05 ns |  0.77 |    0.01 |     358 B | 0.4168 |     - |     - |     872 B |              1 |                       0 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |   100 | 432.6 ns |  2.98 ns | 2.79 ns |  1.13 |    0.02 |     453 B | 0.4163 |     - |     - |     872 B |              1 |                       2 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |   100 | 594.0 ns |  7.24 ns | 6.05 ns |  1.56 |    0.03 |    1588 B | 0.3939 |     - |     - |     824 B |              1 |                       2 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |   100 | 539.9 ns |  5.22 ns | 4.88 ns |  1.41 |    0.02 |     843 B | 0.4158 |     - |     - |     872 B |              2 |                       3 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 661.4 ns | 10.66 ns | 8.90 ns |  1.73 |    0.02 |    1426 B | 0.1287 |     - |     - |     272 B |              1 |                       2 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |   100 | 434.8 ns |  5.75 ns | 5.10 ns |  1.14 |    0.02 |    1286 B | 0.1297 |     - |     - |     272 B |              1 |                       1 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 670.5 ns |  6.08 ns | 5.68 ns |  1.76 |    0.03 |     838 B | 0.1059 |     - |     - |     224 B |              1 |                       2 |
|       Hyperlinq_Pool | .NET Core 3.1 | .NET Core 3.1 |   100 | 748.8 ns |  9.26 ns | 8.67 ns |  1.96 |    0.04 |    1139 B | 0.0267 |     - |     - |      56 B |              1 |                       2 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |   100 | 252.8 ns |  1.90 ns | 1.69 ns |  0.66 |    0.01 |     336 B | 0.4168 |     - |     - |     872 B |              0 |                       0 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |   100 | 390.2 ns |  5.71 ns | 4.77 ns |  1.02 |    0.02 |     429 B | 0.4168 |     - |     - |     872 B |              1 |                       1 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |   100 | 578.8 ns |  6.25 ns | 5.85 ns |  1.52 |    0.02 |    1557 B | 0.3939 |     - |     - |     824 B |              1 |                       2 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |   100 | 440.5 ns |  4.82 ns | 4.51 ns |  1.15 |    0.02 |     802 B | 0.4168 |     - |     - |     872 B |              1 |                       2 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 630.1 ns |  6.55 ns | 6.12 ns |  1.65 |    0.03 |    1497 B | 0.1297 |     - |     - |     272 B |              1 |                       2 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |   100 | 342.6 ns |  5.11 ns | 4.53 ns |  0.90 |    0.02 |    1327 B | 0.1297 |     - |     - |     272 B |              1 |                       1 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 583.7 ns |  6.41 ns | 6.00 ns |  1.53 |    0.02 |     789 B | 0.1068 |     - |     - |     224 B |              1 |                       2 |
|       Hyperlinq_Pool | .NET Core 5.0 | .NET Core 5.0 |   100 | 625.9 ns |  5.23 ns | 4.89 ns |  1.64 |    0.02 |    1089 B | 0.0267 |     - |     - |      56 B |              0 |                       2 |
