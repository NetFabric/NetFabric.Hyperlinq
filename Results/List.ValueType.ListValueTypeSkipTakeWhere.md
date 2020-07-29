## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

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
|      Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------ |----- |------ |-----------:|---------:|---------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|     ForLoop | 1000 |   100 |   491.3 ns |  5.77 ns |  5.40 ns |  1.00 |    0.00 |     344 B |      - |     - |     - |         - |              0 |                       0 |
| ForeachLoop | 1000 |   100 | 4,148.7 ns | 27.97 ns | 24.80 ns |  8.45 |    0.11 |     537 B | 0.0305 |     - |     - |      72 B |              2 |                       2 |
|        Linq | 1000 |   100 | 1,612.9 ns | 29.43 ns | 26.09 ns |  3.29 |    0.06 |    1894 B | 0.1183 |     - |     - |     248 B |              3 |                       2 |
|  LinqFaster | 1000 |   100 | 2,604.9 ns | 43.49 ns | 40.68 ns |  5.30 |    0.09 |    2119 B | 6.3133 |     - |     - |   13224 B |             13 |                       4 |
|  StructLinq | 1000 |   100 | 1,498.8 ns |  5.17 ns |  4.58 ns |  3.05 |    0.03 |    1653 B | 0.0763 |     - |     - |     160 B |              2 |                       1 |
|   Hyperlinq | 1000 |   100 |   725.8 ns |  4.24 ns |  3.76 ns |  1.48 |    0.01 |    1293 B |      - |     - |     - |         - |              0 |                       1 |
