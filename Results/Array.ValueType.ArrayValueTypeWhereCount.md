## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 | 146.6 ns | 0.56 ns | 0.52 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 | 122.3 ns | 0.51 ns | 0.48 ns |  0.83 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 | 653.2 ns | 3.82 ns | 3.39 ns |  4.46 |    0.03 | 0.0153 |     - |     - |      32 B |              0 |                       1 |
|           LinqFaster |   100 | 275.4 ns | 2.10 ns | 1.96 ns |  1.88 |    0.02 |      - |     - |     - |         - |              0 |                       1 |
|           StructLinq |   100 | 379.0 ns | 2.57 ns | 2.41 ns |  2.58 |    0.02 | 0.0191 |     - |     - |      40 B |              0 |                       0 |
| StructLinq_IFunction |   100 | 191.5 ns | 1.93 ns | 1.81 ns |  1.31 |    0.01 | 0.0191 |     - |     - |      40 B |              0 |                       0 |
|            Hyperlinq |   100 | 203.2 ns | 1.01 ns | 0.79 ns |  1.39 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
