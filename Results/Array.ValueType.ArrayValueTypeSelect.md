## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta28](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta28)

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
|                     ForLoop |   100 | 1.618 μs | 0.0044 μs | 0.0041 μs |  1.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 | 1.749 μs | 0.0065 μs | 0.0061 μs |  1.08 |      - |     - |     - |         - |
|                        Linq |   100 | 2.294 μs | 0.0028 μs | 0.0025 μs |  1.42 | 0.0381 |     - |     - |      80 B |
|                  LinqFaster |   100 | 2.220 μs | 0.0108 μs | 0.0096 μs |  1.37 | 1.9226 |     - |     - |    4024 B |
|                      LinqAF |   100 | 2.898 μs | 0.0105 μs | 0.0098 μs |  1.79 |      - |     - |     - |         - |
|                  StructLinq |   100 | 1.947 μs | 0.0128 μs | 0.0114 μs |  1.20 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 | 1.688 μs | 0.0066 μs | 0.0058 μs |  1.04 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 1.872 μs | 0.0060 μs | 0.0056 μs |  1.16 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 1.738 μs | 0.0064 μs | 0.0059 μs |  1.07 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 1.977 μs | 0.0046 μs | 0.0041 μs |  1.22 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 | 1.753 μs | 0.0058 μs | 0.0054 μs |  1.08 |      - |     - |     - |         - |
