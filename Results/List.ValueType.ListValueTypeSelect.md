## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [1.0.0](https://www.nuget.org/packages/LinqAF/1.0.0)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

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
|              ForLoop |   100 | 1.723 μs | 0.0023 μs | 0.0021 μs |  1.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 1.919 μs | 0.0036 μs | 0.0034 μs |  1.11 |      - |     - |     - |         - |
|                 Linq |   100 | 2.644 μs | 0.0033 μs | 0.0029 μs |  1.53 | 0.0648 |     - |     - |     136 B |
|           LinqFaster |   100 | 2.491 μs | 0.0038 μs | 0.0031 μs |  1.45 | 1.9379 |     - |     - |    4056 B |
|               LinqAF |   100 | 3.175 μs | 0.0023 μs | 0.0019 μs |  1.84 |      - |     - |     - |         - |
|           StructLinq |   100 | 2.091 μs | 0.0096 μs | 0.0081 μs |  1.21 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 1.679 μs | 0.0006 μs | 0.0004 μs |  0.97 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |   100 | 2.082 μs | 0.0024 μs | 0.0022 μs |  1.21 |      - |     - |     - |         - |
|        Hyperlinq_For |   100 | 2.133 μs | 0.0016 μs | 0.0014 μs |  1.24 |      - |     - |     - |         - |
