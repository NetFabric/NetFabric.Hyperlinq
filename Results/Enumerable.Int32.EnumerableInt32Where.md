## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |---------:|--------:|--------:|------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|                 Linq |   100 | 948.7 ns | 3.88 ns | 3.44 ns |  1.00 |     887 B | 0.0458 |     - |     - |      96 B |              1 |                       1 |
|           StructLinq |   100 | 736.8 ns | 2.51 ns | 1.96 ns |  0.78 |     501 B | 0.0191 |     - |     - |      40 B |              1 |                       1 |
| StructLinq_IFunction |   100 | 551.2 ns | 2.63 ns | 2.33 ns |  0.58 |     467 B | 0.0191 |     - |     - |      40 B |              1 |                       1 |
|            Hyperlinq |   100 | 815.5 ns | 6.13 ns | 5.74 ns |  0.86 |     553 B | 0.0191 |     - |     - |      40 B |              1 |                       1 |
