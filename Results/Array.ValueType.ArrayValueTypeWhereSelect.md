## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|              ForLoop |   100 |   890.8 ns | 1.78 ns | 1.49 ns |  1.00 |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 |   842.7 ns | 4.03 ns | 3.77 ns |  0.95 |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 | 1,358.8 ns | 7.89 ns | 7.38 ns |  1.53 | 0.0801 |     - |     - |     168 B |              2 |                       1 |
|           LinqFaster |   100 | 1,414.7 ns | 9.40 ns | 8.79 ns |  1.59 | 2.8896 |     - |     - |    6048 B |              5 |                       1 |
|           StructLinq |   100 | 1,229.7 ns | 6.10 ns | 5.71 ns |  1.38 |      - |     - |     - |         - |              0 |                       1 |
| StructLinq_IFunction |   100 |   903.8 ns | 6.90 ns | 6.46 ns |  1.02 |      - |     - |     - |         - |              0 |                       0 |
|            Hyperlinq |   100 | 1,213.6 ns | 7.65 ns | 6.78 ns |  1.36 |      - |     - |     - |         - |              0 |                       1 |
