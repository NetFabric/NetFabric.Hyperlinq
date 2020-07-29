## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

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
|               Method | Count |       Mean |   Error |  StdDev | Ratio | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |-----------:|--------:|--------:|------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|          ForeachLoop |   100 |   712.6 ns | 4.64 ns | 3.87 ns |  1.00 |     742 B | 0.4358 |     - |     - |     912 B |              4 |                       4 |
|                 Linq |   100 | 1,090.5 ns | 6.93 ns | 5.79 ns |  1.53 |    1599 B | 0.3967 |     - |     - |     832 B |              5 |                       5 |
|           StructLinq |   100 | 1,134.6 ns | 7.09 ns | 6.29 ns |  1.59 |    1814 B | 0.1450 |     - |     - |     304 B |              3 |                       3 |
| StructLinq_IFunction |   100 |   764.8 ns | 4.53 ns | 4.02 ns |  1.07 |    1756 B | 0.1450 |     - |     - |     304 B |              3 |                       3 |
|            Hyperlinq |   100 | 1,062.6 ns | 4.67 ns | 3.90 ns |  1.49 |    1243 B | 0.1259 |     - |     - |     264 B |              3 |                       3 |
|       Hyperlinq_Pool |   100 | 1,104.8 ns | 9.28 ns | 7.75 ns |  1.55 |    1720 B | 0.0458 |     - |     - |      96 B |              1 |                       3 |
