## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

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
|                     ForLoop |   100 | 1.543 μs | 0.0050 μs | 0.0045 μs |  1.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 | 1.645 μs | 0.0051 μs | 0.0048 μs |  1.07 |      - |     - |     - |         - |
|                        Linq |   100 | 2.175 μs | 0.0079 μs | 0.0074 μs |  1.41 | 0.0381 |     - |     - |      80 B |
|                  LinqFaster |   100 | 2.055 μs | 0.0067 μs | 0.0060 μs |  1.33 | 1.9226 |     - |     - |    4024 B |
|                      LinqAF |   100 | 2.610 μs | 0.0070 μs | 0.0059 μs |  1.69 |      - |     - |     - |         - |
|                  StructLinq |   100 | 1.830 μs | 0.0052 μs | 0.0046 μs |  1.19 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 | 1.579 μs | 0.0042 μs | 0.0039 μs |  1.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 1.691 μs | 0.0043 μs | 0.0040 μs |  1.10 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 1.577 μs | 0.0034 μs | 0.0028 μs |  1.02 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 1.716 μs | 0.0053 μs | 0.0047 μs |  1.11 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 | 1.579 μs | 0.0034 μs | 0.0030 μs |  1.02 |      - |     - |     - |         - |
