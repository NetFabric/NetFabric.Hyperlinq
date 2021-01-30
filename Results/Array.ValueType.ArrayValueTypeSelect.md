## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

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
|                     ForLoop |   100 | 1.490 μs | 0.0026 μs | 0.0023 μs |  1.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 | 1.572 μs | 0.0016 μs | 0.0015 μs |  1.05 |      - |     - |     - |         - |
|                        Linq |   100 | 2.152 μs | 0.0046 μs | 0.0043 μs |  1.44 | 0.0381 |     - |     - |      80 B |
|                  LinqFaster |   100 | 2.017 μs | 0.0061 μs | 0.0057 μs |  1.35 | 1.9226 |     - |     - |    4024 B |
|                      LinqAF |   100 | 2.563 μs | 0.0061 μs | 0.0057 μs |  1.72 |      - |     - |     - |         - |
|                  StructLinq |   100 | 1.776 μs | 0.0030 μs | 0.0027 μs |  1.19 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 | 1.545 μs | 0.0020 μs | 0.0017 μs |  1.04 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 1.712 μs | 0.0028 μs | 0.0025 μs |  1.15 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 1.587 μs | 0.0036 μs | 0.0030 μs |  1.07 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 1.826 μs | 0.0019 μs | 0.0016 μs |  1.23 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 | 1.608 μs | 0.0025 μs | 0.0022 μs |  1.08 |      - |     - |     - |         - |
