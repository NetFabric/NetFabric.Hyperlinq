## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta24](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta24)

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
|              ForLoop |   100 | 1.714 μs | 0.0020 μs | 0.0017 μs |  1.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 1.917 μs | 0.0016 μs | 0.0014 μs |  1.12 |      - |     - |     - |         - |
|                 Linq |   100 | 2.593 μs | 0.0019 μs | 0.0016 μs |  1.51 | 0.0648 |     - |     - |     136 B |
|           LinqFaster |   100 | 2.500 μs | 0.0067 μs | 0.0059 μs |  1.46 | 1.9379 |     - |     - |    4056 B |
|               LinqAF |   100 | 3.200 μs | 0.0042 μs | 0.0038 μs |  1.87 |      - |     - |     - |         - |
|           StructLinq |   100 | 2.085 μs | 0.0012 μs | 0.0011 μs |  1.22 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 1.676 μs | 0.0010 μs | 0.0008 μs |  0.98 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |   100 | 2.078 μs | 0.0021 μs | 0.0020 μs |  1.21 |      - |     - |     - |         - |
|        Hyperlinq_For |   100 | 2.103 μs | 0.0015 μs | 0.0013 μs |  1.23 |      - |     - |     - |         - |
