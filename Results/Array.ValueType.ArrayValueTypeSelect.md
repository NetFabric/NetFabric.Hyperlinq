## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

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
|              ForLoop |   100 | 1.516 μs | 0.0088 μs | 0.0078 μs |  1.00 |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 | 1.596 μs | 0.0071 μs | 0.0066 μs |  1.05 |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 | 2.138 μs | 0.0201 μs | 0.0168 μs |  1.41 | 0.0381 |     - |     - |      80 B |              1 |                       1 |
|           LinqFaster |   100 | 2.045 μs | 0.0127 μs | 0.0113 μs |  1.35 | 1.9226 |     - |     - |    4024 B |              7 |                       2 |
|           StructLinq |   100 | 1.830 μs | 0.0136 μs | 0.0127 μs |  1.21 |      - |     - |     - |         - |              0 |                       1 |
| StructLinq_IFunction |   100 | 1.554 μs | 0.0052 μs | 0.0048 μs |  1.03 |      - |     - |     - |         - |              0 |                       0 |
|    Hyperlinq_Foreach |   100 | 1.863 μs | 0.0081 μs | 0.0076 μs |  1.23 |      - |     - |     - |         - |              0 |                       1 |
|        Hyperlinq_For |   100 | 1.879 μs | 0.0152 μs | 0.0142 μs |  1.24 |      - |     - |     - |         - |              0 |                       1 |
