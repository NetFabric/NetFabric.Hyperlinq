## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|              ForLoop |      .NET 4.8 |      .NET 4.8 |   100 |   966.6 ns |  3.76 ns |  3.33 ns |  1.00 |    0.00 |   0.51 KB | 2.4452 |     - |     - |   5.02 KB |              3 |                       1 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |   100 |   940.8 ns |  8.69 ns |  8.13 ns |  0.97 |    0.01 |   0.52 KB | 2.4452 |     - |     - |   5.02 KB |              3 |                       1 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |   100 | 1,822.6 ns |  6.87 ns |  6.09 ns |  1.89 |    0.01 |   1.48 KB | 2.5330 |     - |     - |    5.2 KB |              7 |                       3 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |   100 | 1,197.4 ns |  8.30 ns |  7.76 ns |  1.24 |    0.01 |   1.56 KB | 3.8757 |     - |     - |   7.95 KB |              6 |                       1 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |   100 | 1,495.6 ns | 10.34 ns |  9.16 ns |  1.55 |    0.01 |    2.3 KB | 1.0090 |     - |     - |   2.07 KB |              5 |                       2 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |   100 | 1,032.8 ns |  9.58 ns |  8.96 ns |  1.07 |    0.01 |   1.94 KB | 1.0090 |     - |     - |   2.07 KB |              4 |                       3 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |   100 | 1,386.9 ns | 15.77 ns | 14.75 ns |  1.44 |    0.02 |   1.16 KB | 1.0204 |     - |     - |   2.09 KB |              5 |                       2 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |   100 |   979.7 ns | 10.07 ns |  9.42 ns |  1.01 |    0.01 |   0.58 KB | 2.4433 |     - |     - |   4.99 KB |              4 |                       1 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |   100 |   978.3 ns |  5.87 ns |  5.49 ns |  1.01 |    0.01 |   0.59 KB | 2.4433 |     - |     - |   4.99 KB |              4 |                       1 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,274.0 ns |  9.94 ns |  8.30 ns |  1.32 |    0.01 |   1.65 KB | 2.5234 |     - |     - |   5.16 KB |              5 |                       2 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,189.4 ns | 10.75 ns | 10.06 ns |  1.23 |    0.01 |    1.5 KB | 3.8700 |     - |     - |   7.91 KB |              5 |                       1 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,396.9 ns | 10.11 ns |  8.44 ns |  1.45 |    0.01 |   1.91 KB | 1.0052 |     - |     - |   2.05 KB |              5 |                       2 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,007.3 ns |  6.56 ns |  6.14 ns |  1.04 |    0.01 |   1.63 KB | 1.0052 |     - |     - |   2.05 KB |              4 |                       2 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,341.8 ns | 11.86 ns | 10.52 ns |  1.39 |    0.01 |   0.92 KB | 1.0166 |     - |     - |   2.08 KB |              6 |                       3 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |   100 |   870.6 ns |  5.44 ns |  4.54 ns |  0.90 |    0.01 |   0.55 KB | 2.4433 |     - |     - |   4.99 KB |              3 |                       1 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |   100 |   861.0 ns |  8.92 ns |  8.34 ns |  0.89 |    0.01 |   0.55 KB | 2.4433 |     - |     - |   4.99 KB |              4 |                       1 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,285.9 ns | 14.60 ns | 13.66 ns |  1.33 |    0.02 |   1.63 KB | 2.5234 |     - |     - |   5.16 KB |              5 |                       3 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,156.1 ns |  8.94 ns |  8.36 ns |  1.20 |    0.01 |   1.47 KB | 3.8700 |     - |     - |   7.91 KB |              6 |                       1 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,290.7 ns | 15.38 ns | 14.39 ns |  1.34 |    0.02 |   1.95 KB | 1.0052 |     - |     - |   2.05 KB |              4 |                       2 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |   100 |   862.4 ns |  5.43 ns |  5.08 ns |  0.89 |    0.01 |   1.61 KB | 1.0052 |     - |     - |   2.05 KB |              4 |                       3 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,280.6 ns | 15.18 ns | 12.68 ns |  1.32 |    0.01 |   0.89 KB | 1.0166 |     - |     - |   2.08 KB |              5 |                       2 |
