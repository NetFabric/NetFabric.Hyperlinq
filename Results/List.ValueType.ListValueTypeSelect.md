## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta31](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta31)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                      Method | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                     ForLoop |   100 | 1.571 μs | 0.0015 μs | 0.0012 μs |  1.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 | 1.765 μs | 0.0016 μs | 0.0014 μs |  1.12 |      - |     - |     - |         - |
|                        Linq |   100 | 2.439 μs | 0.0042 μs | 0.0038 μs |  1.55 | 0.0648 |     - |     - |     136 B |
|                  LinqFaster |   100 | 2.306 μs | 0.0149 μs | 0.0139 μs |  1.47 | 1.9379 |     - |     - |    4056 B |
|                      LinqAF |   100 | 2.933 μs | 0.0073 μs | 0.0057 μs |  1.87 |      - |     - |     - |         - |
|                  StructLinq |   100 | 1.821 μs | 0.0027 μs | 0.0024 μs |  1.16 | 0.0191 |     - |     - |      40 B |
|        StructLinq_IFunction |   100 | 1.552 μs | 0.0023 μs | 0.0022 μs |  0.99 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 1.667 μs | 0.0018 μs | 0.0014 μs |  1.06 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 1.536 μs | 0.0020 μs | 0.0017 μs |  0.98 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 1.694 μs | 0.0026 μs | 0.0023 μs |  1.08 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 | 1.537 μs | 0.0017 μs | 0.0015 μs |  0.98 |      - |     - |     - |         - |
