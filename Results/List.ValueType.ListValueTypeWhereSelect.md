## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|              ForLoop |      .NET 4.8 |      .NET 4.8 |   100 |   906.0 ns |  2.27 ns |  2.02 ns |  1.00 |    0.00 |      - |     - |     - |         - |     585 B |              0 |                       0 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |   100 | 1,082.2 ns |  2.63 ns |  2.46 ns |  1.19 |    0.00 |      - |     - |     - |         - |     757 B |              0 |                       0 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |   100 | 1,943.8 ns | 14.08 ns | 13.17 ns |  2.15 |    0.01 | 0.1335 |     - |     - |     281 B |    1814 B |              3 |                       1 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |   100 | 1,757.1 ns | 12.93 ns | 11.46 ns |  1.94 |    0.01 | 2.4452 |     - |     - |    5136 B |    1619 B |              7 |                       3 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |   100 | 1,339.5 ns |  4.99 ns |  4.42 ns |  1.48 |    0.01 |      - |     - |     - |         - |    1850 B |              0 |                       1 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |   100 |   909.8 ns |  2.50 ns |  2.09 ns |  1.00 |    0.00 |      - |     - |     - |         - |    1467 B |              0 |                       0 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |   100 | 1,277.5 ns |  2.68 ns |  2.51 ns |  1.41 |    0.00 |      - |     - |     - |         - |    1900 B |              0 |                       1 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |   100 |   891.7 ns |  2.64 ns |  2.47 ns |  0.98 |    0.00 |      - |     - |     - |         - |     502 B |              0 |                       0 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,092.5 ns |  4.53 ns |  4.24 ns |  1.21 |    0.00 |      - |     - |     - |         - |     717 B |              0 |                       1 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,958.0 ns | 10.86 ns |  9.07 ns |  2.16 |    0.01 | 0.1335 |     - |     - |     280 B |    2010 B |              3 |                       1 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,744.6 ns | 15.01 ns | 14.04 ns |  1.93 |    0.01 | 2.4433 |     - |     - |    5112 B |    1466 B |              6 |                       3 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,301.0 ns |  3.57 ns |  3.17 ns |  1.44 |    0.00 |      - |     - |     - |         - |    1710 B |              0 |                       1 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |   100 |   906.8 ns |  2.33 ns |  2.07 ns |  1.00 |    0.00 |      - |     - |     - |         - |    1368 B |              0 |                       0 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,223.9 ns |  5.74 ns |  5.37 ns |  1.35 |    0.01 |      - |     - |     - |         - |    1374 B |              0 |                       1 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |   100 |   877.3 ns |  3.39 ns |  3.01 ns |  0.97 |    0.00 |      - |     - |     - |         - |     513 B |              0 |                       0 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,057.2 ns |  3.49 ns |  3.27 ns |  1.17 |    0.00 |      - |     - |     - |         - |     729 B |              0 |                       0 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,608.9 ns |  5.60 ns |  4.97 ns |  1.78 |    0.01 | 0.1335 |     - |     - |     280 B |    1978 B |              3 |                       1 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,718.0 ns | 19.28 ns | 17.09 ns |  1.90 |    0.02 | 2.4433 |     - |     - |    5112 B |    1474 B |              6 |                       2 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,238.7 ns |  5.81 ns |  5.43 ns |  1.37 |    0.00 |      - |     - |     - |         - |    1564 B |              0 |                       1 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |   100 |   894.7 ns |  2.04 ns |  1.91 ns |  0.99 |    0.00 |      - |     - |     - |         - |    1261 B |              0 |                       0 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,213.5 ns |  5.89 ns |  4.60 ns |  1.34 |    0.00 |      - |     - |     - |         - |    1349 B |              0 |                       1 |
