## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 |   982.8 ns |  6.77 ns |  5.29 ns |  1.00 |    0.00 |   0.63 KB | 2.4433 |     - |     - |   4.99 KB |              6 |                       1 |
|          ForeachLoop |   100 | 1,224.0 ns | 10.43 ns |  9.75 ns |  1.24 |    0.01 |   0.92 KB | 2.4433 |     - |     - |   4.99 KB |              8 |                       3 |
|                 Linq |   100 | 1,433.9 ns | 18.85 ns | 16.71 ns |  1.46 |    0.02 |    1.7 KB | 2.5768 |     - |     - |   5.27 KB |              8 |                       3 |
|           LinqFaster |   100 | 1,569.5 ns | 25.49 ns | 22.60 ns |  1.60 |    0.02 |   1.81 KB | 3.4237 |     - |     - |      7 KB |              9 |                       3 |
|           StructLinq |   100 | 1,367.6 ns | 19.81 ns | 18.53 ns |  1.39 |    0.02 |   2.42 KB | 1.0052 |     - |     - |   2.05 KB |              7 |                       3 |
| StructLinq_IFunction |   100 |   900.1 ns |  9.02 ns |  8.44 ns |  0.92 |    0.01 |   2.04 KB | 1.0052 |     - |     - |   2.05 KB |              5 |                       3 |
|            Hyperlinq |   100 | 1,249.2 ns | 16.47 ns | 12.86 ns |  1.27 |    0.01 |   2.37 KB | 1.0166 |     - |     - |   2.08 KB |              5 |                       3 |
