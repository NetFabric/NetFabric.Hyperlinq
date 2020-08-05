## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|               Method |           Job |       Runtime | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |-------------- |-------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|----------:|---------------:|------------------------:|
|              ForLoop |      .NET 4.8 |      .NET 4.8 |   100 | 274.8 ns | 1.61 ns | 1.35 ns |  1.00 |    0.00 | 0.3133 |     - |     - |     658 B |     199 B |              1 |                       1 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |   100 | 273.8 ns | 1.29 ns | 1.21 ns |  1.00 |    0.01 | 0.3133 |     - |     - |     658 B |     199 B |              1 |                       1 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |   100 | 848.0 ns | 9.42 ns | 7.87 ns |  3.09 |    0.03 | 0.3633 |     - |     - |     762 B |    1418 B |              3 |                       3 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |   100 | 410.5 ns | 1.95 ns | 1.73 ns |  1.49 |    0.01 | 0.4358 |     - |     - |     915 B |    1153 B |              1 |                       1 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |   100 | 757.2 ns | 3.88 ns | 3.44 ns |  2.76 |    0.02 | 0.1488 |     - |     - |     313 B |    1811 B |              2 |                       2 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |   100 | 499.8 ns | 2.86 ns | 2.23 ns |  1.82 |    0.01 | 0.1488 |     - |     - |     313 B |    1662 B |              1 |                       1 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |   100 | 823.4 ns | 2.94 ns | 2.60 ns |  3.00 |    0.02 | 0.1602 |     - |     - |     337 B |    1096 B |              2 |                       2 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |   100 | 241.2 ns | 1.79 ns | 1.68 ns |  0.88 |    0.01 | 0.3095 |     - |     - |     648 B |     223 B |              1 |                       0 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |   100 | 241.3 ns | 1.48 ns | 1.32 ns |  0.88 |    0.01 | 0.3095 |     - |     - |     648 B |     223 B |              1 |                       0 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |   100 | 536.6 ns | 4.21 ns | 3.73 ns |  1.95 |    0.02 | 0.3595 |     - |     - |     752 B |    1608 B |              2 |                       2 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |   100 | 437.9 ns | 2.81 ns | 2.63 ns |  1.60 |    0.01 | 0.4320 |     - |     - |     904 B |    1177 B |              2 |                       1 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 770.2 ns | 4.37 ns | 3.88 ns |  2.80 |    0.02 | 0.1440 |     - |     - |     304 B |    1483 B |              2 |                       2 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |   100 | 449.1 ns | 2.91 ns | 2.58 ns |  1.63 |    0.01 | 0.1450 |     - |     - |     304 B |    1343 B |              2 |                       1 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 724.9 ns | 4.82 ns | 4.03 ns |  2.64 |    0.03 | 0.1554 |     - |     - |     328 B |     860 B |              2 |                       2 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |   100 | 208.2 ns | 1.91 ns | 1.78 ns |  0.76 |    0.01 | 0.3097 |     - |     - |     648 B |     223 B |              1 |                       1 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |   100 | 222.3 ns | 1.17 ns | 1.03 ns |  0.81 |    0.01 | 0.3097 |     - |     - |     648 B |     223 B |              1 |                       0 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |   100 | 519.8 ns | 3.79 ns | 3.16 ns |  1.89 |    0.02 | 0.3595 |     - |     - |     752 B |    1585 B |              2 |                       2 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |   100 | 367.2 ns | 1.48 ns | 1.39 ns |  1.34 |    0.01 | 0.4320 |     - |     - |     904 B |    1148 B |              1 |                       1 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 642.6 ns | 4.24 ns | 3.31 ns |  2.34 |    0.01 | 0.1450 |     - |     - |     304 B |    1555 B |              2 |                       2 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |   100 | 353.1 ns | 1.34 ns | 1.19 ns |  1.29 |    0.01 | 0.1450 |     - |     - |     304 B |    1389 B |              1 |                       1 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 610.6 ns | 4.60 ns | 4.08 ns |  2.22 |    0.02 | 0.1564 |     - |     - |     328 B |     830 B |              2 |                       2 |
