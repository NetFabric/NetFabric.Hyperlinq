## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|              ForLoop |   100 | 247.5 ns | 2.89 ns | 2.42 ns |  1.00 |    0.00 |     300 B | 0.3095 |     - |     - |     648 B |              2 |                       0 |
|          ForeachLoop |   100 | 406.2 ns | 2.95 ns | 2.62 ns |  1.64 |    0.01 |     430 B | 0.3095 |     - |     - |     648 B |              2 |                       2 |
|                 Linq |   100 | 586.6 ns | 5.70 ns | 5.06 ns |  2.37 |    0.03 |    1627 B | 0.3824 |     - |     - |     800 B |              3 |                       2 |
|           LinqFaster |   100 | 501.1 ns | 2.47 ns | 2.06 ns |  2.03 |    0.02 |    1255 B | 0.4320 |     - |     - |     904 B |              3 |                       2 |
|           StructLinq |   100 | 687.9 ns | 3.65 ns | 3.23 ns |  2.78 |    0.03 |    2007 B | 0.1450 |     - |     - |     304 B |              2 |                       2 |
| StructLinq_IFunction |   100 | 380.6 ns | 7.12 ns | 6.66 ns |  1.54 |    0.03 |    1841 B | 0.1450 |     - |     - |     304 B |              2 |                       1 |
|            Hyperlinq |   100 | 677.2 ns | 4.33 ns | 4.05 ns |  2.73 |    0.03 |    1943 B | 0.1564 |     - |     - |     328 B |              3 |                       2 |
