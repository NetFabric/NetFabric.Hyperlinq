## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

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
|               Method | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |-----------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|          ForeachLoop |   100 |   426.4 ns | 2.81 ns | 2.62 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |              0 |                       1 |
|                 Linq |   100 | 1,089.9 ns | 5.57 ns | 5.21 ns |  2.56 |    0.02 | 0.0458 |     - |     - |      96 B |              1 |                       1 |
|           StructLinq |   100 |   679.7 ns | 6.91 ns | 6.47 ns |  1.59 |    0.02 | 0.0191 |     - |     - |      40 B |              0 |                       1 |
| StructLinq_IFunction |   100 |   473.1 ns | 3.42 ns | 3.03 ns |  1.11 |    0.01 | 0.0191 |     - |     - |      40 B |              0 |                       1 |
|    Hyperlinq_Foreach |   100 |   797.4 ns | 6.50 ns | 5.76 ns |  1.87 |    0.02 | 0.0191 |     - |     - |      40 B |              0 |                       1 |
