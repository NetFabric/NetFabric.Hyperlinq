## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

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
|     ForLoop | 1000 |   100 |   484.9 ns |  4.62 ns |  4.32 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
| ForeachLoop | 1000 |   100 | 4,160.0 ns | 33.75 ns | 31.57 ns |  8.58 |    0.12 | 0.0305 |     - |     - |      72 B |              2 |                       2 |
|        Linq | 1000 |   100 | 1,563.6 ns |  7.20 ns |  6.38 ns |  3.23 |    0.04 | 0.1183 |     - |     - |     248 B |              2 |                       1 |
|   Hyperlinq | 1000 |   100 |   737.9 ns |  5.13 ns |  4.80 ns |  1.52 |    0.02 |      - |     - |     - |         - |              0 |                       1 |
