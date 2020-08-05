## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|               Method |           Job |       Runtime | Count |       Mean |    Error |   StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |-------------- |-------------- |------ |-----------:|---------:|---------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |      .NET 4.8 |      .NET 4.8 |   100 |   340.8 ns |  2.05 ns |  1.82 ns |  1.00 |    0.00 |     297 B | 0.3133 |     - |     - |     658 B |              0 |                       1 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |   100 |   435.0 ns |  3.25 ns |  2.71 ns |  1.28 |    0.01 |     310 B | 0.3133 |     - |     - |     658 B |              1 |                       1 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |   100 | 1,035.9 ns |  9.77 ns |  9.14 ns |  3.04 |    0.04 |    1421 B | 0.3853 |     - |     - |     810 B |              1 |                       3 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |   100 |   662.9 ns |  7.33 ns |  6.86 ns |  1.94 |    0.02 |    1199 B | 0.4396 |     - |     - |     923 B |              1 |                       2 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |   100 |   803.1 ns | 11.45 ns | 10.71 ns |  2.36 |    0.04 |    1791 B | 0.1488 |     - |     - |     313 B |              1 |                       2 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |   100 |   481.1 ns |  7.20 ns |  6.38 ns |  1.41 |    0.02 |    1637 B | 0.1488 |     - |     - |     313 B |              1 |                       1 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |   100 |   739.4 ns |  8.09 ns |  7.57 ns |  2.17 |    0.02 |    1377 B | 0.1602 |     - |     - |     337 B |              1 |                       2 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |   100 |   260.0 ns |  2.78 ns |  2.60 ns |  0.76 |    0.01 |     247 B | 0.3095 |     - |     - |     648 B |              1 |                       0 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |   100 |   397.6 ns |  4.62 ns |  4.09 ns |  1.17 |    0.01 |     348 B | 0.3095 |     - |     - |     648 B |              1 |                       2 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |   100 |   532.6 ns |  4.02 ns |  3.76 ns |  1.56 |    0.01 |    1608 B | 0.3824 |     - |     - |     800 B |              1 |                       2 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |   100 |   488.8 ns |  5.82 ns |  5.44 ns |  1.43 |    0.02 |    1227 B | 0.4311 |     - |     - |     904 B |              3 |                       3 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |   100 |   719.4 ns |  3.46 ns |  3.24 ns |  2.11 |    0.01 |    1484 B | 0.1440 |     - |     - |     304 B |              2 |                       2 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |   100 |   448.4 ns |  1.71 ns |  1.60 ns |  1.32 |    0.01 |    1344 B | 0.1450 |     - |     - |     304 B |              2 |                       1 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |   100 |   698.9 ns |  4.60 ns |  4.30 ns |  2.05 |    0.01 |     883 B | 0.1564 |     - |     - |     328 B |              2 |                       2 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |   100 |   233.5 ns |  1.77 ns |  1.57 ns |  0.69 |    0.01 |     247 B | 0.3097 |     - |     - |     648 B |              1 |                       0 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |   100 |   376.8 ns |  1.93 ns |  1.61 ns |  1.11 |    0.01 |     338 B | 0.3095 |     - |     - |     648 B |              1 |                       1 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |   100 |   557.0 ns |  3.58 ns |  3.35 ns |  1.63 |    0.01 |    1585 B | 0.3824 |     - |     - |     800 B |              2 |                       2 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |   100 |   460.1 ns |  2.03 ns |  1.90 ns |  1.35 |    0.01 |    1192 B | 0.4320 |     - |     - |     904 B |              2 |                       2 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |   100 |   647.9 ns |  3.77 ns |  3.34 ns |  1.90 |    0.01 |    1559 B | 0.1450 |     - |     - |     304 B |              2 |                       2 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |   100 |   356.4 ns |  1.16 ns |  1.08 ns |  1.05 |    0.01 |    1393 B | 0.1450 |     - |     - |     304 B |              1 |                       1 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |   100 |   678.5 ns |  3.50 ns |  2.92 ns |  1.99 |    0.01 |     845 B | 0.1564 |     - |     - |     328 B |              2 |                       3 |
