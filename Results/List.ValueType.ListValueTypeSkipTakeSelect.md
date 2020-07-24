## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

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
|            Method | Skip | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------------ |----- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|           ForLoop | 1000 |   100 | 1.646 μs | 0.0062 μs | 0.0058 μs |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|       ForeachLoop | 1000 |   100 | 5.768 μs | 0.0374 μs | 0.0350 μs |  3.50 |    0.02 | 0.0305 |     - |     - |      72 B |              3 |                       3 |
|              Linq | 1000 |   100 | 2.514 μs | 0.0091 μs | 0.0081 μs |  1.53 |    0.01 | 0.1183 |     - |     - |     248 B |              3 |                       1 |
| Hyperlinq_Foreach | 1000 |   100 | 1.928 μs | 0.0058 μs | 0.0052 μs |  1.17 |    0.00 |      - |     - |     - |         - |              0 |                       1 |
|     Hyperlinq_For | 1000 |   100 | 2.073 μs | 0.0089 μs | 0.0079 μs |  1.26 |    0.01 |      - |     - |     - |         - |              0 |                       1 |
