## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

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
|               Method | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|          ForeachLoop |   100 |   688.1 ns | 4.23 ns | 3.95 ns |  1.00 | 0.3281 |     - |     - |     688 B |              2 |                       3 |
|                 Linq |   100 | 1,034.2 ns | 3.23 ns | 2.52 ns |  1.50 | 0.3853 |     - |     - |     808 B |              3 |                       4 |
|           StructLinq |   100 | 1,127.3 ns | 7.82 ns | 6.10 ns |  1.64 | 0.1602 |     - |     - |     336 B |              3 |                       2 |
| StructLinq_IFunction |   100 |   751.6 ns | 4.74 ns | 4.44 ns |  1.09 | 0.1602 |     - |     - |     336 B |              2 |                       2 |
|            Hyperlinq |   100 | 1,082.2 ns | 8.54 ns | 7.57 ns |  1.57 | 0.1755 |     - |     - |     368 B |              3 |                       2 |
