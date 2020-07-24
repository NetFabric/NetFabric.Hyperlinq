## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

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
|               Method | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|          ForeachLoop |   100 |   635.7 ns | 3.31 ns | 2.58 ns |  1.00 | 0.3281 |     - |     - |     688 B |              2 |                       3 |
|                 Linq |   100 | 1,024.4 ns | 4.29 ns | 4.01 ns |  1.61 | 0.3853 |     - |     - |     808 B |              3 |                       5 |
|           StructLinq |   100 | 1,132.8 ns | 6.30 ns | 5.89 ns |  1.78 | 0.1602 |     - |     - |     336 B |              3 |                       2 |
| StructLinq_IFunction |   100 |   780.1 ns | 5.47 ns | 5.12 ns |  1.23 | 0.1602 |     - |     - |     336 B |              2 |                       2 |
|            Hyperlinq |   100 | 1,143.9 ns | 3.97 ns | 3.71 ns |  1.80 | 0.1755 |     - |     - |     368 B |              3 |                       2 |
