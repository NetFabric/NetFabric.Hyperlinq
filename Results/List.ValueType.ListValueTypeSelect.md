## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta34](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta34)

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
|                     ForLoop |   100 | 1.600 μs | 0.0022 μs | 0.0020 μs |  1.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 | 1.773 μs | 0.0033 μs | 0.0030 μs |  1.11 |      - |     - |     - |         - |
|                        Linq |   100 | 2.444 μs | 0.0033 μs | 0.0026 μs |  1.53 | 0.0648 |     - |     - |     136 B |
|                  LinqFaster |   100 | 2.332 μs | 0.0077 μs | 0.0072 μs |  1.46 | 1.9379 |     - |     - |    4056 B |
|                      LinqAF |   100 | 2.944 μs | 0.0060 μs | 0.0057 μs |  1.84 |      - |     - |     - |         - |
|                  StructLinq |   100 | 1.823 μs | 0.0031 μs | 0.0028 μs |  1.14 | 0.0191 |     - |     - |      40 B |
|        StructLinq_IFunction |   100 | 1.563 μs | 0.0022 μs | 0.0021 μs |  0.98 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 1.678 μs | 0.0034 μs | 0.0028 μs |  1.05 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 1.539 μs | 0.0029 μs | 0.0025 μs |  0.96 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 1.677 μs | 0.0024 μs | 0.0020 μs |  1.05 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 | 1.550 μs | 0.0034 μs | 0.0030 μs |  0.97 |      - |     - |     - |         - |
