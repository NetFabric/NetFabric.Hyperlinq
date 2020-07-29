## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

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
|               Method | Count |     Mean |     Error |    StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |---------:|----------:|----------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 | 1.652 μs | 0.0059 μs | 0.0049 μs |  1.00 |    0.00 |     506 B |      - |     - |     - |         - |              0 |                       1 |
|          ForeachLoop |   100 | 1.847 μs | 0.0103 μs | 0.0096 μs |  1.12 |    0.01 |     779 B |      - |     - |     - |         - |              0 |                       1 |
|                 Linq |   100 | 3.200 μs | 0.0290 μs | 0.0226 μs |  1.94 |    0.01 |    1433 B | 0.0648 |     - |     - |     136 B |              2 |                       1 |
|           LinqFaster |   100 | 2.552 μs | 0.0485 μs | 0.0430 μs |  1.54 |    0.03 |    1252 B | 1.9379 |     - |     - |    4056 B |             10 |                       3 |
|           StructLinq |   100 | 2.601 μs | 0.0151 μs | 0.0134 μs |  1.58 |    0.01 |     994 B |      - |     - |     - |         - |              0 |                       1 |
| StructLinq_IFunction |   100 | 1.604 μs | 0.0085 μs | 0.0079 μs |  0.97 |    0.01 |     838 B |      - |     - |     - |         - |              0 |                       0 |
|    Hyperlinq_Foreach |   100 | 1.924 μs | 0.0066 μs | 0.0062 μs |  1.17 |    0.00 |    1113 B |      - |     - |     - |         - |              0 |                       1 |
|        Hyperlinq_For |   100 | 2.073 μs | 0.0115 μs | 0.0102 μs |  1.25 |    0.01 |     996 B |      - |     - |     - |         - |              0 |                       1 |
