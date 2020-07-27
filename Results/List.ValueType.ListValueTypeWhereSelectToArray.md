## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 | 1,010.5 ns |  7.11 ns |  6.30 ns |  1.00 |    0.00 | 3.4103 |     - |     - |    7136 B |              4 |                       1 |
|          ForeachLoop |   100 | 1,237.0 ns | 10.95 ns |  9.71 ns |  1.22 |    0.01 | 3.4103 |     - |     - |    7136 B |              5 |                       2 |
|                 Linq |   100 | 1,352.8 ns | 12.51 ns | 11.70 ns |  1.34 |    0.01 | 2.4853 |     - |     - |    5200 B |              6 |                       3 |
|           LinqFaster |   100 | 1,370.4 ns | 23.60 ns | 22.07 ns |  1.35 |    0.02 | 3.4103 |     - |     - |    7136 B |              5 |                       3 |
|           StructLinq |   100 | 1,354.2 ns | 20.42 ns | 18.10 ns |  1.34 |    0.02 | 0.9899 |     - |     - |    2072 B |              5 |                       2 |
| StructLinq_IFunction |   100 |   901.0 ns |  8.53 ns |  7.56 ns |  0.89 |    0.01 | 0.9899 |     - |     - |    2072 B |              3 |                       2 |
|            Hyperlinq |   100 | 1,190.1 ns | 11.30 ns |  8.82 ns |  1.18 |    0.01 | 0.9670 |     - |     - |    2024 B |              4 |                       2 |
|       Hyperlinq_Pool |   100 | 1,153.2 ns |  6.46 ns |  6.05 ns |  1.14 |    0.01 | 0.0267 |     - |     - |      56 B |              1 |                       2 |
