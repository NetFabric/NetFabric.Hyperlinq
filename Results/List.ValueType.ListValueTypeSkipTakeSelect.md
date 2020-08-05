## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

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
|            Method |           Job |       Runtime | Skip | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|------------------ |-------------- |-------------- |----- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|----------:|---------------:|------------------------:|
|           ForLoop |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 1.614 μs | 0.0054 μs | 0.0051 μs |  1.00 |    0.00 |      - |     - |     - |         - |     583 B |              0 |                       0 |
|       ForeachLoop |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 5.541 μs | 0.0169 μs | 0.0132 μs |  3.43 |    0.02 | 0.0305 |     - |     - |      72 B |     639 B |              2 |                       2 |
|              Linq |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 9.415 μs | 0.0397 μs | 0.0371 μs |  5.83 |    0.03 | 0.1678 |     - |     - |     361 B |    1415 B |              6 |                       4 |
|        LinqFaster |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 3.663 μs | 0.0452 μs | 0.0423 μs |  2.27 |    0.03 | 5.8250 |     - |     - |   12240 B |    2064 B |             13 |                       4 |
|        StructLinq |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 8.389 μs | 0.0261 μs | 0.0232 μs |  5.20 |    0.02 | 0.1221 |     - |     - |     265 B |    1159 B |              6 |                       4 |
| Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 1.991 μs | 0.0079 μs | 0.0070 μs |  1.23 |    0.01 |      - |     - |     - |         - |    1739 B |              0 |                       1 |
|     Hyperlinq_For |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 2.014 μs | 0.0086 μs | 0.0080 μs |  1.25 |    0.01 |      - |     - |     - |         - |    1566 B |              0 |                       1 |
|           ForLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 1.639 μs | 0.0047 μs | 0.0044 μs |  1.02 |    0.00 |      - |     - |     - |         - |     475 B |              0 |                       0 |
|       ForeachLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 5.769 μs | 0.0371 μs | 0.0347 μs |  3.57 |    0.02 | 0.0305 |     - |     - |      72 B |     642 B |              3 |                       2 |
|              Linq | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 2.591 μs | 0.0133 μs | 0.0124 μs |  1.61 |    0.01 | 0.1183 |     - |     - |     248 B |    1663 B |              3 |                       1 |
|        LinqFaster | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 3.630 μs | 0.0493 μs | 0.0437 μs |  2.25 |    0.03 | 5.8136 |     - |     - |   12168 B |    1985 B |             13 |                       4 |
|        StructLinq | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 2.594 μs | 0.0115 μs | 0.0107 μs |  1.61 |    0.01 | 0.0763 |     - |     - |     160 B |    1179 B |              2 |                       2 |
| Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 1.889 μs | 0.0048 μs | 0.0040 μs |  1.17 |    0.00 |      - |     - |     - |         - |    1072 B |              1 |                       1 |
|     Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 1.967 μs | 0.0060 μs | 0.0056 μs |  1.22 |    0.00 |      - |     - |     - |         - |    1031 B |              1 |                       1 |
|           ForLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 1.627 μs | 0.0102 μs | 0.0095 μs |  1.01 |    0.01 |      - |     - |     - |         - |     494 B |              0 |                       0 |
|       ForeachLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 5.722 μs | 0.0273 μs | 0.0228 μs |  3.55 |    0.02 | 0.0305 |     - |     - |      72 B |     658 B |              3 |                       2 |
|              Linq | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 2.537 μs | 0.0087 μs | 0.0081 μs |  1.57 |    0.01 | 0.1183 |     - |     - |     248 B |    1622 B |              3 |                       1 |
|        LinqFaster | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 3.629 μs | 0.0353 μs | 0.0330 μs |  2.25 |    0.02 | 5.8136 |     - |     - |   12168 B |    1998 B |             14 |                       4 |
|        StructLinq | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 2.485 μs | 0.0085 μs | 0.0079 μs |  1.54 |    0.01 | 0.0763 |     - |     - |     160 B |    1155 B |              2 |                       1 |
| Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 1.880 μs | 0.0069 μs | 0.0064 μs |  1.16 |    0.00 |      - |     - |     - |         - |    1086 B |              0 |                       1 |
|     Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 2.595 μs | 0.0101 μs | 0.0094 μs |  1.61 |    0.01 |      - |     - |     - |         - |    1038 B |              1 |                       1 |
