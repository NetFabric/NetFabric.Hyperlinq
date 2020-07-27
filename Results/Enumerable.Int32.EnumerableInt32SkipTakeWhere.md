## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta20](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta20)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|      Method | Skip | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------ |----- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
| ForeachLoop | 1000 |   100 | 3.152 μs | 0.0217 μs | 0.0203 μs |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |              1 |                       2 |
|        Linq | 1000 |   100 | 4.561 μs | 0.0252 μs | 0.0236 μs |  1.45 |    0.01 | 0.0992 |     - |     - |     208 B |              3 |                       3 |
|   Hyperlinq | 1000 |   100 | 4.628 μs | 0.0453 μs | 0.0424 μs |  1.47 |    0.02 | 0.0992 |     - |     - |     208 B |              3 |                       4 |
