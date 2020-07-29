## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|               Method | Count |     Mean |   Error |   StdDev |   Median | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |---------:|--------:|---------:|---------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 | 237.0 ns | 3.02 ns |  2.82 ns | 236.7 ns |  1.00 |    0.00 |     276 B | 0.3095 |     - |     - |     648 B |              1 |                       0 |
|          ForeachLoop |   100 | 236.6 ns | 4.76 ns |  7.27 ns | 234.0 ns |  1.01 |    0.04 |     276 B | 0.3095 |     - |     - |     648 B |              2 |                       0 |
|                 Linq |   100 | 501.5 ns | 9.42 ns | 17.69 ns | 493.7 ns |  2.15 |    0.10 |    1627 B | 0.3595 |     - |     - |     752 B |              3 |                       3 |
|           LinqFaster |   100 | 442.6 ns | 2.80 ns |  2.48 ns | 443.0 ns |  1.87 |    0.03 |    1321 B | 0.4320 |     - |     - |     904 B |              2 |                       1 |
|           StructLinq |   100 | 661.5 ns | 7.25 ns |  7.12 ns | 658.6 ns |  2.79 |    0.05 |    2003 B | 0.1450 |     - |     - |     304 B |              2 |                       2 |
| StructLinq_IFunction |   100 | 369.7 ns | 2.65 ns |  2.35 ns | 369.2 ns |  1.56 |    0.02 |    1837 B | 0.1450 |     - |     - |     304 B |              2 |                       1 |
|            Hyperlinq |   100 | 716.4 ns | 5.21 ns |  4.62 ns | 715.1 ns |  3.03 |    0.03 |    1921 B | 0.1564 |     - |     - |     328 B |              3 |                       2 |
