## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

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
|               Method | Start | Count |     Mean |   Error |  StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |------ |---------:|--------:|--------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |     0 |   100 | 298.8 ns | 3.43 ns | 3.04 ns |  1.00 |    0.00 |     263 B | 0.5660 |     - |     - |    1184 B |              2 |                       0 |
|          ForeachLoop |     0 |   100 | 776.3 ns | 6.25 ns | 5.54 ns |  2.60 |    0.04 |     573 B | 0.5922 |     - |     - |    1240 B |              4 |                       3 |
|                 Linq |     0 |   100 | 332.2 ns | 1.52 ns | 1.34 ns |  1.11 |    0.01 |    1205 B | 0.2599 |     - |     - |     544 B |              2 |                       1 |
|           LinqFaster |     0 |   100 | 355.4 ns | 1.78 ns | 1.48 ns |  1.19 |    0.02 |    1090 B | 0.6232 |     - |     - |    1304 B |              2 |                       1 |
|           StructLinq |     0 |   100 | 556.9 ns | 5.38 ns | 4.77 ns |  1.86 |    0.02 |    1558 B | 0.2327 |     - |     - |     488 B |              2 |                       3 |
| StructLinq_IFunction |     0 |   100 | 399.9 ns | 2.72 ns | 2.54 ns |  1.34 |    0.02 |    1550 B | 0.2332 |     - |     - |     488 B |              2 |                       0 |
|            Hyperlinq |     0 |   100 | 270.5 ns | 1.51 ns | 1.34 ns |  0.91 |    0.01 |    1290 B | 0.2446 |     - |     - |     512 B |              2 |                       1 |
