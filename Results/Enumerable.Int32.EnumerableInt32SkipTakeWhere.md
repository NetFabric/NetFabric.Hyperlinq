## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

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
|               Method |           Job |       Runtime | Skip | Count |     Mean |     Error |    StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |-------------- |-------------- |----- |------ |---------:|----------:|----------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 3.126 μs | 0.0087 μs | 0.0068 μs |  1.00 |    0.00 |     217 B | 0.0191 |     - |     - |      40 B |              1 |                       1 |
|                 Linq |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 5.254 μs | 0.0195 μs | 0.0183 μs |  1.68 |    0.01 |    1066 B | 0.1068 |     - |     - |     225 B |              3 |                       3 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 4.728 μs | 0.0200 μs | 0.0177 μs |  1.51 |    0.01 |     757 B | 0.0763 |     - |     - |     169 B |              3 |                       3 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 4.736 μs | 0.0241 μs | 0.0225 μs |  1.51 |    0.01 |     738 B | 0.0763 |     - |     - |     169 B |              3 |                       3 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 5.263 μs | 0.0259 μs | 0.0230 μs |  1.68 |    0.01 |    1066 B | 0.1068 |     - |     - |     225 B |              3 |                       3 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 3.446 μs | 0.0318 μs | 0.0265 μs |  1.10 |    0.01 |     228 B | 0.0191 |     - |     - |      40 B |              1 |                       1 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 4.189 μs | 0.0283 μs | 0.0265 μs |  1.34 |    0.01 |    1139 B | 0.0992 |     - |     - |     208 B |              3 |                       3 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 3.528 μs | 0.0101 μs | 0.0089 μs |  1.13 |    0.00 |     773 B | 0.0725 |     - |     - |     152 B |              2 |                       2 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 3.695 μs | 0.0116 μs | 0.0109 μs |  1.18 |    0.00 |     778 B | 0.0725 |     - |     - |     152 B |              3 |                       3 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 4.114 μs | 0.0191 μs | 0.0179 μs |  1.32 |    0.01 |    1139 B | 0.0992 |     - |     - |     208 B |              3 |                       3 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 3.161 μs | 0.0104 μs | 0.0087 μs |  1.01 |    0.00 |     218 B | 0.0191 |     - |     - |      40 B |              1 |                       2 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 3.753 μs | 0.0127 μs | 0.0119 μs |  1.20 |    0.00 |    1106 B | 0.0992 |     - |     - |     208 B |              2 |                       2 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 3.517 μs | 0.0677 μs | 0.0633 μs |  1.13 |    0.02 |     730 B | 0.0725 |     - |     - |     152 B |              2 |                       2 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 4.199 μs | 0.0262 μs | 0.0245 μs |  1.34 |    0.01 |     717 B | 0.0687 |     - |     - |     152 B |              2 |                       3 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 3.763 μs | 0.0316 μs | 0.0295 μs |  1.20 |    0.01 |    1106 B | 0.0992 |     - |     - |     208 B |              2 |                       2 |
