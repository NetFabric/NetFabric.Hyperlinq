## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

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
|              ForLoop |      .NET 4.8 |      .NET 4.8 |   100 | 1.527 μs | 0.0041 μs | 0.0039 μs |  1.00 |      - |     - |     - |         - |     417 B |              0 |                       0 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |   100 | 1.614 μs | 0.0049 μs | 0.0043 μs |  1.06 |      - |     - |     - |         - |     459 B |              0 |                       0 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |   100 | 2.888 μs | 0.0091 μs | 0.0081 μs |  1.89 | 0.0458 |     - |     - |      96 B |    1216 B |              2 |                       1 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |   100 | 2.053 μs | 0.0080 μs | 0.0075 μs |  1.34 | 1.9226 |     - |     - |    4041 B |     880 B |              6 |                       1 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |   100 | 1.890 μs | 0.0077 μs | 0.0065 μs |  1.24 |      - |     - |     - |         - |    1085 B |              0 |                       1 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |   100 | 1.588 μs | 0.0033 μs | 0.0031 μs |  1.04 |      - |     - |     - |         - |     966 B |              0 |                       0 |
|    Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 |   100 | 1.918 μs | 0.0060 μs | 0.0056 μs |  1.26 |      - |     - |     - |         - |    1179 B |              0 |                       1 |
|        Hyperlinq_For |      .NET 4.8 |      .NET 4.8 |   100 | 1.999 μs | 0.0141 μs | 0.0131 μs |  1.31 |      - |     - |     - |         - |    1027 B |              0 |                       1 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |   100 | 1.556 μs | 0.0046 μs | 0.0043 μs |  1.02 |      - |     - |     - |         - |     402 B |              0 |                       0 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |   100 | 1.641 μs | 0.0044 μs | 0.0041 μs |  1.07 |      - |     - |     - |         - |     442 B |              0 |                       1 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |   100 | 2.238 μs | 0.0085 μs | 0.0075 μs |  1.47 | 0.0381 |     - |     - |      80 B |    1384 B |              1 |                       1 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |   100 | 2.049 μs | 0.0169 μs | 0.0158 μs |  1.34 | 1.9226 |     - |     - |    4024 B |     804 B |              7 |                       2 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1.925 μs | 0.0071 μs | 0.0066 μs |  1.26 |      - |     - |     - |         - |     987 B |              1 |                       1 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |   100 | 1.618 μs | 0.0038 μs | 0.0033 μs |  1.06 |      - |     - |     - |         - |     886 B |              0 |                       1 |
|    Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 |   100 | 1.937 μs | 0.0080 μs | 0.0075 μs |  1.27 |      - |     - |     - |         - |     846 B |              1 |                       1 |
|        Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 |   100 | 1.903 μs | 0.0052 μs | 0.0043 μs |  1.25 |      - |     - |     - |         - |     811 B |              1 |                       1 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |   100 | 1.521 μs | 0.0038 μs | 0.0035 μs |  1.00 |      - |     - |     - |         - |     398 B |              0 |                       0 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |   100 | 1.613 μs | 0.0047 μs | 0.0044 μs |  1.06 |      - |     - |     - |         - |     454 B |              0 |                       0 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |   100 | 2.195 μs | 0.0095 μs | 0.0089 μs |  1.44 | 0.0381 |     - |     - |      80 B |    1361 B |              1 |                       1 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |   100 | 2.019 μs | 0.0150 μs | 0.0133 μs |  1.32 | 1.9226 |     - |     - |    4024 B |     801 B |              9 |                       2 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 1.850 μs | 0.0062 μs | 0.0058 μs |  1.21 |      - |     - |     - |         - |     960 B |              0 |                       1 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |   100 | 1.583 μs | 0.0048 μs | 0.0042 μs |  1.04 |      - |     - |     - |         - |     873 B |              0 |                       0 |
|    Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 |   100 | 1.879 μs | 0.0053 μs | 0.0050 μs |  1.23 |      - |     - |     - |         - |     868 B |              0 |                       1 |
|        Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 |   100 | 1.901 μs | 0.0082 μs | 0.0077 μs |  1.24 |      - |     - |     - |         - |     834 B |              0 |                       1 |
