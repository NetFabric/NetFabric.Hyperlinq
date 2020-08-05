## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

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
|      Method |           Job |       Runtime | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|------------ |-------------- |-------------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|----------:|---------------:|------------------------:|
| ForeachLoop |      .NET 4.8 |      .NET 4.8 |   100 | 2.594 μs | 0.0159 μs | 0.0141 μs |  1.00 | 2.8839 |     - |     - |    6059 B |     841 B |              9 |                       4 |
|        Linq |      .NET 4.8 |      .NET 4.8 |   100 | 2.712 μs | 0.0138 μs | 0.0122 μs |  1.05 | 2.0714 |     - |     - |    4349 B |     283 B |              9 |                       4 |
|  StructLinq |      .NET 4.8 |      .NET 4.8 |   100 | 3.438 μs | 0.0149 μs | 0.0132 μs |  1.33 | 0.0191 |     - |     - |      40 B |    1748 B |              1 |                       7 |
|   Hyperlinq |      .NET 4.8 |      .NET 4.8 |   100 | 3.408 μs | 0.0149 μs | 0.0139 μs |  1.31 | 0.0191 |     - |     - |      40 B |     602 B |              1 |                       5 |
| ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |   100 | 2.289 μs | 0.0146 μs | 0.0137 μs |  0.88 | 2.8839 |     - |     - |    6040 B |     805 B |             11 |                       6 |
|        Linq | .NET Core 3.1 | .NET Core 3.1 |   100 | 2.653 μs | 0.0124 μs | 0.0096 μs |  1.02 | 2.0638 |     - |     - |    4320 B |     345 B |              9 |                       4 |
|  StructLinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 2.815 μs | 0.0202 μs | 0.0169 μs |  1.08 | 0.0191 |     - |     - |      40 B |    1535 B |              1 |                       5 |
|   Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 2.368 μs | 0.0090 μs | 0.0076 μs |  0.91 | 0.0191 |     - |     - |      40 B |     574 B |              1 |                       3 |
| ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |   100 | 1.744 μs | 0.0110 μs | 0.0097 μs |  0.67 | 2.8896 |     - |     - |    6048 B |    1004 B |              8 |                       4 |
|        Linq | .NET Core 5.0 | .NET Core 5.0 |   100 | 2.624 μs | 0.0090 μs | 0.0080 μs |  1.01 | 2.0638 |     - |     - |    4320 B |     333 B |              8 |                       5 |
|  StructLinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 2.655 μs | 0.0150 μs | 0.0133 μs |  1.02 | 0.0191 |     - |     - |      40 B |    1513 B |              1 |                       4 |
|   Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 2.227 μs | 0.0079 μs | 0.0070 μs |  0.86 | 0.0191 |     - |     - |      40 B |     571 B |              1 |                       2 |
