## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

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
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |   100 |   822.8 ns |  2.47 ns |  2.31 ns |  1.00 |    0.00 |     444 B | 0.4396 |     - |     - |     923 B |              3 |                       4 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |   100 | 1,291.7 ns |  3.61 ns |  3.37 ns |  1.57 |    0.01 |    1458 B | 0.4768 |     - |     - |    1003 B |              4 |                       5 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |   100 | 1,287.8 ns | 10.69 ns | 10.00 ns |  1.57 |    0.01 |    1576 B | 0.1450 |     - |     - |     305 B |              3 |                       2 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |   100 |   898.5 ns |  2.29 ns |  2.03 ns |  1.09 |    0.00 |    1524 B | 0.1450 |     - |     - |     305 B |              2 |                       2 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |   100 | 1,150.2 ns |  9.25 ns |  7.73 ns |  1.40 |    0.01 |     625 B | 0.1259 |     - |     - |     265 B |              2 |                       2 |
|       Hyperlinq_Pool |      .NET 4.8 |      .NET 4.8 |   100 | 1,246.5 ns |  5.65 ns |  5.29 ns |  1.51 |    0.01 |    1179 B | 0.0458 |     - |     - |      96 B |              1 |                       2 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |   100 |   753.6 ns |  7.86 ns |  7.35 ns |  0.92 |    0.01 |     496 B | 0.4349 |     - |     - |     912 B |              3 |                       3 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,112.6 ns |  8.92 ns |  8.34 ns |  1.35 |    0.01 |    1588 B | 0.3948 |     - |     - |     832 B |              4 |                       4 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,224.7 ns |  6.83 ns |  6.05 ns |  1.49 |    0.01 |    1284 B | 0.1431 |     - |     - |     304 B |              2 |                       2 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |   100 |   860.6 ns |  2.31 ns |  1.81 ns |  1.05 |    0.00 |    1235 B | 0.1440 |     - |     - |     304 B |              2 |                       2 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,125.0 ns |  5.51 ns |  4.60 ns |  1.37 |    0.01 |     531 B | 0.1259 |     - |     - |     264 B |              3 |                       2 |
|       Hyperlinq_Pool | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,172.1 ns |  4.86 ns |  4.31 ns |  1.42 |    0.00 |     817 B | 0.0458 |     - |     - |      96 B |              1 |                       2 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |   100 |   749.5 ns |  3.13 ns |  2.93 ns |  0.91 |    0.00 |     461 B | 0.4358 |     - |     - |     912 B |              2 |                       3 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,076.3 ns |  7.15 ns |  6.69 ns |  1.31 |    0.01 |    1557 B | 0.3967 |     - |     - |     832 B |              3 |                       4 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,074.6 ns |  4.82 ns |  4.51 ns |  1.31 |    0.01 |    1366 B | 0.1450 |     - |     - |     304 B |              2 |                       2 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |   100 |   739.0 ns |  2.56 ns |  2.39 ns |  0.90 |    0.00 |    1308 B | 0.1450 |     - |     - |     304 B |              2 |                       2 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,039.7 ns | 19.80 ns | 20.33 ns |  1.26 |    0.03 |     514 B | 0.1259 |     - |     - |     264 B |              2 |                       2 |
|       Hyperlinq_Pool | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,059.5 ns |  9.91 ns |  8.78 ns |  1.29 |    0.01 |     798 B | 0.0458 |     - |     - |      96 B |              1 |                       2 |
