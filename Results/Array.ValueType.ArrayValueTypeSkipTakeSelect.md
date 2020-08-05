## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|           ForLoop |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 1.555 μs | 0.0072 μs | 0.0068 μs |  1.00 |    0.00 |      - |     - |     - |         - |     427 B |              0 |                       0 |
|       ForeachLoop |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 3.897 μs | 0.0165 μs | 0.0154 μs |  2.51 |    0.01 | 0.0153 |     - |     - |      32 B |     639 B |              1 |                       2 |
|              Linq |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 7.443 μs | 0.0276 μs | 0.0258 μs |  4.79 |    0.03 | 0.1526 |     - |     - |     321 B |    1415 B |              5 |                       3 |
|        LinqFaster |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 2.532 μs | 0.0164 μs | 0.0154 μs |  1.63 |    0.01 | 5.7678 |     - |     - |   12122 B |    1233 B |             13 |                       2 |
|        StructLinq |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 6.448 μs | 0.0314 μs | 0.0262 μs |  4.15 |    0.03 | 0.1068 |     - |     - |     225 B |    1159 B |              4 |                       3 |
| Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 1.954 μs | 0.0086 μs | 0.0080 μs |  1.26 |    0.01 |      - |     - |     - |         - |    1639 B |              0 |                       1 |
|     Hyperlinq_For |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 1.974 μs | 0.0092 μs | 0.0086 μs |  1.27 |    0.01 |      - |     - |     - |         - |    1478 B |              0 |                       1 |
|           ForLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 1.535 μs | 0.0053 μs | 0.0050 μs |  0.99 |    0.01 |      - |     - |     - |         - |     408 B |              0 |                       1 |
|       ForeachLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 3.870 μs | 0.0157 μs | 0.0131 μs |  2.49 |    0.01 | 0.0153 |     - |     - |      32 B |     642 B |              2 |                       2 |
|              Linq | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 2.645 μs | 0.0113 μs | 0.0106 μs |  1.70 |    0.01 | 0.1183 |     - |     - |     248 B |    1663 B |              3 |                       1 |
|        LinqFaster | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 2.514 μs | 0.0181 μs | 0.0161 μs |  1.62 |    0.01 | 5.7678 |     - |     - |   12072 B |    1159 B |             11 |                       2 |
|        StructLinq | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 2.691 μs | 0.0084 μs | 0.0070 μs |  1.73 |    0.01 | 0.0763 |     - |     - |     160 B |    1179 B |              2 |                       1 |
| Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 1.890 μs | 0.0049 μs | 0.0043 μs |  1.22 |    0.01 |      - |     - |     - |         - |    1027 B |              0 |                       1 |
|     Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 1.965 μs | 0.0069 μs | 0.0064 μs |  1.26 |    0.01 |      - |     - |     - |         - |     986 B |              1 |                       1 |
|           ForLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 1.571 μs | 0.0058 μs | 0.0054 μs |  1.01 |    0.01 |      - |     - |     - |         - |     411 B |              0 |                       0 |
|       ForeachLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 4.100 μs | 0.0139 μs | 0.0130 μs |  2.64 |    0.02 | 0.0153 |     - |     - |      32 B |     658 B |              1 |                       2 |
|              Linq | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 2.574 μs | 0.0143 μs | 0.0134 μs |  1.66 |    0.01 | 0.1183 |     - |     - |     248 B |    1622 B |              3 |                       1 |
|        LinqFaster | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 2.506 μs | 0.0223 μs | 0.0209 μs |  1.61 |    0.02 | 5.7678 |     - |     - |   12072 B |    1144 B |             12 |                       2 |
|        StructLinq | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 2.548 μs | 0.0114 μs | 0.0107 μs |  1.64 |    0.01 | 0.0763 |     - |     - |     160 B |    1155 B |              2 |                       1 |
| Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 1.880 μs | 0.0039 μs | 0.0031 μs |  1.21 |    0.00 |      - |     - |     - |         - |    1045 B |              0 |                       1 |
|     Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 1.883 μs | 0.0082 μs | 0.0077 μs |  1.21 |    0.01 |      - |     - |     - |         - |     997 B |              0 |                       1 |
