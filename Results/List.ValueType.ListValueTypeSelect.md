## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

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
|               Method | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 | 1.606 μs | 0.0068 μs | 0.0063 μs |  1.00 |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 | 1.872 μs | 0.0035 μs | 0.0033 μs |  1.17 |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 | 2.506 μs | 0.0118 μs | 0.0111 μs |  1.56 | 0.0648 |     - |     - |     136 B |              2 |                       1 |
|           LinqFaster |   100 | 2.406 μs | 0.0131 μs | 0.0116 μs |  1.50 | 1.9379 |     - |     - |    4056 B |              9 |                       2 |
|           StructLinq |   100 | 1.840 μs | 0.0076 μs | 0.0068 μs |  1.15 |      - |     - |     - |         - |              0 |                       1 |
| StructLinq_IFunction |   100 | 2.294 μs | 0.0054 μs | 0.0045 μs |  1.43 |      - |     - |     - |         - |              0 |                       0 |
|    Hyperlinq_Foreach |   100 | 1.936 μs | 0.0068 μs | 0.0064 μs |  1.21 |      - |     - |     - |         - |              0 |                       1 |
|        Hyperlinq_For |   100 | 2.086 μs | 0.0081 μs | 0.0076 μs |  1.30 |      - |     - |     - |         - |              0 |                       1 |
