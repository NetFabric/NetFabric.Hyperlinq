## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
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
|                     ForLoop |   100 | 1.489 μs | 0.0033 μs | 0.0029 μs |  1.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 | 1.571 μs | 0.0031 μs | 0.0028 μs |  1.06 |      - |     - |     - |         - |
|                        Linq |   100 | 2.124 μs | 0.0075 μs | 0.0070 μs |  1.43 | 0.0381 |     - |     - |      80 B |
|                  LinqFaster |   100 | 1.978 μs | 0.0085 μs | 0.0075 μs |  1.33 | 1.9226 |     - |     - |    4024 B |
|                      LinqAF |   100 | 2.539 μs | 0.0097 μs | 0.0081 μs |  1.70 |      - |     - |     - |         - |
|                  StructLinq |   100 | 1.770 μs | 0.0050 μs | 0.0044 μs |  1.19 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 | 1.539 μs | 0.0039 μs | 0.0036 μs |  1.03 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 1.795 μs | 0.0039 μs | 0.0034 μs |  1.21 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 1.586 μs | 0.0033 μs | 0.0031 μs |  1.06 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 1.764 μs | 0.0034 μs | 0.0028 μs |  1.18 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 | 2.311 μs | 0.0045 μs | 0.0040 μs |  1.55 |      - |     - |     - |         - |
