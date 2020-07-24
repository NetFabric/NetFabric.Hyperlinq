## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|               Method | Count |     Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |---------:|---------:|---------:|------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|                 Linq |   100 | 907.2 ns |  6.29 ns |  5.88 ns |  1.00 | 0.0458 |     - |     - |      96 B |              1 |                       1 |
|           StructLinq |   100 | 732.5 ns | 13.66 ns | 12.77 ns |  0.81 | 0.0191 |     - |     - |      40 B |              0 |                       1 |
| StructLinq_IFunction |   100 | 554.0 ns |  5.56 ns |  5.20 ns |  0.61 | 0.0191 |     - |     - |      40 B |              0 |                       1 |
|            Hyperlinq |   100 | 805.1 ns |  5.84 ns |  5.17 ns |  0.89 | 0.0191 |     - |     - |      40 B |              1 |                       1 |
