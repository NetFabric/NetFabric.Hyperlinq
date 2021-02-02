## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta30](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta30)

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
|                     ForLoop |   100 | 1.500 μs | 0.0023 μs | 0.0022 μs |  1.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 | 1.551 μs | 0.0018 μs | 0.0016 μs |  1.03 |      - |     - |     - |         - |
|                        Linq |   100 | 2.124 μs | 0.0044 μs | 0.0037 μs |  1.42 | 0.0381 |     - |     - |      80 B |
|                  LinqFaster |   100 | 1.990 μs | 0.0053 μs | 0.0050 μs |  1.33 | 1.9226 |     - |     - |    4024 B |
|                      LinqAF |   100 | 2.562 μs | 0.0039 μs | 0.0036 μs |  1.71 |      - |     - |     - |         - |
|                  StructLinq |   100 | 1.788 μs | 0.0034 μs | 0.0028 μs |  1.19 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 | 1.545 μs | 0.0025 μs | 0.0023 μs |  1.03 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 1.801 μs | 0.0028 μs | 0.0025 μs |  1.20 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 1.535 μs | 0.0027 μs | 0.0025 μs |  1.02 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 1.806 μs | 0.0028 μs | 0.0025 μs |  1.20 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 | 1.538 μs | 0.0025 μs | 0.0023 μs |  1.03 |      - |     - |     - |         - |
