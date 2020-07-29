## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

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
|               Method | Count |     Mean |     Error |    StdDev | Ratio | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |---------:|----------:|----------:|------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 | 1.531 μs | 0.0065 μs | 0.0058 μs |  1.00 |     398 B |      - |     - |     - |         - |              1 |                       1 |
|          ForeachLoop |   100 | 1.607 μs | 0.0051 μs | 0.0045 μs |  1.05 |     454 B |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 | 2.198 μs | 0.0073 μs | 0.0069 μs |  1.44 |    1433 B | 0.0381 |     - |     - |      80 B |              2 |                       2 |
|           LinqFaster |   100 | 2.131 μs | 0.0106 μs | 0.0088 μs |  1.39 |     831 B | 1.9226 |     - |     - |    4024 B |             11 |                       2 |
|           StructLinq |   100 | 1.864 μs | 0.0061 μs | 0.0054 μs |  1.22 |     990 B |      - |     - |     - |         - |              1 |                       1 |
| StructLinq_IFunction |   100 | 1.592 μs | 0.0052 μs | 0.0049 μs |  1.04 |     873 B |      - |     - |     - |         - |              0 |                       0 |
|    Hyperlinq_Foreach |   100 | 1.899 μs | 0.0176 μs | 0.0156 μs |  1.24 |     898 B |      - |     - |     - |         - |              1 |                       1 |
|        Hyperlinq_For |   100 | 1.938 μs | 0.0081 μs | 0.0072 μs |  1.27 |     864 B |      - |     - |     - |         - |              1 |                       1 |
