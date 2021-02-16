## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta37](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta37)

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
|                     ForLoop |   100 | 1.605 μs | 0.0037 μs | 0.0033 μs |  1.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 | 1.770 μs | 0.0043 μs | 0.0038 μs |  1.10 |      - |     - |     - |         - |
|                        Linq |   100 | 2.447 μs | 0.0059 μs | 0.0055 μs |  1.53 | 0.0648 |     - |     - |     136 B |
|                  LinqFaster |   100 | 2.340 μs | 0.0089 μs | 0.0075 μs |  1.46 | 1.9379 |     - |     - |    4056 B |
|                      LinqAF |   100 | 2.932 μs | 0.0098 μs | 0.0087 μs |  1.83 |      - |     - |     - |         - |
|                  StructLinq |   100 | 1.778 μs | 0.0032 μs | 0.0028 μs |  1.11 | 0.0191 |     - |     - |      40 B |
|        StructLinq_IFunction |   100 | 1.556 μs | 0.0022 μs | 0.0021 μs |  0.97 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 1.694 μs | 0.0017 μs | 0.0014 μs |  1.06 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 1.542 μs | 0.0031 μs | 0.0026 μs |  0.96 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 1.676 μs | 0.0023 μs | 0.0020 μs |  1.04 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 | 1.562 μs | 0.0025 μs | 0.0020 μs |  0.97 |      - |     - |     - |         - |
