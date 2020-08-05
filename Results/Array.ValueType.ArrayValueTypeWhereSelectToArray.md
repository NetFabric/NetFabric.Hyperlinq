## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|               Method |           Job |       Runtime | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |-------------- |-------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|----------:|---------------:|------------------------:|
|              ForLoop |      .NET 4.8 |      .NET 4.8 |   100 | 1,088.8 ns |  6.31 ns |  5.60 ns |  1.00 |    0.00 | 3.4122 |     - |     - |    7166 B |     606 B |              4 |                       1 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |   100 | 1,093.5 ns |  8.80 ns |  8.23 ns |  1.00 |    0.01 | 3.4122 |     - |     - |    7166 B |     611 B |              4 |                       1 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |   100 | 1,990.7 ns | 14.41 ns | 12.78 ns |  1.83 |    0.02 | 3.4828 |     - |     - |    7310 B |    1552 B |              7 |                       3 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |   100 | 1,027.9 ns |  7.50 ns |  7.01 ns |  0.94 |    0.01 | 2.8896 |     - |     - |    6067 B |     973 B |              4 |                       1 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |   100 | 1,480.2 ns | 12.85 ns | 11.39 ns |  1.36 |    0.01 | 0.9880 |     - |     - |    2078 B |    2282 B |              5 |                       2 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |   100 | 1,031.1 ns |  7.49 ns |  7.01 ns |  0.95 |    0.01 | 0.9899 |     - |     - |    2078 B |    1908 B |              4 |                       2 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |   100 | 1,362.4 ns | 10.02 ns |  8.88 ns |  1.25 |    0.01 | 0.9670 |     - |     - |    2030 B |    1170 B |              6 |                       2 |
|       Hyperlinq_Pool |      .NET 4.8 |      .NET 4.8 |   100 | 1,368.1 ns |  5.51 ns |  5.15 ns |  1.26 |    0.01 | 0.0267 |     - |     - |      56 B |    1972 B |              1 |                       2 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,088.3 ns | 11.29 ns |  9.43 ns |  1.00 |    0.01 | 3.4103 |     - |     - |    7136 B |     700 B |              4 |                       1 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,110.0 ns |  9.70 ns |  8.60 ns |  1.02 |    0.01 | 3.4103 |     - |     - |    7136 B |     705 B |              5 |                       1 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,375.4 ns |  9.36 ns |  8.76 ns |  1.26 |    0.01 | 2.4319 |     - |     - |    5088 B |    1672 B |              6 |                       3 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,023.0 ns | 11.48 ns | 10.74 ns |  0.94 |    0.01 | 2.8896 |     - |     - |    6048 B |     859 B |              5 |                       1 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,385.4 ns | 16.35 ns | 15.30 ns |  1.27 |    0.02 | 0.9899 |     - |     - |    2072 B |    1902 B |              4 |                       1 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |   100 |   965.9 ns |  5.60 ns |  5.24 ns |  0.89 |    0.01 | 0.9899 |     - |     - |    2072 B |    1606 B |              3 |                       2 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,303.1 ns |  9.64 ns |  9.01 ns |  1.20 |    0.01 | 0.9670 |     - |     - |    2024 B |     899 B |              6 |                       2 |
|       Hyperlinq_Pool | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,262.7 ns | 11.14 ns | 10.42 ns |  1.16 |    0.01 | 0.0267 |     - |     - |      56 B |    1376 B |              1 |                       2 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |   100 |   988.6 ns | 10.41 ns |  9.74 ns |  0.91 |    0.01 | 3.4103 |     - |     - |    7136 B |     654 B |              4 |                       1 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,000.8 ns | 12.22 ns | 10.84 ns |  0.92 |    0.01 | 3.4103 |     - |     - |    7136 B |     653 B |              4 |                       1 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,282.8 ns | 10.08 ns |  9.43 ns |  1.18 |    0.01 | 2.4319 |     - |     - |    5088 B |    1641 B |              6 |                       2 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,032.1 ns |  7.45 ns |  6.60 ns |  0.95 |    0.01 | 2.8896 |     - |     - |    6048 B |     839 B |              4 |                       1 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,319.4 ns | 10.48 ns |  9.29 ns |  1.21 |    0.01 | 0.9899 |     - |     - |    2072 B |    1943 B |              5 |                       2 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |   100 |   868.7 ns |  6.51 ns |  5.77 ns |  0.80 |    0.01 | 0.9899 |     - |     - |    2072 B |    1585 B |              3 |                       3 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,259.1 ns |  9.60 ns |  8.98 ns |  1.16 |    0.01 | 0.9670 |     - |     - |    2024 B |     858 B |              5 |                       3 |
|       Hyperlinq_Pool | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,166.4 ns |  7.55 ns |  7.06 ns |  1.07 |    0.01 | 0.0267 |     - |     - |      56 B |    1353 B |              1 |                       2 |
