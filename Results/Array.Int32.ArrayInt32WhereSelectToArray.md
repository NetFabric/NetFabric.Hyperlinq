## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 | 241.4 ns | 1.82 ns | 1.61 ns |  1.00 |    0.00 |     593 B | 0.4168 |     - |     - |     872 B |              2 |                       0 |
|          ForeachLoop |   100 | 243.0 ns | 1.98 ns | 1.75 ns |  1.01 |    0.01 |     593 B | 0.4168 |     - |     - |     872 B |              1 |                       0 |
|                 Linq |   100 | 595.4 ns | 3.39 ns | 2.64 ns |  2.46 |    0.01 |    1599 B | 0.3710 |     - |     - |     776 B |              3 |                       2 |
|           LinqFaster |   100 | 343.8 ns | 1.23 ns | 1.03 ns |  1.42 |    0.01 |     796 B | 0.3095 |     - |     - |     648 B |              2 |                       1 |
|           StructLinq |   100 | 682.5 ns | 6.40 ns | 5.34 ns |  2.83 |    0.03 |    1941 B | 0.1297 |     - |     - |     272 B |              2 |                       2 |
| StructLinq_IFunction |   100 | 365.2 ns | 2.40 ns | 2.00 ns |  1.51 |    0.02 |    1771 B | 0.1297 |     - |     - |     272 B |              2 |                       1 |
|            Hyperlinq |   100 | 621.1 ns | 2.95 ns | 2.47 ns |  2.57 |    0.02 |    1404 B | 0.1068 |     - |     - |     224 B |              2 |                       2 |
|       Hyperlinq_Pool |   100 | 624.5 ns | 2.46 ns | 2.18 ns |  2.59 |    0.02 |    1897 B | 0.0267 |     - |     - |      56 B |              1 |                       2 |
