## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta36](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta36)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                      Method | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                     ForLoop |   100 | 1.603 μs | 0.0051 μs | 0.0045 μs |  1.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 | 1.828 μs | 0.0030 μs | 0.0027 μs |  1.14 |      - |     - |     - |         - |
|                        Linq |   100 | 2.497 μs | 0.0069 μs | 0.0061 μs |  1.56 | 0.0648 |     - |     - |     136 B |
|                  LinqFaster |   100 | 2.374 μs | 0.0057 μs | 0.0044 μs |  1.48 | 1.9379 |     - |     - |    4056 B |
|                      LinqAF |   100 | 2.982 μs | 0.0149 μs | 0.0125 μs |  1.86 |      - |     - |     - |         - |
|                  StructLinq |   100 | 1.865 μs | 0.0073 μs | 0.0065 μs |  1.16 | 0.0191 |     - |     - |      40 B |
|        StructLinq_IFunction |   100 | 1.596 μs | 0.0039 μs | 0.0037 μs |  1.00 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 1.706 μs | 0.0078 μs | 0.0073 μs |  1.06 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 1.571 μs | 0.0053 μs | 0.0049 μs |  0.98 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 1.714 μs | 0.0055 μs | 0.0052 μs |  1.07 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 | 1.579 μs | 0.0047 μs | 0.0044 μs |  0.99 |      - |     - |     - |         - |
