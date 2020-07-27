## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta20](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta20)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |---------:|--------:|--------:|------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|                 Linq |   100 | 914.0 ns | 3.18 ns | 2.82 ns |  1.00 | 0.0458 |     - |     - |      96 B |              1 |                       1 |
|           StructLinq |   100 | 783.9 ns | 6.17 ns | 5.77 ns |  0.86 | 0.0191 |     - |     - |      40 B |              1 |                       1 |
| StructLinq_IFunction |   100 | 579.9 ns | 3.74 ns | 3.50 ns |  0.63 | 0.0191 |     - |     - |      40 B |              0 |                       1 |
|            Hyperlinq |   100 | 836.6 ns | 8.24 ns | 7.31 ns |  0.92 | 0.0191 |     - |     - |      40 B |              1 |                       1 |
