## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|          ForeachLoop |   100 | 508.0 ns | 3.78 ns | 3.53 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |              0 |                       1 |
|                 Linq |   100 | 993.7 ns | 4.76 ns | 4.22 ns |  1.95 |    0.02 | 0.0763 |     - |     - |     160 B |              2 |                       1 |
|           StructLinq |   100 | 911.7 ns | 3.31 ns | 2.94 ns |  1.79 |    0.01 | 0.0191 |     - |     - |      40 B |              0 |                       1 |
| StructLinq_IFunction |   100 | 562.5 ns | 3.53 ns | 3.31 ns |  1.11 |    0.01 | 0.0191 |     - |     - |      40 B |              0 |                       1 |
|            Hyperlinq |   100 | 993.7 ns | 6.47 ns | 6.05 ns |  1.96 |    0.01 | 0.0191 |     - |     - |      40 B |              1 |                       1 |
