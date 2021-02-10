## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

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
|                     ForLoop |   100 | 1.502 μs | 0.0019 μs | 0.0016 μs |  1.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 | 1.555 μs | 0.0032 μs | 0.0030 μs |  1.04 |      - |     - |     - |         - |
|                        Linq |   100 | 2.130 μs | 0.0045 μs | 0.0042 μs |  1.42 | 0.0381 |     - |     - |      80 B |
|                  LinqFaster |   100 | 1.990 μs | 0.0102 μs | 0.0085 μs |  1.32 | 1.9226 |     - |     - |    4024 B |
|                      LinqAF |   100 | 2.552 μs | 0.0048 μs | 0.0040 μs |  1.70 |      - |     - |     - |         - |
|                  StructLinq |   100 | 1.794 μs | 0.0032 μs | 0.0029 μs |  1.19 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 | 1.551 μs | 0.0030 μs | 0.0024 μs |  1.03 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 1.657 μs | 0.0034 μs | 0.0030 μs |  1.10 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 1.546 μs | 0.0021 μs | 0.0020 μs |  1.03 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 1.681 μs | 0.0027 μs | 0.0023 μs |  1.12 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 | 1.567 μs | 0.0025 μs | 0.0022 μs |  1.04 |      - |     - |     - |         - |
