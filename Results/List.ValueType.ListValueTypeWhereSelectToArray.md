## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 | 1,030.7 ns |  4.46 ns |  3.95 ns |  1.00 |    0.00 | 3.4103 |     - |     - |    7136 B |              4 |                       1 |
|          ForeachLoop |   100 | 1,279.2 ns | 10.64 ns |  9.43 ns |  1.24 |    0.01 | 3.4103 |     - |     - |    7136 B |              6 |                       2 |
|                 Linq |   100 | 1,356.3 ns | 18.00 ns | 16.84 ns |  1.31 |    0.01 | 2.4853 |     - |     - |    5200 B |              6 |                       3 |
|           LinqFaster |   100 | 1,441.4 ns | 21.33 ns | 18.91 ns |  1.40 |    0.02 | 3.4103 |     - |     - |    7136 B |              5 |                       3 |
|           StructLinq |   100 | 1,281.4 ns | 14.53 ns | 12.88 ns |  1.24 |    0.01 | 0.9899 |     - |     - |    2072 B |              5 |                       3 |
| StructLinq_IFunction |   100 |   856.0 ns |  4.52 ns |  4.01 ns |  0.83 |    0.01 | 0.9899 |     - |     - |    2072 B |              4 |                       3 |
|            Hyperlinq |   100 | 1,232.0 ns |  7.55 ns |  7.07 ns |  1.19 |    0.01 | 0.9670 |     - |     - |    2024 B |              5 |                       3 |
|       Hyperlinq_Pool |   100 | 1,134.6 ns |  9.57 ns |  8.95 ns |  1.10 |    0.01 | 0.0267 |     - |     - |      56 B |              1 |                       2 |
