## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|      Method |           Job |       Runtime | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|------------ |-------------- |-------------- |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|----------:|---------------:|------------------------:|
|     ForLoop |      .NET 4.8 |      .NET 4.8 | 1000 |   100 |   493.4 ns |  2.24 ns |  2.10 ns |  1.00 |    0.00 |      - |     - |     - |         - |     352 B |              0 |                       0 |
| ForeachLoop |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 2,470.0 ns | 10.43 ns |  8.71 ns |  5.01 |    0.03 | 0.0153 |     - |     - |      32 B |     514 B |              1 |                       1 |
|        Linq |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 6,310.6 ns | 25.39 ns | 22.51 ns | 12.79 |    0.05 | 0.1450 |     - |     - |     313 B |    1291 B |              4 |                       3 |
|  LinqFaster |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 1,371.9 ns |  6.42 ns |  5.69 ns |  2.78 |    0.02 | 6.7329 |     - |     - |   14143 B |    1243 B |              4 |                       1 |
|  StructLinq |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 5,841.3 ns | 23.96 ns | 20.01 ns | 11.84 |    0.06 | 0.1068 |     - |     - |     225 B |    1142 B |              3 |                       3 |
|   Hyperlinq |      .NET 4.8 |      .NET 4.8 | 1000 |   100 |   754.4 ns |  2.48 ns |  2.32 ns |  1.53 |    0.01 |      - |     - |     - |         - |    1665 B |              0 |                       1 |
|     ForLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 |   479.4 ns |  1.75 ns |  1.63 ns |  0.97 |    0.01 |      - |     - |     - |         - |     340 B |              0 |                       0 |
| ForeachLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 2,666.9 ns | 14.43 ns | 13.50 ns |  5.41 |    0.03 | 0.0153 |     - |     - |      32 B |     524 B |              1 |                       2 |
|        Linq | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 2,049.0 ns |  8.21 ns |  7.28 ns |  4.15 |    0.03 | 0.1183 |     - |     - |     248 B |    1366 B |              3 |                       1 |
|  LinqFaster | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 1,401.1 ns | 26.37 ns | 23.38 ns |  2.84 |    0.04 | 6.7329 |     - |     - |   14096 B |    1164 B |              6 |                       2 |
|  StructLinq | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 1,620.5 ns |  6.47 ns |  5.40 ns |  3.29 |    0.02 | 0.0763 |     - |     - |     160 B |    1160 B |              2 |                       1 |
|   Hyperlinq | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 |   711.8 ns |  2.35 ns |  2.20 ns |  1.44 |    0.01 |      - |     - |     - |         - |    1047 B |              0 |                       1 |
|     ForLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 |   473.6 ns |  1.60 ns |  1.42 ns |  0.96 |    0.00 |      - |     - |     - |         - |     339 B |              0 |                       0 |
| ForeachLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 2,691.7 ns | 15.17 ns | 13.45 ns |  5.46 |    0.03 | 0.0153 |     - |     - |      32 B |     537 B |              1 |                       2 |
|        Linq | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 1,644.7 ns |  5.07 ns |  4.50 ns |  3.33 |    0.01 | 0.1183 |     - |     - |     248 B |    1326 B |              2 |                       1 |
|  LinqFaster | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 1,402.9 ns | 14.62 ns | 12.96 ns |  2.84 |    0.03 | 6.7329 |     - |     - |   14096 B |    1147 B |              6 |                       1 |
|  StructLinq | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 1,525.0 ns |  5.18 ns |  4.04 ns |  3.09 |    0.01 | 0.0763 |     - |     - |     160 B |    1127 B |              2 |                       1 |
|   Hyperlinq | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 |   706.4 ns |  3.06 ns |  2.55 ns |  1.43 |    0.01 |      - |     - |     - |         - |    1063 B |              0 |                       0 |
