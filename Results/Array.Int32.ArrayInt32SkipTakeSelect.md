## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|           ForLoop | 1000 |   100 |    66.79 ns |  0.441 ns |  0.413 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|       ForeachLoop | 1000 |   100 | 2,368.63 ns | 12.567 ns | 10.494 ns | 35.48 |    0.34 | 0.0153 |     - |     - |      32 B |              1 |                       1 |
|              Linq | 1000 |   100 |   983.38 ns | 11.701 ns |  9.770 ns | 14.73 |    0.15 | 0.0725 |     - |     - |     152 B |              1 |                       1 |
|        LinqFaster | 1000 |   100 |   299.42 ns |  1.657 ns |  1.383 ns |  4.48 |    0.04 | 0.2027 |     - |     - |     424 B |              1 |                       1 |
| Hyperlinq_Foreach | 1000 |   100 |   229.14 ns |  1.599 ns |  1.496 ns |  3.43 |    0.04 |      - |     - |     - |         - |              0 |                       0 |
|     Hyperlinq_For | 1000 |   100 |   304.27 ns |  2.396 ns |  2.241 ns |  4.56 |    0.05 |      - |     - |     - |         - |              0 |                       0 |
