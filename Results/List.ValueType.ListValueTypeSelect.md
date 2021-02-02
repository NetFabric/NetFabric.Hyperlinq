## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta30](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta30)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 1.583 μs | 0.0025 μs | 0.0023 μs |  1.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 1.766 μs | 0.0028 μs | 0.0027 μs |  1.12 |      - |     - |     - |         - |
|                 Linq |   100 | 2.448 μs | 0.0059 μs | 0.0049 μs |  1.55 | 0.0648 |     - |     - |     136 B |
|           LinqFaster |   100 | 2.349 μs | 0.0078 μs | 0.0073 μs |  1.48 | 1.9379 |     - |     - |    4056 B |
|               LinqAF |   100 | 2.924 μs | 0.0070 μs | 0.0065 μs |  1.85 |      - |     - |     - |         - |
|           StructLinq |   100 | 1.787 μs | 0.0034 μs | 0.0030 μs |  1.13 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 | 1.558 μs | 0.0031 μs | 0.0027 μs |  0.98 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |   100 | 1.802 μs | 0.0022 μs | 0.0020 μs |  1.14 |      - |     - |     - |         - |
|        Hyperlinq_For |   100 | 1.895 μs | 0.0051 μs | 0.0048 μs |  1.20 |      - |     - |     - |         - |
