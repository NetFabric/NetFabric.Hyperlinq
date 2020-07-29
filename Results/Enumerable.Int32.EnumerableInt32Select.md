## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

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
|               Method | Count |       Mean |    Error |  StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |-----------:|---------:|--------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|          ForeachLoop |   100 |   432.3 ns |  2.46 ns | 2.30 ns |  1.00 |    0.00 |     195 B | 0.0191 |     - |     - |      40 B |              1 |                       1 |
|                 Linq |   100 | 1,015.5 ns | 10.40 ns | 9.22 ns |  2.35 |    0.02 |    1099 B | 0.0458 |     - |     - |      96 B |              1 |                       1 |
|           StructLinq |   100 |   746.1 ns |  3.65 ns | 3.23 ns |  1.73 |    0.01 |     469 B | 0.0191 |     - |     - |      40 B |              1 |                       1 |
| StructLinq_IFunction |   100 |   501.2 ns |  3.72 ns | 3.11 ns |  1.16 |    0.01 |     543 B | 0.0191 |     - |     - |      40 B |              1 |                       1 |
|    Hyperlinq_Foreach |   100 |   794.4 ns |  7.75 ns | 7.25 ns |  1.84 |    0.02 |     480 B | 0.0191 |     - |     - |      40 B |              1 |                       1 |
