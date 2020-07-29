## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

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
|      Method | Start | Count |     Mean |   Error |  StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------ |------ |------ |---------:|--------:|--------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|     ForLoop |     0 |   100 | 302.1 ns | 3.56 ns | 3.33 ns |  1.00 |    0.00 |     261 B | 0.5660 |     - |     - |    1184 B |              2 |                       0 |
| ForeachLoop |     0 |   100 | 744.0 ns | 6.23 ns | 5.52 ns |  2.46 |    0.03 |     572 B | 0.5922 |     - |     - |    1240 B |              4 |                       3 |
|        Linq |     0 |   100 | 197.0 ns | 3.82 ns | 3.92 ns |  0.65 |    0.02 |     370 B | 0.2370 |     - |     - |     496 B |              1 |                       1 |
|  LinqFaster |     0 |   100 | 131.6 ns | 2.68 ns | 2.51 ns |  0.44 |    0.01 |     693 B | 0.4206 |     - |     - |     880 B |              1 |                       1 |
|  StructLinq |     0 |   100 | 403.7 ns | 3.26 ns | 2.54 ns |  1.34 |    0.02 |    1271 B | 0.2294 |     - |     - |     480 B |              2 |                       0 |
|   Hyperlinq |     0 |   100 | 104.0 ns | 0.73 ns | 0.57 ns |  0.34 |    0.00 |     761 B | 0.2333 |     - |     - |     488 B |              1 |                       1 |
