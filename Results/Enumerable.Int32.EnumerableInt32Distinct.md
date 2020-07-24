## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|      Method | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------ |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
| ForeachLoop |   100 | 1.814 μs | 0.0204 μs | 0.0190 μs |  1.00 |    0.00 | 2.8896 |     - |     - |    6048 B |              7 |                       4 |
|        Linq |   100 | 2.641 μs | 0.0122 μs | 0.0102 μs |  1.46 |    0.02 | 2.0638 |     - |     - |    4320 B |             11 |                       5 |
|  StructLinq |   100 | 2.494 μs | 0.0157 μs | 0.0147 μs |  1.38 |    0.01 | 0.0191 |     - |     - |      40 B |              1 |                       4 |
|   Hyperlinq |   100 | 2.246 μs | 0.0129 μs | 0.0107 μs |  1.24 |    0.02 | 0.0191 |     - |     - |      40 B |              1 |                       3 |
