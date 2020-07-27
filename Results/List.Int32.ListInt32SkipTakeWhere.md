## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

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
|      Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------ |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|     ForLoop | 1000 |   100 |   122.0 ns |  0.48 ns |  0.44 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
| ForeachLoop | 1000 |   100 | 3,551.5 ns | 34.41 ns | 32.18 ns | 29.11 |    0.30 | 0.0191 |     - |     - |      40 B |              1 |                       1 |
|        Linq | 1000 |   100 | 1,250.7 ns |  3.90 ns |  3.05 ns | 10.26 |    0.05 | 0.0725 |     - |     - |     152 B |              1 |                       1 |
|   Hyperlinq | 1000 |   100 |   343.9 ns |  1.54 ns |  1.37 ns |  2.82 |    0.02 |      - |     - |     - |         - |              0 |                       0 |
