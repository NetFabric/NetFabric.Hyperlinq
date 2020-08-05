## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

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
|              ForLoop |      .NET 4.8 |      .NET 4.8 |   100 | 1,129.9 ns |  7.28 ns |  6.81 ns |  1.00 |    0.00 |     704 B | 3.4122 |     - |     - |    7166 B |              5 |                       2 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |   100 | 1,811.4 ns | 11.01 ns | 10.30 ns |  1.60 |    0.01 |     888 B | 3.4122 |     - |     - |    7166 B |              5 |                       3 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |   100 | 2,166.3 ns |  6.98 ns |  6.19 ns |  1.92 |    0.01 |    1552 B | 3.5286 |     - |     - |    7409 B |              8 |                       3 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |   100 | 1,426.8 ns | 14.52 ns | 12.87 ns |  1.26 |    0.01 |    1286 B | 3.4122 |     - |     - |    7166 B |              5 |                       2 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |   100 | 1,492.1 ns | 13.71 ns | 12.82 ns |  1.32 |    0.01 |    2275 B | 0.9899 |     - |     - |    2078 B |              5 |                       2 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |   100 | 1,044.6 ns |  7.85 ns |  7.35 ns |  0.92 |    0.01 |    1898 B | 0.9899 |     - |     - |    2078 B |              3 |                       2 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |   100 | 1,365.7 ns | 15.81 ns | 14.79 ns |  1.21 |    0.02 |    1454 B | 0.9670 |     - |     - |    2030 B |              4 |                       2 |
|       Hyperlinq_Pool |      .NET 4.8 |      .NET 4.8 |   100 | 1,361.1 ns |  7.68 ns |  6.81 ns |  1.21 |    0.01 |    2253 B | 0.0267 |     - |     - |      56 B |              1 |                       2 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,141.6 ns |  8.45 ns |  7.90 ns |  1.01 |    0.01 |     742 B | 3.4103 |     - |     - |    7136 B |              4 |                       2 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,359.4 ns | 11.08 ns | 10.37 ns |  1.20 |    0.01 |     990 B | 3.4103 |     - |     - |    7136 B |              5 |                       3 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,401.0 ns | 13.94 ns | 12.36 ns |  1.24 |    0.01 |    1672 B | 2.4853 |     - |     - |    5200 B |              6 |                       3 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,441.9 ns | 14.61 ns | 13.66 ns |  1.28 |    0.01 |    1235 B | 3.4103 |     - |     - |    7136 B |              6 |                       3 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,454.7 ns | 13.90 ns | 13.00 ns |  1.29 |    0.01 |    1903 B | 0.9899 |     - |     - |    2072 B |              6 |                       2 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |   100 |   993.8 ns |  5.83 ns |  5.17 ns |  0.88 |    0.01 |    1607 B | 0.9899 |     - |     - |    2072 B |              4 |                       2 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,345.5 ns |  8.46 ns |  7.91 ns |  1.19 |    0.01 |     922 B | 0.9670 |     - |     - |    2024 B |              4 |                       2 |
|       Hyperlinq_Pool | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,245.7 ns |  7.29 ns |  6.82 ns |  1.10 |    0.01 |    1399 B | 0.0267 |     - |     - |      56 B |              1 |                       2 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,035.9 ns |  8.66 ns |  8.10 ns |  0.92 |    0.01 |     678 B | 3.4103 |     - |     - |    7136 B |              4 |                       1 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,242.3 ns |  7.11 ns |  6.30 ns |  1.10 |    0.01 |     921 B | 3.4103 |     - |     - |    7136 B |              6 |                       2 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,344.6 ns | 14.57 ns | 13.63 ns |  1.19 |    0.01 |    1641 B | 2.4853 |     - |     - |    5200 B |              5 |                       3 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,419.9 ns | 23.48 ns | 19.61 ns |  1.26 |    0.02 |    1194 B | 3.4103 |     - |     - |    7136 B |              5 |                       3 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,303.5 ns | 10.90 ns |  9.10 ns |  1.16 |    0.01 |    1941 B | 0.9899 |     - |     - |    2072 B |              4 |                       2 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |   100 |   848.3 ns |  7.55 ns |  7.07 ns |  0.75 |    0.01 |    1583 B | 0.9899 |     - |     - |    2072 B |              3 |                       2 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,256.5 ns | 11.49 ns | 10.19 ns |  1.11 |    0.01 |      48 B | 0.9670 |     - |     - |    2024 B |              4 |                       2 |
|       Hyperlinq_Pool | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,158.2 ns |  7.25 ns |  6.05 ns |  1.03 |    0.01 |    1368 B | 0.0267 |     - |     - |      56 B |              1 |                       2 |
