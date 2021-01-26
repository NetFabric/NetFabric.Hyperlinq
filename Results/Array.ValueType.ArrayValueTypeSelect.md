## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

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
|                     ForLoop |   100 | 1.616 μs | 0.0051 μs | 0.0048 μs |  1.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 | 1.682 μs | 0.0067 μs | 0.0060 μs |  1.04 |      - |     - |     - |         - |
|                        Linq |   100 | 2.282 μs | 0.0059 μs | 0.0052 μs |  1.41 | 0.0381 |     - |     - |      80 B |
|                  LinqFaster |   100 | 2.197 μs | 0.0125 μs | 0.0104 μs |  1.36 | 1.9226 |     - |     - |    4024 B |
|                      LinqAF |   100 | 2.797 μs | 0.0100 μs | 0.0094 μs |  1.73 |      - |     - |     - |         - |
|                  StructLinq |   100 | 1.965 μs | 0.0075 μs | 0.0067 μs |  1.22 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 | 1.672 μs | 0.0064 μs | 0.0060 μs |  1.03 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 1.892 μs | 0.0072 μs | 0.0067 μs |  1.17 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 1.722 μs | 0.0062 μs | 0.0052 μs |  1.06 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 1.981 μs | 0.0077 μs | 0.0068 μs |  1.23 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 | 2.500 μs | 0.0087 μs | 0.0082 μs |  1.55 |      - |     - |     - |         - |
