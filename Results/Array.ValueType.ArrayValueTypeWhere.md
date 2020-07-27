## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

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
|              ForLoop |   100 | 483.0 ns | 1.49 ns | 1.39 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 | 457.0 ns | 3.11 ns | 2.91 ns |  0.95 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 | 869.5 ns | 7.77 ns | 7.27 ns |  1.80 |    0.01 | 0.0381 |     - |     - |      80 B |              1 |                       0 |
|           LinqFaster |   100 | 937.6 ns | 8.26 ns | 7.73 ns |  1.94 |    0.02 | 2.8896 |     - |     - |    6048 B |              3 |                       1 |
|           StructLinq |   100 | 744.0 ns | 2.26 ns | 2.00 ns |  1.54 |    0.01 |      - |     - |     - |         - |              0 |                       1 |
| StructLinq_IFunction |   100 | 491.1 ns | 2.26 ns | 2.00 ns |  1.02 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
|            Hyperlinq |   100 | 665.9 ns | 3.27 ns | 2.73 ns |  1.38 |    0.01 |      - |     - |     - |         - |              0 |                       1 |
