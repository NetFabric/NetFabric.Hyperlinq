## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|               Method |           Job |       Runtime | Count |     Mean |   Error |  StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |-------------- |-------------- |------ |---------:|--------:|--------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |      .NET 4.8 |      .NET 4.8 |   100 | 317.2 ns | 1.72 ns | 1.34 ns |  1.00 |    0.00 |     283 B | 0.4206 |     - |     - |     883 B |              1 |                       1 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |   100 | 320.0 ns | 1.77 ns | 1.57 ns |  1.01 |    0.00 |     283 B | 0.4206 |     - |     - |     883 B |              1 |                       1 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |   100 | 829.3 ns | 3.91 ns | 3.65 ns |  2.62 |    0.01 |    1458 B | 0.4511 |     - |     - |     947 B |              3 |                       2 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |   100 | 365.9 ns | 1.85 ns | 1.73 ns |  1.15 |    0.01 |     718 B | 0.3095 |     - |     - |     650 B |              1 |                       1 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |   100 | 753.9 ns | 3.97 ns | 3.52 ns |  2.38 |    0.01 |    1738 B | 0.1297 |     - |     - |     273 B |              2 |                       2 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |   100 | 479.4 ns | 2.46 ns | 2.30 ns |  1.51 |    0.01 |    1585 B | 0.1297 |     - |     - |     273 B |              1 |                       1 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |   100 | 715.3 ns | 5.17 ns | 4.32 ns |  2.25 |    0.01 |    1077 B | 0.1068 |     - |     - |     225 B |              2 |                       2 |
|       Hyperlinq_Pool |      .NET 4.8 |      .NET 4.8 |   100 | 831.9 ns | 2.69 ns | 2.39 ns |  2.62 |    0.01 |    1668 B | 0.0267 |     - |     - |      56 B |              1 |                       2 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |   100 | 266.3 ns | 1.40 ns | 1.17 ns |  0.84 |    0.01 |     334 B | 0.4163 |     - |     - |     872 B |              1 |                       0 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |   100 | 283.8 ns | 2.13 ns | 1.78 ns |  0.89 |    0.01 |     334 B | 0.4168 |     - |     - |     872 B |              1 |                       0 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |   100 | 604.0 ns | 2.69 ns | 2.52 ns |  1.91 |    0.01 |    1588 B | 0.3700 |     - |     - |     776 B |              2 |                       2 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |   100 | 368.9 ns | 1.89 ns | 1.67 ns |  1.16 |    0.01 |     644 B | 0.3095 |     - |     - |     648 B |              1 |                       1 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 665.4 ns | 3.69 ns | 3.08 ns |  2.10 |    0.01 |    1425 B | 0.1297 |     - |     - |     272 B |              2 |                       2 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |   100 | 439.7 ns | 2.15 ns | 1.80 ns |  1.39 |    0.01 |    1285 B | 0.1297 |     - |     - |     272 B |              2 |                       2 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 663.4 ns | 4.38 ns | 4.10 ns |  2.09 |    0.02 |     815 B | 0.1059 |     - |     - |     224 B |              2 |                       2 |
|       Hyperlinq_Pool | .NET Core 3.1 | .NET Core 3.1 |   100 | 699.5 ns | 2.46 ns | 2.18 ns |  2.21 |    0.01 |    1116 B | 0.0267 |     - |     - |      56 B |              1 |                       2 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |   100 | 241.0 ns | 0.94 ns | 0.83 ns |  0.76 |    0.00 |     312 B | 0.4168 |     - |     - |     872 B |              1 |                       0 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |   100 | 240.1 ns | 2.69 ns | 2.52 ns |  0.76 |    0.01 |     312 B | 0.4168 |     - |     - |     872 B |              2 |                       0 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |   100 | 568.5 ns | 2.64 ns | 2.34 ns |  1.79 |    0.01 |    1557 B | 0.3710 |     - |     - |     776 B |              2 |                       2 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |   100 | 341.8 ns | 1.98 ns | 1.86 ns |  1.08 |    0.01 |     623 B | 0.3095 |     - |     - |     648 B |              1 |                       1 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 614.2 ns | 2.05 ns | 1.82 ns |  1.94 |    0.01 |    1493 B | 0.1297 |     - |     - |     272 B |              2 |                       2 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |   100 | 354.0 ns | 2.26 ns | 1.88 ns |  1.12 |    0.01 |    1323 B | 0.1297 |     - |     - |     272 B |              1 |                       1 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 664.3 ns | 3.78 ns | 3.54 ns |  2.10 |    0.02 |     774 B | 0.1068 |     - |     - |     224 B |              2 |                       3 |
|       Hyperlinq_Pool | .NET Core 5.0 | .NET Core 5.0 |   100 | 628.6 ns | 2.33 ns | 2.07 ns |  1.98 |    0.01 |    1074 B | 0.0267 |     - |     - |      56 B |              1 |                       2 |
