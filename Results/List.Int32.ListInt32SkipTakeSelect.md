## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

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
|            Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------------ |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|           ForLoop | 1000 |   100 |    66.00 ns |  0.494 ns |  0.438 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|       ForeachLoop | 1000 |   100 | 3,742.58 ns | 23.435 ns | 21.921 ns | 56.74 |    0.32 | 0.0191 |     - |     - |      40 B |              1 |                       2 |
|              Linq | 1000 |   100 |   958.04 ns |  3.682 ns |  3.264 ns | 14.52 |    0.12 | 0.0725 |     - |     - |     152 B |              1 |                       1 |
| Hyperlinq_Foreach | 1000 |   100 |   288.35 ns |  2.014 ns |  1.884 ns |  4.37 |    0.04 |      - |     - |     - |         - |              0 |                       0 |
|     Hyperlinq_For | 1000 |   100 |   440.59 ns |  2.400 ns |  2.128 ns |  6.68 |    0.05 |      - |     - |     - |         - |              0 |                       0 |
