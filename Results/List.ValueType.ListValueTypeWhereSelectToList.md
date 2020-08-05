## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
|              ForLoop |      .NET 4.8 |      .NET 4.8 |   100 | 1,006.7 ns |  7.07 ns |  6.61 ns |  1.00 |    0.00 | 2.4452 |     - |     - |   5.02 KB |   0.61 KB |              3 |                       1 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |   100 | 1,199.9 ns |  5.03 ns |  4.70 ns |  1.19 |    0.01 | 2.4452 |     - |     - |   5.02 KB |   0.79 KB |              4 |                       2 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |   100 | 2,161.4 ns | 16.14 ns | 15.10 ns |  2.15 |    0.02 | 2.5787 |     - |     - |   5.29 KB |   1.48 KB |              7 |                       3 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |   100 | 1,454.0 ns | 14.15 ns | 13.24 ns |  1.44 |    0.02 | 3.4332 |     - |     - |   7.04 KB |   1.79 KB |              5 |                       3 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |   100 | 1,499.9 ns | 13.62 ns | 12.74 ns |  1.49 |    0.01 | 1.0090 |     - |     - |   2.07 KB |   2.28 KB |              5 |                       2 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |   100 | 1,056.0 ns |  4.31 ns |  4.03 ns |  1.05 |    0.01 | 1.0090 |     - |     - |   2.07 KB |   1.91 KB |              4 |                       3 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |   100 | 1,389.4 ns |  7.94 ns |  7.04 ns |  1.38 |    0.01 | 1.0204 |     - |     - |   2.09 KB |   1.43 KB |              4 |                       2 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,016.9 ns |  7.87 ns |  7.36 ns |  1.01 |    0.01 | 2.4433 |     - |     - |   4.99 KB |   0.62 KB |              4 |                       1 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,229.5 ns | 10.01 ns |  9.37 ns |  1.22 |    0.01 | 2.4433 |     - |     - |   4.99 KB |   0.86 KB |              5 |                       3 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,391.7 ns | 23.11 ns | 19.30 ns |  1.38 |    0.02 | 2.5768 |     - |     - |   5.27 KB |   1.65 KB |              6 |                       2 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,447.5 ns | 18.34 ns | 16.26 ns |  1.44 |    0.02 | 3.4237 |     - |     - |      7 KB |   1.72 KB |              6 |                       3 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,391.3 ns |  8.87 ns |  7.87 ns |  1.38 |    0.01 | 1.0052 |     - |     - |   2.05 KB |   1.92 KB |              5 |                       2 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |   100 |   966.5 ns |  6.23 ns |  5.83 ns |  0.96 |    0.01 | 1.0052 |     - |     - |   2.05 KB |   1.63 KB |              4 |                       2 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,377.3 ns | 22.56 ns | 47.08 ns |  1.41 |    0.07 | 1.0166 |     - |     - |   2.08 KB |   0.94 KB |              4 |                       2 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |   100 |   906.9 ns |  5.24 ns |  4.64 ns |  0.90 |    0.01 | 2.4433 |     - |     - |   4.99 KB |   0.57 KB |              4 |                       1 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,112.8 ns |  8.03 ns |  7.12 ns |  1.11 |    0.01 | 2.4433 |     - |     - |   4.99 KB |   0.81 KB |              5 |                       2 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,332.4 ns | 24.94 ns | 25.61 ns |  1.32 |    0.03 | 2.5768 |     - |     - |   5.27 KB |   1.63 KB |              5 |                       2 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,381.7 ns | 19.38 ns | 17.18 ns |  1.37 |    0.02 | 3.4237 |     - |     - |      7 KB |   1.69 KB |              5 |                       3 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,292.4 ns | 13.93 ns | 11.63 ns |  1.28 |    0.02 | 1.0052 |     - |     - |   2.05 KB |   1.95 KB |              5 |                       2 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |   100 |   848.8 ns |  5.89 ns |  5.23 ns |  0.84 |    0.01 | 1.0052 |     - |     - |   2.05 KB |   1.61 KB |              3 |                       2 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,272.4 ns | 16.50 ns | 15.43 ns |  1.26 |    0.02 | 1.0166 |     - |     - |   2.08 KB |   0.91 KB |              4 |                       2 |
