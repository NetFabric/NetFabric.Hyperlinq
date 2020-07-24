## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

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
|          ForeachLoop |   100 | 483.9 ns | 3.06 ns | 2.86 ns |  1.00 | 0.0191 |     - |     - |      40 B |              0 |                       1 |
|                 Linq |   100 | 639.5 ns | 2.98 ns | 2.78 ns |  1.32 | 0.0191 |     - |     - |      40 B |              0 |                       1 |
|           StructLinq |   100 | 731.1 ns | 4.55 ns | 4.03 ns |  1.51 | 0.0343 |     - |     - |      72 B |              1 |                       1 |
| StructLinq_IFunction |   100 | 512.2 ns | 2.57 ns | 2.41 ns |  1.06 | 0.0343 |     - |     - |      72 B |              1 |                       1 |
|            Hyperlinq |   100 | 610.2 ns | 3.14 ns | 2.94 ns |  1.26 | 0.0191 |     - |     - |      40 B |              0 |                       1 |
