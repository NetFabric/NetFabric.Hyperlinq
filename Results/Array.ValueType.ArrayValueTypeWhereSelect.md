## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|               Method |           Job |       Runtime | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |-------------- |-------------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|----------:|---------------:|------------------------:|
|              ForLoop |      .NET 4.8 |      .NET 4.8 |   100 |   848.4 ns |  2.83 ns |  2.64 ns |  1.00 |      - |     - |     - |         - |     460 B |              0 |                       0 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |   100 |   859.0 ns |  3.82 ns |  3.57 ns |  1.01 |      - |     - |     - |         - |     468 B |              0 |                       0 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |   100 | 1,717.5 ns |  8.36 ns |  6.53 ns |  2.03 | 0.0877 |     - |     - |     185 B |    1814 B |              2 |                       1 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |   100 | 1,388.1 ns |  6.77 ns |  6.33 ns |  1.64 | 2.8896 |     - |     - |    6067 B |    1221 B |              6 |                       1 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |   100 | 1,343.7 ns |  5.32 ns |  4.97 ns |  1.58 |      - |     - |     - |         - |    1850 B |              0 |                       1 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |   100 |   911.0 ns |  3.19 ns |  2.98 ns |  1.07 |      - |     - |     - |         - |    1479 B |              0 |                       0 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |   100 | 1,305.4 ns |  5.53 ns |  4.90 ns |  1.54 |      - |     - |     - |         - |    1628 B |              0 |                       1 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |   100 |   862.5 ns |  2.63 ns |  2.33 ns |  1.02 |      - |     - |     - |         - |     443 B |              0 |                       0 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |   100 |   879.0 ns |  5.08 ns |  4.24 ns |  1.04 |      - |     - |     - |         - |     451 B |              0 |                       1 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,724.4 ns |  9.07 ns |  8.48 ns |  2.03 | 0.0801 |     - |     - |     168 B |    2010 B |              2 |                       1 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,429.6 ns | 11.81 ns | 11.05 ns |  1.69 | 2.8896 |     - |     - |    6048 B |    1113 B |              5 |                       1 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,320.1 ns |  6.70 ns |  6.27 ns |  1.56 |      - |     - |     - |         - |    1714 B |              0 |                       1 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |   100 |   901.7 ns |  1.61 ns |  1.34 ns |  1.06 |      - |     - |     - |         - |    1369 B |              0 |                       0 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,222.2 ns |  3.69 ns |  3.27 ns |  1.44 |      - |     - |     - |         - |    1351 B |              0 |                       1 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |   100 |   857.2 ns |  2.78 ns |  2.32 ns |  1.01 |      - |     - |     - |         - |     439 B |              0 |                       0 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |   100 |   843.8 ns |  4.51 ns |  3.77 ns |  0.99 |      - |     - |     - |         - |     459 B |              0 |                       0 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,370.2 ns |  5.68 ns |  5.31 ns |  1.62 | 0.0801 |     - |     - |     168 B |    1978 B |              2 |                       1 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,387.2 ns | 11.88 ns | 11.12 ns |  1.64 | 2.8896 |     - |     - |    6048 B |    1100 B |              5 |                       1 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,250.5 ns |  5.37 ns |  4.76 ns |  1.47 |      - |     - |     - |         - |    1583 B |              0 |                       1 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |   100 |   895.4 ns |  2.81 ns |  2.63 ns |  1.06 |      - |     - |     - |         - |    1255 B |              0 |                       0 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,218.2 ns |  3.13 ns |  2.92 ns |  1.44 |      - |     - |     - |         - |    1334 B |              0 |                       1 |
