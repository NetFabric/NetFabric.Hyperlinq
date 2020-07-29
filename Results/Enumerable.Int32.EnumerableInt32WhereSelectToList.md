## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

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
|          ForeachLoop |   100 |   708.8 ns |  6.34 ns |  6.23 ns |  1.00 |    0.00 |     425 B | 0.3281 |     - |     - |     688 B |              3 |                       3 |
|                 Linq |   100 | 1,072.9 ns |  4.55 ns |  4.03 ns |  1.51 |    0.01 |    1627 B | 0.3853 |     - |     - |     808 B |              4 |                       4 |
|           StructLinq |   100 | 1,147.8 ns |  6.66 ns |  5.90 ns |  1.62 |    0.02 |    1872 B | 0.1602 |     - |     - |     336 B |              3 |                       3 |
| StructLinq_IFunction |   100 |   795.8 ns |  3.82 ns |  3.38 ns |  1.12 |    0.01 |    1814 B | 0.1602 |     - |     - |     336 B |              3 |                       2 |
|            Hyperlinq |   100 | 1,127.2 ns | 18.23 ns | 16.16 ns |  1.59 |    0.02 |    1760 B | 0.1755 |     - |     - |     368 B |              3 |                       3 |
