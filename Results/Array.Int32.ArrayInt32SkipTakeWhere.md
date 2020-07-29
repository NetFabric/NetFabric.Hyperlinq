## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
|               Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop | 1000 |   100 |    80.38 ns |  0.454 ns |  0.424 ns |  1.00 |    0.00 |      69 B |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop | 1000 |   100 | 2,392.49 ns | 22.329 ns | 20.886 ns | 29.76 |    0.29 |     218 B | 0.0153 |     - |     - |      32 B |              1 |                       3 |
|                 Linq | 1000 |   100 | 1,369.70 ns |  8.687 ns |  7.701 ns | 17.04 |    0.14 |    1674 B | 0.0725 |     - |     - |     152 B |              2 |                       2 |
|           LinqFaster | 1000 |   100 |   389.87 ns |  2.669 ns |  2.366 ns |  4.85 |    0.03 |    1206 B | 0.7153 |     - |     - |    1496 B |              3 |                       1 |
|           StructLinq | 1000 |   100 | 1,160.07 ns | 12.567 ns | 10.494 ns | 14.42 |    0.17 |    1288 B | 0.0458 |     - |     - |      96 B |              1 |                       1 |
| StructLinq_IFunction | 1000 |   100 |   996.16 ns |  3.736 ns |  3.119 ns | 12.38 |    0.06 |    1243 B | 0.0458 |     - |     - |      96 B |              1 |                       1 |
|            Hyperlinq | 1000 |   100 |   353.77 ns |  2.793 ns |  2.180 ns |  4.40 |    0.03 |     694 B |      - |     - |     - |         - |              0 |                       1 |
