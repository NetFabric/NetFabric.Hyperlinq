## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta21](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta21)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |     Mean |     Error |    StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |----- |------ |---------:|----------:|----------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|          ForeachLoop | 1000 |   100 | 3.019 μs | 0.0266 μs | 0.0235 μs |  1.00 |    0.00 |     218 B | 0.0191 |     - |     - |      40 B |              2 |                       2 |
|                 Linq | 1000 |   100 | 4.193 μs | 0.0294 μs | 0.0245 μs |  1.39 |    0.01 |    1674 B | 0.0992 |     - |     - |     208 B |              4 |                       4 |
|           StructLinq | 1000 |   100 | 3.898 μs | 0.0299 μs | 0.0280 μs |  1.29 |    0.02 |    1256 B | 0.0687 |     - |     - |     152 B |              3 |                       3 |
| StructLinq_IFunction | 1000 |   100 | 3.758 μs | 0.0222 μs | 0.0197 μs |  1.24 |    0.01 |    1243 B | 0.0725 |     - |     - |     152 B |              3 |                       3 |
|            Hyperlinq | 1000 |   100 | 4.224 μs | 0.0196 μs | 0.0164 μs |  1.40 |    0.01 |    1674 B | 0.0992 |     - |     - |     208 B |              4 |                       4 |
