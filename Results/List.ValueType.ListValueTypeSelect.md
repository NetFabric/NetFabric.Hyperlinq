## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta35](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta35)

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
|                     ForLoop |   100 | 1.624 μs | 0.0034 μs | 0.0032 μs |  1.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 | 1.768 μs | 0.0026 μs | 0.0022 μs |  1.09 |      - |     - |     - |         - |
|                        Linq |   100 | 2.446 μs | 0.0049 μs | 0.0046 μs |  1.51 | 0.0648 |     - |     - |     136 B |
|                  LinqFaster |   100 | 2.330 μs | 0.0157 μs | 0.0147 μs |  1.43 | 1.9379 |     - |     - |    4056 B |
|                      LinqAF |   100 | 3.190 μs | 0.0057 μs | 0.0053 μs |  1.96 |      - |     - |     - |         - |
|                  StructLinq |   100 | 2.510 μs | 0.0026 μs | 0.0020 μs |  1.55 | 0.0191 |     - |     - |      40 B |
|        StructLinq_IFunction |   100 | 1.579 μs | 0.0033 μs | 0.0030 μs |  0.97 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 1.672 μs | 0.0032 μs | 0.0028 μs |  1.03 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 1.540 μs | 0.0028 μs | 0.0025 μs |  0.95 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 1.698 μs | 0.0027 μs | 0.0023 μs |  1.05 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 | 1.541 μs | 0.0025 μs | 0.0024 μs |  0.95 |      - |     - |     - |         - |
