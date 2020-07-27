## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

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
|               Method | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 | 1.635 μs | 0.0086 μs | 0.0072 μs |  1.00 |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 | 1.891 μs | 0.0046 μs | 0.0043 μs |  1.16 |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 | 2.483 μs | 0.0130 μs | 0.0122 μs |  1.52 | 0.0648 |     - |     - |     136 B |              2 |                       1 |
|           LinqFaster |   100 | 2.375 μs | 0.0131 μs | 0.0117 μs |  1.45 | 1.9379 |     - |     - |    4056 B |              8 |                       2 |
|           StructLinq |   100 | 1.866 μs | 0.0072 μs | 0.0060 μs |  1.14 |      - |     - |     - |         - |              0 |                       1 |
| StructLinq_IFunction |   100 | 1.572 μs | 0.0046 μs | 0.0043 μs |  0.96 |      - |     - |     - |         - |              0 |                       0 |
|    Hyperlinq_Foreach |   100 | 1.923 μs | 0.0135 μs | 0.0126 μs |  1.18 |      - |     - |     - |         - |              0 |                       1 |
|        Hyperlinq_For |   100 | 2.066 μs | 0.0064 μs | 0.0053 μs |  1.26 |      - |     - |     - |         - |              0 |                       1 |
