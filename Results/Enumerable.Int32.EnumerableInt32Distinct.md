## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

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
|      Method | Count |     Mean |     Error |    StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------ |------ |---------:|----------:|----------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
| ForeachLoop |   100 | 1.942 μs | 0.0338 μs | 0.0300 μs |  1.00 |    0.00 |    1414 B | 2.8877 |     - |     - |    6048 B |             11 |                       5 |
|        Linq |   100 | 2.724 μs | 0.0244 μs | 0.0204 μs |  1.40 |    0.03 |     375 B | 2.0638 |     - |     - |    4320 B |             12 |                       5 |
|  StructLinq |   100 | 2.543 μs | 0.0488 μs | 0.0480 μs |  1.31 |    0.03 |    1857 B | 0.0191 |     - |     - |      40 B |              1 |                       4 |
|   Hyperlinq |   100 | 2.309 μs | 0.0394 μs | 0.0349 μs |  1.19 |    0.02 |    1321 B | 0.0191 |     - |     - |      40 B |              1 |                       3 |
