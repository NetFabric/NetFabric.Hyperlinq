## Enumerable.Int32.EnumerableInt32SkipTakeSelect

### Source
[EnumerableInt32SkipTakeSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeSelect.cs)

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
|               Method |           Job |       Runtime | Skip | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |-------------- |-------------- |----- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|----------:|---------------:|------------------------:|
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 3.096 μs | 0.0179 μs | 0.0158 μs |  1.00 | 0.0191 |     - |     - |      40 B |     214 B |              1 |                       1 |
|                 Linq |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 5.388 μs | 0.0291 μs | 0.0272 μs |  1.74 | 0.1068 |     - |     - |     233 B |    1099 B |              3 |                       3 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 4.719 μs | 0.0251 μs | 0.0235 μs |  1.52 | 0.0763 |     - |     - |     169 B |     757 B |              3 |                       3 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 4.491 μs | 0.0201 μs | 0.0157 μs |  1.45 | 0.0763 |     - |     - |     169 B |     818 B |              3 |                       2 |
|    Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 3.826 μs | 0.0282 μs | 0.0235 μs |  1.24 | 0.0153 |     - |     - |      40 B |     744 B |              1 |                       2 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 3.376 μs | 0.0120 μs | 0.0112 μs |  1.09 | 0.0191 |     - |     - |      40 B |     225 B |              1 |                       2 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 4.279 μs | 0.0196 μs | 0.0153 μs |  1.38 | 0.0992 |     - |     - |     208 B |    1352 B |              3 |                       3 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 3.817 μs | 0.0271 μs | 0.0226 μs |  1.23 | 0.0687 |     - |     - |     152 B |     773 B |              2 |                       3 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 3.674 μs | 0.0172 μs | 0.0161 μs |  1.19 | 0.0725 |     - |     - |     152 B |     852 B |              2 |                       3 |
|    Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 4.365 μs | 0.0228 μs | 0.0214 μs |  1.41 | 0.0153 |     - |     - |      40 B |     692 B |              2 |                       2 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 3.145 μs | 0.0145 μs | 0.0136 μs |  1.02 | 0.0191 |     - |     - |      40 B |     215 B |              1 |                       2 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 4.258 μs | 0.0450 μs | 0.0421 μs |  1.38 | 0.0992 |     - |     - |     208 B |    1318 B |              3 |                       3 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 3.855 μs | 0.0137 μs | 0.0121 μs |  1.24 | 0.0687 |     - |     - |     152 B |     730 B |              2 |                       2 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 3.601 μs | 0.0174 μs | 0.0163 μs |  1.16 | 0.0725 |     - |     - |     152 B |     793 B |              2 |                       3 |
|    Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 3.799 μs | 0.0144 μs | 0.0135 μs |  1.23 | 0.0153 |     - |     - |      40 B |     666 B |              2 |                       3 |
