## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

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
|          ForeachLoop |   100 |   499.6 ns | 3.35 ns | 2.80 ns |  1.00 | 0.0191 |     - |     - |      40 B |              0 |                       1 |
|                 Linq |   100 | 1,087.4 ns | 6.67 ns | 6.24 ns |  2.18 | 0.0458 |     - |     - |      96 B |              1 |                       1 |
|           StructLinq |   100 |   738.7 ns | 3.00 ns | 2.66 ns |  1.48 | 0.0191 |     - |     - |      40 B |              0 |                       1 |
| StructLinq_IFunction |   100 |   498.0 ns | 1.50 ns | 1.25 ns |  1.00 | 0.0191 |     - |     - |      40 B |              0 |                       1 |
|    Hyperlinq_Foreach |   100 |   753.9 ns | 5.18 ns | 4.84 ns |  1.51 | 0.0191 |     - |     - |      40 B |              0 |                       1 |
