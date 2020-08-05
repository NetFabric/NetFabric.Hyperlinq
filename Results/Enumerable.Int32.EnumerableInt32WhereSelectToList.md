## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

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
|               Method |           Job |       Runtime | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |-------------- |-------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|----------:|---------------:|------------------------:|
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |   100 |   786.5 ns | 3.68 ns | 3.26 ns |  1.00 | 0.3328 |     - |     - |     698 B |     360 B |              3 |                       5 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |   100 | 1,417.9 ns | 6.50 ns | 5.76 ns |  1.80 | 0.3891 |     - |     - |     818 B |    1418 B |              4 |                       4 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |   100 | 1,287.3 ns | 6.97 ns | 6.17 ns |  1.64 | 0.1640 |     - |     - |     345 B |    1650 B |              3 |                       2 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |   100 |   928.2 ns | 2.67 ns | 2.23 ns |  1.18 | 0.1640 |     - |     - |     345 B |    1598 B |              2 |                       2 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |   100 | 1,217.4 ns | 5.55 ns | 4.92 ns |  1.55 | 0.1793 |     - |     - |     377 B |     697 B |              3 |                       2 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |   100 |   697.0 ns | 4.52 ns | 4.01 ns |  0.89 | 0.3281 |     - |     - |     688 B |     385 B |              3 |                       3 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,039.9 ns | 5.13 ns | 4.55 ns |  1.32 | 0.3853 |     - |     - |     808 B |    1608 B |              4 |                       4 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,244.2 ns | 4.99 ns | 4.67 ns |  1.58 | 0.1602 |     - |     - |     336 B |    1342 B |              3 |                       2 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |   100 |   834.1 ns | 5.07 ns | 4.74 ns |  1.06 | 0.1602 |     - |     - |     336 B |    1294 B |              3 |                       2 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,154.2 ns | 6.43 ns | 5.70 ns |  1.47 | 0.1736 |     - |     - |     368 B |     605 B |              3 |                       2 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |   100 |   700.3 ns | 4.61 ns | 4.31 ns |  0.89 | 0.3281 |     - |     - |     688 B |     372 B |              2 |                       3 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,026.7 ns | 8.27 ns | 7.74 ns |  1.31 | 0.3853 |     - |     - |     808 B |    1585 B |              3 |                       4 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,123.5 ns | 5.65 ns | 5.01 ns |  1.43 | 0.1602 |     - |     - |     336 B |    1424 B |              3 |                       2 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |   100 |   747.3 ns | 3.07 ns | 2.57 ns |  0.95 | 0.1602 |     - |     - |     336 B |    1366 B |              2 |                       2 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,093.6 ns | 5.16 ns | 4.57 ns |  1.39 | 0.1755 |     - |     - |     368 B |     598 B |              3 |                       2 |
