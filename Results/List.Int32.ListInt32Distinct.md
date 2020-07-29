## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

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
|               Method | Duplicates | Count |       Mean |    Error |   StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |----------- |------ |-----------:|---------:|---------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |          4 |   100 | 3,407.4 ns | 38.78 ns | 36.27 ns |  1.00 |    0.00 |    1297 B | 2.8687 |     - |     - |    6008 B |             17 |                       5 |
|          ForeachLoop |          4 |   100 | 3,881.2 ns | 52.01 ns | 46.10 ns |  1.14 |    0.02 |    1409 B | 2.8687 |     - |     - |    6008 B |             18 |                       7 |
|                 Linq |          4 |   100 | 7,415.7 ns | 33.97 ns | 28.36 ns |  2.18 |    0.02 |     375 B | 2.0599 |     - |     - |    4320 B |             26 |                      10 |
|           LinqFaster |          4 |   100 |   650.5 ns |  3.30 ns |  2.57 ns |  0.19 |    0.00 |     636 B |      - |     - |     - |         - |              0 |                       2 |
|           StructLinq |          4 |   100 | 5,169.5 ns | 21.23 ns | 18.82 ns |  1.52 |    0.02 |    1928 B |      - |     - |     - |         - |              2 |                       7 |
| StructLinq_IFunction |          4 |   100 | 3,727.2 ns | 21.28 ns | 18.86 ns |  1.09 |    0.01 |    1665 B |      - |     - |     - |         - |              1 |                       4 |
|            Hyperlinq |          4 |   100 | 4,093.4 ns | 28.95 ns | 25.66 ns |  1.20 |    0.01 |    1416 B |      - |     - |     - |         - |              1 |                       4 |
