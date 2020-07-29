## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

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
|          ForeachLoop |   100 | 521.3 ns | 6.43 ns | 5.37 ns |  1.00 |    0.00 |     198 B | 0.0191 |     - |     - |      40 B |              1 |                       1 |
|                 Linq |   100 | 652.7 ns | 3.01 ns | 2.35 ns |  1.25 |    0.01 |     378 B | 0.0191 |     - |     - |      40 B |              1 |                       1 |
|           StructLinq |   100 | 831.2 ns | 4.17 ns | 3.48 ns |  1.59 |    0.02 |     441 B | 0.0343 |     - |     - |      72 B |              1 |                       1 |
| StructLinq_IFunction |   100 | 535.3 ns | 1.62 ns | 1.35 ns |  1.03 |    0.01 |     342 B | 0.0343 |     - |     - |      72 B |              1 |                       1 |
|            Hyperlinq |   100 | 626.9 ns | 2.46 ns | 1.92 ns |  1.20 |    0.01 |     462 B | 0.0191 |     - |     - |      40 B |              1 |                       1 |
