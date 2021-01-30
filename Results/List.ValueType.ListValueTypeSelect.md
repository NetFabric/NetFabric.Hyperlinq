## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

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
|                     ForLoop |   100 | 1.601 μs | 0.0037 μs | 0.0033 μs |  1.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 | 1.786 μs | 0.0020 μs | 0.0018 μs |  1.12 |      - |     - |     - |         - |
|                        Linq |   100 | 2.443 μs | 0.0045 μs | 0.0040 μs |  1.53 | 0.0648 |     - |     - |     136 B |
|                  LinqFaster |   100 | 2.369 μs | 0.0100 μs | 0.0094 μs |  1.48 | 1.9379 |     - |     - |    4056 B |
|                      LinqAF |   100 | 2.929 μs | 0.0059 μs | 0.0052 μs |  1.83 |      - |     - |     - |         - |
|                  StructLinq |   100 | 1.830 μs | 0.0015 μs | 0.0012 μs |  1.14 | 0.0191 |     - |     - |      40 B |
|        StructLinq_IFunction |   100 | 1.555 μs | 0.0045 μs | 0.0038 μs |  0.97 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 1.834 μs | 0.0179 μs | 0.0149 μs |  1.15 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 1.719 μs | 0.0130 μs | 0.0115 μs |  1.07 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 1.888 μs | 0.0216 μs | 0.0202 μs |  1.18 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 | 1.731 μs | 0.0131 μs | 0.0116 μs |  1.08 |      - |     - |     - |         - |
