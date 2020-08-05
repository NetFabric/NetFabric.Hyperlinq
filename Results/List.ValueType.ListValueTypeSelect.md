## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

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
|               Method |           Job |       Runtime | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |-------------- |-------------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|----------:|---------------:|------------------------:|
|              ForLoop |      .NET 4.8 |      .NET 4.8 |   100 | 1.694 μs | 0.0064 μs | 0.0057 μs |  1.00 |      - |     - |     - |         - |     571 B |              0 |                       0 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |   100 | 1.876 μs | 0.0104 μs | 0.0092 μs |  1.11 |      - |     - |     - |         - |     743 B |              0 |                       0 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |   100 | 3.052 μs | 0.0140 μs | 0.0131 μs |  1.80 | 0.0687 |     - |     - |     144 B |    1216 B |              2 |                       1 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |   100 | 2.411 μs | 0.0200 μs | 0.0187 μs |  1.42 | 1.9417 |     - |     - |    4080 B |    1231 B |              8 |                       2 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |   100 | 1.947 μs | 0.0099 μs | 0.0093 μs |  1.15 |      - |     - |     - |         - |    1079 B |              0 |                       1 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |   100 | 1.582 μs | 0.0047 μs | 0.0044 μs |  0.93 |      - |     - |     - |         - |     962 B |              0 |                       0 |
|    Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 |   100 | 1.973 μs | 0.0083 μs | 0.0078 μs |  1.16 |      - |     - |     - |         - |    1454 B |              0 |                       1 |
|        Hyperlinq_For |      .NET 4.8 |      .NET 4.8 |   100 | 1.966 μs | 0.0067 μs | 0.0060 μs |  1.16 |      - |     - |     - |         - |    1308 B |              1 |                       1 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |   100 | 1.693 μs | 0.0064 μs | 0.0059 μs |  1.00 |      - |     - |     - |         - |     488 B |              0 |                       1 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |   100 | 1.850 μs | 0.0059 μs | 0.0056 μs |  1.09 |      - |     - |     - |         - |     703 B |              0 |                       1 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |   100 | 3.150 μs | 0.0126 μs | 0.0112 μs |  1.86 | 0.0648 |     - |     - |     136 B |    1384 B |              2 |                       1 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |   100 | 2.386 μs | 0.0162 μs | 0.0152 μs |  1.41 | 1.9379 |     - |     - |    4056 B |    1087 B |              8 |                       2 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1.945 μs | 0.0055 μs | 0.0048 μs |  1.15 |      - |     - |     - |         - |     989 B |              1 |                       1 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |   100 | 1.585 μs | 0.0052 μs | 0.0049 μs |  0.94 |      - |     - |     - |         - |     890 B |              0 |                       0 |
|    Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 |   100 | 1.942 μs | 0.0075 μs | 0.0071 μs |  1.15 |      - |     - |     - |         - |     869 B |              1 |                       1 |
|        Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 |   100 | 1.928 μs | 0.0072 μs | 0.0064 μs |  1.14 |      - |     - |     - |         - |     834 B |              1 |                       1 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |   100 | 1.663 μs | 0.0051 μs | 0.0045 μs |  0.98 |      - |     - |     - |         - |     506 B |              0 |                       0 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |   100 | 1.814 μs | 0.0044 μs | 0.0039 μs |  1.07 |      - |     - |     - |         - |     722 B |              0 |                       1 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |   100 | 2.497 μs | 0.0095 μs | 0.0084 μs |  1.47 | 0.0648 |     - |     - |     136 B |    1361 B |              2 |                       1 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |   100 | 2.368 μs | 0.0130 μs | 0.0122 μs |  1.40 | 1.9379 |     - |     - |    4056 B |    1104 B |              8 |                       2 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 2.591 μs | 0.0069 μs | 0.0065 μs |  1.53 |      - |     - |     - |         - |     964 B |              0 |                       1 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |   100 | 1.581 μs | 0.0045 μs | 0.0040 μs |  0.93 |      - |     - |     - |         - |     838 B |              0 |                       0 |
|    Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 |   100 | 1.873 μs | 0.0046 μs | 0.0041 μs |  1.11 |      - |     - |     - |         - |     883 B |              0 |                       1 |
|        Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 |   100 | 1.867 μs | 0.0092 μs | 0.0086 μs |  1.10 |      - |     - |     - |         - |     849 B |              0 |                       1 |
