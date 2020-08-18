## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G73) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 1.715 μs | 0.0016 μs | 0.0015 μs |  1.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 1.974 μs | 0.0007 μs | 0.0007 μs |  1.15 |      - |     - |     - |         - |
|                 Linq |   100 | 2.631 μs | 0.0015 μs | 0.0012 μs |  1.53 | 0.0648 |     - |     - |     136 B |
|           LinqFaster |   100 | 2.519 μs | 0.0016 μs | 0.0013 μs |  1.47 | 1.9379 |     - |     - |    4056 B |
|               LinqAF |   100 | 3.321 μs | 0.0089 μs | 0.0078 μs |  1.94 |      - |     - |     - |         - |
|           StructLinq |   100 | 2.034 μs | 0.0005 μs | 0.0004 μs |  1.19 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 1.678 μs | 0.0016 μs | 0.0015 μs |  0.98 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |   100 | 2.050 μs | 0.0006 μs | 0.0005 μs |  1.20 |      - |     - |     - |         - |
|        Hyperlinq_For |   100 | 2.077 μs | 0.0013 μs | 0.0012 μs |  1.21 |      - |     - |     - |         - |
