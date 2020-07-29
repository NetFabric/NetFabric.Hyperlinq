## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

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
|              ForLoop |   100 | 1,172.4 ns | 11.81 ns | 11.04 ns |  1.00 |    0.00 |     959 B | 3.4103 |     - |     - |    7136 B |              7 |                       2 |
|          ForeachLoop |   100 | 1,401.4 ns | 11.55 ns | 10.81 ns |  1.20 |    0.02 |    1259 B | 3.4103 |     - |     - |    7136 B |              8 |                       3 |
|                 Linq |   100 | 1,459.4 ns | 15.91 ns | 14.88 ns |  1.24 |    0.02 |    1713 B | 2.4853 |     - |     - |    5200 B |              9 |                       3 |
|           LinqFaster |   100 | 1,578.0 ns | 13.47 ns | 11.94 ns |  1.35 |    0.02 |    1549 B | 3.4103 |     - |     - |    7136 B |              9 |                       3 |
|           StructLinq |   100 | 1,376.3 ns | 16.73 ns | 14.83 ns |  1.17 |    0.01 |    2419 B | 0.9899 |     - |     - |    2072 B |              7 |                       3 |
| StructLinq_IFunction |   100 |   905.6 ns | 10.27 ns |  9.10 ns |  0.77 |    0.01 |    2031 B | 0.9899 |     - |     - |    2072 B |              5 |                       3 |
|            Hyperlinq |   100 | 1,214.4 ns | 21.18 ns | 17.69 ns |  1.04 |    0.02 |    1737 B | 0.9670 |     - |     - |    2024 B |              7 |                       3 |
|       Hyperlinq_Pool |   100 | 1,130.1 ns |  4.41 ns |  3.68 ns |  0.96 |    0.01 |    2455 B | 0.0267 |     - |     - |      56 B |              1 |                       2 |
