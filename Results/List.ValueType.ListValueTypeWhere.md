## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|              ForLoop |      .NET 4.8 |      .NET 4.8 |   100 |   492.6 ns |  1.80 ns |  1.68 ns |  1.00 |    0.00 |      - |     - |     - |         - |     434 B |              0 |                       0 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |   100 |   707.3 ns |  2.08 ns |  1.95 ns |  1.44 |    0.01 |      - |     - |     - |         - |     622 B |              0 |                       0 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |   100 | 1,419.2 ns |  7.83 ns |  7.33 ns |  2.88 |    0.02 | 0.0648 |     - |     - |     136 B |    1092 B |              1 |                       1 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |   100 | 1,151.4 ns |  8.95 ns |  7.93 ns |  2.34 |    0.02 | 2.4452 |     - |     - |    5136 B |     769 B |              5 |                       3 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |   100 |   791.9 ns |  1.91 ns |  1.70 ns |  1.61 |    0.01 |      - |     - |     - |         - |    1087 B |              0 |                       0 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |   100 |   502.3 ns |  1.21 ns |  1.13 ns |  1.02 |    0.00 |      - |     - |     - |         - |     762 B |              0 |                       0 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |   100 |   713.2 ns |  2.52 ns |  2.23 ns |  1.45 |    0.01 |      - |     - |     - |         - |    1426 B |              0 |                       1 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |   100 |   505.4 ns |  1.45 ns |  1.36 ns |  1.03 |    0.00 |      - |     - |     - |         - |     349 B |              0 |                       0 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |   100 |   719.5 ns |  2.82 ns |  2.64 ns |  1.46 |    0.01 |      - |     - |     - |         - |     589 B |              0 |                       0 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,454.9 ns |  8.35 ns |  7.81 ns |  2.95 |    0.02 | 0.0648 |     - |     - |     136 B |    1087 B |              2 |                       1 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,150.3 ns |  9.02 ns |  7.53 ns |  2.34 |    0.02 | 2.4433 |     - |     - |    5112 B |     637 B |              5 |                       2 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |   100 |   780.3 ns |  2.17 ns |  2.03 ns |  1.58 |    0.01 |      - |     - |     - |         - |     989 B |              0 |                       1 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |   100 |   502.5 ns |  1.52 ns |  1.34 ns |  1.02 |    0.00 |      - |     - |     - |         - |     694 B |              0 |                       0 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |   100 |   678.3 ns |  2.01 ns |  1.78 ns |  1.38 |    0.01 |      - |     - |     - |         - |     827 B |              0 |                       1 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |   100 |   499.0 ns |  1.08 ns |  1.01 ns |  1.01 |    0.00 |      - |     - |     - |         - |     347 B |              0 |                       0 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |   100 |   698.3 ns |  2.76 ns |  2.45 ns |  1.42 |    0.01 |      - |     - |     - |         - |     569 B |              0 |                       0 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,124.3 ns | 18.61 ns | 15.54 ns |  2.28 |    0.03 | 0.0648 |     - |     - |     136 B |    1065 B |              2 |                       1 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,091.4 ns | 10.20 ns |  9.04 ns |  2.22 |    0.02 | 2.4433 |     - |     - |    5112 B |     647 B |              5 |                       2 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |   100 |   737.8 ns |  3.05 ns |  2.70 ns |  1.50 |    0.01 |      - |     - |     - |         - |     967 B |              0 |                       0 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |   100 |   493.6 ns |  2.21 ns |  2.07 ns |  1.00 |    0.00 |      - |     - |     - |         - |     669 B |              0 |                       0 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |   100 |   672.0 ns |  1.35 ns |  1.13 ns |  1.36 |    0.01 |      - |     - |     - |         - |     822 B |              0 |                       1 |
