## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta21](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta21)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 | 124.6 ns | 0.69 ns | 0.64 ns |  1.00 |    0.00 |     108 B |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 | 123.9 ns | 0.47 ns | 0.42 ns |  0.99 |    0.01 |     108 B |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 | 659.2 ns | 3.64 ns | 3.23 ns |  5.29 |    0.03 |     427 B | 0.0153 |     - |     - |      32 B |              1 |                       1 |
|           LinqFaster |   100 | 277.3 ns | 2.53 ns | 2.24 ns |  2.23 |    0.02 |     389 B |      - |     - |     - |         - |              0 |                       1 |
|           StructLinq |   100 | 385.9 ns | 2.95 ns | 2.61 ns |  3.10 |    0.03 |     550 B | 0.0191 |     - |     - |      40 B |              1 |                       1 |
| StructLinq_IFunction |   100 | 194.1 ns | 1.84 ns | 1.54 ns |  1.56 |    0.01 |     334 B | 0.0191 |     - |     - |      40 B |              0 |                       0 |
|            Hyperlinq |   100 | 349.8 ns | 1.18 ns | 0.98 ns |  2.81 |    0.02 |     644 B |      - |     - |     - |         - |              0 |                       0 |
