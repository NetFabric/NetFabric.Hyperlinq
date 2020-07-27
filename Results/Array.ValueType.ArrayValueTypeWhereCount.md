## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

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
|              ForLoop |   100 | 145.2 ns | 0.96 ns | 0.90 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 | 120.8 ns | 0.39 ns | 0.32 ns |  0.83 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 | 644.1 ns | 3.58 ns | 3.35 ns |  4.44 |    0.04 | 0.0153 |     - |     - |      32 B |              0 |                       1 |
|           LinqFaster |   100 | 221.1 ns | 1.61 ns | 1.50 ns |  1.52 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
|           StructLinq |   100 | 354.8 ns | 4.94 ns | 4.62 ns |  2.44 |    0.04 | 0.0191 |     - |     - |      40 B |              0 |                       0 |
| StructLinq_IFunction |   100 | 185.1 ns | 1.67 ns | 1.56 ns |  1.27 |    0.01 | 0.0191 |     - |     - |      40 B |              0 |                       0 |
|            Hyperlinq |   100 | 513.4 ns | 3.16 ns | 2.96 ns |  3.54 |    0.03 |      - |     - |     - |         - |              0 |                       0 |
