## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

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
|               Method |           Job |       Runtime | Start | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |-------------- |-------------- |------ |------ |-----------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|----------:|---------------:|------------------------:|
|              ForLoop |      .NET 4.8 |      .NET 4.8 |     0 |   100 |   424.4 ns | 3.13 ns | 2.77 ns |  1.00 |    0.00 | 0.5698 |     - |     - |    1196 B |     186 B |              2 |                       1 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |   100 |   865.8 ns | 3.87 ns | 3.43 ns |  2.04 |    0.01 | 0.5960 |     - |     - |    1252 B |     427 B |              3 |                       3 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |   100 | 1,675.8 ns | 9.03 ns | 8.45 ns |  3.95 |    0.04 | 0.6218 |     - |     - |    1308 B |     930 B |              5 |                       5 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |   100 |   333.6 ns | 2.61 ns | 2.31 ns |  0.79 |    0.01 | 0.6270 |     - |     - |    1316 B |    1081 B |              1 |                       1 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |   100 |   747.4 ns | 3.14 ns | 2.94 ns |  1.76 |    0.02 | 0.2365 |     - |     - |     498 B |    1283 B |              2 |                       3 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |   100 |   550.6 ns | 1.63 ns | 1.45 ns |  1.30 |    0.01 | 0.2365 |     - |     - |     498 B |    1279 B |              2 |                       1 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |   100 |   269.8 ns | 2.09 ns | 1.74 ns |  0.64 |    0.01 | 0.2484 |     - |     - |     522 B |    1156 B |              1 |                       1 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 |   326.2 ns | 3.41 ns | 3.03 ns |  0.77 |    0.01 | 0.5660 |     - |     - |    1184 B |     210 B |              1 |                       0 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 |   730.8 ns | 4.54 ns | 4.25 ns |  1.72 |    0.02 | 0.5922 |     - |     - |    1240 B |     491 B |              2 |                       3 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 |   311.5 ns | 1.79 ns | 1.67 ns |  0.73 |    0.01 | 0.2599 |     - |     - |     544 B |    1177 B |              1 |                       1 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 |   359.1 ns | 3.81 ns | 3.18 ns |  0.85 |    0.01 | 0.6232 |     - |     - |    1304 B |    1112 B |              1 |                       1 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 |   600.2 ns | 5.89 ns | 5.51 ns |  1.41 |    0.01 | 0.2327 |     - |     - |     488 B |     995 B |              2 |                       3 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 |   468.9 ns | 2.43 ns | 2.27 ns |  1.11 |    0.01 | 0.2317 |     - |     - |     488 B |     980 B |              2 |                       1 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 |   289.5 ns | 1.55 ns | 1.37 ns |  0.68 |    0.01 | 0.2446 |     - |     - |     512 B |    1183 B |              1 |                       0 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |   282.6 ns | 2.56 ns | 2.40 ns |  0.67 |    0.01 | 0.5660 |     - |     - |    1184 B |     210 B |              1 |                       0 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |   734.5 ns | 3.36 ns | 2.98 ns |  1.73 |    0.01 | 0.5922 |     - |     - |    1240 B |     478 B |              3 |                       2 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |   331.6 ns | 2.22 ns | 1.96 ns |  0.78 |    0.01 | 0.2599 |     - |     - |     544 B |    1163 B |              1 |                       1 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |   362.5 ns | 2.67 ns | 2.23 ns |  0.85 |    0.01 | 0.6232 |     - |     - |    1304 B |    1090 B |              1 |                       1 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |   501.5 ns | 1.28 ns | 1.13 ns |  1.18 |    0.01 | 0.2327 |     - |     - |     488 B |    1110 B |              2 |                       3 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |   385.1 ns | 2.11 ns | 1.87 ns |  0.91 |    0.01 | 0.2332 |     - |     - |     488 B |    1102 B |              1 |                       0 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |   256.3 ns | 2.27 ns | 2.01 ns |  0.60 |    0.01 | 0.2446 |     - |     - |     512 B |    1153 B |              1 |                       1 |
