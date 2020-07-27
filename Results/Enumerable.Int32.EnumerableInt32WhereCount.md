## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

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
|          ForeachLoop |   100 | 510.8 ns | 3.81 ns | 3.56 ns |  1.00 | 0.0191 |     - |     - |      40 B |              0 |                       1 |
|                 Linq |   100 | 638.9 ns | 4.69 ns | 4.38 ns |  1.25 | 0.0191 |     - |     - |      40 B |              0 |                       1 |
|           StructLinq |   100 | 796.5 ns | 3.89 ns | 3.25 ns |  1.56 | 0.0343 |     - |     - |      72 B |              1 |                       1 |
| StructLinq_IFunction |   100 | 506.7 ns | 4.15 ns | 3.67 ns |  0.99 | 0.0343 |     - |     - |      72 B |              1 |                       1 |
|            Hyperlinq |   100 | 643.6 ns | 2.83 ns | 2.51 ns |  1.26 | 0.0191 |     - |     - |      40 B |              0 |                       1 |
