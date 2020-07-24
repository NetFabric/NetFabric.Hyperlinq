## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

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
|            Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------------ |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|           ForLoop | 1000 |   100 |    72.74 ns |  0.311 ns |  0.276 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|       ForeachLoop | 1000 |   100 | 3,601.35 ns | 26.476 ns | 24.765 ns | 49.53 |    0.40 | 0.0191 |     - |     - |      40 B |              1 |                       2 |
|              Linq | 1000 |   100 |   942.97 ns |  2.931 ns |  2.448 ns | 12.97 |    0.04 | 0.0725 |     - |     - |     152 B |              2 |                       1 |
| Hyperlinq_Foreach | 1000 |   100 |   290.77 ns |  1.892 ns |  1.677 ns |  4.00 |    0.03 |      - |     - |     - |         - |              0 |                       0 |
|     Hyperlinq_For | 1000 |   100 |   478.12 ns |  3.622 ns |  3.388 ns |  6.57 |    0.05 |      - |     - |     - |         - |              0 |                       0 |
