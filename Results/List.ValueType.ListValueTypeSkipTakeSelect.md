## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

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
|            Method | Skip | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------------ |----- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|           ForLoop | 1000 |   100 | 1.649 μs | 0.0124 μs | 0.0116 μs |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|       ForeachLoop | 1000 |   100 | 5.584 μs | 0.0291 μs | 0.0272 μs |  3.39 |    0.03 | 0.0305 |     - |     - |      72 B |              2 |                       2 |
|              Linq | 1000 |   100 | 2.546 μs | 0.0126 μs | 0.0112 μs |  1.54 |    0.01 | 0.1183 |     - |     - |     248 B |              2 |                       1 |
| Hyperlinq_Foreach | 1000 |   100 | 1.896 μs | 0.0140 μs | 0.0124 μs |  1.15 |    0.01 |      - |     - |     - |         - |              0 |                       1 |
|     Hyperlinq_For | 1000 |   100 | 2.054 μs | 0.0088 μs | 0.0078 μs |  1.25 |    0.01 |      - |     - |     - |         - |              0 |                       1 |
