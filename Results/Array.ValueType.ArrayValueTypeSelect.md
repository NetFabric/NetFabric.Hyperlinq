## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

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
|                     ForLoop |   100 | 1.496 μs | 0.0026 μs | 0.0023 μs |  1.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 | 1.604 μs | 0.0021 μs | 0.0019 μs |  1.07 |      - |     - |     - |         - |
|                        Linq |   100 | 2.099 μs | 0.0077 μs | 0.0068 μs |  1.40 | 0.0381 |     - |     - |      80 B |
|                  LinqFaster |   100 | 1.999 μs | 0.0114 μs | 0.0101 μs |  1.34 | 1.9226 |     - |     - |    4024 B |
|                      LinqAF |   100 | 2.560 μs | 0.0045 μs | 0.0039 μs |  1.71 |      - |     - |     - |         - |
|                  StructLinq |   100 | 1.814 μs | 0.0020 μs | 0.0018 μs |  1.21 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 | 1.545 μs | 0.0016 μs | 0.0013 μs |  1.03 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 1.709 μs | 0.0042 μs | 0.0037 μs |  1.14 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 1.537 μs | 0.0030 μs | 0.0027 μs |  1.03 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 1.675 μs | 0.0026 μs | 0.0022 μs |  1.12 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 | 1.540 μs | 0.0030 μs | 0.0026 μs |  1.03 |      - |     - |     - |         - |
